# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 3 - Standards (Completada)

**Estado general:** Fase 2 - Architecture y Fase 3 - Standards completadas. Filosofía del Producto, SRS-001 a SRS-010, arquitecturas principales, decisiones tecnológicas y EST-001 a EST-005 aprobados. Preparación de la primera implementación trazable.

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
* ✅ ADR-008 - Plataforma y Estrategia de Despliegue
* ✅ ADR-009 - Autenticación y Sesión para Frontend Estático
* ✅ ADR-010 - Relación entre Identidad Corporativa y Participante

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

* ✅ EST-001 - Estándar Tecnológico
* ✅ EST-002 - Estándar Azure
* ✅ EST-003 - Convención de Repositorios
* ✅ EST-004 - Convención de Nombres
* ✅ EST-005 - CI/CD

---

## Roadmap

* ✅ Sprint 0 - Primera Capacidad Trazable
* ✅ Sprint 1 - Implementación de CU-002

---

# Documento Actual

ADR-010 - Relación entre Identidad Corporativa y Participante (Approved)

Objetivo alcanzado:

Se aprobó representar tenant y object identifier como datos técnicos opcionales y conjuntos de Participante, con unicidad dentro de una Iniciativa.

---

# Siguiente Objetivo

Preparar la revisión 1.1 de SRS-010 - Modelo Relacional.

Objetivo:

Incorporar los datos y restricciones aprobados en ADR-010 antes de actualizar DER y Diccionario de Datos.

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
* EST-002 - Estándar Azure
* EST-003 - Convención de Repositorios
* EST-004 - Convención de Nombres
* EST-005 - CI/CD
* ADR-008 - Plataforma y Estrategia de Despliegue
* ADR-009 - Autenticación y Sesión para Frontend Estático
* Sprint 0 - Primera Capacidad Trazable
* Sprint 1 - Implementación de CU-002
* ADR-010 - Relación entre Identidad Corporativa y Participante

---

# Última Decisión Importante

ADR-010 relaciona la identidad corporativa con Participante mediante tenant y object identifier, sin reutilizar correo, nombre ni Identificación de la persona o equipo.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
