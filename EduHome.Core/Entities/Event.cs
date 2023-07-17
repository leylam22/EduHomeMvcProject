using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class Event : IEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int EventDetailId { get; set; }
    public EventsDetail? EventDetails { get; set; }
    public List<EventSpeaker> EventSpeakers { get; set; }
}
