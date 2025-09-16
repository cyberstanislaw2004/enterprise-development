using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airlines.Domain;

/// <summary>
/// Класс, характеризующий билет
/// </summary>
public class Ticket
{
    /// <summary>
    /// Уникальный ID для праймари ключа в БД
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Информация о рейсе
    /// </summary>
    public required Flight FlightInfo { get; set; }

    /// <summary>
    /// Информация о пассажире
    /// </summary>
    public required Passenger PassengerInfo { get; set; }

    /// <summary>
    /// Номер сидения
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Наличие ручной клади
    /// </summary>
    public required bool? HandLuggageAvailability { get; set; } // 0 - no; 1 - yes

    /// <summary>
    /// Суммарный вес багажа
    /// </summary>
    public required double TotalBaggageWeight { get; set; }
}
