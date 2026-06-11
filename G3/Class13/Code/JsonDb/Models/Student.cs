namespace JsonDb.Models
{
	public class Student : BaseEntity
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int Age { get; set; }
		public override string GetInfo()
		{
			return $"{Firstname} {Lastname} - {Age}";
		}
	}
}
