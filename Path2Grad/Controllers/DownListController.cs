using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Path2Grad.Models;

namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DownListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ProjectField")]
         public IActionResult GetProjectField()
        {
            var Fields = _context.Fields.Distinct().ToList();
            return Ok(Fields);
        }

        [HttpGet("Supervisor")]
        public IActionResult GetSupervisor()
        {
            var supervisors = _context.Supervisors.Where(e=>e.Position=="Doctor").Select(s => new
            {
                s.SupervisorId,
                s.SupervisorName,
                s.Pic,
                s.Specialization
            }).ToList();
            return Ok(supervisors);
        }
        [HttpGet("CoSupervisor")]
        public IActionResult GetCo_Supervisor()
        {
            var supervisors = _context.Supervisors.Where(e => e.Position == "TeachingAssistant").Select(s => new
            {
                s.SupervisorId,
                s.SupervisorName,
                s.Pic,
                s.Specialization
            }).ToList();
            return Ok(supervisors);
        }
        [HttpGet("Student/{trackName}")]
        public IActionResult GetStudentByTrack(string trackName)
        {
            var Students = _context.Students.Where(s => s.Track.TrackName == trackName).Select(e => new
            {
                e.StudentId,
                e.StudentName,
                track=e.Track.TrackName,
                e.Pic
            }).ToList();
            return Ok(Students);

        }


    }
}
