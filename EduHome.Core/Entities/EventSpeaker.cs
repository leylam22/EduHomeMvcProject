using EduHome.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities;

public class EventSpeaker : IEntity
{
    public int Id { get ; set ; }
    public int EventId { get ; set ; }
    public Event Event { get ; set ; }

    public int SpeakerId { get ; set ; }
    public Speaker Speaker { get ; set ;}
}
