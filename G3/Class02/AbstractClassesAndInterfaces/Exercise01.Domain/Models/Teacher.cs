using Exercise01.Domain.Interfaces;

namespace Exercise01.Domain.Models
{
	public class Teacher : User, ITeacher
	{
        public string Subject { get; set; }

		public Teacher(int id, string name, string username, string password, string subject)
			:base(id, name, username, password)
		{
			Subject = subject;
		}

		//we need to implement this method because Teacher implements ITeacher interface
        public void PrintSubject()
		{
			Console.WriteLine($"Teacher {Name} teacher {Subject}");
		}

		//we need to implement this method because Teacher is a derived class from User - an abstract class that has this abstract method
		public override void PrintUser()
		{
			Console.WriteLine($"Teacher {Name} teacher {Subject}");
		}
	}
}
