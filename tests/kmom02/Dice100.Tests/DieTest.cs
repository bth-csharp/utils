namespace Dice100.src;

[TestFixture]
public class DieTest
{
    private const int MAX_VALUE = 6;
    private const int MIN_VALUE = 1;
    private const int MAX_NUMBER_OF_SIDES = 20;
    private const int MIN_NUMBER_OF_SIDES = 4;
    private List<int> _numbers;

    [SetUp]
    public void Setup()
    {
        this._numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
    }


    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        if (TestContext.CurrentContext.Result.FailCount == 0)
        {
            TestContext.Progress.WriteLine("✅ Alla testfall i Die gick igenom.\n");
        }
        else
        {
            TestContext.Progress.WriteLine("❌ Något testfall gick fel i Die.\n");
        }
    }

    [Test]
    public void TestCreateDie()
    {
        Die die = new Die();
        Assert.That(die.GetValue(), Is.LessThanOrEqualTo(MAX_VALUE), "The value of the Die should be 1 <= value <= 6.");
        Assert.That(die.GetValue(), Is.GreaterThanOrEqualTo(MIN_VALUE), "The value of the Die should be 1 <= value <= 6.");
    }

    [Test]
    public void TestCreateDieValidNumbers()
    {
        Die die = new Die();
        Assert.That(this._numbers.Contains(die.GetValue()), Is.True, "The value of the Die should be 1 <= value <= 6.");
    }

    [TestCase(4)]
    [TestCase(8)]
    [TestCase(18)]
    public void TestCreateDieWithSides(int sides)
    {
        Die die = new Die(sides);
        Assert.That(die.GetSides(), Is.EqualTo(sides), "The value of the Die should be " + sides + ".");
    }

    [Test]
    public void TestCreateDieWithSidesTooHigh()
    {
        Die die = new Die(555);
        Assert.That(die.GetSides(), Is.EqualTo(MAX_NUMBER_OF_SIDES), $"The number of sides should be {MAX_NUMBER_OF_SIDES}.");
    }

    [Test]
    public void TestCreateDieWithArgumentTooLow0()
    {
        Die die = new Die(1);
        Assert.That(die.GetSides(), Is.EqualTo(MIN_NUMBER_OF_SIDES), $"The number of sides should be {MIN_NUMBER_OF_SIDES}.");
    }

    [Test]
    public void TestRollDieTwice()
    {
        Die die = new Die();
        Assert.That(this._numbers.Contains(die.GetValue()), Is.True, "The value of the Die should be 1 <= value <= 6 after Roll.");
        die.Roll();
        Assert.That(this._numbers.Contains(die.GetValue()), Is.True, "The value of the Die should be 1 <= value <= 6 after Roll.");
        die.Roll();
        Assert.That(this._numbers.Contains(die.GetValue()), Is.True, "The value of the Die should be 1 <= value <= 6 after Roll.");
    }

    [TestCase(10)]
    [TestCase(18)]
    public void TestRollWithMoreSidesThan6(int sides)
    {
        Die die = new Die(sides);
        Assert.That(die.GetValue(), Is.LessThanOrEqualTo(MAX_NUMBER_OF_SIDES), $"The value of the Die should be 1 <= value <= {sides}.");
        Assert.That(die.GetValue(), Is.GreaterThanOrEqualTo(MIN_VALUE), $"The value of the Die should be 1 <= value <= {sides}.");
    }

    public void TestGetValueAsStrings()
    {
        Die die = new Die();
        for (int i = 0; i < 10; i++)
        {
            die.Roll();
            Assert.That(die.GetValueAsString(), Does.Contain("123456"), "GetValueAsString should return a substring in '123456'");
        }
    }
}
