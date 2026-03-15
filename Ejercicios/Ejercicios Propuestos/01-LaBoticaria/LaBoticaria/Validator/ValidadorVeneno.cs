using LaBoticaria.Enums;
using LaBoticaria.Validator.Common;

namespace LaBoticaria.Validator;

public class ValidadorVeneno : IValidador<Sustancia> {
    public IEnumerable<string> Validar(Sustancia s) {
        var errores = new List<string>();


        if (s is not Veneno v) {
            errores.Add("La sustancia proporcionada no es un veneno");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(v.Nombre) || v.Nombre.Length < 3)
            errores.Add("El nombre del veneno es obligatorio (minimo 3 caracteres)");
        
        if (string.IsNullOrWhiteSpace(v.Descripcion) || v.Descripcion.Length < 3)
            errores.Add("La descripcion del veneno es obligatoria (minimo 3 caracteres)");
        
        if (v.Precio < 0)
            errores.Add("El precio del veneno tiene que ser mayor a cero");
        
        if (!Enum.IsDefined(typeof(Disponibilidad), v.Rareza))
            errores.Add("La rareza del veneno no es acorde a las registradas");
        
        if (!Enum.IsDefined(typeof(NivelPeligro), v.Peligro))
            errores.Add("EL nivel de peligro no es acorde con la sustancia proporcionada");
        
        if (!Enum.IsDefined(typeof(ViaAdministracion), v.Suministro))
            errores.Add("Las formas de suministrar el veneno no es acorde a los terminos establecidos");
        
        if (v.TiempoAparicion < 0)
            errores.Add("El tiempo de aparicion debe ser mayor a cero");
        
        if (v.GradoToxicidad is < 0.0 or > 100.0)
            errores.Add("El grado de toxicidad debe estar entre 0.0 y 100.0");
        
        if (v.ProbalidadSupevivencia is < 0 or > 100)
            errores.Add("La probabilidad de supervivencia debe de estar entre 0 y 100");

        if (v.ListaSintomas == null || !v.ListaSintomas.Any()) 
        {
            errores.Add("La sustancia debe tener al menos un síntoma registrado para su diagnóstico");
        }
        else 
        {
            foreach (var sintoma in v.ListaSintomas) 
            {
                if (string.IsNullOrWhiteSpace(sintoma.Nombre))
                    errores.Add("Uno de los síntomas no tiene nombre definido");

                if (sintoma.Riesgo is < 0 or > 10)
                    errores.Add($"El nivel de riesgo de '{sintoma.Nombre}' debe estar entre 0 y 10");

                if (string.IsNullOrWhiteSpace(sintoma.Organo))
                    errores.Add($"El síntoma '{sintoma.Nombre}' no tiene un órgano afectado registrado");

                if (string.IsNullOrWhiteSpace(sintoma.Descripcion))
                    errores.Add($"El síntoma '{sintoma.Nombre}' requiere una descripción clínica");
            }
        }
        
        
        if (v.ListaAntidotos == null || !v.ListaAntidotos.Any()) 
        {
            // Regla de Maomao: Un veneno sin antídoto es una sentencia de muerte
            if (v.Peligro == NivelPeligro.Extremo)
                errores.Add($"CRÍTICO: El veneno extremo '{v.Nombre}' no tiene antídotos conocidos registrados");
        }
        else 
        {
            foreach (var antidoto in v.ListaAntidotos) 
            {
                if (string.IsNullOrWhiteSpace(antidoto.Nombre))
                    errores.Add("Uno de los antídotos no tiene nombre");

                if (antidoto.Efectividad is < 1 or > 10)
                    errores.Add($"La efectividad de '{antidoto.Nombre}' debe ser una escala del 1 al 10");

                if (string.IsNullOrWhiteSpace(antidoto.Metodo))
                    errores.Add($"El antídoto '{antidoto.Nombre}' debe especificar un método de suministro (Ingestión, IV, etc.)");

                if (string.IsNullOrWhiteSpace(antidoto.Descripcion))
                    errores.Add($"El antídoto '{antidoto.Nombre}' requiere una descripción de su mecanismo de acción");
            }
        }
            
        
        return errores;

    }
}