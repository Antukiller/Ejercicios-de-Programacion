using System.Text.RegularExpressions;
using SistemaGestiónNarutoWorld.Enums;
using SistemaGestiónNarutoWorld.Models;
using SistemaGestiónNarutoWorld.Validator.Common;

namespace SistemaGestiónNarutoWorld.Validator;

public class ValidadorJinchuriki : IValidador<Shinobi> {
    public IEnumerable<string> Validar(Shinobi shinobi) {
        var errores = new List<string>();
        
        if (shinobi is not Jinchuriki jinchuriki) {
            errores.Add("La entidad propocionada no es un jinchuriki");
            return errores;
        }
        
        if (string.IsNullOrWhiteSpace(jinchuriki.DniNinja) || !Regex.IsMatch(jinchuriki.DniNinja, @"^\d{4}[A-Z]{3}$"))
            errores.Add("El DNI del ninja debe tener el formato oficial (Ej: 1234ABC)");
        
        if (string.IsNullOrWhiteSpace(jinchuriki.Nombre) || jinchuriki.Nombre.Length < 3)
            errores.Add("El nombre del ninja es obligatorio (min. 3 caracteres)");
        
        if (!Enum.IsDefined(typeof(AldeaNinja), jinchuriki.Aldea))
            errores.Add("La aldea proporcionada no existe en los registros");
        
        if (jinchuriki.Edad is < 1 or > 150)
            errores.Add("El edad del shinobi debe de estar entre 1 y 150 años");
        
        if (!Enum.IsDefined(typeof(NombreBestia), jinchuriki.Bestia))
            errores.Add("La bestia con cola no esta registrada en los pergaminos");
        
        if (jinchuriki.NivelControlBestia is < 0.0 or > 10.0)
            errores.Add("EL nivel de control de la besti con cola debe estar entre 0 y 10");
        
        if (jinchuriki.ColasManifestadas is < 0 or > 9) 
            errores.Add("EL numero de colas manifestadas tiene que ser entre 1 y 10");

        return errores;
    }
}