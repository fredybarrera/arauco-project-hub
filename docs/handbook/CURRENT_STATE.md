# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 4 - Implementación

**Estado general:** Fase 2 - Architecture y Fase 3 - Standards completadas. Sprint 1 versión 1.1 aprobado. Inicio de la implementación trazable de CU-002.

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
* ✅ SRS-010 - Modelo Relacional (versión 1.1)

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
* ✅ ADR-011 - Estructura Física de Frontend y Backend
* ✅ ADR-012 - Esquema Físico Mínimo para CU-002

---

## Modelo de Datos

* ✅ DER - Diagrama de Entidad-Relación (versión 1.1)
* ✅ Diccionario de Datos (versión 1.1)

---

## Arquitectura

* ✅ Visión de Arquitectura
* ✅ Módulos
* ✅ Modelo de Dominio Arquitectónico
* ✅ Arquitectura del Backend
* ✅ Arquitectura del Frontend
* ✅ Diseño de la API (versión 1.1)
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
* ✅ Sprint 1 - Implementación de CU-002 (versión 1.1)

---

# Documento Actual

Persistencia Mínima de CU-002 (Approved)

Objetivo:

Contexto de Entity Framework Core, migración inicial y pruebas del esquema físico aprobados.

---

# Siguiente Objetivo

Implementar el Backend de CU-002.

Objetivo:

Definir la consulta en la coordinación de capacidades, proyectar únicamente la información aprobada y verificar la participación dentro de la Iniciativa.

---

# Estado del Modelo

Aggregate Root principal:

* Iniciativa

Dominio principal aprobado.

Lenguaje Ubicuo aprobado.

Modelo de Dominio aprobado.

Modelo Operacional aprobado.

Modelo Relacional versión 1.1 aprobado.

DER versión 1.1 aprobado.

Diccionario de Datos versión 1.1 aprobado.

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
* SRS-010 - Modelo Relacional, versión 1.1
* DER - Diagrama de Entidad-Relación, versión 1.1
* Diccionario de Datos, versión 1.1
* Diseño de la API, versión 1.1
* Sprint 1 - Implementación de CU-002, versión 1.1
* ADR-011 - Estructura Física de Frontend y Backend
* ADR-012 - Esquema Físico Mínimo para CU-002
* Persistencia Mínima de CU-002

---

# Última Decisión Importante

La Persistencia Mínima de CU-002 materializa ADR-012 mediante Entity Framework Core 10, una migración inicial sin datos semilla y pruebas del esquema físico.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
