using System.ComponentModel.DataAnnotations;

namespace Exam.Models;

public class Event
{
    [Key]
    public int IdEvent { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    public virtual ICollection<Artist_Event> ArtistEvents { get; set; } = new List<Artist_Event>();
    
    public virtual ICollection<Event_Organiser> EventOrganisers { get; set; } = new List<Event_Organiser>();
}