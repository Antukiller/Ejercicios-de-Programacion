namespace LaBoticaria;

public interface ITieneSintomas {
    IEnumerable<(string Nombre, int Riesgo, string Organo, string Descripcion)> ListaSintomas { get; }
}