# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, modelos, requerimientos y Modelo de Permisos aprobados. Arquitecturas principales y Diseño de la API aprobados. Preparación de los Flujos de Negocio.

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

SRS-007 - Modelo de Permisos (Approved)

Objetivo:

Definir qué actores pueden consultar o ejecutar las capacidades aprobadas dentro del contexto de una Iniciativa, aplicando transparencia, menor privilegio y responsabilidad visible.

---

# Siguiente Objetivo

SRS-008 - Flujos de Negocio

Objetivo:

Definir los recorridos funcionales de extremo a extremo mediante los cuales los actores gestionan una Iniciativa y sus Solicitudes, conservando estados, permisos y trazabilidad.

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

* Flujos de Negocio
* Casos de Uso
* Catálogo de operaciones de la API

---

# Última Decisión Importante

SRS-007 define el Modelo de Permisos contextual por Iniciativa, asigna 31 reglas de permiso y mantiene denegadas las capacidades cuya autoridad aún no ha sido aprobada.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
