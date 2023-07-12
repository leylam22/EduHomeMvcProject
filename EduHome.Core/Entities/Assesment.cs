using EduHome.Core.Interface;

namespace EduHome.Core.Entities;

public class Assesment : IEntity
{
    public int Id { get ; set ; }
    public string? AssesmentType { get; set; }
    CourseDetail? CourseDetail { get; set; }
}
