using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Test_Project.Models
{
    public class Employee
    {
        [Key]
        public int userId { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Employee First Name is Required")]
        [StringLength(20)]

        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Employee Last Name is Required")]
        [StringLength(20)]

        [Display(Name = "Most Used Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter a valid Centric email address")]
        [StringLength(60)]

        [Display(Name = "Mobile Phone Number")]
        public string phoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Numbers Must be input in the(xxx) xxx - xxxx or xxx - xxx - xxxx Format")]

        [Display(Name = "LinkedIn URL")]
        public string linkedInURL { get; set; }
        [StringLength(20)]

        //[Display(Name = "Company Location")]
        public string location { get; set; }
        [Required(ErrorMessage = "Please enter a Centric Office Location")]
        [StringLength(30)]

        public ICollection<Value> Value { get; set; }

    }
}