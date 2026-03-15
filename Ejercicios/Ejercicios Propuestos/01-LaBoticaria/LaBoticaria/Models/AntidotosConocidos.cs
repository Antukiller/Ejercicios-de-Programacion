namespace LaBoticaria;

public static class AntidotosConocidos 
{
    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        CarbonActivado = ("Carbón Activado", 8, "Ingestión", "Absorbe toxinas en el tracto digestivo antes de que pasen a la sangre");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        AtropinaSintetica = ("Atropina", 9, "Inyección", "Bloquea los efectos del exceso de acetilcolina causado por el Acónito");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        NitritoDeSodio = ("Nitrito de Sodio", 9, "Intravenosa", "Convierte la hemoglobina en methemoglobina para unir el cianuro");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        QuelantesDePlomo = ("Agentes Quelantes", 7, "Oral/IV", "Se une a los metales pesados como el plomo para ser expulsados por la orina");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Fisostigmina = ("Fisostigmina", 8, "Inyección", "Antídoto específico para la intoxicación por Belladona");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Dimercaprol = ("BAL (Dimercaprol)", 7, "Intramuscular", "Desplaza al arsénico de las enzimas celulares");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Digibind = ("Fragmentos de Anticuerpos", 10, "Inyección", "Atrapa las moléculas de digitalis en la sangre de forma inmediata");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Diazepam = ("Benzodiacepinas", 6, "Inyección/Oral", "Controla las convulsiones mortales causadas por la Estricnina");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Tiosulfato = ("Tiosulfato de Sodio", 8, "Infusión", "Acelera la desintoxicación natural del cianuro de la Mandioca");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Penicilamina = ("Penicilamina", 7, "Oral", "Tratamiento de elección para la eliminación de mercurio");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        Piridoxina = ("Vitamina B6", 9, "Oral/IV", "Revierte los efectos neurológicos de ciertos hongos venenosos");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        JarabeDeIpecacuana = ("Ipecacuana", 5, "Oral", "Induce el vómito inmediato (solo usar si el veneno no es corrosivo)");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        SueroPolivalente = ("Suero Antiofídico", 9, "Inyección", "Neutraliza venenos de serpientes y ciertos arácnidos");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        EtanolGradoMedico = ("Etanol", 6, "Oral/IV", "Utilizado para bloquear la absorción de alcoholes tóxicos");

    public static readonly (string Nombre, int Efectividad, string Metodo, string Descripcion)
        AlmidonLiquido = ("Solución de Almidón", 5, "Lavado Gástrico", "Inactiva el yodo y otros oxidantes en el estómago");
}