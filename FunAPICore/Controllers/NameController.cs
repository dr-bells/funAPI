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
    public class NamesController : ControllerBase
    {
        const string admin = "ADMIN";

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
    }
}