using AutoMapper;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace FunAPITests.Tests
{
    public static class GetNameMapperHelper
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Names, GetNameDTO>());
            var mapper = new Mapper(config);

            return mapper;
        }
    }

}