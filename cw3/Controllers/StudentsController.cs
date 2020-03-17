using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cw3.Controllers
{
    [ApiController]
    [Route(template:"api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet(template:"{id}")]
        public string GetStudents(int id)
        {
            return "Kowalski, Malewski, Andrzejewski";
        }
    }
}