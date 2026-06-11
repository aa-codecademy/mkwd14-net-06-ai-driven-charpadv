using AdoNet;

string connectionString = "Server=.\\SQLEXPRESS;Database=AVENGA_ACADEMY_EXAMPLE;Trusted_Connection=True;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
StudentService studentService = new StudentService(connectionString);
List<Student> allStudents = studentService.GetStudents();
Console.ReadLine();