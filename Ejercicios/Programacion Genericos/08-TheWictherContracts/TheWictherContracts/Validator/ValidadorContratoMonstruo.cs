using TheWictherContracts.Enums;
using TheWictherContracts.Models;
using TheWictherContracts.Validator.Common;

namespace TheWictherContracts.Validator;

public class ValidadorContratoMonstruo : IValidador<ContratoBase> {
    public IEnumerable<string> Validar(ContratoBase contrato) {
        var errores = new List<string>();

        // 1. Verificación de tipo (Pattern Matching)
        if (contrato is not ContratoMonstruo m) {
            errores.Add("Error: Se esperaba un contrato de monstruo.");
            return errores;
        }
        
        // 2. Validaciones de lógica de negocio
        if (string.IsNullOrWhiteSpace(m.Titulo) || m.Titulo.Length < 5)
            errores.Add("El tablón requiere un título más descriptivo (mín. 5 letras).");

        if (m.NivelRecomendado is < 1 or > 100)
            errores.Add("El nivel debe estar entre 1 y 100.");

        if (m.Recompensa <= 100)
            errores.Add("Un brujo no desenfunda la espada por 100 monedas.");

        if (!Enum.IsDefined(typeof(EspecieCriatura), m.Monstruo))
            errores.Add("Especie de monstruo desconocida o no registrada.");
        
        return errores;
    }
}