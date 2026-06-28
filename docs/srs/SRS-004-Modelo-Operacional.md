# Arauco Project Hub

## Software Requirements Specification

# SRS-004 - Modelo Operacional

**Versión:** 1.0  
**Estado:** Approved  
**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento describe cómo se mueve una Iniciativa dentro de Arauco, desde su origen hasta la operación y evolución de la Solución.

Su propósito es establecer una visión operacional compartida entre el Negocio, el equipo responsable de la ejecución y las áreas transversales, manteniendo a la Iniciativa como centro del ciclo de vida.

Este documento modela el funcionamiento del negocio. No define base de datos, API, pantallas, infraestructura ni decisiones de implementación técnica.

---

# 2. Alcance

El Modelo Operacional comprende:

* El flujo actual de una Iniciativa.
* El flujo objetivo con Arauco Project Hub.
* Las etapas de la Iniciativa desde Idea hasta Operación.
* La evolución de una Iniciativa mediante Solicitudes.
* La participación de los actores definidos en el Lenguaje Ubicuo.
* La coordinación de los flujos de Evaluación, Presupuesto, Recursos tecnológicos, DevOps, DBA, Desarrollo, QAS, Producción y Operación.
* Las reglas que permiten avanzar, devolver, cancelar o cerrar una Iniciativa.
* La trazabilidad de decisiones, aprobaciones, rechazos y cambios relevantes.

Quedan fuera del alcance:

* El diseño de pantallas.
* La definición de endpoints.
* El modelo de datos relacional.
* La selección de tecnologías.
* La automatización técnica de los flujos.
* Los permisos específicos por actor.
* Los tiempos de atención y SLA.

---

# 3. Etapas de Iniciativa y Estados de Solicitud

Las etapas de una Iniciativa y los Estados de Solicitud representan ciclos diferentes.

En este documento, las **Etapas de Iniciativa** son la lectura operacional del **Estado de Iniciativa** definido en SRS-003. No constituyen un concepto adicional del dominio.

| Aspecto | Etapas de Iniciativa | Estados de Solicitud |
| --- | --- | --- |
| Qué representan | La madurez de una Iniciativa durante su ciclo de vida completo. | El avance de una necesidad operacional asociada a una Iniciativa. |
| Cuándo comienzan | Desde el registro de la Idea. | Cuando existe una Iniciativa en uso o evolución y se registra una Solicitud. |
| Alcance | Evaluación, aprobación, preparación, construcción, validación, puesta en producción y operación. | Atención de un Error, Mejora o Nuevo Desarrollo. |
| Relación con la Iniciativa | Existe un único Estado de Iniciativa vigente. | Una Iniciativa puede tener muchas Solicitudes, cada una con su propio estado. |
| Continuidad | La Iniciativa permanece en Operación mientras la Solución se utiliza y evoluciona. | La Solicitud finaliza de manera independiente al quedar Cerrada o Cancelada. |

Los Estados de Solicitud no reemplazan ni modifican la etapa de la Iniciativa. Una Iniciativa en Operación puede contener simultáneamente Solicitudes en distintos estados.

---

# 4. Flujo AS-IS actual

El flujo AS-IS se construye a partir del problema actual descrito en SRS-001. Su detalle deberá ser validado con los actores involucrados antes de aprobar este documento.

Actualmente una necesidad puede originarse en reuniones, correos electrónicos, conversaciones por Teams, mensajes de WhatsApp o solicitudes verbales.

El flujo general observado es:

```text
Necesidad del Negocio
        ↓
Comunicación por distintos canales
        ↓
Evaluación y coordinación mediante reuniones y correos electrónicos
        ↓
Gestión separada de Presupuesto y Recursos tecnológicos
        ↓
Coordinación manual con DevOps y DBA
        ↓
Desarrollo
        ↓
Validación en QAS
        ↓
Producción
        ↓
Operación y atención de nuevas necesidades por canales dispersos
```

## 4.1 Características del flujo actual

* La información de una misma Iniciativa se distribuye entre distintos canales y herramientas.
* El estado real depende de consultas a las personas involucradas.
* Las aprobaciones, rechazos y decisiones pueden quedar registradas únicamente en correos electrónicos o conversaciones informales.
* La coordinación con Gestión Financiera TI, DevOps y DBA depende principalmente del intercambio manual de información.
* Los documentos y evidencias pueden quedar separados del contexto de la Iniciativa.
* Después de Producción, los Errores, Mejoras y Nuevos Desarrollos pueden perder continuidad respecto de la necesidad original.
* La incorporación de nuevos Participantes requiere reconstruir el contexto desde distintas fuentes.

## 4.2 Consecuencias operacionales

* Pérdida de trazabilidad.
* Dificultad para conocer responsables y estado.
* Retrasos por dependencias no visibles.
* Retrabajo por información incompleta o desactualizada.
* Baja visibilidad para el Negocio y los equipos involucrados.
* Separación entre la ejecución inicial y la Operación de la Solución.

---

# 5. Flujo TO-BE objetivo

Con Arauco Project Hub, toda necesidad que pueda generar una Solución o evolucionar una existente deberá mantenerse dentro del contexto de una Iniciativa.

La plataforma será la fuente de verdad para el estado, los Participantes, los Recursos, los Documentos, las Conversaciones, las Solicitudes, las Versiones, los Despliegues y el Historial de la Iniciativa.

```text
Idea
  ↓
Evaluación
  ↓
Aprobada
  ↓
Preparación
  ↓
Desarrollo
  ↓
QAS
  ↓
Producción
  ↓
Operación
  ├── Solicitud de tipo Error
  ├── Solicitud de tipo Mejora
  └── Solicitud de tipo Nuevo Desarrollo
```

En el flujo objetivo:

* La Iniciativa concentra su información desde el origen.
* Cada Participante conoce el estado vigente y el contexto disponible.
* Los flujos paralelos se relacionan con la misma Iniciativa.
* Las aprobaciones y rechazos se registran mediante Conversaciones y forman parte del Historial.
* Los Documentos y evidencias permanecen asociados a la Iniciativa.
* Las dependencias entre Presupuesto, Recursos tecnológicos, DevOps, DBA, Desarrollo y QAS son visibles.
* La llegada a Producción no termina la Iniciativa.
* La Operación y evolución se administran mediante Solicitudes asociadas a la Iniciativa.

---

# 6. Ciclo de vida de una Iniciativa

## 6.1 Idea

La Iniciativa nace a partir de una necesidad del Negocio o del área de TI.

En esta etapa se registra el objetivo, la justificación, el beneficio esperado, el Negocio y al menos un Responsable Funcional.

La Iniciativa avanza a Evaluación cuando existe información suficiente para que los actores responsables comprendan la necesidad.

---

## 6.2 Evaluación

La necesidad es analizada para comprender su alcance funcional, valor esperado, factibilidad, Recursos requeridos y participación necesaria.

El Business Expert orienta la evaluación estratégica. El Responsable Funcional valida la necesidad. El Jefe de Proyecto coordina la evaluación y el Technical Lead aporta la evaluación técnica.

Durante esta etapa pueden comenzar en paralelo la valorización de Recursos y las coordinaciones iniciales con Gestión Financiera TI, DevOps y DBA.

La Iniciativa puede resultar Aprobada, Cancelada o permanecer en Evaluación hasta resolver sus Pendientes.

---

## 6.3 Aprobada

La Iniciativa ha recibido las aprobaciones necesarias para continuar.

La aprobación confirma que la organización decide avanzar con la Iniciativa. No implica que todos los Recursos se encuentren disponibles.

Toda aprobación debe quedar registrada y ser trazable.

---

## 6.4 Preparación

Se coordinan los Participantes, Recursos, Ambientes, Componentes y Documentos necesarios para iniciar Desarrollo.

Los flujos de Presupuesto, Recursos tecnológicos, DevOps y DBA pueden avanzar en paralelo, de acuerdo con las necesidades de la Iniciativa.

La Iniciativa avanza a Desarrollo cuando dispone de las condiciones necesarias para comenzar su ejecución.

---

## 6.5 Desarrollo

Los Developers implementan la Solución bajo la responsabilidad técnica del Technical Lead y la coordinación del Jefe de Proyecto.

El Responsable Funcional mantiene disponible la validación de las necesidades funcionales. Las decisiones, cambios relevantes y dependencias deben registrarse en la Iniciativa.

La preparación de QAS, la coordinación con DevOps y las actividades de DBA pueden continuar en paralelo.

La Iniciativa avanza a QAS cuando existe una Versión disponible para validación.

---

## 6.6 QAS

La Versión es validada en el Ambiente QAS.

El Responsable Funcional aprueba o rechaza la entrega. Los Usuarios Finales pueden participar en la validación cuando corresponda.

Toda aprobación o rechazo debe quedar registrado con su observación y evidencia.

Si la validación es rechazada, la Iniciativa vuelve a Desarrollo conservando el Historial. Si es aprobada, puede avanzar a Producción.

---

## 6.7 Producción

Se coordina y registra el Despliegue de la Versión en el Ambiente PRD.

DevOps y DBA participan según los Componentes y Recursos de la Iniciativa. El Technical Lead y los Developers atienden las actividades técnicas necesarias. El Responsable Funcional confirma el contexto funcional del paso a PRD.

El resultado, la evidencia y las observaciones del Despliegue deben quedar registrados.

La Iniciativa avanza a Operación cuando la Solución se encuentra disponible para su uso.

---

## 6.8 Operación

La Solución es utilizada por los Usuarios Finales y permanece asociada a la Iniciativa que le dio origen.

Los Errores, Mejoras y Nuevos Desarrollos se registran como Solicitudes. Cada Solicitud sigue su propio flujo sin reemplazar el Estado de Iniciativa.

Las nuevas Versiones y sus Despliegues mantienen la continuidad entre la necesidad operacional y la evolución de la Solución.

---

## 6.9 Evolución

La evolución ocurre dentro de Operación mediante Solicitudes de tipo Mejora o Nuevo Desarrollo.

Evolución no se incorpora en este documento como un Estado de Iniciativa adicional. Representa el comportamiento continuo de una Iniciativa en Operación.

Cuando una Solicitud requiere cambios, puede recorrer Desarrollo, QAS y Producción mediante sus Estados de Solicitud, manteniendo a la Iniciativa en Operación.

---

## 6.10 Cerrada y Cancelada

Una Iniciativa Cancelada no continúa su ejecución. La razón y la decisión deben quedar registradas.

Una Iniciativa Cerrada deja de requerir gestión activa. Los criterios organizacionales para cerrar una Iniciativa se mantienen como Pendiente de definición.

Cerrar o cancelar una Iniciativa no elimina su Historial, Conversaciones, Documentos ni decisiones.

---

# 7. Participación de actores

La participación concreta depende de la etapa y de las necesidades de cada Iniciativa.

| Actor | Participación operacional |
| --- | --- |
| Business Expert | Orienta el valor estratégico de la Iniciativa y participa en su Evaluación y aprobación. |
| Jefe de Proyecto | Coordina el avance integral, los Participantes, las dependencias y los flujos paralelos. |
| Technical Lead | Conduce la evaluación técnica, define las necesidades técnicas de la Solución y mantiene coherencia durante Desarrollo, QAS, Producción y Operación. |
| Developer | Implementa la Solución, participa en la corrección de rechazos de QAS y atiende cambios derivados de Solicitudes. |
| Responsable Funcional | Representa la necesidad del Negocio, valida el alcance funcional y aprueba o rechaza las entregas en QAS. |
| Usuario Final | Aporta necesidades desde la operación diaria, participa en validaciones cuando corresponde y puede registrar Solicitudes de tipo Error o Mejora. |
| Gestión Financiera TI | Revisa, valoriza y aprueba los Recursos presupuestarios requeridos. |
| DevOps | Habilita los Recursos tecnológicos bajo su responsabilidad y participa en los Despliegues. |
| DBA | Administra las bases de datos requeridas y participa en su habilitación y evolución. |

La asignación detallada de permisos y de responsables por cada transición queda fuera del alcance de este documento.

---

# 8. Flujos paralelos

Los flujos paralelos no son Iniciativas independientes. Son actividades coordinadas dentro de una misma Iniciativa.

No todos los flujos son obligatorios para todas las Iniciativas. Su aplicación depende de la necesidad, los Componentes y los Recursos requeridos.

| Flujo | Propósito | Participación principal | Relación con el ciclo de vida |
| --- | --- | --- | --- |
| Evaluación | Comprender la necesidad, el valor esperado, la factibilidad y el alcance. | Business Expert, Responsable Funcional, Jefe de Proyecto y Technical Lead. | Comienza en Evaluación y sustenta la decisión de aprobación. |
| Presupuesto | Valorizar y aprobar los Recursos presupuestarios. | Gestión Financiera TI, Jefe de Proyecto y Business Expert. | Puede comenzar en Evaluación y continuar durante Preparación. |
| Recursos tecnológicos | Identificar, valorizar, aprobar y habilitar los Recursos necesarios. | Technical Lead, Gestión Financiera TI, DevOps y DBA. | Puede comenzar en Evaluación y debe avanzar según las necesidades de Desarrollo, QAS y Producción. |
| DevOps | Habilitar los Recursos tecnológicos bajo su responsabilidad y apoyar los Despliegues. | DevOps y Technical Lead. | Se coordina principalmente durante Preparación, Desarrollo, QAS, Producción y Operación. |
| DBA | Habilitar y administrar las bases de datos requeridas. | DBA y Technical Lead. | Se coordina según los Ambientes y las necesidades de Desarrollo, QAS, Producción y Operación. |
| Desarrollo | Implementar la Solución o los cambios requeridos. | Technical Lead y Developer. | Ocurre en Desarrollo y puede repetirse por rechazo en QAS o por Solicitudes. |
| QAS | Validar funcionalmente una Versión y registrar aprobación o rechazo. | Responsable Funcional, Usuario Final, Technical Lead y Developer. | Ocurre antes del paso a Producción. |
| Producción | Publicar una Versión aprobada en el Ambiente PRD. | DevOps, DBA, Technical Lead y Developer. | Conecta la validación de QAS con Operación. |
| Operación | Utilizar, mantener y evolucionar la Solución. | Responsable Funcional, Usuario Final, Technical Lead, Developer, DevOps y DBA. | Comienza después de Producción y genera Solicitudes, Versiones y Despliegues. |

## 8.1 Coordinación entre flujos

* El avance de un flujo no implica automáticamente el avance de la Iniciativa.
* Un flujo pendiente puede impedir el cambio de etapa cuando su resultado sea necesario para continuar.
* Cada resultado relevante debe quedar asociado a la Iniciativa mediante Documentos, Conversaciones o eventos del Historial.
* Las dependencias y rechazos deben ser visibles para los Participantes.
* La coordinación de los flujos no debe duplicar la información principal de la Iniciativa.

---

# 9. Reglas operacionales

## RO-001

Toda actividad operacional debe mantenerse dentro del contexto de una Iniciativa.

---

## RO-002

Toda Iniciativa debe pertenecer a un Negocio y tener al menos un Responsable Funcional.

---

## RO-003

Cada Iniciativa debe tener un único Estado de Iniciativa vigente.

---

## RO-004

Un cambio de etapa debe conservar el Estado de Iniciativa anterior, el nuevo estado, la fecha y el responsable en el Historial.

---

## RO-005

Toda aprobación, rechazo, cancelación o devolución debe registrar su fundamento mediante una Conversación.

---

## RO-006

Una Iniciativa no puede avanzar a Desarrollo si carece de las condiciones necesarias para ejecutar el trabajo identificado durante Preparación.

La definición verificable de estas condiciones queda Pendiente.

---

## RO-007

Una Iniciativa no puede avanzar de QAS a Producción sin aprobación del Responsable Funcional.

---

## RO-008

Todo rechazo en QAS devuelve el trabajo a Desarrollo sin eliminar la evidencia ni el Historial previo.

---

## RO-009

Todo paso a PRD debe corresponder a una Versión y quedar registrado como Despliegue.

---

## RO-010

La llegada a Producción no cierra la Iniciativa; la Iniciativa avanza a Operación.

---

## RO-011

Toda Solicitud debe pertenecer a una Iniciativa en uso o evolución.

---

## RO-012

Una Solicitud mantiene su propio Estado de Solicitud y no modifica por sí sola el Estado de Iniciativa.

---

## RO-013

Los flujos de Presupuesto, Recursos tecnológicos, DevOps y DBA pueden ejecutarse en paralelo cuando la Iniciativa lo requiera.

---

## RO-014

Los Documentos, Conversaciones y eventos del Historial deben permanecer disponibles durante todo el ciclo de vida de la Iniciativa.

---

## RO-015

Cancelar o cerrar una Iniciativa no elimina su información ni su trazabilidad.

---

# 10. Decisiones tomadas

## D-001

Las etapas descritas en este documento corresponden operacionalmente al Estado de Iniciativa definido en SRS-003.

---

## D-002

Los Estados de Solicitud y el Estado de Iniciativa representan ciclos independientes.

---

## D-003

La Iniciativa continúa en Operación después de Producción.

---

## D-004

La evolución de una Iniciativa en Operación se administra mediante Solicitudes, Versiones y Despliegues.

---

## D-005

Los flujos paralelos forman parte de la Iniciativa y no se modelan como Iniciativas independientes.

---

## D-006

El avance operacional debe conservar aprobaciones, rechazos, decisiones, evidencias e Historial.

---

## D-007

Evolución describe el comportamiento de la Iniciativa en Operación y no se incorpora como un Estado de Iniciativa adicional.

---

# 11. Pendientes

* Validar el flujo AS-IS con Business Expert, Jefe de Proyecto, Responsable Funcional, Gestión Financiera TI, DevOps y DBA.
* Validar si los Estados de Iniciativa sugeridos en SRS-003 son suficientes para representar la operación real.
* Definir las condiciones verificables de entrada y salida de cada etapa.
* Definir quién puede aprobar, devolver, cancelar y cerrar una Iniciativa.
* Definir los criterios organizacionales para cerrar una Iniciativa.
* Definir cómo se representa una Iniciativa que no requiere Desarrollo.
* Definir el tratamiento operacional de una Producción cuyo Despliegue no obtiene el resultado esperado.
* Definir las dependencias mínimas entre Presupuesto, Recursos tecnológicos, DevOps y DBA.
* Definir tiempos de atención y SLA cuando corresponda.
* Definir eventos del dominio asociados a los cambios de etapa.
* Resolver el Pendiente de SRS-003 respecto del concepto Solución.
* Revisar los términos nuevos que pudieran surgir durante la validación y, si corresponde, proponer una nueva revisión de SRS-002 antes de incorporarlos.

---

# 12. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para describir el movimiento operacional de una Iniciativa dentro de Arauco Project Hub.
