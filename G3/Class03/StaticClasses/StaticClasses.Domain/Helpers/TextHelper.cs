namespace StaticClasses.Domain.Helpers
{
	public static class TextHelper
	{
		//all members of the static class must be static
		public static int ValidateInput(string input)
		{
			bool success = int.TryParse(input, out int result);
			if(success)
			{
				return result;
			}
			else
			{
				return -1;
			}
		}
	}
}
