# 🏹 Project Zero Dawn: Focus Data System

## 📝 Descripción del Proyecto
Este sistema representa el motor de procesamiento de datos del **Foco** de Aloy. Se ha diseñado una arquitectura técnica en **.NET 10** orientada a la gestión y análisis de la megafauna robótica y las facciones humanas en el **Oeste Prohibido**. 

El proyecto destaca por el desarrollo de estructuras de datos personalizadas y una implementación artesanal de **programación funcional**, prescindiendo de las librerías de colecciones estándar de C# para garantizar un control total sobre la lógica de punteros y el uso de memoria.

---

## 🧬 Modelado de Entidades (Jerarquía y Comportamiento)

El sistema utiliza **Interfaces** para definir comportamientos específicos y **Records** para la gestión de datos inmutables.

### 1. EntidadHorizon (Base Abstracta)
Núcleo común de todos los escaneos del Foco.
* `Id`, `Nombre`, `CodigoGaia`, `FechaEscaneo`.

### 2. Cazador (Hereda de EntidadHorizon)
Representa a los guerreros de las tribus. Implementa la interfaz de combate.
* **Interfaz `ICazador`:** Define métodos como `Entrenar()`, `RealizarMision()` y `SubirRango()`.
* **Atributos:** `Tribu`, `NivelHabilidad`, `Especializacion`.

### 3. IA de Soporte / Saboteador (Hereda de EntidadHorizon)
Representa a especialistas técnicos (como Sylens o los especialistas en el Foco).
* **Interfaz `ISaboteador`:** Define métodos como `AnalizarDebilidad()`, `HackearRed()` y `RepararComponente()`.
* **Atributos:** `AniosExperiencia`, `Faccion`, `CertificadoCaldero`.

---

## 🗂️ Diccionarios de Datos (Enums de Especialización)

Para clasificar el conocimiento y el progreso, el sistema utiliza los siguientes módulos de datos:

### 🛠️ Áreas de Especialización (Antiguos "Módulos")
Representan las ramas de conocimiento que un Cazador o Saboteador debe dominar:
* **Balística de Flechas** (Base de Datos)
* **Ingeniería de Calderos** (Entornos de Desarrollo)
* **Protocolos de GAIA** (Sistemas Informáticos)
* **Análisis de Máquinas** (Lenguajes de Marcas)
* **Sigilo y Supervivencia** (Programación)

### 📈 Ciclo de Entrenamiento (Antiguos "Cursos")
Define el nivel de veteranía del usuario en la red:
* **Iniciado** (Primero)
* **Vanguardia** (Segundo)

---

## 🏗️ Especificaciones Técnicas

### 📂 Gestión de Memoria y Datos
* **Estructura Dinámica:** Implementación de una `ListaEnlazadaPropia<T>` genérica basada en nodos.
* **Algoritmos de Ordenación:** Uso de **Bubble Sort** para la jerarquización de amenazas por nivel de peligro.

### ⚙️ Paradigma Funcional "Hand-Made"
Uso de **delegados y predicados** para operaciones de orden superior:
* **Filtrado:** `lista.Filtrar(c => c.Especializacion == Especializacion.Ingenieria)`.
* **Búsqueda:** Localización de registros mediante funciones lambda.

### 🛡️ Capa de Integridad y Validación
* **Protocolo de GAIA:** Validación de identificadores mediante **Regex** (`MQU-XXXX-2026`).
* **Validación de Dominio:** Los cazadores deben pertenecer a una tribu válida y las especializaciones deben ser acordes al ciclo de entrenamiento.

### 🧱 Patrones de Diseño
* **Factory (El Caldero):** Centralización de la creación de objetos según el tipo de hallazgo.
* **Inmutabilidad:** Uso de copias no destructivas (`with`) para actualizaciones seguras.

---

## 📋 Módulos del Sistema (CRUD)
1. **[Añadir]** Registro de Cazadores e IAs mediante el **CalderoFactory**.
2. **[Listar]** Visualización del catálogo de la biosfera.
3. **[Analizar]** Filtros funcionales para detectar especialistas de nivel alto.
4. **[Actualizar]** Sincronización de rangos y especializaciones usando el operador `with`.
5. **[Eliminar]** Purga de datos corruptos de la memoria local.
6. **[Ranking]** Clasificación dinámica por índice de poder o experiencia.

---
*"El foco no solo ve lo que hay, ve lo que los demás ignoran."*