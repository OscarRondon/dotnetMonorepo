// See https://aka.ms/new-console-template for more information
var aFriend = "<My friend Name>";
Console.WriteLine($"Hello, my dear {aFriend}!");
Console.WriteLine($"Hello, my dear {aFriend.ToUpper()}!");
Console.WriteLine($"Hello, my dear {aFriend.ToLower()}!");

var names = new List<string> { "<name 1>", "<name 2>" , "<name 3>" };
foreach(string name in names )
{
    Console.WriteLine(name);
}