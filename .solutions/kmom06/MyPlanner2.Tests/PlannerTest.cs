using Moq;
using NUnit.Framework.Internal;
using MyPlanner2.src;

namespace MyPlanner2.Tests;

[TestFixture]
public class PlannerTest
{
    private Planner _myPlanner;
    private StringWriter _stringWriter;
    private StringReader _stringReader;

    [SetUp]
    public void Setup()
    {
        _myPlanner = new Planner();
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
        _stringReader = new StringReader("");
    }

    [TearDown]
    public void TearDown()
    {
        _stringWriter.Dispose();
        _stringReader?.Dispose();
    }

    [Test]
    public void TestCreatePlanner()
    {
        Assert.That(_myPlanner, Is.InstanceOf<Planner>());
        Assert.That(_myPlanner.GetNoOfTasks(), Is.EqualTo(0), "Number of tasks should be 0.");
       
    }

    [Test]
    public void TestShowMenu()
    {
        string input = "e" + Environment.NewLine; // Avsluta menyn
        _stringReader = new StringReader(input);
        Console.SetIn(_stringReader);
        _myPlanner.Run();
        var output = _stringWriter.ToString();
        Assert.That(output, Does.Contain("1 - Skapa en uppgift"), "The string should contain: 1 - Skapa en uppgift");
        Assert.That(output, Does.Contain("2 - Uppdatera en uppgift"), "The string should contain: 2 - Uppdatera en uppgift");
        Assert.That(output, Does.Contain("3 - Ta bort en uppgift"), "The string should contain: 3 - Ta bort en uppgift");
        Assert.That(output, Does.Contain("4 - Skriv ut alla uppgifter"), "The string should contain: 4 - Skriv ut alla uppgifter");
        Assert.That(output, Does.Contain("5 - Sätt en uppgift till klar"), "The string should contain: 5 - Skriv ut alla avklarade uppgifter");
        Assert.That(output, Does.Contain("e - Avsluta"), "The string should contain: " + "e - Avsluta");
    }

    [Test]
    public void TestMenuEnd()
    {
        string input = "e" + Environment.NewLine; // Avsluta menyn
        _stringReader = new StringReader(input);
        Console.SetIn(_stringReader);
        string result = "\nDu har valt att avsluta! Hej då!";
        _myPlanner.Run();
        var output = _stringWriter.ToString();
        Assert.That(output, Does.Contain(result), "The string should be: " + result);
    }

    [Test]
    public void TestInvalidMenuOption()
    {
        string input = "invalid" + Environment.NewLine; // Felaktigt menyval
        input += "e" + Environment.NewLine; // Avsluta menyn
        _stringReader = new StringReader(input);
        Console.SetIn(_stringReader);
        string result = "\nOgiltigt menyval";
        _myPlanner.Run();
        var output = _stringWriter.ToString();
        Assert.That(output, Does.Contain(result), "The string should be: " + result);
    }

/*     [Test]
    public void TestMenuOptionCreate()
    {
        var _mockPlanner = new Mock<IPlanner>();

        string input = "1" + Environment.NewLine; // Välj skapa uppgift
        input += "e" + Environment.NewLine; // Avsluta menyn
        _stringReader = new StringReader(input);
        Console.SetIn(_stringReader);
        string result = "\nUppgiften Test är skapad!";
        _mockPlanner.Setup(p => p.GetNoOfTasks()).Returns(1);
        _mockPlanner.Setup(p => p.Run()).Callback(() => Console.WriteLine("\nUppgiften Test är skapad!"));
        
        _mockPlanner.Object.Run();
        var output = _stringWriter.ToString();
        Assert.Multiple(() =>
        {
            Assert.That(output, Does.Contain(result), "The string should be: " + result);
            Assert.That(_mockPlanner.Object.GetNoOfTasks(), Is.EqualTo(1), "Number of tasks should be 1.");
        });
    } */
}