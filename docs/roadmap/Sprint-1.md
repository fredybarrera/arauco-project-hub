# Arauco Project Hub

## Engineering Playbook

# Sprint 1 - Implementación de CU-002

**Versión:** 1.1

**Estado:** Approved

**Fecha:** 2026-06-30

**Revisión anterior:** 1.0 Approved

---

# 1. Objetivo

Ordenar los cambios pequeños y verificables necesarios para implementar CU-002 - Consultar una Iniciativa conforme al alcance aprobado en Sprint 0.

---

# 2. Resultado Esperado

Al completar Sprint 1:

* Un Participante autenticado podrá consultar una Iniciativa en la que participa.
* La respuesta presentará el Negocio, nombre y Estado de Iniciativa vigente.
* Un actor sin participación no recibirá información de la Iniciativa.
* La capacidad recorrerá Frontend, API, Backend y persistencia.
* Existirá evidencia automatizada del recorrido exitoso y sus alternativas.

---

# 3. Condiciones Previas

Antes de implementar la capacidad se debe resolver:

## 3.1 Relación entre identidad y Participante

Esta condición fue resuelta por:

* ADR-010 - Relación entre Identidad Corporativa y Participante.
* SRS-010 - Modelo Relacional, versión 1.1.
* DER, versión 1.1.
* Diccionario de Datos, versión 1.1.

## 3.2 Datos controlados

Como registrar una Iniciativa permanece fuera del alcance:

* Los datos necesarios para Desarrollo y pruebas deben ser deterministas.
* No deben incorporarse como comportamiento de PRD.
* Deben incluir un Negocio, una Iniciativa y Participantes suficientes para verificar acceso permitido y no permitido.

La estrategia propuesta es:

* Las pruebas de integración crean y eliminan sus propios datos en una base aislada.
* Los datos utilizan identificadores deterministas únicamente dentro de las pruebas.
* Las vinculaciones utilizan tenant y object identifier ficticios, nunca identidades corporativas reales.
* Desarrollo puede habilitar datos locales mediante una acción explícita y separada de las migraciones.
* Las migraciones de PRD contienen únicamente cambios de estructura.
* La aplicación no crea Negocios, Iniciativas ni Participantes automáticamente al iniciar.
* QAS y PRD no reciben datos de prueba desde el repositorio.

## 3.3 Contrato de la API

Esta condición fue resuelta por Diseño de la API, versión 1.1.

La operación aprobada es `GET /api/iniciativas/{iniciativaId}`.

---

# 4. Secuencia de Implementación

## 4.1 Base del Monorepo

* Preparar las estructuras aprobadas para Frontend y Backend.
* Incorporar configuraciones mínimas de construcción, formato, análisis y pruebas.
* Mantener dependencias y límites definidos por EST-003.
* Evitar componentes que no sean necesarios para CU-002.

**Evidencia:** Frontend y Backend construyen y sus pruebas mínimas se ejecutan en integración continua.

## 4.2 Persistencia Mínima

* Representar Negocio, Iniciativa y Participante conforme al modelo aprobado.
* Crear la migración inicial necesaria para la capacidad.
* Incorporar los datos controlados únicamente para Desarrollo y pruebas.
* Implementar una consulta que recupere solo la información requerida.

**Evidencia:** pruebas de integración verifican acceso permitido, acceso no permitido e Iniciativa inexistente.

## 4.3 Backend

* Definir la consulta de CU-002 en la coordinación de capacidades.
* Mantener las reglas del dominio independientes de ASP.NET Core y Entity Framework Core.
* Verificar la participación dentro del contexto de la Iniciativa.
* Distinguir información no encontrada y acción no permitida.

**Evidencia:** pruebas unitarias y de integración cubren los resultados de la capacidad.

## 4.4 API y Autenticación

* Exponer únicamente el contrato aprobado para CU-002.
* Validar firma, emisor, audiencia y vigencia del token.
* Obtener la identidad corporativa desde el token validado.
* No aceptar identidad del actor desde datos libres del consumidor.
* Propagar el identificador de correlación sin registrar tokens.

**Evidencia:** pruebas de API cubren autenticación válida, token inválido, acceso permitido y acceso no permitido.

## 4.5 Frontend

* Integrar el inicio de sesión aprobado en ADR-009.
* Solicitar la consulta mediante `/api`.
* Presentar Negocio, nombre y Estado de Iniciativa.
* Distinguir carga, información no encontrada, acceso no permitido y fallo técnico.
* No reproducir reglas de autorización del Backend.

**Evidencia:** pruebas de componentes y del recorrido de consulta.

## 4.6 Recorrido Integrado

* Verificar la capacidad desde el Frontend hasta la persistencia.
* Confirmar que un actor sin participación no recibe información.
* Confirmar que los registros técnicos no contienen credenciales ni información sensible.
* Conservar evidencia de construcción, pruebas y trazabilidad.

**Evidencia:** recorrido automatizado exitoso en Desarrollo.

---

# 5. Contrato Propuesto para Revisión

La intención de la operación es consultar una Iniciativa dentro de su contexto.

Representación mínima de salida:

* Identificador de la Iniciativa.
* Negocio:
  * Identificador.
  * Nombre.
* Nombre de la Iniciativa.
* Estado de Iniciativa.

No se incluyen las demás responsabilidades de la Iniciativa en esta entrega.

La ruta, el método y la correspondencia con el protocolo permanecen Pendientes de aprobación antes de implementar.

---

# 6. Validaciones

Cada cambio debe verificar:

* Trazabilidad hacia CU-002 y Sprint 0.
* Uso del Lenguaje Ubicuo.
* Ausencia de conceptos o capacidades nuevas.
* Límites entre Frontend, API, Backend, dominio y persistencia.
* Autenticación y autorización en el Backend.
* Pruebas proporcionales al cambio.
* Construcción reproducible.
* Ausencia de secretos y credenciales en el repositorio.

---

# 7. Fuera de Alcance

Se mantiene fuera de Sprint 1:

* Registrar una Iniciativa.
* Consultar Iniciativas en las que el actor no participa.
* Actualizar información general.
* Incorporar o retirar Participantes.
* Cambiar el Estado de Iniciativa.
* Consultar responsabilidades adicionales.
* Filtros, búsqueda y paginación.
* Despliegue en PRD.

---

# 8. Trazabilidad

Sprint 1 deriva de:

* Sprint 0 - Primera Capacidad Trazable.
* SRS-005: RF-002 y RF-003.
* SRS-007: MP-001 y MP-004.
* SRS-008: FN-002.
* SRS-009: CU-002.
* SRS-010 - Modelo Relacional.
* ADR-003, ADR-004 y ADR-006 a ADR-009.
* Diseño de la API.
* Arquitectura del Frontend.
* Arquitectura del Backend.
* Arquitectura de Persistencia.
* Arquitectura de Seguridad.
* Arquitectura de Observabilidad.
* Diccionario de Datos.
* EST-001 a EST-005.

---

# 9. Condiciones para Iniciar la Implementación

Antes de iniciar la implementación se debe:

* Aprobar esta revisión con la estrategia de datos controlados.
* Validar la ejecución con el Technical Lead y el equipo de Desarrollo.

---

# 10. Siguiente Paso

Después de aprobar esta revisión, iniciar la base del monorepo definida en la sección 4.1.

---

# 11. Estado del Documento

**Estado actual:** Approved

Esta revisión constituye la fuente oficial para la implementación de CU-002 y reemplaza la versión 1.0.
