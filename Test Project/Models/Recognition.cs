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

        public int recognitionID { get; set; }


        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "ID of Person giving the recognition")]
        
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

        public GUID ID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
