using LaBoticaria.Enums;

namespace LaBoticaria.Factory;

using LaBoticaria.Enums;

namespace LaBoticaria;

public static class CasoMedicoFactory 
{
    public static List<CasoMedico> GetSeedCasosMedicos() => new() 
    {
        // --- Casos de Gravedad Leve ---
        new (1, "El Eunuco Agotado", new[] { Sintomas.Inapetencia }, CausaSospecha.Fatiga, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now),
        new (2, "Alergia Estacional", new[] { Sintomas.PruritoIntenso }, CausaSospecha.Entorno, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now),
        new (3, "Zumbido tras el Festival", new[] { Sintomas.Tinnitus }, CausaSospecha.Accidentado, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now),
        new (4, "Resfriado del Pabellón Verde", new[] { Sintomas.FiebreMiliar }, CausaSospecha.Entorno, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now),
        new (5, "Malestar por Comida Picante", new[] { Sintomas.Inapetencia }, CausaSospecha.Dieta, EstadoInvestigacion.Cerrado, Gravedad.Leve, DateTime.Now),

        // --- Casos de Gravedad Media ---
        new (6, "El Guardia Mareado", new[] { Sintomas.Sincope, Sintomas.Parestesia }, CausaSospecha.Agotamiento, EstadoInvestigacion.EnCurso, Gravedad.Media, DateTime.Now),
        new (7, "Visión Borrosa del Bibliotecario", new[] { Sintomas.Midriasis }, CausaSospecha.SustanciaDesconocida, EstadoInvestigacion.EnCurso, Gravedad.Media, DateTime.Now),
        new (8, "Retención de Líquidos Sospechosa", new[] { Sintomas.EdemaRenal }, CausaSospecha.Enfermedad, EstadoInvestigacion.EnCurso, Gravedad.Media, DateTime.Now),
        new (9, "Dificultad Respiratoria en Invierno", new[] { Sintomas.Disnea }, CausaSospecha.Entorno, EstadoInvestigacion.Cerrado, Gravedad.Media, DateTime.Now),
        new (10, "El Mensajero Exhausto", new[] { Sintomas.Sincope, Sintomas.Inapetencia }, CausaSospecha.Agotamiento, EstadoInvestigacion.Cerrado, Gravedad.Media, DateTime.Now),

        // --- Casos de Gravedad Alta (Sospecha de Envenenamiento) ---
        new (11, "La Dama de Honor Amarilla", new[] { Sintomas.IctericiaBiliar, Sintomas.Melena }, CausaSospecha.Veneno, EstadoInvestigacion.BajoVigilancia, Gravedad.Grave, DateTime.Now),
        new (12, "El Poeta Mudo", new[] { Sintomas.AfasiaTemporal, Sintomas.Tinnitus }, CausaSospecha.SustanciaDesconocida, EstadoInvestigacion.BajoVigilancia, Gravedad.Alta, DateTime.Now),
        new (13, "Tos Carmesí", new[] { Sintomas.Hemoptisis, Sintomas.Disnea }, CausaSospecha.Enfermedad, EstadoInvestigacion.EnCurso, Gravedad.Alta, DateTime.Now),
        new (14, "Pupilas de Cristal", new[] { Sintomas.Midriasis, Sintomas.Sincope }, CausaSospecha.Veneno, EstadoInvestigacion.BajoVigilancia, Gravedad.Alta, DateTime.Now),
        new (15, "El Banquete Manchado", new[] { Sintomas.Melena, Sintomas.Inapetencia }, CausaSospecha.Veneno, EstadoInvestigacion.BajoVigilancia, Gravedad.Alta, DateTime.Now),

        // --- Casos de Gravedad Crítica ---
        new (16, "Cianosis en el Té Real", new[] { Sintomas.Cianosis, Sintomas.Sincope }, CausaSospecha.IntentoAsesinato, EstadoInvestigacion.Urgente, Gravedad.Critica, DateTime.Now),
        new (17, "El Colapso del Ministro", new[] { Sintomas.ArritmiaSevera, Sintomas.Cianosis }, CausaSospecha.Veneno, EstadoInvestigacion.Urgente, Gravedad.Critica, DateTime.Now),
        new (18, "Sangre en el Pabellón de Jade", new[] { Sintomas.Hemoptisis, Sintomas.Melena }, CausaSospecha.IntentoAsesinato, EstadoInvestigacion.Urgente, Gravedad.Critica, DateTime.Now),
        new (19, "Parálisis del Gran Eunuco", new[] { Sintomas.Parestesia, Sintomas.Disnea }, CausaSospecha.Veneno, EstadoInvestigacion.Urgente, Gravedad.Critica, DateTime.Now),
        new (20, "Delirio de la Consorte", new[] { Sintomas.AfasiaTemporal, Sintomas.Midriasis }, CausaSospecha.SustanciaDesconocida, EstadoInvestigacion.Urgente, Gravedad.Critica, DateTime.Now),

        // --- Casos de Investigación Especial ---
        new (21, "Incidente del Polvo de Plomo", new[] { Sintomas.EdemaRenal, Sintomas.Inapetencia }, CausaSospecha.Cosmeticos, EstadoInvestigacion.EnCurso, Gravedad.Media, DateTime.Now),
        new (22, "Sudor Frío Misterioso", new[] { Sintomas.FiebreMiliar, Sintomas.ArritmiaSevera }, CausaSospecha.SustanciaDesconocida, EstadoInvestigacion.EnCurso, Gravedad.Alta, DateTime.Now),
        new (23, "Alucinaciones en el Jardín", new[] { Sintomas.AfasiaTemporal, Sintomas.Sincope }, CausaSospecha.Entorno, EstadoInvestigacion.EnCurso, Gravedad.Media, DateTime.Now),
        new (24, "El Catador Caído", new[] { Sintomas.Cianosis, Sintomas.Melena }, CausaSospecha.Veneno, EstadoInvestigacion.Urgente, Gravedad.Critica, DateTime.Now),
        new (25, "Sospecha de Maomao", new[] { Sintomas.Parestesia, Sintomas.Tinnitus }, CausaSospecha.Autoexperimentacion, EstadoInvestigacion.Cerrado, Gravedad.Baja, DateTime.Now)
    };
}