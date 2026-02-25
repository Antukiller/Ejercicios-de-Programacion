using EmpresaHeroes.Models;
using EmpresaHeroes.Validator.Common;

namespace EmpresaHeroes.Validator;

public class ValidadorGuerrero : IValidador<Heroe> {
    public IEnumerable<string> Validate(Heroe heroe) {
        var errores = new List<string>();

        if (heroe is not Guerrero a) {
            errores.Add("Error: El tipo de heroe no correponde a un guerrero");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(a.Nombre) || a.Nombre.Length < 3)
            errores.Add("El nombre del guerrero debe ser mas descriptivo (mín. 3 caracteres)");
        
        if (a.Nivel is < 1 or > 100) 
            errores.Add("El nivel de guerrero debe estar entre 1 y 100");

        if (a.Energia is  < 1 or > 100)
            errores.Add("El nivel de energia del guerrero debe estar entre 1 y 100");
        
        if (a.Experiencia < 0)
            errores.Add("La experiencia del guerrero debe ser mayor que cero");
        
        if (a.PoderBase <= 0.0) 
            errores.Add("El poder base del guerrero tiene que ser mayor que 0");
        
        
        return errores;
    }
}