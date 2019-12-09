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

        public Guid ID { get; set; }
        // public int profileID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(120)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(120)]
        public string lastName { get; set; }
        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit Required")]

        public bUnit businessUnit { get; set; }
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date Required")]
        [StringLength(120)]
        public string hireDate { get; set; }
        [Display(Name = "Employee Title")]
        [Required(ErrorMessage = "Employee Title Required")]

        public eTitle employeeTitle { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required")]
        [StringLength(12)]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [StringLength(120)]
        public string email { get; set; }



        public enum bUnit
        {
            Boston,
            Charlotte,
            Chicago,
            Cincinnati,
            Cleveland,
            Columbus,
            India,
            Indianapolis,
            Louisville,
            Miami,
            Seattle,
            [Display(Name = "St. Louis")]
            StLouis,
            Tampa
        }

        public enum eTitle
        {
            Consultant,
            [Display(Name = "Senior Consultant")]
            SeniorConsultant,
            Manager,
            Architect,
            [Display(Name = "Senior Manager/Senior Architect")]
            SeniorManager,
            Director,
            VP
        }
        ICollection<Recognition> Recognition { get; set; }

        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
    }
}