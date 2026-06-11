using JsonDb.Models;
using Newtonsoft.Json;

namespace JsonDb
{
	public class Database<T> where T: BaseEntity
	{
		//private List<T> _items; //we don't want to keep the data in memory anymore. We want to store it in json files
		private string _folderPath;
		private string _filePath;
		private int _id;

		public Database()
		{
			_folderPath = @"..\..\..\Database";
			//..\..\..\Database\Students.json
			//..\..\..\Database\Subjects.json

			_filePath = _folderPath + @$"\{typeof(T).Name}s.json"; //with typeOf we get the type of the generic T that we have. With name we acccess the name of the type

			Directory.CreateDirectory(_folderPath); //we need to create the directory (folder)

			if (!File.Exists(_filePath))
			{
				//we will try to read from the file in the beginning
				//StreamReader does not create the file if it does not exist (only StreamWriter creates it)
				File.Create(_filePath).Close(); //don't forget to call the Close method, otherwise the file will remain opened (used by another process) when we try to access it
			}

			//read the file
			List<T> data = ReadFromFile();

			if(data == null) //invalid json / file was empty
			{
				_id = 0; //we need to start from 0 and populte a new list
			}
			else
			{
				if(data.Count > 0) //if there are items in the json file (in the list)
				{
					_id = data.Last().Id; //the last used id is the id of the last item in that list
				}
				else
				{
					_id = 0; //if the data was an empty, then we need to set the id to 0, so we can start from scratch
				}
			}
		}

		#region Helpers
		//we mark the read and write methods as private, because we should never be able to access them from the outside
		//we need to implement special logic and validation for reading and writing in the file (GetAll, GetById, Insert..)
		//these methods are only helper methods that should only be used in the scope of this class (Database)
		private List<T> ReadFromFile()
		{
			try
			{
				//using is our safest way of making sure out stream is disposed in the end
				using(StreamReader reader = new StreamReader(_filePath))
				{
					string data = reader.ReadToEnd(); //the data will be json format
													  //we need to convert from json to C# obj
					return JsonConvert.DeserializeObject <List<T>>(data);
				}

			}catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		private void WriteToFile(List<T> data) //List<Student>, List<Subject>...
		{
			try
			{
				//because we want to write to json file, we need to serialize our data into json before writing it in the file
				string jsonData = JsonConvert.SerializeObject(data);
				using(StreamWriter writer = new StreamWriter(_filePath)) //we don't append, we will manipulate the list (the data) on C# level and we will overwrite the existing list in the json file with the new, update version of the list
				{
					writer.WriteLine(jsonData);
				}

			}catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		#endregion

		public List<T> GetAll()
		{
			//when we get the data, we need to read it from the file
			//in this example our data is stored into json files, so we don't have a list like usual, but we need to read the file to get the data
			List<T> data = ReadFromFile(); //in the scope of ReadFromFile we implemented the reading and the deserialization from json to C# objects, so here we just need to call our ReadFromFile method
			return data;
		}

		public T GetById(int id)
		{
			List<T> data = ReadFromFile(); //GetAll()
			if(data == null) //read from file can return null if the file is empty
			{
				return null;
			}
			else
			{
				return data.FirstOrDefault(x => x.Id == id); //we are now working with our List<T> so we can use LINQ to search through the list
			}
		}

		public void Insert(T item)
		{
			//we need to read the data from the file, because that's where our list of items is
			//that is the list that we want to add the item to
			List<T> data = ReadFromFile(); //GetAll()

			if(data == null)
			{
				data = new List<T>(); //if the file is empty, the value of data will be null, so we need to create an empty list in order to avoid an exception when trying to call .Add
			}
			_id++; //the value of the id should be +1 of the last used id
			item.Id = _id;
			data.Add(item); //we need to add the item to the list
			WriteToFile(data); //We need to call WriteToFile, so that our data will persist in the file after the app ends 
			                   //WriteToFile serialzies our data into json and writes it to the file
		}
	}
}
