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
        public int culture { get; set; }
        public int deliveryExcellence { get; set; }
        public int innovation { get; set; }
        public int greaterGood { get; set; }
        public int integrityAndOpenness { get; set; }
        public int Balance { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}