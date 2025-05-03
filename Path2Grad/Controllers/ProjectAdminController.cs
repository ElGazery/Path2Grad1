using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Path2Grad.Dtos;
using Path2Grad.Models;

namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectAdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Data")]
        public async Task<IActionResult> Get()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("User is not authenticated");
            }
            var doctor = await _context.ProjectsAdmins.FirstOrDefaultAsync(d => d.AdminEmail == email);

            return Ok(doctor);

        }
        [HttpGet("Projcets")]
        public IActionResult GetProjects()
        {
            var projects = _context.Projects
             .Include(p => p.Students)
             .ThenInclude(s => s.Supervisors)
             .Select(p => new
             {
                 ProjectId = p.ProjectId,
                 ProjectName = p.ProjectName,
                 Description = p.Description,
                 student = p.Students.Select(s => new StudentDto
                 {
                    StudentId=s.StudentId,
                    StudentName=s.StudentName,
                    Pic=s.Pic
                 }).ToList(),
                 supervisor = p.Supervisors.Select(s=>new SupervisorDto 
                 {
                     SupervisorId=s.SupervisorId,
                     SupervisorName=s.SupervisorName,
                     Pic=s.Pic
                 }).ToList()         
                                     
                 }).ToList() ;
           
        return Ok(projects);
        }
        [HttpGet("ProjcetById/{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _context.Projects.Include(e => e.Students).ThenInclude(s => s.Supervisors).Where(p=>p.ProjectId==id)
                .Select(p => new
                {
                    p.ProjectId,
                    p.ProjectName,
                    p.Description,
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

        [HttpGet("Profile")]
        public IActionResult GetProfile()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var admin = _context.ProjectsAdmins.FirstOrDefault(a => a.AdminEmail == email);
            return Ok(admin);
        }



    }
}
