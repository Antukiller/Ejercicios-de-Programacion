using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using SistemaGestiónNarutoWorld.Enums;
using SistemaGestiónNarutoWorld.Models;
using SistemaGestiónNarutoWorld.Validator.Common;

namespace SistemaGestiónNarutoWorld.Validator;


/// <summary>
/// Clase validador de Ninja de Elite
/// </summary>
public class ValidadorShinobiElite : IValidador<Shinobi> {
    public IEnumerable<string> Validar(Shinobi shinobi) {
        var errores = new List<string>();

        if (shinobi is not ShinobiElite shinobiElite) {
            errores.Add("La entidad proporcionada no es ShinobiElite");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(shinobiElite.DniNinja) || !Regex.IsMatch(shinobiElite.DniNinja, @"^\d{4}[A-Z]{3}$"))
            errores.Add("El DNI del ninja debe tener el formato oficial (Ej: 1234ABC)");
        
        if (string.IsNullOrWhiteSpace(shinobiElite.Nombre) || shinobiElite.Nombre.Length < 2)
            errores.Add("El nombre del shinobi es obligatorio (mín 2.car.)");
        
        if (!Enum.IsDefined(typeof(AldeaNinja), shinobiElite.Aldea))
            errores.Add("La aldea asignada no es una oficial de la lista");
        
        if (shinobiElite.Edad is < 0 or > 150)
            errores.Add("La edad debe de estar entre 0 y 150");
        
        if (!Enum.IsDefined(typeof(ElementoNinja), shinobiElite.ElementoPrincipal))
            errores.Add("EL elemento del ninja no está registrado");
        

        return errores;
    }
}