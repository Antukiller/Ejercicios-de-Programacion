using System.Text.RegularExpressions;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Validator;

public class RevistaValidator : IRevistaValidador {
    private const int MinTituloLength = 3;
    private const int MaxTituloLength = 100;
    private const int MaxCapacidadRevista = 60;
    private const int MinEdicion = 1;
    private const int MaxEdicion = 500;
    
    private readonly ILogger _log = Log.ForContext<RevistaValidator>();
    
    
    public Revista Validate(Revista revista) {
        _log.Debug("Iniciando validacion de revista: {Revista}", revista);

        if (string.IsNullOrWhiteSpace(revista.Titulo)) {
            _log.Warning("Validacion fallida: El titulo es ta vacio o es nulo");
            throw new ArgumentException("El titulo de la revista es obligatorio");
        }

        if (revista.Edicion < MinEdicion || revista.Edicion > MaxEdicion) {
            _log.Warning("Validacion fallida: Edicion {Edicion} fuera de rango", revista.Edicion);
            throw new ArgumentOutOfRangeException(
                nameof(revista.Edicion),
                $"El numero de edicion debe estar entre {MinEdicion} y  {MaxEdicion}"
            );
        }
        
        if (!ValidarEstante(revista.Estante, 'B', MaxCapacidadRevista)) {
            throw new ArgumentException($"El estante de revistas debe ser 'B-X' (1-{MaxCapacidadRevista}).");
        }
        
        var currentTituloLength = revista.Titulo.Length;
        if (currentTituloLength < MinTituloLength || revista.Titulo.Length > MaxTituloLength) {
            _log.Warning("Validacion fallida: Longitud de titulo de revista invalida");
            throw new ArgumentOutOfRangeException(nameof(revista.Titulo),$"El titulo debe de estar en {MinTituloLength} y  {MaxTituloLength} caracteres. Tiene {currentTituloLength}");
        }
        
        _log.Information("La validacion de revista se ha realizado correctamente : {TItulo}", revista);
        return revista;
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
}