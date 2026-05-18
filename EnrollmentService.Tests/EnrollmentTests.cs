using EnrollmentService.Api.Controllers;
using EnrollmentService.Api.Data;
using EnrollmentService.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Tests;

public class EnrollmentTests
{
    private EnrollmentDbContext CreateTestDbContext()
    {
        var options = new DbContextOptionsBuilder<EnrollmentDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new EnrollmentDbContext(options);
    }

    [Fact]
    public async Task CreateEnrollment_ShouldReturnCreated()
    {
        // Arrange
        using var context = CreateTestDbContext();
        var controller = new EnrollmentsController(context);

        var request = new CreateEnrollmentDto
        {
            CourseId = 1,
            StudentId = "student-1"
        };

        // Act
        var result = await controller.CreateEnrollment(request);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public async Task CreateEnrollment_WithSameStudentAndCourse_ShouldReturnBadRequest()
    {
        // Arrange
        using var context = CreateTestDbContext();
        var controller = new EnrollmentsController(context);

        var request = new CreateEnrollmentDto
        {
            CourseId = 2,
            StudentId = "student-2"
        };

        // Act
        await controller.CreateEnrollment(request);
        var secondResult = await controller.CreateEnrollment(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(secondResult);
    }
}