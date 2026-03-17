# ⚽ PROJECT BLUE LOCK: PLAYER MANAGEMENT SYSTEM
> [!IMPORTANT]  
> "En este lugar, los mediocres no tienen nombre. Solo aquellos que logran devorar el campo y demostrar su valía como delanteros merecen ser gestionados en mi sistema. ¿Eres un diamante en bruto o simple basura?"
> — **Jinpachi Ego**

---

## 📝 DESCRIPCIÓN
Este sistema es una plataforma de control de activos diseñada para gestionar la base de datos de los **300 delanteros** de Blue Lock. El objetivo principal es el mantenimiento (CRUD) de los perfiles de los jugadores, la actualización de sus rankings y el seguimiento de su evolución tras los partidos de selección.

Desarrollado como proyecto para **1º de DAW**, este software pone a prueba la capacidad de gestionar colecciones complejas de objetos, persistencia en archivos y filtrado dinámico de datos.

---

> [!TIP]
> "Si nunca aceptas la frustración de perder, no serás capaz de crecer." — **Seishiro Nagi**



## 🟦 1. GESTIÓN DE JUGADORES (Entidad Principal)

El corazón del sistema es el **Jugador**. El software permite clasificar a los delanteros en tres categorías funcionales, cada una con su propia lógica de crecimiento:

### 🧩 Atributos del Jugador
* **Identificador Único:** (ID autogenerado).
* **Perfil Personal:** Nombre, Apodo, Edad y Equipo de procedencia.
* **Estadísticas de Supervivencia:** Ranking (1-300) y Nivel de Egoísmo.
* **Arsenal de Armas:** Una lista integrada de habilidades técnicas que el jugador ha "despertado".
* **Estado de Disponibilidad:** (Activo y Eliminado).

### 🏹 Tipos de Delantero (Especializaciones)
1.  **Finalizadores (Finishers):** Jugadores con bonificaciones en precisión y potencia de tiro.
2.  **Creadores de Juego (Playmakers):** Jugadores con alta capacidad de lectura (Metavisión) y adaptabilidad.
3.  **Tanques Físicos (Physical Strikers):** Jugadores que destacan por fuerza, velocidad y resistencia.

---


> [!CAUTION]
> "Mírame bien, plebeyo. Aquí solo hay un Rey, y el resto solo son actores secundarios en mi camino al trono."
> — ***Shouei Barou***


## 📊 2. LOGICA DE PARTIDOS Y SELECCIÓN

El sistema no solo guarda nombres, gestiona el **destino** de los jugadores basándose en su rendimiento en los partidos:
* **Registro de Resultados:** Goles, asistencias e intensidad de juego por cada jugador.
* **Simulador de Evolución:** Tras un partido, el sistema permite actualizar el ranking del jugador y añadir nuevas habilidades a su ficha personal.
* **Criterio de Eliminación:** Función lógica que marca a los jugadores como "Eliminados" si no cumplen con los objetivos de Ego marcados por la dirección.

---

> [!CAUTION]
> "Para mí, el campo es un campo de batalla, y solo el que está dispuesto a morir puede ganar."
> — ***Itoshi Rin***

## 🔒 3. FUNCIONALIDADES DEL SOFTWARE

### 📋 Operaciones de Gestión (CRUD)
* **Reclutamiento:** Registro de nuevos delanteros en el sistema.
* **Actualización de Ficha:** Modificar estadísticas, cambiar el estado de salud o subir de nivel una habilidad del arsenal.
* **Purga del Sistema:** Eliminación (borrado lógico o físico) de los jugadores que fracasan en la selección.

### ⚡ Consultas Estratégicas (LINQ)
El sistema permite a Ego obtener información crítica mediante consultas rápidas:
* **Top de Elite:** Listar los 10 mejores jugadores del ranking.
* **Buscador por "Arma":** Encontrar a todos los jugadores que tengan una habilidad específica (ej. "Tiro Directo").
* **Informe de Bajas:** Mostrar todos los jugadores con estado "Eliminado" o "Lesionado".

### 📤 Persistencia y Almacenamiento
* **Base de Datos JSON:** Toda la información de los jugadores y sus listas de habilidades se guarda en `jugadores.json`.
* **Carga Automática:** Al iniciar el programa, se recupera el estado de la selección para continuar con la competición.

---


## ⚠️ ÚLTIMA ADVERTENCIA

> [!WARNING]
> ### "¿Díganme... van a ser un simple error estadístico o la anomalía que el mundo no pueda ignorar?"
> Entiendan esto: el talento es solo una entrada para el espectáculo, si no tienen el ego suficiente para adueñarse del escenario mejor quédense en la fila con el resto de los espectadores.
>
> El progreso no es para todos, alguien tiene que quedarse sentado aplaudiendo. ¿Quieres ser el que aplaude? Quédate sentado. Después de todo, necesitamos mediocres como tú para alimentar el ego de mis diamantes en bruto. **Lock Off.**
>
> — ***Jinpachi Ego***

