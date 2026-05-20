# Azure Deployment

## Enrollment Service API

Azure App Service:

https://enrollment-service-api-vita-geajcyhkhdamdqb7.swedencentral-01.azurewebsites.net

Swagger:

https://enrollment-service-api-vita-geajcyhkhdamdqb7.swedencentral-01.azurewebsites.net/swagger/index.html


# Enrollment Service

Microservice for managing student enrollments in programs for the Shiko LMS platform.

---

# Overview

Enrollment Service is responsible for handling student registrations in LMS programs.

The service follows a program-based enrollment structure similar to Nackademin LMS architecture, where:

- students enroll into programs
- programs contain multiple courses
- courses are connected to programs

Example:

.NET Webbutvecklare Program
- ASP.NET 1
- ASP.NET 2
- Databases
- Affärsmannaskap

Students are enrolled into the program instead of individual courses.

---

# Features

- Create enrollment
- Get all enrollments
- Get enrollment by id
- Delete enrollment
- Prevent duplicate enrollments
- Program-based enrollment architecture
- Swagger API documentation
- Azure SQL Database integration
- Entity Framework Core
- REST API architecture
- Azure deployment

---

# Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / Azure SQL
- Swagger / OpenAPI
- Azure App Service
- Docker
- xUnit

---

# API Endpoints

## Get All Enrollments

```http
GET /api/enrollments
