namespace MyBank.src;

public class InterestAccount : BankAccount
{
    public InterestAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    public void PrintDescription()
    {
        Console.WriteLine($"Detta räntekonto skapades till {_owner} med saldot {_balance} kr.");
    }

    public override bool PerformMonthEndTransactions()
    {
        decimal interest = 0.0015m;

        if (this._balance > 100m)
        {
            interest = this._balance * 0.02m;
        }

        return Deposit(interest);
    }
}