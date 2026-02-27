using LaBoticaria.Enums;
using LaBoticaria.Validator.Common;

namespace LaBoticaria.Validator;

public class ValidadorAfrodisiaco : IValidador<Sustancia> {
    public IEnumerable<string> Validar(Sustancia s) {
        var errores = new List<string>();

        if (s is not Afrodisiacos a) {
            errores.Add("La sustancia proporcionada no es un afrodisíaco");
            return errores;
        }

        // 1. Validaciones heredadas de Sustancia
        if (string.IsNullOrWhiteSpace(a.Nombre) || a.Nombre.Length < 3)
            errores.Add("El nombre es obligatorio (mínimo 3 caracteres)");

        if (string.IsNullOrWhiteSpace(a.Descripcion) || a.Descripcion.Length < 3)
            errores.Add("La descripción es obligatoria (mínimo 3 caracteres)");

        if (a.Precio < 0)
            errores.Add("El precio no puede ser inferior a 0");

        if (!Enum.IsDefined(typeof(Disponibilidad), a.Rareza))
            errores.Add("La disponibilidad/rareza no es válida");

        if (!Enum.IsDefined(typeof(NivelPeligro), a.Peligro))
            errores.Add("El nivel de peligro no es válido");

        // 2. Validaciones específicas de Afrodisíaco
        if (!Enum.IsDefined(typeof(IntensidadEfecto), a.CategoriaEfecto))
            errores.Add("La categoría de intensidad del efecto no es válida");

        if (a.Duracion <= 0)
            errores.Add("La duración del efecto debe ser mayor a cero minutos");

        // 3. Validación de Contraindicaciones
        if (a.ListaContradicciones != null && a.ListaContradicciones.Any()) {
            foreach (var contra in a.ListaContradicciones) {
                if (string.IsNullOrWhiteSpace(contra.Nombre))
                    errores.Add("Una contraindicación no tiene un nombre válido");
                
                if (contra.Riesgo is < 0 or > 10)
                    errores.Add($"El riesgo de la contraindicación '{contra.Nombre}' debe estar entre 0 y 10");

                if (string.IsNullOrWhiteSpace(contra.Descripcion))
                    errores.Add($"La contraindicación '{contra.Nombre}' requiere una descripción");
            }
        }

        // 4. Validación de Riesgos Excesivos (Por sobredosis)
        if (a.ListaRiesgosExcivos == null || !a.ListaRiesgosExcivos.Any()) {
            errores.Add("Debe registrar al menos un riesgo por exceso de consumo");
        }
        else {
            foreach (var riesgo in a.ListaRiesgosExcivos) {
                if (string.IsNullOrWhiteSpace(riesgo.Nombre))
                    errores.Add("Uno de los riesgos excesivos no tiene nombre");

                if (riesgo.Riesgo is < 0 or > 10)
                    errores.Add($"El nivel de riesgo de '{riesgo.Nombre}' debe estar entre 0 y 10");

                if (string.IsNullOrWhiteSpace(riesgo.Descripcion))
                    errores.Add($"El riesgo '{riesgo.Nombre}' requiere una descripción del efecto");
            }
        }

        return errores;
    }
}