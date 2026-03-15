namespace LaBoticaria;


public static class RiesgosExcesivos 
{
    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        ParoCardiaco = ("Paro Cardíaco", 10, "Corazón", "Cese repentino de la función de bombeo del corazón");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        FalloHepaticoFulminante = ("Fallo Hepático Fulminante", 9, "Hígado", "Pérdida rápida de la función del hígado con necrosis tisular");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        EdemaPulmonar = ("Edema Pulmonar", 8, "Pulmones", "Acumulación de líquido en los pulmones que impide la respiración");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        ChoqueAnafilactico = ("Choque Anafiláctico", 9, "Sistema Inmune", "Reacción alérgica severa que colapsa el sistema circulatorio");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        NecrosisTubular = ("Necrosis Tubular Aguda", 8, "Riñones", "Daño grave en las células renales que provoca fallo renal");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        ComaInducido = ("Estado de Coma", 10, "Cerebro", "Pérdida prolongada de la conciencia por toxicidad severa");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        HemorragiaInterna = ("Hemorragia Masiva", 9, "Sistema Circulatorio", "Ruptura de vasos internos con pérdida crítica de sangre");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        PsicosisToxica = ("Psicosis Tóxica", 7, "Mente", "Desconexión total de la realidad con episodios de agresividad");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        ParalisisDiafragmatica = ("Parálisis Diafragmática", 9, "Sistema Respiratorio", "Incapacidad de mover los músculos respiratorios");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        ConvulsionesTonicoClonicas = ("Convulsiones Severas", 8, "Sistema Nervioso", "Espasmos musculares violentos y pérdida de control");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        CegueraIrreversible = ("Atrofia Óptica", 7, "Ojos", "Daño permanente en el nervio óptico por agentes químicos");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        TrombosisVenosa = ("Trombosis", 6, "Venas", "Formación de coágulos que pueden viajar a órganos vitales");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        DeliriumTremens = ("Delirio Agudo", 7, "Cerebro", "Confusión extrema, temblores y alucinaciones terroríficas");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        IsquemiaCerebral = ("Isquemia Cerebral", 9, "Cerebro", "Falta de riego sanguíneo en áreas críticas del encéfalo");

    public static readonly (string Nombre, int Riesgo, string Organo, string Descripcion)
        HipotensionExtrema = ("Colapso Vascular", 8, "Arterias", "Caída súbita de la presión que impide la perfusión de órganos");
}