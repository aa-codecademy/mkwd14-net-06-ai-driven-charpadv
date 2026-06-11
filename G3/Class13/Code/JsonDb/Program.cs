using JsonDb;
using JsonDb.Models;

Database<Student> students = new Database<Student>();
Database<Subject> subjects = new Database<Subject>();

Subject newSubject = new Subject
{
	Title = "MVC",
	Description = "MVC",
	NumberOfModules = 10
};

Student student = new Student
{
	Firstname = "Petko",
	Lastname = "Petkovski",
	Age = 25
};

subjects.Insert(newSubject);
students.Insert(student);