# 📰 AINewsHub

AINewsHub is a **full-stack .NET 9 + React (TypeScript)** application that aggregates AI news, articles, and events.  
It includes authentication, category management, admin features, and Dockerized deployment with **Nginx**.

---

## 🚀 Features
- 🔐 **Authentication** with ASP.NET Core Identity & JWT
- 📝 **Articles**: CRUD operations with categories
- 📅 **Events**: CRUD operations with categories
- 🧑‍💻 **Admin Panel** for managing categories (articles & events)
- 🧪 **Unit & Integration Tests** with **xUnit**, **Moq**, **FluentAssertions**
- 🐳 **Dockerized Deployment** with Nginx reverse proxy
- 🎨 **Frontend** in React + TypeScript (Material UI v5)

---

## 📂 Project Structure

AINews/
│── AINews.API/ # Backend ASP.NET Core Web API
│── AINews.Application/ # Application Layer (CQRS, Handlers, DTOs)
│── AINews.Domain/ # Domain Models & Business Logic
│── AINews.Infrastructure/ # Persistence, Identity, EF Core
│── AINews.Web/ # React (TypeScript) frontend
│── AINews.Tests/ # Unit tests
│── AINews.Tests.Integration/ # Integration tests
│── docker-compose.yml # Multi-container orchestration
│── README.md # This file 🚀
