# Arauco Project Hub

## Architecture Decision Record

# ADR-001 - Arquitectura Basada en el Negocio

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Contexto

Arauco Project Hub debe acompañar el ciclo de vida completo de las Iniciativas tecnológicas, desde la Idea hasta la Operación.

La Filosofía del Producto establece que el Negocio define el producto, la Iniciativa es el centro y la tecnología sirve al dominio. Los SRS aprobados definen el Lenguaje Ubicuo, el Modelo de Dominio y el Modelo Operacional que la arquitectura debe proteger.

Sin una regla arquitectónica explícita, las futuras decisiones de tecnologías, datos, API, Backend y Frontend podrían organizar el producto alrededor de herramientas o estructuras técnicas. Esto aumentaría el riesgo de:

* Fragmentar el contexto de una Iniciativa.
* Duplicar información.
* Introducir términos ajenos al Lenguaje Ubicuo.
* Acoplar el dominio a una tecnología.
* Perder trazabilidad entre una necesidad del Negocio y su implementación.
* Crear diferencias innecesarias entre Negocios.

Esta decisión define la relación entre el dominio aprobado y las futuras decisiones arquitectónicas. No selecciona tecnologías ni define todavía el Modelo Relacional, la API o la estructura del código.

---

# 2. Fuerzas de decisión

La decisión debe:

* Mantener a la Iniciativa como centro del producto.
* Expresar el Lenguaje Ubicuo sin traducciones innecesarias.
* Conservar la continuidad entre Idea, Desarrollo, Producción y Operación.
* Mantener la trazabilidad de acciones y decisiones relevantes.
* Permitir la adopción por múltiples Negocios sin fragmentar el producto.
* Evitar que una herramienta determine el Modelo de Dominio.
* Favorecer la alternativa más simple que satisfaga las necesidades aprobadas.
* Permitir que las tecnologías evolucionen sin redefinir el dominio.

---

# 3. Opciones consideradas

## 3.1 Arquitectura organizada por tecnología

Organizar el producto principalmente según bases de datos, frameworks, servicios de infraestructura o capas técnicas.

### Ventajas

* Puede facilitar el trabajo inicial cuando el equipo conoce bien una tecnología.
* Sigue estructuras comunes ofrecidas por herramientas y frameworks.

### Desventajas

* Hace que la tecnología condicione la representación del dominio.
* Dispersa una misma capacidad entre estructuras técnicas.
* Debilita la trazabilidad desde la necesidad del Negocio.
* Aumenta el costo de sustituir una tecnología.

## 3.2 Arquitectura organizada por pantallas o formularios

Organizar el producto según sus interfaces de usuario y los datos capturados en cada una.

### Ventajas

* Permite visualizar rápidamente interacciones concretas.
* Puede simplificar prototipos iniciales.

### Desventajas

* Reduce el dominio a operaciones de captura y consulta.
* Favorece formularios desconectados.
* Puede duplicar reglas e información entre interfaces.
* No protege el ciclo de vida completo de la Iniciativa.

## 3.3 Arquitectura derivada del dominio

Organizar las capacidades del producto a partir de la Filosofía del Producto, el Lenguaje Ubicuo, el Modelo de Dominio y el Modelo Operacional aprobados.

### Ventajas

* Mantiene el Negocio visible en la arquitectura.
* Protege a la Iniciativa como Aggregate Root.
* Favorece la trazabilidad entre documentación e implementación.
* Mantiene las tecnologías subordinadas al dominio.
* Facilita una evolución intencional sin fragmentar el producto.

### Desventajas

* Requiere disciplina para evitar atajos orientados por herramientas.
* Exige revisar la documentación aprobada antes de implementar.
* Puede requerir adaptación cuando un framework no expresa el dominio con claridad.

---

# 4. Decisión

La arquitectura de Arauco Project Hub se derivará del dominio aprobado.

Toda decisión arquitectónica o tecnológica deberá:

1. Partir de una necesidad trazable del Negocio o de un requerimiento aprobado.
2. Utilizar el Lenguaje Ubicuo definido en SRS-002.
3. Respetar las relaciones, responsabilidades y reglas establecidas en el Modelo de Dominio.
4. Respetar el movimiento y las reglas establecidas en el Modelo Operacional.
5. Mantener a la Iniciativa como centro de su ciclo de vida y proteger su responsabilidad como Aggregate Root.
6. Conservar dentro del contexto de la Iniciativa sus Participantes, decisiones, Recursos, Documentos, Conversaciones, Componentes, Solicitudes, Versiones, Despliegues e Historial.
7. Evitar duplicar información que ya tenga una fuente oficial.
8. Mantener separadas las reglas del dominio de los detalles particulares de frameworks, bases de datos, interfaces y servicios externos.
9. Justificar toda complejidad adicional mediante una necesidad validada.
10. Ser aplicable al núcleo común de múltiples Negocios, salvo que exista una diferencia real y documentada.

Las tecnologías se seleccionarán posteriormente según su capacidad para expresar y proteger estas condiciones. Ninguna selección tecnológica podrá redefinir conceptos, relaciones o reglas aprobadas.

Cuando una necesidad arquitectónica no pueda resolverse sin contradecir la Filosofía del Producto o un SRS aprobado, se detendrá la implementación y se propondrá una nueva revisión del documento correspondiente.

---

# 5. Implicancias

## 5.1 Modelo Relacional

El futuro Modelo Relacional deberá representar el Modelo de Dominio sin convertirse en su fuente de definición.

Las decisiones de persistencia deberán conservar las relaciones y reglas aprobadas, además de permitir la trazabilidad requerida.

## 5.2 Backend

El Backend deberá expresar capacidades y reglas mediante el Lenguaje Ubicuo.

Las reglas del dominio no deberán depender directamente de frameworks, mecanismos de persistencia o servicios externos.

## 5.3 API

La API deberá representar capacidades del dominio y utilizar el Lenguaje Ubicuo.

No deberá exponer estructuras determinadas únicamente por la persistencia o por conveniencias de una herramienta.

## 5.4 Frontend

El Frontend deberá presentar el ciclo de vida y el contexto de la Iniciativa de manera coherente con el Modelo Operacional.

Las interfaces no deberán introducir estados, relaciones o conceptos que no estén respaldados por la documentación aprobada.

## 5.5 Integraciones

Las integraciones deberán adaptarse al dominio de Arauco Project Hub.

Los términos o estructuras de herramientas externas no deberán reemplazar el Lenguaje Ubicuo ni convertirse en la fuente oficial de las reglas del producto.

---

# 6. Consecuencias

## 6.1 Consecuencias positivas

* La arquitectura mantiene coherencia con el propósito del producto.
* Las decisiones técnicas pueden rastrearse hasta el dominio y los requerimientos.
* El cambio de una tecnología tiene menor impacto conceptual.
* Las reglas del Negocio permanecen visibles y protegidas.
* Los distintos Negocios comparten un núcleo común.
* Se reduce el riesgo de duplicar información o fragmentar el contexto.

## 6.2 Costos y restricciones

* Cada decisión técnica deberá demostrar coherencia con los documentos aprobados.
* Las estructuras predeterminadas de una herramienta podrán requerir adaptación.
* Los atajos que mezclen reglas del dominio con detalles tecnológicos deberán rechazarse.
* Los cambios del dominio deberán resolverse primero en la documentación de mayor prioridad.

---

# 7. Criterios de cumplimiento

Una decisión derivada de este ADR cumple cuando:

* Identifica la necesidad o documento aprobado que la origina.
* Utiliza exclusivamente el Lenguaje Ubicuo.
* Explica cómo protege a la Iniciativa y su ciclo de vida.
* No crea una segunda fuente de verdad.
* Separa las reglas del dominio de los detalles tecnológicos.
* Justifica la complejidad incorporada.
* Conserva trazabilidad hacia los documentos que la respaldan.
* No fragmenta el núcleo común entre Negocios.

Si alguno de estos criterios no puede cumplirse, la decisión deberá revisarse antes de su implementación.

---

# 8. Trazabilidad

Este ADR deriva principalmente de:

* PHIL-001: FP-001, FP-002, FP-003, FP-004, FP-005, FP-006, FP-009, FP-010, FP-011 y FP-012.
* SRS-001: propósito, alcance y principios de diseño.
* SRS-002: Lenguaje Ubicuo y relaciones fundamentales.
* SRS-003: Modelo de Dominio y reglas del dominio.
* SRS-004: Modelo Operacional y reglas operacionales.

---

# 9. Decisiones posteriores

Este ADR deberá orientar, sin anticiparlas, las decisiones sobre:

* Modelo Relacional.
* Arquitectura de Backend y Frontend.
* Diseño de API.
* Persistencia.
* Integraciones.
* Standards de implementación.

Cada decisión arquitectónica importante deberá documentarse mediante su propio ADR cuando corresponda.

---

# 10. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para orientar la relación entre el dominio y las decisiones arquitectónicas de Arauco Project Hub.
