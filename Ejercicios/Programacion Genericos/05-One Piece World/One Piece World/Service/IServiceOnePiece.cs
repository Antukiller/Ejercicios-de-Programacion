using One_Piece_World.Collections;

namespace One_Piece_World.Service;

public interface IServiceOnePiece {
    // 1. Listados (Opciones 1, 2, 3, 4)
    ILista<Entidad> ObtenerTodo();
    ILista<Pirata> ObtenerPiratas();        // Aquí el servicio hará el filtrado y casting
    ILista<Marine> ObtenerMarines();        // Aquí también
    ILista<FrutaDelDiablo> ObtenerFrutas(); // Y aquí

    // 2. Búsqueda (Opción 5)
    Entidad? BuscarPorId(int id);
    ILista<Entidad> BuscarPorNombre(string nombre);

    // 3. Gestión (Opciones 6, 7, 8)
    void AñadirEntidad(Entidad entidad);
    bool ActualizarEntidad(int id, Entidad entidad);
    bool EliminarEntidad(int id);

    // 4. Estadísticas (Opción 9)
    // Por ejemplo: total de recompensas, número de almirantes, etc.
    long CalcularTotalRecompensas(); 
    int ContarDespertadas();
}