using EduHome.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities;

public class Speaker : IEntity
{
    public int Id { get ; set ; }
    public string Name { get ; set ; }
    public string Position { get ; set ; }
    public string ImagePath { get ; set ; }

    public List<EventSpeaker> EventSpeakers { get ; set ; }
}
