using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using School.gRPC.Protos;
using SchoolAPI.Controllers;
using SchoolAPI.Models;
using SchoolLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static School.gRPC.Protos.Course;
using Course = SchoolAPI.Models.Course;

namespace School.gRPC.Services
{
    public class CourseService : CourseBase
    {
        private readonly CourseLogic _Courselogic;
       
        public CourseService()
        {
            _Courselogic = new CourseLogic();
        }
        
        //Get
        public override Task<CourseReply> GetCourse(CourseIdRequest request, ServerCallContext context)
        {
           Course poco = _Courselogic.Get(request.CourseID);
            

            return Task.FromResult<CourseReply>(FromPoco(poco));
        }

        //GetAll
        public override Task<Courses> GetCourses(Empty request, ServerCallContext context)
        {
           Courses collectionofcourses = new Courses();
            List<SchoolAPI.Models.Course> pocos = _Courselogic.GetAll();
            foreach (Course poco in pocos)
            {
                collectionofcourses.Cour.Add(FromPoco(poco));
            }
            return Task.FromResult<Courses>(collectionofcourses);
        }
        //Add 

        public override Task<Empty> AddCourse(CourseReply request, ServerCallContext context)
        {
            Course poco = new Course()
            {
                CourseID = request.CourseID,
                CourseName = request.CourseName
            };
            _Courselogic.Post(poco);
            return Task.FromResult<Empty>(null);

        }
       
        private CourseReply FromPoco(Course poco)
        {
            return new CourseReply()
            {
                CourseID = poco.CourseID,
                CourseName = poco.CourseName.ToString()
            };
        }
        private Course ToPoco(CourseReply reply)
        {
            return new Course()
            {
                CourseID = reply.CourseID,
                CourseName = reply.CourseName.ToString()
            };
        }

    }
}
