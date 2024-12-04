using REST_Application_Demo.Models;
using System.Collections.Generic;

namespace REST_Application_Demo.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
