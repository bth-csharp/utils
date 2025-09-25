namespace MyPlanner.Tests;
using MyPlanner.src;

public class PrivateTaskTest
{
    private DateTime _dateToday;

    [SetUp]
    public void Setup()
    {
        _dateToday = DateTime.Today; // använd Now om du vill ha tiden med        
    }

    [Test]
    public void CreatePrivateTask()
    {
        DateTime newDate = _dateToday.AddDays(3);
        PrivateTask task = new("Hemma", "Privat", "Test PrivateTask", newDate);
        Assert.Multiple(() =>
        {
            Assert.That(task.GetTitle(), Does.Contain("Privat"), "The title should contain Privat.");
            Assert.That(task.GetDueDate().ToString("yyyy-MM-dd"), Is.EqualTo(newDate.ToString("yyyy-MM-dd")), "The dates should be the same, the date of today plus 3 days.");
            Assert.That(task.GetLocation(), Does.Contain("Hemma"), "The location of the task should be Hemma.");
        });
    }

    [Test]
    public void TestDescription()
    {
        PrivateTask task = new("Hemma", "Privat", "Test PrivateTask", _dateToday);
        task.Completed();
        string myDate = _dateToday.ToString("yyyy-MM-dd");
        string result = $"\n📋 Uppgiften Privat ska vara klar senast {myDate} och är klar ✅.";
        result += "\nBeskrivning: Test PrivateTask";
        result += "\nPlats: Hemma";
        Assert.That(task.GetDescription(), Does.Contain(result), "The description should contain: " + result);
    }

    [Test]
    public void TestGetInformation()
    {
        PrivateTask task = new("Hemma", "Privat", "Test PrivateTask", _dateToday);
        List<string> expected = new List<string> { "Hemma", "Privat" , "Test PrivateTask", _dateToday.ToString("yyyy-MM-dd"), "false"};
        List<string> actual = task.GetInformation();
        bool same = actual.SequenceEqual(expected);
        Assert.That(actual, Is.EqualTo(expected), "The list should be the same.");
    }
}
