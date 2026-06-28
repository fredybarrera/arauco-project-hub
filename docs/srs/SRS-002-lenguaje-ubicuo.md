# Arauco Project Hub

# Software Requirements Specification

## SRS-002

# Lenguaje Ubicuo

**Versión:** 1.0

**Estado:** Approved

---

# 1. Objetivo

Este documento define el lenguaje oficial utilizado por Arauco Project Hub.

Su propósito es asegurar que todas las personas involucradas en el desarrollo, operación y evolución de la plataforma utilicen la misma terminología para representar los conceptos del negocio.

Este lenguaje deberá utilizarse en:

* Documentación.
* Base de datos.
* Código fuente.
* API.
* Interfaces de usuario.
* Conversaciones técnicas.
* Manuales.
* Casos de uso.

---

# 2. Principios

Todo concepto definido en este documento deberá cumplir los siguientes principios:

* Tener un único significado.
* Ser independiente de la tecnología utilizada.
* Representar el lenguaje del negocio.
* Mantenerse estable en el tiempo.
* Evitar sinónimos para un mismo concepto.

---

# 3. Conceptos del Dominio

## Negocio

Unidad organizacional de Arauco para la cual se desarrollan soluciones tecnológicas.

Ejemplos:

* Celulosa
* Maderas
* Forestal
* Transversal

---

## Iniciativa

Unidad principal del sistema.

Representa una necesidad de negocio o tecnológica cuyo objetivo es generar valor mediante el desarrollo o evolución de una solución informática.

Una iniciativa comienza con una idea y finaliza cuando la solución se encuentra operando y mantenida dentro de la organización.

Toda la información del sistema gira alrededor de una iniciativa.

---

## Solución

Resultado implementado de una iniciativa.

Una solución puede estar compuesta por uno o más componentes tecnológicos.

Ejemplos:

* Aplicación Web
* API
* Servicio
* Base de Datos
* Integración
* Proceso Batch

---

## Componente

Elemento técnico que forma parte de una solución.

Ejemplos:

* Frontend
* Backend
* Base de Datos
* Azure Container App
* Azure Static Web App
* Azure SQL Database
* Storage Account

---

## Solicitud

Requerimiento realizado sobre una solución que ya se encuentra en operación.

Las solicitudes pueden corresponder a:

* Error
* Mejora
* Nuevo Desarrollo

---

## Conversación

Registro cronológico de toda interacción relacionada con una iniciativa o una solicitud.

Toda decisión relevante deberá quedar registrada mediante conversaciones.

---

# 4. Actores

## Business Expert

Responsable estratégico de las iniciativas dentro del negocio.

---

## Jefe de Proyecto

Responsable de coordinar y supervisar la ejecución de una iniciativa.

---

## Technical Lead

Responsable técnico de la solución.

---

## Developer

Integrante encargado de implementar técnicamente la solución.

---

## Responsable Funcional

Representante del negocio que valida las necesidades funcionales y aprueba las entregas.

---

## Usuario Final

Persona que utiliza la solución en su operación diaria.

---

## Gestión Financiera TI

Área responsable de validar y aprobar la valorización económica de los recursos tecnológicos necesarios para una iniciativa.

---

## DevOps

Equipo responsable de habilitar la infraestructura tecnológica requerida por una iniciativa.

---

## DBA

Equipo responsable de administrar las bases de datos requeridas por una iniciativa.

---

# 5. Relaciones Fundamentales

Una Iniciativa pertenece a un Negocio.

Una Iniciativa genera una Solución.

Una Solución está compuesta por Componentes.

Una Solución recibe Solicitudes.

Las Solicitudes generan Conversaciones.

Todos los actores interactúan sobre una Iniciativa durante su ciclo de vida.

---

# 6. Términos Prohibidos

Con el objetivo de mantener consistencia, los siguientes términos no deberán utilizarse dentro del proyecto cuando exista un término oficial equivalente.

| Evitar   | Utilizar                      |
| -------- | ----------------------------- |
| Proyecto | Iniciativa                    |
| Chat     | Conversación                  |
| Cliente  | Responsable Funcional         |
| Sistema  | Solución (cuando corresponda) |
| Issue    | Solicitud                     |

---

# 7. Evolución del Lenguaje

Todo nuevo concepto incorporado al dominio deberá ser documentado previamente en este documento antes de ser implementado en el sistema.
