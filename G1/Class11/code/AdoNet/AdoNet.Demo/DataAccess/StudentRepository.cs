using AdoNet.Demo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNet.Demo.DataAccess
{
    // SqlConnection => used to establish connection to a database
    // SqlCommand => execute SQL queries, stored procedures, and other database commands
    // SqlDataReader => read data from a database
    internal class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            // 1) Establish the connection to the Database

            // BAD WAY
            //SqlConnection sqlConnection = new SqlConnection(_connectionString);
            //sqlConnection.Open();

            //sqlConnection.Close();


            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                // 2) Write the SQL query
                string query = @"
                    SELECT
	                    s.ID,
	                    s.FirstName,
	                    s.LastName,
	                    s.DateOfBirth,
	                    s.EnrolledDate,
	                    s.Gender,
	                    s.NationalIdNumber,
	                    s.StudentCardNumber
                    FROM dbo.Student s
                ";

                // 3) Create sql command
                //using SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandText = query;
                using SqlCommand command = new SqlCommand(query, sqlConnection);

                // 4) Execute the sql command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // 5) Read the data from the executed query
                    while (reader.Read())
                    {
                        // 6) Map manually the retrieved columns to Student objects
                        // 1	Kalin	Mitev	1991-04-10	2010-10-08	M	391983	sc-77618
                        Student student = new Student
                        {
                            // IMPORTANT: The order of the columns is the one written in the SELECT query
                            Id = reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            DateOfBirth = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                            EnrolledDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            Gender = reader.IsDBNull(5) ? null : reader.GetString(5)[0],
                            NationalIdNumber = reader.IsDBNull(6) ? null : reader.GetInt64(6),
                            StudentCardNumber = reader.IsDBNull(7) ? null : reader.GetString(7),
                        };

                        students.Add(student);
                    }
                }

            }

            // 7) Return the mapped students
            return students;
        }

    }
}
