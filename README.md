# Designli .NET Test

## Overview

This project was developed as part of a technical challenge with the objective of demonstrating the implementation of a clean, modular, and maintainable architecture using .NET 8, React, and in-memory data storage.  
The solution simulates a small HR-like system capable of managing employees and authenticating users through two mechanisms:

1. Manual JWT authentication  
2. (Optional) ASP.NET Identity-based authentication

Although no external database was required, the solution was structured to allow easy migration to persistent storage such as SQL Server if needed.

---

## Challenge Requirements

The challenge consisted of designing and implementing an API that could:

- Manage Employee data (CRUD operations)
- Authenticate users through a basic login flow
- Demonstrate clean architecture and best engineering practices
- Use in-memory data instead of a real database
- Include unit tests for critical components such as AuthService

---

## Architecture

The project follows a combination of Clean Architecture and Hexagonal Architecture principles. The solution is divided into the following layers:

### 1. Core (Domain Layer)

Purpose: Represents the business domain and contains the enterprise logic.

Includes:
- Domain entities (Employee, UserApp, etc.)
- Repository interfaces

This layer has no external dependencies.

### 2. Application Layer

Purpose: Contains the application logic and orchestrates use cases.

Includes:
- Services such as AuthService and EmployeeService
- DTOs for data transfer
- Mapping configuration using Mapster

This layer references only the Core layer.

### 3. Infrastructure Layer

Purpose: Implements external concerns such as data access, providers, and integrations.

Includes:
- In-memory repositories
- Seed data initialization
- JWT token generation
- Optional ASP.NET Identity configuration

Data is stored in static in-memory collections to simulate database tables.

### 4. Web API Layer

Purpose: Exposes HTTP endpoints for employee management and authentication.

Includes:
- Controllers
- Dependency injection configuration
- Authentication and JWT setup
- Swagger for API documentation

This layer is the entry point of the system.

---

## In-Memory Data Implementation

Since no database was required, all data is handled using static in-memory lists within the Infrastructure layer.

Benefits:
- No external dependencies
- Fast execution
- Easy to test
- Simple to replace with real persistence later

Migration to a real database requires only replacing repository implementations and adding EF Core/Dapper.

---

## Authentication Approaches

The project supports two authentication flows:

### 1. Manual JWT Authentication

Implemented via:
- AuthService
- JwtTokenGenerator

Flow:
1. Validate user credentials using IUserRepository
2. Generate a JWT token (issuer, audience, secret, expiration)
3. Return token and expiration metadata

This lightweight approach works well with in-memory data.

### 2. ASP.NET Identity (Optional)

Some Identity configuration is included to demonstrate how the application could evolve toward full Identity support.  
However, the primary authentication flow is manual JWT due to the use of in-memory user storage.

---

## Unit Testing

Unit tests were implemented using:
- xUnit
- Moq
- Real IConfiguration via ConfigurationBuilder

Key tests validate:
- Authentication success returns a valid token
- Authentication failure returns null
- JWT expiration is generated correctly

Configuration is injected using an actual configuration section instead of mocking GetValue<T>(), which Moq does not support.

---

## Running the Solution

### Requirements
- Visual Studio 2022+
- .NET 8 SDK
- Node.js and npm (for the React frontend)

### Steps

1. Open the solution in Visual Studio.
2. Right-click the solution → “Set Startup Projects…”
3. Select “Multiple startup projects”.
4. Set:
   - DesignliTest.WebApi → Start
   - DesignliTest.WebClient (React) → Start
5. Run the solution with F5.

API will start on the configured port and Swagger will be available for testing.

---

## Key Features

- Clean, modular architecture
- In-memory data persistence
- Manual JWT authentication
- Optional Identity authentication
- DTO mapping using Mapster
- Unit tests with real configuration
- Fully dependency-injected
- Ready for real database integration
- API-first approach for frontend clients

---

## Future Improvements

- Replace in-memory repositories with EF Core
- Add refresh token flow
- Role-based authorization
- Logging with Serilog or Application Insights
- Redis caching
- CI/CD pipelines (GitHub Actions, Azure DevOps)

