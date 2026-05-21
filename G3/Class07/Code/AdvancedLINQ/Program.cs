using AdvancedLINQ;
using AdvancedLINQ.Domain;
using AdvancedLINQ.Domain.Models;

List<Student> studentsOlderThan25 = AvengaAcademy.Students.Where(x => x.Age > 25).ToList();
studentsOlderThan25.PrintEntities(); //we call our extension method for printing

List<string> namesOfStudentsOlderThan25 = AvengaAcademy.Students.Where(x => x.Age > 25).Select(x => x.Firstname).ToList();
namesOfStudentsOlderThan25.PrintSimple();

List<Student> studentsNamedBob = AvengaAcademy.Students.Where(x => x.Firstname.ToLower() == "Bob".ToLower()).ToList();

var studentsNamedBobSql = (from student in AvengaAcademy.Students //from all the students in the list
						   where student.Firstname == "Bob" //filter out the ones named Bob
						   select student).ToList(); //take the whole object student


var agesOfStudentsNamedBobSql = (from student in AvengaAcademy.Students //from all the students in the list
						   where student.Firstname == "Bob" //filter out the ones named Bob
						   select student.Age).ToList(); //take the age of the student

//First/Last/Single /OrDefault
//First => gets the first element, if no elements it will throw an error
//FirstOrDefault => gets the first element, if no elements it will return a default value, but it will NOT throw an error
//Last => gets the last element, if no elements it will throw an error
//LastOrDefault => gets the last element, if no elements it will return a default value, but it will NOT throw an error
//Single => gets the only element from the list, if no elements or more than one element it will throw an error
//SingleOrDefault => gets the only element from the list, if no elements - default value, but if there are more than one element it will throw an error

//Student studentStartingWithT = AvengaAcademy.Students.Single(x => x.Firstname.StartsWith("T")); //Error - no matching
//Student studentStartingWithB = AvengaAcademy.Students.Single(x => x.Firstname.StartsWith("B")); //Error - more than one
//Student studentStartingWithBSingleOrDefault = AvengaAcademy.Students.SingleOrDefault(x => x.Firstname.StartsWith("B")); //Error - more than one
Student studentStartingWithT = AvengaAcademy.Students.SingleOrDefault(x => x.Firstname.StartsWith("T"));
Console.WriteLine(studentStartingWithT);

//Select/SelectMany

//here we will have  a list of subjects for all the students that are part time
//here we get a list of lists which is complicated to work with - List<List<Subject>>
var subjectsOfPartTimeStudents = AvengaAcademy.Students.Where(x => x.IsPartTime).Select(x => x.Subjects).ToList();
Console.WriteLine(subjectsOfPartTimeStudents);

//selectMany flattens the list of lists. The members of each list in the list of lists becomes a member of the main list
//List<Subject>
List<Subject> subjectsOfPartTime = AvengaAcademy.Students.Where(x => x.IsPartTime).SelectMany(x => x.Subjects).ToList();
Console.WriteLine(subjectsOfPartTime);


//Except => gets all except the ones that we tell it to exclude
List<Student> exceptBob = AvengaAcademy.Students.Except(studentsNamedBob).ToList();
Console.WriteLine(exceptBob);

//Any/All
bool checkIfAnyPartTime = AvengaAcademy.Students.Any(x => x.IsPartTime); //true -checks if at least one student is part time
bool checkIfAllPartTime = AvengaAcademy.Students.All(x => x.IsPartTime); //false - checks if all students are part time

//Distinct/DistinctBy - removes duplicates
List<int> numbers = new List<int>() { 4, 5, 6, 4, 6 };
List<int> distinctNumbers = numbers.Distinct().ToList();
distinctNumbers.PrintSimple();

List<Student> distinctByAge = AvengaAcademy.Students.DistinctBy(x => x.Age).ToList(); //when we work with complex types, objects, we need something to compare them by and distinct them by
distinctByAge.PrintEntities();

List<Subject> subjectsOfPartTimeDistinct = AvengaAcademy.Students.Where(x => x.IsPartTime).SelectMany(x => x.Subjects).DistinctBy(x => x.Title).ToList();
subjectsOfPartTimeDistinct.PrintEntities();

//OrderBy/ OrderByDescending

List<Student> studentsOrderedByAge = AvengaAcademy.Students.OrderBy( x=> x.Age).ToList(); //order by is ascending by default
List<Student> studentsOrderedByAgeDesc = AvengaAcademy.Students.OrderByDescending( x=> x.Age).ToList(); 

List<Student> studentsOrderedByName = AvengaAcademy.Students.OrderBy(x => x.Firstname).ToList();
studentsOrderedByName.PrintEntities();