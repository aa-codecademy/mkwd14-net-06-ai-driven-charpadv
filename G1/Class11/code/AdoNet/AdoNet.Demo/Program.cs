using AdoNet.Demo.DataAccess;
using AdoNet.Demo.Models;

Console.WriteLine("Hello, World!");

void PrintInColor(string text, ConsoleColor color = ConsoleColor.White)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

void PrintStudents(List<Student> students)
{
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
}

// ===> For using SQL Express, the connection string should be like this:
//const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SEDC_DEMO_SHARP;Trusted_Connection=True;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
// ===> For using SQL Server, the connection string should be like this:
const string ConnectionString = "Server=.;Database=SEDC_DEMO_SHARP;Trusted_Connection=True;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

StudentRepository studentRepository = new StudentRepository(ConnectionString);

List<Student> allStudents = studentRepository.GetAllStudents();


PrintInColor("\n======= All Students =======", ConsoleColor.Cyan);
PrintStudents(allStudents);


PrintInColor("\n======= Insert New Student =======", ConsoleColor.Cyan);

Console.WriteLine("\nEnter First Name:");
// ===> SQL Injection Example
// Insert the line bellow when calling InsertStudentSqlInjection
// John', 'Doe', '2000-01-01', '2025-01-01', 'M', 1234567890123, 'CA-2024-001'); DROP TABLE Student;--

string firstName = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(firstName))
{
    Student student = new Student
    {
        FirstName = firstName,
        LastName = "Doe",
        DateOfBirth = DateTime.UtcNow.AddYears(-32),
        EnrolledDate = DateTime.UtcNow,
        Gender = 'M',
        NationalIdNumber = 23432454235,
        StudentCardNumber = "ST-4234-bla"
    };

    //studentRepository.InsertStudentSqlInjection(student);
    studentRepository.InsertStudentSafe(student);
}



Console.ReadLine();