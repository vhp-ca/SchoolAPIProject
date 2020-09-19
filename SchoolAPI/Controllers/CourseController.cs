﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/schoolapi")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private SchoolContext _context = new SchoolContext();


        // GET: api/<CourseController>
        //    [HttpGet]
        /*    public IEnumerable<Course> Get()
            {
                return _context.Courses.ToList();
            }
        */
        [HttpGet]
        [Route("course")]
     
        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return _context.Courses
                .Where(course => course.CourseID == id)
                .FirstOrDefault();
        }


        // POST api/<CourseController>

        [HttpPost]     
        [Route("course")]
        public IActionResult Post([FromBody] Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
            return Ok();
        }


        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Remove(_context.Courses
                .Where(course => course.CourseID == id)
                .FirstOrDefault());

            _context.SaveChanges();
            return Ok();
        }
    }
}
