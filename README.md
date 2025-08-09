# ProductManagement (ASP.NET Core MVC)

A **Clean Architecture** MVC application for managing **Service Providers** and **Products**, with filtering capabilities by price, date, and provider.

---

## ✨ Features
- **Service Providers**: Create & List (validation, unique name).
- **Products**: Create & List with provider dropdown.
- **Filtering**: Min/Max Price, Date range (inclusive), and Provider.
- **User Experience**: Bootstrap UI, validation summary, reset filters, result count badge.
- **Data Layer**: Repository pattern, `AsNoTracking()` reads, eager loading for related data.
- **Security**: Anti-forgery on POST, DTO/VM to avoid over-posting.
- **Performance**: DB indexes (Price, CreationDate), projection-ready.
- **Extensible**: Pagination & sorting fields in DTOs (`Page`, `PageSize`, `Search`).

---

## 🧱 Tech Stack
- **.NET 8** / ASP.NET Core MVC  
- **Entity Framework Core** (SQL Server / LocalDB)  
- **AutoMapper**  
- (Optional) **Serilog**, **FluentValidation**, MemoryCache

---

## 🏗️ Architecture
```
Domain/            -> Entities (Product, ServiceProvider)
Application/       -> DTOs, Services, Interfaces
Infrastructure/    -> EF Core (AppDbContext), Repositories
ProductManagement/ -> MVC (Controllers, Views, MappingProfile, DI)
```

---

## 📁 Project Structure (high level)
```
ProductManagement.sln
 ├─ Domain/
 ├─ Application/
 ├─ Infrastructure/
 │   └─ Data/AppDbContext.cs
 │   └─ Repositories/...
 └─ ProductManagement/ (Web)
     ├─ Controllers/
     ├─ Views/
     ├─ MappingProfile.cs
     └─ Program.cs
```

---

## ⚙️ Getting Started

### Prerequisites
- .NET 8 SDK  
- SQL Server (LocalDB works fine)

### Setup
1. Update the connection string in `appsettings.json` if needed:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ProductManagement;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
2. Apply EF migrations:
   ```bash
   dotnet ef database update
   ```
   > If you modify entity names/tables:  
   > `dotnet ef migrations add InitialCreate && dotnet ef database update`

3. Run:
   ```bash
   dotnet run --project ProductManagement
   ```
   Then open: http://localhost:5000 (or the port shown in the console).

---

## 🖥️ How to Use
- **Service Providers**
  - `ServiceProviders > Create` → Add a new provider.
  - `ServiceProviders > Index` → View all providers.
- **Products**
  - `Products > Create` → Add a new product (requires selecting a provider).
  - `Products > Index` → View products + filtering:
    - Price: Min/Max (number)
    - Date: From/To (`type="date"`, To is inclusive for the whole day)
    - Provider: Dropdown
    - **Apply** button to filter, **Reset** to clear.
    - **If no results with filters** → all products are shown as per requirements.

---

## ✅ Validation & Security
- Server & client validation (DataAnnotations).
- `[ValidateAntiForgeryToken]` on all POST actions.
- DTO/VM mapping to prevent over-posting.
- Success messages via `TempData["Success"]`.

---

## 🚀 Performance Notes
- All list queries use `AsNoTracking()`.
- Indexes on `Price` and `CreationDate`.
- `Include(ServiceProvider)` only when needed.
- Ready for adding Pagination/Sorting and `ProjectTo<>` if required.

---

## 🔌 Key Commands (EF)
```bash
# Add migration after model changes
dotnet ef migrations add <Name>

# Apply migrations
dotnet ef database update
```

---

## 🧭 Roadmap
- Pagination & sorting on the Products page.
- Global exception handling + Serilog structured logging.
- MemoryCache for provider dropdown list.
- FluentValidation for advanced validation rules.
- Integration tests (SQLite InMemory).

---

## 📸 Screenshots
<img width="1950" height="1308" alt="image" src="https://github.com/user-attachments/assets/7c7b8e6c-9636-4381-8c44-98a3002f0295" />
<img width="1954" height="844" alt="image" src="https://github.com/user-attachments/assets/ab9fb5ed-3678-400f-a5cf-47dea9ae9b6f" />
<img width="1952" height="1136" alt="image" src="https://github.com/user-attachments/assets/fb5c07cf-cdc4-4505-9bbd-7c0110cc74f2" />


---

## 📄 License
Internal / Assessment Use Only.
