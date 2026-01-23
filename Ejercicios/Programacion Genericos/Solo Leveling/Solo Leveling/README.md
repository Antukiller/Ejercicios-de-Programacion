# ⚔️ Hunter System: Práctica de Genéricos y Varianza (C#)

Este proyecto es un ejercicio práctico desarrollado para el módulo de **Programación**. Utiliza la temática de *Solo Leveling* para implementar conceptos avanzados de POO, centrándose especialmente en la flexibilidad que ofrecen los tipos genéricos y la varianza en interfaces.

## 🎯 Objetivos de Aprendizaje
El propósito de este código es demostrar el dominio de:
1.  **Tipos Genéricos (`<T>`)**: Creación de clases reutilizables con restricciones (`where`).
2.  **Covarianza (`out`)**: Permitir el uso de tipos más derivados que los especificados originalmente (Lectura).
3.  **Contravarianza (`in`)**: Permitir el uso de tipos menos derivados o más genéricos (Escritura/Acción).
4.  **Pattern Matching**: Uso de `switch` y `is` para identificar tipos en tiempo de ejecución.
5.  **Arquitectura por Interfaces**: Desacoplamiento de la lógica de ataque (Pattern Strategy).

## 🧩 Conceptos Clave Explicados

### 📤 Covarianza (`out`)
Se aplica en la interfaz `IAlmacenSombras<out T>`. 
* **Por qué:** Como solo necesitamos **extraer** sombras (lectura), el compilador nos permite tratar un `EjercitoSombras<Sombra>` como un `IAlmacenSombras<Entidad>`. Esto facilita el polimorfismo en colecciones.



### 📥 Contravarianza (`in`)
Se aplica en la interfaz `IEvaluadorAsociacion<in T>`.
* **Por qué:** Aquí el tipo `T` entra como parámetro. Esto permite que un evaluador de "Entidades" (clase padre) sea capaz de procesar a un "CazadorMagico" (clase hija), ya que el evaluador general sabe manejar las propiedades básicas de cualquier entidad.



### 🔄 Pattern Matching
En la clase `MonarcaSombras`, el método `EjecutarHabilidadUnica` no conoce el tipo exacto de `T` en tiempo de compilación. Usamos `switch` sobre la interfaz para decidir qué habilidad ejecutar según el rol equipado actualmente.

## 📁 Estructura del Proyecto
* **/Models**: Jerarquía de clases (`Entidad` -> `Cazador`, `Sombra`).
* **/Interfaces**: Definición de contratos con varianza e interfaces de estrategia.
* **/Logic**: Implementación de clases genéricas como el `Ejercito` y el `Portal`.
* **Program.cs**: Punto de entrada con la simulación de la incursión.

## 💻 Requisitos
* .NET 8.0 SDK o superior.
* C# 12 (debido al uso de *Constructores Primarios*).

## 🛠️ Instalación y Ejecución
1. Clonar el repositorio.
2. Abrir en VS Code o Visual Studio.
3. Ejecutar `dotnet run` en la terminal.