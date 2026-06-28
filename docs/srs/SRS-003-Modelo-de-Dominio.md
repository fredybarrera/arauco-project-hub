# Arauco Project Hub

## Software Requirements Specification

# SRS-003 - Modelo de Dominio

**Versión:** 1.0
**Estado:** Approved
**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define el modelo de dominio inicial de Arauco Project Hub.

Su propósito es representar cómo nacen, evolucionan y se mantienen las iniciativas tecnológicas dentro de Arauco, antes de definir base de datos, API, pantallas o infraestructura.

El modelo de dominio deberá ser la base para las futuras decisiones técnicas del sistema.

---

# 2. Principios del Dominio

El modelo de dominio se regirá por los siguientes principios:

* El dominio representa el negocio, no la tecnología.
* El lenguaje utilizado corresponde al Lenguaje Ubicuo definido en SRS-002.
* Toda entidad debe existir porque representa un concepto real del negocio.
* La simplicidad tendrá prioridad sobre la flexibilidad innecesaria.
* La Iniciativa será el centro del modelo.
* La base de datos, la API y la interfaz deberán derivarse del dominio, no al revés.
* El modelo deberá permitir escalar desde Celulosa hacia otros negocios de Arauco sin rediseñar la solución.

---

# 3. Aggregate Root Principal

## 3.1 Iniciativa

La Iniciativa es la unidad principal del sistema.

Representa una necesidad del negocio o del área de TI cuyo propósito es generar valor mediante el desarrollo, evolución o mejora de una solución tecnológica.

Toda actividad registrada dentro de Arauco Project Hub pertenece a una Iniciativa.

Una Iniciativa acompaña todo el ciclo de vida de una solución, desde su concepción inicial hasta su operación, mantenimiento y evolución.

La Iniciativa no desaparece cuando el software llega a producción. En cambio, madura hacia una etapa operacional donde pueden generarse nuevas Solicitudes, mejoras, incidentes o nuevos desarrollos asociados.

---

# 4. Entidades Principales del Dominio

## 4.1 Negocio

Representa una unidad organizacional de Arauco.

Ejemplos:

* Celulosa
* Maderas
* Forestal
* Transversal

Una Iniciativa siempre pertenece a un Negocio.

---

## 4.2 Iniciativa

Entidad central del dominio.

Contiene la información principal del ciclo de vida de una necesidad tecnológica.

Una Iniciativa puede tener:

* Información general.
* Objetivo.
* Justificación.
* Beneficio esperado.
* Negocio asociado.
* Participantes.
* Componentes.
* Recursos requeridos.
* Documentación.
* Conversaciones.
* Solicitudes.
* Versiones.
* Despliegues.
* Historial.

---

## 4.3 Participante

Representa a una persona o equipo que participa en una Iniciativa con una responsabilidad determinada.

Ejemplos de participantes:

* Business Expert.
* Jefe de Proyecto.
* Technical Lead.
* Developer.
* Responsable Funcional.
* Usuario Final.
* Gestión Financiera TI.
* DevOps.
* DBA.

Una misma persona puede participar en distintas Iniciativas con roles diferentes.

---

## 4.4 Componente

Representa un elemento técnico que forma parte de una Iniciativa.

Ejemplos:

* Frontend.
* Backend.
* API.
* Base de Datos.
* Azure Static Web App.
* Azure Container App.
* Storage Account.
* Repositorio.
* Pipeline.
* App Registration.

La Iniciativa puede tener uno o varios Componentes.

---

## 4.5 Recurso

Representa un recurso técnico o presupuestario requerido para ejecutar una Iniciativa.

Ejemplos:

* Base de datos QAS.
* Base de datos PRD.
* Container App.
* Static Web App.
* Storage Account.
* App Registration.
* Repositorio GitHub.
* Pipeline.
* Centro de costo.
* Valorización de recursos.

Los recursos pueden requerir revisión, valorización o aprobación por parte de áreas transversales.

---

## 4.6 Solicitud

Representa una necesidad operacional asociada a una Iniciativa que ya se encuentra en uso o evolución.

Las Solicitudes pueden ser de tres tipos:

* Error en algún sistema.
* Mejora de una funcionalidad.
* Nuevo desarrollo.

Una Solicitud pertenece siempre a una Iniciativa.

---

## 4.7 Conversación

Representa el historial colaborativo asociado a una Iniciativa o Solicitud.

La Conversación permite registrar:

* Comentarios.
* Decisiones.
* Observaciones.
* Rechazos.
* Aprobaciones.
* Coordinaciones.
* Adjuntos.

La Conversación reemplaza el concepto informal de chat y debe funcionar como memoria trazable.

---

## 4.8 Documento

Representa un archivo, enlace o referencia documental asociado a una Iniciativa.

Ejemplos:

* Documento funcional.
* Documento técnico.
* Cotización.
* Aprobación presupuestaria.
* Evidencia.
* Manual.
* Arquitectura.
* Minuta.
* Documento de estándar.

---

## 4.9 Ambiente

Representa un entorno donde se desarrolla, prueba o ejecuta una solución.

Ambientes iniciales:

* Desarrollo.
* QAS.
* PRD.

Una Iniciativa puede requerir uno o más ambientes.

---

## 4.10 Versión

Representa una entrega identificable de una Iniciativa.

Una Versión permite registrar qué cambio fue liberado, cuándo fue liberado y bajo qué contexto.

---

## 4.11 Despliegue

Representa la acción de publicar una Versión en un Ambiente.

Un Despliegue puede estar asociado a:

* Ambiente.
* Fecha.
* Responsable.
* Versión.
* Resultado.
* Observaciones.
* Evidencia.
* Pipeline utilizado.

---

## 4.12 Historial

Representa el registro cronológico de eventos relevantes ocurridos dentro de una Iniciativa.

Ejemplos:

* Creación de la Iniciativa.
* Cambio de estado.
* Asignación de responsable.
* Aprobación presupuestaria.
* Cambio de etapa.
* Registro de componente.
* Creación de solicitud.
* Aprobación en QAS.
* Paso a PRD.

El Historial debe ser automático, no depender únicamente de comentarios manuales.

---

# 5. Objetos de Valor

## 5.1 Rol de Participación

Define la responsabilidad que cumple un Participante dentro de una Iniciativa.

Valores iniciales:

* Business Expert.
* Jefe de Proyecto.
* Technical Lead.
* Developer.
* Responsable Funcional.
* Usuario Final.
* Gestión Financiera TI.
* DevOps.
* DBA.

---

## 5.2 Estado de Iniciativa

Representa la etapa actual de una Iniciativa dentro de su ciclo de vida.

Estados iniciales sugeridos:

* Idea.
* Evaluación.
* Aprobada.
* Preparación.
* Desarrollo.
* QAS.
* Producción.
* Operación.
* Cerrada.
* Cancelada.

---

## 5.3 Tipo de Solicitud

Define la naturaleza de una Solicitud operacional.

Valores permitidos:

* Error.
* Mejora.
* Nuevo Desarrollo.

---

## 5.4 Prioridad

Define la urgencia relativa de una Solicitud.

Valores permitidos:

* Baja.
* Media.
* Alta.

---

## 5.5 Estado de Solicitud

Define el flujo simple de una Solicitud.

Estados permitidos:

* Creada.
* Asignada.
* En Desarrollo.
* En QAS.
* Rechazada en QAS.
* Aprobada.
* En Producción.
* Cerrada.
* Cancelada.

---

## 5.6 Tipo de Componente

Define la naturaleza técnica de un Componente.

Ejemplos:

* Frontend.
* Backend.
* API.
* Base de Datos.
* Repositorio.
* Pipeline.
* Storage.
* Azure Function.
* Container App.
* Static Web App.

---

## 5.7 Ambiente

Valores iniciales:

* Desarrollo.
* QAS.
* PRD.

---

# 6. Relaciones Fundamentales

Las relaciones principales del dominio son:

* Un Negocio tiene muchas Iniciativas.
* Una Iniciativa pertenece a un Negocio.
* Una Iniciativa tiene muchos Participantes.
* Un Participante cumple un Rol de Participación dentro de una Iniciativa.
* Una Iniciativa tiene muchos Componentes.
* Una Iniciativa puede requerir muchos Recursos.
* Una Iniciativa tiene muchos Documentos.
* Una Iniciativa tiene muchas Conversaciones.
* Una Iniciativa tiene muchas Solicitudes.
* Una Solicitud tiene Conversaciones.
* Una Iniciativa puede tener muchas Versiones.
* Una Versión puede tener muchos Despliegues.
* Un Despliegue ocurre sobre un Ambiente.
* Una Iniciativa tiene un Historial.
* Una Solicitud genera eventos en el Historial.

---

# 7. Ciclo de Vida de una Iniciativa

Una Iniciativa no debe entenderse como un proyecto cerrado, sino como una unidad viva que madura con el tiempo.

Ciclo inicial:

```text
Idea
  ↓
Evaluación
  ↓
Aprobada
  ↓
Preparación
  ↓
Desarrollo
  ↓
QAS
  ↓
Producción
  ↓
Operación
  ↓
Evolución
```

Durante la etapa de Operación pueden generarse nuevas Solicitudes, mejoras o nuevos desarrollos.

---

# 8. Reglas del Dominio

## RD-001

Toda Solicitud debe pertenecer a una Iniciativa.

---

## RD-002

Toda Iniciativa debe pertenecer a un Negocio.

---

## RD-003

Toda Iniciativa debe tener al menos un Responsable Funcional.

---

## RD-004

Toda Iniciativa debe tener al menos un responsable TI.

---

## RD-005

Una Solicitud de tipo Nuevo Desarrollo solo puede ser creada o aprobada por un Responsable Funcional o por el Equipo TI.

---

## RD-006

Un Usuario Final puede crear Solicitudes de tipo Error o Mejora.

---

## RD-007

Toda aprobación o rechazo en QAS debe quedar registrada con observación.

---

## RD-008

Toda acción relevante debe generar un evento en el Historial.

---

## RD-009

Las Solicitudes no deben existir fuera del contexto de una Iniciativa.

---

## RD-010

El modelo debe permitir que una misma plataforma soporte múltiples Negocios sin mezclar información operacional.

---

# 9. Implicancias Técnicas

A partir de este modelo se derivan las siguientes decisiones técnicas iniciales:

* La entidad principal del backend será Iniciativa.
* La base de datos deberá reflejar la relación entre Negocio, Iniciativa, Participantes, Solicitudes y Componentes.
* La API deberá organizarse alrededor del ciclo de vida de la Iniciativa.
* Las pantallas principales deberán partir desde la vista de Iniciativas.
* Las Solicitudes serán una capacidad operacional asociada a una Iniciativa, no el centro del sistema.
* El Historial deberá implementarse como una bitácora automática de eventos.
* La Conversación deberá ser trazable y persistente.
* Los estados y tipos principales serán controlados por el dominio, no por configuración libre del usuario.

---

# 10. Decisiones Tomadas

## D-001

La Iniciativa es el Aggregate Root principal del dominio.

---

## D-002

La Iniciativa no termina al llegar a producción; madura hacia operación.

---

## D-003

Las Solicitudes pertenecen a una Iniciativa y no existen de forma aislada.

---

## D-004

Se utiliza Participante en lugar de Usuario dentro del contexto de una Iniciativa.

---

## D-005

Se modelan Componentes directamente dentro de la Iniciativa, evitando una entidad intermedia llamada Solución en esta etapa.

---

# 11. Pendientes

* Validar si "Solución" debe mantenerse como concepto documental o descartarse del modelo.
* Definir atributos específicos de cada entidad.
* Definir eventos del dominio.
* Definir modelo de datos relacional.
* Definir casos de uso asociados al ciclo de vida de la Iniciativa.
* Definir permisos específicos por rol de participación.

---

# 12. Estado del Documento

**Estado actual:** Approved
