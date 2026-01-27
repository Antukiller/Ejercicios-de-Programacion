using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Factories;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Repositories;

public class DvdRepositoryListaEnlazadaPropia : IDvdRepository {
    private static DvdRepositoryListaEnlazadaPropia? _instance;
    private static int _idCounter;
    private readonly ILista<Dvd> _listadoDvd = new Lista<Dvd>();
    private readonly ILogger _log = Log.ForContext<DvdRepositoryListaEnlazadaPropia>();
    
     private DvdRepositoryListaEnlazadaPropia() {
        _log.Debug("Creando instancia de DvdRepository");

        InitDemoDvd();
    }
    
    
    public ILista<Dvd> GetAll() {
        _log.Debug("Obteniendo todos los Dvds");
        return _listadoDvd;
    }

    public Dvd? GetById(int id) {
        _log.Debug("Obteniendo Dvd con id: {Id}");
        foreach(var revista in _listadoDvd)
            if (revista.Id == id)
                return revista;
        return null;
    }

    public Dvd? Create(Dvd entity) {
        _log.Debug("Creando Dvd: {Dvd}", entity);

        if (Exists(entity)) {
            _log.Warning("El Dvd ya existe");
            return null;
        }

        var saved = entity with {
            Id = GetNextId(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        _listadoDvd.AgregarFinal(saved);
        return saved;

    }

    public Dvd? Update(int id, Dvd entity) {
        _log.Debug("Atualizando Dvd: {Id}", id);
        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("El Dvd con id: {Id} no existe", id);
            return null;
        }

        var updated = entity with {
            Id = id,
            UpdatedAt = DateTime.Now
        };
        
        _listadoDvd.AgregarEn(updated, index);
        return updated;
    }

    public Dvd? Delete(int id) {
        _log.Debug("Borrando Dvd con id: {Id}", id);

        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("El Dvd con id: {Id} no existe", id);
            return null;
        }

        var revistaToDelete = _listadoDvd.Obterner(index) with {
            IsDeleted = true
        };
        
        _listadoDvd.EliminarEn(index);
        return revistaToDelete;
    }


    public int TotalDvds => _listadoDvd.Contar();
    
    public ILista<Dvd> GetByDvdsOrderBy(TipoOrdenamientoDvd ordenamientoDvd = TipoOrdenamientoDvd.PorGenero) {
        _log.Debug("Ordenando Dvds por {ordenamientoDvd}");
        var dvdArray = new Dvd[_listadoDvd.Contar()];
        var n = dvdArray.Length;
        // Copiamos los libros al array
        for (var i = 0; i < _listadoDvd.Contar(); i++)
            dvdArray[i] = _listadoDvd.Obterner(i);

        for (var i = 0; i < n - 1; i++) {
            for (var j = 0; j < n - i - 1; j++) {
                var debeIntercambiar = false;
                var dvdJ =  dvdArray[j];
                var dvdJ1 = dvdArray[j + 1];

                if (ordenamientoDvd== TipoOrdenamientoDvd.PorTitulo) {
                    if (string.Compare(dvdJ.Titulo, dvdJ1.Titulo, StringComparison.Ordinal) > 0)
                        debeIntercambiar = true;
                }

                else if (ordenamientoDvd == TipoOrdenamientoDvd.PorDirector) {
                    if (string.Compare(dvdJ.Director, dvdJ1.Director, StringComparison.Ordinal) > 0)
                        debeIntercambiar = true;
                }

                else if (ordenamientoDvd == TipoOrdenamientoDvd.PorGenero) {
                    if (dvdJ.Genero > dvdJ1.Genero)
                        debeIntercambiar = true;
                }
                
                if (debeIntercambiar)
                    (dvdArray[j], dvdArray[j + 1]) = (dvdArray[j + 1], dvdArray[j]);
            }
        }
        
        var sortedList = new Lista<Dvd>();
        foreach (var dvd in dvdArray)
            sortedList.AgregarFinal(dvd);
        return sortedList;
    }

    public static DvdRepositoryListaEnlazadaPropia GetInstance() {
        return _instance ??= new DvdRepositoryListaEnlazadaPropia();
    }
    

    private void InitDemoDvd() {
        _log.Debug("Iniciando Dvds de prueba");
        var demoRevistas = DvdFactory.DemoData();
        foreach (var revista in demoRevistas )
            Create(revista);
    }

    private static int GetNextId() {
        return ++_idCounter;
    }

    private bool Exists(Dvd dvd) {
        _log.Debug("Comprobando existencia del Dvd:  {Dvd}", dvd);
        foreach (var re in _listadoDvd ) 
            if (re.Equals(dvd))
                return true;
        return false;
    }

    private int IndexOf(int id) {
        _log.Debug("Buscando indice del Dvd con id: {Id}", id);
        for (var i = 0; i < _listadoDvd.Contar(); i++)
            if (_listadoDvd.Obterner(i).Id == id)
                return i;
        return -1;
    }
    
    
    
}