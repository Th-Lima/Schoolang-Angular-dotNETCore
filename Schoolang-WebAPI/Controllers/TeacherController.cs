using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Schoolang_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professor: Thales");
        }
    }
}
