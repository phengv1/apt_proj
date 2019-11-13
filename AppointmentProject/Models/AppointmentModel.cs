using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemLibraryData;

namespace AppointmentProject.Models
{
    public class AppointmentModel
    {
        public int DId { get; set; }

        [Display(Name = "Card No")]
        [Required]
        [DataType(DataType.PostalCode)]
        public string CNo { get; set; }


        [Display(Name = "Date")]
        [Required]
        public DateTime ApDate
        {
            get;
            set;
        }

        [Display(Name = "Doctor Name")]
        [Required]
        public string DName { get; set; }

        [Display(Name = "Fee")]
        [Required]
        public decimal ChFee
        {
            get;
            set;
        }

        public string SpUsername { get; set; }

    }
}
