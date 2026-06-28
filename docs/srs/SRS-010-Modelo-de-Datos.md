# Arauco Project Hub

## Software Requirements Specification

# SRS-010 - Modelo Relacional

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define el Modelo Relacional inicial de Arauco Project Hub.

Su propósito es representar mediante estructuras relacionales el Modelo de Dominio y el Modelo Operacional aprobados, preservando sus relaciones, reglas y trazabilidad.

El Modelo Relacional deriva del dominio. No reemplaza al Modelo de Dominio ni se convierte en la fuente de definición de sus conceptos.

---

# 2. Alcance

Este documento establece:

* Las estructuras relacionales necesarias para persistir las entidades y los Objetos de Valor aprobados.
* Las claves primarias y relaciones entre estructuras.
* Las restricciones que pueden protegerse mediante integridad relacional.
* Los datos mínimos necesarios para conservar trazabilidad.
* La correspondencia entre el Modelo de Dominio y el Modelo Relacional.

Quedan fuera del alcance:

* La selección de un motor de base de datos.
* La definición de tipos de datos específicos de una tecnología.
* La estrategia de acceso a datos del Backend.
* La definición de API, pantallas o formularios.
* La optimización física, índices y particionamiento.
* Los permisos de acceso a la información.
* La retención y eliminación de información.

---

# 3. Principios

El Modelo Relacional se rige por los siguientes principios:

* La Iniciativa mantiene su responsabilidad como Aggregate Root principal.
* Los nombres utilizan el Lenguaje Ubicuo definido en SRS-002.
* Cada dato tiene una única estructura como fuente oficial.
* Las relaciones aprobadas se protegen mediante integridad referencial cuando corresponde.
* Las reglas del dominio no se reducen a restricciones de persistencia.
* Las estructuras técnicas no introducen conceptos nuevos al dominio.
* La trazabilidad se conserva durante todo el ciclo de vida de la Iniciativa.
* La simplicidad prevalece sobre la generalización no justificada.
* El modelo común permite representar Iniciativas de múltiples Negocios sin duplicar estructuras.

---

# 4. Convenciones del Modelo Relacional

Cada estructura principal utiliza un identificador interno como clave primaria.

Las relaciones obligatorias se representan mediante claves foráneas no nulas. Las relaciones opcionales permiten ausencia de referencia solo cuando el dominio aprobado lo admite.

Los nombres físicos definitivos y los tipos de datos específicos se establecerán cuando se seleccione la tecnología de persistencia. Hasta entonces, este documento utiliza los nombres del Lenguaje Ubicuo.

Las estructuras pueden incorporar datos técnicos de creación y modificación para apoyar la trazabilidad, sin reemplazar el Historial ni las Conversaciones.

---

# 5. Estructuras Relacionales

## 5.1 Negocio

Representa la unidad organizacional a la que pertenece una Iniciativa.

Datos mínimos:

* Identificador.
* Nombre.

Relaciones:

* Un Negocio tiene muchas Iniciativas.

Restricciones:

* El Nombre de Negocio es obligatorio.
* Un Negocio no se duplica por cada Iniciativa.

---

## 5.2 Iniciativa

Representa el Aggregate Root principal.

Datos mínimos:

* Identificador.
* Negocio.
* Nombre.
* Objetivo.
* Justificación.
* Beneficio esperado.
* Estado de Iniciativa.
* Fecha de creación.

Relaciones:

* Pertenece a un Negocio.
* Tiene Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones y eventos del Historial.
* Puede requerir uno o más Ambientes.

Restricciones:

* Toda Iniciativa pertenece a un Negocio.
* Toda Iniciativa tiene un único Estado de Iniciativa vigente.
* El Nombre y el Objetivo son obligatorios.

---

## 5.3 Participante

Representa la participación de una persona o equipo dentro de una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Identificación de la persona o equipo.
* Nombre.
* Rol de Participación.

Relaciones:

* Pertenece a una Iniciativa.

Restricciones:

* Toda participación corresponde a una Iniciativa.
* El Rol de Participación utiliza únicamente los valores aprobados.
* Una misma persona o equipo puede participar en distintas Iniciativas con roles diferentes.

La integración con una fuente corporativa de personas queda fuera del alcance de esta versión.

---

## 5.4 Componente

Representa un elemento técnico que forma parte de una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Nombre.
* Tipo de Componente.
* Descripción.

Relaciones:

* Pertenece a una Iniciativa.

Restricciones:

* Todo Componente corresponde a una Iniciativa.
* El Tipo de Componente utiliza valores gobernados por el dominio.

---

## 5.5 Recurso

Representa un recurso técnico o presupuestario requerido por una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Nombre.
* Descripción.
* Estado.

Relaciones:

* Pertenece a una Iniciativa.

El conjunto de Estados de Recurso se mantiene Pendiente porque no está definido en los documentos aprobados.

---

## 5.6 Documento

Representa un archivo, enlace o referencia documental asociado a una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Nombre.
* Referencia.
* Fecha de registro.
* Participante que registra.

Relaciones:

* Pertenece a una Iniciativa.
* Puede identificar al Participante que lo registra.

Restricciones:

* Todo Documento corresponde a una Iniciativa.
* El contenido o la Referencia son obligatorios según el mecanismo de almacenamiento que se defina posteriormente.

---

## 5.7 Solicitud

Representa una necesidad operacional asociada a una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Tipo de Solicitud.
* Prioridad.
* Estado de Solicitud.
* Descripción.
* Fecha de creación.
* Participante que crea.

Relaciones:

* Pertenece a una Iniciativa.
* Tiene Conversaciones.
* Puede originar Versiones cuando corresponda.

Restricciones:

* Toda Solicitud pertenece a una Iniciativa.
* El Tipo de Solicitud, la Prioridad y el Estado de Solicitud utilizan los valores aprobados.
* El Estado de Solicitud es independiente del Estado de Iniciativa.

La relación entre una Solicitud y las Versiones que atienden su necesidad queda Pendiente de validación.

---

## 5.8 Conversación

Representa una interacción trazable asociada a una Iniciativa o a una Solicitud.

Datos mínimos:

* Identificador.
* Iniciativa.
* Solicitud, cuando corresponda.
* Participante.
* Contenido.
* Fecha de registro.

Relaciones:

* Pertenece siempre a una Iniciativa.
* Puede pertenecer además a una Solicitud de esa misma Iniciativa.
* Identifica al Participante que registra la interacción.

Restricciones:

* Toda Conversación conserva el contexto de una Iniciativa.
* Si una Conversación pertenece a una Solicitud, la Solicitud pertenece a la misma Iniciativa.
* El Contenido, el Participante y la Fecha de registro son obligatorios.

Los adjuntos se representan mediante Documentos asociados a la misma Iniciativa hasta que exista una necesidad aprobada de relación más específica.

---

## 5.9 Versión

Representa una entrega identificable de una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Identificación de Versión.
* Descripción.
* Fecha de creación.

Relaciones:

* Pertenece a una Iniciativa.
* Tiene Despliegues.

Restricciones:

* Toda Versión corresponde a una Iniciativa.
* La Identificación de Versión no se repite dentro de una misma Iniciativa.

---

## 5.10 Ambiente

Representa un entorno donde se desarrolla, prueba o ejecuta una Solución.

Datos mínimos:

* Identificador.
* Nombre.

Valores iniciales:

* Desarrollo.
* QAS.
* PRD.

Relaciones:

* Puede ser requerido por muchas Iniciativas.
* Recibe Despliegues.

Restricciones:

* Los Ambientes son valores gobernados por el dominio.
* Un Ambiente no se duplica por cada Iniciativa.

---

## 5.11 Iniciativa y Ambiente

Representa la relación entre una Iniciativa y los Ambientes que requiere.

Datos mínimos:

* Iniciativa.
* Ambiente.

Restricciones:

* Una combinación de Iniciativa y Ambiente no se duplica.
* La relación no implica por sí sola que exista un Despliegue.

Esta estructura es una representación técnica de una relación aprobada y no incorpora un nuevo concepto al dominio.

---

## 5.12 Despliegue

Representa la publicación de una Versión en un Ambiente.

Datos mínimos:

* Identificador.
* Versión.
* Ambiente.
* Fecha.
* Participante responsable.
* Resultado.
* Observaciones.
* Evidencia.
* Pipeline utilizado.

Relaciones:

* Pertenece a una Versión.
* Ocurre en un Ambiente.
* Identifica al Participante responsable.

Restricciones:

* Todo Despliegue corresponde a una Versión y a un Ambiente.
* Un paso a PRD debe conservar su Resultado y la trazabilidad disponible.

Los valores permitidos para Resultado quedan Pendientes porque no están definidos en los documentos aprobados.

---

## 5.13 Historial

Representa el registro cronológico automático de eventos relevantes de una Iniciativa.

Datos mínimos:

* Identificador.
* Iniciativa.
* Solicitud, cuando corresponda.
* Participante responsable, cuando corresponda.
* Evento.
* Fecha.
* Estado anterior, cuando corresponda.
* Estado nuevo, cuando corresponda.
* Descripción.

Relaciones:

* Pertenece a una Iniciativa.
* Puede referenciar una Solicitud de esa misma Iniciativa.
* Puede identificar al Participante responsable.

Restricciones:

* Todo evento del Historial corresponde a una Iniciativa.
* Los eventos del Historial no se modifican para reemplazar lo ocurrido.
* Todo cambio de Estado de Iniciativa conserva el estado anterior, el nuevo estado, la fecha y el responsable.

El catálogo de eventos del dominio queda Pendiente de definición.

---

# 6. Objetos de Valor

Los siguientes Objetos de Valor utilizan conjuntos de valores gobernados por el dominio:

* Rol de Participación.
* Estado de Iniciativa.
* Tipo de Solicitud.
* Prioridad.
* Estado de Solicitud.
* Tipo de Componente.
* Ambiente.

Estos valores no son configuraciones libres del usuario.

Su representación física podrá resolverse mediante restricciones o estructuras de referencia. La alternativa deberá conservar los valores aprobados, evitar duplicación y no trasladar reglas del dominio a configuración libre.

---

# 7. Relaciones Fundamentales

```text
Negocio
  └── Iniciativa
        ├── Participante
        ├── Componente
        ├── Recurso
        ├── Documento
        ├── Conversación
        ├── Ambiente
        ├── Solicitud
        │     └── Conversación
        ├── Versión
        │     └── Despliegue ── Ambiente
        └── Historial
```

La relación visual expresa pertenencia y trazabilidad. No altera la responsabilidad de la Iniciativa como Aggregate Root principal.

---

# 8. Integridad y Reglas

## MR-001

No puede existir una Iniciativa sin Negocio.

## MR-002

No puede existir una Solicitud fuera del contexto de una Iniciativa.

## MR-003

Una Conversación asociada a una Solicitud debe conservar también la referencia a la Iniciativa de esa Solicitud.

## MR-004

Una Versión y sus Despliegues deben permanecer dentro del contexto de una misma Iniciativa.

## MR-005

Un Despliegue debe identificar la Versión publicada y el Ambiente donde ocurre.

## MR-006

Los Estados de Iniciativa y los Estados de Solicitud deben almacenarse de forma independiente.

## MR-007

Los Documentos, Conversaciones y eventos del Historial no se eliminan al cerrar o cancelar una Iniciativa.

## MR-008

Toda acción relevante debe generar un evento del Historial.

## MR-009

Las reglas que dependen del significado del dominio deben protegerse en el dominio, aunque la persistencia también aplique restricciones de integridad.

## MR-010

Una Iniciativa debe tener al menos un Responsable Funcional y un responsable TI antes de cumplir las condiciones operacionales que requieran dichas responsabilidades.

La identificación exacta del responsable TI queda Pendiente porque los documentos aprobados no definen un único Rol de Participación para esa responsabilidad.

---

# 9. Trazabilidad

| Estructura relacional | Fuente principal |
| --- | --- |
| Negocio | SRS-002, SRS-003 |
| Iniciativa | SRS-002, SRS-003, SRS-004 |
| Participante | SRS-003 |
| Componente | SRS-002, SRS-003 |
| Recurso | SRS-003, SRS-004 |
| Documento | SRS-003, SRS-004 |
| Solicitud | SRS-002, SRS-003, SRS-004 |
| Conversación | SRS-002, SRS-003, SRS-004 |
| Versión | SRS-003, SRS-004 |
| Ambiente | SRS-003, SRS-004 |
| Despliegue | SRS-003, SRS-004 |
| Historial | SRS-003, SRS-004 |

Este documento aplica además PHIL-001 y ADR-001.

---

# 10. Decisiones Tomadas

## D-001

El Modelo Relacional deriva del Modelo de Dominio aprobado y no lo reemplaza.

## D-002

La Iniciativa mantiene una relación directa con las estructuras que forman su contexto.

## D-003

Las Conversaciones de una Solicitud conservan también la referencia a su Iniciativa para proteger el contexto y la integridad.

## D-004

Los Objetos de Valor gobernados por el dominio no se convierten en configuraciones libres.

## D-005

El Historial se representa como un registro cronológico de eventos y no como una copia del estado actual.

## D-006

Ambiente se mantiene como un conjunto común de valores aprobados y no se duplica por Iniciativa.

## D-007

La definición del motor, los tipos físicos y la estrategia de acceso a datos se posterga hasta contar con una decisión arquitectónica específica.

---

# 11. Pendientes

* Validar los datos mínimos de cada estructura con los actores responsables.
* Definir los atributos específicos aún pendientes en SRS-003.
* Definir los Estados de Recurso.
* Definir los valores de Resultado de Despliegue.
* Definir el catálogo de eventos del dominio.
* Aclarar qué Rol de Participación representa al responsable TI de RD-004.
* Validar la relación entre Solicitudes y Versiones.
* Resolver el Pendiente de SRS-003 respecto del concepto Solución.
* Definir las condiciones y restricciones de retención de información.
* Elaborar el DER y el Diccionario de Datos después de aprobar este documento.
* Documentar mediante ADR la selección de la tecnología y la estrategia de persistencia cuando corresponda.

---

# 12. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial del Modelo Relacional de Arauco Project Hub.
