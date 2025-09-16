using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Domain;

/// <summary>
/// Класс, описывающий семейство самолетов
/// </summary>
public class AirplaneFamily
{
    /// <summary>
    /// Название семейства
    /// </summary>
    public required string NameOfFamily { get; set; }

    /// <summary>
    /// Название производителя
    /// </summary>
    public required string NameOfManufacturer { get; set; }
}
