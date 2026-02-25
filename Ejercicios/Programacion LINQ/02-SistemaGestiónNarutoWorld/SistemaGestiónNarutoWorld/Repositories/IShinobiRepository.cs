using SistemaGestiónNarutoWorld.Models;
using SistemaGestiónNarutoWorld.Repositories.Common;

namespace SistemaGestiónNarutoWorld.Repositories;

public interface IShinobiRepository : ICrudRepository<int, Shinobi> {

    Shinobi? GetByDniNinja(string dniNinja);

    bool ExisteDniNinja(string dniNinja);
}