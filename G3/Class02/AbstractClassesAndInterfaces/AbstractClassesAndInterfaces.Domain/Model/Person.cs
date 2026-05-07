using AbstractClassesAndInterfaces.Domain.Interfaces;

namespace AbstractClassesAndInterfaces.Domain.Model
{
	public abstract class Person : IPerson
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } //prop + tab -> generate inital property
        public string PhoneNumber { get; set; } //ctrl + d -> duplicate line shortcut

		public Person() { }

		//we don't use this constructor to create instances from Person, but we use it in the derived classes
		public Person(string firstname, string lastname, int age, string address, string phoneNumber)
		{
			Firstname = firstname;
			Lastname = lastname;
			Age = age;
			Address = address;
			PhoneNumber = phoneNumber;
		}

		//we can have some methods that already have an implementation (just like standard classes)
		public void PrintInfo()
		{
			Console.WriteLine($"{Firstname} {Lastname}: {Age} {PhoneNumber}");
		}

		//this method is abstract which means that we won't have an implementation here (in the base class), but all classes
		//that inherit from this class MUST implement this method
		public abstract string GetProffestionalInfo();

		//we need to implement the methods from the interface that this class is implementing
		public void Greet()
		{
			Console.WriteLine("Hello from Person");
		}

		public string SendGift(string address)
		{
			return $"Sending a gift to {address}";
		}
	}
}
