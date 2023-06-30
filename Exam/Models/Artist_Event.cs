using System.ComponentModel.DataAnnotations;

namespace Exam.Models;

public class Artist_Event
{
    public int IdEvent { get; set; }
    
    public int IdArtist { get; set; }
    
    [Required]
    public DateTime PerformanceDate { get; set; }
    
    public virtual Artist Artist { get; set; }
    
    public virtual Event Event { get; set; }
}