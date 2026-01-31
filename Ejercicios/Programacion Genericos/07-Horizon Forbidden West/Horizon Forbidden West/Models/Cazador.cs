using Horizon_Forbidden_West.Enums;

namespace Horizon_Forbidden_West.Models;

public sealed record Cazador : EntidadHorizon, ICazador {
    public TipoTribu Tribu { get; init; }
    public RangoCazador Rango { get; init; }
    public CicloEntrenamiento Entrenamiento { get; init; }
    public string Especialidad { get; init; }
    
    public void Entrenar() {
        Console.WriteLine($"\n[FOCUS SCAN]: {NombreCompleto} - {Especialidad}");
        string simulacro = (Tribu, Rango, Entrenamiento, Especialidad) switch {
            (TipoTribu.Nora, RangoCazador.Iniciado, CicloEntrenamiento.Iniciado, Especializacion.SigiloYSupervivencias)
                => "🌿 Escondiéndose en la hierba roja para evitar el escaneo de un Vigía.",
            (TipoTribu.Tenakth, _, _, Especializacion.BalisticaDeFelchas)
                => "🏹 Calibrando el arco de precisión para derribar componentes de un Terremamut.",
            (_, _, CicloEntrenamiento.Veterano, Especializacion.IngenieriaDeCalderos)
                => "🔧 Analizando la estructura de un núcleo para forzar el sabotaje manual.",
            (_, _, _, Especializacion.ProtocolosDeGaia)
                => "📡 Decodificando transmisiones de audio de los Antiguos.",
            // Caso por defecto
            _ => "⚔️ Repasando tácticas de combate básicas en el campamento."
        };
        Console.WriteLine($"[SIMULACRO]: {simulacro}");
    }

    public void RealizarMision() {
        string objetivo = Especialidad switch {
            Especializacion.AnalisisDeMaquinas => "🔍 Escanear una manada de Recolectores sin ser visto.",
            Especializacion.BalisticaDeFelchas => "🎯 Eliminar el lanzadiscos de un Tronador.",
            Especializacion.IngenieriaDeCalderos => "🛠️ Reparando los calderos para su posterior utilizacion",
            _ => $"🏹 Misión de reconocimiento en el Oeste Prohibido."

        };
        Console.WriteLine($"[MISIÓN]: {objetivo}");
    }
    
    public override string ToString() {
        return $"""
                -------------------------------------------------------
                [IDENTIDAD DE CAZADOR]: {NombreCompleto}
                -------------------------------------------------------
                Tribu:         {Tribu}
                Rango:         {Rango}
                Ciclo:         {Entrenamiento}
                Especialidad:  {Especialidad}
                -------------------------------------------------------
                """;
    }
}