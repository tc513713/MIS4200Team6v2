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
        [Required(ErrorMessage = "Description Required")]
        [StringLength(120)]
        public string description { get; set; }

        [Display(Name = "Values")]
        [Range(1, 7)]
        [Required(ErrorMessage = "Please Select a Core Value")]
        public cValues values { get; set; }

        public enum cValues
        {
            [Display(Name = "Please Select")]
            Select = 0,
            Stewardship,
            Culture,
            DeliveryExcellance,
            Innovation,
            GreaterGood,
            Integrity,
            Balance
        }

        public Guid id { get; set; }
        public virtual Profile Profile { get; set; }
    }
}