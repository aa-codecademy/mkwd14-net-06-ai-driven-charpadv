namespace Logger
{
	public class LoggerService
	{
		private string folderPath;
		private string filePath;

		public LoggerService()
		{
			folderPath = @"..\..\..\logs";
			filePath = folderPath + @"\logs.txt"; //..\..\..\logs\logs.txt

			Directory.CreateDirectory(folderPath); //we need to create the folder

			//we can, but if we use StreamWriter we do not need to create the file
		}

		public void Log(string message, bool isError)
		{
			using(StreamWriter sw = new StreamWriter(filePath, true)) //we want to append text content in the txt file
			{
				sw.WriteLine($"Time: {DateTime.Now}");

				if(isError)
				{
					sw.WriteLine($"ERROR: {message}");
				}
				else
				{
					sw.WriteLine($"INFO: {message}");
				}
				sw.WriteLine("=====================================");
			}
		}
	}
}
