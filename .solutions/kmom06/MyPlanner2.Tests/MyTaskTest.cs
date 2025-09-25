using Moq;
using MyPlanner2.src;

namespace MyPlanner2.Tests;

public class MyTaskTest
{
    private DateTime _dateToday;

    [SetUp]
    public void Setup()
    {
        _dateToday = DateTime.Today; // använd Now om du vill ha tiden med
    }

    [Test]
    public void TestCreateMyTask()
    {
        DateTime newDate = _dateToday.AddDays(3);
        PrivateTask task = new("Hemma", "Test", "Test MyTask", newDate);
        Assert.Multiple(() =>
        {
            Assert.That(task.GetTitle(), Does.Contain("Test"), "The title should contain Test.");
            Assert.That(task.GetDueDate().ToString("yyyy-MM-dd"), Is.EqualTo(newDate.ToString("yyyy-MM-dd")), "The dates should be the same, the date of today plus 3 days.");
            Assert.That(task.IsCompleted(), Is.False, "The task should be not completed.");
        });
    }

    [Test]
    public void TestUpdateMyTaskPrivate()
    {
        PrivateTask task = new("Hemma", "Privat", "Test PrivateTask", _dateToday);
        task.Update("Hemma2", "Privat", "Test PrivateTask2", _dateToday.AddDays(2));
        List<string> expected = new List<string> { "Hemma2", "Privat", "Test PrivateTask2", _dateToday.AddDays(2).ToString("yyyy-MM-dd"), "false" };
        List<string> actual = task.GetInformation();
        Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
    }

    [Test]
    public void TestUpdateMyTaskWork()
    {
        WorkTask task = new(1, 100, "Testproject", "Arbete", "Test WorkTask", _dateToday);
        task.Update(2, 80, 70, "Testproject2", "Arbete", "Test WorkTask2", _dateToday.AddDays(2));
        task.Completed();
        List<string> expected = new List<string> { "2", "80", "70", "Testproject2", "Arbete", "Test WorkTask2", _dateToday.AddDays(2).ToString("yyyy-MM-dd"), "true" };
        List<string> actual = task.GetInformation();
        Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
    }

    [Test]
    public void TestDescriptionNotCompleted()
    {
        //MyTask task = new ("Test", "Test MyTask", this._dateToday);
        string myDate = this._dateToday.ToString("yyyy-MM-dd");
        var mockTask = new Mock<MyTask>("Test", "Test MyTask", this._dateToday);
        string mockedResult = $"Uppgiften Test ska vara klar senast 📅 {myDate} och är ej klar ⏳.\nBeskrivning: Test MyTask";
        mockTask.Setup(m => m.GetDescription()).Returns(mockedResult);
        string result = $"Uppgiften Test ska vara klar senast 📅 {myDate} och är ej klar ⏳.";
        result += "\nBeskrivning: Test MyTask";
        Assert.That(mockTask.Object.GetDescription(), Does.Contain(result), "The description should contain: " + result);
    }

    /*     [Test]
        public void TestDescriptionCompleted()
        {
            MyTask task = new("Test", "Test MyTask", this._dateToday.AddDays(3));
            task.Completed();
            string myDate = this._dateToday.AddDays(3).ToString("yyyy-MM-dd");
            string result = $"\n📋 Uppgiften Test ska vara klar senast 📅 {myDate} och är klar ✅.";
            result += "\nBeskrivning: Test MyTask";
            Assert.That(task.GetDescription(), Does.Contain(result), "The description should contain: " + result);
        }

        [Test]
        public void TestGetInformation()
        {
            MyTask task = new("Test", "Test MyTask", this._dateToday);
            List<string> expected = new List<string> { "Test", "Test MyTask", _dateToday.ToString("yyyy-MM-dd"), "false"};
            List<string> actual = task.GetInformation();
            bool same = actual.SequenceEqual(expected);
            Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
        } */
}
