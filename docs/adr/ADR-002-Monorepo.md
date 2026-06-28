# Arauco Project Hub

## Architecture Decision Record

# ADR-002 - Monorepo

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Contexto

Arauco Project Hub es un único producto que debe conservar el contexto completo de una Iniciativa desde la Idea hasta la Operación.

El Engineering Playbook, el Backend, el Frontend y los futuros elementos de infraestructura evolucionarán como partes relacionadas de este producto. Sus cambios deberán mantener coherencia con la Filosofía del Producto, el Lenguaje Ubicuo, el Modelo de Dominio, el Modelo Operacional y la arquitectura basada en el Negocio.

Sin una decisión explícita sobre la organización de los repositorios, el producto podría fragmentarse según tecnologías o equipos antes de que exista una necesidad real. Esto aumentaría el riesgo de:

* Separar cambios que forman parte de una misma capacidad.
* Perder trazabilidad entre documentación e implementación.
* Duplicar configuración, validaciones y dependencias.
* Introducir diferencias innecesarias en el Lenguaje Ubicuo.
* Coordinar versiones entre repositorios sin una necesidad operacional validada.
* Convertir límites técnicos en límites del dominio.

Esta decisión define cómo se organizará el código fuente de Arauco Project Hub. No define la arquitectura interna del Backend o Frontend, las tecnologías utilizadas, la estrategia de despliegue ni la estructura física de carpetas.

---

# 2. Fuerzas de Decisión

La decisión debe:

* Mantener a Arauco Project Hub como un único producto.
* Favorecer la trazabilidad entre documentación, decisiones e implementación.
* Mantener visible el Lenguaje Ubicuo en todos los componentes.
* Permitir cambios coherentes que involucren más de un componente.
* Evitar duplicar configuración y automatización sin justificación.
* Mantener separadas las responsabilidades de cada componente.
* Permitir validaciones específicas por componente.
* No imponer que todos los componentes se desplieguen juntos.
* Favorecer la alternativa más simple para la etapa actual.
* Permitir revisar la decisión si aparecen límites operacionales reales.

---

# 3. Opciones Consideradas

## 3.1 Repositorios separados por componente

Mantener repositorios independientes para el Engineering Playbook, Backend, Frontend e infraestructura.

### Ventajas

* Cada componente puede administrar de manera independiente su historial, permisos y automatización.
* Reduce el alcance visible para equipos que trabajan exclusivamente en un componente.
* Puede facilitar ciclos de vida completamente independientes cuando estos ya existen.

### Desventajas

* Fragmenta la trazabilidad de cambios que representan una misma capacidad.
* Requiere coordinación adicional para mantener coherencia entre componentes.
* Favorece la duplicación de configuración y convenciones.
* Puede convertir una separación tecnológica en una separación conceptual.
* Introduce complejidad operacional antes de que exista una necesidad validada.

## 3.2 Organización híbrida

Mantener algunos componentes en un repositorio común y separar otros en repositorios independientes.

### Ventajas

* Permite aislar componentes con necesidades operacionales particulares.
* Puede equilibrar cambios coordinados e independencia técnica.

### Desventajas

* Requiere definir y mantener criterios de separación adicionales.
* Conserva parte de la coordinación entre repositorios.
* Puede producir límites inconsistentes si las excepciones no responden a necesidades reales.
* Agrega una flexibilidad que todavía no ha sido justificada.

## 3.3 Monorepo

Mantener el Engineering Playbook y los componentes de Arauco Project Hub en un único repositorio Git.

### Ventajas

* Mantiene juntas la documentación y la implementación del producto.
* Facilita cambios trazables que afectan más de un componente.
* Favorece convenciones y validaciones comunes.
* Reduce la coordinación y duplicación inicial.
* Refuerza la visión de Arauco Project Hub como un único producto.
* Permite revisar de forma conjunta la coherencia con el dominio aprobado.

### Desventajas

* Requiere mantener límites internos claros entre componentes.
* El repositorio puede crecer y exigir validaciones selectivas.
* Una configuración deficiente podría acoplar componentes que deben evolucionar de forma independiente.
* Los permisos específicos por componente son menos simples de aislar.

---

# 4. Decisión

Arauco Project Hub se mantendrá en un monorepo.

El mismo repositorio contendrá:

* El Engineering Playbook.
* El Backend cuando sea implementado.
* El Frontend cuando sea implementado.
* La automatización e infraestructura que formen parte del producto.

Esta decisión se aplicará bajo las siguientes condiciones:

1. El repositorio representa un único producto y no una agrupación genérica de soluciones.
2. La organización interna deberá derivarse del dominio y de las responsabilidades aprobadas, no solo de las tecnologías.
3. Cada componente mantendrá límites, dependencias y validaciones explícitas.
4. Un cambio que afecte documentación e implementación podrá revisarse de forma trazable dentro del mismo cambio.
5. Los componentes podrán tener ciclos de construcción, validación y despliegue independientes.
6. La presencia en un mismo repositorio no autoriza dependencias directas entre componentes sin una necesidad documentada.
7. El código compartido solo se incorporará cuando represente una necesidad real y no una generalización anticipada.
8. Las herramientas del monorepo se seleccionarán posteriormente y deberán justificar la complejidad que agreguen.

El monorepo no implica un despliegue único, una única tecnología ni una arquitectura interna organizada por capas técnicas.

---

# 5. Consecuencias

## 5.1 Consecuencias Positivas

* La documentación y la implementación permanecen próximas.
* Los cambios transversales pueden conservar una única trazabilidad.
* Se reduce la duplicación inicial de configuración.
* El Lenguaje Ubicuo puede verificarse de manera coherente.
* Las decisiones del Engineering Playbook permanecen visibles para todos los componentes.
* La estructura inicial favorece la simplicidad mientras el producto madura.

## 5.2 Costos y Restricciones

* Se deberán definir límites internos claros antes de implementar componentes.
* Las validaciones deberán poder ejecutarse por alcance cuando el repositorio crezca.
* Los componentes no deberán acoplarse solo por compartir repositorio.
* Los permisos particulares por componente podrían requerir controles adicionales.
* La selección de herramientas específicas requerirá una evaluación posterior.

## 5.3 Riesgos

### Acoplamiento accidental

Compartir repositorio puede facilitar dependencias no intencionales.

Mitigación:

* Definir responsabilidades y dependencias permitidas.
* Revisar cambios según los criterios de ADR-001.
* Evitar código compartido sin una necesidad validada.

### Validaciones lentas

El crecimiento del repositorio puede aumentar el tiempo de validación.

Mitigación:

* Ejecutar validaciones selectivas por componente cuando sea necesario.
* Mantener una validación integral proporcional al riesgo del cambio.

### Estructura orientada por tecnología

El monorepo podría organizarse exclusivamente alrededor de frameworks o herramientas.

Mitigación:

* Derivar la estructura interna de la arquitectura basada en el Negocio.
* Mantener el Lenguaje Ubicuo y la Iniciativa visibles en la implementación.

---

# 6. Criterios de Cumplimiento

La implementación de esta decisión cumple cuando:

* El Engineering Playbook y los componentes del producto permanecen en un único repositorio.
* Un cambio puede rastrearse desde la documentación aprobada hasta los componentes afectados.
* Cada componente mantiene responsabilidades y validaciones explícitas.
* Los componentes no dependen entre sí por conveniencia del repositorio.
* Los ciclos de despliegue pueden mantenerse independientes.
* La estructura utiliza el Lenguaje Ubicuo cuando representa conceptos del dominio.
* La incorporación de herramientas adicionales está justificada.
* No se duplican configuraciones o capacidades sin una necesidad validada.

---

# 7. Cuándo Revisar esta Decisión

Esta decisión deberá revisarse si:

* Un componente requiere permisos de repositorio incompatibles con el resto del producto.
* Los ciclos de vida de los componentes generan una coordinación desproporcionada.
* El tamaño del repositorio impide validaciones o entregas eficientes aun utilizando ejecución selectiva.
* Un componente adquiere un ciclo de vida organizacional independiente y validado.
* Existen requisitos regulatorios o de seguridad que exigen separación.

La preferencia de una herramienta o equipo no constituye por sí sola una razón suficiente para fragmentar el producto.

---

# 8. Trazabilidad

Este ADR deriva principalmente de:

* PHIL-001: FP-002, FP-004, FP-005, FP-009, FP-010, FP-011 y FP-012.
* SRS-001: propósito y alcance del producto.
* SRS-002: Lenguaje Ubicuo.
* SRS-003: Iniciativa como Aggregate Root principal.
* SRS-004: continuidad del ciclo de vida.
* ADR-001: arquitectura derivada del dominio y separación entre reglas del dominio y detalles tecnológicos.

---

# 9. Decisiones Posteriores

Este ADR deberá orientar, sin anticiparlas, las decisiones sobre:

* Estructura interna del repositorio.
* Arquitectura de Backend.
* Arquitectura de Frontend.
* Automatización de validaciones.
* Estrategia de construcción y despliegue.
* Herramientas de soporte para el monorepo.

La selección de una herramienta específica o la definición de una estructura interna importante deberá documentarse mediante un ADR cuando corresponda.

---

# 10. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para la organización del código fuente de Arauco Project Hub.
