namespace MyBank.src;

public class Bank
{
    public const string BANK_NAME = "Dbwebb Bank";

    private List<BankAccount> _accounts;
    private List<Employee> _employees;

    public Bank()
    {
        this._accounts = new List<BankAccount>();
        this._employees = []; // [] är samma som new List<Employee>()
    }

    public void AddAccount(string nameOfOwner, decimal initialBalance)
    {
        this._accounts.Add(new BankAccount(nameOfOwner, initialBalance));
        /* eller
        var newAccount = new BankAccount(nameOfOwner, initialBalance);
        this._accounts.Add(newAccount); */
    }

    public void PrintDescription()
    {
        Console.WriteLine($"\nBanken heter {BANK_NAME} och har {this._accounts.Count.ToString()} bankkonton.");
        Console.WriteLine($"Banken har {this._employees.Count.ToString()} anställda.");
    }

    public void PrintAccountInfo()
    {
        Console.WriteLine($"\nAlla konton i {BANK_NAME}:");
        foreach (var account in _accounts)
        {
            account.PrintAccountDescription();
        }
    }

    private List<BankAccount> GetBankAccountsForOwner(string owner)
    {
        List<BankAccount> ownerAccounts = new List<BankAccount>();

        foreach (BankAccount account in _accounts)
        {
            if (account.GetOwner() == owner)
            {
                ownerAccounts.Add(account);
            }
        }
        return ownerAccounts;
    }

    public void PrintAccountInfoForOwner(string owner)
    {
        List<BankAccount> accounts;

        accounts = this.GetBankAccountsForOwner(owner);
        if (accounts.Count == 0)
        {
            Console.WriteLine($"\nKonton saknas för {owner} i {BANK_NAME}!");
        }
        else
        {
            Console.WriteLine($"\n{owner} har dessa konton i {BANK_NAME}:");
            foreach (BankAccount account in accounts)
            {
                account.PrintAccountDescription();
            }
        }
    }

    public void HireEmployee(Employee employee)
    {
        this._employees.Add(employee);
    }

    public void FireEmployee(Employee employee)
    {
        this._employees.Remove(employee);
    }
}
