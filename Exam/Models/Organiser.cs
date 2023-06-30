using System.ComponentModel.DataAnnotations;

namespace Exam.Models;

public class Organiser
{
    [Key]
    public int IdOrganiser { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    public virtual ICollection<Event_Organiser> EventOrganisers { get; set; } = new List<Event_Organiser>();
}