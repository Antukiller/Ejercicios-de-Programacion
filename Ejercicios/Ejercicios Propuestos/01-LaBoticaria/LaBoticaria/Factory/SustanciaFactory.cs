using LaBoticaria.Enums;

namespace LaBoticaria.Factory;

using LaBoticaria; // Para acceder a Antidotos, Sintomas, etc.

public static class BoticariaFactory {
    public static IEnumerable<Sustancia> Seed() {
        var lista = new List<Sustancia>();
        lista.AddRange(GetSeedMedicinas());     // IDs 1-20
        lista.AddRange(GetSeedVenenos());       // IDs 21-40
        lista.AddRange(GetSeedAfrodisiacos());  // IDs 41-60
        return lista;
    }

    // --- 💊 MEDICINAS (Usa EfectosSecundarios) ---
   private static List<Medicina> GetSeedMedicinas() => new() {
    new (1, "Jarabe de Loto", "Calmante para la tos real", 150, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Disnea }, 45, new[] { EfectosSecundarios.Alucinaciones }, 35),
    new (2, "Tónico de Ginseng", "Vitalizante de raíz profunda", 300, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Inapetencia }, 15, new[] { EfectosSecundarios.Hiperactividad }, 60),
    new (3, "Bálsamo de Menta", "Refrescante craneal", 50, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Tinnitus }, 5, new[] { EfectosSecundarios.Xerostomia }, 30),
    new (4, "Extracto de Sauce", "Analgésico de corteza", 200, Disponibilidad.Comun, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.FiebreMiliar }, 20, new[] { EfectosSecundarios.Disgeusia }, 240),
    new (5, "Gotas de Eufrasia", "Claridad para la vista", 120, Disponibilidad.Rara, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Midriasis }, 2, new[] { EfectosSecundarios.Fotosensibilidad }, 15),
    new (6, "Licor de Jengibre", "Digestivo de la corte", 45, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Melena }, 30, new[] { EfectosSecundarios.Diaforesis }, 180),
    new (7, "Píldoras de Valeriana", "Paz para el espíritu", 90, Disponibilidad.Comun, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Parestesia }, 1, new[] { EfectosSecundarios.VertigoPosicional }, 480),
    new (8, "Ungüento Cicatrizante", "Cierra pieles abiertas", 75, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.PruritoIntenso }, 0, new[] { EfectosSecundarios.UrticariaIdiopatica }, 1440),
    new (9, "Elixir de Ginkgo", "Fluidez de pensamiento", 450, Disponibilidad.Rara, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.AfasiaTemporal }, 5, new[] { EfectosSecundarios.Irritabilidad }, 120),
    new (10, "Solución de Almidón", "Recubrimiento estomacal", 30, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Inapetencia }, 100, new[] { EfectosSecundarios.Poliuria }, 60),
    new (11, "Esencia de Lavanda", "Relajante de tendones", 55, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.ArritmiaSevera }, 10, new[] { EfectosSecundarios.Somnolencia }, 60),
    new (12, "Aceite de Eucalipto", "Vapores del bosque", 25, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Disnea }, 5, new[] { EfectosSecundarios.Xerostomia }, 30),
    new (13, "Jarabe de Saúco", "Escudo contra el frío", 85, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.FiebreMiliar }, 15, new[] { EfectosSecundarios.Diaforesis }, 120),
    new (14, "Poción de Caléndula", "Calma para la inflamación", 110, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.PruritoIntenso }, 20, new[] { EfectosSecundarios.UrticariaIdiopatica }, 180),
    new (15, "Sales Rehidratantes", "Retención de esencia vital", 20, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.EdemaRenal }, 500, new[] { EfectosSecundarios.Disgeusia }, 60),
    new (16, "Extracto de Alcachofa", "Filtro para el hígado", 130, Disponibilidad.Rara, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.IctericiaBiliar }, 10, new[] { EfectosSecundarios.Poliuria }, 300),
    new (17, "Bálsamo de Tigre", "Calor para el hueso", 180, Disponibilidad.Comun, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Parestesia }, 0, new[] { EfectosSecundarios.Fotosensibilidad }, 90),
    new (18, "Infusión de Manzanilla", "Sosegar el vientre", 15, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Inapetencia }, 250, new[] { EfectosSecundarios.Somnolencia }, 45),
    new (19, "Corteza de Quina", "Freno para la fiebre", 600, Disponibilidad.Secreta, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Hemoptisis }, 5, new[] { EfectosSecundarios.Bradicardia }, 240),
    new (20, "Vitamina de Cítricos", "Brillo de salud", 40, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, new[] { Sintomas.Sincope }, 10, new[] { EfectosSecundarios.Hiperactividad }, 1000)
};
    // --- 🧪 VENENOS (Usa Antidotos) ---
   private static List<Veneno> GetSeedVenenos() => new() {
    new (21, "Arsénico Puro", "Muerte por fallo celular", 2000, Disponibilidad.Rara, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 120, new[] { Sintomas.PruritoIntenso, Sintomas.Melena }, 95.5, 5, new[] { AntidotosConocidos.Dimercaprol }),
    new (22, "Cianuro Potásico", "Asfixia química rápida", 3500, Disponibilidad.Secreta, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 5, new[] { Sintomas.Cianosis, Sintomas.Sincope }, 99.9, 1, new[] { AntidotosConocidos.NitritoDeSodio, AntidotosConocidos.Tiosulfato }),
    new (23, "Extracto de Acónito", "Parada cardiorrespiratoria", 1200, Disponibilidad.Rara, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Contacto, 15, new[] { Sintomas.ArritmiaSevera, Sintomas.Parestesia }, 90.0, 10, new[] { AntidotosConocidos.AtropinaSintetica }),
    new (24, "Esencia de Belladona", "Delirio y midriasis mortal", 800, Disponibilidad.Comun, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 45, new[] { Sintomas.Midriasis, Sintomas.AfasiaTemporal }, 75.0, 25, new[] { AntidotosConocidos.Fisostigmina }),
    new (25, "Veneno de Crótalo", "Hemotóxico potente", 5000, Disponibilidad.Secreta, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Contacto, 10, new[] { Sintomas.Hemoptisis, Sintomas.Cianosis }, 85.0, 15, new[] { AntidotosConocidos.SueroPolivalente }),
    new (26, "Estricnina", "Convulsiones tetánicas", 1500, Disponibilidad.Rara, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 20, new[] { Sintomas.ArritmiaSevera, Sintomas.Tinnitus }, 92.0, 8, new[] { AntidotosConocidos.Diazepam }),
    new (27, "Sales de Plomo", "Saturnismo agudo", 450, Disponibilidad.Comun, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 5000, new[] { Sintomas.Inapetencia, Sintomas.EdemaRenal }, 30.0, 70, new[] { AntidotosConocidos.QuelantesDePlomo }),
    new (28, "Mercurio Destilado", "Hidrargirismo mortal", 2500, Disponibilidad.Rara, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Inhalacion, 10000, new[] { Sintomas.AfasiaTemporal, Sintomas.Tinnitus }, 45.0, 55, new[] { AntidotosConocidos.Penicilamina }),
    new (29, "Cicuta Mayor", "Parálisis ascendente", 600, Disponibilidad.Comun, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 60, new[] { Sintomas.Disnea, Sintomas.Sincope }, 80.0, 20, new[] { AntidotosConocidos.JarabeDeIpecacuana }),
    new (30, "Digitalis Concentrada", "Fibrilación ventricular", 900, Disponibilidad.Comun, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 30, new[] { Sintomas.ArritmiaSevera, Sintomas.IctericiaBiliar }, 88.0, 12, new[] { AntidotosConocidos.Digibind }),
    new (31, "Ricino", "Inhibidor ribosómico", 4000, Disponibilidad.Secreta, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 240, new[] { Sintomas.Melena, Sintomas.Hemoptisis }, 98.0, 2, new[] { AntidotosConocidos.CarbonActivado }),
    new (32, "Hongo Amanita", "Destrucción del hígado", 1100, Disponibilidad.Rara, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 1440, new[] { Sintomas.IctericiaBiliar, Sintomas.Inapetencia }, 96.0, 4, new[] { AntidotosConocidos.Piridoxina }),
    new (33, "Vapor de Azufre", "Asfixia mecánica", 100, Disponibilidad.Comun, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Inhalacion, 1, new[] { Sintomas.Disnea, Sintomas.Cianosis }, 60.0, 40, new[] { AntidotosConocidos.CarbonActivado }),
    new (34, "Curare de Caza", "Relajación muscular total", 2800, Disponibilidad.Secreta, NivelPeligro.Extremo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Contacto, 2, new[] { Sintomas.AfasiaTemporal, Sintomas.Disnea }, 97.0, 3, new[] { AntidotosConocidos.JarabeDeIpecacuana }),
    new (35, "Antimonio", "Corrosivo gástrico", 550, Disponibilidad.Comun, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 180, new[] { Sintomas.Melena, Sintomas.Inapetencia }, 50.0, 50, new[] { AntidotosConocidos.CarbonActivado }),
    new (36, "Solanina", "Neurotoxina de brotes", 200, Disponibilidad.Comun, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 360, new[] { Sintomas.Parestesia, Sintomas.FiebreMiliar }, 15.0, 85, new[] { AntidotosConocidos.CarbonActivado }),
    new (37, "Tejo Rojo", "Taxinas cardiotóxicas", 1300, Disponibilidad.Rara, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 50, new[] { Sintomas.ArritmiaSevera, Sintomas.Sincope }, 82.0, 18, new[] { AntidotosConocidos.AtropinaSintetica }),
    new (38, "Veneno de Escorpión", "Dolor y shock", 3200, Disponibilidad.Secreta, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, ViaAdministracion.Contacto, 5, new[] { Sintomas.Parestesia, Sintomas.PruritoIntenso }, 40.0, 60, new[] { AntidotosConocidos.SueroPolivalente }),
    new (39, "Metanol Destilado", "Ceguera y acidosis", 400, Disponibilidad.Comun, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 720, new[] { Sintomas.Midriasis, Sintomas.AfasiaTemporal }, 25.0, 75, new[] { AntidotosConocidos.EtanolGradoMedico }),
    new (40, "Yodo Concentrado", "Oxidante tisular", 300, Disponibilidad.Comun, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, ViaAdministracion.Oral, 30, new[] { Sintomas.FiebreMiliar, Sintomas.EdemaRenal }, 20.0, 80, new[] { AntidotosConocidos.AlmidonLiquido })
};

    // --- 🌹 AFRODISIACOS (Usa Sintomas como Riesgos) ---
  private static List<Afrodisiacos> GetSeedAfrodisiacos() => new() {
    new (41, "Chocolate Real", "Cacao y pimienta roja", 1000, Disponibilidad.Rara, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Media, 120, new[] { Contraindicaciones.DiabetesImperial }, new[] { Sintomas.ArritmiaSevera }),
    new (42, "Madera de Oud", "Incienso hipnótico", 900, Disponibilidad.Rara, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 60, new[] { Contraindicaciones.AlergiaAlPolen }, new[] { Sintomas.Sincope }),
    new (43, "Asta de Ciervo", "Vigorizante de las estepas", 2500, Disponibilidad.Secreta, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Alta, 240, new[] { Contraindicaciones.EstadoDeAnemia }, new[] { Sintomas.ArritmiaSevera }),
    new (44, "Vino de Canela", "Dulzor estimulante", 150, Disponibilidad.Comun, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 90, new[] { Contraindicaciones.UlceraGastrica }, new[] { Sintomas.Inapetencia }),
    new (45, "Mandrágora Blanca", "Efecto narcótico-pasional", 1800, Disponibilidad.Secreta, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Extrema, 300, new[] { Contraindicaciones.EdadAvanzada }, new[] { Sintomas.AfasiaTemporal }),
    new (46, "Aceite de Ámbar", "Para masajes sugerentes", 500, Disponibilidad.Rara, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 180, new[] { Contraindicaciones.EstadoDeAnemia }, new[] { Sintomas.PruritoIntenso }),
    new (47, "Orquídea Negra", "Atractivo irresistible", 4000, Disponibilidad.Secreta, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Alta, 120, new[] { Contraindicaciones.ConsumoDeAlcohol }, new[] { Sintomas.Parestesia }),
    new (48, "Miel de Montaña", "Dulzor vigorizante", 80, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 45, new[] { Contraindicaciones.ConsumoDeAlcohol }, new[] { Sintomas.FiebreMiliar }),
    new (49, "Polvo de Diamante", "Excentricidad de palacio", 9999, Disponibilidad.Secreta, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Media, 60, new[] { Contraindicaciones.HipertensionArterial }, new[] { Sintomas.Tinnitus }),
    new (50, "Lirio del Nilo", "Estimulante floral", 650, Disponibilidad.Rara, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Media, 150, new[] { Contraindicaciones.AlergiaAlPolen }, new[] { Sintomas.Sincope }),
    new (51, "Corteza de Yohimbe", "Efecto físico potente", 1100, Disponibilidad.Rara, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Alta, 200, new[] { Contraindicaciones.InsuficienciaCardiaca }, new[] { Sintomas.ArritmiaSevera }),
    new (52, "Trufa Blanca", "Estimulante gourmet", 2200, Disponibilidad.Secreta, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 60, new[] { Contraindicaciones.UlceraGastrica }, new[] { Sintomas.Inapetencia }),
    new (53, "Cardamomo Verde", "Calor interno", 100, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 30, new[] { Contraindicaciones.DiabetesImperial }, new[] { Sintomas.FiebreMiliar }),
    new (54, "Extracto de Cobra", "Pasión peligrosa", 4500, Disponibilidad.Secreta, NivelPeligro.Alto, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Extrema, 45, new[] { Contraindicaciones.InsuficienciaCardiaca }, new[] { Sintomas.Cianosis }),
    new (55, "Vainilla Real", "Aroma de seducción", 120, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 240, new[] { Contraindicaciones.EdadAvanzada }, new[] { Sintomas.Parestesia }),
    new (56, "Nuez de Kola", "Energía duradera", 350, Disponibilidad.Rara, NivelPeligro.Bajo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Media, 360, new[] { Contraindicaciones.HipertensionArterial }, new[] { Sintomas.Tinnitus }),
    new (57, "Musgo de Roble", "Aroma terroso", 280, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Baja, 120, new[] { Contraindicaciones.AlergiaAlPolen }, new[] { Sintomas.PruritoIntenso }),
    new (58, "Poción de Loto Azul", "Relajación mística", 3800, Disponibilidad.Secreta, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Alta, 180, new[] { Contraindicaciones.ConsumoDeAlcohol }, new[] { Sintomas.AfasiaTemporal }),
    new (59, "Raíz de Maca", "Vigor andino", 95, Disponibilidad.Comun, NivelPeligro.Nulo, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Media, 500, new[] { Contraindicaciones.AfeccionRenal }, new[] { Sintomas.EdemaRenal }),
    new (60, "Sangre de Dragón", "Resina estimulante", 6000, Disponibilidad.Secreta, NivelPeligro.Medio, DateTime.Now, DateTime.Now, false, IntensidadEfecto.Extrema, 30, new[] { Contraindicaciones.HipertensionArterial }, new[] { Sintomas.Cianosis })
    
  };
}