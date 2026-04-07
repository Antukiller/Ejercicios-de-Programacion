
using System.Text.RegularExpressions;
using GestionITV.Models;
using GestionITV.Validator.Common;
using GestionITV.Enum;

namespace GestionITV.Validator;
public class ValidadorVehiculo : IValidador<Vehiculo> {
    public IEnumerable<string> Validar(Vehiculo e) {
        var errores = new List<string>();

        if (e is not { } v) {
            errores.Add("La entidad proporcionada no es un vehículo");
            return errores;
        }

        // Matrícula
        if (string.IsNullOrWhiteSpace(v.Matricula)) {
            errores.Add("La matrícula es obligatoria");
        } else {
            var patronMatricula = @"^[0-9]{4}[ -]?[B-DF-HJ-NP-TV-Z]{3}$";
            if (!Regex.IsMatch(v.Matricula.ToUpper(), patronMatricula)) {
                errores.Add($"Matrícula inválida: {v.Matricula} debe ser NNNNLLL o NNNN-LLL");
            }
        }
            
        // Marca y Modelo
        if (string.IsNullOrWhiteSpace(v.Marca)) 
            errores.Add("La marca del vehículo es obligatoria");
        
        if (string.IsNullOrWhiteSpace(v.Modelo))
            errores.Add("El modelo del vehículo es obligatorio");
        
        // Cilindrada (Ajustado el mensaje al nuevo rango 0.0 - 3.0)
        if (v.Cilindrada is < 0.0 or > 3.0) 
            errores.Add("La cilindrada debe estar entre 0.0 (eléctricos) y 3.0");
        
        // Motor
        if (!System.Enum.IsDefined(typeof(Motor), v.Motor))
            errores.Add("El tipo de motor no es válido");
        
        // DNI
        if (string.IsNullOrWhiteSpace(v.DniPropietario)) {
            errores.Add("El DNI del propietario es obligatorio");
        } else {
            var patronDni = @"^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKEtrwagmyfpdxbnjzsqvhlcke]$";
            if (!Regex.IsMatch(v.DniPropietario, patronDni)) {
                errores.Add($"DNI inválido: {v.DniPropietario} debe tener 8 números y una letra");
            }
        }

        return errores;
    }
}