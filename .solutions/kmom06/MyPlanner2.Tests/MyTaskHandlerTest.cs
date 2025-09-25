using NUnit.Framework;
using Moq;
using MyPlanner2.src;

namespace MyPlanner2.Tests;

public class MyTaskHandlerTest
{
    private MyTaskHandler _myTaskHandler;
    private DateTime _dateToday;
    private DateTime _oneDayAhead;

    [SetUp]
    public void Setup()
    {
        _dateToday = DateTime.Today; // använd Now om du vill ha tiden med
        _myTaskHandler = new MyTaskHandler();
        _oneDayAhead = _dateToday.AddDays(1);
    }

    [Test]
    public void TestCreateTaskHandler()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_myTaskHandler, Is.Not.Null);
            Assert.That(_myTaskHandler, Is.InstanceOf<MyTaskHandler>(), "The type should be MyTaskHandler.");
            Assert.That(_myTaskHandler!.GetNoOfTasks(), Is.EqualTo(0), "There should be 0 tasks in the taskhandler.");
            // utropstecknet efter _myTaskHandler visar kompilatorn att vi vet att objektet inte är null
        });
    }

    [Test]
    public void TestCreatePrivateTask()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
    }

    [Test]
    public void TestCreateWorkTask()
    {
        _myTaskHandler.CreateTask(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _dateToday.AddDays(1));
        Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
    }

    [Test]
    public void TestUpdatePrivateTask()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        bool editOk = _myTaskHandler.UpdateTask("Hemma", "Privat", "Test PrivateTask change", _oneDayAhead, true);
        string result = _myTaskHandler.GetDescription("Privat");
        Assert.Multiple(() =>
        {
            Assert.That(editOk, Is.True, "Task should be found and UpdateTask should return true.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
            Assert.That(result, Does.Contain("Test PrivateTask change"), "Task projectname should not be changed to Test PrivateTask change.");
            Assert.That(result, Does.Contain(_oneDayAhead.ToString("yyyy-MM-dd")), "Task dueDate changed one day ahead.");
            Assert.That(result, Does.Contain("är klar"), "Task should be completed.");
        });
    }

    [Test]
    public void TestUpdateWorkTask()
    {
        DateTime threeDaysAhead = _oneDayAhead.AddDays(2);
        _myTaskHandler.CreateTask(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _oneDayAhead);
        bool editOk = _myTaskHandler.UpdateTask(1, 100, 40, "Testprojekt", "Arbete", "Test WorkTask extra jobb", threeDaysAhead, true);
        string result = _myTaskHandler.GetDescription("Arbete");
        Assert.Multiple(() =>
        {
            Assert.That(editOk, Is.True, "Task should be found and UpdateTask should return true.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
            Assert.That(result, Does.Contain("Testprojekt"), "Task projectname should not be changed.");
            Assert.That(result, Does.Contain("Test WorkTask extra jobb"), "Task description should be changed to Test WorkTask extra jobb.");
            Assert.That(result, Does.Contain(threeDaysAhead.ToString("yyyy-MM-dd")), "Task dueDate changed one day ahead.");
            Assert.That(result, Does.Contain("är klar"), "Task should be completed.");
        });
    }

    [Test]
    public void TestUpdatePrivateTaskNegative()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        bool editOk = _myTaskHandler.UpdateTask("Borta", "Privat2", "Test PrivateTask change", _oneDayAhead, false);
        Assert.Multiple(() =>
        {
            Assert.That(editOk, Is.False, "Task should not be found and UpdateTask should return false.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
        });
    }

    [Test]
    public void TestUpdateWorkTaskNegative()
    {
        _myTaskHandler.CreateTask(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _oneDayAhead);
        bool editOk = _myTaskHandler.UpdateTask(1, 100, 40, "Testprojekt", "Fritid", "Test WorkTask extra jobb", _dateToday, true);
        Assert.Multiple(() =>
        {
            Assert.That(editOk, Is.False, "Task should not be found and UpdateTask should return false.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
        });
    }

    [Test]
    public void TestCompleteTask()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        _myTaskHandler.CompleteTask("Privat");
        string result = _myTaskHandler.GetDescription("Privat");
        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain("är klar"), "Task should be completed.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
        });
    }

    [Test]
    public void TestCompleteTaskNegative()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        _myTaskHandler.CompleteTask("Privat2");
        string result = _myTaskHandler.GetDescription("Privat2");
        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Not.Contain("är klar"), "Task should be completed.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
        });
    }

    [Test]
    public void TestGetOneTask()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        List<string> expected = new List<string> { "Hemma", "Privat", "Test PrivateTask", _dateToday.ToString("yyyy-MM-dd"), "false" };
        List<string> actual = _myTaskHandler.GetOneTasksInfo("Privat");
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 tasks in the taskhandler.");
        });
    }

    [Test]
    public void TestGetTasks()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        _myTaskHandler.CreateTask(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _oneDayAhead);
        int actual = _myTaskHandler.GetTasks().Count();
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.EqualTo(2), "There should be 2 tasks returned from GetTasks().");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(2), "There should be 2 tasks in the taskhandler.");
        });
    }

    [Test]
    public void TestDescriptionPrivateTaskNegative()
    {
        string expected = "\nUppgiften Privat kunde inte hittas, beskrivning saknas!";
        string result = _myTaskHandler.GetDescription("Privat");
        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(expected), "Task should not be found.");
            Assert.That(_myTaskHandler!.GetNoOfTasks(), Is.EqualTo(0), "There should be 0 tasks in the taskhandler.");
        });
    }

    [Test]
    public void TestDescriptionWorkTaskNegative()
    {
        string expected = "\nUppgiften Arbete kunde inte hittas, beskrivning saknas!";
        string result = _myTaskHandler.GetDescription("Arbete");
        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(expected), "Task should not be found.");
            Assert.That(_myTaskHandler!.GetNoOfTasks(), Is.EqualTo(0), "There should be 0 tasks in the taskhandler.");
        });
    }

    [Test]
    public void TestDeleteTask()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        _myTaskHandler.CreateTask(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _oneDayAhead);
        bool deleteOk = _myTaskHandler.DeleteTask("Privat");
        Assert.Multiple(() =>
        {
            Assert.That(deleteOk, Is.True, "Task should be found and deleted and DeleteTask should return true.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(1), "There should be 1 task in the taskhandler.");
        });
    }

    [Test]
    public void TestDeleteTaskNegative()
    {
        _myTaskHandler.CreateTask("Hemma", "Privat", "Test PrivateTask", _dateToday);
        _myTaskHandler.CreateTask(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _oneDayAhead);
        bool deleteOk = _myTaskHandler.DeleteTask("Privat2");
        Assert.Multiple(() =>
        {
            Assert.That(deleteOk, Is.False, "Task should not be found nor deleted and DeleteTask should return false.");
            Assert.That(_myTaskHandler.GetNoOfTasks(), Is.EqualTo(2), "There should be 2 tasks in the taskhandler.");
        });
    }

    [Test]
    public void TestGetNoOfTasksMock()
    {
        // Arrange
        var mockHandler = new Mock<MyTaskHandler>();
        mockHandler.Setup(h => h.GetNoOfTasks()).Returns(2);

        // Arrange
        var noOfTasks = mockHandler.Object.GetNoOfTasks();

        // Assert
        Assert.That(noOfTasks, Is.EqualTo(2), "There should be 2 tasks in the taskhandler.");
    }
}
