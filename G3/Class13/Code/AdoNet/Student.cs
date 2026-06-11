namespace AdoNet
{
	public class Student
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime? EnrolledDate { get; set; }
		public char? Gender { get; set; }
		public long? NationalIdNumber { get; set; }
		public string StudentCardNumber { get; set; }
		public string GetInfo()
		{
			return $"{Id} - {Firstname} {Lastname}";
		}
	}
}
