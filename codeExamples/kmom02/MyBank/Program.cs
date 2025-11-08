using MyBank.src;

BankAccount account1 = new BankAccount("Marie", 1000);
BankAccount account2 = new BankAccount("Betty", 2000);
string bankName = BankAccount.BANK_NAME;

Console.WriteLine($"\nThe name of the bank is {bankName}");
Console.WriteLine($"Account {account1.GetAccountNumber()} was created for {account1.GetOwner()} with {account1.GetBalance()} initial balance.");
Console.WriteLine($"Account {account2.GetAccountNumber()} was created for {account2.GetOwner()} with {account2.GetBalance()} initial balance.");

bool ok = account1.Deposit(-100);
Console.WriteLine($"Deposit for account {account1.GetAccountNumber()} with -100 went good? {ok}");
ok = account1.Deposit(100);
Console.WriteLine($"Deposit for account {account1.GetAccountNumber()} with 100 went good? {ok}");
Console.WriteLine($"Account {account1.GetAccountNumber()} was created for {account1.GetOwner()} with {account1.GetBalance()} balance.");

ok = account1.Withdraw(10000);
Console.WriteLine($"Deposit for account {account1.GetAccountNumber()} with 10000 went good? {ok}");
ok = account1.Withdraw(300);
Console.WriteLine($"Deposit for account {account1.GetAccountNumber()} with 300 went good? {ok}");
Console.WriteLine($"Account {account1.GetAccountNumber()} was created for {account1.GetOwner()} with {account1.GetBalance()} balance.");
Console.WriteLine();
