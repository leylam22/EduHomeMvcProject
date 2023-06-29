using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;

public class CoursePostVM
{
    [Required, MaxLength(10)]
    public string? Title { get; set; }
    [Required, MaxLength(120)]
    public string? Description { get; set; }
    [Required, MaxLength(255)]
    public string? ImagePath { get; set; }
}
