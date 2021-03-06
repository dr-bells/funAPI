using System.Collections.Generic;
using System.Threading.Tasks;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace funAPI.Services.NameService
{
    public interface INameService
    {
        Task<ServiceResponse<List<GetNameDTO>>> GetAll();
        Task<ServiceResponse<List<GetNameDTO>>> GetListForToday();
        Task<ServiceResponse<List<GetNameDTO>>> GenerateAName();
        Task<ServiceResponse<List<GetNameDTO>>> AddAName(AddNameDTO newName);
        Task<ServiceResponse<List<GetBookedNamesDTO>>> BookAName(int id);

    }
}