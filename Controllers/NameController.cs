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
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> Get()
        {
            return Ok(await _nameService.GetList());
        }

        [HttpGet("GetAll/Booked/{role}")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> GetAllBooked(string role)
        {
            return Ok(await _nameService.GetList());
        }

        [HttpGet("GenerateAName")]
        public ActionResult GenerateAName()
        {
            string generatedName = RandomString(10);
            return Ok(generatedName);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> BookAName(AddNameDTO newName)
        {
            return Ok(await _nameService.BookAName(newName));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetNameDTO>>>> DeleteAName(int id)
        {
            var response = await _nameService.DeleteAName(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}