using Exam.Models;
using Exam.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistEventsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ArtistEventsController(MainDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArtistEvent([FromBody]ArtistEventDTO artistEventDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var doesArtistExist = await _context.Artists.AnyAsync(a => a.IdArtist == artistEventDto.IdArtist);

                if (!doesArtistExist)
                {
                    return StatusCode(404, "No artist with such id was found");
                }
                
                var doesEventExist = await _context.Events.AnyAsync(a => a.IdEvent == artistEventDto.IdEvent);

                if (!doesEventExist)
                {
                    return StatusCode(404, "No event with such id was found");
                }
                
                var artistEvent = await _context.ArtistEvents
                    .FindAsync(artistEventDto.IdEvent, artistEventDto.IdArtist);

                if (artistEvent == null)
                {
                    return StatusCode(404, "The specified artist does not have any scheduled performances in the given event");
                }

                if (artistEvent.Event.StartDate <= DateTime.Now)
                {
                    return StatusCode(409, "Cannot change the performance date on the start day of the event or past it");
                }

                if (artistEventDto.PerformanceDate < artistEvent.Event.StartDate || artistEventDto.PerformanceDate > artistEvent.Event.EndDate)
                {
                    return StatusCode(409, "The new performance date has to be within the start and end time of the event");
                }
                
                var isPerformanceDateTaken = await _context.ArtistEvents
                    .AnyAsync(ae => ae.IdEvent == artistEventDto.IdEvent && ae.PerformanceDate == artistEventDto.PerformanceDate);

                if (isPerformanceDateTaken)
                {
                    return StatusCode(409, "This performance date is already taken for the specified event");
                }

                await _context.SaveChangesAsync();

                return Ok("The artist's performance date has been successfully updated to " + artistEventDto.PerformanceDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(500, "An error occurred while processing the request");
            }
        } 
    }
}

