using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Test_Project.Models
{
    public class Value
    {
        [Key]
        public int valueId { get; set; }
        public int employeeId { get; set; }
        public int stewardship { get; set; }
        [Display(Name = "Stewardship")]
        public int culture { get; set; }
        [Display(Name = "Culture")]
        public int deliveryExcellence { get; set; }
        [Display(Name = "Delivery Excellence")]
        public int innovation { get; set; }
        [Display(Name = "Innovation")]
        public int greaterGood { get; set; }
        [Display(Name = "Greater Good")]
        public int integrityAndOpenness { get; set; }
        [Display(Name = "Integrity and Openness")]
        public int Balance { get; set; }
        [Display(Name = "Balance")]
        public ICollection<Employee> Employees { get; set; }
    }

    /*  public int studentId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Students First Name is Required")]
        [StringLength(20)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Students Last Name is Required")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "Most Used Email Address")]
        [Required(ErrorMessage = "Please enter a valid email address")]
        [StringLength(60)]
        public string email { get; set; }

        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Numbers Must be input in the(xxx) xxx - xxxx or xxx - xxx - xxxx Format")]
        //[RegularExpression(@"^(\(\d{3}|) |\d{3}-)\d{3}-\d{4}$",
            //ErrorMessage ="Phone Numbers Must be input in the (xxx) xxx-xxxx or xxx-xxx-xxxx Format")]
        public string phone { get; set; }


        [Display(Name = "Anticipated Graduation")]
       [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Entry must be in a MM/DD/YYYY Format")]

        public String studentSince { get; set; }
        */




}
 