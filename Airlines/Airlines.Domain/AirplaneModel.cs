using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Domain;

/// <summary>
/// Класс, хранящий сведения о моделе самолета
/// </summary>
public class AirplaneModel
{
    /// <summary>
    /// Уникальный ID для праймари ключа в БД
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название модели самолета
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// Семейство модели
    /// </summary>
    public required AirplaneFamily AirplaneFamily { get; set; }

    /// <summary>
    /// Дальность полета
    /// </summary>
    public required double RangeOfFlight { get; set; }

    /// <summary>
    /// Пассажировместимость
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Грузовместимость
    /// </summary>
    public required double CargoCapacity { get; set; }
}
