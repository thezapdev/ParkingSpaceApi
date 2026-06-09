namespace MySpot.Api.Models;

public class Reservation
{
    public int Id { get;  }
    public string EmployeeName { get; private set; }
    public string ParkingSpotName { get; private set; }
    public string LicensePlate { get; private set; }
    public DateTime Date { get; private set; }

    public Reservation(int id, string employeeName, string parkingSpotName, string licensePlate, DateTime date)
    {
        Id = id;
        EmployeeName = employeeName;
        ParkingSpotName = parkingSpotName;
        LicensePlate = licensePlate;
        Date = date;
    }

    public void ChangeLicencePlate(string licensePlate)
    {
        if (string.IsNullOrWhiteSpace(licensePlate))
        {
            throw new ArgumentException("License plate cannot be empty");
            
        }
        LicensePlate = licensePlate;
    }
}