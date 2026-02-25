# ⚔️ Solo Leveling: Hunter Query System (LINQ Mastery)

Este proyecto es una demostración exhaustiva del uso de **LINQ (Language Integrated Query)** en C#. A través de una base de datos simulada de cazadores basada en el universo de *Solo Leveling*, se resuelven más de 30 consultas técnicas que demuestran el poder del filtrado y la manipulación de datos en .NET.

## 📋 Descripción del Escenario

El sistema gestiona una lista dinámica de `Hunters` (Cazadores) con las siguientes propiedades:
- **Rango**: Clasificación de poder (S, A, B, C, D, E).
- **Clase**: Especialidad de combate (Monarca, Espadachín, Mago, Tanque, etc.).
- **Nivel**: Valor numérico de fuerza actual.
- **Gremio**: Afiliación (Ahjin, Hunters, White Tiger, Scavenger, etc.).
- **Estado**: Booleano que indica si el cazador sigue activo (`EstaVivo`).

---

## 🧬 Jerarquía y Clasificación

El sistema utiliza la siguiente lógica para categorizar a los miembros:

| Rango | Perfil | Rol Típico |
| :--- | :--- | :--- |
| **S** | Leyendas | Monarcas y Líderes Nacionales |
| **A** | Élite Operativa | Comandantes de incursión |
| **B/C** | Soporte | Sanadores y Guerreros de rango medio |
| **D/E** | Novatos | Reclutas en fase de aprendizaje |

---

## 🛠️ Tecnologías y Conceptos LINQ Aplicados

* **Lenguaje**: C# 12 / .NET 8.0+.
* **Method Syntax**: Uso de métodos de extensión para consultas fluidas.
* **Operadores Implementados**:
    * **Filtrado**: `Where`, `Count`, `Any`, `All`.
    * **Ordenación**: `OrderBy`, `OrderByDescending`.
    * **Agregación**: `Average`, `Sum`, `Max`, `Min`.
    * **Agrupación**: `GroupBy` combinado con `ToDictionary`.
    * **Selección**: `Select` con Proyecciones y Tipos Anónimos.
    * **Paginación**: `Skip` y `Take`.

---

## 💻 Ejemplo de Salida en Consola

Al ejecutar la aplicación, el sistema procesa la lógica y genera un reporte detallado:

```csharp
*** 1. Listado General: Muestra todos los cazadores registrados ***
[ID: 1] Sung Jin-woo | Rango: S | Clase: Monarca | Nivel: 146
[ID: 2] Cha Hae-In   | Rango: S | Clase: Espadachín | Nivel: 85
...

*** 7. Líder del Ranking: Imprimir el cazador con mayor nivel ***
[ID: 1 | Nombre: Sung Jin-woo | Nivel: 146 | Clase: Monarca] 👑

*** 15. Poder Gremial: Nota (nivel) media por cada gremio ***
Ahjin: 62.00
Hunters: 77.33
Scavenger: 87.50
Asociación: 82.50
Ninguno: 35.40

*** 17. Extremos por Gremio: Mejor y peor cazador por gremio ***
Hunters: Mejor = 85 (Cha Hae-In), Peor = 65 (Jung Yoon-tae)
White Tiger: Mejor = 88 (Baek Yoon-ho), Peor = 68 (Park Heui-jin)

*** 23. Alerta de Monarca: ¿Existe algún cazador con clase 'Monarca'? ***
⚠️ ¡Sí, hay un cazador clase Monarca!

*** Extra: Gremio más equilibrado (menor brecha de poder) ***
El gremio más equilibrado es: Asociación (Brecha: 15) ⚖️
```

