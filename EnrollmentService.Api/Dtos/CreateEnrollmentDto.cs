namespace EnrollmentService.Api.Dtos;

public class CreateEnrollmentDto
{
    public int CourseId { get; set; }

    public string StudentId { get; set; } = string.Empty;
}