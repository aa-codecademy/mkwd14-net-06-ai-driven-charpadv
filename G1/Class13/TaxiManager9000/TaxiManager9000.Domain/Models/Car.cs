namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.BaseEntity;

public class Car : BaseEntity
{
    private string v1;
    private string v2;
    private DateTime dateTime;

    public Car(string v1, string v2, DateTime dateTime)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.dateTime = dateTime;
    }

    public string Model { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime LicensePlateExpieryDate { get; set; }
    public List<Driver> AssignedDrivers { get; set; } = new();
}
