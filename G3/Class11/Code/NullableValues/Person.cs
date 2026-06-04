namespace NullableValues
{
	public class Person
	{
		public int Id { get; set; } //default 0 - int cannot be null

		//nullable int as type, has default value null
		//Score can get any whole number as a value the same as int, but also can get a value null
		public int? Score { get; set; } //default is null

		public bool IsStudent {  get; set; } //default value is false
		public bool? IsParttimeStudent { get; set; } //default is null

		public string Name { get; set; } //default value is null (after C#8 it is preffered to use string?)
		public List<int> Numbers { get; set; } //default value is null, we need to create an empty list in the constructor if we want to use this list
	}
}
