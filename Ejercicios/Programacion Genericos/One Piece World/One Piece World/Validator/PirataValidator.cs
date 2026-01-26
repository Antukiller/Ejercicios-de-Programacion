using System.Text.RegularExpressions;
using One_Piece_World.Enum;
using Serilog;

namespace One_Piece_World.Validator.Common;

public class PirataValidator : IPirataValidator {
    private const int MinNombreCompletoLength = 3;
    private const int MaxNombreCompletoLength = 200;
    private const int MinApodoCompletoLength = 3;
    private const int MaxApodoCompletoLength = 200;
    private const int MinTripulacionLength = 3;
    private const int MaxTripulacionLength = 350;
    private static readonly string RegexNombreCompleto = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s\.]{3,}$";
    private static readonly string RegexApodo = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s\.]{3,}$";
    private static readonly string RegexTripulacion = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
    


    private readonly ILogger _log = Log.ForContext<PirataValidator>();


    public Pirata Validate(Pirata pirata) {
        _log.Debug("Iniciando validacion de Pirata");

        // Validamos las exitencias
        if (string.IsNullOrWhiteSpace(pirata.NombreCompleto)) {
            _log.Warning("Validacion Fallida: El nombre comoleto del pirata esta vacio o es nulo");
            throw new ArgumentException("El nombre completo del pirata no puede estar vacio", nameof(pirata.NombreCompleto));
        }

        if (string.IsNullOrWhiteSpace(pirata.Apodo)) {
            _log.Warning("Validacion Fallida: El apodo del pirata esta vacio o es nulo");
            throw new ArgumentException("El apodo del pirata no puede estar vacio", nameof(pirata.Apodo));
        }

        if (string.IsNullOrWhiteSpace(pirata.Tripulacion)) {
            _log.Warning("La tripulacion del pirata esta vacia o es nula");
            throw new ArgumentException("El parametro de la tripulacion no puede estar vacio", nameof(pirata.Tripulacion));
        }
        
        // Validamos las longitudes
        var currentNombreCompletoLength = pirata.NombreCompleto.Length;
        if (currentNombreCompletoLength < MinNombreCompletoLength || currentNombreCompletoLength > MaxNombreCompletoLength) {
            _log.Warning(
                "Validacion Fallida: La longitud del nombre cmpleto del pirata '{NombreCompleto}' esta fuera del rango ({Min}-{Max}).Actual {current}",
                pirata.NombreCompleto, MinNombreCompletoLength, MaxNombreCompletoLength, currentNombreCompletoLength);

            throw new ArgumentOutOfRangeException(
                nameof(pirata.NombreCompleto),
                $"El nombre completo del pirata debe tener entre {MinNombreCompletoLength} y {MaxNombreCompletoLength} caracteres. Tiene {currentNombreCompletoLength}"
            );
        }


        var currentApodoLength = pirata.Apodo.Length;
        if (currentApodoLength < MinNombreCompletoLength || currentApodoLength > MaxNombreCompletoLength) {
            _log.Warning(
                "Validacion Fallida: La longitud del apodo '{Apodo}' esta fuera de rango ({Min}-{Max}).Actual {current}",
                pirata.Apodo, MinApodoCompletoLength, MaxApodoCompletoLength, currentApodoLength);
            throw new ArgumentOutOfRangeException(
                nameof(pirata.Apodo),
                $"El apodo del pirata debe tener entre {MinApodoCompletoLength} y {MaxApodoCompletoLength} caracteres. Tiene {currentApodoLength}"
            );
        }

        var currentTripulacionLength = pirata.Tripulacion.Length;
        if (currentTripulacionLength < MinTripulacionLength || currentTripulacionLength > MaxTripulacionLength) {
            _log.Warning(
                "Validacion Fallida: La longitud del parametro tripulacion '{Tripulacion}' esta fuera de rango ({Min}-{Max}). Actual: {Current}",
                pirata.Tripulacion, MinTripulacionLength, MaxTripulacionLength, currentTripulacionLength);

            throw new ArgumentOutOfRangeException(
                nameof(pirata.Tripulacion),
                $"El parametro de la tripulacion debe tener entre {MinTripulacionLength} y {MaxTripulacionLength} caracteres. Tiene {currentTripulacionLength}"
            );
        }
        

        if (!ValidadNombreCompleto(pirata.NombreCompleto)) {
            _log.Warning("Validacion Fallida: El nombre completo '{NombreCompleto}' contiene caracteres invalidos",
                pirata.NombreCompleto);
            throw new ArgumentException(
                $"El nombre '{pirata.NombreCompleto}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(pirata.NombreCompleto));
        }

        if (!ValidadApodo(pirata.Apodo)) {
            _log.Warning("Validacion Fallida: El apodo '{Apodo} contiene caracteres invalidos",
                pirata.Apodo);

            throw new ArgumentException(
                $"El apodo '{pirata.Apodo}' no es válido. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(pirata.Apodo));
        }

        if (!ValidadTripulacion(pirata.Tripulacion)) {
            _log.Warning("Validacion Fallida: La tripulacion '{Tripulacion}' contiene caracteres invalidos",
                pirata.Tripulacion);

            throw new ArgumentException(
                $"La tripulacion '{pirata.Tripulacion}' no es válida. Solo se permiten letras, espacios y puntos (mínimo 3 caracteres).",
                nameof(pirata.Tripulacion));
        }

        if (pirata.Recompensa < 0) {
            _log.Warning("Validacion Fallida: Recompensa negativa '{Recompensa}' para '{Nombre}'",
                pirata.Recompensa, pirata.NombreCompleto);

            throw new ArgumentException($"La recompensa '{pirata.Recompensa}' no puede ser negativa", 
                nameof(pirata.Recompensa));
        }

        if (!System.Enum.IsDefined(typeof(PosicionPirata), pirata.Posicion)) {
            _log.Warning("Validacion Fallida: La posición '{Posicion}' no existe en el catálogo", pirata.Posicion);
            throw new ArgumentException("La posicion sleccionada no es valida para un pirata");
        }
        
        
        _log.Information("La validacion del Pirata se ha realizado correctamente");
        return pirata;

    }

    private bool ValidadNombreCompleto(string nombreCompleto) {
        return Regex.IsMatch(nombreCompleto, RegexNombreCompleto);
    }

    private bool ValidadApodo(string apodo) {
        return Regex.IsMatch(apodo, RegexApodo);
    }

    private bool ValidadTripulacion(string tripulacion) {
        return Regex.IsMatch(tripulacion, RegexTripulacion);
    }
    
}