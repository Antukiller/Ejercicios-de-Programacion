using System.Text.RegularExpressions;
using One_Piece_World.Enum;
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
    private static readonly string RegexBaseAsignada = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";

    private readonly ILogger _log = Log.ForContext<MarineValidator>();


    public Marine Validate(Marine marine) {
        _log.Debug("Iniciando validacion de Marine");
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
        if (currentBaseAsignadaLength < MinBaseAsignadaLength || currentBaseAsignadaLength > MaxBaseAsignadaLength) {
            _log.Warning("Validacion Fallida: La longitud de la base asignada '{BaseAsignada}' esta fuera de rango ({Min}-{Max}. Actual {Current})",
                marine.BaseAsignada, MinBaseAsignadaLength, MaxBaseAsignadaLength, currentBaseAsignadaLength);
            throw new ArgumentException(
                nameof(marine.BaseAsignada),
                $"La base asignada del marine tiene que tener entre {MinBaseAsignadaLength} y {MaxBaseAsignadaLength} caracteres. Tiene {currentBaseAsignadaLength}"
            );
        }

        if (!ValidadNombreCompleto(marine.NombreCompleto)) {
            _log.Warning("El nombre completo {NombreCompleto} contiene carateres invalidos,", 
                marine.NombreCompleto);
            throw new ArgumentException(
                $"El nombre completo '{marine.NombreCompleto}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(marine.NombreCompleto));
            
        }
        
        if (!ValidadApodo(marine.Apodo)) {
            _log.Warning("El apodo {Apodo} contiene carateres invalidos,", 
                marine.Apodo);
            throw new ArgumentException(
                $"El apodo '{marine.Apodo}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(marine.Apodo));
            
        }
        
        if (!ValidadBaseAsignada(marine.BaseAsignada)) {
            _log.Warning("La base asignada {BaseAginada} contiene carateres invalidos,", 
                marine.BaseAsignada);
            throw new ArgumentException(
                $"La base asignada '{marine.BaseAsignada}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(marine.BaseAsignada));
            
        }

        if (!System.Enum.IsDefined(typeof(RangoMarine), marine.Rango)) {
            _log.Warning("Validacion Fallida: El rango '{Rango}' no existe en el catálogo", marine.Rango);
            throw new ArgumentException("El rango seleccionado no es valido para un marine");
        }
        
        _log.Information("La validacion del Marine se ha realizado correctamente");
        return  marine;
        

    }


    private bool ValidadNombreCompleto(string nombreCompleto) {
        return Regex.IsMatch(nombreCompleto, RegexNombreCompleto);
    }

    private bool ValidadApodo(string apodo) {
        return Regex.IsMatch(apodo, RegexApodo);
    }

    private bool ValidadBaseAsignada(string baseAsignada) {
        return Regex.IsMatch(baseAsignada, RegexBaseAsignada);
    }
}