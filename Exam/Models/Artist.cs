using System.ComponentModel.DataAnnotations;

namespace Exam.Models;

public class Artist
{
    [Key] 
    public int IdArtist { get; set; }

    [Required] 
    [MaxLength(30)] 
    public string Nickname { get; set; }
    
    public virtual ICollection<Artist_Event> ArtistEvents { get; set; } = new List<Artist_Event>();
}