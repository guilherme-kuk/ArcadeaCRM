# 🏢 Arcadea CRM

A simple, modern CRM application built with .NET 8 and Blazor Server for managing customer accounts.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?style=flat-square&logo=blazor)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=flat-square&logo=microsoftsqlserver)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

## 📋 About

Arcadea CRM is a full-stack prototype designed to demonstrate a clean architecture approach using Domain-Driven Design (DDD) principles. It provides complete CRUD operations for customer account management with a responsive, user-friendly interface.

### ✨ Features

- 📊 **List all accounts** with a responsive data table
- ➕ **Create new accounts** with inline form
- ✏️ **Edit accounts** with inline editing
- 🗑️ **Delete accounts** with confirmation modal
- ✅ **Form validation** with real-time feedback
- 📱 **Phone masking** for Brazilian phone numbers (landline & mobile)
- 📧 **Email validation** with regex pattern
- 🎨 **Clean UI** with Bootstrap 5

## 🏗️ Architecture

This project follows **DDD Light** principles with clear separation of concerns:

```
📦 ArcadeaCRM
├── 📁 CrmApp.Domain          # Entities & Interfaces
├── 📁 CrmApp.Infrastructure  # Data Access (EF Core + Repositories)
├── 📁 CrmApp.Application     # Business Logic (Services)
└── 📁 CrmApp.Web             # Blazor Server Frontend
```

### Design Patterns

- **Repository Pattern** - Abstracts data access logic
- **Service Layer** - Encapsulates business rules
- **Dependency Injection** - Loose coupling between layers
- **Interface-based Design** - Enables testability and flexibility

## 🛠️ Tech Stack

| Layer            | Technology                                  |
| ---------------- | ------------------------------------------- |
| **Frontend**     | Blazor Server, Bootstrap 5, Bootstrap Icons |
| **Backend**      | .NET 8, C# 12                               |
| **Database**     | SQL Server LocalDB, Entity Framework Core 8 |
| **Architecture** | DDD, Repository Pattern, Service Layer      |

## 📋 Prerequisites

Before running this project, make sure you have installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (comes with Visual Studio)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with C# extension

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/guilherme-kuk/ArcadeaCRM.git
cd arcadea-crm
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Apply database migrations

```bash
dotnet ef database update --project CrmApp.Infrastructure --startup-project CrmApp.Web
```

### 4. Run the application

```bash
cd CrmApp.Web
dotnet run
```

The application will be available at `http://localhost:5221`

## ⚙️ Configuration

### Connection String

The database connection is configured in `CrmApp.Web/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ArcadeaCRM;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

## 📁 Project Structure

```
📦 CrmApp.Domain
├── 📁 Entities
│   └── Account.cs              # Account entity with validations
└── 📁 Interfaces
    └── IAccountRepository.cs   # Repository interface

📦 CrmApp.Infrastructure
├── 📁 Data
│   ├── CrmDbContext.cs         # EF Core DbContext
│   └── 📁 Migrations           # Database migrations
└── 📁 Repositories
    └── AccountRepository.cs    # Repository implementation

📦 CrmApp.Application
├── 📁 Interfaces
│   └── IAccountService.cs      # Service interface
└── 📁 Services
    └── AccountService.cs       # Business logic

📦 CrmApp.Web
├── 📁 Components
│   ├── 📁 Layout               # MainLayout, NavMenu
│   └── 📁 Pages
│       ├── Accounts.razor      # Main CRUD page
│       └── AccountForm.razor   # Reusable form component
├── Program.cs                  # DI configuration
└── appsettings.json           # App configuration
```

## 📊 Data Model

### Account Entity

| Field         | Type     | Validation                                    |
| ------------- | -------- | --------------------------------------------- |
| `Id`          | int      | Auto-generated PK                             |
| `FirstName`   | string   | Required, max 100 chars                       |
| `LastName`    | string   | Required, max 100 chars                       |
| `Email`       | string   | Required, unique, regex validated             |
| `PhoneNumber` | string?  | Brazilian format (XX) XXXX-XXXX or XXXXX-XXXX |
| `Address`     | string?  | Max 500 chars                                 |
| `City`        | string?  | Max 100 chars                                 |
| `State`       | string?  | Max 100 chars                                 |
| `Country`     | string?  | Max 100 chars                                 |
| `DateCreated` | DateTime | Auto-generated                                |

## 🧪 Development

### Building the project

```bash
dotnet build
```

### Running with hot reload

```bash
cd CrmApp.Web
dotnet watch run
```

### Creating a new migration

```bash
dotnet ef migrations add MigrationName --project CrmApp.Infrastructure --startup-project CrmApp.Web --output-dir Data/Migrations
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Your Name**

- GitHub: [@guilherme-kuk](https://github.com/guilherme-kuk)
- LinkedIn: [Guilherme Kuk](https://linkedin.com/in/guilhermekuk)

---

<p align="center">
  Made with ❤️ using .NET 8 and Blazor
</p>
