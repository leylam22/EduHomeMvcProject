using EduHome.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities;

public class AboutUs : IEntity
{
    public int Id { get ; set ; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
