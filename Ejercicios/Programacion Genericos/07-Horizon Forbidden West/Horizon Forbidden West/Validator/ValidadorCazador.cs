using System.Text.RegularExpressions;
using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Validator.Common;

namespace Horizon_Forbidden_West.Validator;

public class ValidadorCazador : IValidador<EntidadHorizon> {
    public ILista<string> Validar(EntidadHorizon entidad) {
        var errores = new Lista<string>();


        if (entidad is not Cazador cazador) {
            errores.AddLast("La entidad no es un cazador procesable");
            return errores;
        }

        if (string.IsNullOrEmpty(cazador.Nombre) || cazador.Nombre.Length < 3) {
            errores.AddLast("El nombre del cazador es obligatorio (minimo 3 caracteres)");
        }
        

        if (string.IsNullOrWhiteSpace(cazador.CodigoGaia)) {
            errores.AddLast("Error de registro: El codigo GAIA es requerido para los cazadores.");
        }
        else {
            var patronGaia = @"^CZR-\d{4}-[A-Z]$";

            if (!Regex.IsMatch(cazador.CodigoGaia, patronGaia)) {
                errores.AddLast($"Formato Invalido: '{cazador.CodigoGaia}' no sigue el protocolo estandar (CZR-0000-X)");
            }
        }

        if (string.IsNullOrWhiteSpace(cazador.Descripcion) || cazador.Descripcion.Length < 3) {
            errores.AddLast("La descripcion del cazador es obligatorio (minimo 3 caracteres)");
        }
        
        if (string.IsNullOrWhiteSpace(cazador.Especialidad))
            errores.AddLast("El cazador debe poseer una especialidad técnica activa.");
        
        if (!Enum.IsDefined(typeof(RangoCazador), cazador.Rango))
            errores.AddLast("El rango asignado no existe en la jerarquía tribal.");
        
        if (!Enum.IsDefined(typeof(TipoTribu), cazador.Tribu))
            errores.AddLast("Tribu no identificada. Los datos podrían estar corruptos.");
        
        if (!Enum.IsDefined(typeof(CicloEntrenamiento), cazador.Entrenamiento))
            errores.AddLast("El ciclo de entrenamiento no es valido (Iniciado o Veterano)");
        
        return errores;
    }
}