namespace The_Witcher_3Genericos.Models;


/// <summary>
/// Representa un laboratorio alquímico encargado de procesar ingredientes.
/// Utiliza Contravarianza (<see langword="in"/>) para permitir que un procesador 
/// de tipos generales acepte tipos más específicos.
/// </summary>
/// <typeparam name="T">El tipo de suministro que el laboratorio es capaz de analizar.</typeparam>
public class LaboratorioAlquimico<T> : IProcesadorAlquimico<T> where T : Suministro {
    
    // Ejecuta un análisis químico del ingrediente proporcionado.
    public void analizar(T ingrediente) {
        // Al usar 'where T : Suministro', tenemos acceso directo a las propiedades de la base
        Console.WriteLine($"[LABORATORIO] Analizando: {ingrediente.Nombre}...");
        Console.WriteLine($"[DATOS] Peso registrado: {ingrediente.Peso} kg.");

        if (ingrediente is Pocion p) {
            if (p.DuracionEfecto == 0) {
                Console.WriteLine("[Alerta]Los efectos del extracto han concluido");
            }
            else {
                Console.WriteLine($"[Detalle]Duracion del efecto: {p.DuracionEfecto} minutos");
            }
        }
    }
}