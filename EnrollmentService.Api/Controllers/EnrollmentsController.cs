using EnrollmentService.Api.Data;
using EnrollmentService.Api.Dtos;
using EnrollmentService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Api.Controllers;

[ApiController]
[Route("api/enrollments")]
public class EnrollmentsController : ControllerBase
{
    private readonly EnrollmentDbContext _context;

    public EnrollmentsController(EnrollmentDbContext context)
    {
        _context = context;
    }

    // Skapar en ny enrollment
    [HttpPost]
    public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentDto request)
    {
        if (request.CourseId <= 0 || string.IsNullOrWhiteSpace(request.StudentId))
        {
            return BadRequest(new
            {
                message = "CourseId and StudentId are required"
            });
        }

        // Kontrollera om studenten redan är registrerad på samma kurs
        var existingEnrollment = await _context.Enrollments
            .FirstOrDefaultAsync(e =>
                e.StudentId == request.StudentId &&
                e.CourseId == request.CourseId);

        if (existingEnrollment != null)
        {
            return BadRequest("Student is already enrolled in this course.");
        }

        var enrollment = new Enrollment
        {
            CourseId = request.CourseId,
            StudentId = request.StudentId,
            EnrolledAt = DateTime.UtcNow
        };

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateEnrollment), new { id = enrollment.Id }, enrollment);
    }

    // Hämta alla enrollments för en student
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetStudentEnrollments(string studentId)
    {
        var enrollments = await _context.Enrollments
            .Where(e => e.StudentId == studentId)
            .ToListAsync();

        return Ok(enrollments);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllEnrollments()
    {
        var enrollments = await _context.Enrollments.ToListAsync();

        return Ok(enrollments);
    }

    // Ta bort enrollment
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);

        if (enrollment == null)
        {
            return NotFound();
        }

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}