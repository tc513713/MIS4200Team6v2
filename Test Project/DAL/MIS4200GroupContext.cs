using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Project.Models; //This accesses the models
using System.Data.Entity; //This is used to access the DbContext object

namespace Test_Project.DAL
{
    public class MIS4200GroupContext : DbContext // inherits from DbContext
    {
        public MIS4200GroupContext() : base ("name=DefaultConnection")
        {

        }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Recognition> Recognition { get; set; }
    }
}