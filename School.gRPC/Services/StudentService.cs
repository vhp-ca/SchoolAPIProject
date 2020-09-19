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
using static School.gRPC.Protos.Student;
using Student = SchoolAPI.Models.Student;

namespace School.gRPC.Services
{
    public class StudentService : StudentBase
    {
        private StudentLogic _studentlogic;
        public StudentService()
        {
            _studentlogic = new StudentLogic();
        }
        //Get
        public override Task<StudentReply> GetStudent(IdRequest request, ServerCallContext context)
        {
            SchoolAPI.Models.Student poco = _studentlogic.Get(request.StudentID);

            return Task.FromResult<StudentReply>(FromPoco(poco));
                      
        }
        //GetAll
        public override Task<Students> GetStudents(Empty request, ServerCallContext context)
        {
            
            Students collectionofstudents = new Students();
            List<Student> pocos = _studentlogic.GetAll();
            foreach(Student poco in pocos)
            {
                collectionofstudents.Stu.Add(FromPoco(poco));
            }
            return Task.FromResult<Students>(collectionofstudents);
        }
        //Add 

        public override Task<Empty> AddStudent(StudentReply request, ServerCallContext context)
        {
            Student studentPoco = new Student()
            {
                StudentID = request.StudentID,
                Name = request.Name
            };
            _studentlogic.Post(studentPoco);
            return Task.FromResult<Empty>(null);

        }
              
        private  StudentReply FromPoco (SchoolAPI.Models.Student poco)
        {
            return new StudentReply()
            {
                StudentID = poco.StudentID,
                Name = poco.Name.ToString()
            };
        }
        private Student ToPoco(StudentReply reply)
        {
            return new Student()
            {
                StudentID = reply.StudentID,
                Name = reply.Name.ToString()
            };
        }

    }
}
