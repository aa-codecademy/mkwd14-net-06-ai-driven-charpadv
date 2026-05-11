using StaticClasses.Helpers;

namespace StaticClasses.Models
{
    public class User : BaseEntity
    {
        //public int Id { get; set; }

        // We can use Custom Getter and Setter to add validation logic to the Username property
        // For that purpose, we need to create a private field to store the value of the property and use it in the getter and setter
        private string username;
        public string Username
        {
            get { return username; } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Username cannot be empty");
                }
                username = value;
            }
        }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public User()
        {
            
        }

        public User(string username, string address, List<Order> orders)
        {
            Username = username;
            Address = address;
            Orders = orders;
        }

        public void PrintOrders()
        {
            //ConsoleHelper consoleHelper = new ConsoleHelper();

            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine($"Orders of {Username}:");
            //Console.ResetColor();

            ConsoleHelper.WriteInColor($"Orders of {Username}:", ConsoleColor.Cyan);

            for (int i = 0; i < Orders.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Orders[i].GetInfo()}");
            }
        }
    }
}
