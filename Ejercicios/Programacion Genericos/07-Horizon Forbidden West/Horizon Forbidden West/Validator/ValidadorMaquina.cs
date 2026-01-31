using System.Text.RegularExpressions;
using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Validator.Common;

namespace Horizon_Forbidden_West.Validator;

public class ValidadorMaquina : IValidador<EntidadHorizon> {
    public ILista<string> Validar(EntidadHorizon entidad) {
        var errores = new Lista<string>();

        if (entidad is not Maquina maquina) {
            errores.AddLast("Error Crítico: La entidad no es una unidad robótica procesable.");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(maquina.Nombre) || maquina.Nombre.Length < 3)
            errores.AddLast("El nombre de la maquina es obligario (minimo 3 caracteres)");
        
        if (string.IsNullOrWhiteSpace(maquina.CodigoGaia)) {
            errores.AddLast("Error de Registro: El código GAIA es obligatorio para unidades robóticas.");
        } 
        else {
            // 2. Validación de Formato (Regex)
            // Estructura esperada: MAQ-XXXX-X (Ejemplo: MAQ-0001-L)
            // ^MAQ -> Empieza por MAQ
            // -\d{4} -> Guion seguido de 4 dígitos
            // -[A-Z]$ -> Guion seguido de una letra mayúscula al final
            var patronGaia = @"^MAQ-\d{4}-[A-Z]$";
            
            if (!Regex.IsMatch(maquina.CodigoGaia, patronGaia)) {
                errores.AddLast($"Formato Inválido: '{maquina.CodigoGaia}' no sigue el protocolo estándar (MAQ-0000-X).");
            }
        }
        
        if (string.IsNullOrWhiteSpace(maquina.Descripcion) || maquina.Descripcion.Length < 3)
            errores.AddLast("La descripcion de la máquina es obligatorio (mínimo 3 caracteres).");
        
        if (string.IsNullOrWhiteSpace(maquina.DebilidadElemental))
            errores.AddLast("Protocolo de escaneo incompleto: La debilidad elemental debe estar definida.");
        
        if (!Enum.IsDefined(typeof(TipoMaquina), maquina.Tipo))
            errores.AddLast("Clasificación de máquina no reconocida por GAIA");
        
        if (!Enum.IsDefined(typeof(NivelAmenaza), maquina.Peligrosidad))
            errores.AddLast("Nivel de amenaza fuera de los parámetros establecidos.");
        
        return errores;
    }
}