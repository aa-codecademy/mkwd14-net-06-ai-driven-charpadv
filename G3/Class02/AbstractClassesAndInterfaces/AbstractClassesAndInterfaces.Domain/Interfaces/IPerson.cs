namespace AbstractClassesAndInterfaces.Domain.Interfaces
{
	public interface IPerson
	{
		//here we don't have access modofiers, we don't have impl. we only have the signature of what the name of the method, the return and the params should be for the class that will implement this interface
		void Greet();

		string SendGift(string address);
	}
}
