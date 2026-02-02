using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Repositories.Common;

namespace Horizon_Forbidden_West.Repositories;

public interface IEntidadHorizonRepository : ICrudRepository<int, EntidadHorizon> {
    EntidadHorizon? GetByCodigoGaia(string codigoGaia);
    
    bool ExisteCodigoGaia(string codigoGaia);
}