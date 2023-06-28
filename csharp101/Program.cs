// See https://aka.ms/new-console-template for more information
using BankOperationsLibrary;


Console.WriteLine();
var aFriend = "<My friend Name>";
Console.WriteLine($"Hello, my dear {aFriend}!");
Console.WriteLine($"Hello, my dear {aFriend.ToUpper()}!");
Console.WriteLine($"Hello, my dear {aFriend.ToLower()}!");

var names = new List<string> { "<name 1>", "<name 2>" , "<name 3>" };
foreach(string name in names )
{
    Console.WriteLine(name);
}

var account = new BankAccount("Client_1", 15000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

account.MakeWithdrawal(120, DateTime.Now, "Hammock");
account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");

Console.WriteLine(account.GetAccountHistory());

// Test that the initial balances must be positive.
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}