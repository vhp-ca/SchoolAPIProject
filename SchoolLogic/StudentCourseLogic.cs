using SchoolAPI;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolLogic
{
    public class StudentCourseLogic
    {
       

            private SchoolContext _context = new SchoolContext();

            public List<StudentCourse> GetAll()
            {
                return _context.StudentCourses.ToList();
            }

            public StudentCourse Get(int id)
            {
            return _context.StudentCourses
            .Where(StudentCourse => StudentCourse.StudentCourseID == id)
            .FirstOrDefault();
        }

            public void Post(StudentCourse studentCourse)
            {
                _context.Add(studentCourse);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                _context.Remove(_context.StudentCourses
                    .Where(Studentcourse => Studentcourse.StudentCourseID == id)
                    .FirstOrDefault());

                _context.SaveChanges();
            }
        }

    }

