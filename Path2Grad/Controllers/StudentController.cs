using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Path2Grad.Models;
using Path2Grad.Dtos;
using System.Threading.Tasks;
using System.Security.Claims;
using Path2Grad.Helper;
namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]  
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        private Student GetCurrentStudent()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (email == null)
                return null;

            return _context.Students.FirstOrDefault(d => d.StudentEmail == email);
        }

        [HttpGet("Profile")]
        public IActionResult GetProfile()
        {
            var student = GetCurrentStudent();
            return Ok(student);

        }


        [HttpGet("CVTemplets")]
        public IActionResult GetAllCVTemplets()
        {
         var CVs=_context.Cvs.Where(e=>e.Type=="Templet").ToList();
            return Ok(CVs);
        
        }
        [HttpPost("AddStudentCV")]
        public IActionResult PostCv(IFormFile cv)
        {
              var student = GetCurrentStudent();
            var pdf = IFormToByteHelper.ConvertToBytes(cv);
            Cv StudetnCv = new Cv()
            {
                Cvfile = pdf,
                StudentId = student.StudentId,
                Type = "StudentCV",
                CVName = cv.FileName

            };
            _context.Cvs.Add(StudetnCv);
            _context.SaveChanges();
            return Ok(StudetnCv);

        }


        [HttpGet("Internship")]
        public IActionResult GetAllInternship()
        {
            var intern = _context.Internships.Select(e => new
            {
                Name=e.InternshipName,
                Link=e.InternshipLink
            }).ToList();
            return Ok(intern);
        }

        [HttpPost("WorkFiles")]
        public IActionResult PostWorkFile(IFormFile file)
        {
            var student = GetCurrentStudent();
            var PDF = IFormToByteHelper.ConvertToBytes(file);
            InternshipWorkFile file1 = new InternshipWorkFile()
            {
                WorkFile =PDF,
                StudentId=student.StudentId
                
             };
            _context.InternshipWorkFiles.Add(file1);
            _context.SaveChanges();

            return Ok(file1);
        }
        [HttpPost("Certificates")]
        public IActionResult PostCertificate(IFormFile file)
        {
            var student = GetCurrentStudent();
            var PDF = IFormToByteHelper.ConvertToBytes(file);
            InternshipCertificate file1 = new InternshipCertificate()
            {
                Certificate = PDF,
                StudentId=student.StudentId
            };
            _context.InternshipCertificates.Add(file1);
            _context.SaveChanges();

            return Ok(file1);
        }


    }
}
