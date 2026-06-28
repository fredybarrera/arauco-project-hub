# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, Modelo de Dominio, Modelo Operacional, arquitectura basada en el Negocio, organización en monorepo, tecnologías principales, Visión de Arquitectura y Módulos aprobados. Preparación del Modelo de Dominio Arquitectónico.

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

---

## Standards

Pendientes.

---

# Documento Actual

Módulos (Approved)

Objetivo:

Definir los módulos y sus responsabilidades a partir del dominio aprobado, manteniendo a la Iniciativa como centro y evitando fragmentar el producto según entidades o tecnologías.

---

# Siguiente Objetivo

Modelo de Dominio Arquitectónico

Objetivo:

Definir cómo se expresa el Modelo de Dominio aprobado dentro del módulo Iniciativas, preservando Aggregate Root, entidades, Objetos de Valor, reglas y eventos sin acoplarlos al framework o la persistencia.

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

Arauco Project Hub inicia con un único módulo de dominio denominado Iniciativas; sus entidades relacionadas permanecen dentro del contexto de la Iniciativa y no se convierten automáticamente en módulos independientes.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
