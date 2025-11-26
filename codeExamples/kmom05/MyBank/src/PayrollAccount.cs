namespace MyBank.src;

public class PayrollAccount : BankAccount
{

    public PayrollAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    public void PrintDescription()
    {
        Console.WriteLine($"Detta lönekonto skapades till {_owner} med saldot {_balance} kr.");
    }

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