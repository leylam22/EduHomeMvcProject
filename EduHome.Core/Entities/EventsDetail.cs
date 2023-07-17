using EduHome.Core.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Core.Entities;

public class EventsDetail : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(255)]
    public string ImagePath { get; set ; }
    [Required, MaxLength(2000)]
    public string Description { get; set ; }
    public int EventId { get; set ; }
    [ForeignKey("EventId")]
    public Event Events { get; set ; }
}
