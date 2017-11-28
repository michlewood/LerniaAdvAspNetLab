using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLab.Controllers
{
    [Route("Lab3")]
    public class Lab3Controller : Controller
    {

        [HttpGet, Route("lamp")]
        public IActionResult Lamp(bool LampIsOn)
        {

            if (LampIsOn)
            {
                string html = $"<body style='background-color:yellow'></body>";
                return Content(html, "text/html");
            }
            else if (!LampIsOn)
            {
                string html = $"<body style='background-color:gray'></body>";
                return Content(html, "text/html");
            }

            return View();
        }

        [HttpGet, Route("chocolate")]
        public IActionResult Chocolate(int nrOfPeople)
        {

            if (nrOfPeople <= 0)
            {
                return BadRequest("Must be atleast one person");
            }

            else
            {
                int amountOfChocolate = 25;
                int chocolatePerPerson = amountOfChocolate / nrOfPeople;
                return Ok(chocolatePerPerson); 
            }
        }

        [HttpGet, Route("order")]
        public IActionResult Order(string orderNumber)
        {

            if (!(orderNumber.Length.Equals(7)) || !(orderNumber.ElementAt(2) == '-') 
                || !(int.TryParse(orderNumber.Substring(3), out int number)) 
                || !(CheckIfLetter(orderNumber[0])) || !(CheckIfLetter(orderNumber[1])))
            {
                return BadRequest("Ordern måste vara i formatet två bokstäver dash fyra siffror (XX-0000)");
            }
            else if (number > 3000)
            {
                return NotFound("Order ej funnen");
            }
            else
            {
                return Ok($"Order {orderNumber.ToUpper()} hittades i databasen");
            }
        }

       

        [HttpGet, Route("users")]
        public IActionResult Users(string username)
        {
            string html;

            if (username == "Stewie")
            {
                throw  new Exception("DATA ERROR!");
            }
            else if (username == "Peter")
            {
                html = "<img src='/img/explosion.bmp' style='height:200px'></img>";

            }
            else if(username == "Lois" || username == "Meg" 
                || username == "Chris" || username == "Brian")
            {
                html = "<img src='/img/thumbUp.bmp' style='height:200px'></img>";
            }

            else
            {
                html = "<img src='/img/thumbDown.bmp' style='height:200px'></img>";

            }

            return Content(html, "text/html");
        }

        private bool CheckIfLetter(char characterToCompare)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö'};
            characterToCompare = characterToCompare.ToString().ToLower().ToCharArray()[0];
            foreach (char letter in alphabet)
            {
                if (letter == characterToCompare)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
