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
    }

    public class StatusResponse
    {
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
