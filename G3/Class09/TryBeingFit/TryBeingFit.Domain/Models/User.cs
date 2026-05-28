using TryBeingFit.Domain.Enums;

namespace TryBeingFit.Domain.Models
{
	//we don't want to be able to create a user that is just a User, so we make this class abstract
	public abstract class User : BaseEntity
	{
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
