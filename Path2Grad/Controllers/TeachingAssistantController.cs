using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("Data")]
        public async Task<IActionResult> Get()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("User is not authenticated");
            }
            var doctor = await _context.Supervisors.FirstOrDefaultAsync(d => d.SupervisorEmail == email);

            return Ok(doctor);

        }
    }
}
