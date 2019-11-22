﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Project.Models
{
    public class TestCoreValues
    {
        public int ID { get; set; }
        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "ID of Person giving the recognition")]
        
        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }
    }
}
