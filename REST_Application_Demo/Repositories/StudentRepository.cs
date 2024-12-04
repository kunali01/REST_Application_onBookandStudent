using Microsoft.EntityFrameworkCore;
using REST_Application_Demo.Data;
using REST_Application_Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace REST_Application_Demo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the database context
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get all students
        public List<Student> GetStudents()
        {
            return _context.Students.ToList();  // Fetch all students from the database
        }

        // Method to get a student by their ID
        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);  // Find the student by ID
        }

        // Method to add a new student
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);  // Add student to the DbSet
            _context.SaveChanges();          // Save the changes to the database
        }

        // Method to update an existing student
        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);  // Update the student entity
            _context.SaveChanges();              // Save changes to the database
        }

        // Method to delete a student by their ID
        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);  // Find student by ID
            if (student != null)
            {
                _context.Students.Remove(student);  // Remove the student from DbSet
                _context.SaveChanges();             // Save changes to the database
            }
        }
    }
}
