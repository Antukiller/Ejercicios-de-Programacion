using GestionITV.Enum;

namespace GestionITV.Models;

/// <summary>
///  Clase record vehiculo
/// </summary>
/// <param name="Matricula"></param>
/// <param name="Marca"></param>
/// <param name="Modelo"></param>
/// <param name="Cilindrada"></param>
/// <param name="Motor"></param>
/// <param name="DniPropietario"></param>
public record Vehiculo(
    int Id,
    string Matricula,
    string Marca,
    string Modelo,
    double Cilindrada,
    Motor Motor,
    string DniPropietario,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted
);