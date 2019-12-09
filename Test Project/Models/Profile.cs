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
        
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(120)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(120)]
        public string lastName { get; set; }
       
      
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required")]
        [StringLength(12)]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [StringLength(120)]
        public string email { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit Required")]

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