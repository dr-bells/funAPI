using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using funAPI.Models;
using funAPI.Services.NameService;
using Microsoft.AspNetCore.Mvc;

namespace funAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : ControllerBase
    {
        private readonly INameService _nameService;

        public NameController(INameService nameService)
        {
            _nameService = nameService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Name>> Get()
        {
            return Ok(_nameService.GetList());
        }

        [HttpGet("GenerateAName")]
        public ActionResult GenerateAName()
        {
            string generatedName = RandomString(10);
            return Ok(generatedName);
        }

        [HttpPost]
        public ActionResult<List<Name>> BookAName(Name newName)
        {
            return Ok(_nameService.BookAName(newName));
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