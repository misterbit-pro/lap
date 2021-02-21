using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsOffice.Models
{
    public class AddPatientFromModel
    {
        [Required]
        public string SvNumber { get; set; }
    }
}
