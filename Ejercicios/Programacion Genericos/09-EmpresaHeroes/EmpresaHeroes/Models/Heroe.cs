namespace EmpresaHeroes.Models;


/// <summary>
/// Clase abstract heroe.
/// </summary>
/// <param name="nombre"></param>
/// <param name="poderBase"></param>
public abstract record Heroe(string nombre, double poderBase) {
    public int Id { get; set; }
    public string Nombre { get; set; } = nombre;
    public int Nivel { get; set; } = 1;
    public int Energia { get; set; } = 100;
    public int Experiencia { get; set; } = 0;
    public double PoderBase { get; set; } = poderBase;
    
    public DateTime CreateAt { get; init; }
    
    public DateTime UpdateAt { get; init; }
    
    public bool IsDeleted { get; init; }


    /// <summary>
/// Metodo virtual descansar. 
/// </summary>
    public virtual void Descansar() {
        Energia = Energia + 20;

        if (Energia > 100) {
            Energia = 100;
        }
        Console.WriteLine($"{Nombre} ha descansado. Energia actual: {Energia}");
    }


/// <summary>
/// Metodo virtual entrenar
/// </summary>
    public virtual void Entrenar() {

        if (Energia >= 20) {
            Energia -= 10;
            PoderBase += 5;
            Console.WriteLine($"{Nombre} ha entrenado duro. Poder base aumentado: {PoderBase}, Energia: {Energia}");
        }
        else {
            Console.WriteLine($"{Nombre} esta demasiado agotado para entrenar. Necesita descansar el insecto...");
        }

    }

/// <summary>
/// Metodo abstract que permite calcular el poder del heroe.
/// </summary>
    public abstract double CalcularPoderTotal();

}