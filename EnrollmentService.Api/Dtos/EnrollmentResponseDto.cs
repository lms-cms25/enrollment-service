namespace EnrollmentService.Api.Dtos;

public class EnrollmentResponseDto
{
    public int Id { get; set; }

    public string StudentId { get; set; } = string.Empty;

    public int ProgramId { get; set; }

    public DateTime EnrolledAt { get; set; }

    public string Status { get; set; } = string.Empty;
}