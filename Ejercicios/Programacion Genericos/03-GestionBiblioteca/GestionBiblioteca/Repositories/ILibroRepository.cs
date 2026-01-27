using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using GestionBiblioteca.Repositories.Common;

namespace GestionBiblioteca.Repositories;

public interface ILibroRepository : ICrudRepository<int, Libro> {
    public int TotalLibros { get; }
    
    ILista<Libro> GetByLibrosOrderBy(TipoOrdenamientoLibro ordenamientoLibro = TipoOrdenamientoLibro.PorTitulo);
    
    Libro GetLibroIsbn(string isbn);
}