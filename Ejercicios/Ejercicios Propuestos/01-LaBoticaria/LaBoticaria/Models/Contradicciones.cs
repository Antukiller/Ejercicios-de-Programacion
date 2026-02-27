namespace LaBoticaria;

public static class Contraindicaciones
{
    // Estructura: (Nombre, Gravedad del riesgo, Descripcion)
    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        InsuficienciaCardiaca = ("Insuficiencia Cardíaca", 10, "Riesgo de infarto por aumento de presión");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        EmbarazoPrimerTrimestre = ("Embarazo Temprano", 9, "Posible efecto abortivo por estimulación uterina");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        HipertensionArterial = ("Hipertensión", 7, "Peligro de ruptura de vasos sanguíneos");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        AfeccionRenal = ("Fallo Renal", 6, "Incapacidad de filtrar los componentes de la sustancia");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        EstadoDeAnemia = ("Anemia Crónica", 4, "Puede causar desmayos por redistribución del flujo sanguíneo");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        ConsumoDeAlcohol = ("Interacción con Alcohol", 8, "Potencia el efecto tóxico y nubla el juicio");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        EdadAvanzada = ("Senilidad", 5, "Efectos impredecibles en el sistema nervioso");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        AlergiaAlPolen = ("Sensibilidad Botánica", 3, "Posible shock anafiláctico por origen floral");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        UlceraGastrica = ("Úlcera Viva", 6, "Irritación extrema de las paredes del estómago");

    public static readonly (string Nombre, int Riesgo, string Descripcion) 
        DiabetesImperial = ("Desbalance de Azúcar", 5, "Altera los niveles de energía de forma violenta");
}