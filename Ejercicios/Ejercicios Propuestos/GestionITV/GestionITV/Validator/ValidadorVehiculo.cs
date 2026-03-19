using System.Text.RegularExpressions;
using GestionITV.Models;
using GestionITV.Validator.Common;

namespace GestionITV.Validator;

public class ValidadorVehiculo : IValidador<Vehiculo> {
    public IEnumerable<string> Validar(Vehiculo e) {
        var errores = new List<string>();


        if (e is not Vehiculo v) {
            errores.Add("La entidad proporcionada no es un vehiculo");
            return errores;
        }

        if (!string.IsNullOrWhiteSpace(v.Matricula)) {
            var matricula = @"^[0-9]{4}[B-DF-HJ-NP-TV-Z]{3}$";
            if (!Regex.IsMatch(v.Matricula, matricula)) {
                errores.Add($"Protocolo de matricula inválido: {v.Matricula} no cumple con el formato de matricula (NNNN-LLL)");
            }
        }
            
        
        
    }
    
    
    
    
}