namespace MyBank2.src;

public class BankAccount
{
    private static int _accountNumberSeed = 1234567890;
    protected string _owner;
    protected decimal _balance;
    private string _accountNumber;

    public BankAccount(string name, decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new CreateBankAccountException("Bankkontot ska skapas med saldo >= 0.");
        }
        _owner = name;
        _balance = initialBalance;
        _accountNumber = _accountNumberSeed.ToString();
        _accountNumberSeed++;
    }

    public string GetOwner()
    {
        return _owner;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public string GetNumber()
    {
        return _accountNumber;
    }

    public bool Deposit(decimal amount)
    {
        bool okDeposit = false;

        if (amount > 0)
        {
            _balance += amount;
            okDeposit = true;
        }
        return okDeposit;
    }

    public bool Withdraw(decimal amount)
    {
        bool okWithdraw = false;

        if (_balance >= amount)
        {
            _balance -= amount;
            okWithdraw = true;
        }
        return okWithdraw;
    }

    public void PrintAccountDescription()
    {
        Console.WriteLine($"Kontot med nummer {_accountNumber} skapades till {_owner} med saldot {_balance} kr.");
    }

    public virtual bool PerformMonthEndTransactions() { return false; }
}
