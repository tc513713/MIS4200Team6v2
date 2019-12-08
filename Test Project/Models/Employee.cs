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
        public GUID id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Employee First Name is Required")]
        [StringLength(120)]
        public string firstName { get; set; }
        

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Employee Last Name is Required")]
        [StringLength(120)]
        public string lastName { get; set; }

        public string fullName
        {
            get
            {
                return firstName + ", " + lastName;
            }
        }
        

        [Display(Name = "Most Used Email Address")]
        [Required(ErrorMessage = "Please enter a valid Centric email address")]
        [StringLength(60)]
        public string email { get; set; }
       

        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$", ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]

        public string phoneNumber { get; set; }
  
        [Display(Name = "LinkedIn URL")]
        [StringLength(100)]
        public string linkedInURL { get; set; }


        //[Display(Name = "Company Location")]
        [Required(ErrorMessage = "Please enter a Centric Office Location")]
        [StringLength(30)]
        public string Location { get; set; }
        
      // public ICollection<Value> Value { get; set; }


        public enum location
        {
            //Company locations, setting up selection list
            Boston, Charlotte, Chicago, Cincinnati, Cleveland, Columbus, India, Indianapolis, Louisville, Miami, Seattle, StLouis, Tampa
          
        }

        ICollection<TestCoreValues> testCoreValues { get; set; }



    }
}