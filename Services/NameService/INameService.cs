using System.Collections.Generic;
using System.Threading.Tasks;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace funAPI.Services.NameService
{
    public interface INameService
    {
        Task<ServiceResponse<List<GetNameDTO>>> GetList();
        Task<ServiceResponse<List<GetNameDTO>>> BookAName(AddNameDTO newName);
        Task<ServiceResponse<List<GetNameDTO>>> DeleteAName(int id);
    }
}