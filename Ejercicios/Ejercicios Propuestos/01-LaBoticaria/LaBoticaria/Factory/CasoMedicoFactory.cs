using LaBoticaria.Enums;
using LaBoticaria.Enums;

namespace LaBoticaria;

public static class CasoMedicoFactory 
{
    public static List<CasoMedico> GetSeedCasosMedicos() => new() 
    {
        new (1, "El Eunuco Agotado", new[] { Sintomas.Inapetencia }, new DateTime(2026, 01, 12), CausaSospecha.Enfermedad, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now, DateTime.Now, false),
        
        new (2, "La Dama del Té", new[] { Sintomas.Cianosis, Sintomas.Sincope }, new DateTime(2026, 02, 05), CausaSospecha.Veneno, EstadoInvestigacion.Investigando, Gravedad.Grave, DateTime.Now, DateTime.Now, false),
        
        new (3, "El Guardia Aturdido", new[] { Sintomas.Tinnitus, Sintomas.Parestesia }, new DateTime(2026, 02, 10), CausaSospecha.Desconocido, EstadoInvestigacion.Abierto, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (4, "Resfriado del Pabellón", new[] { Sintomas.FiebreMiliar }, new DateTime(2026, 01, 20), CausaSospecha.Enfermedad, EstadoInvestigacion.Resuelto, Gravedad.Leve, DateTime.Now, DateTime.Now, false),
        
        new (5, "El Banquete de Otoño", new[] { Sintomas.Melena, Sintomas.Inapetencia }, new DateTime(2026, 03, 01), CausaSospecha.Veneno, EstadoInvestigacion.Investigando, Gravedad.Grave, DateTime.Now, DateTime.Now, false),
        
        new (6, "Visión de Cristal", new[] { Sintomas.Midriasis }, new DateTime(2026, 02, 15), CausaSospecha.Desconocido, EstadoInvestigacion.Abierto, Gravedad.Leve, DateTime.Now, DateTime.Now, false),
        
        new (7, "El Poeta de la Corte", new[] { Sintomas.AfasiaTemporal }, new DateTime(2026, 03, 05), CausaSospecha.Enfermedad, EstadoInvestigacion.Investigando, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (8, "El Catador Real", new[] { Sintomas.ArritmiaSevera, Sintomas.Cianosis }, new DateTime(2026, 03, 10), CausaSospecha.Veneno, EstadoInvestigacion.Investigando, Gravedad.Grave, DateTime.Now, DateTime.Now, false),
        
        new (9, "Afección del Riñón", new[] { Sintomas.EdemaRenal }, new DateTime(2026, 01, 15), CausaSospecha.Enfermedad, EstadoInvestigacion.Cerrado, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (10, "Tos Carmesí", new[] { Sintomas.Hemoptisis, Sintomas.Disnea }, new DateTime(2026, 02, 28), CausaSospecha.Enfermedad, EstadoInvestigacion.Investigando, Gravedad.Grave, DateTime.Now, DateTime.Now, false),
        
        new (11, "Piel de Ictericia", new[] { Sintomas.IctericiaBiliar }, new DateTime(2026, 03, 12), CausaSospecha.Enfermedad, EstadoInvestigacion.Resuelto, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (12, "El Incidente del Loto", new[] { Sintomas.Sincope, Sintomas.Parestesia }, new DateTime(2026, 03, 14), CausaSospecha.Veneno, EstadoInvestigacion.Abierto, Gravedad.Grave, DateTime.Now, DateTime.Now, false),
        
        new (13, "Picor de la Concubina", new[] { Sintomas.PruritoIntenso, Sintomas.FiebreMiliar }, new DateTime(2026, 01, 05), CausaSospecha.Desconocido, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now, DateTime.Now, false),
        
        new (14, "El Mensajero Exhausto", new[] { Sintomas.Inapetencia, Sintomas.Sincope }, new DateTime(2026, 02, 20), CausaSospecha.Enfermedad, EstadoInvestigacion.Resuelto, Gravedad.Leve, DateTime.Now, DateTime.Now, false),
        
        new (15, "Dificultad Nocturna", new[] { Sintomas.Disnea }, new DateTime(2026, 02, 12), CausaSospecha.Enfermedad, EstadoInvestigacion.Cerrado, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (16, "Pupilas de Muñeca", new[] { Sintomas.Midriasis, Sintomas.AfasiaTemporal }, new DateTime(2026, 03, 08), CausaSospecha.Veneno, EstadoInvestigacion.Investigando, Gravedad.Grave, DateTime.Now, DateTime.Now, false),
        
        new (17, "Zumbido Metálico", new[] { Sintomas.Tinnitus }, new DateTime(2026, 01, 30), CausaSospecha.Desconocido, EstadoInvestigacion.Cerrado, Gravedad.Nula, DateTime.Now, DateTime.Now, false),
        
        new (18, "Heces Oscuras", new[] { Sintomas.Melena }, new DateTime(2026, 02, 22), CausaSospecha.Enfermedad, EstadoInvestigacion.Investigando, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (19, "Palpitaciones en el Jardín", new[] { Sintomas.ArritmiaSevera }, new DateTime(2026, 03, 02), CausaSospecha.Desconocido, EstadoInvestigacion.Abierto, Gravedad.Moderada, DateTime.Now, DateTime.Now, false),
        
        new (20, "El Caso de Maomao", new[] { Sintomas.Parestesia }, new DateTime(2026, 03, 15), CausaSospecha.Desconocido, EstadoInvestigacion.Abierto, Gravedad.Leve, DateTime.Now, DateTime.Now, false)
    };
}