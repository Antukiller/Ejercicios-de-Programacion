using System.Text.RegularExpressions;
using One_Piece_World.Enum;
using Serilog;

namespace One_Piece_World.Validator.Common;

public class FrutaDelDiabloValidator : IFrutaDelDiablo {
    private const int MinNombreCompletoLength = 3;
    private const int MaxNombreCompletoLength = 300;
    private const int MinApodoLength = 3;
    private const int MaxApodoLength = 300;
    private static readonly string RegexNombreCompleto = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s\.]{3,}$";
    private static readonly string RegexApodo = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
    
    private readonly ILogger _log = Log.ForContext<FrutaDelDiabloValidator>();
    
    
    public FrutaDelDiablo Validate(FrutaDelDiablo frutaDelDiablo) {
        _log.Debug("Iniciando validacion de Fruta del Diablo");
        
        // Validamos exitencias
        if (string.IsNullOrWhiteSpace(frutaDelDiablo.NombreCompleto)) {
            _log.Warning("Validacion Fallida: El nombre de la fruta del diablo esta vacio o es nulo");
            throw new ArgumentException("El nombre de la fruta del diablo no puede estar vacio", nameof(frutaDelDiablo.NombreCompleto));
        }

        if (string.IsNullOrWhiteSpace(frutaDelDiablo.Apodo)) {
            _log.Warning("El apodo de la fruta del diablo esta vacio o es nulo");
            throw new ArgumentException("El apodo de la fruta del diablo esta vacio", nameof(frutaDelDiablo.Apodo));
        }
        
        
        // Validamos longitud
        var currentNombreCompletoLength = frutaDelDiablo.NombreCompleto.Length;
        if (currentNombreCompletoLength < MinNombreCompletoLength || currentNombreCompletoLength > MaxNombreCompletoLength) {
            _log.Warning("Validacion Fallida: La longitud del nombre de la fruta del diablo '{NombreCompleto}' esta fuera de rango ({Min}-{Max}). Actual {current}",
                frutaDelDiablo.NombreCompleto, MinNombreCompletoLength, MaxNombreCompletoLength, currentNombreCompletoLength);
            throw new ArgumentOutOfRangeException(
                nameof(frutaDelDiablo.NombreCompleto),
                $"El nombre completo de la fruta del diablo tiene que tener entre {MinNombreCompletoLength} y {MaxNombreCompletoLength} caracteres. Tiene {currentNombreCompletoLength}"
            );
        }

        var currentApodoLength = frutaDelDiablo.Apodo.Length;
        if (currentApodoLength < MinApodoLength || currentApodoLength > MaxApodoLength) {
            _log.Warning("Validacion Fallida: La longitud de la fruta del diablo '{Apodo}' esta fuera de rango ({Min}-{Max}. Actual {Current})",
                frutaDelDiablo.Apodo, MinApodoLength, MaxApodoLength, currentApodoLength);
            throw new ArgumentOutOfRangeException(
                nameof(frutaDelDiablo.Apodo),
                $"El apodo de la fruta del diablotiene que tener entre {MinApodoLength} y {MaxApodoLength} caracteres. Tiene {currentApodoLength}"
            );
        }
        
        if (!ValidadNombreCompleto(frutaDelDiablo.NombreCompleto)) {
            _log.Warning("El nombre completo {NombreCompleto} contiene carateres invalidos,", 
                frutaDelDiablo.NombreCompleto);
            throw new ArgumentException(
                $"El nombre completo '{frutaDelDiablo.NombreCompleto}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(frutaDelDiablo.NombreCompleto));
            
        }
        
        if (!ValidadApodo(frutaDelDiablo.Apodo)) {
            _log.Warning("El apodo {Apodo} contiene carateres invalidos,", 
                frutaDelDiablo.Apodo);
            throw new ArgumentException(
                $"El apodo '{frutaDelDiablo.Apodo}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(frutaDelDiablo.Apodo));
        }
        
        if (!System.Enum.IsDefined(typeof(TipoFruta), frutaDelDiablo.Fruta)) {
            _log.Warning("Validacion Fallida: La fruta '{Fruta}' no existe en el catálogo", frutaDelDiablo.Fruta);
            throw new ArgumentException("La fruta seleccionada no es valida para una fruta");
        }
        
        
        _log.Information("La validacion de la Fruta del Diablo se ha realizado correctamente");
        return frutaDelDiablo;

    }


    private bool ValidadNombreCompleto(string nombreComopleto) {
        return Regex.IsMatch(nombreComopleto, RegexNombreCompleto);
    }
    
    private bool ValidadApodo(string Apodo) {
        return Regex.IsMatch(Apodo, RegexApodo);
    }
}