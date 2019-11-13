using System;
using System.ComponentModel.DataAnnotations;

namespace SystemLibraryData
{
    public class Appointment
    {
        [Display(Name ="ID")]
        public int ApId
        {
            get;
            set;
        }
        
        public int PId
        {
            get;
            set;
        }

        [Display(Name ="Card No")]
        public string CNo { get; set; }

        [Display(Name ="Date")]
        public DateTime ApDate
        {
            get;
            set;
        }
        
        public int ApStatus
        {
            get;
            set;
        }
        
        [Display(Name = "Fee")]
        public decimal ChFee
        {
            get;
            set;
        }


        [Display(Name = "Status")]
        public int ChStatus
        {
            get;
            set;
        }

        public string SpUsername { get; set; }

        public int DId { get; set; }

        public Doctor Doctor { get; set; }
    }
}