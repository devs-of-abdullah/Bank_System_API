# Bank Management System #

**Overview**
- This Project is a **Bank Management System API** built with ASP.NET Core following clean, layered architecture.
- It simulates real world banking operations such as account management, transfer money between users, deposit, withdraw and many other functions.
- The goal of this project is to demonstrate my development skills, data management, and business logic handling.

**Features**
- Create and manage bank accounts
- Deposit and withdraw money
- Transfer money between accounts
- Secured Transactions and login
- Layered architechure
- DTO based data transfer
- Validations

**Tech Stack**
- ASP.NET Core
- Entity Framework Core 
- C#
- Clean architechure principles
 Secured operations

## EF Core Commands

# Add a new migration
dotnet ef migrations add InitialCreate --project Data --startup-project API

# Apply migrations to the database
dotnet ef database update --project Data --startup-project API

# Remove the last migration
dotnet ef migrations remove --project Data --startup-project API

# Drop the entire database
dotnet ef database drop --project Data --startup-project API
