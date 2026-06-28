# Arauco Project Hub

## Software Requirements Specification

# SRS-007 - Modelo de Permisos

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define el Modelo de Permisos inicial de Arauco Project Hub.

Su propósito es establecer qué actores pueden consultar o ejecutar las capacidades aprobadas dentro del contexto de una Iniciativa, manteniendo transparencia, menor privilegio, responsabilidad visible y trazabilidad.

Este documento define reglas funcionales de acceso. No selecciona proveedor de identidad, protocolo de autenticación ni mecanismo técnico de autorización.

---

# 2. Alcance

Este documento establece:

* Los principios del Modelo de Permisos.
* La relación entre identidad, Participante y Rol de Participación.
* El alcance de consulta dentro de una Iniciativa.
* Los permisos respaldados por responsabilidades aprobadas.
* Las reglas transversales de autorización y trazabilidad.
* Los permisos que permanecen Pendientes.

Quedan fuera del alcance:

* Proveedor de identidad.
* Roles técnicos o administrativos de plataforma.
* Gestión de cuentas.
* Acceso de servicios e integraciones.
* Clasificación detallada de información.
* Permisos sobre capacidades todavía no aprobadas.
* Implementación técnica de políticas.

---

# 3. Principios

## 3.1 La identidad no reemplaza al Participante

La identidad autenticada permite reconocer a una persona o equipo.

El Participante representa su responsabilidad dentro de una Iniciativa mediante un Rol de Participación. Una misma identidad puede tener responsabilidades diferentes en distintas Iniciativas.

## 3.2 Los permisos dependen del contexto

Un permiso sobre una Iniciativa no se extiende automáticamente a otras Iniciativas.

La autorización debe considerar:

* La identidad.
* La Iniciativa.
* El Rol de Participación.
* La capacidad solicitada.
* El estado vigente cuando una regla aprobada lo requiera.

## 3.3 Transparencia esperada

Los Participantes deben poder consultar el contexto necesario para colaborar, salvo que una clasificación de información aprobada exija una restricción específica.

## 3.4 Menor privilegio

Una acción solo se permite cuando existe una responsabilidad aprobada que la justifica.

La ausencia de definición no concede permiso.

## 3.5 Backend como autoridad

El Backend debe evaluar la autorización. El Frontend puede ocultar o deshabilitar acciones, pero no constituye el límite de seguridad.

## 3.6 Responsabilidad visible

Toda acción relevante debe permitir identificar al Participante responsable y generar la trazabilidad correspondiente.

---

# 4. Actores y Roles de Participación

Los valores aprobados son:

* Business Expert.
* Jefe de Proyecto.
* Technical Lead.
* Developer.
* Responsable Funcional.
* Usuario Final.
* Gestión Financiera TI.
* DevOps.
* DBA.

Este documento no crea roles adicionales.

La expresión Equipo TI utilizada en RD-005 todavía no corresponde de manera inequívoca a uno o más Roles de Participación aprobados. Los permisos que dependan de esa expresión permanecen Pendientes hasta revisar el SRS de mayor prioridad correspondiente.

---

# 5. Alcances de Acceso

## 5.1 Iniciativa

Es el alcance principal. Los permisos se evalúan dentro de una Iniciativa específica.

## 5.2 Negocio

La pertenencia de una Iniciativa a un Negocio debe impedir mezclar información operacional entre Negocios.

La visibilidad transversal de Iniciativas de un mismo Negocio permanece Pendiente de validación.

## 5.3 Plataforma

No se definen permisos globales de plataforma en esta versión.

Si aparece la necesidad de administrar catálogos, identidades o configuración transversal, deberá justificarse sin introducir conceptos del dominio por conveniencia técnica.

---

# 6. Permisos de Consulta

## MP-001 - Consultar una Iniciativa

Todo Participante de una Iniciativa puede consultar:

* Información general.
* Estado de Iniciativa.
* Participantes.
* Componentes.
* Recursos.
* Documentos.
* Conversaciones.
* Solicitudes.
* Versiones.
* Despliegues.
* Historial.

La información clasificada puede requerir restricciones adicionales cuando dicha clasificación sea aprobada.

## MP-002 - Consultar Solicitudes

Todo Participante de una Iniciativa puede consultar sus Solicitudes y el Estado de Solicitud vigente.

## MP-003 - Consultar Historial

Todo Participante de una Iniciativa puede consultar su Historial.

Los eventos no se ocultan para alterar la comprensión de lo ocurrido.

## MP-004 - Consultar otras Iniciativas

La consulta de una Iniciativa en la que el actor no es Participante permanece Pendiente.

Este permiso deberá equilibrar transparencia, separación entre Negocios y protección de información.

---

# 7. Permisos sobre la Iniciativa

## MP-005 - Registrar una Iniciativa

Los actores autorizados para registrar una Iniciativa permanecen Pendientes.

El registro debe asegurar un Negocio y al menos un Responsable Funcional.

## MP-006 - Actualizar información general

El Jefe de Proyecto y el Responsable Funcional pueden actualizar la información general de una Iniciativa en la que participan.

El Technical Lead puede actualizar información técnica únicamente mediante las capacidades específicas aprobadas.

## MP-007 - Incorporar Participantes

El Jefe de Proyecto puede incorporar Participantes a la Iniciativa que coordina.

La sustitución o retiro de Participantes permanece Pendiente. Ninguna acción puede dejar la Iniciativa sin Responsable Funcional.

## MP-008 - Cambiar Estado de Iniciativa

Los permisos por transición de Estado de Iniciativa permanecen Pendientes.

Las siguientes responsabilidades aprobadas orientan su definición posterior:

* Business Expert participa en Evaluación y aprobación.
* Jefe de Proyecto coordina el avance integral.
* Responsable Funcional valida la necesidad y aprueba o rechaza en QAS.
* Technical Lead mantiene la responsabilidad técnica.

Estas responsabilidades no autorizan por sí solas todas las transiciones.

## MP-009 - Cancelar o Cerrar una Iniciativa

Los actores autorizados para Cancelar o Cerrar una Iniciativa permanecen Pendientes.

La acción debe registrar fundamento mediante una Conversación.

---

# 8. Permisos sobre Componentes y Recursos

## MP-010 - Registrar Componentes

El Technical Lead puede registrar Componentes de la Iniciativa en la que participa.

## MP-011 - Registrar Recursos

El Technical Lead y el Jefe de Proyecto pueden registrar Recursos requeridos por la Iniciativa.

Registrar un Recurso no implica aprobarlo ni habilitarlo.

## MP-012 - Gestionar Recursos presupuestarios

Gestión Financiera TI puede registrar la revisión, valorización y aprobación de Recursos presupuestarios dentro de su responsabilidad.

Los estados y transiciones de Recurso permanecen Pendientes.

## MP-013 - Gestionar Recursos técnicos

DevOps y DBA pueden registrar decisiones, avances y resultados sobre los Recursos bajo su responsabilidad.

El alcance concreto depende de los Estados de Recurso que sean aprobados.

---

# 9. Permisos sobre Documentos y Conversaciones

## MP-014 - Registrar Documentos

Todo Participante puede registrar Documentos en la Iniciativa cuando sean pertinentes a su responsabilidad.

Los permisos para reemplazar o retirar un Documento permanecen Pendientes.

## MP-015 - Registrar Conversaciones

Todo Participante puede registrar Conversaciones en la Iniciativa.

Un Participante puede registrar una Conversación de Solicitud cuando pertenece a la misma Iniciativa.

## MP-016 - Conservar decisiones

Una Conversación que fundamenta una aprobación, rechazo, devolución o cancelación no puede eliminarse para sustituir lo ocurrido.

---

# 10. Permisos sobre Solicitudes

## MP-017 - Registrar Error o Mejora

El Usuario Final puede registrar una Solicitud de tipo Error o Mejora dentro de una Iniciativa en uso o evolución.

El Responsable Funcional también puede registrar estas Solicitudes dentro de la Iniciativa en la que participa.

## MP-018 - Registrar Nuevo Desarrollo

El Responsable Funcional puede registrar una Solicitud de tipo Nuevo Desarrollo.

El permiso correspondiente al Equipo TI permanece Pendiente hasta resolver su relación con los Roles de Participación aprobados.

## MP-019 - Aprobar Nuevo Desarrollo

El Responsable Funcional puede aprobar una Solicitud de tipo Nuevo Desarrollo.

El permiso correspondiente al Equipo TI permanece Pendiente.

## MP-020 - Cambiar Estado de Solicitud

Los permisos por transición de Estado de Solicitud permanecen Pendientes.

Technical Lead y Developer participan en Desarrollo; Responsable Funcional aprueba o rechaza en QAS. Estas responsabilidades deberán convertirse en una matriz de transiciones cuando el flujo completo sea aprobado.

## MP-021 - Cerrar o Cancelar una Solicitud

Los actores autorizados para Cerrar o Cancelar una Solicitud permanecen Pendientes.

---

# 11. Permisos sobre Versiones y Despliegues

## MP-022 - Registrar una Versión

El Technical Lead puede registrar una Versión de la Iniciativa.

## MP-023 - Registrar un Despliegue

DevOps puede registrar un Despliegue en el que participa.

Technical Lead puede registrar o completar el contexto técnico del Despliegue cuando corresponda.

La participación de DBA se limita a los Componentes y Recursos bajo su responsabilidad.

## MP-024 - Aprobar o rechazar en QAS

El Responsable Funcional puede aprobar o rechazar una entrega en QAS.

La decisión debe incluir observación y evidencia y generar trazabilidad.

---

# 12. Historial

## MP-025 - Generación automática

Ningún actor registra manualmente un evento para sustituir la generación automática del Historial.

El Backend genera el evento como consecuencia de una acción relevante.

## MP-026 - Inmutabilidad funcional

Ningún Participante puede modificar o eliminar un evento para reemplazar lo ocurrido.

La corrección de información debe realizarse mediante una nueva acción trazable cuando exista una capacidad aprobada.

---

# 13. Matriz Resumida

| Capacidad | Rol de Participación autorizado | Estado |
| --- | --- | --- |
| Consultar contexto de Iniciativa | Todo Participante | Definido |
| Actualizar información general | Jefe de Proyecto, Responsable Funcional | Draft |
| Incorporar Participantes | Jefe de Proyecto | Draft |
| Registrar Componente | Technical Lead | Draft |
| Registrar Recurso | Technical Lead, Jefe de Proyecto | Draft |
| Gestionar Recurso presupuestario | Gestión Financiera TI | Parcial |
| Gestionar Recurso técnico | DevOps, DBA | Parcial |
| Registrar Documento o Conversación | Todo Participante | Draft |
| Registrar Error o Mejora | Usuario Final, Responsable Funcional | Draft |
| Registrar Nuevo Desarrollo | Responsable Funcional | Parcial |
| Aprobar Nuevo Desarrollo | Responsable Funcional | Parcial |
| Aprobar o rechazar en QAS | Responsable Funcional | Definido |
| Registrar Versión | Technical Lead | Draft |
| Registrar Despliegue | DevOps, Technical Lead según responsabilidad | Draft |
| Modificar Historial | Ninguno | Definido |
| Cambiar estados, Cerrar o Cancelar | Pendiente por transición | Pendiente |

“Parcial” indica que existe una regla aprobada, pero falta resolver valores o responsabilidades relacionadas.

---

# 14. Reglas Transversales

## MP-027 - Denegación por ausencia

Una capacidad sin permiso definido debe ser denegada.

## MP-028 - Evaluación en cada acción

El Backend debe evaluar el permiso usando el contexto vigente; no debe confiar únicamente en una decisión previa del Frontend.

## MP-029 - Sin elevación implícita

Participar con varios Roles de Participación combina únicamente los permisos aprobados para esos roles.

Ningún rol adquiere permisos no documentados por conveniencia.

## MP-030 - Trazabilidad

Toda acción relevante autorizada debe conservar la identidad y el Participante responsable.

Una acción rechazada por autorización no modifica información.

## MP-031 - Separación entre Negocios

Un permiso dentro de una Iniciativa no concede acceso automático a Iniciativas de otro Negocio.

---

# 15. Trazabilidad

Este documento deriva principalmente de:

* PHIL-001: transparencia, protección, simplicidad y responsabilidad visible.
* SRS-002: actores y Lenguaje Ubicuo.
* SRS-003: Participante, Rol de Participación y RD-003 a RD-006.
* SRS-004: participación operacional de actores.
* SRS-005: Requerimientos Funcionales.
* SRS-006: RNF-001 a RNF-003 y RNF-010.

---

# 16. Pendientes

* Definir quién puede registrar una Iniciativa.
* Definir permisos por transición de Estado de Iniciativa.
* Definir permisos por transición de Estado de Solicitud.
* Definir quién puede Cerrar o Cancelar una Iniciativa o Solicitud.
* Resolver qué Roles de Participación corresponden a responsable TI y Equipo TI.
* Validar la visibilidad de Iniciativas para actores que no son Participantes.
* Definir visibilidad transversal dentro de un Negocio.
* Validar restricciones por clasificación de información.
* Definir retiro y sustitución de Participantes.
* Definir reemplazo o retiro de Documentos.
* Definir permisos técnicos y administrativos de plataforma fuera del dominio.
* Validar la matriz con todos los actores.

Los Pendientes que requieran nuevos actores, roles o conceptos deben resolverse primero mediante una revisión de SRS-002 o SRS-003.

---

# 17. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial del Modelo de Permisos de Arauco Project Hub.
