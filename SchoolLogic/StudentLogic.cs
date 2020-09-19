using SchoolAPI;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolLogic
{
    public class StudentLogic
    {

       private SchoolContext _context = new SchoolContext();

            public List<Student> GetAll()
            {
                return _context.Students.ToList();
            }

            public Student Get(int id)
            {
                return _context.Students
                    .Where(Student => Student.StudentID == id)
                    .FirstOrDefault();
            }

            public void Post(Student student)
            {
                _context.Add(student);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                _context.Remove(_context.Students
                    .Where(Student => Student.StudentID == id)
                    .FirstOrDefault());

                _context.SaveChanges();
            }
        }
    
}
