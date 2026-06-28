# Arauco Project Hub

## Software Requirements Specification

# SRS-008 - Flujos de Negocio

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define los Flujos de Negocio iniciales de Arauco Project Hub.

Su propósito es describir cómo los actores utilizan las capacidades aprobadas para mantener una Iniciativa desde su registro hasta Operación y evolución mediante Solicitudes, conservando permisos, decisiones, evidencias e Historial.

Este documento organiza reglas existentes en secuencias verificables. No crea estados, actores, permisos ni conceptos nuevos.

---

# 2. Alcance

Este documento comprende:

* Registro y consulta de una Iniciativa.
* Evaluación y aprobación.
* Preparación y flujos paralelos.
* Desarrollo y validación en QAS.
* Producción y paso a Operación.
* Registro y atención de Solicitudes.
* Cancelación y cierre.
* Consulta de contexto e Historial.

Quedan fuera del alcance:

* Diseño de pantallas.
* Endpoints.
* Automatización técnica.
* Notificaciones.
* SLA.
* Transiciones y permisos todavía Pendientes.
* Variantes no respaldadas por documentos Approved.

---

# 3. Principios

* Todo flujo ocurre dentro del contexto de una Iniciativa.
* Un cambio de estado requiere una acción explícita y trazable.
* El Estado de Iniciativa y el Estado de Solicitud no se sustituyen.
* Las aprobaciones, rechazos, devoluciones y cancelaciones registran fundamento.
* El Backend evalúa permisos y reglas antes de modificar información.
* Una acción rechazada no deja cambios parciales.
* Los flujos paralelos no son Iniciativas independientes.
* Llegar a Producción no termina la Iniciativa.

---

# 4. Convenciones

Cada flujo describe:

* **Objetivo:** resultado buscado.
* **Actores:** participantes con responsabilidad aprobada.
* **Precondiciones:** contexto necesario.
* **Flujo principal:** secuencia esperada.
* **Alternativas:** resultados distintos sin inventar reglas.
* **Resultado:** estado observable al finalizar.
* **Trazabilidad:** evidencia que debe conservarse.

Cuando un paso depende de una definición no aprobada, se identifica como Pendiente.

---

# 5. FN-001 - Registrar una Iniciativa

## Objetivo

Crear el contexto oficial de una necesidad del Negocio.

## Actores

El actor autorizado para iniciar este flujo permanece Pendiente en SRS-007.

## Precondiciones

* Existe un Negocio aprobado.
* Se conoce al menos un Responsable Funcional.
* Se dispone de nombre, objetivo, justificación y beneficio esperado.

## Flujo principal

1. El actor solicita registrar una Iniciativa.
2. El producto valida la forma de la información.
3. El Backend verifica que el actor esté autorizado.
4. El dominio valida Negocio y Responsable Funcional.
5. La Iniciativa se registra con su Estado de Iniciativa inicial.
6. Se genera el evento de creación en el Historial.
7. El producto confirma el resultado y presenta el contexto creado.

## Alternativas

* Si falta información obligatoria, el registro se rechaza indicando los datos requeridos.
* Si el actor no está autorizado, no se registra información.
* Si una regla del dominio no se cumple, no se crea la Iniciativa.

## Resultado

Existe una Iniciativa asociada a un Negocio, con Responsable Funcional, estado vigente e Historial.

## Trazabilidad

RF-001, RF-033, MP-005, RD-002, RD-003 y RO-002.

---

# 6. FN-002 - Consultar el Contexto de una Iniciativa

## Objetivo

Permitir que un Participante comprenda el estado y contexto vigente.

## Actores

Todo Participante de la Iniciativa.

## Precondiciones

* El actor está autenticado.
* El actor es Participante de la Iniciativa.

## Flujo principal

1. El actor selecciona una Iniciativa.
2. El Backend verifica su participación.
3. El producto recupera la información disponible.
4. Se presenta información general, Estado de Iniciativa y responsabilidades relacionadas.
5. El actor puede consultar Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial.

## Alternativas

* Si la Iniciativa no existe, se comunica que no fue encontrada.
* Si el actor no tiene permiso, no se expone su información.
* Una responsabilidad sin registros se presenta vacía y no como fallo.

## Resultado

El actor obtiene una visión coherente sin modificar la Iniciativa.

## Trazabilidad

RF-002, RF-003, MP-001 a MP-004 y RNF-010.

---

# 7. FN-003 - Evaluar y Aprobar una Iniciativa

## Objetivo

Comprender la necesidad y registrar la decisión de continuar.

## Actores

* Business Expert.
* Responsable Funcional.
* Jefe de Proyecto.
* Technical Lead.
* Gestión Financiera TI, DevOps y DBA cuando corresponda.

## Precondiciones

* La Iniciativa existe.
* La información necesaria para Evaluación está disponible.

## Flujo principal

1. Los Participantes consultan el contexto de la Iniciativa.
2. El Responsable Funcional valida la necesidad.
3. Business Expert orienta su valor estratégico.
4. Jefe de Proyecto coordina la Evaluación.
5. Technical Lead registra la evaluación técnica mediante Documentos o Conversaciones.
6. Se identifican Componentes y Recursos preliminares cuando corresponda.
7. Las decisiones y Pendientes quedan registrados en Conversaciones.
8. El actor autorizado solicita el cambio de Estado de Iniciativa.
9. El Backend verifica permiso, estado vigente y reglas aplicables.
10. Si la decisión es válida, se registra el nuevo estado y su evento del Historial.

## Alternativas

* La Iniciativa permanece en Evaluación mientras existan Pendientes.
* Puede Cancelarse registrando fundamento, cuando se apruebe la autoridad correspondiente.
* Si falta una condición requerida, el cambio de estado se rechaza sin perder información.

## Resultado

La Iniciativa permanece en Evaluación, resulta Aprobada o queda Cancelada según una decisión trazable.

## Pendientes

* Autoridad para aprobar o cancelar.
* Condiciones verificables de salida de Evaluación.
* Matriz completa de transiciones.

## Trazabilidad

SRS-004 secciones 6.2 y 6.3, RF-017, MP-008 y MP-009.

---

# 8. FN-004 - Preparar una Iniciativa

## Objetivo

Coordinar los Participantes, Componentes, Recursos, Ambientes y Documentos necesarios para comenzar Desarrollo.

## Actores

* Jefe de Proyecto.
* Technical Lead.
* Gestión Financiera TI.
* DevOps.
* DBA.

## Precondiciones

* La Iniciativa está Aprobada o en Preparación según la transición aplicable.

## Flujo principal

1. Jefe de Proyecto revisa los Pendientes de preparación.
2. Incorpora los Participantes requeridos.
3. Technical Lead registra los Componentes y Recursos necesarios.
4. Gestión Financiera TI registra la revisión de Recursos presupuestarios.
5. DevOps y DBA registran avances sobre los Recursos bajo su responsabilidad.
6. Los flujos avanzan en paralelo cuando la Iniciativa lo requiere.
7. Documentos, decisiones y dependencias quedan asociados a la Iniciativa.
8. Cuando se cumplan las condiciones aprobadas, el actor autorizado solicita avanzar a Desarrollo.
9. El Backend valida las condiciones y registra el cambio con Historial.

## Alternativas

* Un Recurso pendiente puede impedir el avance sin bloquear otros flujos.
* Un rechazo debe registrar su fundamento.
* La Iniciativa permanece en Preparación si faltan condiciones necesarias.

## Resultado

La Iniciativa conserva una visión compartida de su preparación y avanza únicamente cuando cuenta con condiciones aprobadas.

## Pendientes

* Estados de Recurso.
* Dependencias mínimas entre flujos.
* Condiciones verificables para iniciar Desarrollo.

## Trazabilidad

RF-005 a RF-015, RO-006, RO-013 y MP-007 a MP-016.

---

# 9. FN-005 - Desarrollar y Validar en QAS

## Objetivo

Construir una entrega identificable y obtener validación funcional.

## Actores

* Jefe de Proyecto.
* Technical Lead.
* Developer.
* Responsable Funcional.
* Usuario Final cuando corresponda.

## Precondiciones

* La Iniciativa se encuentra en Desarrollo.
* Existen las condiciones necesarias para ejecutar el trabajo.

## Flujo principal

1. Technical Lead y Developer realizan el trabajo de Desarrollo.
2. Las decisiones y cambios relevantes se registran en la Iniciativa.
3. Technical Lead registra una Versión disponible para validación.
4. El actor autorizado solicita avanzar a QAS.
5. El Responsable Funcional valida la Versión.
6. Registra aprobación o rechazo con observación y evidencia.
7. El Backend verifica permiso y reglas.
8. Se conserva la decisión en Conversación e Historial.
9. Si se aprueba, la Iniciativa puede continuar hacia Producción.

## Alternativa - Rechazo en QAS

1. El Responsable Funcional registra el rechazo, observación y evidencia.
2. El trabajo vuelve a Desarrollo.
3. La Versión, evidencia y trazabilidad previa se conservan.
4. Se registra una nueva Versión cuando corresponda repetir la validación.

## Resultado

Existe una validación trazable de la entrega y no se avanza a Producción sin aprobación del Responsable Funcional.

## Trazabilidad

RF-018, RF-026, MP-022, MP-024 y RO-007 a RO-008.

---

# 10. FN-006 - Desplegar en PRD y Avanzar a Operación

## Objetivo

Registrar la publicación de una Versión aprobada y mantener continuidad hacia Operación.

## Actores

* DevOps.
* DBA cuando corresponda.
* Technical Lead.
* Developer.
* Responsable Funcional.

## Precondiciones

* Existe una Versión aprobada en QAS.
* Se encuentran disponibles los Recursos necesarios para PRD.

## Flujo principal

1. Los Participantes coordinan el paso a PRD.
2. DevOps registra el Despliegue de la Versión.
3. Se registra Ambiente PRD, fecha, responsable, resultado, observaciones y evidencia.
4. DBA y Technical Lead completan el contexto bajo su responsabilidad cuando corresponda.
5. El Backend genera el evento del Historial.
6. Cuando la Solución está disponible para uso, el actor autorizado solicita avanzar la Iniciativa a Operación.
7. El Backend verifica las reglas y registra el cambio.

## Alternativas

* Si el Despliegue no obtiene el resultado esperado, no se asume el avance a Operación.
* El tratamiento completo de ese resultado permanece Pendiente.

## Resultado

El paso a PRD queda representado por un Despliegue y la Iniciativa continúa en Operación sin perder su contexto.

## Trazabilidad

RF-028, RF-029, MP-023, RO-009 y RO-010.

---

# 11. FN-007 - Registrar una Solicitud

## Objetivo

Incorporar una necesidad operacional dentro del contexto de una Iniciativa.

## Actores

* Usuario Final.
* Responsable Funcional.
* Equipo TI cuando se resuelva su correspondencia con Roles de Participación.

## Precondiciones

* La Iniciativa se encuentra en uso o evolución.
* El actor participa en la Iniciativa.

## Flujo principal

1. El actor selecciona la Iniciativa.
2. Registra Tipo de Solicitud, Prioridad e información necesaria.
3. El Backend verifica el permiso según el Tipo de Solicitud.
4. El dominio valida valores y pertenencia.
5. La Solicitud se registra con su Estado de Solicitud inicial.
6. Se genera un evento en el Historial de la Iniciativa.
7. El producto confirma el resultado.

## Reglas por Tipo de Solicitud

* Usuario Final puede registrar Error o Mejora.
* Responsable Funcional puede registrar Error, Mejora o Nuevo Desarrollo.
* El permiso del Equipo TI para Nuevo Desarrollo permanece Pendiente.

## Resultado

Existe una Solicitud dentro de una Iniciativa, sin modificar por sí sola el Estado de Iniciativa.

## Trazabilidad

RF-021, RF-022, MP-017 a MP-019 y RD-001, RD-005, RD-006.

---

# 12. FN-008 - Atender una Solicitud

## Objetivo

Mantener trazabilidad desde una necesidad operacional hasta su validación y llegada a Producción.

## Actores

* Responsable Funcional.
* Technical Lead.
* Developer.
* Usuario Final cuando corresponda.
* DevOps y DBA según los Componentes y Recursos involucrados.

## Precondiciones

* La Solicitud existe dentro de una Iniciativa.

## Flujo general

1. Los Participantes consultan la Solicitud y sus Conversaciones.
2. La Solicitud avanza conforme a sus Estados de Solicitud aprobados.
3. Technical Lead y Developer realizan el trabajo requerido.
4. Las decisiones se registran como Conversaciones.
5. La entrega se valida en QAS.
6. Responsable Funcional registra aprobación o rechazo con observación.
7. Una aprobación puede continuar hacia Producción.
8. El Despliegue correspondiente se registra dentro de la Iniciativa.
9. La Solicitud puede Cerrarse cuando se cumplan los criterios aprobados.

## Alternativas

* Un rechazo en QAS conserva evidencia y devuelve el trabajo a Desarrollo.
* La Solicitud puede Cancelarse registrando fundamento cuando se defina la autoridad.

## Pendientes

* Permisos por transición.
* Relación definitiva entre Solicitud y Versión.
* Criterios y autoridad para Cerrar o Cancelar.

## Resultado

La Solicitud evoluciona sin reemplazar el Estado de Iniciativa y conserva sus Conversaciones e Historial.

## Trazabilidad

RF-023 a RF-029, MP-020 a MP-024 y RO-011 a RO-012.

---

# 13. FN-009 - Cancelar o Cerrar

## Objetivo

Finalizar la gestión activa sin eliminar el contexto.

## Precondiciones

* Existe una Iniciativa o Solicitud.
* El actor autorizado y los criterios permanecen sujetos a definición.

## Flujo principal

1. El actor registra el fundamento mediante una Conversación.
2. Solicita Cancelar o Cerrar.
3. El Backend verifica autoridad, estado y reglas.
4. Si la acción es válida, registra el estado nuevo.
5. Se genera el evento del Historial.
6. Documentos, Conversaciones e Historial permanecen disponibles.

## Resultado

La gestión deja de estar activa sin eliminar su memoria trazable.

## Pendientes

* Autoridad.
* Criterios organizacionales de cierre.
* Transiciones permitidas.

## Trazabilidad

RF-019, RF-020, RF-025, RF-037, MP-009, MP-021 y RO-015.

---

# 14. Reglas Transversales

## FN-R01

Toda acción valida forma, permiso y reglas antes de persistir cambios.

## FN-R02

Toda acción relevante genera Historial dentro de la misma operación consistente.

## FN-R03

Toda aprobación, rechazo, devolución o cancelación registra fundamento mediante Conversación.

## FN-R04

Una acción rechazada no modifica el estado vigente.

## FN-R05

Las consultas no modifican el dominio.

## FN-R06

Ningún flujo autoriza eliminar información para reemplazar lo ocurrido.

---

# 15. Trazabilidad

| Flujo | Fuentes principales |
| --- | --- |
| FN-001 | RF-001, RD-002, RD-003, RO-002 |
| FN-002 | RF-002, RF-003, MP-001 a MP-004 |
| FN-003 | SRS-004 secciones 6.2 y 6.3, RF-017 |
| FN-004 | SRS-004 sección 6.4, RF-005 a RF-015 |
| FN-005 | SRS-004 secciones 6.5 y 6.6, RF-018, RF-026 |
| FN-006 | SRS-004 secciones 6.7 y 6.8, RF-028, RF-029 |
| FN-007 | RF-021, RF-022, MP-017 a MP-019 |
| FN-008 | RF-023 a RF-029, MP-020 a MP-024 |
| FN-009 | RF-019, RF-020, RF-025, RO-015 |

---

# 16. Pendientes

* Definir actor autorizado para registrar una Iniciativa.
* Definir transiciones completas y permisos de Estado de Iniciativa.
* Definir transiciones completas y permisos de Estado de Solicitud.
* Definir condiciones verificables de entrada y salida de etapas.
* Definir Estados de Recurso.
* Resolver Equipo TI dentro de los Roles de Participación.
* Definir tratamiento de un Despliegue sin resultado esperado.
* Validar la relación entre Solicitud y Versión.
* Definir criterios y autoridad para Cerrar o Cancelar.
* Validar los flujos con los actores involucrados.

Los Pendientes deben resolverse en el documento de mayor prioridad que corresponda antes de completar estos flujos.

---

# 17. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial de Flujos de Negocio de Arauco Project Hub.
