namespace MyBank2.src;

public class Bank
{
    public const string BANK_NAME = "Dbwebb Bank";
    private List<BankAccount> _accounts;

    public Bank()
    {
        this._accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount newAccount)
    {
        this._accounts.Add(newAccount);
    }

    public virtual string GetNoOfAccounts()
    {
        return this._accounts.Count.ToString();
    }

    public string GetDescription()
    {
        return $"Banken heter {BANK_NAME} och har {GetNoOfAccounts()} konton.";
    }
}
