# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, modelos de Dominio, Operacional y Relacional, decisiones tecnológicas, Visión de Arquitectura, Módulos y Modelo de Dominio Arquitectónico aprobados. Preparación de la Arquitectura del Backend.

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

---

## Standards

Pendientes.

---

# Documento Actual

Modelo de Dominio Arquitectónico (Approved)

Objetivo:

Definir cómo se expresa el Modelo de Dominio aprobado dentro del módulo Iniciativas, preservando Aggregate Root, entidades, Objetos de Valor, reglas y eventos sin acoplarlos al framework o la persistencia.

---

# Siguiente Objetivo

Arquitectura del Backend

Objetivo:

Definir cómo el Backend con .NET 10 coordina la API, las capacidades del módulo Iniciativas, el Modelo de Dominio, la persistencia y las integraciones manteniendo dependencias explícitas.

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

* Arquitectura
* Backend
* Frontend

---

# Última Decisión Importante

El Modelo de Dominio Arquitectónico mantiene a la Iniciativa como Aggregate Root principal, protege las reglas mediante comportamiento explícito y conserva el dominio independiente de frameworks y persistencia.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
