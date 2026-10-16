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

## Setup

Requirements: Visual Studio with the ASP.NET workload, the .NET 10 SDK, and SQL Server LocalDB (installed with Visual Studio).

1. Clone this repository.
2. Open `RaceDay.API.slnx` in Visual Studio.
3. Check the connection string in `RaceDay.API/appsettings.json`. The default uses LocalDB: `Server=(localdb)\mssqllocaldb;Database=RaceDayDB;...`
4. Open Tools > NuGet Package Manager > Package Manager Console, set Default project to `RaceDay.API`, and run: `Update-Database`. The migrations are already included, so this creates the RaceDayDB database and all six tables.

## Running the API

Press F5 in Visual Studio, or from the `RaceDay.API` folder run: `dotnet run --launch-profile https`

Then open `https://localhost:7083/swagger` in your browser. Every endpoint is listed with a description, the input it expects and the responses it can return.

To try it out:
1. Call `POST /api/auth/register` to create an Organiser or a Participant.
2. Call `POST /api/auth/login` with the same email and password. The server now remembers you.
3. Call any protected endpoint. No extra token is needed.
4. Call `POST /api/auth/logout` to end the session.

Sessions are kept in the API's memory, so restarting the API logs everyone out.
