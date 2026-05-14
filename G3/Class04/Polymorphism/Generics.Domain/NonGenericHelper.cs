namespace Generics.Domain
{
	public static class NonGenericHelper
	{
		public static void PrintListOfStrings(List<string> strings)
		{
			foreach (string s in strings)
			{
				Console.WriteLine(s);
			}
		}

		public static void PrintListOfInts(List<int> ints)
		{
			foreach(int i in ints)
			{
				Console.WriteLine(i);
			}
		}

		public static void PrintListOfBools(List<bool> bools)
		{
			foreach(bool b in bools)
			{
				Console.WriteLine(b);
			}
		}
	}
}
