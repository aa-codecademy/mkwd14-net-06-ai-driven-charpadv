using ExtensionMethods.Domain;

Employee employee = new Employee();
employee.Firstname = "Petko";
employee.Lastname = "Petkovski";
employee.Address = "Address1";
employee.SetSalary(100);

Employee employee2 = new Employee();
employee2.Firstname = "Trajko";
employee2.Lastname = "Trajkovski";
employee2.Address = "Address2";
employee2.SetSalary(200);

//we need to call this method using the EmployeeHelper class and pass the employee as a param
EmployeeHelper.PrintEmployee(employee);

//the param in Print(this Employee employee) will be replaced by the employee that we call the method with
//we don't need to send the employee as param
employee.Print();

//the first param in PrintEmployeeInfoWithAge(this Employee employee, int age) will be replaced with the employee that we call this method with
//we need to send the rest of the params (in our case, the value for age)
employee.PrintEmployeeInfoWithAge(26);

string text = "We are learning about extension methods";

//StringHelper.Shorten(text, 3);
text.Shorten(3);

string text2 = "Some text about G3 and Avenga";
text2.Shorten(2);

List<Employee> employees = new List<Employee>() {  employee, employee2 };
List<int> ints = new List<int>() { 1, 2, 3 };

//T will be Employee
Console.WriteLine(employees.GetInfo());

//T will be an int
Console.WriteLine(ints.GetInfo()); //GetInfo is a generic