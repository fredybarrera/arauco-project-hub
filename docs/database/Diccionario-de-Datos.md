# Arauco Project Hub

## Engineering Playbook

# Diccionario de Datos

**Versión:** 1.1

**Estado:** Approved

**Fecha:** 2026-06-30

**Revisión anterior:** 1.0 Approved

---

# 1. Objetivo

Este documento define el Diccionario de Datos inicial de Arauco Project Hub.

Su propósito es describir los nombres físicos provisionales, significados, tipos lógicos, obligatoriedad y claves de los datos representados en el DER aprobado.

El Diccionario de Datos deriva de SRS-010 y del DER. No redefine el Modelo de Dominio, no incorpora conceptos nuevos y no selecciona una tecnología de persistencia.

---

# 2. Alcance

Este documento establece:

* Los nombres físicos provisionales de las estructuras y sus datos.
* El significado de cada dato.
* Su tipo lógico.
* Su obligatoriedad.
* Las claves primarias, foráneas y únicas.
* Las referencias entre estructuras.

Quedan fuera del alcance:

* Los tipos de datos específicos de un motor.
* Las longitudes físicas.
* Los valores predeterminados.
* La generación de identificadores.
* Los índices de rendimiento.
* El particionamiento.
* La estrategia de acceso a datos.
* La selección del motor de base de datos.
* Los atributos que SRS-010 mantiene Pendientes.

---

# 3. Convenciones

## 3.1 Nombres físicos

Los nombres físicos provisionales:

* Utilizan minúsculas.
* Utilizan singular para las estructuras.
* Separan palabras mediante guion bajo.
* Evitan abreviaturas que oculten el Lenguaje Ubicuo.
* Omiten tildes y caracteres especiales por portabilidad técnica.

Estos nombres no sustituyen los términos oficiales utilizados en la documentación, el dominio, la API o la interfaz.

## 3.2 Tipos lógicos

| Tipo lógico | Significado |
| --- | --- |
| Identificador | Valor interno que identifica una instancia o referencia otra estructura. |
| Texto corto | Texto de extensión acotada cuyo límite físico se definirá posteriormente. |
| Texto largo | Contenido descriptivo cuyo límite físico se definirá posteriormente. |
| Fecha y hora | Momento temporal relevante para el dominio o la trazabilidad. |
| Valor gobernado | Valor perteneciente a un conjunto controlado por el dominio. |
| Referencia | Ubicación o vínculo hacia contenido asociado. |

## 3.3 Claves

| Marca | Significado |
| --- | --- |
| PK | Clave primaria. |
| FK | Clave foránea. |
| UK | Clave única dentro del contexto indicado. |

La obligatoriedad `Pendiente` indica que los documentos aprobados todavía no permiten fijarla sin incorporar una decisión nueva.

---

# 4. Estructuras

## 4.1 Negocio

**Nombre físico provisional:** `negocio`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un Negocio. |
| Nombre | `nombre` | Texto corto | Sí | — | Nombre oficial del Negocio. |

---

## 4.2 Iniciativa

**Nombre físico provisional:** `iniciativa`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica una Iniciativa. |
| Negocio | `negocio_identificador` | Identificador | Sí | FK | Referencia a `negocio.identificador`. |
| Nombre | `nombre` | Texto corto | Sí | — | Nombre de la Iniciativa. |
| Objetivo | `objetivo` | Texto largo | Sí | — | Resultado que la Iniciativa busca alcanzar. |
| Justificación | `justificacion` | Texto largo | No | — | Fundamento de la Iniciativa. |
| Beneficio esperado | `beneficio_esperado` | Texto largo | No | — | Valor que se espera obtener. |
| Estado de Iniciativa | `estado_iniciativa` | Valor gobernado | Sí | — | Etapa vigente de la Iniciativa. |
| Fecha de creación | `fecha_creacion` | Fecha y hora | Sí | — | Momento en que se registra la Iniciativa. |

---

## 4.3 Participante

**Nombre físico provisional:** `participante`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica una participación dentro de una Iniciativa. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Identificación de la persona o equipo | `identificacion_persona_equipo` | Texto corto | Sí | — | Identifica a la persona o equipo participante. |
| Nombre | `nombre` | Texto corto | Sí | — | Nombre visible de la persona o equipo. |
| Rol de Participación | `rol_participacion` | Valor gobernado | Sí | — | Responsabilidad del Participante dentro de la Iniciativa. |
| Identificador del tenant | `identificador_tenant` | Identificador | No | UK | Identifica el tenant de la identidad corporativa asociada. |
| Object identifier | `object_identifier` | Identificador | No | UK | Identifica la identidad corporativa dentro del tenant. |

`identificador_tenant` y `object_identifier` son opcionales como par: ambos están presentes o ambos están ausentes.

La clave única se compone de `iniciativa_identificador`, `identificador_tenant` y `object_identifier`. Ninguno de los dos datos de identidad es único de forma aislada.

La Identificación de la persona o equipo mantiene un significado distinto de la identidad corporativa.

La administración productiva de la vinculación con una identidad corporativa permanece fuera del alcance.

---

## 4.4 Componente

**Nombre físico provisional:** `componente`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un Componente. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Nombre | `nombre` | Texto corto | Sí | — | Nombre del Componente. |
| Tipo de Componente | `tipo_componente` | Valor gobernado | Sí | — | Naturaleza técnica del Componente. |
| Descripción | `descripcion` | Texto largo | No | — | Información complementaria del Componente. |

---

## 4.5 Recurso

**Nombre físico provisional:** `recurso`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un Recurso. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Nombre | `nombre` | Texto corto | Sí | — | Nombre del Recurso. |
| Descripción | `descripcion` | Texto largo | No | — | Información complementaria del Recurso. |
| Estado | `estado` | Valor gobernado | Pendiente | — | Situación del Recurso; sus valores todavía no están definidos. |

---

## 4.6 Documento

**Nombre físico provisional:** `documento`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un Documento. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Participante que registra | `participante_registra_identificador` | Identificador | No | FK | Referencia a `participante.identificador`. |
| Nombre | `nombre` | Texto corto | Sí | — | Nombre del Documento. |
| Referencia | `referencia` | Referencia | Sí | — | Ubicación del archivo, enlace o referencia documental. |
| Fecha de registro | `fecha_registro` | Fecha y hora | Sí | — | Momento en que se registra el Documento. |

La forma de almacenar contenido documental se definirá junto con la tecnología correspondiente.

---

## 4.7 Solicitud

**Nombre físico provisional:** `solicitud`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica una Solicitud. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Participante que crea | `participante_crea_identificador` | Identificador | Sí | FK | Referencia a `participante.identificador`. |
| Tipo de Solicitud | `tipo_solicitud` | Valor gobernado | Sí | — | Naturaleza de la Solicitud. |
| Prioridad | `prioridad` | Valor gobernado | Sí | — | Urgencia relativa de la Solicitud. |
| Estado de Solicitud | `estado_solicitud` | Valor gobernado | Sí | — | Estado vigente de la Solicitud. |
| Descripción | `descripcion` | Texto largo | Sí | — | Necesidad operacional registrada. |
| Fecha de creación | `fecha_creacion` | Fecha y hora | Sí | — | Momento en que se crea la Solicitud. |

---

## 4.8 Conversación

**Nombre físico provisional:** `conversacion`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica una interacción de la Conversación. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Solicitud | `solicitud_identificador` | Identificador | No | FK | Referencia a `solicitud.identificador` cuando corresponde. |
| Participante | `participante_identificador` | Identificador | Sí | FK | Referencia al Participante que registra la interacción. |
| Contenido | `contenido` | Texto largo | Sí | — | Comentario, decisión, observación, rechazo, aprobación o coordinación registrada. |
| Fecha de registro | `fecha_registro` | Fecha y hora | Sí | — | Momento en que se registra la interacción. |

Cuando existe `solicitud_identificador`, la Solicitud debe pertenecer a la misma Iniciativa indicada por `iniciativa_identificador`.

---

## 4.9 Versión

**Nombre físico provisional:** `version`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica una Versión. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK, UK | Referencia a `iniciativa.identificador` y parte de la unicidad de Versión. |
| Identificación de Versión | `identificacion_version` | Texto corto | Sí | UK | Identificación que no se repite dentro de una Iniciativa. |
| Descripción | `descripcion` | Texto largo | No | — | Cambios incluidos en la Versión. |
| Fecha de creación | `fecha_creacion` | Fecha y hora | Sí | — | Momento en que se registra la Versión. |

La clave única se compone de `iniciativa_identificador` e `identificacion_version`.

---

## 4.10 Ambiente

**Nombre físico provisional:** `ambiente`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un Ambiente. |
| Nombre | `nombre` | Valor gobernado | Sí | UK | Nombre del Ambiente: Desarrollo, QAS o PRD. |

---

## 4.11 Iniciativa y Ambiente

**Nombre físico provisional:** `iniciativa_ambiente`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia |
| --- | --- | --- | --- | --- | --- |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | PK, FK | Referencia a `iniciativa.identificador`. |
| Ambiente | `ambiente_identificador` | Identificador | Sí | PK, FK | Referencia a `ambiente.identificador`. |

La clave primaria se compone de `iniciativa_identificador` y `ambiente_identificador`.

---

## 4.12 Despliegue

**Nombre físico provisional:** `despliegue`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un Despliegue. |
| Versión | `version_identificador` | Identificador | Sí | FK | Referencia a `version.identificador`. |
| Ambiente | `ambiente_identificador` | Identificador | Sí | FK | Referencia a `ambiente.identificador`. |
| Participante responsable | `participante_responsable_identificador` | Identificador | Sí | FK | Referencia a `participante.identificador`. |
| Fecha | `fecha` | Fecha y hora | Sí | — | Momento en que ocurre el Despliegue. |
| Resultado | `resultado` | Valor gobernado | Sí | — | Resultado del Despliegue; sus valores permanecen Pendientes. |
| Observaciones | `observaciones` | Texto largo | No | — | Información complementaria del Despliegue. |
| Evidencia | `evidencia` | Referencia | No | — | Referencia a evidencia del Despliegue. |
| Pipeline utilizado | `pipeline_utilizado` | Referencia | No | — | Referencia al Pipeline utilizado. |

---

## 4.13 Historial

**Nombre físico provisional:** `historial`

| Dato | Nombre físico | Tipo lógico | Obligatorio | Clave | Referencia o significado |
| --- | --- | --- | --- | --- | --- |
| Identificador | `identificador` | Identificador | Sí | PK | Identifica un evento del Historial. |
| Iniciativa | `iniciativa_identificador` | Identificador | Sí | FK | Referencia a `iniciativa.identificador`. |
| Solicitud | `solicitud_identificador` | Identificador | No | FK | Referencia a `solicitud.identificador` cuando corresponde. |
| Participante responsable | `participante_responsable_identificador` | Identificador | No | FK | Referencia a `participante.identificador` cuando corresponde. |
| Evento | `evento` | Valor gobernado | Sí | — | Tipo de evento ocurrido; su catálogo permanece Pendiente. |
| Fecha | `fecha` | Fecha y hora | Sí | — | Momento en que ocurre el evento. |
| Estado anterior | `estado_anterior` | Valor gobernado | No | — | Estado previo cuando el evento representa un cambio de estado. |
| Estado nuevo | `estado_nuevo` | Valor gobernado | No | — | Estado resultante cuando el evento representa un cambio de estado. |
| Descripción | `descripcion` | Texto largo | No | — | Contexto complementario del evento. |

Cuando existe `solicitud_identificador`, la Solicitud debe pertenecer a la misma Iniciativa indicada por `iniciativa_identificador`.

---

# 5. Valores Gobernados

Los siguientes datos utilizan valores gobernados por el dominio y no constituyen configuraciones libres:

| Dato | Valores aprobados o fuente |
| --- | --- |
| Rol de Participación | Business Expert, Jefe de Proyecto, Technical Lead, Developer, Responsable Funcional, Usuario Final, Gestión Financiera TI, DevOps y DBA. |
| Estado de Iniciativa | Idea, Evaluación, Aprobada, Preparación, Desarrollo, QAS, Producción, Operación, Cerrada y Cancelada. |
| Tipo de Solicitud | Error, Mejora y Nuevo Desarrollo. |
| Prioridad | Baja, Media y Alta. |
| Estado de Solicitud | Creada, Asignada, En Desarrollo, En QAS, Rechazada en QAS, Aprobada, En Producción, Cerrada y Cancelada. |
| Tipo de Componente | Valores gobernados por el Modelo de Dominio; su catálogo físico se definirá posteriormente. |
| Ambiente | Desarrollo, QAS y PRD. |
| Estado de Recurso | Pendiente de definición. |
| Resultado de Despliegue | Pendiente de definición. |
| Evento del Historial | Pendiente de definición. |

---

# 6. Integridad Referencial

* Toda Iniciativa referencia un Negocio existente.
* Toda estructura dependiente de una Iniciativa referencia una Iniciativa existente.
* Todo Participante utilizado como referencia pertenece a la Iniciativa correspondiente.
* Una Solicitud referenciada por una Conversación o un evento del Historial pertenece a la misma Iniciativa.
* Todo Despliegue referencia una Versión y un Ambiente existentes.
* Una Versión y sus Despliegues permanecen dentro del contexto de una misma Iniciativa.
* Una combinación de Iniciativa y Ambiente no se repite.
* Una Identificación de Versión no se repite dentro de una misma Iniciativa.
* `identificador_tenant` y `object_identifier` de Participante están presentes juntos o ausentes juntos.
* La combinación de `iniciativa_identificador`, `identificador_tenant` y `object_identifier` no se repite.
* `identificacion_persona_equipo` no sustituye los datos de identidad corporativa.
* El cierre o cancelación de una Iniciativa no elimina sus Documentos, Conversaciones ni eventos del Historial.

Las reglas que requieren comprender el significado del dominio deben permanecer protegidas por el dominio y no depender únicamente de la persistencia.

---

# 7. Trazabilidad

| Contenido | Fuente |
| --- | --- |
| Estructuras y datos mínimos | SRS-010 versión 1.1, sección 5. |
| Relaciones e integridad | SRS-010 versión 1.1, secciones 7 y 8; DER versión 1.1, secciones 4 a 6. |
| Valores gobernados | SRS-003, sección 5; SRS-010, sección 6. |
| Lenguaje utilizado | SRS-002. |
| Iniciativa como Aggregate Root principal | SRS-003, ADR-001, SRS-010 y DER. |
| Identidad corporativa de Participante | ADR-010, SRS-010 versión 1.1 y DER versión 1.1. |

Si existe una diferencia entre este documento y una fuente aprobada de mayor prioridad, prevalece la fuente de mayor prioridad.

---

# 8. Pendientes

* Validar los nombres físicos provisionales.
* Validar la obligatoriedad de los datos no definida explícitamente en SRS-010.
* Definir los atributos específicos que permanecen Pendientes en SRS-010.
* Definir los Estados de Recurso.
* Definir los valores de Resultado de Despliegue.
* Definir el catálogo de eventos del dominio.
* Aclarar qué Rol de Participación representa al responsable TI.
* Validar la relación entre Solicitudes y Versiones antes de incorporarla.
* Resolver el Pendiente respecto del concepto Solución.
* Definir la representación física de los valores gobernados.
* Documentar mediante ADR la selección de la tecnología y la estrategia de persistencia.
* Definir tipos físicos, longitudes, valores predeterminados e índices después de seleccionar la tecnología.
* Definir una capacidad autorizada para administrar vinculaciones de identidad corporativa en PRD.

---

# 9. Estado del Documento

**Estado actual:** Approved

Esta revisión constituye la fuente oficial para la definición lógica de los datos persistidos y reemplaza la versión 1.0.
