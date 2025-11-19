# Airlines

Реализует многослойную архитектуру с доменной моделью, DTO, прикладной логикой и Web API с in-memory инфраструктурой для удобства разработки и тестирования.

## Структура репозитория
- `Airlines.Domain` — доменные сущности
- `Airlines.Dto` — DTO‑классы для передачи данных между слоями
- `Airlines.Application` — сервисы
- `Airlines.Infrastructure.InMemory` — реализация репозиториев в памяти
- `Airlines.Infrastructure.Db` — EF Core `DbContext`, миграции и репозитории для MS SQL Server
- `Airlines.Api` — ASP.NET Core Web API
- `Airlines.AppHost` — оркестратор (Aspire) для запуска приложения и базы данных в контейнерах

## Технологии
- .NET 8
- ASP.NET Core Web API
- Swashbuckle (Swagger) для документации API
- Entity Framework Core
- MS SQL Server
- Aspire

## Требования
- .NET 8 SDK
- Visual Studio 2022 / 2022+ или любая IDE, поддерживающая .NET 8
- MS SQL Server
- Docker Desktop
