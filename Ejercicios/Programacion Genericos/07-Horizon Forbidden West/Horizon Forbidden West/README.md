# 🏹 Project Zero Dawn: Focus Data System

## 📝 Descripción del Proyecto
Este sistema representa el motor de procesamiento de datos del **Foco** de Aloy. Se ha diseñado una arquitectura técnica en **.NET 10** orientada a la gestión y análisis de la megafauna robótica y las facciones humanas en el **Oeste Prohibido**. 

El proyecto destaca por el desarrollo de estructuras de datos personalizadas y una implementación artesanal de **programación funcional**, prescindiendo de las librerías de colecciones estándar de C# para garantizar un control total sobre la lógica de punteros y el uso de memoria.

---

## 🧬 Modelado de Entidades (Jerarquía de GAIA)

El sistema se basa en una estructura de **Records** inmutables que garantiza la integridad de los datos históricos:

### 1. EntidadHorizon (Base Abstracta)
Núcleo común de todos los escaneos del Foco.
* `Id`: Identificador numérico único.
* `Nombre`: Denominación común del hallazgo.
* `CodigoGaia`: Identificador oficial (Validado por Regex: `MQU-XXXX-2026`).
* `FechaEscaneo`: Marca de tiempo automática del registro.

### 2. Maquina (Especialización)
Representación de la fauna robótica y su peligrosidad.
* `Clase`: Enum (`Transporte`, `Lidia`, `Reconocimiento`, `Reguladora`).
* `NivelPeligro`: Escala numérica de amenaza (1-100).
* `DebilidadElemental`: Tipo de daño efectivo (Fuego, Hielo, Ácido).
* `EsSaboteable`: Estado de compatibilidad con la lanza de Aloy.

### 3. Cazador (Especialización)
Registro de las facciones humanas del Oeste Prohibido.
* `Tribu`: Enum (`Nora`, `Tenakth`, `Utaru`, `Oseram`).
* `Rango`: Posición jerárquica (Buscadora, Mariscal, Capellán).
* `FuerzaCombate`: Índice de poder militar.

---

## 🏗️ Especificaciones Técnicas

### 📂 Gestión de Memoria y Datos
* **Estructura Dinámica:** Implementación de una `ListaEnlazadaPropia<T>` genérica basada en nodos, gestionando manualmente la navegación y el almacenamiento.
* **Algoritmos de Ordenación:** Uso del método **Bubble Sort** para la jerarquización de amenazas, permitiendo clasificar las entidades según su índice de peligrosidad de forma descendente.

### ⚙️ Paradigma Funcional "Hand-Made"
El sistema integra capacidades de análisis avanzado mediante el uso de **delegados y predicados**:
* **Filtrado Selectivo:** Generación de sub-listas basadas en criterios variables (ej. `lista.Filtrar(m => m.NivelPeligro > 80)`).
* **Contadores Condicionales:** Cálculo de métricas sin necesidad de iteraciones externas al servicio.
* **Búsqueda por Predicado:** Localización de registros únicos mediante funciones lambda aplicadas al motor de búsqueda.

### 🛡️ Capa de Integridad y Validación
* **Protocolo de GAIA:** Validación de identificadores mediante **Expresiones Regulares (Regex)**.
* **Control de Rango:** Verificación estricta de parámetros en niveles de peligrosidad y estados elementales.

### 🧱 Patrones de Diseño
* **Factory (El Caldero):** Centralización de la instanciación de objetos para desacoplar la creación de máquinas y cazadores.
* **Inmutabilidad:** Uso de copias no destructivas (`with`) para actualizaciones seguras.

---

## 📋 Módulos del Sistema (CRUD)
1.  **[Añadir]** Registro de hallazgos mediante el **CalderoFactory**.
2.  **[Listar]** Visualización completa de la base de datos de máquinas.
3.  **[Analizar]** Herramientas funcionales para detectar amenazas de nivel alto.
4.  **[Actualizar]** Sincronización de estados usando el operador `with`.
5.  **[Eliminar]** Baja de registros de la memoria local del Foco.
6.  **[Ranking]** Clasificación dinámica mediante nivel de peligro.

---
*"El foco no solo ve lo que hay, ve lo que los demás ignoran."*