namespace Exercise01.Domain.Models
{
	public class Dog
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Bark()
        {
            Console.WriteLine("Bark bark");
        }

        public static bool Validate(Dog dog)
        {
            //when doing validations like this, usually we do the negative scenarios first. If all negative scenarios pass
            //and false is never returned then we can return true and say that the validation is a success

            //ALWAYS check if the object that was sent as param is not null
            if(dog == null)
            {
                return false;
            }

            //our Id is a required field, so this check is obsolete; if we wanted to allow null, we would write int?
            if(dog.Id == null || string.IsNullOrEmpty(dog.Name) || string.IsNullOrEmpty(dog.Color)){
                return false;
            }

            if(dog.Id < 0)
            {
                return false;
            }

            if(dog.Name.Length < 2)
            {
                return false;
            }

            return true; //if we reached this line, that means that none of the validations above returned false
        }
    }
}
