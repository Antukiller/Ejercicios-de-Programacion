using One_Piece_World.Collections;
using Serilog;

namespace One_Piece_World.Repositories;

public class EntidadRepositoryListaEnlazadaPropia : IEntidadReposytory {
    private static EntidadRepositoryListaEnlazadaPropia? _instance;
    private static int _idCounter;
    private readonly ILista<Entidad> _listado = new Lista<Entidad>();
    private readonly ILogger _log = Log.ForContext<EntidadRepositoryListaEnlazadaPropia>();
    
    
    
    
    public ILista<Entidad> GetAll() {
        return _listado;
    }

    public Entidad? GetById(int id) {
        
    }

    public Entidad? Create(Entidad entity) {
        throw new NotImplementedException();
    }

    public Entidad? Update(int id, Entidad entity) {
        throw new NotImplementedException();
    }

    public Entidad? Delete(int id) {
        throw new NotImplementedException();
    }

    public int TotalEntidades { get; }
}