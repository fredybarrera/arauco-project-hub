# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, SRS-001 a SRS-010, arquitecturas principales y decisiones tecnológicas de persistencia y observabilidad aprobados. Revisión de cierre de Architecture.

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
* ✅ ADR-005 - Proveedor de Identidad y Estrategia de Sesión
* ✅ ADR-006 - Tecnología y Estrategia de Persistencia
* ✅ ADR-007 - Plataforma y Estándar de Observabilidad

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
* ✅ Autenticación
* ✅ Arquitectura de Persistencia
* ✅ Arquitectura de Observabilidad

---

## Standards

Pendientes.

---

# Documento Actual

ADR-007 - Plataforma y Estándar de Observabilidad (Approved)

Objetivo:

Utilizar Azure Monitor Application Insights, OpenTelemetry y W3C Trace Context, con una estrategia explícita y aislada para la instrumentación del navegador.

---

# Siguiente Objetivo

EST-001 - Estándar Tecnológico

Objetivo:

Consolidar las tecnologías y versiones aprobadas, sus condiciones de uso y sus límites, después de verificar el cierre de la Fase 2 - Architecture.

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

* ADR-006 - Tecnología y Estrategia de Persistencia
* Arquitectura de Persistencia
* Arquitectura de Observabilidad
* ADR-007 - Plataforma y Estándar de Observabilidad
* EST-001 - Estándar Tecnológico

---

# Última Decisión Importante

ADR-007 adopta Azure Monitor Application Insights, OpenTelemetry y W3C Trace Context, y mantiene una instrumentación específica y aislada para el navegador.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
