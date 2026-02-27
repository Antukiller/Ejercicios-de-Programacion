namespace LaBoticaria;

public interface ITieneSintomas {
    List<(string Nombre, int Riesgo, string Organo, string Descripcion)> ListaSintomas { get; }
}