using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cw3.DAL;
using cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw3.Controllers
{
    [ApiController]
    [Route(template:"api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudent());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id == 2)
            {
                return Ok("Malewski");
            } else if (id == 3)
            {
                return Ok("Andrzejewski");
            }
            return NotFound("Nie znaleziono studenta!");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //... add to database
            //... generating index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                return Ok("Usuwanine ukończone.");

            }
            return NotFound("Nie ma takiego studenta.");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                return Ok("Aktualizacja dokończona.");

            }
            return NotFound("Nie ma takiego studenta.");
        }


    }
}