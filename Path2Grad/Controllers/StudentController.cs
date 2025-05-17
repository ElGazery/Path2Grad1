using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Path2Grad.Models;
using Path2Grad.Dtos;
using System.Threading.Tasks;
using System.Security.Claims;
using Path2Grad.Helper;
using Azure.Core;
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
            var CVs = _context.Cvs.Where(e => e.Type == "Templet").ToList();
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
                Name = e.InternshipName,
                Link = e.InternshipLink
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
                WorkFile = PDF,
                StudentId = student.StudentId

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
                StudentId = student.StudentId
            };
            _context.InternshipCertificates.Add(file1);
            _context.SaveChanges();

            return Ok(file1);
        }

        [HttpGet("WorkFiles")]
        public IActionResult GetWorkFile()
        {
            var student = GetCurrentStudent();
            var Files = _context.InternshipWorkFiles.Where(e => e.StudentId == student.StudentId)
                .Select(e => new
                {
                    e.WorkFile,
                    e.InternshipWorkFilesId
                }
                );
            return Ok(Files);
        }



        [HttpGet("UploadCertificates")]
        public IActionResult GetCertificate()
        {
            var student = GetCurrentStudent();
            var Files = _context.InternshipCertificates.Where(e => e.StudentId == student.StudentId)
                .Select(e => new
                {
                    e.InternshipCertificatesId,
                    e.Certificate

                }
                );
            return Ok(Files);


        }

        [HttpPost("AddTrack")]
        public IActionResult PostTrack(AddTrackDto addTrackDto)
        {
            var student = GetCurrentStudent();

            var track = _context.Tracks.FirstOrDefault(e => e.TrackName == addTrackDto.TrackName);
            if (track == null)
                return NotFound("Track not found");
            student.TrackId = track.TrackId;
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);




        }
        [HttpGet("Track")]
        public IActionResult GetTrack()
        {
            var student = GetCurrentStudent();
            if (student.TrackId is null)
            {
                return BadRequest("Enroll in a track ");
            }

            var tracks = _context.Tracks
                         .Where(e=>e.TrackId==student.TrackId)
                         .Include(t => t.Items)
                         .ThenInclude(i => i.ItemLessons)
                         .Select(t => new
                                {
                                 TrackName = t.TrackName,
                                 Items = t.Items.Select(i => new
                                        {
                                          ItemName = i.Name,
                                           Lessons = i.ItemLessons.Select(l => new
                                                    {
                                                       LessonName = l.Name,
                                                       IsComplet = l.IsComplet
                                           }).ToList()
                                 }).ToList()
                          }).ToList();




            return Ok(tracks);
        }

        [HttpGet("LessonRate")]
        public IActionResult GetRate()
        {
            var student = GetCurrentStudent();


            var totalLessons = _context.TrackItem
                             .Where(e => e.TrackId == student.TrackId)
                             .SelectMany(e => e.ItemLessons)
                             .Count();

            var completedLessons = _context.TrackItem
                .Where(e => e.TrackId == student.TrackId)
                .SelectMany(e => e.ItemLessons)
                .Count(lesson => lesson.IsComplet == true);
            double percentComplete = (double)completedLessons / totalLessons * 100;

            return Ok(new { Message = "Lesson updated", PercentComplete = percentComplete });
        }

        [HttpPut("UpdateLessonStatus")]
        public async Task<IActionResult> UpdateLessonStatus([FromBody] LessonUpdateDto model)
        {
            var student = GetCurrentStudent();

            var lesson = await _context.TrackItem
                .Where(e => e.TrackId == student.TrackId)
                .SelectMany(e => e.ItemLessons)
                .FirstOrDefaultAsync(l => l.Id == model.LessonId);

                lesson.IsComplet = model.IsComplet;

            await _context.SaveChangesAsync();

            return Ok(new { Message = "Lesson updated successfully" });
        }

        [HttpGet("ProjectBank")]
        public IActionResult GetProjects()
        {
            var projects = _context.ProjectsBanks.Select(e => new
            {
                ProjectId=e.ProjectBankId,
                ProjectName=e.ProjectName,
                ProjectDescripition=e.Description


            }).ToList();
            return Ok(projects);
        }
        [HttpGet("ProjectBank/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _context.ProjectsBanks.Where(e => e.ProjectBankId == id).Select(e => new
            {
                ProjectId = e.ProjectBankId,
                ProjectName = e.ProjectName,
                ProjectDescripition = e.Description,
                e.ProjectSpecification,
                projectFields = e.ProjectsBankProjectFields.Where(p => p.ProjectFieldId == id).Select(p => new
                {
                    p.ProjectFieldId,
                    p.ProjectField
                }).ToList()

            }).ToList();
            if(project is null )
            {
                return BadRequest("please enter vaild id !!");
            }
            return Ok(project);
        }
        [HttpPost("CustomizeProject")]
        public IActionResult PostProject(ProjectDto projectDto)
        {
            var student = GetCurrentStudent();
            Project project = new Project()
            {
                ProjectName = projectDto.ProjectName,
                Description=projectDto.Description,
                NumberOfTeam=projectDto.NumberOfTeam,
                
                
            };
            _context.Projects.Add(project);
            _context.SaveChanges();

            var fieldNames = projectDto.Fields.Select(f => f.FieldName).ToList();

            var fields = _context.Fields
                .Where(f => fieldNames.Contains(f.FieldName))
                .ToList();

            var projectFields = fields.Select(field => new ProjectField
            {
                ProjectId = project.ProjectId,
                FieldId = field.FieldId
            }).ToList();
            student.ProjectId = project.ProjectId;
            _context.ProjectFields.AddRange(projectFields);
            _context.SaveChanges();
             return Ok("Project Created successfully .. Start to add supervisors and students ");

        }
        [HttpPost("StudentRequest")]
        public IActionResult SendProjectRquest(RequestDto requestDto)
        {
            var student = GetCurrentStudent();
           StudentProjectJoinRequest studentProjectJoinRequest = new StudentProjectJoinRequest()
            {
                SenderId=student.StudentId,
                StudentId=requestDto.ReceiverId,
                ProjectId=student.ProjectId
            };
            _context.Add(studentProjectJoinRequest);
            _context.SaveChanges();
            return Ok("Request Send.. ");

        }

        [HttpGet("StudentRequest")]
        public IActionResult GetProjectRquest()
        {
            var student = GetCurrentStudent();
            if(student.ProjectId!=null)
            {
                return Ok("You are join in project .. ");
            }
            var AllRequests = _context.StudentProjectJoinRequests.Where(e => e.StudentId == student.StudentId)
                .Select(e => new
                {
                    Requestid=e.RequestId,
                    SenderPic = e.Sender.Pic,
                    SenderName =e.Sender.StudentName,
                    ProjectName =e.Project.ProjectName
                })
                .ToList();

            return Ok(AllRequests);

        }
        [HttpPost("StatusRequest")]
        public IActionResult StatusRequest(StatusRequestDto statusRequestDto)
        {
            var student = GetCurrentStudent();
            var request = _context.StudentProjectJoinRequests.FirstOrDefault(e => e.RequestId == statusRequestDto.RequestId);
            if (request == null)
                return NotFound("Request not found.");
            if (statusRequestDto.Status=="Remove")
            {
               
                _context.StudentProjectJoinRequests.Remove(request);

            }else if(statusRequestDto.Status=="Accept")
            {
                student.ProjectId = request.ProjectId;

            }else
            {
                return NotFound("Status not correct");
            }
            _context.SaveChanges();
            return Ok(student);
        }


        [HttpGet("Project")]
        public IActionResult GetProject()
        {
            var student = GetCurrentStudent();

            var project = _context.Projects
                .Include(p => p.Requirements)
                .Include(p => p.Tasks)
                .Include(p => p.projectFiles) 
                .Where(p => p.ProjectId == student.ProjectId)
                .Select(p => new
                {
                    ProjectRequirements = p.Requirements.Select(x => new
                    {
                        RequirementName = x.RequirementName,
                        Pdf = x.PdfContent
                    }).ToList(),

                    ProjectFiles = p.projectFiles.Select(f => new
                    {
                        FileName = f.FileName,          
                        FileContent = f.FileContent     
                    }).ToList(),

                    ProjectTasks = p.Tasks.Select(t => new
                    {
                        TaskName = t.TaskName,
                        AssignedToName = t.Student.StudentName,
                        AssignedToPic = t.Student.Pic,
                        Deadline = t.Deadline,
                        Status = t.Status
                    }).ToList()
                })
                .FirstOrDefault();

            if (project == null)
                return NotFound("Project not found.");

            return Ok(project);
        }
        [HttpPost("AddTask")]
        public IActionResult AddTask(AddTaskDto addTaskDto)
        {
            var student = GetCurrentStudent();
            ProjectTask projecttask = new ProjectTask()
            {
                TaskName=addTaskDto.TaskName,
                StudentId=addTaskDto.StudentId,
                ProjectId=addTaskDto.ProjectId,
                Deadline=addTaskDto.Deadline

             };
            _context.Add(projecttask);
            _context.SaveChanges();
            return Ok(projecttask);
        }

        [HttpPost("UploadFile")]
        public IActionResult PostProjectfiles(ProjectFileDto file)
        {
            var student = GetCurrentStudent();
            var PDF = IFormToByteHelper.ConvertToBytes(file.File);
            ProjectFile projectFile = new ProjectFile()
            {
                FileContent=PDF,
                ProjectId=file.ProjectId

            };
            _context.Add(projectFile);
            _context.SaveChanges();

            return Ok(file.File);
        }
    }
}
