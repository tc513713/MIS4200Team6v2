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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string linkedInURL { get; set; }
        public string location { get; set; }

        public ICollection<Value> Value { get; set; }

    }
}