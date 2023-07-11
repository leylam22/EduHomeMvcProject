using EduHome.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities;

public class Teacher : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(100)]
    public string FullName { get ; set ; }
    [Required, MaxLength(255)]
    public string ImagePath { get ; set ; }
    [Required, MaxLength(100)]
    public string Position { get ; set ; }
    public TeacherDetail teacherDetails { get; set; }
}
