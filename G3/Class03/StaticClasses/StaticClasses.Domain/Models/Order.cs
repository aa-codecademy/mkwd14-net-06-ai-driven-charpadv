using StaticClasses.Domain.Enums;

namespace StaticClasses.Domain.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public OrderStatusEnum OrderStatus { get; set; }

		public Order()
		{
			Id = new Random().Next(1, 10000000); //this way a random number from 1 til 1000 is being generated
			OrderStatus = OrderStatusEnum.Created;
		}

		public Order(int id, string title, string description)
		{
			Id = id;
			Title = title;
			Description = description;
			OrderStatus = OrderStatusEnum.Created;	
		}

		//in a standard class we can have non-static methods (members)
		public void PrintTitle()
		{
			Console.WriteLine($"Title: {Title}");
		}

		//in a non-static class we can have static methods (members)
		public static bool IsValid(Order order)
		{
			return order.Id > 0 && !string.IsNullOrEmpty(order.Title) && !string.IsNullOrEmpty(order.Description);
		}
	}
}
