using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Factories;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Repositories;

public class RevistaRepositoryListaEnlazadaPropia : IRevistaRepository {
    private static RevistaRepositoryListaEnlazadaPropia? _instance;
    private static int _idCounter;
    private readonly ILista<Revista> _listaRevista =  new Lista<Revista>();
    private readonly ILogger _log = Log.ForContext<RevistaRepositoryListaEnlazadaPropia>();

    private RevistaRepositoryListaEnlazadaPropia() {
        _log.Debug("Creando instancia de RevistaRepository");

        InitDemoRevistas();
    }
    
    
    public ILista<Revista> GetAll() {
        _log.Debug("Obteniendo todas las revistas");
        return _listaRevista;
    }

    public Revista? GetById(int id) {
        _log.Debug("Obteniendo revista con id: {Id}");
        foreach(var revista in _listaRevista)
            if (revista.Id == id)
                return revista;
        return null;
    }

    public Revista? Create(Revista entity) {
        _log.Debug("Creando revista: {Revista}", entity);

        if (Exists(entity)) {
            _log.Warning("La revista ya existe");
            return null;
        }

        var saved = entity with {
            Id = GetNextId(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        _listaRevista.AgregarFinal(saved);
        return saved;

    }

    public Revista? Update(int id, Revista entity) {
        _log.Debug("Atualizando revista: {Id}", id);
        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("La revista con id: {Id} no existe", id);
            return null;
        }

        var updated = entity with {
            Id = id,
            UpdatedAt = DateTime.Now
        };
        
        _listaRevista.AgregarEn(updated, index);
        return updated;
    }

    public Revista? Delete(int id) {
        _log.Debug("Borrando revista con id: {Id}", id);

        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("La revista con id: {Id} no existe", id);
            return null;
        }

        var revistaToDelete = _listaRevista.Obterner(index) with {
            IsDeleted = true
        };
        
        _listaRevista.EliminarEn(index);
        return revistaToDelete;
    }

    public int TotalRevistas => _listaRevista.Contar();
    

    public ILista<Revista> GetByRevistaOrderBy(TipoOrdenamientoRevista ordenamientoRevista = TipoOrdenamientoRevista.PorEdicion) {
        _log.Debug("Ordenando revistas por {ordenamientoRevista}");
        var revistasArray = new Revista[_listaRevista.Contar()];
        var n = revistasArray.Length;
        // Copiamos los libros al array
        for (var i = 0; i < _listaRevista.Contar(); i++)
            revistasArray[i] = _listaRevista.Obterner(i);

        for (var i = 0; i < n - 1; i++) {
            for (var j = 0; j < n - i - 1; j++) {
                var debeIntercambiar = false;
                var revistaJ =  revistasArray[j];
                var revistaJ1 = revistasArray[j + 1];

                if (ordenamientoRevista == TipoOrdenamientoRevista.PorTitulo) {
                    if (string.Compare(revistaJ.Titulo, revistaJ1.Titulo, StringComparison.Ordinal) > 0)
                        debeIntercambiar = true;
                }

                else if (ordenamientoRevista == TipoOrdenamientoRevista.PorEdicion) {
                    if (revistaJ.Edicion < revistaJ1.Edicion) debeIntercambiar = true;
                }
                
                if (debeIntercambiar)
                    (revistasArray[j], revistasArray[j + 1]) = (revistasArray[j + 1], revistasArray[j]);
            }
        }
        
        var sortedList = new Lista<Revista>();
        foreach (var revista in revistasArray)
            sortedList.AgregarFinal(revista);
        return sortedList;
    }


    public static RevistaRepositoryListaEnlazadaPropia GetInstance() {
        return _instance ??= new RevistaRepositoryListaEnlazadaPropia();
    }
    

    private void InitDemoRevistas() {
        _log.Debug("Iniciando revistas de prueba");
        var demoRevistas = RevistaFactory.DemoData();
        foreach (var revista in demoRevistas )
            Create(revista);
    }

    private static int GetNextId() {
        return ++_idCounter;
    }

    private bool Exists(Revista revista) {
        _log.Debug("Comprobando existencia de la revista:  {Revista}", revista);
        foreach (var re in _listaRevista ) 
            if (re.Equals(revista))
                return true;
        return false;
    }

    private int IndexOf(int id) {
        _log.Debug("Buscando indice de la revista con id: {Id}", id);
        for (var i = 0; i < _listaRevista.Contar(); i++)
            if (_listaRevista.Obterner(i).Id == id)
                return i;
        return -1;
    }
    
    
}