using AdoNet;

string connectionString = "Server=.\\SQLEXPRESS;Database=AVENGA_ACADEMY_EXAMPLE;Trusted_Connection=True;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
StudentService studentService = new StudentService(connectionString);
List<Student> allStudents = studentService.GetStudents();
Console.ReadLine();

Student newStudent = new Student()
{
	Firstname = "Trajko",
	Lastname = "Trajkovski",
	DateOfBirth = new DateTime(1999, 5, 23),
	EnrolledDate = DateTime.Now,
	Gender = 'M',
	NationalIdNumber = 121434,
	StudentCardNumber = "sc-123-456"
};

studentService.InsertStudent(newStudent);