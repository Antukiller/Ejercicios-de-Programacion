using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using GestionBiblioteca.Repositories.Common;

namespace GestionBiblioteca.Repositories;

public interface IDvdRepository : ICrudRepository<int, Dvd> {
    public int TotalDvds { get; }

    ILista<Dvd> GetByDvdsOrderBy(TipoOrdenamientoDvd ordenamientoDvd = TipoOrdenamientoDvd.PorGenero);
    
}