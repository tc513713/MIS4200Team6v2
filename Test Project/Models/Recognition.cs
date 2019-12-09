using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Project.Models
{
    public class Recognition
    {
        [Key]


        public int recognitionID { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(120)]
        public string description { get; set; }

        [Display(Name = "Values")]
        [Range(1, 7)]
        [Required(ErrorMessage = "Please select your Core Value")]
        public coreValues values { get; set; }

        public enum coreValues
        {
            [Display(Name = "Please Select")]
            Select = 0,
            Stewardship=1,
            Culture=2,
            Excellence=3,
            Innovation=4,
            GreaterGood=5,
            Integrity=6,
            Balance=7
        }

        public virtual Profile Profile { get; set; }
        public Guid id { get; set; }
        
    }
}