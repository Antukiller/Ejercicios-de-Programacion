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

### 2. Maquina (Hereda de EntidadHorizon)
Representa la fauna robótica. Implementa la interfaz de combate y sabotaje.
* **Interfaz `IMaquina`:** Métodos como `AnalizarDebilidad()`, `Sabotear()` y `ExtraerComponentes()`.
* **Atributos:** `ClaseMaquina` (Lidia, Transporte...), `NivelPeligro` (1-100), `DebilidadElemental`.

### 3. Cazador (Hereda de EntidadHorizon)
Representa a los guerreros de las tribus (Equivalente a *Estudiante*).
* **Interfaz `ICazador`:** Métodos como `Entrenar()`, `RealizarMision()` y `SubirRango()`.
* **Atributos:** `Tribu`, `NivelHabilidad`, `Especializacion`, `Ciclo`.

### 4. Saboteador (Hereda de EntidadHorizon)
Representa a especialistas técnicos y maestros (Equivalente a *Docente*).
* **Interfaz `ISaboteador`:** Métodos como `HackearRed()`, `RepararNucleo()` y `EnseñarHabilidad()`.
* **Atributos:** `AniosExperiencia`, `Faccion`, `CertificadoCaldero`.

---

## 🗂️ Diccionarios de Datos (Enums de Especialización)

Para clasificar el conocimiento y el progreso, el sistema utiliza los siguientes módulos de datos:

### 🛠️ Áreas de Especialización (Antiguos "Módulos")
Ramas de conocimiento que un Cazador o Saboteador debe dominar para operar el Foco:
* **Balística de Flechas** (Base de Datos)
* **Ingeniería de Calderos** (Entornos de Desarrollo)
* **Protocolos de GAIA** (Sistemas Informáticos)
* **Análisis de Máquinas** (Lenguajes de Marcas)
* **Sigilo y Supervivencia** (Programación)

### 📈 Ciclo de Entrenamiento (Antiguos "Cursos")
Define la veteranía del usuario en la red:
* **Iniciado** (Primero)
* **Vanguardia** (Segundo)

---

## 🏗️ Especificaciones Técnicas

### 📂 Gestión de Memoria y Datos
* **Estructura Dinámica:** Implementación de una `ListaEnlazadaPropia<T>` genérica basada en nodos.
* **Algoritmos de Ordenación:** Uso de **Bubble Sort** para la jerarquización de amenazas por nivel de peligro.

### ⚙️ Paradigma Funcional "Hand-Made"
Uso de **delegados y predicados** para operaciones de orden superior:
* **Filtrado:** `lista.Filtrar(e => e is Maquina m && m.NivelPeligro > 80)`.
* **Conteo:** `lista.ContarSi(e => e is Cazador c && c.Ciclo == Ciclo.Iniciado)`.

### 🛡️ Capa de Integridad y Validación
* **Protocolo de GAIA:** Validación mediante **Regex** (`MQU-XXXX-2026`).
* **Validación de Dominio:** Los niveles de peligro y años de experiencia deben estar en rangos positivos y coherentes.

### 🧱 Patrones de Diseño
* **Factory (El Caldero):** Centralización de la creación de objetos según el tipo de hallazgo.
* **Inmutabilidad:** Uso de copias no destructivas (`with`) para actualizaciones seguras.

---

## 📋 Módulos del Sistema (CRUD)
1. **[Añadir]** Registro de Máquinas, Cazadores e IAs mediante el **CalderoFactory**.
2. **[Listar]** Visualización del catálogo de la biosfera.
3. **[Analizar]** Filtros funcionales para detectar amenazas o especialistas.
4. **[Actualizar]** Sincronización de niveles y especializaciones usando el operador `with`.
5. **[Eliminar]** Purga de datos corruptos de la memoria.
6. **[Ranking]** Clasificación dinámica por peligrosidad o veteranía.

---
*"El foco no solo ve lo que hay, ve lo que los demás ignoran."*