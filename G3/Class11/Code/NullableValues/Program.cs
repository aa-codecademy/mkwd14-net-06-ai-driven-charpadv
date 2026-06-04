using NullableValues;

Person person = new Person();
Console.WriteLine(person.Id);
Console.WriteLine(person.Score);

if(person.Score == null) //!person.Score.HasValue
{
	Console.WriteLine("Score is null using == null");
}

if (!person.Score.HasValue) // person.Score == null
{
	Console.WriteLine("Score is null using HasValue");
}

person.Score = 5;

if (person.Score.HasValue) // person.Score != null
{
	Console.WriteLine(person.Score);

	//int score = person.Score; //ERROR - person.Score is nullable int (int?), we cannot assign it to a variable of type int (int != int?)
    int score = person.Score.Value; //with value we access the value of int? if there is one; That's why we need to check if the variable has value before trying to access its value
}

//person.Id = null; //ERROR - Id is non-nullable int
person.Score = null; //this is okay
//person.IsStudent = null; //ERROR - IsStudent is a non-nullable bool
person.IsParttimeStudent = null; //this is okay
person.IsParttimeStudent = true;
person.IsParttimeStudent = false;

Person secondPerson = new Person();
secondPerson = null; //every object is nullable

//? is an operator that checks for null values
//if the left side of the ? is null, then it will return null instead of continuing and throwing an exception
//if the left side of the ? is NOT null, then it will continue and access the properties/methods etc that are on the right side of the ? (after check)
string name = secondPerson?.Name;

//ternary operator
int ternaryScore = person.Score.HasValue ? person.Score.Value : 0;

int shortScore = person.Score ?? 0;