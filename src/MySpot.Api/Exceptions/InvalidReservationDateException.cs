namespace MySpot.Api.Exceptions;
 
public sealed class InvalidReservationDateException : CustomException
{
    public DateTime Date { get; }

    public InvalidReservationDateException(DateTime date) : base($"Reservation date: {date:d} is invalid")
    {
        Date = date;
    }
}

public sealed class ParkingSpotAlreadyReservationException : CustomException
{
    
        public string Name { get; }
        public DateTime Date { get; }
    public ParkingSpotAlreadyReservationException(string name,DateTime date) : base($"Parking spot {name} already reserved in {date:d}")
    {
        Name = name;
        Date = date;
    }
}