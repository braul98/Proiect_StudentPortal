using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class CourseGrade
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public decimal Grade { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Semester Semester { get; set; }

    }

    public enum Semester
    {
        One = 1,
        Two = 2
    }
}