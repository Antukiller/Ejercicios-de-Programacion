# 🏴‍☠️ One Piece Entity Management System

**Versión:** .NET 10 - "The Grand Line Edition"  
**Arquitectura:** Capas (Service, Repository, Models, Validators) con Persistencia en Memoria mediante Estructuras Propias.

Este sistema es una solución técnica avanzada para la gestión de las grandes potencias que operan en el Grand Line. Utiliza un modelo de datos basado en **Records** para registrar y validar a cada individuo, asegurando que la información recopilada sea íntegra y veraz.

## 🏗️ Jerarquía de Modelos (Record Classes)
El sistema aprovecha la potencia de los **`record class`** para garantizar la inmutabilidad de los datos y una gestión de igualdad eficiente basada en valores:

* **Entidad (Base):** La raíz de la jerarquía. Gestiona metadatos críticos como `Id`, `CreatedAt`, `UpdatedAt` y el estado de **Soft Delete** (`IsDeleted`). Redefine la igualdad comparando `NombreCompleto` y `Apodo`.
* **Pirata:** Especializado en forajidos. Incluye la gestión de la **Recompensa** (tipo `long` para cifras masivas), la **Tripulacion** y su **PosicionPirata**.
* **Marine:** Representa la fuerza de la justicia. Controla el **RangoMarine** oficial y la **BaseAsignada** donde el oficial presta servicio.
* **Fruta del Diablo:** Registro de habilidades sobrenaturales. Almacena el **TipoFruta** y el estado de **Despertar** (`IsDespertada`).

## 🛠️ Stack Tecnológico
* **ListaEnlazadaPropia<T>:** Estructura de datos personalizada basada en **Nodos**, desarrollada para gestionar la memoria de forma eficiente sin depender de las colecciones estándar de .NET.
* **Repositorio Singleton:** Se garantiza una única fuente de verdad mediante una instancia centralizada de la lista de entidades que persiste durante la ejecución.
* **Validadores Orientados a Objetos:** Siguiendo la lógica de negocio, cada alta o actualización es procesada por un validador que devuelve la instancia validada o `null` si los datos no cumplen los requisitos.
* **Motor de Estadísticas:** Capacidad de realizar análisis en tiempo real, como el cálculo de recompensas totales y el censo de usuarios con frutas despertadas mediante **Casting** y **Pattern Matching**.

## 📊 Protocolos de Validación y Análisis
El **ServiceOnePiece** coordina la lógica de negocio antes de persistir los datos en el repositorio:

| Entidad | Propiedad Clave | Regla de Validación |
| :--- | :--- | :--- |
| **Piratas** | `Recompensa` | No se permiten valores negativos; la infamia tiene un precio. |
| **Marines** | `Rango` | El rango debe estar definido según la jerarquía oficial de la Marina. |
| **Frutas** | `IsDespertada` | Se rastrea el potencial máximo alcanzado por el usuario. |

---

> "¡Alguien que no tiene sueños no puede destruir los sueños de los demás!" — **Monkey D. Luffy**

---

### 💡 Nota técnica para la entrega:
Este proyecto demuestra el uso de **Herencia**, **Polimorfismo** y estructuras de datos personalizadas para resolver problemas de gestión de información compleja en un entorno .NET moderno, separando claramente las responsabilidades entre la capa de datos, validación y servicio.