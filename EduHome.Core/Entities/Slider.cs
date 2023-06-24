using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class Slider : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string SecondTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
}
