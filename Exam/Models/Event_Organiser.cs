namespace Exam.Models;

public class Event_Organiser
{
    public int IdEvent { get; set; }
    
    public int IdOrganiser { get; set; }
    
    public virtual Event Event { get; set; }
    
    public virtual Organiser Organiser { get; set; }
}