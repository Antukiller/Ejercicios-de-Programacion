# 🐺 PROYECTO: "THE WITCHER'S CONTRACTS" (CONTRACT MANAGER V2)

![Status: Active](https://img.shields.io/badge/Status-Active-green)
![Pattern: Inheritance_%26_Interfaces-orange)

## 📝 1. El Escenario
En el continente, los contratos de brujo son la única forma de mantener a raya a las criaturas de la conjunción. Como regidor de los tablones de anuncios en **Novigrado**, debes programar un sistema robusto que gestione estos avisos. A diferencia de otros sistemas, este debe ser escalable mediante una jerarquía de clases sólida.

---

## 🏛️ 2. Arquitectura de Datos (Herencia + Interfaces)
Para este ejercicio, el sistema debe estructurarse siguiendo el principio de reutilización de código.

### La Interfaz (`IContrato`)
Define el comportamiento obligatorio:
* `void MostrarDetalles()`: Firma del método que imprimirá la información en consola.

### La Clase Base (`ContratoBase`) - **HERENCIA**
Debe ser una **clase abstracta** que implemente `IContrato` y contenga los atributos comunes:
* **Atributos:** `Id` (único), `Titulo`, `NivelRecomendado`, `RecompensaCoronas`.
* **Constructor:** Debe inicializar todos estos campos obligatoriamente.
* **Validación:** El `Titulo` no puede ser vacío y la `Recompensa` debe ser mayor a 0.

### Las Clases Especializadas (Hijas)
1.  **`ContratoMonstruo`**: Hereda de `ContratoBase`. Añade el atributo `TipoCriatura` (Especie del monstruo).
2.  **`ContratoEscolta`**: Hereda de `ContratoBase`. Añade los atributos `DistanciaKM` y `Peligrosidad` (1-100).

---

## ⚡ 3. El Oráculo Funcional (Extensiones)
Implementa métodos de extensión para `List<ContratoBase>` que permitan:
* `Filtrar()`: Localizar contratos por cualquier criterio (ej. contratos de nivel < 10).
* `SumarRecompensas()`: Calcular el oro total necesario para pagar todos los contratos actuales.
* `BuscarMasRentable()`: Devolver el contrato que ofrece más Coronas por cada punto de Nivel Recomendado.

---

## 💾 4. La Alforja Mágica (Caché Sandevistan)
Implementa el sistema de caché para que los brujos no esperen:
* **Mecánica:** Clase Singleton `WitcherCache` con un diccionario interno.
* **Protocolo:** Si se busca "Contratos de Espectros", el sistema debe mirar primero en la caché.
* **Invalidación:** Cualquier alta de contrato nuevo debe "vaciar" la alforja (limpiar caché).

---

## 📊 5. Consultas del Tablón
Muestra por consola los resultados de:
1.  **Listado de Contratos de Monstruo** que sean del tipo "Dracónido".
2.  **Búsqueda** del contrato con mayor recompensa (usando la función de extensión).
3.  **Conteo** de cuántos contratos de escolta superan los 50km de distancia.

---

## ⚠️ Reglas del Maestro Armero (Restricciones)
* **Colección:** Utiliza una colección que asegure que no existan contratos con el mismo `Id` (evita duplicados).
* **Formato de Moneda:** Las coronas deben mostrarse como `1,250.00 orens`.
* **Feedback de Caché:** Al recuperar datos, imprime en color amarillo:
    `[MEDITACIÓN] >> Extrayendo datos de la memoria sensorial...`