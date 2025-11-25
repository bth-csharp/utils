using MyBank.src;

// Skapa en bank, ett objekt av klassen Bank.
var bank = new Bank();

// Komposition, skapa 3 bankkonton i banken.
// Kontona existerar så länge banken existerar.
bank.AddAccount("Marie", 1000);
bank.AddAccount("Marie", 9999);
bank.AddAccount("Betty", 2000);

// Aggregation, skapa en anställd som anställs i banken. Den anställde
// fortsätter att existera även när bank upphör att existera. Det är en
// bemanningsföretag för bankanställda som är ansvariga för Employee-objekten.
// Employee-objekten skapas och ägs av bemanningsföretaget.
var staff1 = new Employee("Andreas");
var staff2 = new Employee("Mattias");
bank.HireEmployee(staff1);
bank.HireEmployee(staff2);

// Visa innehållet i banken
bank.PrintDescription();
bank.PrintAccountInfo();

// Aggregation, Andreas ska börja jobba som lärare och säger upp sig
// Det blir då en anställd kvar.
bank.FireEmployee(staff1);
bank.PrintDescription();

// Association, en kund som blir betjänad av banken
// Vi skapar två kunder som vill kolla sitt saldo på banken.
// Kunderna tillhör inte banken utan är fristående objekt som utnyttjar 
// banken ibland. Banken är inte ansvarig för Customer-objektens livslängd.
var customer1 = new Customer("Marie");
var customer2 = new Customer("Andreas");
bank.PrintAccountInfoForOwner(customer1.GetName());
bank.PrintAccountInfoForOwner(customer2.GetName());
// Nu är kunderna klara med banken och går vidare och gör ärenden på andra ställen.

// När detta huvudprogram avslutar så slutar alla objekt att existera.
