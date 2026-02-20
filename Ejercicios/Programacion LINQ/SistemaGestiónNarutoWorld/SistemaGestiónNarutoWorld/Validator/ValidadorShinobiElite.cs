using Microsoft.VisualBasic;
using SistemaGestiónNarutoWorld.Enums;
using SistemaGestiónNarutoWorld.Models;
using SistemaGestiónNarutoWorld.Validator.Common;

namespace SistemaGestiónNarutoWorld.Validator;

public class ValidadorShinobiElite : IValidador<Shinobi> {
    public IEnumerable<string> Validar(Shinobi shinobi) {
        var errores = new List<string>();

        if (shinobi is not ShinobiElite shinobiElite) {
            errores.Add("La entidad proporcionada no es ShinobiElite");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(shinobiElite.DniNinja) || shinobiElite.DniNinja.Length < 2)
            errores.Add("El dni del ninja es obligatorio(mín. 2 car.");
        
        if (string.IsNullOrWhiteSpace(shinobiElite.Nombre) || shinobiElite.Nombre.Length < 2)
            errores.Add("El nombre del shinobi es obligatorio (mín 2.car.)");
        
        if (!Enum.IsDefined(typeof(AldeaNinja), shinobiElite.Aldea))
            errores.Add("La aldea asignada no es una oficial de la lista");
        
        if (shinobi.AñoGraduacion > 1950 && shinobiElite.AñoGraduacion < 2026)
            errores.Add("EL año de graduacion tiene que ser entre 1950 y 2026");
        
        if (!Enum.IsDefined(typeof(ElementoNinja), shinobiElite.ElementoPrincipal))
            errores.Add("EL elemento del ninja no está registrado");
        
        
    }
}