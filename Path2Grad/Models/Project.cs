using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Path2Grad.Models;

public partial class Project
{
    [Key]
    [Column("ProjectID")]
    public int ProjectId { get; set; }

    [StringLength(255)]
    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public int NumberOfTeam { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProjectField> ProjectFields { get; set; } = new List<ProjectField>();


    [JsonIgnore]
    [InverseProperty("Project")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    [JsonIgnore]
    [InverseProperty("Project")]
    public virtual ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();
    [JsonIgnore]
    [InverseProperty("Project")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    [JsonIgnore]
    [InverseProperty("Project")]
    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    [JsonIgnore]
    [InverseProperty("Project")]
    public ICollection<ProjectRequirement> Requirements { get; set; }
    [JsonIgnore]
    [InverseProperty("Project")]
    public ICollection<ProjectFile> projectFiles { get; set; }

}
