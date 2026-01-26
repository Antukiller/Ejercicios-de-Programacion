using Serilog;

namespace One_Piece_World.Validator.Common;

public class MarineValidator : IMarineValidator {
    private const int MinNombreCompletoLength = 3;
    private const int MaxNombreCompletoLength = 200;
    private const int MinApodoLength = 3;
    private const int MaxApodoLength = 200;
    private const int MinBaseAsignadaLength = 3;
    private const int MaxBaseAsignadaLength = 300;
    private static readonly string RegexNombreCompleto = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s\.]{3,}$";
    private static readonly string RegexApodo = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";

    private readonly ILogger _log = Log.ForContext<MarineValidator>();


    public Marine Validate(Marine marine) {
        // Validaciones de exitencia

        if (string.IsNullOrWhiteSpace(marine.NombreCompleto)) {
            _log.Warning("Validacion Fallida: El nombre del marine esta vacio o es nulo");
            throw new ArgumentException("El nombre del marine no puede estar vacio", nameof(marine.NombreCompleto));
        }

        if (string.IsNullOrWhiteSpace(marine.Apodo)) {
            _log.Warning("El apodo del marine esta vacio o es nulo");
            throw new ArgumentException("El apodo del marine esta vacio", nameof(marine.Apodo));
        }

        if (string.IsNullOrWhiteSpace(marine.BaseAsignada)) {
            _log.Warning("EL nombre de la base del marine esta vacia o es nula");
            throw new ArgumentException("La base del marine no puede estar vacia", nameof(marine.BaseAsignada));
        }
        
        // Validaciones de Longitud

        var currentNombreCompletoLength = marine.NombreCompleto.Length;
        if (currentNombreCompletoLength < MinNombreCompletoLength || currentNombreCompletoLength > MaxNombreCompletoLength) {
            _log.Warning("Validacion Fallida: La longitud del nombre del marine '{NombreCompleto}' esta fuera de rango ({Min}-{Max}). Actual {current}",
                marine.NombreCompleto, MinNombreCompletoLength, MaxNombreCompletoLength, currentNombreCompletoLength);
            throw new ArgumentOutOfRangeException(
                nameof(marine.NombreCompleto),
                $"El nombre completo del marine tiene que tener entre {MinNombreCompletoLength} y {MaxNombreCompletoLength} caracteres. Tiene {currentNombreCompletoLength}"
            );
        }

        var currentApodoLength = marine.Apodo.Length;
        if (currentApodoLength < MinApodoLength || currentApodoLength > MaxApodoLength) {
            _log.Warning("Validacion Fallida: La longitud del apodo del marine '{Apodo}' esta fuera de rango ({Min}-{Max}. Actual {Current})",
                marine.Apodo, MinApodoLength, MaxApodoLength, currentApodoLength);
            throw new ArgumentOutOfRangeException(
                nameof(marine.Apodo),
                $"El apodo del marine tiene que tener entre {MinApodoLength} y {MaxApodoLength} caracteres. Tiene {currentApodoLength}"
            );
        }

        var currentBaseAsignadaLength = marine.BaseAsignada.Length;

    }
}