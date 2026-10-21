namespace Dice100.Tests;
using Dice100.src;

public class GameTest
{
    Game _game;
    private TextWriter _originalOut;
    private TextReader _originalIn;

    [SetUp]
    public void SetUp()
    {
        this._originalOut = Console.Out;
        this._originalIn = Console.In;
        Console.SetOut(new StringWriter());
        this._game = new Game();
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(this._originalOut);
        Console.SetIn(this._originalIn);
    }

    [Test]
    public void TestGame()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        List<Player> players = [];
        players.Add(new Player("Test name 1"));

        Game game = new Game(players);
        Console.SetIn(new StringReader("1\n\nh\nh\nh\nh\nh\nh\nh\nh\nh\nh\nh\nh\nh\n4\n"));
        game.Run();

        string result = writer.ToString();

        Assert.That(result, Does.Contain("Test name 1"));
        //Assert.That(result.GetWinner().GetTotalScore(), Is.GreaterThanOrEqualTo(100));

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        TestContext.Out.WriteLine("✅ Game  play ok");
    }

/*     [Test]
    public void TestInputNoOfDiesTooHigh()
    {
        int noOfDiceTooHigh = 14;
        
        Assert.Throws<NumberOfDieException>(() => _game.SetNumberOfDice(noOfDiceTooHigh));
        TestContext.Out.WriteLine("✅ SetNumberOfDice, NumberOfDieException kastas när antalet tärningar är större än 10");
    }

    [Test]
    public void TestInputNoOfDiesTooLow()
    {
        int noOfDiceTooLow = 1;

        Assert.Throws<NumberOfDieException>(() => _game.SetNumberOfDice(noOfDiceTooLow));
        TestContext.Out.WriteLine("✅ SetNumberOfDice, NumberOfDieException kastas när antalet tärningar är mindre än 2");
    } */
}
