using System.ComponentModel.DataAnnotations;

namespace Path2Grad.Dtos
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }
    }
}
