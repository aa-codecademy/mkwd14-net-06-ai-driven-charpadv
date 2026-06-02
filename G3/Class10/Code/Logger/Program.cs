using Logger;

LoggerService logger = new LoggerService();

List<User> users = new List<User>()
{
	new User {Id = 1, Firstname = "Petko", Lastname="Petkovski", Username="p.petko", Password="P@ssw0rd"},
	new User {Id = 2, Firstname="Trajko", Lastname="Trajkovski", Username="t.trajko", Password="Test123!"}
};

void Login(string username, string password)
{
	User user = users.FirstOrDefault(x => x.Username == username && x.Password == password);
	if(user == null)
	{
		throw new Exception($"Invalid login for {username}");
	}
}

try
{
	Console.WriteLine("Enter username:");
	string username = Console.ReadLine();

	Console.WriteLine("Enter password:");
	string password = Console.ReadLine();
	logger.Log($"Trying to log in a user with username {username}", false); //this is an info message that we want to log
	Login(username, password);
	logger.Log($"Successfully logged in user with username {username}", false);
	Console.WriteLine($"Successfully logged in user with username {username} and logged info");

}catch(Exception ex)
{
	Console.WriteLine(ex.Message);
	logger.Log(ex.Message, true); //here we send the message and we send true as a value for the param because we are logging an error that occurred
}