using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLab.Model
{
    public class SimplePerson
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "FirstNamn is Required")]
        public string Firstname { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is Required")]
        public string Age { get; set; }
    }
}
