using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class SkillLevel : IEntity
{
    public int Id { get ; set ; }
    public string? Skill { get; set; }
    CourseDetail? CourseDetail { get; set; }
}
