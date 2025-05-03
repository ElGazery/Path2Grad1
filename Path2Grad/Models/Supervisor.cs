using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Path2Grad.Models;

[Index("ProjectId", Name = "IX_Supervisors_ProjectId")]
[Index("SupervisorEmail", Name = "UQ__Supervis__FAB2DC03A7DD1066", IsUnique = true)]
public partial class Supervisor
{
    [Key]
    [Column("SupervisorID")]
    public int SupervisorId { get; set; }

    [StringLength(255)]
    public string SupervisorName { get; set; } = null!;

    [StringLength(255)]
    public string SupervisorEmail { get; set; } = null!;

    [StringLength(255)]
    public string SupervisorPassword { get; set; } = null!;

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(255)]
    public string Position { get; set; } = null!;

    [StringLength(255)]
    public string Specialization { get; set; } = null!;

    public byte[]? Pic { get; set; }

    public int? ProjectId { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("Supervisors")]
    public virtual Project? Project { get; set; }

    [ForeignKey("SupervisorId")]
    [InverseProperty("Supervisors")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
