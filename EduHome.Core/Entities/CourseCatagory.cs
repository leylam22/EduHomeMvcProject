using EduHome.Core.Interface;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class CourseCatagory : IEntity
{
    public int Id { get; set; }

    [Required, MaxLength(30)]
    public string? Catagory { get; set; }
    public ICollection<Course>? Courses { get; set; }
}
