using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;

namespace EduHome.UI.Mapper;

public class CourseProfile:Profile
{
	public CourseProfile()
	{
		CreateMap<CoursePostVM,Course>().ReverseMap();
	}
}
