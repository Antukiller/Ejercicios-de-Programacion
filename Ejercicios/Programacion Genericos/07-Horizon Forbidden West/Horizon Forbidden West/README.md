# 🏹 Project Zero Dawn: Focus Data System

## 📝 Descripción del Proyecto
Este sistema representa el motor de procesamiento de datos del **Foco** de Aloy. Se ha diseñado una arquitectura técnica en **.NET 10** orientada a la gestión y análisis de la megafauna robótica y las facciones humanas en el **Oeste Prohibido**. 

El proyecto destaca por el desarrollo de estructuras de datos personalizadas y una implementación artesanal de **programación funcional**, prescindiendo de las librerías de colecciones estándar de C# para garantizar un control total sobre la lógica de punteros y el uso de memoria.

---

## 🏗️ Especificaciones Técnicas

### 📂 Gestión de Memoria y Datos
* **Estructura Dinámica:** Implementación de una `ListaEnlazadaPropia<T>` genérica basada en nodos, gestionando manualmente la navegación y el almacenamiento de los hallazgos.
* **Algoritmos de Ordenación:** Uso del método **Bubble Sort** para la jerarquización de amenazas, permitiendo clasificar las entidades según su índice de peligrosidad de forma descendente.

### ⚙️ Paradigma Funcional "Hand-Made"
El sistema integra capacidades de análisis avanzado mediante el uso de **delegados y predicados**, permitiendo operaciones de orden superior sobre la estructura de datos:
* **Filtrado Selectivo:** Generación de sub-listas basadas en criterios booleanos variables (ej. máquinas de clase Lidia).
* **Contadores Condicionales:** Cálculo de métricas específicas sin necesidad de iteraciones externas al servicio.
* **Búsqueda por Predicado:** Localización de registros únicos mediante funciones lambda aplicadas al motor de búsqueda.

### 🛡️ Capa de Integridad y Validación
* **Protocolo de GAIA:** Validación de identificadores mediante **Expresiones Regulares (Regex)**, asegurando que cada código de máquina cumpla con el estándar oficial: `MQU-XXXX-2026`.
* **Control de Rango:** Verificación estricta de parámetros numéricos en niveles de peligrosidad (1-100) y estados elementales.

### 🧱 Patrones de Diseño
* **Factory (El Caldero):** Centralización de la instanciación de objetos para desacoplar la creación de máquinas y cazadores de la lógica de negocio.
* **Inmutabilidad:** Uso de `records` y copias no destructivas (`with`) para garantizar la persistencia de datos históricos durante las actualizaciones.

---

## 📋 Módulos del Sistema (CRUD)
1.  **[Añadir]** Registro de hallazgos tras un escaneo exitoso del Foco.
2.  **[Listar]** Visualización completa de la base de datos de máquinas.
3.  **[Analizar]** Herramientas funcionales para detectar amenazas de nivel alto.
4.  **[Actualizar]** Sincronización de estados y niveles de peligrosidad de las máquinas.
5.  **[Eliminar]** Baja de registros en la base de datos local.
6.  **[Ranking]** Clasificación dinámica de la fauna robótica mediante nivel de peligro.

---
*"El foco no solo ve lo que hay, ve lo que los demás ignoran."*