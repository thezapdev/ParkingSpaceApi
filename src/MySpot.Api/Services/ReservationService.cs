using MySpot.Api.Entities;
using MySpot.Api.Models;

namespace MySpot.Api.Services;

public class ReservationService
{

    private static readonly List<WeeklyParkingSpot> WeeklyParkingSpots = new List<WeeklyParkingSpot>()
    {
        new WeeklyParkingSpot(Guid.NewGuid(),DateTime.UtcNow,DateTime.UtcNow.AddDays(7),"P1"),
        new WeeklyParkingSpot(Guid.NewGuid(),DateTime.UtcNow,DateTime.UtcNow.AddDays(7),"P2"),
        new WeeklyParkingSpot(Guid.NewGuid(),DateTime.UtcNow,DateTime.UtcNow.AddDays(7),"P3"),
        new WeeklyParkingSpot(Guid.NewGuid(),DateTime.UtcNow,DateTime.UtcNow.AddDays(7),"P4"),
        new WeeklyParkingSpot(Guid.NewGuid(),DateTime.UtcNow,DateTime.UtcNow.AddDays(7),"P5")
    };

    public Reservation Get(Guid id) => GetAllWeekly().SingleOrDefault(w => w.Id == id);
    
    public IEnumerable<Reservation> GetAllWeekly() => WeeklyParkingSpots.SelectMany(x => x.Reservations);

    public Guid? Create(Reservation reservation)
    {
        var weeklyParkingSpot = WeeklyParkingSpots.SingleOrDefault(x => x.Id == reservation.ParkingSpotId);

        if (weeklyParkingSpot == null)
        {
            return default;
        }
        
        reservation.Id =  Guid.NewGuid();
        weeklyParkingSpot.AddReservation(reservation);
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