using One_Piece_World.Collections;
using One_Piece_World.Repositories;
using One_Piece_World.Validator.Common;
using Serilog;

namespace One_Piece_World.Service;

public class ServiceOnePiece(
    IEntidadReposytory repositorio,
    IPirataValidator pirataValidator,
    IMarineValidator marineValidator,
    IFrutaDelDiablo frutaDelDiabloValidator
) : IServiceOnePiece {
    
    private readonly ILogger _log = Log.ForContext<ServiceOnePiece>();


    public ILista<Entidad> ObtenerTodo() => repositorio.GetAll();

    public ILista<Pirata> ObtenerPiratas() {
        _log.Debug("Obteniendo a todo los piratas");
        var piratas = new Lista<Pirata>();
        var todos = repositorio.GetAll();
        foreach (var pirata in todos) {
            if (pirata is Pirata p) {
                piratas.AgregarFinal(p);
            }
        }
        return piratas;
    }

    public ILista<Marine> ObtenerMarines() {
        _log.Debug("Obteniendo a todos los marines");
        var marines  = new Lista<Marine>();
        var todos = repositorio.GetAll();
        foreach (var marine in todos) {
            if (marine is Marine m) {
                marines.AgregarFinal(m);
            }
        }
        return marines;
    }

    public ILista<FrutaDelDiablo> ObtenerFrutas() {
        _log.Debug("Obteniendo todas las frutas del diablo");
        var frutas = new Lista<FrutaDelDiablo>();
        var todos = repositorio.GetAll();
        foreach (var fruta in todos) {
            if (fruta is FrutaDelDiablo fr) {
                frutas.AgregarFinal(fr);
            }
        }
        return frutas;
    }

    public Entidad? BuscarPorId(int id) {
       return repositorio.GetById(id);
    }

    public ILista<Entidad> BuscarPorNombre(string nombre) {
        var nombres = new Lista<Entidad>();
        var todos = repositorio.GetAll();

        foreach (var e in todos ) {
            if (e.NombreCompleto.Contains(nombre, StringComparison.CurrentCultureIgnoreCase)) {
                nombres.AgregarFinal(e);
            }
        }
        return nombres;
    }
    
    public void AñadirEntidad(Entidad entidad) {
        _log.Debug("Añadiendo nombre:{Nombre}", entidad.NombreCompleto);

        // Guardaremos aquí el objeto que devuelva el validador
        Entidad? entidadValidada = entidad switch {
            // Caso Pirata: hacemos el casting a 'p' y validamos
            Pirata p => pirataValidator.Validate(p),

            // Caso Marine: hacemos el casting a 'm' y validamos
            Marine m => marineValidator.Validate(m),

            // Caso Fruta: hacemos el casting a 'f' y validamos
            FrutaDelDiablo f => frutaDelDiabloValidator.Validate(f),

            // Caso por defecto (si no coincide con ninguno de los anteriores)
            _ => entidad 
        };

        // Siguiendo la regla de tu profe: si el validador devolvió null, paramos
        if (entidadValidada == null) {
            _log.Warning("Validación fallida: El objeto devuelto por el validador es null.");
            return;
        }

        // Si todo fue bien, guardamos la versión validada
        repositorio.Create(entidadValidada);
    }

    public bool ActualizarEntidad(int id, Entidad entidad) {
        _log.Debug("Actualizando entidad con Id {Id}", id);

        // 1. Usamos el switch para validar según el tipo de objeto que nos llega
        Entidad? entidadValidada = entidad switch {
            Pirata p => pirataValidator.Validate(p),
            Marine m => marineValidator.Validate(m),
            FrutaDelDiablo f => frutaDelDiabloValidator.Validate(f),
            _ => entidad // Si no tiene validador específico, la dejamos como está
        };

        // 2. Si el validador devolvió null, no procedemos con la actualización
        if (entidadValidada == null) {
            _log.Warning("Actualización cancelada: La validación devolvió null.");
            return false;
        }

        // 3. Llamamos al repositorio para que haga el cambio real
        // Le pasamos el ID original y el objeto ya validado (y posiblemente corregido)
        var resultado = repositorio.Update(id, entidadValidada);

        // Si el repositorio devuelve algo distinto de null, es que se actualizó con éxito
        return resultado != null;
    }
    
    
    public bool EliminarEntidad(int id) {
        _log.Debug("Eliminación de la entidad con Id {Id}", id);

        // Llamamos al repositorio. 
        // Si el ID existe, el repo devuelve la entidad marcada; si no, devuelve null.
        var resultado = repositorio.Delete(id);

        // Si resultado no es null, devolvemos true (éxito), de lo contrario false.
        return resultado != null;
    }

    public long CalcularTotalRecompensas() {
        _log.Information("Calculando el total de todas las recompensas de piratas activos.");
        long total = 0;

        // Obtenemos todos los personajes (el repositorio ya filtra los IsDeleted)
        var todos = repositorio.GetAll();

        foreach (var entidad in todos) {
            // Solo sumamos si la entidad es un Pirata
            if (entidad is Pirata p) {
                total += p.Recompensa;
            }
        }

        return total;
    }

    public int ContarDespertadas() {
        _log.Information("Contando frutas del diablo despertadas.");
        int contador = 0;

        var todos = repositorio.GetAll();

        foreach (var entidad in todos) {
            // Solo entramos si es una FrutaDelDiablo
            if (entidad is FrutaDelDiablo f) {
                // Comprobamos la propiedad específica de la fruta
                if (f.IsDespertada) { 
                    contador++;
                }
            }
        }

        return contador;
    }
}