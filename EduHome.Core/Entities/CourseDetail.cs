using EduHome.Core.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class CourseDetail : IEntity
{
    public int Id { get ; set ; }
    [Required]
    public DateTime Starts { get; set; }
    [Required]
    public int Students { get; set; }
    [Required]
    public decimal CourseFee { get; set; }
    [Required, MaxLength(50)]
    public string Duration { get; set; }= null!;
    [Required, MaxLength(50)]
    public string ClassDuration { get; set; }=null!;
    public int StudentCount { get; set; }
    public Language? LanguageOption { get; set; }
    public Assesment? Assesment { get; set; }
    public SkillLevel? Skill { get; set; }
    public int LanguageOptionId { get; set; }
    public int AssesmentId { get; set; }
    public int SkillId { get; set; }


    public int CourseId { get; set; }
    [ForeignKey("CourseId")]
    public Course Courses { get; set; }
}
