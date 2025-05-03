﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Path2Grad.Models;

[Table("ProjectField")]
[Index("ProjectId", Name = "IX_ProjectField_ProjectID")]
public partial class ProjectField
{
    [Key]
    [Column("ProjectFieldID")]
    public int ProjectFieldId { get; set; }

    [Column("ProjectField")]
    [StringLength(255)]
    public string ProjectField1 { get; set; } = null!;

    [Column("ProjectID")]
    public int ProjectId { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectFields")]
    public virtual Project Project { get; set; } = null!;
}
