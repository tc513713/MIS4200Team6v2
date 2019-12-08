using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Project.Models
{
    public class TestCoreValues
    {
        [Key]

        public int ID { get; set; }

        //Setting up core value Enum
        [Display(Name = "CentricValues")]
        [Range (1,5)]
        [Required(ErrorMessage = "Please Choose one of Centric's Core Values!")]
        [StringLength(110)]
        public CoreValue CentricValues { get; set; }

        //public CoreValue award { get; set; }

        [Display(Name = "Employee")]
        [Required(ErrorMessage = "Please Enter Your Name!")]
        [StringLength(110)]
        public string employee { get; set; }


        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            [Display(Name = "Please Choose a Value")]
            Select = 0,
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }

        public GUID id { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
