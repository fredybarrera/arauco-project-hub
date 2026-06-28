# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, SRS-001 a SRS-010, decisiones arquitectónicas principales y Arquitectura de Persistencia aprobados. Preparación de la Arquitectura de Observabilidad.

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

---

## Standards

Pendientes.

---

# Documento Actual

Arquitectura de Persistencia (Approved)

Objetivo:

Implementar ADR-006 mediante límites, flujos, mapeos, reconstrucción, consultas, transacciones, concurrencia y evolución controlada del esquema.

---

# Siguiente Objetivo

Arquitectura de Observabilidad

Objetivo:

Definir cómo Arauco Project Hub observará solicitudes, errores, rendimiento, dependencias y operaciones relevantes sin exponer información sensible ni confundir observabilidad con Historial.

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
* Observabilidad

---

# Última Decisión Importante

ADR-006 adopta Azure SQL Database y Entity Framework Core 10, mantiene la persistencia como adaptación del dominio y define concurrencia optimista y transacciones locales.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
