using MyBank.src;

var account = new BankAccount("Marie", 1000);

account.PrintAccountDescription();

var payroll = new PayrollAccount("Marie BTH", 10000);
payroll.PerformMonthEndTransactions();
payroll.PrintAccountDescription();
//payroll.PrintDescription();

var interest = new InterestAccount("Marie savings", 120000);
interest.PerformMonthEndTransactions();
interest.PrintAccountDescription();
//interest.PrintDescription();
