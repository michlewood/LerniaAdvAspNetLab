using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiLab.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLab.Controllers
{
    [Route("demo4")]
    public class DemoApi4Controller : Controller
    {
        // GET: api/values
        [HttpPost, Route("addMeeting")]
        public IActionResult AddMeeting(Meeting meeting)
        {
            return Ok($"{meeting.People} at {meeting.Location}");
        }

    }
}
