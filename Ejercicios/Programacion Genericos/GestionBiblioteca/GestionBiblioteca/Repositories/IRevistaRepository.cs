using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using GestionBiblioteca.Repositories.Common;

namespace GestionBiblioteca.Repositories;

public interface IRevistaRepository : ICrudRepository<int, Revista> {
    public int TotalRevistas { get; }
    
    ILista<Revista> GetByRevistaOrderBy(TipoOrdenamientoRevista ordenamientoRevista = TipoOrdenamientoRevista.PorEdicion);
}