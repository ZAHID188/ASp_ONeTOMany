using AutoMapper;
using relationshipAPI.Data.Dtos.One_TO_Many;
using relationshipAPI.Model.One_TO_many;

namespace relationshipAPI.Data.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Blog12M, Blog12M_Dto>();
            CreateMap<BlogUpdateDto, Blog12M>();
            CreateMap<Post, Post_Dto>();


        }
    }
}
