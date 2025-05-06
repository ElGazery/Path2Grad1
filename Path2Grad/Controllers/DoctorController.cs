using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Path2Grad.Dtos;
using Path2Grad.Helper;
using Path2Grad.Models;
using System.Security.Claims;

namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Profile")]
        public IActionResult GetProfile()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var doctor = _context.Supervisors.FirstOrDefault(d => d.SupervisorEmail == email);
            return Ok(doctor);

        }
        [HttpGet("Projcets")]
        public IActionResult GetProjects()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var doctor = _context.Supervisors.FirstOrDefault(e => e.SupervisorEmail == email);
            var Projects = _context.Projects.Include(e => e.Students).
                                             ThenInclude(e => e.Supervisors).
                                             Where(e => e.ProjectId == doctor.ProjectId).
                                             Select(p => new
                                             {
                                                 p.ProjectId,
                                                 p.ProjectName,
                                                 p.Description,
                                                 students = p.Students.Select(s => new StudentDto
                                                 {
                                                     StudentId = s.StudentId,
                                                     StudentName = s.StudentName,
                                                     Pic = s.Pic
                                                 }).ToList(),
                                                 TeachingAssistant = p.Supervisors.Where(t => t.Position == "TeachingAssistant").Select(t => new
                                                 {
                                                     TeachingAssistanId = t.SupervisorId,
                                                     TeacahingAssistanName = t.SupervisorName,
                                                     TeachingAssistantPic = t.Pic
                                                 }).ToList()
                                             });
            return Ok(Projects);
        }

        [HttpGet("ProjcetById/{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _context.Projects.Include(e => e.Students).
                                            ThenInclude(s => s.Supervisors).
                                            Where(p => p.ProjectId == id)
                .Select(p => new
                {
                    p.ProjectId,
                    p.ProjectName,
                    p.ProjectFields,
                    p.NumberOfTeam,
                    student = p.Students.Select(s => new StudentDto
                    {
                        StudentId = s.StudentId,
                        StudentName = s.StudentName,
                        Pic = s.Pic
                    }).ToList(),
                    supervisor = p.Supervisors.Select(s => new SupervisorDto
                    {
                        SupervisorId = s.SupervisorId,
                        SupervisorName = s.SupervisorName,
                        Pic = s.Pic
                    }).ToList()

                });
            return Ok(project);
        }
        [HttpPost("Requirement")]
        public IActionResult PostRequirement([FromForm] ProjectRequirementCreateDto dto)
        {
            ProjectRequirement projectRequirement = ProjectRequirementHelper.ToEntity(dto);
            _context.ProjectRequirements.Add(projectRequirement);
            _context.SaveChanges();
            return Ok(projectRequirement);

        }
        // the last ting in the docotr controller is the get endpoint to get the project files from the student 



    }
}
