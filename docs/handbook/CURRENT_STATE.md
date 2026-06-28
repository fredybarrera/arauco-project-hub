# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, modelos aprobados y arquitectura basada en el Negocio consolidados. Arquitecturas del Backend y del Frontend aprobadas. Preparación del Diseño de la API.

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

---

## Standards

Pendientes.

---

# Documento Actual

Arquitectura del Frontend (Approved)

Objetivo:

Definir cómo el Frontend con Nuxt 4 organiza navegación, presentación, comunicación con la API y estado de interfaz sin duplicar reglas del dominio.

---

# Siguiente Objetivo

Diseño de la API

Objetivo:

Definir los contratos, recursos, operaciones, respuestas y errores mediante los cuales el Frontend y otros consumidores utilizan las capacidades del Backend sin exponer el Modelo de Dominio ni la persistencia.

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

* Diseño de la API
* Persistencia
* Seguridad

---

# Última Decisión Importante

La Arquitectura del Frontend separa navegación y páginas, presentación, coordinación de capacidades, estado de interfaz y comunicación con la API, manteniendo a la Iniciativa como centro del contexto presentado.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
