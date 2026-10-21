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
        string result = this._player.GetInformation();

        Assert.That(result, Does.Contain("Anna"), "The name should be Anna");
        Assert.That(result.Split('0').Length - 1, Is.GreaterThanOrEqualTo(2));
    }

    [Test]
    public void TestCreatePlayerWithNoName()
    {
        Player player = new Player();
        string result = player.GetInformation();

        Assert.That(result, Does.Not.Contain("Anna"), "The Player class should contain a default constructor with no parameters.");
        Assert.That(result.Split('0').Length - 1, Is.GreaterThanOrEqualTo(2));
    }

    [Test]
    public void TestAddScoreAndAddsPoints()
    {
        this._player.AddScore(15);
        Assert.That(this._player.GetInformation(), Does.Contain("15"), "The score should be 15");
    }

    [Test]
    public void TestAddScoreMultipleTimesAccumulates()
    {
        this._player.AddScore(10);
        this._player.AddScore(20);
        Assert.That(this._player.GetInformation(), Does.Contain("30"), "The score should be 30");
    }

    [Test]
    public void TestAddRoundIncrementsRounds()
    {
        this._player.AddRound();
        Assert.That(this._player.GetInformation(), Does.Contain("1"), "The number of rounds should be 1");
    }

    [Test]
    public void TestAddRoundMultipleTimesAccumulates()
    {
        this._player.AddRound();
        this._player.AddRound();
        this._player.AddRound();
        Assert.That(this._player.GetInformation(), Does.Contain("3"), "The number of rounds should be 3");
    }
}
