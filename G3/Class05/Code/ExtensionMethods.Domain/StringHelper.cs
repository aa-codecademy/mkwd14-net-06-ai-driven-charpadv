namespace ExtensionMethods.Domain
{
	public static class StringHelper
	{
		public static string Shorten(this string text, int numberOfWords)
		{
			//validation
			if(numberOfWords <= 0 || string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}

			//"We are learning about extension methods" -> we, are, learning, about, extension, methods
			string[] words = text.Split(" "); //we split the text by empty space

			//if our text has only 3 words and they ask for 10 words - we return the whole text because 3 is our max number of words
			if(words.Length < numberOfWords)
			{
				return text;
			}

			//Take returns IEnumerable and we can then transform it into list, array (toList, toArray..)
			///"We are learning about extension methods" 3
			List<string> resultWords = words.Take(numberOfWords).ToList(); //We, are, learning
			string result = string.Join(" ", resultWords);//We are learning
			return result;
		}
	}
}
