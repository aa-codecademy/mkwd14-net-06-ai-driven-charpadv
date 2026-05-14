using StaticClasses.Domain;
using StaticClasses.Domain.Helpers;
using StaticClasses.Domain.Models;

//when we want to access the members of a static class we use the name of the class . the name of the member
int validate = TextHelper.ValidateInput("12");

Order order = new Order(1, "First order", "Our first order");
Console.WriteLine(order.Description); //we access the non-static member useing the object (using the instance)
order.PrintTitle(); //for the non-static method we use the object (the instance) to access it

Order.IsValid(order); //because the method IsValid is a static method, we use the name of the class to call this method

Console.WriteLine("Console is also a static class and we use the name of the class (Console) to access its static member the WriteLine method");

Console.WriteLine("Welcome to our ordering app");
Console.WriteLine("Choose the number of your user:");
OrdersDb.PrintUsers(); //we use the class name to call the static member PrintUsers

string input = Console.ReadLine();// we simulate login process by just choosing the number of the user

//validation
int userChoice = TextHelper.ValidateInput(input); //we use the name of the class to access the static method

if(userChoice == -1)
{
	Console.WriteLine("Invalid input!");
}
else
{
	User currentUser = OrdersDb.Users.FirstOrDefault(x => x.Id == userChoice);
	if(currentUser == null) //if the user entered a number, but that number was not on the list (a user with that id does not exist)
	{
		throw new Exception("User does not exist");
	}

	Console.WriteLine("Choose an option");
	Console.WriteLine("1. Print your orders");
	Console.WriteLine("2. Add new order");

	string optionInput = Console.ReadLine();

	int optionChoice = TextHelper.ValidateInput(optionInput); //validation that a number was entered
	if(optionChoice == -1)
	{
		Console.WriteLine("Invalid input");
	}
	else
	{
		if(optionChoice == 1)
		{
			currentUser.PrintOrders(); //PrintOrder is a non-static (standard) method in a non-static class, so we use the object (the instance) for current user to call this method
		}else if(optionChoice == 2)
		{
			//1. enter data for the new order
			Console.WriteLine("Enter title:");
			string titleInput = Console.ReadLine();
			Console.WriteLine("Enter description:");
			string descInput = Console.ReadLine();

			//2. validate the data
			if(string.IsNullOrEmpty(titleInput) || string.IsNullOrEmpty(descInput))
			{
				throw new Exception("Title and description are required fields");
			}

			//3. create new order
			Order newOrder = new Order();
			newOrder.Title = titleInput; //Title is a non-static member, so we use the object to access it
			newOrder.Description = descInput; //Description is a non-static member, so we use the object to access it
			newOrder.PrintTitle(); //PrintTitle is a non-static member so we user the object to access it

			Order.IsValid(newOrder); //IsValid is a static method, so we use the class name to access it

			//4. call the insert method - add it to the db
			OrdersDb.InsertOrder(currentUser.Id, newOrder); //we need to send the id of the current user that is making the order, and the new order
			Console.WriteLine("Successfully added new order");
			currentUser.PrintOrders();
		}
		else
		{
			Console.WriteLine("Invalid number!"); //If the user entered a number, but not a number that was a valid choice (1 or 2)
		}
	} 
}