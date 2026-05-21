using AdvancedLINQ.Domain.Models;

namespace AdvancedLINQ
{
	public static class ListHelper
	{
		//we will make these methods generic

		//we will use this method to print the simple data types (string, int, bool..)
		public static void PrintSimple<T>(this List<T> list)
		{
			Console.WriteLine($"Printing {list.Count} items");
			foreach(T item in list )
			{
				Console.WriteLine(item);
			}
		}

		//we will use this method to print the entities
		public static void PrintEntities<T>(this List<T> list) where T :BaseEntity
		{
			Console.WriteLine($"Printing {list.Count} items");
			foreach (T item in list)
			{
				item.PrintInfo(); //we know that our entities have PrintInfo
			}
		}
	}
}
