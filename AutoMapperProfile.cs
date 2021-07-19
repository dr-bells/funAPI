using AutoMapper;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace funAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Name, GetNameDTO>();
            CreateMap<AddNameDTO, Name>();
        }
    }
}