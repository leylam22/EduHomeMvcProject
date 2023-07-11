using EduHome.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities;

public class TeacherDetail : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(55)]
    public string FullName { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Position { get; set; }=null!;
    [Required, MaxLength(500)]
    public string About { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Degree { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Experience { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Hobbies { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Faculty { get; set; } = null!;
    [Required, MaxLength(255)]
    public string Mail { get; set; } = null!;
    [Required, MaxLength(55)]
    public string Phone { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Skype { get; set; } = null!;
    [Required]
    public int LanguageDegree { get; set; }
    [Required]
    public int TeamLeaderDegree { get; set; }
    [Required]
    public int DevelopmentDegree { get; set; }
    [Required]
    public int DesignDegree { get; set; }
    [Required]
    public int InnovationDegree { get; set; }
    [Required]
    public int CommunicationDegree { get; set; }

    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public Teacher Teacher { get; set; }

}
