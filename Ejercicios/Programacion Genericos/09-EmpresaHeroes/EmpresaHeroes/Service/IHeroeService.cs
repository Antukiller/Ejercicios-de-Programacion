using EmpresaHeroes.Enums;
using EmpresaHeroes.Models;

namespace EmpresaHeroes.Service;

using EmpresaHeroes.Models;

public interface IHeroesService 
{
    // --- CRUD Básico ---
    int TotalHeroes { get; }
    IEnumerable<Heroe> GetAll();
    Heroe GetById(int id);
    Heroe Save(Heroe heroe);
    Heroe Update(int id, Heroe heroe);
    Heroe Delete(int id);

    // --- Búsquedas Especializadas ---
    IEnumerable<Heroe> BuscarPorNombre(string nombre);
    IEnumerable<Heroe> ObtenerPorNivelMinimo(int nivel);

    // --- Lógica de Negocio ---
    void EntrenarHeroe(int id);
    void DescansarHeroe(int id);
    
    // --- Rankings ---
    IEnumerable<Heroe> GetTopPoderosos();

    // --- Misiones ---
    ResultadoMision ResolverMision(Mision mision);
}