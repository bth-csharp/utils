namespace MyBank.src;

/// <summary>
/// This is a Bank class is documented with XML documentation.
/// </summary>
/// <author>Marie Grahn</author>
/// <date>2024-05-30</date>
public class Bank
{
    /// <summary>
    /// The name of the bank.
    /// </summary>
    public string BankName;

    /// <summary>
    /// The bank accounts of the bank.
    /// </summary>
    private List<BankAccount> _accounts;

    /// <summary>
    /// Initializes a new instance of the <see cref="Bank"/> class.
    /// The bank's name is set to the content of bankName.
    /// Creates an empty list of bank accounts.
    /// </summary>
    /// <param name="bankName">The name of the bank.</param>
    public Bank(string bankName)
    {
        this.BankName = bankName;
        this._accounts = new List<BankAccount>();
    }

    /// <summary>
    /// This method adds a new bank account to the bank.
    /// </summary>
    /// <param name="newAccount">The object of a BankAccount.</param>
    public void AddAccount(BankAccount newAccount)
    {
        this._accounts.Add(newAccount);
    }

    /// <summary>
    /// This method returns the number of accounts in the bank.
    /// </summary>
    /// <returns>The number of bank accounts as a string.</returns>
    public string GetNoOfAccounts()
    {
        return this._accounts.Count.ToString();
    }


    /// <summary>
    /// This method prints the name of the bank in the terminal.
    /// </summary>
    public void PrintDescription()
    {
        Console.WriteLine($"The name of the bank is {this.BankName}");
    }

    /// <summary>
    /// This method prints information of all the bank accounts in the bank to the terminal.
    /// </summary>
    public void PrintAccountInfo()
    {
        Console.WriteLine($"\nAlla konton i {this.BankName}:");
        foreach (var account in _accounts)
        {
            account.PrintAccountDescription();
        }
    }

    /// <summary>
    /// This method looks for bank account owned by a specific owner in the bank and returns 
    /// a list with bank account found.
    /// </summary>
    /// <param name="owner">The owner of the bank accounts.</param>
    public List<BankAccount> GetBankAccountsForOwner(string owner)
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
        // Raden nedan ersätter alla rader ovan
        //return this._accounts.FindAll(account => account.GetOwner() == owner);
    }

    /// <summary>
    /// This method prints information of all the bank accounts owned by a specific 
    /// owner in the bank to the terminal. 
    /// </summary>
    /// <param name="owner">The owner of the bank accounts.</param>
    public void PrintAccountInfoForOwner(string owner)
    {
        List<BankAccount> accounts;

        accounts = this.GetBankAccountsForOwner(owner);
        if (accounts.Count == 0)
        {
            Console.WriteLine($"\nKonton saknas för {owner} i {BankName}!");
        }
        else
        {
            Console.WriteLine($"\n{owner} har dessa konton i {BankName}:");
            foreach (BankAccount account in accounts)
            {
                account.PrintAccountDescription();
            }
        }
    }

    /// <summary>
    /// This method prints the balance of a specific bank account in the bank to the terminal. 
    /// </summary>
    /// <param name="accountNumber">The account number of the specific bank account.</param>
    public void PrintBalance(string accountNumber)
    {
        decimal balance = 0;
        BankAccount? bankAccount; // bankAccount kan bli tom om inte kontot finns

        bankAccount = _accounts.Find(account => account.GetAccountNumber().Equals(accountNumber));
        if (bankAccount != null)
        {
            balance = bankAccount.GetBalance();
            Console.Write($"\nSaldot för konto {accountNumber} är {balance}.");
        }
        else
        {
            Console.WriteLine("\nKontot hittades inte!");
        }
    }
}