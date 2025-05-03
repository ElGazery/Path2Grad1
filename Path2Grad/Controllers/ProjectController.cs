using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Path2Grad.Models;

namespace Path2Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult get(int id)
        {
            var projcet = _context.Projects.FirstOrDefault(e => e.ProjectId == id);
            return Ok(projcet);

        }
    }
}
