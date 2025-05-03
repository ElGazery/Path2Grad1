using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Path2Grad.Models;

[Index("StudentId", Name = "IX_Tracks_StudentID", IsUnique = true)]
public partial class Track
{
    [Key]
    [Column("TrackID")]
    public int TrackId { get; set; }

    [StringLength(255)]
    public string TrackName { get; set; } = null!;

    [StringLength(255)]
    public string? Link { get; set; }

    public string? Description { get; set; }

    [Column("StudentID")]
    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Track")]
    public virtual Student Student { get; set; } = null!;
}
