using EnrollmentService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Api.Data;

public class EnrollmentDbContext : DbContext
{
    public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
}