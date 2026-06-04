namespace DisposingClasses
{
	public class CustomWriter : IDisposable
	{
		private string _filePath;
		private StreamWriter _writer;//we are simulating the use of our own resource (our own writer)
		private bool _isDisposed = false;

		public CustomWriter(string filePath)
		{
			_filePath = filePath;
			_writer	= new StreamWriter(filePath);
		}

		public void Write(string text)
		{
			try
			{
				if(text.ToLower() == "stop")
				{
					throw new Exception("We should not write to this file..");
				}
				_writer.WriteLine(text); //in our custom writer we would use another logic to write to a file

			}catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Dispose()
		{
			if (!_isDisposed)
			{
				_writer.Dispose();//here we just call the existing Dispose from StreamWriter (in our own custom writer we would have our own way of disposing the resource)
				_isDisposed = true;
				Console.WriteLine("Disposing...");
			}
		}
	}
}
