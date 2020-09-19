using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using School.gRPC.Protos;
using SchoolAPI.Controllers;
using SchoolAPI.Models;
using SchoolLogic;
using static School.gRPC.Protos.StudentCourse;
using Student = SchoolAPI.Models.StudentCourse;

namespace School.gRPC.Services
{
    public class StudentCourseService : StudentCourseBase
    {
        private StudentCourseLogic _studentcourselogic;
        public StudentCourseService()
        {
            _studentcourselogic = new StudentCourseLogic();
        }
        public override Task<Empty> AddStudentCourse(StudentCourseReply request, ServerCallContext context)
        {
            return base.AddStudentCourse(request, context);
        }
        public override Task<StudentCourseReply> GetStudentCourse(StudentCourseIdRequest request, ServerCallContext context)
        {
            return base.GetStudentCourse(request, context);
        }
        public override Task<StudentCourses> GetStudentCourses(Empty request, ServerCallContext context)
        {
            return base.GetStudentCourses(request, context);
        }
        private StudentCourseReply FromPoco(SchoolAPI.Models.StudentCourse poco)
        {
            return new StudentCourseReply()
            {
                 CourseID = poco.CourseID,
                  StudentCourseID = poco.StudentCourseID,
                  StudentID = poco.StudentID
                 
            };
        }
        private Student ToPoco(StudentCourseReply reply)
        {
            return new Student()
            {
                CourseID = reply.CourseID,
                StudentCourseID = reply.StudentCourseID,
                StudentID = reply.StudentID
            };
        }
    }
}
