 using SchoolAPI;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolLogic
{
    public class CourseLogic
    {
        private SchoolContext _context = new SchoolContext();

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course Get(int id)
        {
            return _context.Courses
                .Where(course => course.CourseID == id)
                .FirstOrDefault();
        }

        public void Post(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(_context.Courses
                .Where(course => course.CourseID == id)
                .FirstOrDefault());

            _context.SaveChanges();
        }
    }
}
