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
        public string email { get; set; }
        [Display(Name = "Most Used Email Address")]
        [Required(ErrorMessage = "Please enter a valid Centric email address")]
        [StringLength(60)]
        public string firstName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Employee First Name is Required")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Employee Last Name is Required")]
        [StringLength(20)]
        public string phoneNumber { get; set; }
        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Numbers Must be input in the(xxx) xxx - xxxx or xxx - xxx - xxxx Format")]
        public string linkedInURL { get; set; }
        [Display(Name = "LinkedIn URL")]
        [StringLength(20)]
        public string location { get; set; }
        [Display(Name = "Company Location")]
        [Required(ErrorMessage = "Please enter a Centric Office Location")]
        [StringLength(30)]

        public ICollection<Value> Value { get; set; }

    }
}