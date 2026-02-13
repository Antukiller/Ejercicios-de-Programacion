# 🐺 Proyecto: The Witcher's Contracts (Sistema de Gestión de Gremios)

## 📝 Escenario
El Tablón de Anuncios de Novigrado necesita un sistema automatizado para gestionar los encargos de los brujos. El objetivo es desarrollar una arquitectura sólida en C# que permita diferenciar entre **Contratos de Monstruos** y **Contratos de Asalto**, gestionando sus tácticas, aceites y señales de forma eficiente.

---

## 🏗️ 1. Arquitectura de Datos y Tipado

### A. Enumeraciones (Categorización)
* **`EspecieCriatura`**: `Necrofago`, `Espectro`, `Híbrido`, `Insectoide`, `Elementoide`, `Draconico`, `Vampiro`.
* **`TipoAceite`**: `Necrofagos`, `Espectros`, `Vampiros`, `Hibridos`, `Constructos`, `Ninguno`.

### B. Diccionario de Conocimiento (Clases Estáticas)
* **`Señal`**: Clase estática con constantes `string` que describen el efecto de *Igni, Aard, Quen, Axii y Yrden*.
* **`Debilidades`**: Clase estática con constantes `string` sobre vulnerabilidades (Plata, Fuego, Relictos).

---

## 📜 2. Interfaces (Contratos de Comportamiento)

El sistema debe basarse en la herencia de interfaces para garantizar que cada contrato tenga las herramientas adecuadas:

1.  **`IContrato`**: Interfaz base con el método `void MostrarDetalles()`.
2.  **`IBestiario` (Hereda de `IContrato`)**: 
    * `void PrepararAceite()`: Determina y aplica el aceite según la especie.
    * `string SeleccionarSeñal()`: Devuelve la descripción de la señal óptima.
    * `void MostrarDebilidades()`: Imprime el reporte táctico para el brujo.
3.  **`IEstrategia` (Hereda de `IContrato`)**:
    * `int CalcularProbabilidadExito()`: Lógica basada en el número de enemigos y sigilo.
    * `void PlanificarRuta()`: Determina el método de entrada (infiltración vs fuerza bruta).

---

## 🏛️ 3. Jerarquía de Clases

### Clase Base Abstracta: `ContratoBase`
* **Constructor Primario**: `(int id, string titulo, int nivel, double recompensa)`.
* **Propiedades**: Inmutables mediante el uso de `{ get; init; }`.
* **Implementación**: Debe implementar `IContrato` y marcar `MostrarDetalles()` como `abstract`.

### Clases Especializadas (`sealed`):
1.  **`ContratoMonstruo`**:
    * Atributo: `EspecieCriatura Monstruo`.
    * **Lógica**: Uso de `switch expressions` para mapear el Enum con la clase estática `Señal`.
2.  **`ContratoAsalto`**:
    * Atributos: `int NumeroEnemigos`, `bool RequiereSigilo`.
    * **Lógica**: Cálculo dinámico de dificultad.

---

## 🧪 4. Lógica de Ejecución (Program.cs)
El flujo principal debe demostrar el uso de polimorfismo y técnicas modernas:
* **Colecciones**: Uso de `List<ContratoBase>`.
* **Pattern Matching**: Recorrer la lista y usar `is` (ej. `if (contrato is IBestiario b)`) para ejecutar los comportamientos específicos de cada interfaz.

---

## 💾 5. Patrón de Diseño: Singleton
Implementar una clase `WitcherCache` que:
1.  Garantice una **única instancia** en memoria.
2.  Almacene temporalmente la lista de contratos activos.
3.  Simule la persistencia de datos (Carga/Guardado).

---

## ✅ Requisitos Técnicos
* Uso de **C# 12** (Constructores primarios).
* Uso de **Interpolación de cadenas** y **Switch Expressions**.
* Limpieza de código: Separación de archivos por carpetas (`Models`, `Enums`, `Constants`).