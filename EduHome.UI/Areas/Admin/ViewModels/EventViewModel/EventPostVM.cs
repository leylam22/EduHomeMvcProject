namespace EduHome.UI.Areas.Admin.ViewModels.EventViewModel;

public class EventPostVM
{
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;
}
