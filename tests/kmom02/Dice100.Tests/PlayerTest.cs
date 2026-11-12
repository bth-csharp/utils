namespace Dice100.src;

public class PlayerTest
{
    private Player _player;

    [SetUp]
    public void SetUp()
    {
        this._player = new Player("Anna");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        if (TestContext.CurrentContext.Result.FailCount == 0)
        {
            TestContext.Progress.WriteLine("✅ Alla testfall i Player gick igenom.\n");
        }
        else
        {
            TestContext.Progress.WriteLine("❌ Något testfall gick fel i Player.\n");
        }
    }

    [Test]
    public void TestCreatePlayerWithName()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        this._player.PrintInformation();
        string result = writer.ToString();

        Assert.That(result, Does.Contain("Anna"), "The name should be Anna");
        Assert.That(result.Split('0').Length - 1, Is.GreaterThanOrEqualTo(2));

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [Test]
    public void TestCreatePlayerWithNoName()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        Player player = new Player();
        player.PrintInformation();
        string result = writer.ToString();

        Assert.That(result, Does.Not.Contain("Anna"), "The Player class should contain a default constructor with no parameters.");
        Assert.That(result.Split('0').Length - 1, Is.GreaterThanOrEqualTo(2));

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [Test]
    public void TestAddScoreMultipleTimesAccumulates()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        this._player.PrintInformation();
        string result = writer.ToString();

        Assert.That(result, Does.Contain("Anna"), "The name should be Anna");
        Assert.That(result.Split('0').Length - 1, Is.GreaterThanOrEqualTo(2));

        this._player.AddScore(10);
        this._player.PrintInformation();
        result = writer.ToString();
        Assert.That(result, Does.Contain("10"), "The player should have score 10.");

        this._player.AddScore(15);
        this._player.AddScore(20);
        this._player.PrintInformation();
        result = writer.ToString();
        Assert.That(result, Does.Contain("45"), "The player should have score 45.");

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [Test]
    public void TestAddRoundMultipleTimesAccumulates()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        this._player.PrintInformation();
        string result = writer.ToString();

        Assert.That(result, Does.Contain("Anna"), "The name should be Anna");
        Assert.That(result.Split('0').Length - 1, Is.GreaterThanOrEqualTo(2));

        this._player.AddRound();
        this._player.AddRound();
        this._player.PrintInformation();
        result = writer.ToString();
        Assert.That(result, Does.Contain("2"), "The player should have 2 rounds.");

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
}
