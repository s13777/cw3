using cw3.DTOs.Requests;
using cw3.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System;


namespace cw3.Controllers
{
    [ApiController]
    [Route(template: "api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            _service.EnrollStudent(request);
            var response = new EnrollStudentResponse();
            return Ok(response);

        }
    }

}