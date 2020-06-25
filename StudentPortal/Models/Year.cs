using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class Year
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        ICollection<Course> Courses { get; set; } 
    }
}