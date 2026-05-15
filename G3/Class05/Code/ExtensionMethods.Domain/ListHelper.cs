namespace ExtensionMethods.Domain
{
	public static class ListHelper
	{
		public static string GetInfo<T>(this List<T> items)
		{ 
			//with ? we are checking if FirstOrDefult returned null. If it returned null it will NOT call getType and we won't get an error
			//if it did not return null, it will call GetType
			return $"This list has {items.Count} members {items.FirstOrDefault()?.GetType().Name}";
		}
	}
}
