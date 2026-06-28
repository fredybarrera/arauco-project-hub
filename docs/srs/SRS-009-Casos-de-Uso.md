# Arauco Project Hub

## Software Requirements Specification

# SRS-009 - Casos de Uso

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define los Casos de Uso iniciales de Arauco Project Hub.

Su propósito es describir interacciones verificables entre los actores y el producto para ejecutar las capacidades y Flujos de Negocio aprobados, manteniendo a la Iniciativa como contexto y conservando permisos y trazabilidad.

Este documento no define pantallas, endpoints ni implementación.

---

# 2. Alcance

Los Casos de Uso cubren:

* Registro y consulta de Iniciativas.
* Participantes, Componentes y Recursos.
* Documentos y Conversaciones.
* Cambios de Estado de Iniciativa.
* Validación en QAS.
* Versiones y Despliegues.
* Solicitudes.
* Historial.
* Cancelación y cierre.

Los casos que dependen de permisos, transiciones o criterios no aprobados se mantienen Pendientes.

---

# 3. Convenciones

Cada Caso de Uso contiene:

* Actor principal.
* Objetivo.
* Precondiciones.
* Flujo principal.
* Alternativas.
* Resultado.
* Trazabilidad.

Reglas comunes:

1. El actor está autenticado.
2. El Backend evalúa permisos y reglas.
3. Una acción rechazada no modifica información.
4. Toda acción relevante genera Historial.
5. Una aprobación, rechazo, devolución o cancelación registra fundamento.

---

# 4. CU-001 - Registrar una Iniciativa

**Actor principal:** Pendiente de definición.

**Objetivo:** crear el contexto oficial de una necesidad.

**Precondiciones:**

* Existe un Negocio.
* Se dispone de la información obligatoria.
* Se conoce al menos un Responsable Funcional.

**Flujo principal:**

1. El actor informa Negocio, nombre, objetivo, justificación, beneficio esperado y Responsable Funcional.
2. El producto valida la información.
3. El Backend verifica el permiso.
4. El dominio valida las reglas.
5. Se registra la Iniciativa con su estado inicial.
6. Se genera Historial.
7. El producto presenta la Iniciativa creada.

**Alternativas:**

* Información incompleta: se indican los datos requeridos.
* Actor no autorizado: se rechaza sin crear información.
* Regla incumplida: se informa el motivo sin crear la Iniciativa.

**Resultado:** existe una Iniciativa válida y trazable.

**Trazabilidad:** FN-001, RF-001 y MP-005.

---

# 5. CU-002 - Consultar una Iniciativa

**Actor principal:** Participante.

**Objetivo:** comprender el contexto y estado vigente.

**Precondiciones:** el actor participa en la Iniciativa.

**Flujo principal:**

1. El actor selecciona la Iniciativa.
2. El Backend verifica su participación.
3. El producto presenta información general y Estado de Iniciativa.
4. El actor consulta las responsabilidades relacionadas que necesita.

**Alternativas:**

* Iniciativa inexistente: se informa que no fue encontrada.
* Acceso no permitido: no se expone información.
* Responsabilidad sin registros: se presenta vacía.

**Resultado:** el actor consulta el contexto sin modificarlo.

**Trazabilidad:** FN-002, RF-002, RF-003 y MP-001.

---

# 6. CU-003 - Actualizar Información General

**Actor principal:** Jefe de Proyecto o Responsable Funcional.

**Objetivo:** mantener vigente la información general.

**Precondiciones:** el actor participa con un rol autorizado.

**Flujo principal:**

1. El actor consulta la Iniciativa.
2. Modifica los datos editables.
3. El producto valida su forma.
4. El Backend verifica permiso y reglas.
5. Se guardan los cambios.
6. Se genera Historial cuando el cambio es relevante.

**Alternativas:**

* Datos inválidos: no se guardan cambios.
* Conflicto con una modificación reciente: se informa el conflicto.

**Resultado:** la información queda actualizada sin cambiar implícitamente el Estado de Iniciativa.

**Trazabilidad:** RF-004 y MP-006.

---

# 7. CU-004 - Incorporar un Participante

**Actor principal:** Jefe de Proyecto.

**Objetivo:** incorporar una persona o equipo con un Rol de Participación.

**Precondiciones:** el actor coordina la Iniciativa.

**Flujo principal:**

1. El actor identifica la persona o equipo.
2. Selecciona un Rol de Participación aprobado.
3. El Backend verifica permiso y contexto.
4. Se incorpora el Participante.
5. Se genera Historial.

**Alternativas:**

* Rol no gobernado: se rechaza.
* Contexto incorrecto: no se incorpora.

**Resultado:** el Participante queda asociado únicamente a esa Iniciativa y responsabilidad.

**Trazabilidad:** RF-005 a RF-007 y MP-007.

---

# 8. CU-005 - Registrar un Componente o Recurso

**Actor principal:** Technical Lead.

**Actores relacionados:** Jefe de Proyecto para Recursos.

**Objetivo:** mantener visibles las necesidades técnicas o presupuestarias.

**Precondiciones:** el actor participa en la Iniciativa.

**Flujo principal:**

1. El actor selecciona la Iniciativa.
2. Indica si registra un Componente o Recurso.
3. Informa los datos requeridos y valores gobernados.
4. El Backend verifica permiso y reglas.
5. Se registra dentro de la Iniciativa.
6. Se genera Historial.

**Alternativas:**

* Valor no gobernado: se rechaza.
* Recurso registrado: no se considera aprobado ni habilitado automáticamente.

**Resultado:** el Componente o Recurso queda visible en el contexto.

**Trazabilidad:** RF-008 a RF-011 y MP-010 a MP-013.

---

# 9. CU-006 - Registrar un Documento o Conversación

**Actor principal:** Participante.

**Objetivo:** conservar información, evidencia o coordinación en contexto.

**Precondiciones:** el actor participa en la Iniciativa.

**Flujo principal:**

1. El actor selecciona la Iniciativa.
2. Registra un Documento o una Conversación.
3. Si corresponde, relaciona la Conversación con una Solicitud de la misma Iniciativa.
4. El Backend verifica pertenencia y permiso.
5. Se registra fecha y responsable.
6. Se genera la trazabilidad aplicable.

**Alternativas:**

* Solicitud de otra Iniciativa: se rechaza la relación.
* Información inválida: no se registra.

**Resultado:** la información permanece asociada a su contexto.

**Trazabilidad:** RF-012 a RF-015 y MP-014 a MP-016.

---

# 10. CU-007 - Cambiar Estado de Iniciativa

**Actor principal:** Pendiente por transición.

**Objetivo:** registrar un avance, devolución, Cancelación o Cierre válido.

**Precondiciones:**

* La Iniciativa existe.
* El actor y la transición están autorizados.
* Se cumplen las condiciones aplicables.

**Flujo principal:**

1. El actor consulta el estado vigente.
2. Solicita el nuevo Estado de Iniciativa.
3. Registra fundamento cuando corresponda.
4. El Backend verifica permiso, transición y condiciones.
5. El dominio aplica el cambio.
6. Se conserva estado anterior, nuevo, fecha y responsable.
7. Se genera Historial.

**Alternativas:**

* Transición inválida: no cambia el estado.
* Condición faltante: se informan los Pendientes.
* Conflicto: se conserva el estado más reciente.

**Resultado:** existe un único Estado de Iniciativa vigente y trazable.

**Trazabilidad:** RF-016 a RF-020, MP-008, MP-009 y FN-003 a FN-006.

---

# 11. CU-008 - Aprobar o Rechazar en QAS

**Actor principal:** Responsable Funcional.

**Objetivo:** registrar la validación funcional de una entrega.

**Precondiciones:**

* Existe una Versión en QAS.
* El actor participa como Responsable Funcional.

**Flujo principal:**

1. El actor consulta la Versión y evidencia.
2. Indica aprobación o rechazo.
3. Registra observación y evidencia.
4. El Backend verifica permiso y contexto.
5. Se registra la decisión en Conversación.
6. Se genera Historial.

**Alternativa — Rechazo:**

* El trabajo vuelve a Desarrollo.
* No se elimina la Versión ni la evidencia previa.

**Resultado:** existe una decisión trazable que permite continuar o devolver el trabajo.

**Trazabilidad:** RF-018, MP-024 y FN-005.

---

# 12. CU-009 - Registrar una Versión

**Actor principal:** Technical Lead.

**Objetivo:** identificar una entrega de la Iniciativa.

**Precondiciones:** el actor participa como Technical Lead.

**Flujo principal:**

1. El actor informa la Identificación de Versión.
2. El Backend verifica permiso y unicidad dentro de la Iniciativa.
3. Se registra la Versión.
4. Se genera Historial.

**Alternativa:** una identificación repetida se rechaza.

**Resultado:** existe una Versión identificable dentro de la Iniciativa.

**Trazabilidad:** RF-026, RF-027 y MP-022.

---

# 13. CU-010 - Registrar un Despliegue

**Actor principal:** DevOps.

**Actores relacionados:** Technical Lead y DBA según responsabilidad.

**Objetivo:** conservar evidencia de la publicación de una Versión.

**Precondiciones:**

* La Versión pertenece a la Iniciativa.
* El actor participa en el Despliegue.

**Flujo principal:**

1. El actor selecciona la Versión y Ambiente.
2. Registra fecha, responsable, resultado, observaciones y evidencia.
3. El Backend verifica permiso y relaciones.
4. Se registra el Despliegue.
5. Se genera Historial.

**Alternativas:**

* Versión de otra Iniciativa: se rechaza.
* Resultado no esperado: no se asume avance a Operación.

**Resultado:** el Despliegue queda asociado a la Versión y la Iniciativa.

**Trazabilidad:** RF-028, RF-029, MP-023 y FN-006.

---

# 14. CU-011 - Registrar una Solicitud

**Actor principal:** Usuario Final o Responsable Funcional.

**Objetivo:** incorporar una necesidad operacional.

**Precondiciones:**

* La Iniciativa está en uso o evolución.
* El actor participa en ella.

**Flujo principal:**

1. El actor selecciona la Iniciativa.
2. Indica Tipo de Solicitud, Prioridad e información requerida.
3. El Backend verifica permiso según el tipo.
4. El dominio valida valores y contexto.
5. Se registra la Solicitud con estado inicial.
6. Se genera Historial.

**Alternativas:**

* Usuario Final intenta registrar Nuevo Desarrollo: se rechaza.
* Tipo o Prioridad no gobernados: se rechaza.
* El permiso de Equipo TI para Nuevo Desarrollo permanece Pendiente.

**Resultado:** existe una Solicitud sin modificar el Estado de Iniciativa.

**Trazabilidad:** RF-021, RF-022, MP-017 a MP-019 y FN-007.

---

# 15. CU-012 - Cambiar Estado de Solicitud

**Actor principal:** Pendiente por transición.

**Objetivo:** mantener el avance propio de una Solicitud.

**Precondiciones:**

* La Solicitud pertenece a la Iniciativa.
* La transición y el actor están autorizados.

**Flujo principal:**

1. El actor consulta el Estado de Solicitud.
2. Solicita el nuevo estado.
3. Registra fundamento cuando corresponde.
4. El Backend verifica permiso y transición.
5. Se aplica el cambio.
6. Se genera Historial en la Iniciativa.

**Alternativas:**

* Transición inválida: no cambia el estado.
* Rechazo en QAS: conserva evidencia y vuelve a Desarrollo.

**Resultado:** cambia el Estado de Solicitud sin cambiar por sí solo el Estado de Iniciativa.

**Trazabilidad:** RF-024, RF-025, MP-020, MP-021 y FN-008.

---

# 16. CU-013 - Consultar Historial

**Actor principal:** Participante.

**Objetivo:** comprender qué ocurrió, cuándo, quién participó y por qué.

**Precondiciones:** el actor participa en la Iniciativa.

**Flujo principal:**

1. El actor consulta el Historial.
2. El producto presenta los eventos en orden cronológico.
3. El actor identifica fecha, descripción, responsable y cambios de estado cuando corresponda.
4. Puede reconocer la Solicitud relacionada cuando existe.

**Alternativa:** si no existen eventos adicionales, se mantiene visible el evento de creación.

**Resultado:** el actor reconstruye el contexto sin modificar eventos.

**Trazabilidad:** RF-030 a RF-032 y MP-003, MP-025, MP-026.

---

# 17. Matriz de Cobertura

| Caso de Uso | Flujo | Requerimientos principales |
| --- | --- | --- |
| CU-001 | FN-001 | RF-001, RF-033 |
| CU-002 | FN-002 | RF-002, RF-003 |
| CU-003 | FN-002 | RF-004 |
| CU-004 | FN-004 | RF-005 a RF-007 |
| CU-005 | FN-004 | RF-008 a RF-011 |
| CU-006 | FN-003 a FN-009 | RF-012 a RF-015 |
| CU-007 | FN-003 a FN-006, FN-009 | RF-016 a RF-020 |
| CU-008 | FN-005 | RF-018 |
| CU-009 | FN-005, FN-008 | RF-026, RF-027 |
| CU-010 | FN-006, FN-008 | RF-028, RF-029 |
| CU-011 | FN-007 | RF-021, RF-022 |
| CU-012 | FN-008, FN-009 | RF-023 a RF-025 |
| CU-013 | Todos | RF-030 a RF-032 |

---

# 18. Pendientes

* Definir el actor autorizado para CU-001.
* Completar CU-007 con transiciones, condiciones y permisos aprobados.
* Completar CU-012 con transiciones y permisos aprobados.
* Definir criterios y autoridad para Cerrar o Cancelar.
* Resolver Equipo TI dentro de los Roles de Participación.
* Definir Estados de Recurso para detallar su gestión.
* Validar la relación entre Solicitud y Versión.
* Definir tratamiento de un Despliegue con resultado no esperado.
* Validar Casos de Uso con los actores.

Estos Pendientes deben resolverse en el documento de mayor prioridad correspondiente.

---

# 19. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial de Casos de Uso de Arauco Project Hub.
