using LaBoticaria.Enums;
using LaBoticaria.Validator.Common;

namespace LaBoticaria.Validator;

public class ValidadorCasoMedico : IValidador<CasoMedico> {
    public IEnumerable<string> Validar(CasoMedico c) {
        var errores = new List<string>();
        
        if (c is not CasoMedico m) {
            errores.Add("La entidad proporcionada no es un caso medico");
            return errores;
        }

        if (m.SintomasObservados == null || m.SintomasObservados.Any()) {
            foreach (var sintoma in  m.SintomasObservados ) {
                if (string.IsNullOrWhiteSpace(sintoma.Nombre))
                    errores.Add("El nombre del sintoma es requerido");
                    
                if (string.IsNullOrWhiteSpace(sintoma.Descripcion))
                    errores.Add("El descripcion del sintoma es requerido");
                
                if (string.IsNullOrWhiteSpace(sintoma.Organo))
                    errores.Add("El organo es requerido");
                
                if (sintoma.Riesgo is < 0 or > 10)
                    errores.Add("El riesgo no puede ser menor que 0 y mayor que 10");
            }
        }
        
        if (!Enum.IsDefined(typeof(CausaSospecha), m.Causa))
            errores.Add("La causa no esta definida");
        
        if (!Enum.IsDefined(typeof(EstadoInvestigacion), m.Investigacion))
            errores.Add("El riesgo no esta definido");
        
        if (!Enum.IsDefined(typeof(Gravedad), m.Transcendencia))
            errores.Add("La trancenda no esta definida");
        
        return errores;
        
    }
}