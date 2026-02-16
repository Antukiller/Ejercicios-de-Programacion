using Serilog;

namespace TheWictherContracts.Cache;

public class LruCache<Tkey, TValue> : ICache<Tkey, TValue> where Tkey : notnull {
    
    private readonly int _capacity;
    private readonly Dictionary<Tkey, TValue> _items = new();
    private readonly ILogger _log = Log.ForContext<LruCache<Tkey, TValue>>();
    private readonly LinkedList<Tkey> _usageOrder = new(); 
    
    public LruCache(int capacity) {
        if (capacity <= 0) {
            throw new ArgumentOutOfRangeException("La capacidad debe ser mayor que 0.", nameof(capacity));
            _capacity = capacity;
        }
    }
    
    
    public void Add(Tkey key, TValue value) {
        _log.Debug("[LRU-ADD] Intentando añadir nueva clave: {key}", key);

        if (_items.TryGetValue(key, out var existingValue)) {
            _log.Debug("[LRU-ADD] Clave {key} ya existe. Actualizando valor: {Old} -> {New}", key, existingValue, value);
            _items[key] = value;
            RefreshUsage(key);
            return;
        }
        
        _log.Debug("[LRU-ADD] Clave {key} es nueva. Capacidad actual: {Used}/{Total}", key, _items.Count, _capacity);

        if (_items.Count >= _capacity) {
            var oldestKey = _usageOrder.First!.Value;
            var oldestValue = _items[oldestKey];
            _log.Debug("[LRU-EVICT Cache llena. Desalojando elemento más antiguo: {Key} = {Value}", key, oldestKey, oldestValue);
            _usageOrder.RemoveFirst();
            _items.Remove(oldestKey);
        }
        
        _items.Add(key, value);
        _usageOrder.AddLast(key);
        _log.Debug("[LRU-ADD] Elemento nuevo añadido. Nueva lista de uso: {Order}", string.Join("->", _usageOrder));
    }

    public TValue Get(Tkey key) {
        _log.Debug("[LRU-GET] Buscando clave: {key}", key);

        if (_items.TryGetValue(key, out var value)) {
            _log.Debug("[LRU-GET] Clave {key} No encontrado en cache", key);
            return default;
        }
        
        _log.Debug("[LRU-GET] Clave {key} encontrada con valor {value}. Actulizando....", key, value);
        RefreshUsage(key);
        _log.Debug("[LRU-GET] Lista actualizada: {Order}", string.Join("->", _usageOrder));
        
        return value;
    }

    public bool Remove(Tkey key) {
        _log.Debug("[LRU-DELETE] Intentando eliminar clave: {key}", key);

        if (!_items.Remove(key)) {
            _log.Debug("[LRU-REMOVE] Clave {key} no encontrado en cache", key);
            return false;
        }
        
        _usageOrder.Remove(key);
        _log.Debug("[LRU-REMOVE] Clave {key} eliminada correctamente", key);
        return true;
    }

    public void DisplayStatus() {
        _log.Information("[LRU-DISPLAYSTATUS] Capacidad: {Used}/{Total}", _items.Count, _capacity);
        _log.Information("[LRU-DISPLAYSTATUS] Uso (Menos reciente -> Más reciente): {Order}", string.Join("->", _usageOrder));
    }

    private void RefreshUsage(Tkey key) {
        _log.Verbose("[LRU-REFRESH] Moviendo clave {key} al final de la lista", key);
        _usageOrder.Remove(key);
        _usageOrder.AddLast(key);
    }
    
}