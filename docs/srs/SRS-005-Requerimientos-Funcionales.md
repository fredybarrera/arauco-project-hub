# Arauco Project Hub

## Software Requirements Specification

# SRS-005 - Requerimientos Funcionales

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define los Requerimientos Funcionales iniciales de Arauco Project Hub.

Su propósito es convertir la Visión del Producto, el Modelo de Dominio y el Modelo Operacional aprobados en capacidades funcionales verificables, manteniendo a la Iniciativa como centro y conservando trazabilidad desde la Idea hasta la Operación.

Este documento define qué debe permitir el producto. No define pantallas, endpoints, persistencia ni tecnología.

---

# 2. Alcance

Los requerimientos comprenden:

* Gestión del contexto de la Iniciativa.
* Participantes.
* Componentes y Recursos.
* Documentos y Conversaciones.
* Ciclo de vida de la Iniciativa.
* Solicitudes en Operación.
* Versiones y Despliegues.
* Historial y consulta del contexto.
* Soporte de múltiples Negocios.

Quedan fuera del alcance:

* Permisos específicos por actor o Rol de Participación.
* Autenticación y autorización.
* SLA e indicadores.
* Integraciones corporativas.
* Notificaciones.
* Automatización de DevOps o DBA.
* Configuración libre de estados, tipos o flujos.
* Diseño de interfaz y API.

---

# 3. Principios Funcionales

* Toda capacidad debe mantener el contexto de una Iniciativa.
* La Iniciativa es la unidad principal del producto.
* Una Solicitud no existe fuera de una Iniciativa.
* El Estado de Iniciativa y el Estado de Solicitud permanecen separados.
* Las acciones y decisiones relevantes conservan trazabilidad.
* Los valores gobernados no son configuraciones libres.
* Cerrar o Cancelar no elimina el contexto registrado.
* La misma plataforma debe servir a múltiples Negocios sin fragmentar el modelo.
* La información no debe solicitarse nuevamente cuando puede derivarse del contexto.

---

# 4. Gestión de Iniciativas

## RF-001 - Registrar una Iniciativa

El producto debe permitir registrar una Iniciativa con:

* Negocio.
* Nombre.
* Objetivo.
* Justificación.
* Beneficio esperado.
* Fecha de creación.
* Al menos un Responsable Funcional.

**Criterios de aceptación:**

* La Iniciativa queda asociada a un único Negocio.
* El Estado de Iniciativa inicial queda registrado.
* La creación genera un evento del Historial.
* No se registra una Iniciativa sin Responsable Funcional.

## RF-002 - Consultar Iniciativas

El producto debe permitir consultar las Iniciativas disponibles para el actor.

**Criterios de aceptación:**

* Cada resultado permite reconocer el Negocio, nombre y Estado de Iniciativa vigente.
* La consulta no mezcla el contexto interno de distintas Iniciativas.
* Los filtros concretos se definirán cuando exista una necesidad validada.

## RF-003 - Consultar el contexto de una Iniciativa

El producto debe permitir consultar en un mismo contexto:

* Información general.
* Participantes.
* Componentes.
* Recursos.
* Documentos.
* Conversaciones.
* Solicitudes.
* Versiones.
* Despliegues.
* Historial.

**Criterios de aceptación:**

* Toda información presentada pertenece a la Iniciativa consultada.
* El Estado de Iniciativa vigente es visible.
* La ausencia de una responsabilidad se distingue de un error de consulta.

## RF-004 - Actualizar información general

El producto debe permitir actualizar la información general editable de una Iniciativa.

**Criterios de aceptación:**

* La actualización no cambia el Estado de Iniciativa de forma implícita.
* Los datos obligatorios permanecen válidos.
* Los cambios relevantes generan un evento del Historial.

---

# 5. Participantes

## RF-005 - Incorporar un Participante

El producto debe permitir incorporar una persona o equipo como Participante de una Iniciativa con un Rol de Participación aprobado.

**Criterios de aceptación:**

* El Participante queda asociado a una única Iniciativa en ese contexto.
* El Rol de Participación utiliza un valor gobernado.
* La incorporación genera trazabilidad.

## RF-006 - Consultar Participantes

El producto debe permitir conocer los Participantes y sus Roles de Participación dentro de una Iniciativa.

**Criterios de aceptación:**

* Una persona o equipo puede aparecer en distintas Iniciativas con roles diferentes.
* La consulta conserva la relación con la Iniciativa.

## RF-007 - Mantener responsabilidades obligatorias

El producto debe impedir que una Iniciativa quede sin Responsable Funcional.

La responsabilidad TI obligatoria se incorporará cuando se resuelva qué Rol de Participación aprobado la representa.

---

# 6. Componentes y Recursos

## RF-008 - Registrar un Componente

El producto debe permitir registrar un Componente requerido por una Iniciativa.

**Criterios de aceptación:**

* El Componente pertenece a la Iniciativa.
* El Tipo de Componente utiliza un valor gobernado.
* El registro genera trazabilidad.

## RF-009 - Consultar Componentes

El producto debe permitir consultar los Componentes de una Iniciativa sin tratarlos como módulos o Iniciativas independientes.

## RF-010 - Registrar un Recurso

El producto debe permitir registrar un Recurso técnico o presupuestario requerido por una Iniciativa.

**Criterios de aceptación:**

* El Recurso pertenece a la Iniciativa.
* Puede relacionarse con los Ambientes requeridos cuando corresponda.
* Su registro no implica aprobación ni habilitación automática.

## RF-011 - Consultar Recursos

El producto debe permitir consultar los Recursos y hacer visibles los Pendientes que afectan el avance de la Iniciativa.

Los Estados de Recurso y sus transiciones se incorporarán cuando sean aprobados.

---

# 7. Documentos y Conversaciones

## RF-012 - Registrar un Documento

El producto debe permitir asociar un Documento a una Iniciativa.

**Criterios de aceptación:**

* El Documento conserva su relación con la Iniciativa.
* Su registro genera trazabilidad.
* Cerrar o Cancelar la Iniciativa no elimina el Documento.

La gestión física de archivos, enlaces y versiones permanece Pendiente.

## RF-013 - Registrar una Conversación de Iniciativa

El producto debe permitir registrar una Conversación dentro del contexto de una Iniciativa.

**Criterios de aceptación:**

* La Conversación identifica su Iniciativa.
* Conserva fecha y responsable.
* Puede registrar decisiones, observaciones, aprobaciones, rechazos y coordinaciones.

## RF-014 - Registrar una Conversación de Solicitud

El producto debe permitir registrar una Conversación asociada a una Solicitud.

**Criterios de aceptación:**

* La Conversación pertenece a la misma Iniciativa que la Solicitud.
* La relación con la Solicitud es explícita.
* La Conversación permanece disponible al Cerrar o Cancelar la Solicitud.

## RF-015 - Fundamentar decisiones

El producto debe exigir una Conversación como fundamento de toda aprobación, rechazo, devolución o cancelación.

---

# 8. Ciclo de Vida de la Iniciativa

## RF-016 - Consultar el Estado de Iniciativa

El producto debe mantener y presentar un único Estado de Iniciativa vigente.

## RF-017 - Cambiar el Estado de Iniciativa

El producto debe permitir cambiar el Estado de Iniciativa cuando se cumplan las reglas aprobadas.

**Criterios de aceptación:**

* Se conserva el estado anterior y el nuevo.
* Se registra fecha y responsable.
* El cambio genera un evento del Historial.
* Una transición inválida no modifica la Iniciativa.

Las transiciones completas y responsables autorizados permanecen Pendientes.

## RF-018 - Registrar aprobación o rechazo en QAS

El producto debe permitir al Responsable Funcional aprobar o rechazar una validación en QAS.

**Criterios de aceptación:**

* La decisión incluye observación y evidencia.
* Un rechazo devuelve el trabajo a Desarrollo sin eliminar información previa.
* Una aprobación queda disponible para sustentar el paso a Producción.
* La decisión genera Historial.

## RF-019 - Cancelar una Iniciativa

El producto debe permitir Cancelar una Iniciativa registrando su fundamento.

**Criterios de aceptación:**

* La cancelación conserva Documentos, Conversaciones e Historial.
* La acción genera trazabilidad.
* La información no se elimina físicamente.

## RF-020 - Cerrar una Iniciativa

El producto debe permitir Cerrar una Iniciativa cuando se definan y cumplan los criterios organizacionales aprobados.

Cerrar no elimina su información ni trazabilidad.

---

# 9. Solicitudes

## RF-021 - Registrar una Solicitud

El producto debe permitir registrar una Solicitud dentro de una Iniciativa en uso o evolución.

**Criterios de aceptación:**

* La Solicitud pertenece a una Iniciativa.
* Tiene Tipo de Solicitud, Prioridad y Estado de Solicitud gobernados.
* Error, Mejora y Nuevo Desarrollo son los tipos permitidos.
* La creación genera un evento del Historial de la Iniciativa.

## RF-022 - Aplicar reglas de registro por actor

El producto debe aplicar las siguientes reglas:

* Un Usuario Final puede registrar una Solicitud de tipo Error o Mejora.
* Una Solicitud de tipo Nuevo Desarrollo solo puede ser registrada o aprobada por un Responsable Funcional o por el Equipo TI.

La correspondencia entre Equipo TI y los Roles de Participación aprobados permanece Pendiente.

## RF-023 - Consultar Solicitudes

El producto debe permitir consultar las Solicitudes de una Iniciativa.

**Criterios de aceptación:**

* Cada Solicitud presenta su Tipo de Solicitud, Prioridad y Estado de Solicitud.
* El Estado de Solicitud no se presenta como Estado de Iniciativa.
* Una Solicitud no puede consultarse como si fuera independiente de su Iniciativa.

## RF-024 - Cambiar el Estado de Solicitud

El producto debe permitir cambiar el Estado de Solicitud conforme a las reglas aprobadas.

**Criterios de aceptación:**

* El cambio no modifica por sí solo el Estado de Iniciativa.
* Se conserva trazabilidad del cambio.
* Una transición inválida no modifica la Solicitud.

Los responsables de cada transición permanecen Pendientes.

## RF-025 - Cerrar o Cancelar una Solicitud

El producto debe permitir Cerrar o Cancelar una Solicitud conservando sus Conversaciones y eventos del Historial.

---

# 10. Versiones y Despliegues

## RF-026 - Registrar una Versión

El producto debe permitir registrar una Versión identificable dentro de una Iniciativa.

**Criterios de aceptación:**

* La Versión pertenece a la Iniciativa.
* Su Identificación de Versión no se repite dentro de la misma Iniciativa.
* El registro genera trazabilidad.

La relación definitiva entre Solicitudes y Versiones permanece Pendiente.

## RF-027 - Consultar Versiones

El producto debe permitir consultar las Versiones de una Iniciativa y los Despliegues relacionados.

## RF-028 - Registrar un Despliegue

El producto debe permitir registrar el Despliegue de una Versión en un Ambiente.

**Criterios de aceptación:**

* El Despliegue corresponde a una Versión de la misma Iniciativa.
* Registra Ambiente, fecha, responsable, resultado, observaciones y evidencia cuando corresponda.
* Todo paso a PRD queda registrado como Despliegue.
* El registro genera Historial.

Los valores de Resultado de Despliegue permanecen Pendientes.

## RF-029 - Mantener continuidad hacia Operación

El producto debe mantener asociadas a la Iniciativa las Versiones y los Despliegues posteriores a su llegada a Operación.

---

# 11. Historial y Trazabilidad

## RF-030 - Generar Historial

El producto debe generar automáticamente un evento del Historial por cada acción relevante.

**Criterios de aceptación:**

* El evento pertenece a una Iniciativa.
* Registra fecha y descripción.
* Identifica al Participante responsable cuando corresponda.
* Conserva estado anterior y nuevo cuando corresponda.
* Puede referenciar una Solicitud de la misma Iniciativa.

El catálogo completo de eventos permanece Pendiente.

## RF-031 - Consultar Historial

El producto debe permitir consultar cronológicamente los eventos del Historial de una Iniciativa.

**Criterios de aceptación:**

* El Historial no reemplaza el estado vigente.
* Los eventos no se modifican para sustituir lo ocurrido.
* Cerrar o Cancelar no elimina eventos.

## RF-032 - Reconstruir el contexto

El producto debe permitir comprender, a partir del contexto conservado:

* Qué ocurrió.
* Cuándo ocurrió.
* Quién participó.
* Qué decisión se tomó.
* Qué fundamento o evidencia existe.

---

# 12. Múltiples Negocios

## RF-033 - Mantener pertenencia a un Negocio

Toda Iniciativa debe pertenecer a un Negocio.

## RF-034 - Separar información operacional

El producto debe impedir que la información operacional de una Iniciativa se mezcle con la de otro Negocio fuera de las capacidades de visibilidad que sean aprobadas.

Los permisos concretos permanecen Pendientes.

## RF-035 - Mantener un modelo común

El producto debe utilizar el mismo Lenguaje Ubicuo, estados, tipos y relaciones principales para todos los Negocios.

No se crearán flujos o modelos independientes por Negocio sin una necesidad validada y una revisión de los documentos de mayor prioridad.

---

# 13. Reglas Transversales

## RF-036 - Utilizar valores gobernados

El producto debe aceptar únicamente valores aprobados para:

* Rol de Participación.
* Estado de Iniciativa.
* Tipo de Solicitud.
* Prioridad.
* Estado de Solicitud.
* Tipo de Componente.
* Ambiente.

## RF-037 - Evitar eliminación de trazabilidad

El producto no debe eliminar Documentos, Conversaciones ni eventos del Historial como efecto de Cerrar o Cancelar una Iniciativa o Solicitud.

## RF-038 - Confirmar resultados

El producto debe comunicar si una acción fue completada, rechazada por una regla o no pudo completarse.

Una acción rechazada no debe dejar cambios parciales visibles.

---

# 14. Trazabilidad

| Requerimientos | Fuente principal |
| --- | --- |
| RF-001 a RF-004 | SRS-001, SRS-003 y SRS-004 |
| RF-005 a RF-007 | SRS-002, SRS-003 y RD-003 a RD-004 |
| RF-008 a RF-011 | SRS-003 y SRS-004 |
| RF-012 a RF-015 | PHIL-001, SRS-003 y RO-005 |
| RF-016 a RF-020 | SRS-003, SRS-004 y RO-003 a RO-010 |
| RF-021 a RF-025 | SRS-003, RD-001, RD-005, RD-006 y RO-011 a RO-012 |
| RF-026 a RF-029 | SRS-003 y RO-009 a RO-010 |
| RF-030 a RF-032 | PHIL-001, RD-008 y RO-014 a RO-015 |
| RF-033 a RF-035 | SRS-001, RD-002 y RD-010 |
| RF-036 a RF-038 | SRS-003, SRS-004 y PHIL-001 |

---

# 15. Pendientes

* Validar el alcance y la prioridad de los requerimientos con los actores.
* Resolver las transiciones completas de Estado de Iniciativa.
* Definir responsables por transición y permisos específicos.
* Resolver qué Rol de Participación representa al responsable TI y al Equipo TI.
* Definir las condiciones verificables de entrada y salida de etapas.
* Definir los Estados de Recurso.
* Definir los valores de Resultado de Despliegue.
* Validar la relación entre Solicitudes y Versiones.
* Definir el catálogo de eventos del Historial.
* Definir los criterios para Cerrar una Iniciativa.
* Resolver el tratamiento de archivos, enlaces y versiones de Documento.
* Priorizar el alcance funcional inicial.

Los Pendientes que modifiquen el Lenguaje Ubicuo, el Modelo de Dominio o el Modelo Operacional deben resolverse primero mediante una nueva revisión del SRS correspondiente.

---

# 16. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial de Requerimientos Funcionales de Arauco Project Hub.
