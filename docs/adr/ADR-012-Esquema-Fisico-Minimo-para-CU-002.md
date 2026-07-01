# Arauco Project Hub

## Architecture Decision Record

# ADR-012 - Esquema Físico Mínimo para CU-002

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-07-01

---

# 1. Contexto

Sprint 1 exige implementar la persistencia mínima de CU-002 - Consultar una Iniciativa.

ADR-006 selecciona Azure SQL Database y Entity Framework Core 10. SRS-010 versión 1.1, DER versión 1.1 y Diccionario de Datos versión 1.1 definen las estructuras lógicas de Negocio, Iniciativa y Participante.

Permanecen Pendientes los tipos físicos, longitudes, generación de identificadores, valor técnico de versión e índices. Una migración inicial no debe resolverlos mediante convenciones implícitas.

Este ADR limita la decisión al esquema requerido por CU-002.

---

# 2. Fuerzas de Decisión

La alternativa debe:

* Implementar únicamente Negocio, Iniciativa y Participante.
* Utilizar Azure SQL Database y Entity Framework Core 10.
* Mantener identificadores opacos.
* Aplicar presencia conjunta y unicidad contextual de identidad corporativa.
* Permitir concurrencia optimista sobre Iniciativa.
* Evitar eliminaciones en cascada.
* Utilizar tipos y longitudes explícitos.
* Favorecer índices derivados de consultas aprobadas.
* Evitar datos iniciales en migraciones.

---

# 3. Decisión Propuesta

## 3.1 Identificadores

* Utilizar `uniqueidentifier` para claves primarias y foráneas.
* Generar identificadores en la aplicación mediante UUID versión 7.
* No utilizar identificadores con significado del dominio.
* No exponer el orden temporal del identificador como información funcional.

## 3.2 Texto

| Dato | Tipo físico |
| --- | --- |
| Nombre de Negocio | `nvarchar(200)` |
| Nombre de Iniciativa | `nvarchar(200)` |
| Objetivo | `nvarchar(2000)` |
| Justificación | `nvarchar(4000)` |
| Beneficio esperado | `nvarchar(4000)` |
| Estado de Iniciativa | `nvarchar(50)` |
| Identificación de la persona o equipo | `nvarchar(200)` |
| Nombre de Participante | `nvarchar(200)` |
| Rol de Participación | `nvarchar(100)` |

Los textos obligatorios no aceptan valores vacíos ni compuestos únicamente por espacios.

## 3.3 Fechas y Concurrencia

* Utilizar `datetime2(7)` para Fecha de creación.
* Conservar fechas en UTC.
* Utilizar `rowversion` como valor técnico de concurrencia de Iniciativa.
* No exponer `rowversion` en CU-002.

## 3.4 Identidad Corporativa

* Utilizar `uniqueidentifier` nullable para `identificador_tenant`.
* Utilizar `uniqueidentifier` nullable para `object_identifier`.
* Aplicar una restricción `CHECK` para exigir presencia conjunta o ausencia conjunta.
* Aplicar un índice único filtrado por valores no nulos sobre:
  * `iniciativa_identificador`.
  * `identificador_tenant`.
  * `object_identifier`.

## 3.5 Índices

La migración inicial debe incluir:

* Índice sobre `iniciativa.negocio_identificador`.
* Índice sobre `participante.iniciativa_identificador`.
* Índice único filtrado de identidad corporativa dentro de la Iniciativa.

No se agregan otros índices sin una consulta o restricción aprobada.

## 3.6 Relaciones y Eliminación

* Negocio a Iniciativa utiliza clave foránea obligatoria.
* Iniciativa a Participante utiliza clave foránea obligatoria.
* Las relaciones utilizan comportamiento restrictivo de eliminación.
* La migración no elimina en cascada Iniciativas ni Participantes.

## 3.7 Datos Iniciales

* La migración contiene únicamente esquema.
* No crea Negocios, Iniciativas ni Participantes.
* Las pruebas crean y eliminan datos en una base aislada.
* Desarrollo puede utilizar una acción local explícita separada de la migración.

---

# 4. Mapeo con Entity Framework Core

La adaptación de persistencia debe:

* Configurar tablas, columnas, claves, longitudes e índices de forma explícita.
* Mantener Entity Framework Core fuera de Iniciativas.
* Utilizar proyección sin seguimiento para CU-002.
* No habilitar carga automática implícita.
* No aplicar migraciones al iniciar la API.

---

# 5. Consecuencias

## 5.1 Positivas

* La migración inicial es determinista y revisable.
* La consulta de CU-002 dispone de índices derivados de su alcance.
* La identidad corporativa aplica las restricciones aprobadas.
* La concurrencia queda preparada sin contaminar el dominio.
* No se introducen datos de prueba en PRD.

## 5.2 Costos

* Las longitudes elegidas deberán revisarse si aparecen necesidades reales mayores.
* UUID versión 7 requiere generación explícita en la aplicación.
* El índice filtrado incorpora una característica específica de Azure SQL Database.

## 5.3 Riesgos

### Longitudes insuficientes

Una integración futura podría requerir textos mayores.

**Mitigación:** revisar la longitud mediante una migración trazable cuando exista una necesidad aprobada.

### Acoplamiento físico

El código podría depender de tipos de Azure SQL Database.

**Mitigación:** mantener tipos y configuración dentro de Infrastructure.

---

# 6. Criterios de Cumplimiento

La implementación cumple cuando:

* La migración contiene solo Negocio, Iniciativa y Participante.
* Todos los tipos y longitudes están configurados explícitamente.
* La identidad corporativa cumple presencia conjunta y unicidad contextual.
* Iniciativa utiliza `rowversion`.
* Las relaciones no eliminan en cascada.
* CU-002 utiliza una proyección sin seguimiento.
* No existen datos iniciales en la migración.
* Las pruebas verifican restricciones e índices relevantes.

---

# 7. Cuándo Revisar

Esta decisión deberá revisarse si:

* Una capacidad requiere otra estructura del Modelo Relacional.
* Un dato aprobado excede una longitud definida.
* Mediciones justifican nuevos índices.
* Cambia el motor de persistencia.
* Se aprueba otro mecanismo de generación de identificadores.

---

# 8. Trazabilidad

Este ADR deriva principalmente de:

* SRS-010 - Modelo Relacional, versión 1.1.
* ADR-006 - Tecnología y Estrategia de Persistencia.
* ADR-010 - Relación entre Identidad Corporativa y Participante.
* DER, versión 1.1.
* Diccionario de Datos, versión 1.1.
* Arquitectura de Persistencia.
* Sprint 1 - Implementación de CU-002, versión 1.1.

---

# 9. Validaciones de Implementación

Antes de implementar este ADR se debe:

* Confirmar UUID versión 7 para identificadores.
* Validar las longitudes propuestas.
* Confirmar `rowversion` para Iniciativa.
* Validar el índice único filtrado de identidad corporativa.
* Confirmar el comportamiento restrictivo de eliminación.
* Validar el alcance con el Technical Lead y DBA.

---

# 10. Siguiente Paso

Después de aprobar ADR-012, implementar el contexto de Entity Framework Core, la migración inicial y las pruebas de integración de CU-002.

---

# 11. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial de verdad para el esquema físico mínimo de CU-002.
