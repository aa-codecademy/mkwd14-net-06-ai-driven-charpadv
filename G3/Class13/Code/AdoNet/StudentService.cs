
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
						DateOfBirth = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
						EnrolledDate = reader.IsDBNull(4) ? null :reader.GetDateTime(4),
						Gender = reader.GetString(5)[0], //char
						NationalIdNumber = reader.GetInt64(6),
						StudentCardNumber = reader.GetString(7)
					};
					students.Add(student);
				}
				return students;
			}
		}

		public void InsertStudent(Student student)
		{
			//1.create and open a connection to the db
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();
				//John', 'Doe', '2000 - 01 - 01', '2025 - 01 - 01', 'M', 1234567890123, 'CA - 2024 - 001'); DROP TABLE Student;--
				//SQL Injection - we shouldn't use this way of sending data directly into the query
				//string query = $"INSERT INTO dbo.Student(FirstName, LastName, DateOfBirth, EnrolledDate, NationalIdNumber, StudentCardNumber)" +
				//	$"VALUES ({student.Firstname}, {student.Lastname}, {student.DateOfBirth}, {student.EnrolledDate}, {student.NationalIdNumber}, {student.StudentCardNumber})";

				//safe way is to use params
				string query = $"INSERT INTO dbo.Student(FirstName, LastName, DateOfBirth, EnrolledDate, Gender, NationalIdNumber, StudentCardNumber)" +
					$"VALUES (@FirstName, @LastName,@DateOFBirth, @EnrolledDate, @Gender, @NationalIdNumber, @StudentCardNumber)";

				//3. Create sql command
				using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

				//4. Map the inserted values for the params
				sqlCommand.Parameters.AddWithValue("@FirstName", student.Firstname);
				sqlCommand.Parameters.AddWithValue("@LastName", student.Lastname);
				sqlCommand.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
				sqlCommand.Parameters.AddWithValue("@EnrolledDate", student.EnrolledDate);
				sqlCommand.Parameters.AddWithValue("@Gender", student.Gender);
				sqlCommand.Parameters.AddWithValue("@NationalIdNumber", student.NationalIdNumber);
				sqlCommand.Parameters.AddWithValue("@StudentCardNumber", student.StudentCardNumber);

				//5. Execute the query
				//when we execute an insert query there are no rows in the result that we need to read
				//that's why here, we do not need a reader
				int rowsAffected = sqlCommand.ExecuteNonQuery(); //this returns the number of rows affected
				Console.WriteLine(rowsAffected);
			}
		}
	}
}
