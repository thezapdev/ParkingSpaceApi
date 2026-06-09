using MySpot.Api.Exceptions;

namespace MySpot.Api.Models;

public class Reservation
{
    public Guid Id { get;  }
    
    public Guid ParkingSpotId { get; private set; }
    public string EmployeeName { get; private set; }
    public string ParkingSpotName { get; private set; }
    public string LicensePlate { get; private set; }
    public DateTime Date { get; private set; }

    public Reservation(Guid id, string employeeName, string parkingSpotName, string licensePlate, DateTime date,Guid parkingSpotId)
    {
        Id = id;
        EmployeeName = employeeName;
        ParkingSpotName = parkingSpotName;
        ChangeLicencePlate(licensePlate);
        Date = date;
        ParkingSpotId = parkingSpotId;
    }

    public void ChangeLicencePlate(string licensePlate)
    {
        if (string.IsNullOrWhiteSpace(licensePlate))
        {
            throw new EmptyLicensePlateExceptions();

        }
        LicensePlate = licensePlate;
    }
}