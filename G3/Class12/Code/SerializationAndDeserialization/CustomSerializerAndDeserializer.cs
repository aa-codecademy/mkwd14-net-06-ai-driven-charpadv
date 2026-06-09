namespace SerializationAndDeserialization
{
	public static class CustomSerializerAndDeserializer
	{
		public static string SerializeStudent(Student student)
		{
			//we are trying to convert our student into JSON format which is key value pairs where the keys are strings
			string json = "{";
			json += $"\"Firstname\" : {student.Firstname},";
			json += $"\"Lastname\" : {student.Lastname},";
			json += $"\"Age\" : {student.Age},";
			json += $"\"IsPartTime\" : \"{student.IsPartTime.ToString().ToLower()}\"";
			json += "}";

			return json;
		}

		public static Student DeserializeStudent(string json)
		{
			//clean the json string from unnecessary chars
			//we use substring to get only the content between {}
			//we don't want to include the {}, so we will get only one char after/before
			//start from the char after the { and end with one char before the }

			//{"Firstname" : "Petko", "Lastname": "Petkovski", "Age": 25, "IsPartTime":"false"}
			string content = json.Substring(json.IndexOf("{") + 1, json.IndexOf("}") - 1)
				.Replace("\n", "")
				.Replace("\r", "")
				.Replace("\"", ""); //we want to remoce the empty lines and the "

			//Firstname : "Petko", Lastname: "Petkovski", Age: 25, IsPartTime:false
			string[] properties = content.Split(",");

			Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();
			foreach(var property in properties)
			{
				string[] pair = property.Split(":"); //Firstname, Petko
				propertyDictionary.Add(pair[0].Trim(), pair[1].Trim()); //key and value in the dictionary
			}

			//Create the Student object with the values from the dictionary

			Student student = new Student();
			student.Firstname = propertyDictionary["Firstname"]; //we are using the key of the dictionary to access the value
			student.Lastname = propertyDictionary["Lastname"]; //we are using the key of the dictionary to access the value
			student.Age = int.Parse(propertyDictionary["Age"]); //potential error in parsing - just for demo, otherwise safer to use TryParse
			student.IsPartTime = bool.Parse(propertyDictionary["IsPartTime"]); //potential error in parsing - just for demo, otherwise safer to use TryParse
			return student;
		}
	}
}
