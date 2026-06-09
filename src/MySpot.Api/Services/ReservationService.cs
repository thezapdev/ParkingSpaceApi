using MySpot.Api.Models;

namespace MySpot.Api.Services;

public class ReservationService
{
    private static int _id = 1;
    private static readonly List<Reservation> Reservations = new();

    private static readonly List<string> _parkingSpotNames = new List<string>()
    {
        "P1", "P2", "P3", "P4", "P5"
    };

    public Reservation Get(int id)
    
      => Reservations.SingleOrDefault(x => x.Id == id);
    
    public IEnumerable<Reservation> GetAll() => Reservations;

    public int? Create(Reservation reservation)
    {
        var now = DateTime.UtcNow.Date;
        var pastDays = now.DayOfWeek  is DayOfWeek.Sunday ? 7 : (int) now.DayOfWeek;
        var remaining = 7 - pastDays;
        
        if (_parkingSpotNames.All(x => x != reservation.ParkingSpotName))
        {
            return default;
        }

        if (!(reservation.Date.Date >= now && reservation.Date.Date <= now.AddDays(remaining)))
        {
            return default;
        }
        reservation.Date = DateTime.UtcNow.AddDays(1).Date;

        var reservationAlreadyExists = Reservations.Any(x => x.ParkingSpotName == reservation.ParkingSpotName && x.Date.Date == reservation.Date.Date);

        if (reservationAlreadyExists)
        {
            return default;
        }
        reservation.Id = _id;
        _id++;
        Reservations.Add(reservation);
    return reservation.Id;
    }

    public bool Update(int id, Reservation reservation)
    {
        var existingreservation = Reservations.SingleOrDefault(x => x.Id == reservation.Id);

        if (existingreservation == null)
        {
            return false;
        }

        if (existingreservation.Date <= DateTime.UtcNow.Date)
        {
            return false;
        }
        existingreservation.LicensePlate = reservation.LicensePlate;
        return true;
    }

    public bool Delate(int id)
    {
        var existingreservation = Reservations.SingleOrDefault(x => x.Id == id);

        if (existingreservation == null)
        {
            return false;
        } 
        Reservations.Remove(existingreservation);
        return true;
    }
}