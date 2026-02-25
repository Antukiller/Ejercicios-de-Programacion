using EmpresaHeroes.Models;
using EmpresaHeroes.Validator.Common;

namespace EmpresaHeroes.Validator;

public class ValidadorArquero : IValidador<Heroe> {
    public IEnumerable<string> Validate(Heroe heroe) {
        var errores = new List<string>();

        if (heroe is not Arquero a) {
            errores.Add("Error: El tipo de heroe no correponde a un arquero");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(a.Nombre) || a.Nombre.Length < 3)
            errores.Add("El nombre del mago debe ser mas descriptivo (mín. 3 caracteres)");
        
        if (a.Nivel is < 1 or > 100) 
            errores.Add("El nivel de arquero debe estar entre 1 y 100");

        if (a.Energia is  < 1 or > 100)
            errores.Add("El nivel de energia del arquero debe estar entre 1 y 100");
        
        if (a.Experiencia < 0)
            errores.Add("La experiencia del arquero debe ser superior a cero");
        
        if (a.PoderBase <= 0.0) 
            errores.Add("El poder base del arquero tiene que ser mayor que 0");
        
        
        return errores;
    }
}