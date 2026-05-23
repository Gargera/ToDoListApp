<div align="center">

# ✅ ToDoList App

### Modern ASP.NET Core MVC Application For Managing Tasks & Categories

<br/>

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=.net)]()
[![C#](https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=c-sharp)]()
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver)]()
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-ORM-7A3E9D?style=for-the-badge)]()
[![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)]()

<br/>

### 🔗 Live Demo

http://doitnow.runasp.net/

</div>

---

# 📌 Overview

ToDoList App is a modern web application built using **ASP.NET Core MVC** that helps users organize and track their daily tasks through a clean category-based system.

Each user gets a personal workspace with full control over their categories and tasks, backed by secure authentication and role-based authorization.

---

# ✨ Features

## 👤 User Features

- Register & login with secure authentication
- Auto-created **General** category on registration (protected — cannot be edited or deleted)
- Create, update, and delete categories
- Create, update, and delete tasks inside any category
- Tasks without a selected category are automatically added to **General**
- Search and sort categories by name
- Filter and sort tasks by priority and status
- View task details in a popup modal
- View all tasks across all categories in one page

## 👨‍💼 Admin Features

- All user features included
- Access the **Users Management** page
- View all registered users with their roles

---

# 🧠 Architecture — 3-Tier

```text
Presentation Layer (PL)
ASP.NET Core MVC — Controllers, Views, ViewModels
        ↓
Business Logic Layer (BLL)
Services, DTOs, AutoMapper, Result Pattern
        ↓
Data Access Layer (DAL)
Generic Repository, Unit of Work, EF Core, Entities
        ↓
SQL Server Database
```

---

# 🏗️ Project Structure

```text
ToDoListApp
│
├── ToDoListApp.PL               ← Presentation Layer
│   ├── Controllers
│   ├── Views
│   ├── ViewModels
│   └── wwwroot
│
├── ToDoListApp.BLL              ← Business Logic Layer
│   ├── Services
│   ├── DTOs
│   └── Interfaces
│
├── ToDoListApp.DAL              ← Data Access Layer
│   ├── Entities
│   ├── Context
│   ├── Repositories
│   └── Migrations
```

---

# 🗄️ Main Entities

| Entity | Description |
|---|---|
| ApplicationUser | ASP.NET Identity user |
| Category | Groups tasks per user — includes a protected General category |
| ToDoItem | A task with title, description, priority, and completion status |

---

# 🔄 App Flow

```text
Register → Auto-create General Category
    ↓
Categories Page → Open Category
    ↓
Tasks Page → Create / Update / Delete Tasks
```

---

# 🧩 Design Patterns & Concepts

| Pattern / Concept | Usage |
|---|---|
| 3-Tier Architecture | Separation of concerns across PL, BLL, DAL |
| Generic Repository | Reusable data access for all entities |
| Unit of Work | Single transaction management across repositories |
| Dependency Injection | Built-in ASP.NET Core DI for all services and repositories |
| AutoMapper | Mapping between Entities ↔ DTOs ↔ ViewModels |
| Result Pattern | Consistent `IsSuccess`, `Message`, `Data` responses from services |

---

# 🔐 Authentication & Authorization

- ASP.NET Core Identity
- Roles: `Admin`, `User`
- General category is protected per user — cannot be edited or deleted
- `[Authorize]` and `[Authorize(Roles = "Admin")]` on controllers
- Cookie-based authentication with persistent login

---

# 🧰 Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC | Web framework |
| Entity Framework Core | ORM & Code First Migrations |
| SQL Server | Database |
| ASP.NET Core Identity | Authentication & Authorization |
| AutoMapper | Object mapping |
| JavaScript | Client-side interactions & modals |
| LINQ | Data querying |
| Generic Repository + UoW | Data abstraction & transaction management |

---

# 🛠️ Local Setup

## Clone Repository

```bash
git clone https://github.com/Gargera/ToDoListApp.git
cd ToDoListApp
```

## Configure Database

Edit `ToDoListApp.PL/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ToDoListDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Restore Packages

```bash
dotnet restore
```

## Apply Migrations

```bash
dotnet ef database update --project ToDoListApp.DAL --startup-project ToDoListApp.PL
```

## Run Application

```bash
dotnet run --project ToDoListApp.PL
```

---

# 👩‍💻 Author

### Esraa Taha

**GitHub:** https://github.com/Gargera

---

<div align="center">

### ⭐ Portfolio Project Built With ASP.NET Core MVC ⭐

</div>
