# Airlines

Реализует многослойную архитектуру с доменной моделью, DTO, прикладной логикой и Web API с in-memory инфраструктурой для удобства разработки и тестирования.

## Структура репозитория
- `Airlines.Domain` — доменные сущности
- `Airlines.Dto` — DTO‑классы для передачи данных между слоями
- `Airlines.Application` — сервисы
- `Airlines.Infrastructure.InMemory` — реализация репозиториев в памяти 
- `WebApplication1` — ASP.NET Core Web API

## Технологии
- .NET 8
- ASP.NET Core Web API
- Swashbuckle (Swagger) для документации API

## Требования
- .NET 8 SDK
- Visual Studio 2022 / 2022+ или любая IDE, поддерживающая .NET 8
