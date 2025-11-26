using MyBank2.src;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void TestCreateBankAccount()
    {
        // Arrange 
        var account = new BankAccount("Test person", 1000);
        // Assert and no Act
        Assert.That(account.GetOwner(), Does.Contain("Test person"));
        Assert.That(account.GetBalance(), Is.EqualTo(1000));
    }

    [Test]
    public void TestCreateBankAccountNegative()
    {
        // Arrange & Assert
        Assert.That(() => new BankAccount("Test person", -1000), 
            Throws.TypeOf<CreateBankAccountException>()
            .With.Message.EqualTo("Bankkontot ska skapas med saldo >= 0."));
        //Assert.That(ex.Message, Does.Contain("Bank account must be created with balance >= 0."));
    }
}