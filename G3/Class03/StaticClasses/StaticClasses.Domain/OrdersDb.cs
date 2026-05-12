using StaticClasses.Domain.Models;

namespace StaticClasses.Domain
{
	//This static class simulates a Database
	//It is alive during the lifecycle of the app
	//can be accessed from anywhere
	public static class OrdersDb
	{
		//these lists simulate a real db
		//all members need to be static
		public static List<Order> Orders { get; set; }
		public static List<User> Users { get; set; }

		public static int lastOrderId = 4; //we are using it like this to get the lastId, we could also use LastOrDefault from the Orders list, we use it like this to have yet another example with static member
		
		//all members need to be static
		//the constructor is not used to create new instances. It is used once when starting the app to initialize the OrdersDb static class
	    //this is some basic data that will be in our db whenever we start the app
		static OrdersDb()
		{
			Orders = new List<Order>()
			{
				new Order(1, "book", "Best book ever"),
				new Order(2, "keyboard", "Mechanical"),
				new Order(3, "shoes", "Waterproof"),
				new Order(4, "set of pens", "ordinary blue pens")
			};

			Users = new List<User>()
			{
				new User(1, "PetkoP", "Address1"),
				new User(2, "TrajkoT", "Address2")
			};

			Users[0].Orders.Add(Orders[0]);
			Users[0].Orders.Add(Orders[1]);
			Users[1].Orders.Add(Orders[2]);
			Users[1].Orders.Add(Orders[3]);
		}

		public static void PrintUsers()
		{
			foreach(User user in Users)
			{
				Console.WriteLine($"({user.Id}) {user.Username}");
			}
		}

		public static void InsertOrder(int userId, Order order)
		{
			//simulate that the db generates the id (it should be +1 from the last order)
			lastOrderId++; //lastOrderId = lastOrderId + 1
			order.Id = lastOrderId;

			Orders.Add(order); //add the order to the list of orders (the table Order in our simulated db)

			//add the order to the user

			//we need to find the user with this userId in our db
			User userFromDb = Users.FirstOrDefault(x => x.Id == userId);
			if(userFromDb != null) //if we successfully found the user, then we can connect him with the order
			{
				userFromDb.Orders.Add(order);
			}
			else //if the user does not exist we can write a message
			{
				Console.WriteLine("User not found!");
			}
		}

	}
}
