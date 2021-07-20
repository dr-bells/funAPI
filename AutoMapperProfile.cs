using AutoMapper;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace funAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Names, GetNameDTO>();
            CreateMap<AddNameDTO, Names>();
        }
    }
}