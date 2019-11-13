using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentProject.Models
{
    public class DoctorModel
    {
        public int DId { get; set; }

        [Display(Name ="Queue")]
        [Required]
        public int DApQueue { get; set; }

        [Display(Name ="Status")]
        [Required]
        public int DStatus { get; set; }
    }
}
