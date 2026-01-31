using System.Text.RegularExpressions;
using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Validator.Common;

namespace Horizon_Forbidden_West.Validator;

public class SaboteadorValidador : IValidador<EntidadHorizon> {
    public ILista<string> Validar(EntidadHorizon entidad) {
        var errores = new Lista<string>();

        if (entidad is not Saboteador saboteador) {
            errores.AddLast("Error Crítico: La entidad no es un saboteador procesable.");
            return errores;
        }
        
        // Validación de Identidad
        if (string.IsNullOrWhiteSpace(saboteador.NombreCompleto) || saboteador.NombreCompleto.Length < 3)
            errores.AddLast("El nombre del saboteador es obligatorio (mínimo 3 caracteres).");

        // Validación de Código GAIA (Asegurando el inicio con ^)
        if (!string.IsNullOrWhiteSpace(saboteador.CodigoGaia)) {
            var patronGaia = @"^SAB-\d{4}-[A-Z]$"; 
            if (!Regex.IsMatch(saboteador.CodigoGaia, patronGaia)) {
                errores.AddLast($"Protocolo Inválido: '{saboteador.CodigoGaia}' no cumple el formato de saboteador (SAB-0000-X).");
            }
        }
        
        // Validación de Área Maestra
        if (string.IsNullOrWhiteSpace(saboteador.AreaMaestra))
            errores.AddLast("El área maestra tecnológica debe estar definida para el sabotaje.");
        
        // Validación de Experiencia (Lore: más de 70 años es poco probable para un humano vivo)
        if (saboteador.añosExperiencia < 0 || saboteador.añosExperiencia > 70) 
            errores.AddLast("Rango de experiencia inválido: debe estar entre 0 y 70 años.");
        
        // Validación de Enums
        if (!Enum.IsDefined(typeof(FaccionTecnologica), saboteador.Faccion))
            errores.AddLast("La facción tecnológica no está reconocida en la red.");
        
        if (!Enum.IsDefined(typeof(CertificadoCaldero), saboteador.Certificado))
            errores.AddLast("El certificado del caldero no es válido para este perfil.");
        
        // Regla de Negocio Extra (Opcional pero pro)
        if (saboteador.Faccion == FaccionTecnologica.Eclipse && saboteador.añosExperiencia < 10) {
            errores.AddLast("Inconsistencia: Un saboteador del Eclipse requiere al menos 10 años de experiencia técnica.");
        }
        
        return errores;
    }
}