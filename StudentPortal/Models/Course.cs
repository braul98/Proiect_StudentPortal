using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearId { get; set; }
        public Year Year { get; set; }
        public ICollection<ApplicationUser> Students { get; set; }
        public ICollection<CourseGrade> CourseGrades { get; set; }
    }
}