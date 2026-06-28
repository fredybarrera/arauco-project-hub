# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, Modelo de Dominio, Modelo Operacional, arquitectura basada en el Negocio, organización en monorepo, Frontend con Nuxt 4, Backend con .NET 10, Modelo Relacional, DER y Diccionario de Datos aprobados. Preparación de la Visión de Arquitectura.

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

## Standards

Pendientes.

---

# Documento Actual

ADR-004 - Backend con .NET 10 (Approved)

Objetivo:

Evaluar y documentar la tecnología principal del Backend, verificando que permita expresar el Modelo de Dominio, proteger las reglas de la Iniciativa y mantener separados el dominio y los detalles del framework.

---

# Siguiente Objetivo

Visión de Arquitectura

Objetivo:

Consolidar la vista de alto nivel de Arauco Project Hub, mostrando cómo el Frontend, la API, el Backend, el dominio, la persistencia y las integraciones colaboran sin contradecir los documentos aprobados.

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

El Backend se implementa con .NET 10, C# y ASP.NET Core 10, manteniendo las reglas del dominio separadas de la API, la persistencia y las integraciones.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
