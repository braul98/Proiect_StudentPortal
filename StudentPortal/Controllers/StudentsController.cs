using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            var students = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains("296c2aa0-e9b6-4c77-8ffc-7a1763c4b8e5")).ToList();

            return View(students);
        }

        [HttpGet]
        public ActionResult CoursesGrades(string id)
        {
            var courses = db.Courses.Include(nameof(Course.CourseGrades)).Where(x => x.CourseGrades.Select(c => c.UserId).Contains(id)).ToList();

            ViewBag.StudentId = id;
            return View(courses.ToList());
        }

        [HttpGet]
        public ActionResult Courses(string id)
        {
            var courses = db.Courses.Where(x => x.CourseGrades.Select(c => c.UserId).Contains(id) == false);
            ViewBag.StudentId = id;
            return View(courses.ToList());
        }

        public ActionResult AddCourse(int courseId, string studentId)
        {
            var user = db.Users.First(x => x.Id == studentId);

            var grades = new List<CourseGrade>
            {
                new CourseGrade
                {
                    UserId = studentId,
                    CourseId = courseId,
                    Grade = 0,
                    Semester = Semester.One
                },
                new CourseGrade
                {
                    UserId = studentId,
                    CourseId = courseId,
                    Grade = 0,
                    Semester = Semester.Two
                }
            };
            db.CourseGrades.AddRange(grades);
            db.SaveChanges();
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult AddGrades(int courseId, string studentId, string abc)
        {
            var course = db.Courses.First(x => x.Id == courseId);

            ViewBag.StudentId = studentId;

            return View(course);
        }

        public ActionResult AddGrades(int courseId, string studentId, FormCollection collection )
        {
            var first = decimal.Parse(collection["First"]);
            var second = decimal.Parse(collection["Second"]);


            var course = db.Courses.Include(nameof(Course.CourseGrades)).First(x => x.Id == courseId);

            var firstSemesterGrade = course.CourseGrades.First(x => x.UserId == studentId && x.Semester == Semester.One);
            var secondSemesterGrade = course.CourseGrades.First(x => x.UserId == studentId && x.Semester == Semester.Two);
            firstSemesterGrade.Grade = first;
            secondSemesterGrade.Grade = second;
            db.Entry(firstSemesterGrade).State = EntityState.Modified;
            db.Entry(secondSemesterGrade).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Courses");

        }
    }


}