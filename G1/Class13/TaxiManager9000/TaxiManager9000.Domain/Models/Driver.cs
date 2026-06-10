namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.BaseEntity;

public class Driver : BaseEntity
{
    public Driver(string v1, string v2, object noShift, object value, string v3, DateTime dateTime)
    {
        V1 = v1;
        V2 = v2;
        NoShift = noShift;
        Value = value;
        V3 = v3;
        DateTime = dateTime;
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Shift Shift { get; set; }
    public Car? Car { get; set; }
    public string License { get; set; } = string.Empty;
    public DateTime LicenseExpieryDate { get; set; }
    public string V1 { get; }
    public string V2 { get; }
    public object NoShift { get; }
    public object Value { get; }
    public string V3 { get; }
    public DateTime DateTime { get; }
}
