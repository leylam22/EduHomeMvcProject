using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class Blog:IEntity
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Blogger { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
