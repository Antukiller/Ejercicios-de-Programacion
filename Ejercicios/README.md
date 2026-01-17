# ⚔️ The Witcher 3: Sistema de Combate Dinámico

Este proyecto implementa un sistema de gestión de personajes y habilidades basado en el universo de *The Witcher 3*, enfocado en demostrar el uso de **Composición sobre Herencia** y el manejo de **Casting explícito** en C#.

## 🎯 Objetivos del Ejercicio
- Implementar el **Patrón Strategy** para permitir que un personaje cambie su comportamiento en tiempo de ejecución.
- Practicar la jerarquía de interfaces para organizar habilidades (Magia, Espada, Alquimia).
- Dominar el uso de **Casting** para acceder a métodos específicos de una implementación desde una referencia de interfaz genérica.

## 🏗️ Arquitectura del Sistema

El diseño se basa en una clase contenedora (`Brujo`) que delega sus acciones a un objeto de estrategia (`IRolEstrategiaBrujo`).

### Componentes Clave:
1. **Clase Persona/Brujo**: Actúan como el contenedor principal de la identidad y el estado.
2. **Árbol de Interfaces**:
   - `IRolEstrategiaBrujo`: Interfaz base para todos los comportamientos.
   - `IEstiloEspada`: Especialización para combate físico (`AsestarGolpe`).
   - `IEstiloMagico`: Especialización para señales mágicas (`LanzarSeñal`).
   - `IAlquimista`: Especialización para pociones (`DestilarPocion`).
3. **Roles Concretos**: Implementaciones reales como `RolAcero`, `RolQuen`, `RolIgni`, etc.

## 🔍 Ejemplo de Implementación: El Poder del Casting

El núcleo de este ejercicio es entender cómo tratar a un objeto genérico como uno específico cuando sabemos que tiene las capacidades necesarias:

```csharp
// Cambiamos la estrategia en tiempo de ejecución
geralt.cambiarEstrategia(new RolQuen());

// Realizamos casting explícito para acceder a métodos que no están en la interfaz base
((RolQuen)geralt.Estrategia).LanzarSeñal();
