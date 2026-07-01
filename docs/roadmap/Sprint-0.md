# Arauco Project Hub

## Engineering Playbook

# Sprint 0 - Primera Capacidad Trazable

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Objetivo

Preparar una entrega vertical mínima para que un Participante autenticado consulte la información general y el Estado de Iniciativa de una Iniciativa en la que participa.

La capacidad seleccionada es CU-002 - Consultar una Iniciativa.

---

# 2. Justificación

CU-002 puede implementarse sin resolver decisiones funcionales Pendientes:

* El actor principal es Participante.
* MP-001 autoriza la consulta dentro de la Iniciativa.
* RF-002 y RF-003 definen la información mínima.
* FN-002 define el flujo de consulta.
* La capacidad no modifica el dominio.

CU-001 - Registrar una Iniciativa no se incorpora porque el actor autorizado permanece Pendiente en MP-005.

---

# 3. Alcance

La entrega debe incluir:

* Autenticación del actor mediante la estrategia aprobada en ADR-009.
* Resolución de la identidad corporativa y su relación con el Participante.
* Consulta de una Iniciativa por identificador.
* Verificación de participación antes de exponer información.
* Presentación de Negocio, nombre y Estado de Iniciativa vigente.
* Respuesta explícita para Iniciativa inexistente.
* Respuesta sin información de la Iniciativa cuando el acceso no está permitido.
* Persistencia mínima necesaria para ejecutar y probar la consulta.
* Pruebas del dominio, Backend, API y Frontend correspondientes a la capacidad.
* Observabilidad técnica conforme a la arquitectura aprobada.

---

# 4. Fuera de Alcance

Esta entrega no incluye:

* Registrar una Iniciativa.
* Consultar Iniciativas en las que el actor no participa.
* Actualizar información general.
* Incorporar o retirar Participantes.
* Consultar todas las responsabilidades relacionadas.
* Filtros, búsqueda o paginación.
* Cambios de Estado de Iniciativa.
* Nuevos conceptos, Roles de Participación o valores gobernados.

---

# 5. Recorrido Vertical

1. El actor inicia sesión mediante Microsoft Entra ID.
2. El Frontend obtiene un access token para la API.
3. El actor solicita consultar una Iniciativa.
4. La API valida el token y obtiene la identidad corporativa.
5. El Backend verifica que la identidad corresponde a un Participante de la Iniciativa.
6. La persistencia recupera únicamente la información requerida.
7. El Frontend presenta Negocio, nombre y Estado de Iniciativa.

---

# 6. Contrato Mínimo por Definir

El contrato de la capacidad debe documentar antes de implementarse:

* Ruta y método.
* Identificador opaco de la Iniciativa.
* Representación de Negocio, nombre y Estado de Iniciativa.
* Respuesta para información no encontrada.
* Respuesta para acción no permitida.
* Identificador de correlación.

La forma definitiva debe respetar el Diseño de la API aprobado y no exponer entidades del dominio ni estructuras de persistencia.

---

# 7. Criterios de Aceptación

La capacidad estará completa cuando:

* Un Participante autenticado pueda consultar una Iniciativa en la que participa.
* La respuesta permita reconocer Negocio, nombre y Estado de Iniciativa vigente.
* Un actor sin participación no reciba información de la Iniciativa.
* Una Iniciativa inexistente produzca una respuesta explícita.
* La identidad no provenga de datos libres enviados por el consumidor.
* La API valide firma, emisor, audiencia y vigencia del token.
* Frontend, API, Backend, dominio y persistencia mantengan sus límites aprobados.
* Las pruebas automatizadas cubran el recorrido exitoso y sus alternativas.
* Los registros técnicos no expongan tokens ni información sensible.

---

# 8. Trazabilidad

Esta entrega deriva de:

* SRS-005: RF-002 y RF-003.
* SRS-007: MP-001 y MP-004.
* SRS-008: FN-002.
* SRS-009: CU-002.
* ADR-003 - Frontend con Nuxt 4.
* ADR-004 - Backend con .NET 10.
* ADR-006 - Tecnología y Estrategia de Persistencia.
* ADR-007 - Plataforma y Estándar de Observabilidad.
* ADR-008 - Plataforma y Estrategia de Despliegue.
* ADR-009 - Autenticación y Sesión para Frontend Estático.
* Diseño de la API.
* Arquitectura del Frontend.
* Arquitectura del Backend.
* Arquitectura de Persistencia.
* Arquitectura de Seguridad.
* EST-001 a EST-005.

---

# 9. Preparación de la Implementación

Antes de implementar esta entrega se debe:

* Confirmar el contrato mínimo de la API.
* Confirmar cómo disponer datos controlados sin incorporar el registro de Iniciativas.
* Confirmar la relación inicial entre identidad corporativa y Participante.
* Descomponer la entrega en cambios pequeños y verificables.
* Validar el alcance con el Technical Lead y el equipo de Desarrollo.

---

# 10. Siguiente Paso

Preparar Sprint 1 con los cambios pequeños y verificables necesarios para implementar CU-002.

---

# 11. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para el alcance de la primera capacidad trazable de implementación.
