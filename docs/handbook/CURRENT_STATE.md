# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto y SRS-001 a SRS-010 aprobados. Arquitecturas principales, Diseño de la API y Arquitectura de Seguridad aprobados. Preparación del diseño de Autenticación.

---

# Documentos Aprobados

## SRS

* ✅ SRS-001 - Visión del Producto
* ✅ SRS-002 - Lenguaje Ubicuo
* ✅ SRS-003 - Modelo de Dominio
* ✅ SRS-004 - Modelo Operacional
* ✅ SRS-005 - Requerimientos Funcionales
* ✅ SRS-006 - Requerimientos No Funcionales
* ✅ SRS-007 - Modelo de Permisos
* ✅ SRS-008 - Flujos de Negocio
* ✅ SRS-009 - Casos de Uso
* ✅ SRS-010 - Modelo Relacional

---

## Filosofía

* ✅ PHIL-001 - Filosofía del Producto

---

## ADR

* ✅ ADR-001 - Arquitectura Basada en el Negocio
* ✅ ADR-002 - Monorepo
* ✅ ADR-003 - Frontend con Nuxt 4
* ✅ ADR-004 - Backend con .NET 10

---

## Modelo de Datos

* ✅ DER - Diagrama de Entidad-Relación
* ✅ Diccionario de Datos

---

## Arquitectura

* ✅ Visión de Arquitectura
* ✅ Módulos
* ✅ Modelo de Dominio Arquitectónico
* ✅ Arquitectura del Backend
* ✅ Arquitectura del Frontend
* ✅ Diseño de la API
* ✅ Arquitectura de Seguridad

---

## Standards

Pendientes.

---

# Documento Actual

Arquitectura de Seguridad (Approved)

Objetivo:

Definir cómo Frontend, API y Backend colaboran para autenticar identidades, autorizar capacidades, proteger información y conservar trazabilidad.

---

# Siguiente Objetivo

Autenticación

Objetivo:

Definir el contrato y flujo de autenticación entre el Frontend y la API, manteniendo separados identidad, sesión, autorización y reglas del dominio.

---

# Estado del Modelo

Aggregate Root principal:

* Iniciativa

Dominio principal aprobado.

Lenguaje Ubicuo aprobado.

Modelo de Dominio aprobado.

Modelo Operacional aprobado.

Modelo Relacional aprobado.

DER aprobado.

Diccionario de Datos aprobado.

---

# Próximos Hitos

* Autenticación
* ADR de proveedor de identidad y sesión
* Persistencia

---

# Última Decisión Importante

La Arquitectura de Seguridad separa autenticación, autorización, reglas del dominio, Historial y observabilidad, y exige autorización contextual en el Backend.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
