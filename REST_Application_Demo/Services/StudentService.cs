using REST_Application_Demo.Models;
using REST_Application_Demo.Repositories;
using System.Collections.Generic;

namespace REST_Application_Demo.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        // Constructor to inject the repository
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        // Implementation of GetStudents method
        public List<Student> GetStudents()
        {
            return _repository.GetStudents();
        }

        // Implementation of GetStudentById method
        public Student GetStudentById(int id)
        {
            return _repository.GetStudentById(id);
        }

        // Implementation of AddStudent method
        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }

        // Implementation of UpdateStudent method
        public void UpdateStudent(Student student)
        {
            _repository.UpdateStudent(student);
        }

        // Implementation of DeleteStudent method
        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}
