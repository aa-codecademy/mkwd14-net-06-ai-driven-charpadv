using Exercise01.Domain.Interfaces;

namespace Exercise01.Domain.Models
{
	public class Student : User, IStudent
	{
        public List<int> Grades { get; set; }

		public Student(int id, string name, string username, string password, List<int> grades)
			:base(id, name, username, password)
		{
			//we need to validate the list, otherwise we would have null.something which will throw an error
			Grades = grades == null ? new List<int>() : grades;
		}

		//we need to impl this method because Student implements the IStudent interface and our IStudent interface is a ruleset that tells us that we need to have a method PrintGrades that is a void method with no params
        public void PrintGrades()
		{
			Console.WriteLine($"Student with id {Id} and name {Name} and username {Username} has grades:");

			foreach (int grade in Grades)
			{
				Console.WriteLine($"{grade} \n");
			}

			//we can also calculate the avg of our student here
			int avgGrade = Grades.Sum() / Grades.Count();
			Console.WriteLine($"The avg grade of this student is {avgGrade}");
		}

		//we need an impl here because we have an abstract method PrintUser in the User parent class
		public override void PrintUser()
		{
			Console.WriteLine($"Student with id {Id} and name {Name} and username {Username} has grades:");

			foreach(int grade in Grades)
			{
				Console.WriteLine($"{grade} \n");
			}
		}
	}
}
