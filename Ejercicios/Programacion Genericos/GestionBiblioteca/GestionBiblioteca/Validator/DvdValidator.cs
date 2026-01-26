using System.Text.RegularExpressions;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Validator;

public class DvdValidator : IDvdValidador {
    public const int MinDirectorLength = 3;
    public const int MaxDirectorLength = 100;
    private const int MinTituloLength = 3;
    private const int MaxTituloLength = 150;
    private const int MaxDuracionMinutos = 300;
    private const int MaxCapacidadEstanteDvd = 200;
    private static readonly string RegexDirector = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
    private static readonly string RegexEstanteLibro = @"^[A]-[0-9]{1,3}$";  
    
    private readonly ILogger _log =  Log.ForContext<DvdValidator>();
    
    public Dvd Validate(Dvd dvd) {
        _log.Debug("Iniciando validacion del dvd");

        if (string.IsNullOrWhiteSpace(dvd.Titulo)) {
            _log.Warning("Validacion fallida: El titulo del DVD esta vacio o es nulo");
            throw new ArgumentException("Titulo del DVD no puede estar vacio", nameof(dvd.Titulo));
        }

        if (string.IsNullOrWhiteSpace(dvd.Director)) {
            _log.Warning("Validacion fallida: El nombre del director esta vacio o es nulo");
            throw new ArgumentException("El nombre del director no puede estar vacio", nameof(dvd.Director));
        }
        
        var currentTituloLength = dvd.Titulo.Length;
        if (currentTituloLength < MinTituloLength || currentTituloLength > MaxTituloLength) {
            _log.Warning("Validacion fallida: La longitud del nombre del Titulo '{Titulo}' fuera de rango ({Min}-{Max}). Actual: {Current}}",
                dvd.Titulo,  MinTituloLength, MaxTituloLength, currentTituloLength);

            throw new ArgumentOutOfRangeException(
                nameof(dvd.Titulo),
                $"El Titulo del DVD debe tener entre {MinTituloLength} y {MaxTituloLength} caracteres. Tiene {currentTituloLength}"
            );
        }
        
        var currentDirectorLength = dvd.Director.Length;
        if (currentDirectorLength < MinDirectorLength || currentDirectorLength > MaxDirectorLength) {
            _log.Warning(
                "Validacion fallida: La longitud del nombre del director '{Director}' fuera de rango ({Min}-{Max}).Actual {current}",
                dvd.Director, MinDirectorLength, MaxDirectorLength, currentDirectorLength);

            throw new ArgumentOutOfRangeException(
                nameof(dvd.Director),
                $"El nombre del Director debe tener entre {MinDirectorLength} y  {MaxDirectorLength} caracteres. Tiene {currentDirectorLength}"
            );
        }

        var currentDuracionMinutos = MaxDuracionMinutos;
        if (dvd.Duracion < 0 || currentDuracionMinutos > MaxDuracionMinutos) {
            _log.Warning("Validacion fallida: La duracion del DVD '{Duracion}' es mayor del esperado {Max}. Actual: {Current}",
                dvd.Duracion, MaxDuracionMinutos, currentDuracionMinutos);

            throw new ArgumentOutOfRangeException(
                nameof(dvd.Duracion),
                $"La duracion del Dvd debe ser menor que {MaxDuracionMinutos} minutos. Tiene {currentDuracionMinutos}"
            );
        }
        
        
        if (!ValidadDirector(dvd.Director)) {
            _log.Warning("Validacion fallida: Director '{Director}' contiene caracteres invalidos",
                dvd.Director);
            throw new ArgumentException("El nombre completo contiene caracteres invalidos",
                nameof(dvd.Director));
        }
        
         
        if (!ValidarEstante(dvd.Estante, 'C', MaxCapacidadEstanteDvd)) {
            throw new ArgumentException($"El estante de revistas debe ser 'C-X' (1-{MaxCapacidadEstanteDvd}).");
        }

        if (!Enum.IsDefined(typeof(GeneroDvd), dvd.Genero)) {
            throw new ArgumentException("El genero seleccionado no es valido");
        }
        
        
        _log.Information("La validacion del DVD se ha realizado correctamente");
        return dvd;
    }
    
    
    private bool ValidarEstante(string estante, char letraEsperada, int capacidadMax) {
        if (string.IsNullOrWhiteSpace(estante)) return false;

        // 1. Validar formato básico con Regex (ej: A-12)
        if (!Regex.IsMatch(estante, $@"^[{letraEsperada}]-[0-9]+$")) return false;

        // 2. Extraer el número después del guion
        string parteNumerica = estante.Split('-')[1];
        if (int.TryParse(parteNumerica, out int numeroEstante)) {
            // 3. Validar capacidad
            return numeroEstante >= 1 && numeroEstante <= capacidadMax;
        }
        return false;
    }

    private bool ValidadDirector(string director) {
        return Regex.IsMatch(director, RegexDirector);
    }
}