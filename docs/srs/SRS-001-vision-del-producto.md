# Arauco Project Hub

## Software Requirements Specification (SRS)

**Documento:** SRS-001
**Capítulo:** 1 - Visión del Producto
**Versión:** 1.0 (Approved)
**Estado:** Approved

---

# 1. Propósito

Arauco Project Hub es una plataforma corporativa diseñada para administrar el ciclo de vida completo de las iniciativas de desarrollo de software dentro de Arauco.

Su propósito es centralizar toda la información relacionada con una iniciativa, desde su concepción hasta la operación del software en producción, proporcionando trazabilidad, colaboración y visibilidad para todos los actores involucrados.

La plataforma busca eliminar la dispersión de información entre correos electrónicos, reuniones, conversaciones informales y distintas herramientas, estableciendo una única fuente de verdad para cada iniciativa.

---

# 2. Problema Actual

Actualmente el desarrollo de soluciones de software involucra múltiples equipos y diferentes canales de comunicación.

Una misma iniciativa puede comenzar en una reunión, continuar mediante correos electrónicos, conversaciones por Teams, mensajes de WhatsApp o solicitudes verbales.

Como consecuencia:

* Se pierden solicitudes.
* No existe una trazabilidad completa.
* Es difícil conocer el estado real de una iniciativa.
* Los usuarios desconocen quién está trabajando en una solicitud.
* Los equipos técnicos administran múltiples listas y correos paralelos.
* No existe una visión unificada del ciclo de vida de una solución.
* La coordinación entre áreas técnicas depende principalmente del intercambio manual de correos electrónicos.

Esta situación provoca pérdida de información, retrasos, retrabajos y baja visibilidad para todos los participantes.

---

# 3. Objetivos del Producto

Arauco Project Hub tiene como objetivo principal administrar integralmente el ciclo de vida de las iniciativas tecnológicas desarrolladas por el área de TI.

Los objetivos específicos son:

* Centralizar todas las iniciativas en una única plataforma.
* Centralizar la gestión operacional de solicitudes posteriores a la puesta en producción.
* Mantener trazabilidad completa de todas las decisiones.
* Proporcionar visibilidad permanente del estado de cada iniciativa.
* Facilitar la colaboración entre negocio y TI.
* Estandarizar el proceso de desarrollo de software.
* Reducir la dependencia de correos electrónicos para coordinar actividades.
* Mantener toda la documentación relacionada con una iniciativa en un único lugar.
* Facilitar la incorporación de nuevos integrantes al equipo mediante información centralizada.
* Servir como plataforma estándar para todos los negocios de Arauco.

---

# 4. Alcance

La plataforma administrará dos grandes dominios funcionales.

## 4.1 Gestión de Iniciativas

Corresponde a todas las actividades previas a la puesta en producción del software.

Incluye, entre otras:

* Registro de iniciativas.
* Evaluación.
* Priorización.
* Aprobaciones.
* Gestión presupuestaria.
* Centro de costo.
* Solicitud de recursos tecnológicos.
* Seguimiento de requerimientos hacia áreas transversales.
* Coordinación con DevOps.
* Coordinación con DBA.
* Seguimiento del desarrollo.
* Gestión documental.

---

## 4.2 Gestión Operacional

Una vez que la solución entra en producción, la plataforma administrará:

* Incidentes.
* Mejoras.
* Nuevos desarrollos.
* Conversaciones.
* Adjuntos.
* Versiones.
* Despliegues.
* Historial.
* SLA.
* Aprobaciones funcionales.
* Indicadores.

---

# 5. Principios de Diseño

Toda decisión funcional y técnica deberá respetar los siguientes principios.

## Simplicidad

La plataforma deberá ser sencilla de utilizar.

Los usuarios deberán poder registrar una solicitud en pocos minutos.

No se incorporarán funcionalidades que aumenten innecesariamente la complejidad.

---

## Trazabilidad

Toda acción deberá quedar registrada.

Nunca se perderá el historial de una iniciativa.

---

## Transparencia

Cada actor deberá conocer el estado real de la iniciativa.

---

## Colaboración

Toda la conversación relacionada con una iniciativa deberá mantenerse dentro de la plataforma.

---

## Estandarización

La plataforma promoverá el uso de los estándares tecnológicos definidos por el área de TI.

---

## Escalabilidad Organizacional

La solución deberá ser capaz de soportar múltiples negocios de Arauco sin modificar su arquitectura.

---

# 6. Visión de Largo Plazo

Aunque inicialmente la plataforma será utilizada por el negocio Celulosa, su arquitectura será diseñada para permitir su adopción por otros negocios de Arauco, tales como:

* Maderas.
* Forestal.
* Transversal.

Cada negocio podrá administrar sus propias iniciativas, equipos y soluciones, compartiendo la misma plataforma y el mismo estándar de desarrollo.

---

# 7. Declaración de Visión

Arauco Project Hub será la plataforma corporativa que acompañará el ciclo de vida completo de las iniciativas tecnológicas de Arauco, integrando negocio, desarrollo, infraestructura y operación en un único ecosistema colaborativo, simple, trazable y alineado con los estándares tecnológicos de la organización.
