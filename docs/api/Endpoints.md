# Arauco Project Hub

## Engineering Playbook

# Diseño de la API

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define el diseño general inicial de la API de Arauco Project Hub.

Su propósito es establecer cómo el Frontend y otros consumidores utilizan las capacidades del Backend mediante contratos explícitos, manteniendo a la Iniciativa como centro, utilizando el Lenguaje Ubicuo y evitando exponer el Modelo de Dominio o la persistencia.

Este documento no define capacidades nuevas. El catálogo definitivo de operaciones deberá derivarse de requerimientos funcionales aprobados.

---

# 2. Alcance

Este documento establece:

* Los principios de diseño de la API.
* La organización de recursos y operaciones.
* La forma general de solicitudes y respuestas.
* Los criterios de validación, errores, concurrencia y trazabilidad.
* Los límites entre API, Backend, Frontend y dominio.
* Los criterios para documentar y evolucionar contratos.

Quedan fuera del alcance:

* El catálogo definitivo de endpoints.
* Autenticación y autorización.
* Permisos por actor o Rol de Participación.
* El proveedor de identidad.
* La tecnología de persistencia.
* Los tipos físicos de almacenamiento.
* SLA, límites de consumo y requerimientos de rendimiento.
* La publicación y exposición de la API.

---

# 3. Restricciones Aprobadas

La API debe:

* Ser implementada por el Backend con ASP.NET Core 10.
* Exponer capacidades del módulo Iniciativas.
* Mantener a la Iniciativa como contexto principal.
* Utilizar el Lenguaje Ubicuo.
* Mantener contratos de entrada y salida explícitos.
* No exponer entidades del dominio ni estructuras del Modelo Relacional.
* No contener las reglas principales del dominio.
* No permitir que las convenciones del protocolo redefinan estados o conceptos aprobados.
* Comunicar resultados y errores sin exponer detalles internos.
* Conservar la información necesaria para trazabilidad.

---

# 4. Principios

## 4.1 La API expresa capacidades

Cada operación debe representar una intención reconocible del producto y tener trazabilidad hacia un requerimiento aprobado.

La existencia de una entidad, tabla o pantalla no justifica por sí sola una operación.

## 4.2 La Iniciativa mantiene el contexto

Las operaciones sobre Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial deben conservar explícitamente su relación con la Iniciativa.

## 4.3 Contratos independientes

Los contratos públicos son distintos de:

* Entidades y Objetos de Valor del dominio.
* Solicitudes internas de coordinación.
* Estructuras de persistencia.
* Propiedades particulares de componentes del Frontend.

Esta separación no obliga a duplicar modelos cuando una representación explícita y estable puede cumplir varias responsabilidades sin filtrar detalles internos.

## 4.4 Reglas en el Backend

La API valida la forma del contrato. El Backend y el dominio determinan si la acción es válida según el contexto, las reglas y el estado vigente.

## 4.5 Compatibilidad intencional

Los contratos deben evolucionar de manera controlada. Una modificación incompatible requiere una estrategia explícita y una necesidad aprobada.

## 4.6 Simplicidad

La API debe exponer únicamente las capacidades necesarias. No se incorporan operaciones genéricas, filtros libres ni abstracciones anticipadas.

---

# 5. Vista General

```mermaid
flowchart LR
    CONSUMIDOR["Frontend u otro consumidor"]

    subgraph API["API"]
        CONTRATO["Contrato externo"]
        VALIDACION["Validación de forma"]
        TRADUCCION["Traducción"]
    end

    COORDINACION["Coordinación de capacidades"]
    DOMINIO["Módulo Iniciativas"]
    ADAPTACIONES["Adaptaciones técnicas"]

    CONSUMIDOR --> CONTRATO
    CONTRATO --> VALIDACION
    VALIDACION --> TRADUCCION
    TRADUCCION --> COORDINACION
    COORDINACION --> DOMINIO
    COORDINACION --> ADAPTACIONES
```

La API es un límite de entrada y salida. No accede directamente a la persistencia ni reemplaza la coordinación del Backend.

---

# 6. Organización de Recursos

## 6.1 Recurso Principal

Iniciativa es el recurso principal de la API.

Las rutas de responsabilidades relacionadas deben mantener visible la pertenencia a una Iniciativa cuando esa relación sea necesaria para interpretar o validar la operación.

Representación conceptual:

```text
/iniciativas
/iniciativas/{iniciativaId}
/iniciativas/{iniciativaId}/solicitudes
/iniciativas/{iniciativaId}/solicitudes/{solicitudId}
```

Estos ejemplos expresan jerarquía y Lenguaje Ubicuo. No constituyen todavía un catálogo aprobado de endpoints.

## 6.2 Responsabilidades Relacionadas

Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial no se convierten en APIs independientes por conveniencia técnica.

Una ruta separada solo se justifica si la capacidad aprobada puede ejecutarse y comprenderse sin perder el contexto de la Iniciativa.

## 6.3 Identificadores

Los identificadores externos deben:

* Ser estables.
* Ser opacos para el consumidor.
* No incorporar significado mutable.
* No exponer una estrategia física de persistencia.
* Mantener nombres coherentes en rutas, solicitudes y respuestas.

El formato concreto de los identificadores permanece Pendiente.

---

# 7. Operaciones

## 7.1 Consultas

Las consultas deben:

* Recuperar información sin modificar el dominio.
* Mantener el contexto de la Iniciativa.
* Permitir seleccionar una Iniciativa por su identificador.
* Devolver solo la información necesaria para la capacidad.
* Evitar exponer la estructura completa del Aggregate por defecto.

## 7.2 Acciones

Las operaciones que modifican estado deben:

* Expresar una intención reconocible.
* Identificar la Iniciativa afectada.
* Recibir únicamente los datos necesarios.
* Permitir al Backend aplicar reglas y conservar Historial.
* Devolver el resultado oficial de la acción.
* Evitar cambios parciales.

Cuando una modificación represente una acción del dominio, debe preferirse un contrato que exprese esa intención antes que una actualización genérica de propiedades.

## 7.3 Eliminación

No se definirá eliminación física genérica para información que deba conservar trazabilidad.

Cerrar, Cancelar o cualquier otra acción aprobada debe modelarse según el Lenguaje Ubicuo y las reglas del dominio, no como sustituto técnico de eliminación.

---

# 8. Contratos de Entrada

Los contratos de entrada deben:

* Tener un propósito único y reconocible.
* Distinguir datos obligatorios y opcionales.
* No aceptar propiedades desconocidas como mecanismo de extensión implícita.
* No incluir datos que el Backend puede obtener del contexto.
* No permitir que el consumidor establezca información de Historial que corresponde producir al Backend.
* No contener nombres físicos de tablas, columnas o dependencias técnicas.

Los valores gobernados deben utilizar únicamente los valores aprobados. Un valor desconocido no debe interpretarse silenciosamente como uno existente.

---

# 9. Contratos de Salida

Los contratos de salida deben:

* Presentar información estable y comprensible.
* Utilizar el Lenguaje Ubicuo.
* Diferenciar ausencia de dato y colección vacía.
* No exponer excepciones, trazas ni detalles de persistencia.
* No incluir información sensible sin una capacidad y permiso aprobados.
* Mantener una forma consistente para una misma representación.

Las respuestas de acciones deben incluir la información necesaria para que el consumidor confirme el resultado o vuelva a consultar el estado oficial.

No se exige una envoltura general para todas las respuestas mientras no exista una necesidad aprobada.

---

# 10. Colecciones, Filtros y Paginación

Las colecciones deben:

* Tener un orden estable cuando el orden sea relevante.
* Definir filtros explícitos por capacidad.
* Rechazar criterios no soportados.
* Evitar filtros libres que expongan detalles internos.

La paginación se incorporará cuando el volumen y los requerimientos no funcionales la justifiquen. Su estrategia, tamaño y metadatos permanecen Pendientes.

---

# 11. Validación

## 11.1 API

La API verifica:

* Sintaxis y forma del contrato.
* Presencia de datos obligatorios.
* Formatos básicos.
* Valores que no pueden representarse.

## 11.2 Coordinación

La coordinación verifica:

* Existencia del contexto requerido.
* Identidad del actor cuando corresponda.
* Disponibilidad de dependencias.

## 11.3 Dominio

El dominio verifica:

* Reglas e invariantes.
* Estados y valores gobernados.
* Transiciones permitidas.
* Pertenencia al contexto de la Iniciativa.

La validación de la API mejora la respuesta, pero no reemplaza la protección del dominio.

---

# 12. Resultados y Errores

La API debe distinguir:

| Resultado conceptual | Significado |
| --- | --- |
| Solicitud aceptada | El contrato pudo procesarse y la capacidad produjo un resultado. |
| Contrato inválido | La solicitud no cumple la forma requerida. |
| Información no encontrada | El recurso solicitado no existe en el contexto consultado. |
| Acción no permitida | El actor no puede ejecutar la acción. |
| Regla incumplida | La acción contradice una regla del dominio. |
| Conflicto | El estado vigente impide aplicar la acción solicitada. |
| Fallo técnico | La capacidad no pudo completarse por una causa técnica. |

Todo error público debe incluir:

* Un identificador estable del tipo de error.
* Un mensaje comprensible.
* La información mínima para relacionarlo con el dato afectado cuando corresponda.
* Un identificador de correlación cuando sea definido por observabilidad.

La correspondencia con códigos HTTP y el formato definitivo requieren una decisión técnica específica. Si introduce una convención transversal importante, deberá documentarse mediante ADR.

---

# 13. Concurrencia e Idempotencia

La API no debe sobrescribir silenciosamente cambios realizados sobre un estado más reciente.

La estrategia para detectar conflictos de concurrencia permanece Pendiente junto con la persistencia.

Las operaciones que puedan repetirse por reintentos deben definir si son idempotentes. Las claves de idempotencia solo se incorporarán cuando exista una necesidad concreta.

---

# 14. Versionado y Compatibilidad

El versionado debe:

* Proteger a los consumidores frente a cambios incompatibles.
* Evitar mantener versiones paralelas sin necesidad.
* Permitir cambios compatibles dentro de un contrato vigente.
* Documentar retiro y transición cuando una versión sea reemplazada.

El mecanismo de versionado permanece Pendiente.

Son cambios potencialmente incompatibles:

* Eliminar o renombrar propiedades.
* Cambiar el significado o tipo de un dato.
* Convertir un dato opcional en obligatorio.
* Eliminar valores gobernados todavía vigentes.
* Modificar la semántica de una operación.

---

# 15. Seguridad

Hasta aprobar la arquitectura de seguridad, la API debe:

* No confiar en validaciones del Frontend.
* No utilizar ocultamiento de rutas como autorización.
* Validar datos en el límite.
* Evitar exponer información interna o sensible.
* Preparar contratos que permitan identificar al actor responsable.
* Mantener autenticación, autorización y reglas del dominio como responsabilidades distintas.

No se definen permisos, credenciales, sesiones ni proveedor de identidad en este documento.

---

# 16. Trazabilidad y Observabilidad

Las acciones relevantes deben permitir al Backend conservar:

* La Iniciativa afectada.
* La acción realizada.
* La fecha.
* El Participante responsable cuando corresponda.
* El estado anterior y nuevo cuando corresponda.
* La Solicitud relacionada cuando corresponda.

El Historial registra eventos del producto. Los registros técnicos y la correlación de solicitudes pertenecen a observabilidad y no reemplazan el Historial.

---

# 17. Documentación y Contrato

Cada operación aprobada debe documentar:

* Propósito.
* Trazabilidad hacia el requerimiento.
* Ruta y método.
* Contrato de entrada.
* Contrato de salida.
* Resultados y errores esperados.
* Condiciones de autenticación y autorización cuando sean aprobadas.
* Compatibilidad y versionado cuando corresponda.

La especificación ejecutable del contrato y su herramienta permanecen Pendientes.

---

# 18. Pruebas

La estrategia debe permitir:

* Verificar la forma de contratos de entrada y salida.
* Verificar la correspondencia entre resultados y protocolo.
* Verificar valores obligatorios, opcionales y desconocidos.
* Verificar errores sin exponer detalles internos.
* Verificar que una operación no acceda directamente a persistencia.
* Verificar compatibilidad de contratos.
* Verificar flujos integrados con el Backend.

La selección de herramientas y el alcance cuantitativo permanecen Pendientes.

---

# 19. Criterios de Cumplimiento

La implementación cumple este documento cuando:

* Organiza la API alrededor de capacidades de Iniciativas.
* Utiliza el Lenguaje Ubicuo.
* Mantiene contratos explícitos e independientes.
* No expone entidades del dominio ni estructuras relacionales.
* Mantiene la API separada de reglas, coordinación y persistencia.
* Distingue validación de forma y reglas del dominio.
* Comunica resultados y errores de manera uniforme.
* Conserva el contexto necesario para trazabilidad.
* Evoluciona contratos de forma controlada.
* No incorpora operaciones sin requerimientos aprobados.

---

# 20. Trade-offs

## 20.1 Ventajas

* Mantiene una frontera estable entre Frontend y Backend.
* Protege el dominio y la persistencia.
* Conserva el contexto de la Iniciativa.
* Facilita pruebas y evolución controlada.

## 20.2 Costos

* Requiere traducir contratos en los límites.
* Exige documentar cada capacidad.
* Limita la creación anticipada de endpoints genéricos.

## 20.3 Aspectos a Revisar

* Requerimientos funcionales.
* Estilo y catálogo de operaciones.
* Formato de errores.
* Versionado.
* Paginación.
* Concurrencia.
* Autenticación y autorización.

---

# 21. Trazabilidad Documental

Este documento deriva principalmente de:

* PHIL-001.
* SRS-002 - Lenguaje Ubicuo.
* SRS-003 - Modelo de Dominio.
* SRS-004 - Modelo Operacional.
* ADR-001 - Arquitectura Basada en el Negocio.
* ADR-004 - Backend con .NET 10.
* Visión de Arquitectura.
* Módulos.
* Modelo de Dominio Arquitectónico.
* Arquitectura del Backend.
* Arquitectura del Frontend.

---

# 22. Pendientes

* Aprobar los requerimientos funcionales que originan las operaciones.
* Definir el catálogo de endpoints.
* Definir los contratos de cada capacidad.
* Definir el formato de errores y su correspondencia con HTTP.
* Definir el mecanismo de versionado.
* Definir la estrategia de paginación.
* Definir concurrencia e idempotencia.
* Definir autenticación y autorización.
* Definir la especificación ejecutable de la API.
* Definir la estrategia detallada de pruebas de contrato.

Cada decisión arquitectónica importante deberá documentarse mediante ADR.

---

# 23. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para el diseño general de la API de Arauco Project Hub.
