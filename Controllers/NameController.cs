using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using funAPI.DTOs.Name;
using funAPI.Models;
using funAPI.Services.NameService;
using Microsoft.AspNetCore.Mvc;

namespace funAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly INameService _nameService;

        public NamesController(INameService nameService)
        {
            _nameService = nameService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> GetAll()
        {
            return Ok(await _nameService.GetAll());
        }

        [HttpGet("GetAll/Generated/Today")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> Get()
        {
            return Ok(await _nameService.GetListForToday());
        }

        [HttpGet("GetAll/Booked/{role}")]
        public async Task<ActionResult<ServiceResponse<List<GetBookedNamesDTO>>>> GetAllBooked(string role)
        {
            if (role.ToUpper() != "ADMIN")
                return Unauthorized();
            return Ok(await _nameService.GetBookedList(role));
        }

        [HttpGet("Generate")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> GenerateAName()
        {
            return Ok(await _nameService.GenerateAName());
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> AddName(AddNameDTO newName)
        {
            return Ok(await _nameService.AddAName(newName));
        }

        [HttpPost("Book/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> BookAName(int id)
        {
            return Ok(await _nameService.BookAName(id));
        }

        [HttpDelete("{role}/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> DeleteAName(string role, int id)
        {
            var response = await _nameService.DeleteAName(role, id);
            if (response.Data == null || role.ToUpper() != "ADMIN")
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}