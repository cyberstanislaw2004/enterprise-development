using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Airlines.Domain;

/// <summary>
/// Класс, хранящий сведения о авиарейсе
/// </summary>
public class Flight
{
    /// <summary>
    /// Уникальный ID для праймари ключа в БД
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Уникальный шифр авиарейса
    /// </summary>
    public required string FlightNumber { get; set; }

    /// <summary>
    /// Пункт отправления(например LED)
    /// </summary>
    public required string DepartureAirportCode { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    public required string DestinationAirportCode { get; set; }

    /// <summary>
    /// Дата отправления рейса 
    /// </summary>
    public required DateOnly DepartureDate { get; set; }

    /// <summary>
    /// Дата прибытия рейса
    /// </summary>
    public required DateOnly ArrivalDate { get; set; }

    /// <summary>
    /// Время отправления рейса
    /// </summary>
    public required TimeOnly DepartureTime { get; set; }

    /// <summary>
    /// Время в пути
    /// </summary>
    public required TimeSpan Duration { get; set; }

    /// <summary>
    /// Модель самолета
    /// </summary>
    public required AirplaneModel AirplaneModel { get; set; }
}