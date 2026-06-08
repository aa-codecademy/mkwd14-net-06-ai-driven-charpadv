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

        /// <summary>
        ///     Inserts a new student record into the database.
        /// </summary>
        /// <param name="student">The <see cref="Student"/> object containing the student data to insert.</param>
        public void InsertStudentSafe(Student student)
        {
            // 1. Establish the conneciton to the Database

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Student (
                        FirstName, 
                        LastName, 
                        DateOfBirth, 
                        EnrolledDate, 
                        Gender, 
                        NationalIdNumber, 
                        StudentCardNumber
                    )
                    VALUES (
                        @FirstName,
                        @LName,
                        @DateOfBirth,
                        @EnrolledDate,
                        @Gender,
                        @NationalIdNumber,
                        @StudentCardNumber
                    );
                ";

                // 2. Create sql command
                using SqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                // 3. Map the insert values
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LName", student.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@EnrolledDate", student.EnrolledDate);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@NationalIdNumber", student.NationalIdNumber);
                command.Parameters.AddWithValue("@StudentCardNumber", student.StudentCardNumber);

                // 4. Execute the query
                //int rowsAffected = command.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Inserts a new student record into the database.
        ///     VULNERABLE TO SQL INJECTION !
        /// </summary>
        public void InsertStudentSqlInjection(Student student)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();

                // BAD EXAMPLE => POSSIBLE SQL INJECTION VULNERABILITY
                // SQL INJECTION => Malicious users can manipulate the input data to execute unintended SQL commands, potentially compromising your database and data.

                string query = $@"
                    INSERT INTO Student (
                        FirstName, 
                        LastName, 
                        DateOfBirth, 
                        EnrolledDate, 
                        Gender, 
                        NationalIdNumber, 
                        StudentCardNumber
                    )
                    VALUES (
                        '{student.FirstName}','{student.LastName}','{student.DateOfBirth:yyyy-MM-dd}','{student.EnrolledDate:yyyy-MM-dd}','{student.Gender}',{student.NationalIdNumber},'{student.StudentCardNumber}');
                ";

                using SqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                //int rowsAffected = command.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        // BONUS
        /// <summary>
        ///     Retrieves a student record by their unique ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>
        ///     A <see cref="Student"/> object if a student with the specified ID exists; otherwise <i>null</i>.
        /// </returns>
        public Student? GetStudentById(int id)
        {
            Student? student = null;

            // 1. Establish the conneciton to the Database
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // 2. Write the SQL query
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
                    WHERE s.ID = @StudentId
                ";

                // 3. Create sql command
                using SqlCommand command = new SqlCommand(query, connection);

                // 4. Map the parameters
                command.Parameters.AddWithValue("@StudentId", id);

                // 5. Execute the sql command
                using SqlDataReader reader = command.ExecuteReader();

                // 6. Read the data from the executed query
                if (reader.Read())
                {
                    // 7. Map the student info
                    student = new Student
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                        LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                        DateOfBirth = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                        EnrolledDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                        Gender = reader.IsDBNull(5) ? null : reader.GetString(5)[0],
                        NationalIdNumber = reader.IsDBNull(6) ? null : reader.GetInt64(6),
                        StudentCardNumber = reader.IsDBNull(7) ? null : reader.GetString(7)
                    };
                }
            }

            return student;
        }
    }
}
