using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class Year
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Course> Courses { get; set; } 
    }
}