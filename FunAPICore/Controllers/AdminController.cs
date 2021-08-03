using System.Collections.Generic;
using System.Threading.Tasks;
using funAPI.DTOs.Name;
using funAPI.Models;
using FunAPICore.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace FunAPICore.Controllers
{
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService nameService)
        {
            _adminService = nameService;
        }

        [HttpGet("GetAll/Booked")]
        public async Task<ActionResult<ServiceResponse<List<GetBookedNamesDTO>>>> GetAllBooked()
        {
            return Ok(await _adminService.GetBookedList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> DeleteAName(int id)
        {
            var response = await _adminService.DeleteAName(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
    }
}