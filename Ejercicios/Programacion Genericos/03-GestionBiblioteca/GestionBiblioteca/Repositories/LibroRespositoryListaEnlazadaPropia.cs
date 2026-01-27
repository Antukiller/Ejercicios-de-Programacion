using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Factories;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Repositories;

public class LibroRespositoryListaEnlazadaPropia : ILibroRepository {
    private static LibroRespositoryListaEnlazadaPropia? _instance;
    private static int _idCounter;
    private readonly ILista<Libro>  _listaLibros =  new Lista<Libro>();
    private readonly ILogger _log =  Log.ForContext<LibroRespositoryListaEnlazadaPropia>();


    private LibroRespositoryListaEnlazadaPropia() {
        _log.Debug("Creando instanacia de LibroRepository");
        InitDemoLibros();
    }
    
    
    public ILista<Libro> GetAll() {
        _log.Debug("Obteniendo todos los los libros");
        return _listaLibros;
    }

    public Libro? GetById(int id) {
        _log.Debug("Obteniendo libro por id: {id}");
        foreach (var libro in _listaLibros )
            if (libro.Id == id)
                return libro;
        return null;
    }

    public Libro? Create(Libro entity) {
        _log.Debug("Creando libro: {Libro}", entity);

        if (Exists(entity)) {
            _log.Debug("El libro ya existe: {Libro}", entity);
            return null;
        }

        var saved = entity with {
                Id = GetNextId(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            
            _listaLibros.AgregarFinal(saved);
            return saved;
    }

    public Libro? Update(int id, Libro entity) {
        _log.Debug("Actualizando libro con id: {Id}", id);

        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("El libro con id {id} no existe", id);
            return null;
        }

        var updated = entity with {
            Id = id,
            UpdatedAt = DateTime.Now
        };
        
        _listaLibros.AgregarEn(updated, index);
        return updated;

    }

    public Libro? Delete(int id) {
        _log.Debug("Eliminando libro con id: {Id}", id);
        
        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("El libro con id {id} no existe", id);
            return null;
        }

        var libroToDelete = _listaLibros.Obterner(index) with {
            IsDeleted = true
        };

        _listaLibros.EliminarEn(index);
        return libroToDelete;

    }

    public int TotalLibros => _listaLibros.Contar();
    
    public ILista<Libro> GetByLibrosOrderBy(TipoOrdenamientoLibro ordenamientoLibro = TipoOrdenamientoLibro.PorTitulo) {
        _log.Debug("Ordenando libros por {ordenamientoLibro}");
        var librosArray = new Libro[_listaLibros.Contar()];
        var n = librosArray.Length;
        // Copiamos los libros al array
        for (var i = 0; i < _listaLibros.Contar(); i++)
            librosArray[i] = _listaLibros.Obterner(i);

        for (var i = 0; i < n - 1; i++) {
            for (var j = 0; j < n - i - 1; j++) {
                var debeIntercambiar = false;
                var libroJ =  librosArray[j];
                var libroJ1 = librosArray[j + 1];

                if (ordenamientoLibro == TipoOrdenamientoLibro.PorTitulo) {
                    if (string.Compare(libroJ.Titulo, libroJ1.Titulo, StringComparison.OrdinalIgnoreCase) > 0)
                        debeIntercambiar = true;
                }

                else if (ordenamientoLibro == TipoOrdenamientoLibro.PorAutor) {
                    if (string.Compare(libroJ.Autor, libroJ1.Autor, StringComparison.OrdinalIgnoreCase) > 0)
                        debeIntercambiar = true;
                }
                
                if (debeIntercambiar)
                    (librosArray[j], librosArray[j + 1]) = (librosArray[j + 1], librosArray[j]);
            }
        }
        
        var sortedList = new Lista<Libro>();
        foreach (var libro in librosArray)
            sortedList.AgregarFinal(libro);
        return sortedList;
    }

    public Libro? GetLibroIsbn(string isbn) {
        _log.Debug("Buscando libro con ISBN: {Isbn}", isbn);

        for (int i = 0; i < _listaLibros.Contar(); i++) {
            var libro = _listaLibros.Obterner(i);
            if (libro.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase)) {
                return libro;
            }
        }
        return null; 
    }

    public static LibroRespositoryListaEnlazadaPropia GetInstance() {
        return _instance ??= new LibroRespositoryListaEnlazadaPropia();
    }

    private void InitDemoLibros() {
        _log.Debug("Inicializando libros de prueba");
        var demoLibros = LibroFactory.DemoData();
        foreach (var libro in demoLibros) 
            Create(libro);
    }


    private static int GetNextId() {
        return ++_idCounter;
    }


    private bool Exists(Libro libro) {
        _log.Debug("Comprobando existencia del libro: {Libro}", libro);
        foreach (var al in _listaLibros ) 
            if (Equals(libro))
                return true;
        return false;
    }

    private int IndexOf(int id) {
        _log.Debug("Buscando indice del alumno con id: {Id}", id);
        for (var i = 0; i < _listaLibros.Contar(); i++)
            if (_listaLibros.Obterner(i).Id == id)
                return i;
        return -1;
    }
}