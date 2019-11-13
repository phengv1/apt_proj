using System.ComponentModel.DataAnnotations;

namespace SystemLibraryData
{
    public class Patient
    {
        [Display(Name = "No")]
        public int PId
        {
            get;
            set;
        }

        [Display(Name ="Name")]
        public string PName
        {
            get;
            set;
        }

        [Display(Name = "Sex")]
        public string PSex
        {
            get;
            set;
        }

        [Display(Name = "Tel")]
        public string PTel
        {
            get;
            set;
        }

        [Display(Name = "Address")]
        public string PAddress
        {
            get;
            set;
        }

        [Display(Name = "Document ID")]
        public string PDocumentNo
        {
            get;
            set;
        }

        public string CreateDate
        {
            get;
            set;
        }

        [Display(Name = "Card ID")]
        public string CNo
        {
            get;
            set;
        }

        public Card CardInfo
        {
            get;
            set;
        }
    }
}