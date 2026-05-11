using StaticClasses;
using StaticClasses.Enums;
using StaticClasses.Helpers;
using StaticClasses.Models;

Console.WriteLine("Hello, World!");

//ConsoleHelper consoleHelper = new ConsoleHelper();  // Cannot create an instance from *static* class

//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine("===== Welcome to Order Managment System =====");
//Console.ResetColor();

User newUser = new User();

newUser.Username = "";

Console.WriteLine(OrdersStaticDB.Users.Count);
Console.WriteLine(OrdersStaticDB.Orders.Count);

bool isRunning = true;
while (isRunning)
{
    ConsoleHelper.WriteInColor("\n===== Welcome to Order Managment System =====", ConsoleColor.Blue);
    Console.WriteLine("\nPlease choose an option:");
    Console.WriteLine("1) List all users");
    Console.WriteLine("2) Create order for user");
    Console.WriteLine("3) Exit");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ConsoleHelper.WriteInColor("\nList of users:", ConsoleColor.Magenta);
            OrdersStaticDB.ListUsers();
            break;
        case "2":
            ConsoleHelper.WriteInColor("\nEnter User Id:", ConsoleColor.Yellow); 
            string userId = Console.ReadLine();

            ConsoleHelper.WriteInColor("\nEnter Order Title:", ConsoleColor.Yellow); 
            string title = Console.ReadLine();

            ConsoleHelper.WriteInColor("\nEnter Order Description:", ConsoleColor.Yellow);
            string description = Console.ReadLine();

            Order newOrder = new Order
            {
                Title = title,
                Description = description,
                Status = OrderStatus.Processing
            };

            OrdersStaticDB.InsertOrder(newOrder, Convert.ToInt32(userId));
            break;
        case "3":
            ConsoleHelper.WriteInColor("Goodbye!", ConsoleColor.DarkCyan);
            isRunning = false;
            break;
        default:
            ConsoleHelper.WriteError("Invalid choice. Try again."); 
            break;
    }
}

Console.ReadLine();