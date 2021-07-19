using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace funAPI.Services.NameService
{
    public class NameService : INameService
    {
        private static List<Name> names = new List<Name>
        {
            new Name(),
            new Name {Id = 1, BookedName = "Tsitsi"}
                };
        private readonly IMapper _mapper;
        public NameService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> BookAName(AddNameDTO newName)
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            Name name = (_mapper.Map<Name>(newName));
            name.Id = names.Max(n => n.Id) + 1;
            names.Add(name);
            serviceResponse.Data = names.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> GetList()
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            serviceResponse.Data = names.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
            return serviceResponse;
        }
    }
}