using System.ComponentModel.DataAnnotations;

namespace Exam.Models.DTOs;

public class ArtistEventDTO
{
    [Required]
    public int IdArtist { get; set; }
    
    [Required]
    public int IdEvent { get; set; }
    
    [Required]
    public DateTime PerformanceDate { get; set; }
}