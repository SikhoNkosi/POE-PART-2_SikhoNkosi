# POE-PART-2_SikhoNkosi
# RaceDay API

RaceDay is a RESTful API for managing South African road running, walking and cycling events. Organisers create events and categories and capture results. Participants browse events, enter a category, and view their own enrolments and results.

This is Part 2 of the PROG6212 Portfolio of Evidence. It implements the endpoint plan from Part 1.

## Tech stack

- ASP.NET Core Web API (.NET 10) using controllers
- Entity Framework Core, Code-First, with SQL Server (LocalDB)
- Server-side session authentication with role-based access
- Passwords hashed with BCrypt
- Swagger UI (Swashbuckle) for browsing and testing every endpoint
- xUnit tests using WebApplicationFactory and an in-memory database
- GitHub Actions for continuous integration

## Project structure

- `RaceDay.API.slnx` - the Visual Studio solution
- `RaceDay.API/` - the Web API project
  - `Controllers/` - Auth, Users, Events, Categories, Enrolments and Results controllers
  - `Migrations/` - EF Core migrations that create the database
  - `Models.cs` - the six entity classes (User, Event, Category, Enrolment, Result, Payment)
  - `DTOs.cs` - request and response objects
  - `RaceDayContext.cs` - the EF Core database context and relationships
  - `SessionAuthenticationHandler.cs` - reads the logged-in user from the server-side session
  - `Program.cs` - application setup
- `RaceDay.API.Tests/` - the unit tests
- `.github/workflows/ci.yml` - the CI workflow
