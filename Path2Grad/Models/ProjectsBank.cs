using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Path2Grad.Models;

[Table("ProjectsBank")]
[Index("AdminId", Name = "IX_ProjectsBank_AdminID")]
[Index("AdminId", Name = "UQ_ProjectsBank_AdminID", IsUnique = true)]
public partial class ProjectsBank
{
    [Key]
    [Column("ProjectBankID")]
    public int ProjectBankId { get; set; }

    [StringLength(255)]
    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Requirements { get; set; }

    [Column("AdminID")]
    public int AdminId { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("ProjectsBank")]
    public virtual ProjectsAdmin Admin { get; set; } = null!;

    [InverseProperty("ProjectBank")]
    public virtual ICollection<ProjectsBankProjectField> ProjectsBankProjectFields { get; set; } = new List<ProjectsBankProjectField>();
}
