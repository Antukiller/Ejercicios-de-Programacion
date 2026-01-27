# 📚 Sistema de Gestión de Biblioteca

Este proyecto es una aplicación de consola robusta desarrollada en **.NET 10** para la administración de recursos bibliográficos. Implementa principios avanzados de **Programación Orientada a Objetos (POO)**, estructuras de datos personalizadas y algoritmos de validación matemática.

## 🏗️ Arquitectura de Software

### Jerarquía de Herencia
El sistema se basa en un modelo de herencia para maximizar la reutilización de código y facilitar la escalabilidad. Todos los recursos derivan de una clase base abstracta:

* **Ficha (Clase Base):** Contiene atributos comunes como `Id`, `Titulo`, `Estante`, `CreatedAt` y `IsDeleted`.
    * **Libro:** Extiende Ficha añadiendo `Autor` e `Isbn`.
    * **Revista:** Extiende Ficha añadiendo `Edicion`.
    * **DVD:** Extiende Ficha añadiendo `Duracion`, `Director` y `Genero`.



---

## 🛠️ Desafíos Técnicos Implementados

### 1. Estructuras de Datos Propias
En lugar de utilizar colecciones estándar, se ha desarrollado una **`ListaEnlazadaPropia<T>`**:
* **Gestión de Nodos:** Implementación manual de punteros (`Siguiente`) para recorrer la memoria.
* **Eficiencia:** Métodos optimizados para `AgregarFinal`, `EliminarEn` y `ObternerEn`.

### 2. Algoritmos de Ordenación
Se implementó el algoritmo **Bubble Sort (Ordenamiento Burbuja)** para organizar los catálogos de forma personalizada:
* Ordenamiento por **Título** (Alfabético).
* Ordenamiento por **Autor** (Alfabético).
* Uso de `string.Compare` con manejo de sensibilidad a mayúsculas y validación de nulos.

### 3. Validaciones Avanzadas y Regex
* **ISBN-13:** Implementación del algoritmo **Módulo 10** para verificar el dígito de control matemático de los libros.
* **Expresiones Regulares:**
    * `ISBN:` Valida que la entrada tenga 10 o 13 dígitos numéricos permitiendo guiones y espacios.
    * `Estante:` Valida el formato de ubicación según el tipo (Ej: `A-12` para libros).
    * `Autor:` Controla que el nombre no contenga caracteres inválidos.

---

## 📋 Requisitos de los Datos (Reglas de Negocio)

| Entidad | Prefijo Estante | Validación Especial |
| :--- | :--- | :--- |
| **Libro** | `A-` | ISBN de 13 dígitos (Algoritmo Módulo 10) |
| **Revista** | `B-` | Número de edición positivo |
| **DVD** | `C-` | Duración en minutos |

---

## 🚀 Guía de Uso Rápido

1.  **Carga de Datos:** El sistema utiliza un **Factory Pattern** para cargar `DemoData` automáticamente al iniciar.
2.  **Menú Principal:**
    * `Añadir:` Solicita datos validados en tiempo real.
    * `Listar:` Muestra los elementos ordenados mediante el algoritmo Bubble Sort.
    * `Estadísticas:` Genera un informe porcentual de la composición de la biblioteca.

## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** C# 13 / .NET 10
* **IDE:** JetBrains Rider / Visual Studio
* **Logging:** Serilog para trazabilidad de errores y depuración del sistema.

---
**Nota para Desarrolladores:** El proyecto está diseñado siguiendo el patrón **Singleton** en los repositorios para garantizar la integridad de los datos en memoria durante toda la ejecución.