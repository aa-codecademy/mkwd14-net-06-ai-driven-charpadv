namespace AdvancedLINQ.Domain.Models
{
	public class Student : BaseEntity
	{
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public bool IsPartTime { get; set; }
		public List<Subject> Subjects { get; set; }

		public Student()
		{
			Subjects = new List<Subject>();
		}
		public Student(int id, string firstname, string lastname, int age, bool isPartTime)
			: base(id)
		{
			Firstname = firstname;
			Lastname = lastname;
			Age = age;
			IsPartTime = isPartTime;
			Subjects = new List<Subject>();
		}
		public override void PrintInfo()
		{
			Console.WriteLine($"{Firstname} {Lastname} aged {Age} attends {Subjects.Count}");
		}
	}
}
