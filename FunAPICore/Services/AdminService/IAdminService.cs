using System.Collections.Generic;
using System.Threading.Tasks;
using funAPI.DTOs.Name;
using funAPI.Models;

namespace FunAPICore.Services.AdminService
{
    public interface IAdminService
    {
        Task<ServiceResponse<List<GetNameDTO>>> DeleteAName(int id);
        Task<ServiceResponse<List<GetBookedNamesDTO>>> GetBookedList();
    }
}