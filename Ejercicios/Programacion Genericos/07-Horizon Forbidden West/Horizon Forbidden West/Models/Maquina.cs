using Horizon_Forbidden_West.Enums;

namespace Horizon_Forbidden_West.Models;

public record Maquina : EntidadHorizon, IMaquina {
    public string DebilidadElemental { get; init; }
    public TipoMaquina Tipo  { get; init; }
    public NivelAmenaza Peligrosidad { get; init; }
    public bool EsSaboteabale  { get; init; }
    
    
    
    public void AnalizarDebilidad() {
        Console.WriteLine($"[Sistema de Escaner]: Escaneando maquina -> {NombreCompleto}....");

        string consejoTactico = DebilidadElemental switch {
            Elementos.Acido => "⚠️ TÁCTICA: Dispara a los depósitos de ácido para causar una explosión corrosiva.",
            Elementos.Fuego => "🔥 TÁCTICA: El sobrecalentamiento causará una explosion de área.",
            Elementos.Electricidad => "⚡ TÁCTICA: Impacta en las células de energía para sobrecargar y aturdir.",
            Elementos.Hielo => "❄️ TÁCTICA: Una vez congelada, los ataques físicos harán el triple de daño.",
            Elementos.Plasma => "⚛️ TÁCTICA: El daño se acumula. Aléjate cuando la barra se llene.",
            Elementos.AguaPurga => "⚛️ TÁCTICA: El daño se acumula. Aléjate cuando la barra se llene.",
            Elementos.Adhesivo => "🕸️ TÁCTICA: Impide que la máquina salte o vuele.",
            Elementos.Desgarro => "🏹 TÁCTICA: Extrae las armas pesadas y úsalas a tu favor.",
            Elementos.Explosivo => "💣 TÁCTICA: Ignora la armadura y daña componentes internos.",
            _ => "\"❌ Error: Elemento no identificado en la red de GAIA."
        };
        
        Console.WriteLine(consejoTactico);
    }

    public void Sabotear() {
        if (!EsSaboteabale) {
            Console.WriteLine($"❌ Error: Los protocolos del Caldero para {NombreCompleto} estan bloqueados.");
            return;
        }
        Console.WriteLine($"\n[LANZA DE SABOTAJE]: Inyectando código de GAIA en {Nombre}...");

        string sabotaje = Tipo switch {
            TipoMaquina.Transporte => "🚚 Sabotaje exitoso: La máquina ahora es tu medio de transporte.",
            TipoMaquina.Lidia => "⚔️ Sabotaje exitoso: ¡La máquina ahora luchará a tu lado!",
            TipoMaquina.Reconocimiento => "👁️ Sabotaje exitoso: El radar de la máquina ahora marca enemigos cercanos.",
            TipoMaquina.Reguladora =>
                "🔋 Sabotaje exitoso: La máquina ha generado una explosión de energía que recarga tu equipo.",
            _ => "✔️ Protocolo ejecutado: Máquina neutralizada."
        };
        Console.WriteLine(sabotaje);
    }

    public void ExtraerComponentes() {
        Console.WriteLine($"\n[HERRAMIENTA DE DESGARRO]: Extrayendo pieza {NombreCompleto}...");
        string botin = Peligrosidad switch {
            NivelAmenaza.Minima => "📦 Obtenido: Chatarra metálica y un cable trenzado.",
            NivelAmenaza.Moderada => "📦 Obtenido: Circuitería básica y un núcleo de máquina pequeño.",
            NivelAmenaza.Elevada  => "💎 Obtenido: Lente de máquina rara y un núcleo grande.",
            NivelAmenaza.Extrema  => "🔥 ¡BOTÍN LEGENDARIO!: Corazón de máquina, trenzado de cristal y bobina de ataque.",
            _ => "💨 No se han encontrado componentes útiles."
            
        };
        Console.WriteLine(botin);
    }
    
    public override string ToString() {
        return $"""
                =======================================================
                [REGISTRO DE MÁQUINA]: {NombreCompleto}
                =======================================================
                Identificador:  {CodigoGaia}
                Clasificación:  {Tipo}
                Amenaza:        {Peligrosidad}
                Debilidad:      {DebilidadElemental}
                Saboteable:     {(EsSaboteabale ? "SÍ (Protocolo Activo)" : "NO (Cifrado)")}
                =======================================================
                """;
    }
}