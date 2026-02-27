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
        
        
        return errores;

    }
}