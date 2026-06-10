namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Domain.Enums;

public class User : BaseEntity
{
    private string v1;
    private string v2;
    private Role maintenance;

    public User(string v1, string v2, Role maintenance)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.maintenance = maintenance;
    }

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
}
