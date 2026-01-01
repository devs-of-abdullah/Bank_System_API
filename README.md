# Bank Management System #

**Overview**
- This Project is a **Bank Management System** built with ASP.NET Core following clean, layered architecture.
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
- Blazor

**What I Learned**
- Designing business rules for financial operations
- Writing clean and maintainable code
- Using EF Core effectivly
- Secured operations

**How TO Run**
1) Clone the repository
2) Configure a SQL server connection string in app.settings
3) Run Database Migrations
- For initial create (dotnet ef migrations add InitialCreate --project Data --startup-project API)
- To update (dotnet ef database update --project Data --startup-project API)
4) Start the Blazor Client
