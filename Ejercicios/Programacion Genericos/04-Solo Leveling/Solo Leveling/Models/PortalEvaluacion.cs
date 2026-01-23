namespace Solo_Leveling;

public class PortalEvaluacion<T> : IEvaluadorAsosciacion<T> where T : Entidad {
    public void analizar(T cazador) {
        Console.WriteLine($"[SISTEMA DE EVALUACIÓN] Escaneando a: {cazador.Nombre}...");
        Console.WriteLine($"[RESULTADO] Rango: {cazador.Rango}");
        
        if (cazador is CazadorMagico mago)
            Console.WriteLine($"[DETALLE] Maná detectado: {mago.CapacidadMana}");
        else if (cazador is CazadorFisico fisico)
            Console.WriteLine($"[DETALLE] Fuerza detectada: {fisico.Fuerza}");
    }
}