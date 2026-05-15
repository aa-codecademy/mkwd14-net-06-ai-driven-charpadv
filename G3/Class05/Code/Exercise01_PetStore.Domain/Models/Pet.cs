using Exercise01_PetStore.Domain.Enums;

namespace Exercise01_PetStore.Domain.Models
{
	public abstract class Pet
	{
        public string Name { get; set; }
        public int Age { get; set; }
        public PetTypeEnum PetType { get; set; }
        public abstract void PrintInfo();

        public Pet(string name, int age, PetTypeEnum type)
        {
            Name = name;
            Age = age;
            PetType = type;
        }
    }
}
