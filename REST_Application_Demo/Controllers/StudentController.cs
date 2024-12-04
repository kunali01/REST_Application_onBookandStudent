using Microsoft.AspNetCore.Mvc;
using REST_Application_Demo.Models;
using REST_Application_Demo.Services;

namespace REST_Application_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/Student/GetStudents
        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _service.GetStudents();
                if (students != null && students.Any())
                {
                    return Ok(students);  // Return 200 OK with students list
                }
                return NoContent();  // Return 204 No Content if no students found
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);  // Return 500 Internal Server Error in case of an exception
            }
        }

        // GET: api/Student/GetStudentById/{id}
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _service.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);  // Return 200 OK with the student data
                }
                return NotFound($"Student with ID {id} not found.");  // Return 404 Not Found if student does not exist
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);  // Return 500 Internal Server Error in case of an exception
            }
        }

        // POST: api/Student/AddStudent
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                _service.AddStudent(student);  // Call AddStudent in service
                return StatusCode(StatusCodes.Status201Created);  // Return 201 Created if student is added successfully
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);  // Return 500 Internal Server Error in case of an exception
            }
        }

        // PUT: api/Student/UpdateStudent
        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            try
            {
                _service.UpdateStudent(student);  // Call UpdateStudent in service
                return Ok("Student updated successfully.");  // Return 200 OK if student is updated successfully
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);  // Return 500 Internal Server Error in case of an exception
            }
        }

        // DELETE: api/Student/DeleteStudent/{id}
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _service.DeleteStudent(id);  // Call DeleteStudent in service
                return Ok("Student deleted successfully.");  // Return 200 OK if student is deleted successfully
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);  // Return 500 Internal Server Error in case of an exception
            }
        }
    }
}
