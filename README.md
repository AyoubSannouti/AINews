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


---

## ⚙️ Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Node.js 20+](https://nodejs.org)
- [Docker](https://www.docker.com/)
- [SQL Server or PostgreSQL] (depending on your config)

---

## 🛠️ Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/<your-username>/AINews.git
cd AINews

Backend Setup :
cd AINews.API
dotnet restore
dotnet ef database update   # Run migrations
dotnet run

Frontend Setup :
cd AINews.Web
npm install
npm start


Run Test :
cd AINews.Tests
dotnet test

Docker Setup :
Build & Run Bckend :
docker build -t ainews-api ./AINews.API
docker run -p 7129:80 ainews-api


Build & Run Frontend :
docker build -t ainews-web ./AINews.Web
docker run -p 3000:80 ainews-web

Using docker-compose :
docker-compose up --build

⚡ API Endpoints

POST /api/Auth/register → Register new user

POST /api/Auth/login → Login and get JWT

GET /api/Articles → Get all articles

GET /api/Events → Get all events

GET /api/Auth/me → Get current logged-in user

🧪 Testing Strategy

Unit Tests
Located in AINews.Tests → Handlers, Commands, Queries.

Integration Tests
Located in AINews.Tests.Integration → Uses TestWebAppFactory with in-memory server.




