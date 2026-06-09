using Microsoft.AspNetCore.Mvc;
using MySpot.Api.Models;
using MySpot.Api.Services;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("reservations")]
public class ReservationsController : ControllerBase
{
    private static readonly ReservationService _service  = new();

    

    [HttpGet]
    public ActionResult<IEnumerable<Reservation>> Get() => Ok(_service.GetAll());
    

    [HttpGet("{id:guid}")]
    public ActionResult<Reservation> Get(Guid id)
    {
       var reservation = _service.Get(id);
       if (reservation == null)
       {
           return NotFound();
       }
       return Ok(reservation);
    }
    
    [HttpPost]
    public ActionResult Post( Reservation reservation)
    {
       var id =_service.Create(reservation);
       if (id is null)
       {
           return BadRequest();
       }

       return CreatedAtAction(nameof(Get), new { id = id }, null);
    }

    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id,Reservation reservation)
    {
        reservation.Id = id;
        if (_service.Update(id, reservation))
        {
            return NoContent();
        }
        return NotFound();

    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        if (_service.Delate(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}