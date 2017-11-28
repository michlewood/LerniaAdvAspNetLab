using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiLab.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLab
{
    [Route("lab4")]
    public class Lab4Controller : Controller
    {
        [HttpPost, Route("addPerson")]
        public IActionResult AddPerson(SimplePerson person)
        {
            
            bool validName = true;
            bool validAge = true;
            if (person.Firstname == null || !(person.Firstname.Length <= 20 && person.Firstname.Length >= 1))
                validName = false;
            if (person.Age == null || !(person.Age.Length <= 120 && person.Age.Length > 0))
                validAge = false;

            if (!validName || !validAge)
            {
                return BadRequest(ModelState);
            }
            else if (!validName)
            {
                return BadRequest("Name is incorrect");
            }
            if (!validAge)
            {
                return BadRequest("Age is incorrect");
            }
            return Ok($"Du har angett {person.Firstname} som är {person.Age}");
        }
    }
}
