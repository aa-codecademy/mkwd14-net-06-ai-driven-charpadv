// See https://aka.ms/new-console-template for more information
using StaticClasses;
using StaticClasses.Helpers;

Console.WriteLine("Hello, World!");

//ConsoleHelper consoleHelper = new ConsoleHelper();  // Cannot create an instance from *static* class

//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine("===== Welcome to Order Managment System =====");
//Console.ResetColor();

ConsoleHelper.WriteInColor("===== Welcome to Order Managment System =====", ConsoleColor.Blue);

Console.WriteLine(OrdersStaticDB.Users.Count);




Console.ReadLine();