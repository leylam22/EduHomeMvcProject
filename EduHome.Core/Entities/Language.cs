using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class Language : IEntity
{
    public int Id { get ; set ; }
    public string? LanguageOption { get; set; }
    CourseDetail? CourseDetail { get; set; }
}
