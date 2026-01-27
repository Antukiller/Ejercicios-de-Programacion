using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using GestionBiblioteca.Repositories;
using GestionBiblioteca.Validator;
using Serilog;

namespace GestionBiblioteca.Services;

public class BibliotecaService(
    ILibroRepository libroRepository,
    IRevistaRepository revistaRepository,
    IDvdRepository dvdRepository,
    ILibroValidator libroValidator,
    IRevistaValidador revistaValidator,
    IDvdValidador dvdValidator
) : IBibliotecaService {
    
    private readonly ILogger _log = Log.ForContext<BibliotecaService>();


    public int TotalLibros { get; } = libroRepository.TotalLibros;
    
    public Libro? GetLibroById(int id) {
        _log.Information("Obteniendo libro por Id: {Id}", id);
        return libroRepository.GetById(id)
            ?? throw new KeyNotFoundException($"No se encontro libro con Id: {id}");
    }

    public Libro? GetLibroByIsbn(string isbn) {
        return libroRepository.GetLibroIsbn(isbn)
            ?? throw new KeyNotFoundException($"No se encontro libro con Isbn {isbn}");
    }

    public Libro SaveLibro(Libro libro) {
        _log.Information("Guardando nuevo libro: {Libro}", libro);
        var libroValidado =  libroValidator.Validate(libro);
        return libroRepository.Create(libroValidado) ?? throw new ArgumentException(
            $"No se puedo guardar el libro con Isbn {libroValidado.Isbn}, puede que ya exista");
    }

    public Libro UpdateLibro(Libro libro) {
        _log.Information("Actulizando libro: {Libro}", libro);
        var libroValidado = libroValidator.Validate(libro);
        return libroRepository.Update(libroValidado.Id, libroValidado)
               ?? throw new KeyNotFoundException(
                   $"Libro con Id {libroValidado.Id} no encontrado para actualizacion");
    }

    public Libro DeleteLibro(int id) {
        _log.Information("Eliminando libro con Id: {Libro}", id);
        return libroRepository.Delete(id)
            ?? throw new KeyNotFoundException($"No se encontro libro con Id {id} para su eliminacion");
    }

    public ILista<Libro> GetLibrosOrdenados(TipoOrdenamientoLibro orden) {
        _log.Information("Obteniendo todos los libros con ordenamiento: {Orden}", orden);
        return libroRepository.GetByLibrosOrderBy(orden);
    }

    public int TotalRevistas { get; } = revistaRepository.TotalRevistas;
    
    public Revista? GetRevistaById(int id) {
        _log.Information("Obteniendo Revista con Id: {id}", id);
        return revistaRepository.GetById(id)
            ?? throw new KeyNotFoundException($"No se encontro revista con Id: {id}");
    }

    public Revista SaveRevista(Revista revista) {
        _log.Information("Guardando nueva revista: {Revista}", revista);
        var revistaValidado = revistaValidator.Validate(revista);
        return revistaRepository.Create(revistaValidado) ?? throw new ArgumentException(
            $"No se pudo guardar la revista con Id {revistaValidado.Id},  puede que ya exista");
    }

    public Revista UpdateRevista(Revista revista) {
        _log.Information("Actualizando revista: {Revista}", revista);
        var revistaValidado = revistaValidator.Validate(revista);
        return revistaRepository.Update(revistaValidado.Id, revistaValidado) ?? throw new KeyNotFoundException("" +
            $"Revista con Id {revistaValidado.Id} no encontrado para actualizacion");
    }

    public Revista DeleteRevista(int id) {
        _log.Information("Eliminando revista: {Revista}", id);
        return revistaRepository.Delete(id) 
            ?? throw new KeyNotFoundException($"No se encontro Revista con Id: {id} para su eliminacion");
    }

    public ILista<Revista> GetRevistasOrdenadas(TipoOrdenamientoRevista orden) {
        _log.Information("Obteniendo todas las revistas con odenamiento: {Orden}", orden);
        return revistaRepository.GetByRevistaOrderBy(orden);
    }

    public int TotalDvds { get; } = dvdRepository.TotalDvds;
    
    public Dvd SaveDvd(Dvd dvd) {
        _log.Information("Guardando Dvd con Id: {Id}", dvd);
        var dvdValidado = dvdValidator.Validate(dvd);
        return dvdRepository.Create(dvdValidado)  ?? throw new ArgumentException(
            $"No se puedo guardar el Dvd con Id {dvdValidado.Id},   puede que ya exista");
    }

    public Dvd? GetDvdById(int id) {
        _log.Information("Obteniendo Dvd con Id: {Id}", id);
        return dvdRepository.GetById(id) 
            ?? throw new KeyNotFoundException($"No se encontro Dvd con Id: {id}");
    }

    public Dvd UpdateDvd(Dvd dvd) {
        var dvdValidado = dvdValidator.Validate(dvd);
        return dvdRepository.Update(dvdValidado.Id, dvdValidado) ??  throw new KeyNotFoundException(
            $"Dvd con Id {dvdValidado.Id} no encontrado para actualizacion");
    }

    public Dvd DeleteDvd(int id) {
        _log.Information("Eliminando Dvd con Id: {Id}", id);
        return dvdRepository.Delete(id)
            ?? throw new KeyNotFoundException($"No se encontro Dvd con Id: {id} para su eliminacion" );
    }

    public ILista<Dvd> GetDvdsOrdenados(TipoOrdenamientoDvd orden) {
        _log.Information("Obteniendo todos los dvds por ordenamiento: {Orden}", orden);
        return dvdRepository.GetByDvdsOrderBy(orden);
    }

    public InformeBiblioteca GenerarInforme() {
        _log.Information("Generando informe estadístico de la biblioteca");

        // 1. Obtener totales actuales
        int nLibros = TotalLibros;
        int nRevistas = TotalRevistas;
        int nDvds = TotalDvds;
        int total = nLibros + nRevistas + nDvds;

        // 2. Calcular porcentajes (con lógica de seguridad para evitar división por 0)
        // Usamos (double) para que la división no sea entera (ej: 1/2 = 0.5, no 0)
        double pLibros = total > 0 ? Math.Round((double)nLibros / total * 100, 2) : 0;
        double pRevistas = total > 0 ? Math.Round((double)nRevistas / total * 100, 2) : 0;
        double pDvds = total > 0 ? Math.Round((double)nDvds / total * 100, 2) : 0;

        _log.Debug("Informe generado con éxito. Total fichas: {Total}", total);

        return new InformeBiblioteca(
            TotalFichas: total,
            TotalLibros: nLibros,
            TotalRevistas: nRevistas,
            TotalDvds: nDvds,
            PorcentajeLibros: pLibros,
            PorcentajeRevistas: pRevistas,
            PorcentajeDvds: pDvds
        );
    }
}