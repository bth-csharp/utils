namespace MyBank.src;

/// <summary>
/// This is a BankAccount class is documented with XML documentation.
/// </summary>
/// <author>Marie Grahn</author>
/// <date>2024-05-30</date>
public class BankAccount
{
    /// <summary>
    /// The seed number used to create unique numbers for the bank accounts.
    /// </summary>
    private static int _accountNumberSeed = 1234567890;

    /// <summary>
    /// The name of the owner of the bank account.
    /// </summary>
    protected string _owner;

    /// <summary>
    /// The balance of the bank account.
    /// </summary>
    protected decimal _balance;

    /// <summary>
    /// The account number of the bank account.
    /// </summary>
    private string _accountNumber;

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class.
    /// Creates a unique bank account number for this instance.
    /// Increased the seed to create unique bank account numbers.
    /// </summary>
    /// <param name="name">The name of the the owner of the bank account.</param>
    /// <param name="initialBalance">The balance of the bank account.</param>
    public BankAccount(string name, decimal initialBalance)
    {
        this._owner = name;
        this._balance = initialBalance;
        this._accountNumber = this._accountNumberSeed.ToString();
        this._accountNumberSeed++;
    }

    /// <summary>
    /// This method returns the name of the owner of bank account.
    /// </summary>
    /// <returns>The owner of bank account.</returns>
    public string GetOwner()
    {
        return this._owner;
    }

    /// <summary>
    /// This method returns the balance of bank account.
    /// </summary>
    /// <returns>The balance of bank account.</returns>
    public decimal GetBalance()
    {
        return this._balance;
    }

    /// <summary>
    /// This method returns the account number of bank account.
    /// </summary>
    /// <returns>The account number of bank account.</returns>
    public string GetAccountNumber()
    {
        return this._accountNumber;
    }

    /// <summary>
    /// This method deposits an amount of money to the bank account and
    /// returns true if succeeded and false if failure.
    /// </summary>
    /// <param name="amount">The amount to deposit to the bank account.</param>
    /// <returns>true if succeeded and false if failure.</returns>
    public bool Deposit(decimal amount)
    {
        bool okDeposit = false;

        if (amount > 0)
        {
            this._balance += amount;
            okDeposit = true;
        }
        return okDeposit;
    }

    /// <summary>
    /// This method withdraws an amount of money from the bank account and
    /// returns true if succeeded and false if failure.
    /// </summary>
    /// <param name="amount">The amount to withdraw from the bank account.</param>
    /// <returns>true if succeeded and false if failure.</returns>
    public bool Withdraw(decimal amount)
    {
        bool okWithdraw = false;

        if (this._balance >= amount)
        {
            this._balance -= amount;
            okWithdraw = true;
        }
        return okWithdraw;
    }

    /// <summary>
    /// This method prints information of this bank account in the terminal.
    /// </summary>
    public void PrintAccountDescription()
    {
        Console.WriteLine($"Kontot med nummer {this._accountNumber} skapades till {this._owner} med saldot {this._balance} kr.");
    }

    /// <summary>
    /// This method performs a monthly task depending on type of account and
    /// should be implemented in the subclasses of this class.
    /// Returns true if succeeded and false if failure.
    /// </summary>
    /// <returns>true if succeeded and false if failure.</returns>
    public virtual bool PerformMonthEndTransactions() { return false; }
}
