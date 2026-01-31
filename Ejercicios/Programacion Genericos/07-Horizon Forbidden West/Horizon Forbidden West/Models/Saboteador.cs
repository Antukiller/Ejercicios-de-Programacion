using Horizon_Forbidden_West.Enums;

namespace Horizon_Forbidden_West.Models;

public sealed record Saboteador : EntidadHorizon, ISaboteador {
    public int añosExperiencia { get; init; }
    public FaccionTecnologica Faccion { get; init; }
    public CertificadoCaldero Certificado { get; init; }
    public string AreaMaestra { get; init; }


    public void HackearRedes() {
        Console.WriteLine($"\n[CONSOLA DE COMANDO]: Saboteador {NombreCompleto} iniciando bypass...");
        string resultado = (Faccion, añosExperiencia) switch {
            (FaccionTecnologica.Eclipse, >= 10)
                => "🛰️ Hackeo total: La red de focos enemiga está bajo nuestro control.",
            (FaccionTecnologica.HerederosDeApolo, _) =>
                "📚 Acceso concedido: Descargando archivos históricos del servidor.",
            (_, < 5) => "⚠️ Hackeo parcial: Se ha detectado la intrusión, pero se obtuvieron datos básicos.",
            _ => "🔓 Hackeo exitoso: Cortafuegos anulados."
        };
        Console.WriteLine(resultado);
    }

    public void RepararNucleo() {
        Console.WriteLine($"\n[MANTENIMIENTO]: Accediendo al núcleo del Caldero {Certificado}...");
        if (AreaMaestra == Especializacion.IngenieriaDeCalderos) {
            Console.WriteLine("✅ Reparación óptima: El núcleo funciona al 100% de su capacidad.");
        }
        else {
            Console.WriteLine("🛠️ Reparación estándar: El núcleo vuelve a estar operativo.");
        }
    }

    public void EnseñarHabilidad() {
        Console.WriteLine($"\n[ACADEMIA DE SABOTAJE]: {NombreCompleto} está impartiendo una clase.");
        string leccion = (añosExperiencia, AreaMaestra) switch {
            (>= 20, _) => "👑 Clase Magistral: Transmitiendo secretos de nivel Alpha.",
            (_, Especializacion.ProtocolosDeGaia) => "📡 Lección: Cómo comunicarse con las subfunciones de GAIA.",
            (> 5, Especializacion.SigiloYSupervivencias) => "🌿 Lección: Infiltración en instalaciones de Far Zenith.",
        };
        Console.WriteLine(leccion);
    }
    
    public override string ToString() {
        return $"""
                #######################################################
                [SABOTEADOR CLASIFICADO]: {NombreCompleto}
                #######################################################
                Facción:        {Faccion}
                Experiencia:    {añosExperiencia} años
                Especialidad:   {AreaMaestra}
                Certificación:  Caldero {Certificado}
                #######################################################
                """;
    }
}