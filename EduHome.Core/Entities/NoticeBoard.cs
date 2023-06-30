using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class NoticeBoard:IEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = null!;
}
