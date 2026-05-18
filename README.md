# Enrollment Service

Microservice for managing student course enrollments in Shiko LMS.

## Deployed API

Swagger:
https://enrollment-service-api-vita-geajcyhkhdamdqb7.swedencentral-01.azurewebsites.net/swagger/index.html

## Azure Deployment

Status: Successfully deployed to Azure App Service

## Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- Azure App Service

# enrollment-service
Microservice for managing student course enrollments in Shiko LMS
 # Enrollment Service

Enrollment Service is a microservice for managing student course enrollments in the LMS platform.

## Features

- Create enrollment
- Get student enrollments
- Delete enrollment
- Prevent duplicate enrollments
- Admin get all enrollments
- Swagger API documentation
- Azure SQL Database integration
- Entity Framework Core
- REST API architecture

---

## Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / Azure SQL
- Swagger
- Docker 
- xUnit 

---

## API Endpoints

### Create Enrollment

```http
POST /api/enrollments

Get Student Enrollments
GET /api/enrollments/student/{studentId}
Get All Enrollments
GET /api/enrollments
Delete Enrollment
DELETE /api/enrollments/{id}
Architecture

The service uses a layered structure with:

Controllers
DTOs
Models
DbContext

The service communicates through REST API and stores data in Azure SQL Database.

Security

The service is prepared for JWT Authentication and Authorization integration.

Testing

The project includes testing for:

API functionality
CRUD operations
Enrollment service logic

Author

Vitaliia Sivakova
