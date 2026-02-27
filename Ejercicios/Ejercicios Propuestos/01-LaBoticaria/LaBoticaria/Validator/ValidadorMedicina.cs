using LaBoticaria.Enums;
using LaBoticaria.Validator.Common;

namespace LaBoticaria.Validator;

public class ValidadorMedicina : IValidador<Sustancia> {
    public IEnumerable<string> Validar(Sustancia s) {
        var errores = new List<string>();
        
        if (s is not Medicina m){
           errores.Add("La sustancia proporcionada no es una medicina");
           return errores;
        }

        if (string.IsNullOrWhiteSpace(m.Nombre) || m.Nombre.Length < 3) 
            errores.Add("El nombre de la medicina es obligatorio (min 3 caracteres)");
        
        if (string.IsNullOrWhiteSpace(m.Descripcion) || m.Descripcion.Length < 3)
            errores.Add("La descripcion de la medicina es obligatorio  (min 3 caracteres)");
        
        if (m.Precio < 0) 
            errores.Add("El precio tiene que ser superior a 0");
        
        if (!Enum.IsDefined(typeof(Disponibilidad), m.Rareza))
            errores.Add("La rareza de la medicina no es apta");
        
        if (!Enum.IsDefined(typeof(NivelPeligro), m.Peligro))
            errores.Add("EL peligro de la medicina no es apta");
        
        if (m.DosisRecomendada is < 0  or > 1000)
            errores.Add("La dosis de la medicina tiene que estar entre 0 y 1000 mililitros");
        

        if (m.ListaEfectosSecundarios == null || !m.ListaEfectosSecundarios.Any()) {
            errores.Add("Al menos un sintoma tiene que tener un efecto secundario");
        }
        else {
            foreach (var efectoSecundario in m.ListaEfectosSecundarios ) {
                if (string.IsNullOrWhiteSpace(efectoSecundario.Nombre))
                    errores.Add("Uno de los efectos secundarios no tiene un nombre valido");
                
                if (efectoSecundario.Riesgo <  0 || efectoSecundario.Riesgo > 10 )
                    errores.Add($"El efecto secundario {efectoSecundario.Nombre} debe estar entre 0 y 10");
                
                if (string.IsNullOrWhiteSpace(efectoSecundario.Organo))
                    errores.Add("Se debe especificar el organo afectado por efecto secundario");
                
                if (string.IsNullOrWhiteSpace(efectoSecundario.Descripcion))
                    errores.Add("Debe de haber una descripcion del efecto secundario");
            }
        }
        
        if (m.TiempoEfecto < 0) 
            errores.Add("El tiempo de duracion no puede ser inferior a 0");
        
        return errores;

    }
}