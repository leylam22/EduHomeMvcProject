using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.Admin.ViewModels.TestimonialViewModel;

namespace EduHome.UI.Mapper;

public class TestimonialProfile:Profile
{
	public TestimonialProfile()
	{
		CreateMap<TestimonialPostVM, Testimonial>().ReverseMap();
	}
}
