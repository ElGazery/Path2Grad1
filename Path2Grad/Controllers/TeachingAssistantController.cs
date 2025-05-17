using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Path2Grad.Dtos;
using Path2Grad.Helper;
using Path2Grad.Models;

namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeachingAssistantController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TeachingAssistantController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Profile")]
        public IActionResult GetProfile()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var TeachingAssistant = _context.Supervisors.FirstOrDefault(d => d.SupervisorEmail == email);
            return Ok(TeachingAssistant);

        }
        // the point is to delete the tracking from the teaching asstiant 
        [HttpGet("Projcets")]
        public IActionResult GetProjects()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var TeachingAssistant = _context.Supervisors.FirstOrDefault(e => e.SupervisorEmail == email);
            var Projects = _context.Projects.Include(e => e.Students).
                                             ThenInclude(e => e.Supervisors).
                                             Where(e => e.ProjectId == TeachingAssistant.ProjectId).
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
                                                 TeachingAssistant = p.Supervisors.Where(t => t.Position == "Doctor").Select(t => new
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
        [HttpGet("ProjectFiles")]
        public IActionResult GetProjectFiles()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var TeachingAssistant = _context.Supervisors.FirstOrDefault(e => e.SupervisorEmail == email);
            var projectfiles = _context.ProjectFiles.Where(p => p.ProjectId == TeachingAssistant.ProjectId).Select(t => new
            {
                t.FileName,
                t.FileContent
            }).ToList();
            return Ok(projectfiles);
        }
    }
}
