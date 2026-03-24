
using System.Text.RegularExpressions;
using GestionITV.Models;
using GestionITV.Validator.Common;
using GestionITV.Enum;

namespace GestionITV.Validator;

public class ValidadorVehiculo : IValidador<Vehiculo> {
    public IEnumerable<string> Validar(Vehiculo e) {
        var errores = new List<string>();


        if (e is not { } v) {
            errores.Add("La entidad proporcionada no es un vehiculo");
            return errores;
        }

        if (!string.IsNullOrWhiteSpace(v.Matricula)) {
            // El patrón [ -]? permite un espacio o un guion opcional entre números y letras
            var patronMatricula = @"^[0-9]{4}[ -]?[B-DF-HJ-NP-TV-Z]{3}$";

            if (!Regex.IsMatch(v.Matricula.ToUpper(), patronMatricula)) {
                errores.Add($"Protocolo de matrícula inválido: {v.Matricula} no cumple con el formato (NNNNLLL o NNNN-LLL)");
            }
        }
            
        if (!string.IsNullOrWhiteSpace(v.Marca)) 
            errores.Add("La marca del vehiculo no es compatible");
        
        if (!string.IsNullOrWhiteSpace(v.Modelo))
            errores.Add("El modelo es no es compatible con el vehiculo proporcinado");
        
        if (v.Cilindrada is < 1.0 or > 2.0) 
            errores.Add("La cilindrada del vehiculo tiene que ser mayor a 1.0 y menor que 2.0");
        
        if (!System.Enum.IsDefined(typeof(Motor), v.Motor))
            errores.Add("El tipo de motor no coincide con el de la base de datos");
        
        if (!string.IsNullOrWhiteSpace(v.DniPropietario)) {
            // Patrón: 8 números + una letra válida de DNI (mayúscula o minúscula)
            var patronDni = @"^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKEtrwagmyfpdxbnjzsqvhlcke]$";

            if (!Regex.IsMatch(v.DniPropietario, patronDni)) {
                errores.Add($"DNI inválido: {v.DniPropietario} no cumple con el formato oficial (8 números y una letra)");
            }
        }

        return errores;

    }
    
}