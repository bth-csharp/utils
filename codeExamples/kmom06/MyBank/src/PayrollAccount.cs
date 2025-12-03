namespace MyBank.src;

/// <summary>
/// This is a PayrollAccount class is a subclass to BankAccount and 
/// is documented with XML documentation.
/// </summary>
/// <author>Marie Grahn</author>
/// <date>2024-05-30</date>
public class PayrollAccount : BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PayrollAccount"/> class.
    /// Primary constructor could be used, use this constructor for clarification.
    /// </summary>
    /// <param name="name">The name of the the owner of the bank account.</param>
    /// <param name="initialBalance">The balance of the bank account.</param>

    public PayrollAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    /// <summary>
    /// This method prints information of this bank account in the terminal.
    /// </summary>
    public void PrintDescription()
    {
        Console.WriteLine($"Detta lönekonto skapades till {base._owner} med saldot {base._balance} kr.");
    }

    /// <summary>
    /// This method performs a monthly task which is to take a fee for
    /// bank account with high balance.
    /// Returns true if succeeded and false if failure.
    /// </summary>
    /// <returns>true if succeeded and false if failure.</returns>
    public override bool PerformMonthEndTransactions()
    {
        decimal fee = 0.0m;

        if (this._balance > 100m)
        {
            fee = 0.001m;
        }

        return Withdraw(fee);
    }
}