# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, modelos aprobados y arquitectura basada en el Negocio consolidados. Arquitecturas del Backend y del Frontend y Diseño de la API aprobados. Preparación de los Requerimientos Funcionales.

---

# Documentos Aprobados

## SRS

* ✅ SRS-001 - Visión del Producto
* ✅ SRS-002 - Lenguaje Ubicuo
* ✅ SRS-003 - Modelo de Dominio
* ✅ SRS-004 - Modelo Operacional
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

---

## Standards

Pendientes.

---

# Documento Actual

Diseño de la API (Approved)

Objetivo:

Definir cómo el Frontend y otros consumidores utilizan las capacidades del Backend mediante contratos explícitos sin exponer el Modelo de Dominio ni la persistencia.

---

# Siguiente Objetivo

SRS-005 - Requerimientos Funcionales

Objetivo:

Definir las capacidades funcionales de Arauco Project Hub derivadas del Modelo de Dominio y del Modelo Operacional, con criterios verificables y trazabilidad hacia las necesidades del Negocio.

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

* Requerimientos Funcionales
* Catálogo de operaciones de la API
* Persistencia

---

# Última Decisión Importante

El Diseño de la API organiza contratos y operaciones alrededor de la Iniciativa, separa la validación de forma de las reglas del dominio y prohíbe incorporar operaciones sin requerimientos aprobados.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
