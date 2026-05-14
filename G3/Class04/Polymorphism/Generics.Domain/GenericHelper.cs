namespace Generics.Domain
{
	public static class GenericHelper<T>
	{
		public static void PrintList(List<T> items)
		{
			foreach(T item in items)
			{
				Console.WriteLine(item);
			}
		}
	}
}
