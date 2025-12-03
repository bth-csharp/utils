using MyBank.src;

Bank myBank = new Bank("Dbwebb Bank");

// Skapa två konton till Marie och lägg till i banken
var payroll = new PayrollAccount("Marie Grahn", 20000);
var interest = new InterestAccount("Marie Grahn", 1200);
myBank.AddAccount(payroll);
myBank.AddAccount(interest);

// Skapa ett konto till Andreas och lägg till i banken
payroll = new PayrollAccount("Andreas Arnesson", 30000);
myBank.AddAccount(payroll);

// Skriv ut bankinformation
Console.WriteLine($"Det finns {myBank.GetNoOfAccounts()} i banken {myBank.BankName}.");

// Skriv ut kontoinformation om alla konton
myBank.PrintAccountInfo();

// Skriv ut kontoinformation om Maries konton
myBank.PrintAccountInfoForOwner("Marie Grahn");

// Skriv ut kontoinformation om konton saknas
myBank.PrintAccountInfoForOwner("Darth Vader");

// Skriv ut saldot på Maries konto 1234567890
myBank.PrintBalance("1234567890");

// Skriv ut saldot på konto som inte finns
myBank.PrintBalance("9999999999");