namespace SerializationAndDeserialization
{
	public class CustomReaderWriter
	{
		public string ReadFromFile(string filePath)
		{
			//validation that the file exists
			//StreamReader does not create the file if the file does not exist, it expects it to already exist
			//(StreamWriter was the one that created the file if the file does not exist)
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException($"File on path {filePath} does not exist");
			}

			string result = string.Empty;
			using(StreamReader  sr = new StreamReader(filePath))
			{
				result = sr.ReadToEnd(); //with ReadToEnd we get the whole content from the file
			}

			return result;
		}

		public void WriteToFile(string text, string filePath)
		{
			//here, the streamWriter creates the file if it does not already exist, so we don't need to do that validation
			using(StreamWriter sw = new StreamWriter(filePath))
			{
				sw.WriteLine(text);
			}
		}
	}
}
