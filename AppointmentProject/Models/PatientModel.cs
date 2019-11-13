using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentProject.Models
{
    public class PatientModel
    {
        public int PId { get; set; }

        [Display(Name = "Card ID")]
        [Required]
        [DataType(DataType.Text)]
        public string CardNo { get; set; }

        [Display(Name = "Name")]
        [Required]
        [DataType(DataType.Text)]
        public string PName { get; set; }

        [Display(Name = "Sex")]
        [Required]
        public string PSex { get; set; }

        [Display(Name = "Tel")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PTel { get; set; }

        [Display(Name = "Email"), DataType(DataType.EmailAddress), Required] 
        public string PAddress { get; set; }

        [Display(Name = "Identification")]
        [Required]
        public string PDocumentNo { get; set; }
    }
}
