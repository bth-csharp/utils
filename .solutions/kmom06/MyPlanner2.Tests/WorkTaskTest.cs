using MyPlanner2.src;

namespace MyPlanner2.Tests;

public class WorkTaskTest
{
    private DateTime _dateToday;

    [SetUp]
    public void Setup()
    {
        _dateToday = DateTime.Today; // använd Now om du vill ha tiden med        
    }

    [TestCase(0)]
    [TestCase(100)]
    public void CreateWorkTask(int input)
    {
        DateTime newDate = _dateToday.AddDays(3);
        WorkTask task = new(3, input, "Testprojekt", "Arbete", "Test WorkTask", newDate);
        Assert.Multiple(() =>
        {
            Assert.That(task.GetTitle(), Does.Contain("Arbete"), "The title should contain Privat.");
            Assert.That(task.GetDueDate().ToString("yyyy-MM-dd"), Is.EqualTo(newDate.ToString("yyyy-MM-dd")), "The dates should be the same, the date of today plus 3 days.");
            Assert.That(task.GetPrio(), Is.EqualTo(3), "The prio should be the 1.");
            Assert.That(task.GetProjectName(), Does.Contain("Testprojekt"), "The project name of the task should be Testprojekt.");
        });
    }


    [TestCase(0, 0)]
    [TestCase(40, 40)]
    [TestCase(50, 50)]
    [TestCase(100, 100)]
    public void TestGetProgression(int input, int expected)
    {
        DateTime newDate = _dateToday.AddDays(3);
        WorkTask task = new(3, 100, "Testprojekt", "Arbete", "Test WorkTask", newDate);
        task.Update(3, 100, input, "Testprojekt", "Arbete", "Test WorkTask", newDate);
        var result = task.GetProgression();
        Assert.That(result, Is.EqualTo(expected), $"The progression should be {expected}%.");
    }

    [TestCase(0, false)]
    [TestCase(50, false)]
    [TestCase(80, true)]
    [TestCase(100, true)]
    public void TestIsCompleted(int input, bool expected)
    {
        WorkTask task = new(3, 100, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        task.Update(3, 100, input, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        task.Completed();
        var result = task.IsCompleted();
        Assert.That(result, Is.EqualTo(expected), $"The task should be {expected}.");
    }

    [Test]
    public void TestDescription()
    {
        WorkTask task = new(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        string myDate = _dateToday.ToString("yyyy-MM-dd");
        string result = $"\n📋 Uppgiften Arbete ska vara klar senast 📅 {myDate} och är ej klar ⏳.";
        result += "\nBeskrivning: Test WorkTask";
        result += "\nProjektnamn: Testprojekt och är klar till 0% (Prio: 2)";
        Assert.That(task.GetDescription(), Does.Contain(result), "The description should contain: " + result);
    }

    [Test]
    public void TestGetInformation()
    {
        // Arrange
        WorkTask task = new(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        task.Update(2, 100, 90, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        task.Completed();
        List<string> expected = new List<string> { "2", "100", "90", "Testprojekt", "Arbete", "Test WorkTask", _dateToday.ToString("yyyy-MM-dd"), "true" };
        // Act
        List<string> actual = task.GetInformation();
        //Assert
        bool same = actual.SequenceEqual(expected);
        Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
    }

    [Test]
    public void TestGetFieldInfo()
    {
        // Arrange
        WorkTask task = new(2, 100, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        task.Update(2, 100, 90, "Testprojekt", "Arbete", "Test WorkTask", _dateToday);
        task.Completed();
        List<string> expected = new List<string> { "2", "100", "90", "Testprojekt", "Arbete", "Test WorkTask", _dateToday.ToString("yyyy-MM-dd"), "true" };
        // Act
        List<string> actual = task.GetFieldInfo();
        //Assert
        bool same = actual.SequenceEqual(expected);
        Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
    }
}
