using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.Admin.ViewModels.NoticeBoardViewModel;

namespace EduHome.UI.Mapper;

public class NoticeBoardProfile:Profile
{
	public NoticeBoardProfile()
	{
		CreateMap<NoticeBoardPostVM,NoticeBoard>().ReverseMap();
	}
}
