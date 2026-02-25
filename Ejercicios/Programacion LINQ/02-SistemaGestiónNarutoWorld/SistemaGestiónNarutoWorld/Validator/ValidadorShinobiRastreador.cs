using System.Text.RegularExpressions;
using SistemaGestiónNarutoWorld.Enums;
using SistemaGestiónNarutoWorld.Models;
using SistemaGestiónNarutoWorld.Validator.Common;

namespace SistemaGestiónNarutoWorld.Validator;

public class ValidadorShinobiRastreador : IValidador<Shinobi> {
    public IEnumerable<string> Validar(Shinobi shinobi) {
        var errores = new List<string>();

        if (shinobi is not ShinobiRastreador shinobiRastreador) {
            errores.Add("La entidad propocionada no es un shinobi ratreador");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(shinobiRastreador.DniNinja) || !Regex.IsMatch(shinobiRastreador.DniNinja, @"^\d{4}[A-Z]{3}$"))
            errores.Add("El DNI del ninja debe tener el formato oficial (Ej: 1234ABC)");
        
        if (string.IsNullOrWhiteSpace(shinobiRastreador.Nombre) || shinobiRastreador.Nombre.Length < 3)
            errores.Add("El nombre del ninja es obligatorio (min. 3 caracteres)");
        
        if (!Enum.IsDefined(typeof(AldeaNinja), shinobiRastreador.Aldea))
            errores.Add("La aldea proporcionada no existe en los registros");
        
        if (shinobiRastreador.Edad is < 1 or > 150)
            errores.Add("El edad del shinobi debe de estar entre 1 y 150 años");
        
        if (shinobiRastreador.VelocidadDesplazamiento is < 5 or > 500)
            errores.Add("La velocidad de desplazamiento del shinobi tiene que estar en 1 y 500 km/h");
        
        if(!Enum.IsDefined(typeof(MetodoRastreo), shinobiRastreador.Metodo))
            errores.Add("El metodo de rastreo no es apto");

        if (shinobiRastreador.RangoDeteccionKm is < 1 or > 50) 
            errores.Add("El rango de deteccion del shinobi deb estar entre 1 y 10 km");

        return errores;
    }
}