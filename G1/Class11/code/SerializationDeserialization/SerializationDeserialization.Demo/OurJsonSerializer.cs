using System.Text;

namespace SerializationDeserialization.Demo
{
    internal static class OurJsonSerializer
    {
        public static string SerializeStudent(Student student)
        {
            //string json = "{\n";
            //json += $"  \"firstName\": \"{student.FirstName}\",\n";
            //json += $"  \"lastName\": \"{student.LastName}\",\n";
            //json += $"  \"age\": {student.Age},\n";
            //json += $"  \"isPartTime\": {student.IsPartTime}\n";
            //json += "}";
            //return json;

            // Using StringBuilder:
            // *StringBuilder* is more efficient for concatenating strings, especially in loops or when building large strings.
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine($"  \"firstName\": \"{student.FirstName}\",");
            sb.AppendLine($"  \"lastName\": \"{student.LastName}\",");
            sb.AppendLine($"  \"age\": {student.Age},");
            sb.AppendLine($"  \"isPartTime\": {student.IsPartTime.ToString().ToLower()}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public static Student DeserializeStudent(string json)
        {
            // The JSON object:
            /*
                {
                  "firstName": "Bob",
                  "lastName": "Bobsky",
                  "age": 33,
                  "isPartTime": false
                }
            */
            // Cleaning the JSON string:
            string content = json.Trim().Trim('{', '}').Trim();

            // Splitting the content into lines:
            string[] lines = content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Creating a new Student object:
            var student = new Student();

            foreach (var line in lines)
            {
                // Splitting each line into key-value pairs:
                var keyValue = line.Split(new[] { ':' }, 2);
                if (keyValue.Length != 2) continue;

                var key = keyValue[0].Trim().Trim('"');
                var value = keyValue[1].Trim().Trim('"');

                // Assigning values to the Student object:
                switch (key)
                {
                    case "firstName":
                        student.FirstName = value;
                        break;
                    case "lastName":
                        student.LastName = value;
                        break;
                    case "age":
                        student.Age = int.Parse(value);
                        break;
                    case "isPartTime":
                        student.IsPartTime = bool.Parse(value);
                        break;
                }
            }

            return student;
        }
    }
}
