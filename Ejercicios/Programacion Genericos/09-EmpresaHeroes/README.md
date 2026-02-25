# 🛡️ Academia de Héroes - RPG Management System

¡Bienvenido al sistema central de la **Academia de Héroes**! Este es un simulador de gestión de personajes desarrollado en **.NET 10**, diseñado para administrar legiones de guerreros, magos y arqueros con una arquitectura de software robusta.

---

## 🚀 Funcionalidades Estrella

* **⚡ Sistema de Combate**: Resolución de misiones basada en cálculos de poder específicos por clase.
* **📈 Progresión Real**: Los héroes pueden **entrenar** (subir poder base) y **descansar** (recuperar energía).
* **🗂️ Gestión Inteligente**: Repositorio con patrón **Singleton**, sistema de **Caché** y validadores automáticos.
* **📊 Semilla de Datos**: El sistema arranca con **45 héroes** pre-cargados listos para la acción.
* **🎨 Interfaz UI**: Consola decorada con colores y reportes visuales de batalla.

---

## 🧬 Jerarquía de Clases y Poder

El sistema utiliza **C# Records** y herencia para definir el comportamiento de cada héroe:

| Clase | Atributo Principal | Fórmula de Poder Total |
| :--- | :--- | :--- |
| **⚔️ Guerrero** | Poder Base | $PoderBase \times 1.5$ |
| **🪄 Mago** | Experiencia | $Experiencia \times 0.5$ |
| **🏹 Arquero** | Nivel | $Nivel \times 2$ |

---

## 🔮 Próximas Implementaciones (Roadmap)

Estamos trabajando para evolucionar la academia. La siguiente gran actualización incluirá:

* **🗺️ Simulación en Matriz**: Implementación de un mapa bidimensional (`Heroe[,] mapa`) para visualizar el posicionamiento de los personajes.
* **🏃 Movimiento Dinámico**: Ver cómo los personajes se desplazan por la matriz hacia las zonas de entrenamiento o los puntos de misión.
* **⚔️ Colisiones y Eventos**: Interacción real entre héroes cuando coinciden en la misma coordenada de la matriz.

---

## 🛠️ Tecnologías Utilizadas

* **C# 12 / .NET 10**: Uso de *Primary Constructors* y *Records*.
* **LINQ**: Filtrado y ordenamiento avanzado de rankings.
* **Serilog**: Registro estructurado de eventos.

---

## 📂 Estructura del Código

```bash
EmpresaHeroes/
├── 📁 Models/      # Records inmutables (Heroe, Mision)
├── 📁 Factory/     # HeroesFactory (Semilla de 45 héroes)
├── 📁 Service/     # Lógica de negocio e IHeroesService
├── 📁 Repository/  # HeroeRepository (Persistencia Singleton)
├── 📁 Validator/   # ValidadorGuerrero, ValidadorMago...
└── 📄 Program.cs   # Interfaz de Consola y Orquestación