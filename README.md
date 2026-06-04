IncidentLog

A professional ASP.NET Core Web API for managing investigation reports, incidents, evidence, and case discussions.

Overview

IncidentLog is a backend-focused project designed to simulate a real-world incident management platform. It allows investigators to create reports, attach evidence, discuss findings through comments, search and filter incidents, and manage access through authentication.

The project was built to practice modern backend development using ASP.NET Core, Entity Framework Core, PostgreSQL, JWT authentication, and clean architecture principles.

Features
Incident Management
Create incidents
View incident details
Update incident information
Delete incidents
Track incident status and severity
Evidence Management
Attach evidence to incidents
Store evidence URLs
Add evidence descriptions
Retrieve all evidence related to an incident
Comment System
Add comments to incidents
Retrieve discussion history
Support collaborative investigation workflows
Search & Filtering
Filter incidents by:
Status
Severity
Category
Search incidents by title or description
Pagination
Retrieve incidents in pages
Custom page size support
Efficient large dataset handling
Authentication
User registration
Secure password hashing with BCrypt
User login
JWT token generation
Protected endpoints using authorization
Technologies Used
ASP.NET Core
C#
Entity Framework Core
PostgreSQL
JWT Authentication
BCrypt
Swagger / OpenAPI
LINQ
Project Structure
IncidentLog
│
├── Controllers
│   ├── AuthController
│   ├── IncidentController
│   ├── CommentController
│   └── EvidenceController
│
├── DTOs
│   ├── Auth
│   ├── Incident
│   ├── Comment
│   ├── Evidence
│   └── Common
│
├── Models
│   ├── User
│   ├── Incident
│   ├── Comment
│   └── Evidence
│
├── Interfaces
│
├── Services
│
├── Data
│
└── Migrations
API Endpoints
Authentication
Method	Endpoint
POST	/api/auth/register
POST	/api/auth/login
Incidents
Method	Endpoint
GET	/api/incidents
GET	/api/incidents/{id}
POST	/api/incidents
PUT	/api/incidents/{id}
DELETE	/api/incidents/{id}
Filtering
Method	Endpoint
GET	/api/incidents/filter

Example:

GET /api/incidents/filter?status=1&severity=3
Search
GET /api/incidents/search?term=forest
Pagination
GET /api/incidents/paged?page=1&pageSize=10
Comments
GET /api/incidents/{incidentId}/comments
POST /api/incidents/{incidentId}/comments
Evidence
GET /api/incidents/{incidentId}/evidences
POST /api/incidents/{incidentId}/evidences
Getting Started
Clone the repository
git clone https://github.com/yourusername/IncidentLog.git
cd IncidentLog
Configure PostgreSQL

Update your connection string in:

appsettings.json

Example:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=IncidentLog;Username=postgres;Password=yourpassword"
  }
}
Apply Migrations
dotnet ef database update
Run the Application
dotnet run

Swagger will be available at:

https://localhost:5001/swagger
Authentication Example
Register
{
  "username": "investigator",
  "password": "StrongPassword123"
}
Login
{
  "username": "investigator",
  "password": "StrongPassword123"
}

Response:

{
  "token": "eyJhbGciOi..."
}

Use the token inside Swagger:

Bearer eyJhbGciOi...
Learning Objectives

This project focuses on:

REST API development
Entity Framework Core
Database relationships
Dependency Injection
DTO pattern
Service layer architecture
JWT authentication
Password hashing
Filtering and pagination
PostgreSQL integration
Future Improvements
Role-based authorization
File uploads for evidence
Case assignment system
Audit logs
Dashboard analytics
Soft delete support
Unit and integration tests
Docker support
License

This project is intended for educational and portfolio purposes.
