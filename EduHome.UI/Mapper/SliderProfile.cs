using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.Admin.ViewModels.SliderViewModel;

namespace EduHome.UI.Mapper;

public class SliderProfile:Profile
{
	public SliderProfile()
	{
		CreateMap<SliderPostVM, Slider>().ReverseMap();
	}
}
