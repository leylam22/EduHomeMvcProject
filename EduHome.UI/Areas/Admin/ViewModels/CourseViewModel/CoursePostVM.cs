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
    public DateTime Start { get; set; }
    public string? Duration { get; set; }
    public string? ClassDuration { get; set; }
    public decimal CourseFee { get; set; }
    public int LanguageOptionId { get; set; }
    public int AssesmentId { get; set; }
    public int SkillLevelId { get; set; }

    public int CourseCatagoryId { get; set; }
}
