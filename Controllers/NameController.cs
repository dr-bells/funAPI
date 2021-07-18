using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using funAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace funAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : ControllerBase
    {
        private static List<Name> names = new List<Name>
        {
            new Name(),
            new Name {Id = 1, BookedName = "Tsitsi"}

    };

        [HttpGet("GetAll")]
        public ActionResult<List<Name>> Get()
        {
            return Ok(names);
        }

        [HttpGet("GenerateAName")]
        public ActionResult GenerateAName()
        {
            string generatedName = RandomString(10);
            return Ok(generatedName);
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