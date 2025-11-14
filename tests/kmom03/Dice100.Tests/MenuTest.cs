namespace Dice100.Tests;
using Dice100.src;

public class MenuTest
{
    private TextWriter _originalOut;
    private TextReader _originalIn;
    Menu _menu;

    [SetUp]
    public void SetUp()
    {
        this._menu = new Menu();
        this._originalOut = Console.Out;
        this._originalIn = Console.In;
    }


    [TearDown]
    public void TearDown()
    {
        Console.SetOut(this._originalOut);
        Console.SetIn(this._originalIn);
    }


    [Test]
    public void TestInputValues()
    {
        string name = "Marie";
        string noOfDice = "4";
        string title = "Dice100";

        var input = new StringReader(name + "\n" + noOfDice +"\n");
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        _menu.InitGame();
        var content = output.ToString() ?? "";

        Assert.That(content, Does.Contain(title), $"Välkomstmeddelandet ska innehålla titeln: {title}.");
        Assert.That(content, Does.Contain(name), $"Välkomstmeddelandet ska innehålla namnet: {name}.");
        Assert.That(content, Does.Contain(noOfDice), $"Välkomstmeddelandet ska innehålla antalet tärningar {noOfDice}.");
        TestContext.Out.WriteLine("✅ Godkänt valkomstmeddelande med rubrik, namn och antal tärningar");
    }

    [Test]
    public void TestInputNoOfDiesTooHigh()
    {
        string name = "Marie";
        string noOfDice = "4";
        string noOfDiceTooHigh = "14";
        string errorMessage = "vara 10 eller färre";

        var input = new StringReader(name + "\n" + noOfDiceTooHigh +"\n" + noOfDice + "\n");
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);
        _menu.InitGame();

        var content = output.ToString() ?? "";

        Assert.That(content, Does.Contain(errorMessage), $"Felmeddelandet ska innehålla delsträngen: {errorMessage}.");
        Assert.That(content, Does.Contain(noOfDice), $"Antalet tärningar {noOfDice}.");
        TestContext.Out.WriteLine("✅ Inmatning av antalet tärningar över 10 kastar NumberOfDieException");
    }

    [Test]
    public void TestInputNoOfDiesTooLow()
    {
        string name = "Marie";
        string noOfDice = "5";
        string noOfDiceTooLow = "1";
        string errorMessage = "vara 2 eller fler";

        var input = new StringReader(name + "\n" + noOfDiceTooLow + "\n" + noOfDice + "\n");
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);
        _menu.InitGame();

        var content = output.ToString() ?? "";

        Assert.That(content, Does.Contain(errorMessage), $"Felmeddelandet ska innehålla delsträngen: {errorMessage}.");
        Assert.That(content, Does.Contain(noOfDice), $"Antalet tärningar {noOfDice}.");
        TestContext.Out.WriteLine("✅ Inmatning av antalet tärningar mindre än 2 kastar NumberOfDieException");
    }
}