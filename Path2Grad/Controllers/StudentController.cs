using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Path2Grad.Models;
using Path2Grad.Dtos;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]  // هذا يحدد أن أي مستخدم يجب أن يكون لديه دور "Student"
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<Student>> GetStudent()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("User is not authenticated");
            }
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentEmail == email);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }
    }
}
