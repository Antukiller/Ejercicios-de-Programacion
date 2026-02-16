using TheWictherContracts.Enums;

namespace TheWictherContracts.Models;

public sealed record ContratoMonstruo(int id, string titulo, int nivelRecomendado, double recompensa, EspecieCriatura monstruo) : ContratoBase(id, titulo, nivelRecomendado, recompensa), IBestiario {
    public EspecieCriatura Monstruo { get; init; } = monstruo;
    
    public void MostrarDetalles() {
        Console.WriteLine("\n==================================================");
        Console.WriteLine($"   📜 CONTRATO DE BRUJO #{Id}   ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"   ASUNTO:       {Titulo.ToUpper()}");
        Console.WriteLine($"   PELIGROSIDAD: Nivel {NivelRecomendado}");
        Console.WriteLine($"   RECOMPENSA:   {Recompensa:N0} orens");
        Console.WriteLine($"   OBJETIVO:     {Monstruo}");
        Console.WriteLine("==================================================\n");
    }
    

    public void PrepararAceite() {
        Console.WriteLine("Seleccionando tipo de aceite para cada monstrtuo...");
        TipoAceite aceiteElegido = Monstruo switch {
            EspecieCriatura.Necrofago => TipoAceite.Necrofagos,
            EspecieCriatura.Espectro => TipoAceite.Espectros,
            EspecieCriatura.Draconico => TipoAceite.Draconidos,
            EspecieCriatura.Insectoide => TipoAceite.Insectoides,
            EspecieCriatura.Híbrido => TipoAceite.Hibridos,
            EspecieCriatura.Ogroido => TipoAceite.Ogroidos,
            EspecieCriatura.Relicto => TipoAceite.Relictos,
            EspecieCriatura.Maldito => TipoAceite.Malditos,
            EspecieCriatura.Vampiro => TipoAceite.Vampiros,
            EspecieCriatura.Elementoide => TipoAceite.Constructos,
            _ => TipoAceite.Ninguno
        };
        if (aceiteElegido == TipoAceite.Ninguno) {
            Console.WriteLine("[ALQUIMIA] No es necesario aplicar aceites para este objetivo.");
        }
        else {
            Console.WriteLine($"[ALQUIMIA] aplicando aceite para {aceiteElegido} en la espada de plata" );
        }
    }

    public string SeleccionarSeñal() {
        Console.WriteLine("Seleccionando la señal adecuada para el momento...");

        string señalCombate = Monstruo switch {
            EspecieCriatura.Necrofago or EspecieCriatura.Insectoide => Señal.Igni,
            EspecieCriatura.Espectro or EspecieCriatura.Vampiro => Señal.Yrden,
            EspecieCriatura.Híbrido or EspecieCriatura.Draconico => Señal.Aard,
            EspecieCriatura.Elementoide => Señal.Quen,
            EspecieCriatura.Humanos or EspecieCriatura.Animales => Señal.Axii,
        
            // --- Nuevas Incorporaciones ---
            EspecieCriatura.Relicto => Señal.Igni,  // Los Leshens y Chorts odian el fuego
            EspecieCriatura.Maldito => Señal.Quen,  // Los Hombres Lobo pegan rápido, mejor protegerse
            EspecieCriatura.Ogroido => Señal.Axii,  // Los Trolls y Gigantes son lentos de mente, Axii los aturde
        
            _ => Señal.Quen // Caso de seguridad
        };
    
        return señalCombate;
    }

    public void MostraDebilidades() {
        
        Console.ForegroundColor = ConsoleColor.Green;
        PrepararAceite();
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Estrategia mágica: {SeleccionarSeñal()}");
        Console.ResetColor();
        
    }
}