using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Project.Models
{
    public class Profile
    {
        [Key]
        // set primary key as guid
        public Guid ID { get; set; }
        
        [Display(Name = "Employee First Name")]
        [Required(ErrorMessage = "Please enter First Name of employee")]
        [StringLength(120)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(120)]
        public string lastName { get; set; }
       
      
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter Phone Number")]
        [StringLength(12)]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter a valid Email")]
        [StringLength(120)]
        public string email { get; set; }

        [Display(Name = "Business Unit Location")]
        [Required(ErrorMessage = "Business Unit Location Required")]

        public businessUnitLocation businessUnit { get; set; }
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date Required")]
        [StringLength(120)]
        public string hireDate { get; set; }
      

        //Used to make a dropdown with each business location available for choosing
        public enum businessUnitLocation
        {
            Boston, Charlotte, Chicago, Cincinnati, Cleveland, Columbus, India, Indianapolis, Louisville, Miami, Seattle, StLouis, Tampa
            
        }
     
        ICollection<Recognition> Recognition { get; set; }

        
    }
}