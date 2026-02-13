# 🐺 PROYECTO: "THE WITCHER'S CONTRACTS" (PURE INTERFACE EDITION)

![Architecture: Clean Interfaces](https://img.shields.io/badge/Architecture-Pure--Methods-green)

## 📝 1. El Escenario
El Tablón de Anuncios de Novigrado requiere un sistema de gestión de contratos de élite. Para cumplir con los estándares de la Logia de Hechiceras (y los criterios de evaluación académica), el sistema debe separar los **datos** de los **comportamientos** usando una jerarquía de herencia y contratos de interfaz puros.

---

## 🏛️ 2. Arquitectura de Datos (Jerarquía Profesional)

### A. Interfaces de Comportamiento (Contratos Puros)
Siguiendo la teoría clásica, estas interfaces **no contienen atributos**, solo firmas de métodos:

1.  **`IContrato`** (General):
    * `void MostrarDetalles()`: Imprime la información completa en consola.

2.  **`IBestiario`** (Especializada para Monstruos):
    * `string PrepararAceite()`: Retorna el nombre del aceite necesario según la especie.
    * `string SeleccionarSenial()`: Retorna la señal de brujo más efectiva.
    * `void MostrarDebilidades()`: Imprime una lista de puntos vulnerables.

3.  **`IEstrategia`** (Específica para Asaltos):
    * `string SeleccionarExplosivo()`: Retorna la bomba ideal según el entorno.
    * `int CalcularProbabilidadExito()`: Calcula el porcentaje de victoria basándose en lógica interna.
    * `void PlanificarRutaSigilo()`: Imprime los pasos tácticos para la misión.

### B. Clase Base Abstracta (`ContratoBase`)
Aquí es donde viven los **atributos**. Implementa `IContrato`:
* **Datos:** `Id`, `Titulo`, `NivelRecomendado`, `RecompensaCoronas`.
* **Constructor:** Obligatorio para inicializar el estado del objeto.
* **Método de Apoyo:** `bool EsAptoParaBrujo(int nivelBrujo)`.

### C. Clases Hijas (Implementación)
1.  **`ContratoMonstruo`**: Hereda de `ContratoBase` e implementa `IBestiario`. (Tiene el atributo `EspecieCriatura`).
2.  **`ContratoAsalto`**: Hereda de `ContratoBase` e implementa `IEstrategia`. (Tiene los atributos `NumeroEnemigos` y `EsNocturno`).

---

## ⚡ 3. El Oráculo Funcional (Extensiones)
Métodos para `List<ContratoBase>` usando Lambdas:
* `Filtrar()`: Para buscar por cualquier condición.
* `ObtenerMisionMasPeligrosa()`: Encuentra el contrato con mayor nivel o mayor cantidad de enemigos.

---

## 💾 4. La Alforja Mágica (Caché)
* **Singleton `WitcherCache`**: Almacena resultados de consultas en un `Dictionary<string, object>`.
* **Feedback**: Al usar memoria local, imprime en amarillo: `[MEDITACIÓN] >> Datos recuperados...`

---

## 📊 5. Consultas del Tablón
1.  Listar **Contratos de Monstruo** que recomienden la señal "Igni".
2.  Mostrar el **Aceite Recomendado** y las **Debilidades** de todos los monstruos actuales.
3.  Ejecutar la **Planificación de Sigilo** para todos los asaltos de la lista.

---

## ⚠️ Reglas del Fixer
* **Colecciones:** Usa `Dictionary<string, ContratoBase>` para asegurar IDs únicos.
* **Formato:** Recompensas como `$€ 1,250.00` (u orens).
* **Git:** Mantén limpio el repositorio con un archivo `.gitignore`.