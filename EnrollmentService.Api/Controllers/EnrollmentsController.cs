using EnrollmentService.Api.Data;
using EnrollmentService.Api.Dtos;
using EnrollmentService.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly EnrollmentDbContext _context;

    public EnrollmentsController(EnrollmentDbContext context)
    {
        _context = context;
    }

    // Hämtar alla enrollments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentResponseDto>>> GetEnrollments()
    {
        var enrollments = await _context.Enrollments
            .Select(e => new EnrollmentResponseDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                ProgramId = e.ProgramId,
                EnrolledAt = e.EnrolledAt,
                Status = e.Status
            })
            .ToListAsync();

        return Ok(enrollments);
    }

    // Hämtar enrollment med id
    [HttpGet("{id}")]
    public async Task<ActionResult<EnrollmentResponseDto>> GetEnrollment(int id)
    {
        var enrollment = await _context.Enrollments
            .FirstOrDefaultAsync(e => e.Id == id);

        if (enrollment == null)
            return NotFound();

        return Ok(new EnrollmentResponseDto
        {
            Id = enrollment.Id,
            StudentId = enrollment.StudentId,
            ProgramId = enrollment.ProgramId,
            EnrolledAt = enrollment.EnrolledAt,
            Status = enrollment.Status
        });
    }

    // Registrerar student till program
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<EnrollmentResponseDto>> CreateEnrollment(CreateEnrollmentDto request)
    {
        var alreadyExists = await _context.Enrollments
            .AnyAsync(e =>
                e.StudentId == request.StudentId &&
                e.ProgramId == request.ProgramId);

        if (alreadyExists)
        {
            return BadRequest(new
            {
                message = "Student is already enrolled in this program."
            });
        }

        var enrollment = new Enrollment
        {
            StudentId = request.StudentId,
            ProgramId = request.ProgramId
        };

        _context.Enrollments.Add(enrollment);

        await _context.SaveChangesAsync();

        return Ok(new EnrollmentResponseDto
        {
            Id = enrollment.Id,
            StudentId = enrollment.StudentId,
            ProgramId = enrollment.ProgramId,
            EnrolledAt = enrollment.EnrolledAt,
            Status = enrollment.Status
        });
    }

    // Tar bort enrollment
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollments
            .FirstOrDefaultAsync(e => e.Id == id);

        if (enrollment == null)
            return NotFound();

        _context.Enrollments.Remove(enrollment);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}