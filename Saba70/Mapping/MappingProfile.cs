using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace Saba70.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<Blog, BlogDTO>().ReverseMap();
            //CreateMap<BlogPostDTO, Blog>().ReverseMap();
            //CreateMap<Blog, SelectListItem>()
            //    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Title));


        }
    }
}
