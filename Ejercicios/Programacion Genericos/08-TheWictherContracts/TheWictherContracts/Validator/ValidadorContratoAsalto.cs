using TheWictherContracts.Models;
using TheWictherContracts.Validator.Common;

namespace TheWictherContracts.Validator;

public class ValidadorContratoAsalto : IValidador<ContratoBase> {
    public IEnumerable<string> Validar(ContratoBase contrato) {
        var errores = new List<string>();

        if (contrato is not ContratoAsalto a) {
            errores.Add("Error: El tipo de contrato no corresponde a un Asalto Militar.");
            return errores;
        }

        // Validación de Título (ojo con la 'T' mayúscula)
        if (string.IsNullOrWhiteSpace(a.Titulo) || a.Titulo.Length < 5)
            errores.Add("El título de la orden militar debe ser más descriptivo (mín. 5 caracteres).");
        
        // Validación de Nivel (corregido el rango)
        if (a.NivelRecomendado is < 1 or > 100)
            errores.Add("El nivel de peligrosidad debe estar en el rango de 1 a 100.");
        
        // Validación de Recompensa
        if (a.Recompensa < 250)
            errores.Add("Presupuesto insuficiente: Los asaltos requieren un mínimo de 250 orens.");

        // Validación de Lógica de Combate
        if (a.NumeroEnemigos > 10 && a.RequiereSigilo) 
            errores.Add("Incoherencia táctica: No se puede exigir sigilo contra un destacamento de más de 10 enemigos.");

        if (a.NumeroEnemigos <= 0)
            errores.Add("No hay objetivos detectados. El número de enemigos debe ser mayor a 0.");
        
        return errores;
    }
}