using EmpresaHeroes.Models;
using EmpresaHeroes.Repositories.Common;

namespace EmpresaHeroes.Repositories;

public interface IHeroeRepository : ICrudRepository<int, Heroe> { }