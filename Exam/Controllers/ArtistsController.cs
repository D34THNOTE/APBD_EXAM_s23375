using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ArtistsController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet("{idArtist}")]
        public async Task<IActionResult> GetArtistDetails(int idArtist)
        {
            try
            {
                var artist = await _context.Artists.FindAsync(idArtist);

                if (artist == null)
                {
                    return StatusCode(404, "No artist with such id was found");
                }

                if (artist.ArtistEvents.IsNullOrEmpty())
                {
                    return Ok(artist);
                }

                var artistEvents = await _context.ArtistEvents
                    .Where(ae => ae.IdArtist == idArtist)
                    .Include(ae => ae.Event)
                    .ToListAsync();

                var orderedEvents = artistEvents
                    .OrderBy(ae => ae.Event.StartDate)
                    .Select(ae => new
                    {
                        ae.Event.IdEvent,
                        ae.Event.Name,
                        ae.Event.StartDate,
                        ae.Event.EndDate
                    })
                    .ToList();

                var returnData = new
                {
                    artist.IdArtist,
                    artist.Nickname,
                    Events = orderedEvents
                };

                return Ok(returnData);
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
