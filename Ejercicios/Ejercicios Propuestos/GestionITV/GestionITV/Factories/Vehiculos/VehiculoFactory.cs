using GestionITV.Enum;
using GestionITV.Models;

namespace GestionITV.Factory;
public static class VehiculoFactory {
    public static IEnumerable<Vehiculo> Seed() {
        var lista = new List<Vehiculo>();
        
        // Propietario 1: 3 coches (Límite máximo)
        string dni1 = "12345678Z";
        lista.Add(new Vehiculo { Matricula = "1234-ABC", Marca = "BMW", Modelo = "M4", Cilindrada = 3.0, Motor = Motor.Gasolina, DniPropietario = dni1 });
        lista.Add(new Vehiculo { Matricula = "1235ABC", Marca = "Audi", Modelo = "A3", Cilindrada = 1.6, Motor = Motor.Diesel, DniPropietario = dni1 });
        lista.Add(new Vehiculo { Matricula = "1236-ABC", Marca = "Tesla", Modelo = "Model 3", Cilindrada = 0.0, Motor = Motor.Electrico, DniPropietario = dni1 });

        // Propietario 2: 2 coches
        string dni2 = "87654321X";
        lista.Add(new Vehiculo { Matricula = "5678-DEF", Marca = "Seat", Modelo = "Ibiza", Cilindrada = 1.0, Motor = Motor.Gasolina, DniPropietario = dni2 });
        lista.Add(new Vehiculo { Matricula = "5679DEF", Marca = "Ford", Modelo = "Focus", Cilindrada = 1.5, Motor = Motor.Diesel, DniPropietario = dni2 });

        // Propietario 3: 2 coches
        string dni3 = "55555555M";
        lista.Add(new Vehiculo { Matricula = "9012-GHI", Marca = "Toyota", Modelo = "Corolla", Cilindrada = 1.8, Motor = Motor.Hibrido, DniPropietario = dni3 });
        lista.Add(new Vehiculo { Matricula = "9013GHI", Marca = "Hyundai", Modelo = "Ioniq", Cilindrada = 1.6, Motor = Motor.Hibrido, DniPropietario = dni3 });

        // Propietarios individuales (1 coche cada uno)
        lista.Add(new Vehiculo { Matricula = "1111-JKL", Marca = "Renault", Modelo = "Clio", Cilindrada = 1.2, Motor = Motor.Gasolina, DniPropietario = "11111111H" });
        lista.Add(new Vehiculo { Matricula = "2222-MNP", Marca = "Peugeot", Modelo = "208", Cilindrada = 1.5, Motor = Motor.Diesel, DniPropietario = "22222222J" });
        lista.Add(new Vehiculo { Matricula = "3333-QRS", Marca = "Citroen", Modelo = "C3", Cilindrada = 1.2, Motor = Motor.Gasolina, DniPropietario = "33333333S" });
        lista.Add(new Vehiculo { Matricula = "4444-TUV", Marca = "Mercedes", Modelo = "Clase A", Cilindrada = 2.0, Motor = Motor.Diesel, DniPropietario = "44444444P" });
        lista.Add(new Vehiculo { Matricula = "5555-WXY", Marca = "Volkswagen", Modelo = "Golf", Cilindrada = 2.0, Motor = Motor.Gasolina, DniPropietario = "66666666Q" });
        lista.Add(new Vehiculo { Matricula = "6666-ZAB", Marca = "Kia", Modelo = "Sportage", Cilindrada = 1.6, Motor = Motor.Hibrido, DniPropietario = "77777777W" });
        lista.Add(new Vehiculo { Matricula = "7777-CDE", Marca = "Mazda", Modelo = "CX-5", Cilindrada = 2.2, Motor = Motor.Diesel, DniPropietario = "88888888Y" });
        lista.Add(new Vehiculo { Matricula = "8888-FGH", Marca = "Porsche", Modelo = "911", Cilindrada = 3.0, Motor = Motor.Gasolina, DniPropietario = "99999999R" });
        lista.Add(new Vehiculo { Matricula = "9999-IJK", Marca = "Nissan", Modelo = "Leaf", Cilindrada = 0.0, Motor = Motor.Electrico, DniPropietario = "10101010K" });
        lista.Add(new Vehiculo { Matricula = "1010-LMN", Marca = "Volvo", Modelo = "XC40", Cilindrada = 2.0, Motor = Motor.Hibrido, DniPropietario = "20202020L" });
        lista.Add(new Vehiculo { Matricula = "2020-OPQ", Marca = "Honda", Modelo = "Civic", Cilindrada = 2.0, Motor = Motor.Gasolina, DniPropietario = "30303030X" });
        lista.Add(new Vehiculo { Matricula = "3030-RST", Marca = "Fiat", Modelo = "500", Cilindrada = 1.0, Motor = Motor.Electrico, DniPropietario = "40404040T" });
        lista.Add(new Vehiculo { Matricula = "4040-UVW", Marca = "Lexus", Modelo = "RX", Cilindrada = 2.5, Motor = Motor.Hibrido, DniPropietario = "50505050R" });

        return lista;
    }
}