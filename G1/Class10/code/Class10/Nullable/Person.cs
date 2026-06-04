namespace Nullable
{
    internal class Person
    {
        public int Id { get; set; }
        public int? Score { get; set; }
        public string Name { get; set; }
        public bool IsEmployed { get; set; }
        public bool? HasPet { get; set; }
        public List<int> Grades { get; set; } // = new List<int>();
    }
}
