using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;

namespace GestionBiblioteca.Services;

public interface IBibliotecaService {

    // 1. Operaciones de Libros
    int TotalLibros { get; }
    Libro? GetLibroById(int id);
    Libro? GetLibroByIsbn(string isbn);
    Libro SaveLibro(Libro libro);
    Libro UpdateLibro(Libro libro);
    Libro DeleteLibro(int id);
    ILista<Libro> GetLibrosOrdenados(TipoOrdenamientoLibro orden);

    // 2. Operaciones de Revistas
    int TotalRevistas { get; }
    Revista? GetRevistaById(int id);
    Revista SaveRevista(Revista revista);
    Revista UpdateRevista(Revista revista);
    Revista DeleteRevista(int id);
    ILista<Revista> GetRevistasOrdenadas(TipoOrdenamientoRevista orden);

    // 3. Operaciones de DVDs
    int TotalDvds { get; }
    Dvd SaveDvd(Dvd dvd);
    Dvd? GetDvdById(int id);
    Dvd UpdateDvd(Dvd dvd);
    Dvd DeleteDvd(int id);
    ILista<Dvd> GetDvdsOrdenados(TipoOrdenamientoDvd orden);

    // 4. Informe (El que unifica todo)
    InformeBiblioteca GenerarInforme();
}