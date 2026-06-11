
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNet
{
	public class StudentService
	{
		private readonly string _connectionString;

		public StudentService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<Student> GetStudents()
		{
			List<Student> students = new List<Student>();

			//1. open a connection to the db - our connection needs the connection string in order to open a connection
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open(); //after we create the connection, we need to open it

				//2. write the sql query (SELECT * FROM Student)
				//we need to write our query in c# code

				string query = @"
                SELECT s.ID, s.FirstName, s.LastName, s.DateOfBirth, s.EnrolledDate, s.Gender, s.NationalIdNumber, s.StudentCardNumber
				FROM [dbo].[Student] s";

				//3. create a sql command
				using SqlCommand command = new SqlCommand(query, sqlConnection);
				//using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
				//{}

				//4.Execute the sql command
				using SqlDataReader reader = command.ExecuteReader(); //execute the command, reads the data

				//5. read the data from the executed query
				while(reader.Read()) //read them item by item until you read all items (read as long as you have sth to read)
				{
					//6. Manually map the data to a student object
					Student student = new Student
					{
						Id = reader.GetInt32(0), //get the number value from the first column
						Firstname = reader.IsDBNull(1) ? "unnamed" : reader.GetString(1), //firstname is nullable so we need to check if it has value and then get string value
						Lastname = reader.IsDBNull(2) ? "unnamed" : reader.GetString(2),
						DateOfBirth = reader.GetDateTime(3),
						EnrolledDate = reader.GetDateTime(4),
						Gender = reader.GetString(5)[0],
						NationalIdNumber = reader.GetInt64(6),
						StudentCardNumber = reader.GetString(7)
					};
					students.Add(student);
				}
				return students;
			}
		}
	}
}
