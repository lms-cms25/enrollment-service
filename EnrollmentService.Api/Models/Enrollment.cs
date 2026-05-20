namespace EnrollmentService.Api.Models;

public class Enrollment
{
    public int Id { get; set; }

    // Student/User som är registrerad
    public string StudentId { get; set; } = string.Empty;

    // Program som studenten går
    public int ProgramId { get; set; }

    // Datum när studenten registrerades
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    // Enrollment status
    public string Status { get; set; } = "Active";
}