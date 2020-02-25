using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : Controller
    {
        [HttpGet("status")]
        public ActionResult<StatusResponse> GetTheStatus()
        {
            var response = new StatusResponse
            {
                Status = "Looks good up here, cap",
                CreatedAt = DateTime.Now
            };
            return Ok(response);
        }
        [HttpGet("employees/{employeeId:int:min(1)}/salary")]
        public ActionResult GetEmployeeSalary(int employeeId)
        {
            return Ok($"Employee {employeeId} has a salary of $65000.");
        }

        [HttpGet("shoes")]
        public ActionResult GetSomeShoes([FromQuery] string color = "All")
        {
            return Ok($"Getting you shoes of color {color}");
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmI([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"You are using {userAgent}");
        }

        [HttpPost("employees")]
        public ActionResult AddAnEmployee([FromBody] NewEmployee employee, [FromServices] IGenerateEmployeeIds idGenerator)
        {
            var id = idGenerator.GetNewEmployeeId();
            return Ok($"Hiring {employee.Name} starting at {employee.StartingSalary.ToString("c")} with id of {id.ToString()}");
        }
    }


    public class NewEmployee
    {
        public string Name { get; set; }
        public decimal StartingSalary { get; set; }
    }


    public class StatusResponse
    {
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
