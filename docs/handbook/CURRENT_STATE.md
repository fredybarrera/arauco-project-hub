# CURRENT STATE

## Estado Actual del Proyecto

**Proyecto:** Arauco Project Hub

**Fase actual:** Fase 2 - Architecture (En progreso)

**Estado general:** Filosofía del Producto, Modelo de Dominio, Modelo Operacional, arquitectura basada en el Negocio, organización en monorepo, Modelo Relacional, DER y Diccionario de Datos aprobados. Preparación de ADR-003.

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

---

## Modelo de Datos

* ✅ DER - Diagrama de Entidad-Relación
* ✅ Diccionario de Datos

---

## Standards

Pendientes.

---

# Documento Actual

ADR-002 - Monorepo (Approved)

Objetivo:

Evaluar y documentar cómo organizar el código fuente de Arauco Project Hub, preservando el Lenguaje Ubicuo, la cohesión del producto y la separación entre el dominio y los detalles tecnológicos.

---

# Siguiente Objetivo

ADR-003 - Frontend con Nuxt 4

Objetivo:

Evaluar y documentar la tecnología principal del Frontend, verificando que permita expresar el Lenguaje Ubicuo, representar el ciclo de vida de la Iniciativa y mantener separados el dominio y los detalles del framework.

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

Arauco Project Hub se organiza en un monorepo que mantiene juntos el Engineering Playbook y los componentes del producto, conservando límites y ciclos de validación y despliegue independientes.

---

# Cómo continuar el proyecto

Antes de comenzar una nueva sesión:

1. Leer BOOTSTRAP.md
2. Leer CURRENT_STATE.md
3. Revisar el último documento aprobado.
4. Continuar desde el siguiente documento pendiente.

Este archivo debe mantenerse actualizado durante toda la vida del proyecto.
