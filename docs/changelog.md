# Changelog

Este documento registra los hitos formales alcanzados por el Engineering Playbook de Arauco Project Hub.

---

## 2026-06-28

### DER - Diagrama de Entidad-Relación

**Documento aprobado:** DER - Diagrama de Entidad-Relación

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se representaron visualmente las estructuras y relaciones aprobadas en SRS-010.
* Se documentaron claves primarias, claves foráneas y atributos mínimos.
* Se definieron las cardinalidades entre las estructuras del Modelo Relacional.
* Se mantuvo a la Iniciativa como Aggregate Root principal.
* Se conservaron las relaciones necesarias para la trazabilidad de Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial.
* Se documentaron las condiciones de integridad y su trazabilidad hacia los documentos aprobados.
* Se mantuvieron fuera del alcance los tipos físicos, índices y decisiones tecnológicas.
* Se definió el Diccionario de Datos como el siguiente documento del Engineering Playbook.

---

### SRS-010 - Modelo Relacional

**Documento aprobado:** SRS-010 - Modelo Relacional

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se representó el Modelo de Dominio aprobado mediante estructuras relacionales.
* Se mantuvo a la Iniciativa como Aggregate Root principal del modelo.
* Se definieron las relaciones entre Negocio, Iniciativa, Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Ambientes, Despliegues e Historial.
* Se establecieron reglas de integridad para proteger las relaciones y la trazabilidad aprobadas.
* Se mantuvieron los Objetos de Valor gobernados por el dominio fuera de la configuración libre.
* Se documentó la correspondencia entre las estructuras relacionales y sus fuentes aprobadas.
* Se postergaron la selección tecnológica y la estrategia de persistencia para una decisión arquitectónica específica.
* Se definió el DER como el siguiente documento del Engineering Playbook.

---

### ADR-001 - Arquitectura Basada en el Negocio

**Documento aprobado:** ADR-001 - Arquitectura Basada en el Negocio

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se formalizó que la arquitectura de Arauco Project Hub se deriva del dominio aprobado.
* Se evaluaron las alternativas de organización por tecnología, por pantallas o formularios y por dominio.
* Se establecieron criterios para proteger a la Iniciativa como centro del producto.
* Se definió la separación entre las reglas del dominio y los detalles tecnológicos.
* Se documentaron las implicancias para el Modelo Relacional, Backend, API, Frontend e integraciones.
* Se incorporaron criterios de cumplimiento y trazabilidad hacia PHIL-001 y los SRS aprobados.
* Se inició formalmente la Fase 2 - Architecture.

---

### PHIL-001 - Filosofía del Producto

**Documento aprobado:** PHIL-001 - Filosofía del Producto

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió la identidad y la convicción central de Arauco Project Hub.
* Se establecieron los principios permanentes del producto.
* Se definieron los límites que protegen el propósito de la plataforma.
* Se formalizó el orden de prioridad entre Filosofía del Producto, SRS, ADR, Decisions, Standards y código.
* Se incorporaron criterios para evaluar futuras decisiones.
* Se documentaron las tensiones entre simplicidad y flexibilidad, estandarización y autonomía, trazabilidad y esfuerzo, transparencia y protección, y evolución y estabilidad.
* Se estableció que la tecnología debe adaptarse al dominio y no definirlo.

---

### SRS-004 - Modelo Operacional

**Documento aprobado:** SRS-004 - Modelo Operacional

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió la diferencia entre las Etapas de Iniciativa y los Estados de Solicitud.
* Se documentaron el flujo AS-IS y el flujo TO-BE de una Iniciativa.
* Se describió el ciclo de vida desde Idea hasta Operación y evolución.
* Se estableció la participación operacional de los actores definidos en el Lenguaje Ubicuo.
* Se modelaron los flujos paralelos de Evaluación, Presupuesto, Recursos tecnológicos, DevOps, DBA, Desarrollo, QAS, Producción y Operación.
* Se aprobaron las reglas operacionales y las decisiones que mantienen la trazabilidad durante el ciclo de vida de una Iniciativa.
* Se completó formalmente la Fase 1 - Domain Design.
