# DotNet FSE Deepskilling Program

Reference repo: https://github.com/seshadrimr/Digital-Nurture-DotNetFSE

## Structure

### Week 1
- **Advanced SQL** — Window functions, indexes, views, stored procedures, functions, triggers, cursors, exception handling
- **Data Structures & Algorithms** — E-commerce product search, financial forecasting with recursion
- **Design Patterns & Principles** — Singleton pattern, Factory Method pattern
- **NUnit & Moq** — Unit testing with NUnit, mocking with Moq

### Week 2 — Entity Framework Core 8.0
Project: `RetailInventory` (.NET Console App)

- Lab 1 — ORM concepts, EF Core vs EF Framework, EF Core 8.0 features
- Lab 2 — DbContext setup, Category & Product models, SQL Server connection
- Lab 3 — EF Core CLI migrations (`InitialCreate`)
- Lab 4 — Inserting data with `AddRangeAsync` and `SaveChangesAsync`
- Lab 5 — Retrieving data with `ToListAsync`, `FindAsync`, `FirstOrDefaultAsync`
- Lab 6 — Updating and deleting records
- Lab 7 — LINQ queries with `Where`, `OrderByDescending`, `Select` projection into DTOs

### Week 3 — ASP.NET Core 8.0 Web API

#### EmployeeApi
- Hands-on 1 — Basic Web API with GET, POST, PUT, DELETE
- Hands-on 2 — Swagger integration (`Swashbuckle.AspNetCore`), `ProducesResponseType`
- Hands-on 3 — `Employee` model with `Department`, `Skills`, `DateOfBirth`; `GetStandardEmployeeList`; `CustomAuthFilter` (checks Bearer token); `CustomExceptionFilter` (logs to file)
- Hands-on 4 — Full CRUD with PUT validation (`Invalid employee id`)
- Hands-on 5 — CORS, JWT authentication, `AuthController` with `AllowAnonymous`, `[Authorize(Roles="Admin,POC")]`

#### KafkaChatApp
- Hands-on 6 — Kafka chat app using `Confluent.Kafka`; press `P` to produce messages, `C` to consume

### Week 4 — Microservices
- JWT authentication microservice with secure controllers

### Week 5 — React
- 13 React apps covering components, props, state, events, routing, and styling

### Week 6
- **Angular** — Student course portal with components, directives, pipes, services, routing

### Week 7
- **GIT** — Git hands-on commands and workflow
