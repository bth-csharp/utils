namespace MyBank.src;

public class BankAccount
{
    private static int _nextAccountNumber = 100000;
    private string _owner;
    protected decimal _balance;
    private string _accountNumber;

    public BankAccount(string nameOfOwner, decimal initialBalance)
    {
        this._owner = nameOfOwner;
        this._balance = initialBalance;
        this._accountNumber = BankAccount._nextAccountNumber.ToString();
        BankAccount._nextAccountNumber++;
    }

    public string GetOwner()
    {
        return this._owner;
    }

    public decimal GetBalance()
    {
        return this._balance;
    }

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

    public void PrintAccountDescription()
    {
        Console.WriteLine($"Kontot med nummer {this._accountNumber} skapades till {this._owner} med saldot {this._balance} kr.");
    }
}
