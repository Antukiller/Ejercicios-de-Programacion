using TheWictherContracts.Enums;

namespace TheWictherContracts.Models;

public sealed record ContratoAsalto(int id, string titulo, int nivelRecomendado, double recompensa, int numeroEnemigos, bool requiereSigilo) : ContratoBase(id, titulo, nivelRecomendado, recompensa), IEstrategia {
    public int NumeroEnemigos { get; init; } = numeroEnemigos;
    public bool RequiereSigilo { get; init; } = requiereSigilo;
    
    public void MostrarDetalles() {
        Console.WriteLine("\n##################################################");
        Console.WriteLine($"##        ORDEN DE ASALTO MILITAR: {titulo.ToUpper()}");
        Console.WriteLine("##################################################");
        Console.WriteLine($"## OBJETIVOS DETECTADOS: {numeroEnemigos} enemigos");
        Console.WriteLine($"## MODO OPERATIVO: {(requiereSigilo ? "SIGILO" : "ASALTO FRONTAL")}");
        Console.WriteLine($"## RECOMPENSA DE GUERRA: {recompensa:N0} orens");
        Console.WriteLine("##################################################\n");
    }

    public int ProbabiidadExito() {
        int baseExito = nivelRecomendado switch {
            <= 15 => 100,
            <= 30 => 80,
            <= 50 => 60,
            _ => 40
        };

        int penalizacionEnemigos = numeroEnemigos * 3;

        int penalizacionSigilo = requiereSigilo ? 15 : 0;
        
        int resultado = baseExito - penalizacionEnemigos - penalizacionSigilo;
        
        int final = Math.Clamp(resultado, 0, 100);
        
        // Evaluamos el éxito (de menos a más)
        string mensaje = final switch {
            < 20 => "💀 Pronóstico: Suicida (Las probabilidades de éxito son mínimas).",
            < 50 => "🟠 Pronóstico: Arriesgado (El enemigo tiene ventaja numérica).",
            < 80 => "🟢 Pronóstico: Favorable (Un brujo bien preparado no tendrá problemas).",
            _    => "💎 Pronóstico: Victoria segura (Misión de trámite)."
        };
        
        Console.WriteLine(mensaje);
        
        return final;
        
    }

    public void PlanificacionRuta() {
        
        if (requiereSigilo) {
            Console.WriteLine("Necesitaremos una armadura ligera, ir en silencio y por las sombras");
        }
        else {
            Console.WriteLine("Esta mision no requiere sigilo");
        }
    }
}