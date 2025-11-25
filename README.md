# ExpenseTracker.Api

Backend for Smart Expense Tracker – Phase 1 (API + Infrastructure).

## Prerequisites

- .NET 8 SDK
- SQL Server (localdb or instance)
- EF Core CLI (`dotnet tool install --global dotnet-ef`)

## Configuration

Update `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "ExpenseTrackerDb": "Server=localhost;Database=ExpenseTracker;Trusted_Connection=True;TrustServerCertificate=True;"
}