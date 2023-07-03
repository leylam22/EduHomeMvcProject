using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.Admin.ViewModels.EventViewModel;

namespace EduHome.UI.Mapper;

public class EventProfile:Profile 
{
	public EventProfile()
	{
		CreateMap<EventPostVM,Event>().ReverseMap();
	}
}
