using StaticClasses.Enums;
using StaticClasses.Helpers;
using StaticClasses.Models;

namespace StaticClasses
{
    // This static class is serving as a temporary database
    // While the app is running, the static members of this class will keep their data
    // It can also be accessed from anywhere
    public static class OrdersStaticDB
    {

        // These are the lists that will serve as tables in a database ( Store items in them )
        public static List<Order> Orders { get; set; } = new List<Order>();
        public static List<User> Users { get; set; } = new List<User>();

        private static int orderIdCounter;
        // This is an ID tracking field so that we generate the Id of orders automatically

        // Won't work !!!
        //public OrdersStaticDB()
        //{

        //}

        // NOTE: Static classes can have only static constructor
        // It will only execute once, the first time this class is used, when the app is started
        // Static constructor does not have access modifier
        static OrdersStaticDB()
        {
            ConsoleHelper.WriteInColor("Hello from OrdersStaticDB static constructor!", ConsoleColor.DarkMagenta);

            Orders = new List<Order>
            {
                new Order { Id = 1, Title = "Order 1", Description = "Description for Order 1", Status = OrderStatus.Processing },
                new Order { Id = 2, Title = "Order 2", Description = "Description for Order 2", Status = OrderStatus.Delivered },
                new Order { Id = 3, Title = "Order 3", Description = "Description for Order 3", Status = OrderStatus.InProgress },
                new Order { Id = 4, Title = "Order 4", Description = "Description for Order 4", Status = OrderStatus.Cancelled },
                new Order { Id = 5, Title = "Order 5", Description = "Description for Order 5", Status = OrderStatus.InProgress },
            };

            Users = new List<User>()
            {
                new User {Id = 1, Username = "bobsky123", Address = "Bobsky St."},
                new User {Id = 2, Username = "john456", Address = "John St."},
            };

            Users[0].Orders.Add(Orders[0]);
            Users[0].Orders.Add(Orders[1]);
            Users[0].Orders.Add(Orders[2]);
            Users[1].Orders.Add(Orders[3]);
            Users[1].Orders.Add(Orders[4]);

            orderIdCounter = Orders.Max(o => o.Id);
        }
        
        public static void ListUsers()
        {
            for (int i = 0; i < Users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Users[i].Username}");
            }
        }

        public static void InsertOrder(Order order, int userId)
        {
            User user = Users.SingleOrDefault(u => u.Id == userId);
            if (user is null)
            {
                ConsoleHelper.WriteError("User not found!");
                return;
            }

            order.Id = ++orderIdCounter; // Auto-incrementing the order ID
            Orders.Add(order);
            user.Orders.Add(order);

            ConsoleHelper.WriteInColor($"Order successfully created!", ConsoleColor.Green);
            ConsoleHelper.WriteInColor($"Total number of orders: {Orders.Count}", ConsoleColor.DarkGreen);
        }

    }
}
