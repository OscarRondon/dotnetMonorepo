// See https://aka.ms/new-console-template for more information
using BankOperationsLibrary;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices.JavaScript;

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
    //return;
}
// source https://www.programmingwithwolfgang.com/use-net-secrets-in-console-application/

var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
var configurationRoot = builder.Build();

var secrets = configurationRoot.GetSection("MySecretValues").Get<SecretValues>();

Console.WriteLine("----------------------------------------------------------");
Console.WriteLine();
Console.WriteLine(secrets);
