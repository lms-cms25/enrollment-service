using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Api.Dtos;

public class CreateEnrollmentDto
{
    [Required]
    public string StudentId { get; set; } = string.Empty;

    [Required]
    public int ProgramId { get; set; }
}