# User Management API (ASP.NET Core Minimal API)

A secure and modular Minimal API built with ASP.NET Core for managing users. Includes full CRUD functionality, validation, custom middleware for logging, error handling, and token-based authentication. Built step-by-step with Git versioning for Coursera submission.

---

## 🚀 Features

- ✅ CRUD endpoints for user management (`GET`, `POST`, `PUT`, `DELETE`)
- ✅ Validation for incoming user data (`username`, `email`)
- ✅ Token-based authentication middleware
- ✅ Logging middleware for request/response tracking
- ✅ Error handling middleware for consistent JSON errors
- ✅ `.http` file for direct endpoint testing using REST Client

---

## 🔐 Authentication

All `/users` endpoints are protected by token authentication.

**Required Header:**

`your-secret-token` defined in `TokenAuthenticationMiddleware.cs`.

---

## 📂 Folder Structure
UserManagementApi/ ├── Models/ │   └── User.cs ├── Middleware/ │   ├── LoggingMiddleware.cs │   ├── RequestResponseLoggingMiddleware.cs │   ├── TokenAuthenticationMiddleware.cs │   └── ErrorHandlingMiddleware.cs ├── UserManagement.http └── Program.cs

---

## 🧪 Testing the API

Use the included `UserManagement.http` file with the REST Client extension in VS Code.

Make sure the API is running:

```bash
dotnet run
```
## Example request
```POST http://localhost:5046/users
Authorization: Bearer your-secret-token
Content-Type: application/json
{
  "username": "albin",
  "email": "albin@example.com"
}
```
---
## 📦 Setup Instructions
- Clone the repository:
git clone https://github.com/AlbiniB/AlbiniB-Coursera-API-with-Copilot
cd UserManagementApi
dotnet run

## 🧠 Built With
- ASP.NET Core Minimal APIs
- REST Client (.http file)
- Custom Middleware
- Git for version control
- Copilot for debugging and iteration
