# 🐺 Kaer Morhen Logistics & Alchemy System

Este proyecto evoluciona el sistema de combate de **The Witcher 3** hacia una arquitectura avanzada basada en **Genéricos**, **Varianza (Covarianza y Contravarianza)** y **Restricciones de Tipo (Constraints)** en C#.

El objetivo es gestionar la logística de la Escuela del Lobo, permitiendo que los suministros y los roles de los brujos sean tratados de forma flexible y segura sin recurrir al casting manual constante.

---

## 🏗️ Arquitectura del Sistema

### 1. Jerarquía de Suministros (Base para Varianza)
Para demostrar cómo fluyen los datos entre tipos base y derivados, implementamos la siguiente jerarquía:
* **`Suministro`** (Base): Propiedades `Nombre` y `Peso`.
* **`Pocion`** (Hereda de `Suministro`): Añade `DuracionEfecto`.
* **`Extracto`** (Hereda de `Pocion`): El objeto más específico con `NivelToxicidad`.

### 2. Gestión de Inventarios (Covarianza - `out`)
Implementamos la interfaz **covariante** `IInventarioConsulta<out T>`. Esto permite que un inventario de objetos específicos (ej. Pociones) pueda ser tratado como un inventario de objetos generales (ej. Suministros).
* **Regla:** Solo salida de datos (`return T`).
* **Uso:** `IInventarioConsulta<Suministro> lista = new Inventario<Pocion>();`



### 3. Laboratorio de Alquimia (Contravarianza - `in`)
Implementamos la interfaz **contravariante** `IProcesadorAlquimico<in T>`. Permite que un procesador diseñado para tipos generales pueda aceptar tipos más específicos.
* **Regla:** Solo entrada de datos (`param T`).
* **Uso:** `IProcesadorAlquimico<Extracto> lab = new ProcesadorGeneral<Suministro>();`



---

## 🎯 Objetivos Técnicos

| Concepto | Implementación |
| :--- | :--- |
| **Invarianza** | Uso de `List<T>` donde el tipo debe ser exacto. |
| **Covarianza** | Uso de `out T` en interfaces de lectura para permitir polimorfismo hacia arriba. |
| **Contravarianza** | Uso de `in T` en interfaces de acción para permitir polimorfismo hacia abajo. |
| **Constraints** | Uso de `where T : Suministro` para asegurar que los genéricos tengan acceso a propiedades base. |
| **Generics** | Clase `Brujo<T>` para eliminar la necesidad de Casting explícito al usar estrategias. |

---

## 🛠️ Guía de Implementación

### Fase de Brujos Genéricos
A diferencia de versiones anteriores, el brujo ahora es consciente de su especialidad desde su creación:

```csharp
// Ya no es necesario el casting: ((RolIgni)geralt.Estrategia).LanzarSenal()
Brujo<RolIgni> geralt = new Brujo<RolIgni>(new RolIgni());
geralt.Estrategia.LanzarSenal(); // Acceso directo y seguro