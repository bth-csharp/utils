using MyBank2.src;
using Moq;

[TestFixture]
public class BankTests
{
    private Bank _bank;
    private const string BANK_NAME = "Dbwebb Bank";

    [SetUp]
    public void Setup()
    {
        // Arrange
        _bank = new Bank();
    }

    [Test]
    public void TestCreateBank()
    {
        // Assert and Act
        Assert.That(Bank.BANK_NAME, Does.Contain(BANK_NAME));
        Assert.That(_bank.GetNoOfAccounts(), Does.Contain("0"));
    }

    [Test]
    public void TestCreateBankDescription()
    {
        // Assert and Act
        Assert.That(_bank.GetDescription(), Does.Contain($"Banken heter {Bank.BANK_NAME} och har {_bank.GetNoOfAccounts()} konton."));
    }

    [Test]
    public void TestAddAccounts()
    {
        // Arrange
        var mockAccount1 = new Mock<BankAccount>("Owner 1", 12000m);
        var mockAccount2 = new Mock<BankAccount>("Owner 2", 2000m);

        // Act
        _bank.AddAccount(mockAccount1.Object);
        _bank.AddAccount(mockAccount2.Object);

        // Assert
        Assert.That(_bank.GetNoOfAccounts(), Does.Contain("2"));
    }

    [Test]
    public void TestNoOfAccounts()
    {
        // Arrange
        var mockBank = new Mock<Bank>() { CallBase = true };

        mockBank.Setup(b => b.GetNoOfAccounts()).Returns("2");

        // Act
        var noOfAccounts = mockBank.Object.GetNoOfAccounts();

        // Assert
        Assert.That(noOfAccounts, Does.Contain("2"));
    }

    [Test]
    public void TestDescriptionWithInterface()
    {
        // Arrange
        var mockBank = new Mock<IBank>();
        string message = $"Banken heter {BANK_NAME}";
        mockBank.Setup(m => m.PrintDescription()).Callback(() => Console.WriteLine(message));

        // Act
        mockBank.Object.PrintDescription();

        // Assert att Verify använts en gång
        mockBank.Verify(b => b.PrintDescription(), Times.Once());
    }

    [Test]
    public void TestNoOfAccountsWithInterface()
    {
        // Arrange
        var mockBank = new Mock<IBank>();
        mockBank.Setup(m => m.GetNoOfAccounts()).Returns("3");

        // Act
        var noOfAccounts = mockBank.Object.GetNoOfAccounts();

        // Assert
        mockBank.Verify(m => m.GetNoOfAccounts(), Times.AtLeastOnce());
        Assert.That(noOfAccounts, Does.Contain("3")); 
    }
}
