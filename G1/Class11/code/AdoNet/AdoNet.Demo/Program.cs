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

const string ConnectionString = "Server=.\\SQLEXPRESS;Database=SEDC_DEMO_SHARP;Trusted_Connection=True;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

StudentRepository studentRepository = new StudentRepository(ConnectionString);

List<Student> allStudents = studentRepository.GetAllStudents();


PrintInColor("\n======= All Students =======", ConsoleColor.Cyan);
PrintStudents(allStudents);





Console.ReadLine();