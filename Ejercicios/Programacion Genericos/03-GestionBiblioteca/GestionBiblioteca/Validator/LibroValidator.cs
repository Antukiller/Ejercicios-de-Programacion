using System.Text.RegularExpressions;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Validator;

public class LibroValidator : ILibroValidator {
    private const int MinTituloLength = 3;
    private const int MaxTituloLength = 100;
    private const int MaxCapacidadEstante = 100;
    private const int MinAutorLength = 3;
    private const int MaxAutorLength = 100;
    private const int MaxISBNLength = 13;
    private static readonly string RegexAutor = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
    // Acepta 10 o 13 dígitos numéricos, permitiendo guiones y espacios en cualquier posición
    private static readonly string RegexISBNFormato = @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d\- ]+$";
    private static readonly string RegexEstanteLibro = @"^[A]-[0-9]{1,3}$";

    private readonly ILogger _log = Log.ForContext<LibroValidator>();


    public Libro Validate(Libro libro) {
        _log.Debug("Inciando validacion para libro");

        // Validacion del Autor (Existencia)
        if (string.IsNullOrWhiteSpace(libro.Autor)) {
            _log.Warning("Validacion fallida: el nombre del autor esta vacio o es nulo");
            throw new ArgumentException("El nombre del autor no puede estar vacio.", nameof(libro.Autor));
        }

        // Validacion del Titulo (Exitencia)
        if (string.IsNullOrWhiteSpace(libro.Titulo)) {
            _log.Warning("Validacion Fallida: el titulo esta vacio o es nulo");
            throw new ArgumentException("El nombre del titulo no puede estar vacio");
        }

        if (!ValidarIsbnCompleto(libro.Isbn)) {
            _log.Warning("Validacion fallida: El ISBN '{Isbn}' no es valido o su formato es incorrecto", libro.Isbn);
            throw new ArgumentException("EL ISBN no es válido o su formato es incorrecto", nameof(libro.Isbn));
        }

        // Validacion del Titulo (Longitud)
        var currentTituloLength = libro.Titulo.Length;

        if (currentTituloLength < MinTituloLength || currentTituloLength > MaxTituloLength) {
            _log.Warning(
                "Validacion fallida: Lon  gitud del nombre del Titulo '{Titulo}' esta fuera de rango ({Min}-{Max}). Actual: {Current}}",
                libro.Titulo, MinTituloLength, MaxTituloLength, currentTituloLength);


            throw new ArgumentOutOfRangeException(
                nameof(libro.Titulo),
                $"El nombre del titulo debe estar entre {MinAutorLength} y {MaxAutorLength} caracteres. Tiene {currentTituloLength}"
            );

        }

        var currentAutorLength = libro.Autor.Length;

        if (currentAutorLength < MinAutorLength || currentAutorLength > MaxAutorLength) {
            _log.Warning(
                "Validacion fallida: Longitud del nombre del Autor '{Autor}' esta fuera de rango ({Min}-{Max}). Actual: {Current}",
                libro.Autor, MinAutorLength, MaxAutorLength, currentAutorLength);

            throw new ArgumentOutOfRangeException(
                nameof(libro.Autor),
                $"El nombre del titulo debe estar entre {MinAutorLength} y {MaxAutorLength} caracteres. Tiene {currentAutorLength}"
            );
        }

        if (!ValidadAutor(libro.Autor)) {
            _log.Warning("Validacion fallida: Autor '{Autor}' contiene caracteres invalidos",
                libro.Autor);
            throw new ArgumentException("El nombre completo contiene caracteres invalidos",
                nameof(libro.Autor));
        }
        
        if (!ValidarEstante(libro.Estante, 'A', MaxCapacidadEstante)) {
            throw new ArgumentException($"El estante de libros debe ser 'A-X' (1-{MaxCapacidadEstante}).");
        }
        
        
        _log.Information("La validacion de revista se ha realizado correctamente : {Libro}", libro);
        return libro;
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
    
    private bool ValidarIsbnCompleto(string isbn) {
        if (string.IsNullOrWhiteSpace(isbn)) return false;
        string isbnLimpio = Regex.Replace(isbn, @"[^\d]", ""); // Quita TODO lo que no sea número

        // Aceptamos 13 para el algoritmo matemático. 
        // Si quieres aceptar 10, necesitas otro algoritmo diferente.
        if (isbnLimpio.Length != 13) return false; 

        return CalcularAlgoritmoIsbn13(isbnLimpio);
    }

   


    private bool CalcularAlgoritmoIsbn13(string isbn) {
        int suma = 0;
        for (int i = 0; i < 12; i++) {
            int digito = int.Parse(isbn[i].ToString());
            suma += (i % 2 == 0) ? digito : digito * 3;
        }

        int resto = suma % 10;
        int digitoControlEsperado = (10 - resto) % 10;
        int digitoControlReal = int.Parse(isbn[12].ToString());

        return digitoControlEsperado == digitoControlReal;
    }
    
    

    private bool ValidadAutor(string autor) {
        return Regex.IsMatch(autor, RegexAutor);
    }
    

}