# CrudDemoAPI

This is a simple CRUD project to solidify my understanding of C# syntax and ASP.NET Core.  
It's a standalone module that I plan to integrate into a more complex project in the future.  

## Features
- **CRUD Operations**: Create, Read, Update, Delete for Customers and Products
- **Async database operations** with Entity Framework Core
- **DTO-based validation** to ensure clean and secure data input
- **Object mapping with AutoMapper** for separation between entities and API responses
- **Service Layer with ICrudService interface** for reusable CRUD logic and abstraction
- **Dependency Injection** for services following ASP.NET Core best practices
- **Error handling with ServiceResult** to standardize service responses (success, failure, error messages)
- **RESTful API design** with proper HTTP status codes
- **Separation of Concerns**: Controllers handle requests/responses, services handle business logic

## Work in Progress
- General interface `ICrudService` for reusability across entities
- `CustomerService` implementation to move logic from controllers into services
- `ServiceResult` pattern for structured service responses (success, error messages)

## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 Community Edition or VS Code
- SQL Server / SQLite (for local development)
- NuGet packages:  
  - Microsoft.EntityFrameworkCore  
  - Microsoft.EntityFrameworkCore.SqlServer  
  - AutoMapper.Extensions.Microsoft.DependencyInjection  

