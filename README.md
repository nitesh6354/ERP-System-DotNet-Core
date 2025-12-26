# ERP System – ASP.NET Core

## 📌 Project Overview
This project is a **real-world ERP (Enterprise Resource Planning) system**
built using **ASP.NET Core Web API**, **C#**, and **SQL Server Express**.

The application follows **Layered Architecture** to ensure clean separation
of concerns, maintainability, testability, and scalability.

---

## 🧱 Architecture (Layered)

The solution is structured into the following layers:

- **ERP.API**  
  Presentation layer responsible for handling HTTP requests, authentication,
  and responses.

- **ERP.Application**  
  Contains business logic, use cases, validations, and service interfaces.

- **ERP.Domain**  
  Core domain entities and business models.  
  This layer has no dependency on any framework.

- **ERP.Infrastructure**  
  Handles database access using **Entity Framework Core** and
  SQL Server Express.

---

## 🛠️ Technology Stack
- ASP.NET Core 8 (Web API)
- C#
- Entity Framework Core
- SQL Server Express
- RESTful APIs
- Dependency Injection
- Git & GitHub

---

## 🎯 Key Features (Planned & In Progress)
- User authentication & authorization
- Employee management
- Department management
- Inventory management
- Role-based access control
- Clean and scalable architecture
------------------------------------------
#PROJECT REFERENCES STRUCTURE
ERP.Domain → no references

ERP.Application → Domain

ERP.Infrastructure → Domain + Application

ERP.API → Application + Infrastructure
-------------------------------------------

## ⚙️ How to Run the Project
1. Clone the repository:
```bash
git clone https://github.com/USERNAME/ERP-System-DotNet-Core.g


