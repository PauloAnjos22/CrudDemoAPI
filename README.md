# CrudDemoAPI

This is a simple CRUD project to solidify my understanding of C# syntax and ASP.NET Core.  
It's a standalone module that I plan to integrate into a more complex project in the future.  

## Features
- Create, Read, Update, Delete Customers and Products
- Async database operations with EF Core
- Basic HTTP responses and status codes
- Data validation with DTOs
- Object mapping using AutoMapper for clean separation between entities and API responses

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

