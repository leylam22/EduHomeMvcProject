using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.Admin.ViewModels.BlogViewModel;

namespace EduHome.UI.Mapper;

public class BlogProfile:Profile 
{
	public BlogProfile()
	{
		CreateMap<BlogPostVM, Blog>().ReverseMap();
	}
}
