# Arauco Project Hub

## Engineering Playbook

# EST-004 - Convención de Nombres

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Objetivo

Este documento define convenciones de nombres para la documentación, el código, la API, la persistencia y los recursos técnicos de Arauco Project Hub.

Su propósito es mantener el Lenguaje Ubicuo visible, evitar sinónimos y distinguir con claridad los nombres del dominio de las representaciones exigidas por cada tecnología.

---

# 2. Alcance

Este estándar establece:

* La fuente oficial de los nombres del dominio.
* Las transformaciones técnicas permitidas.
* Convenciones para documentos y archivos.
* Convenciones para C#, TypeScript, Vue y Nuxt.
* Convenciones para API y persistencia.
* Criterios para nombres de recursos Azure.
* Reglas para abreviaturas, identificadores y Ambientes.

Este documento no:

* Incorpora conceptos al Lenguaje Ubicuo.
* Cambia nombres físicos aprobados en el Diccionario de Datos.
* Define la estructura interna completa del Frontend o Backend.
* Selecciona nuevos servicios Azure.
* Renombra documentos Approved.
* Sustituye restricciones de nombres propias de una tecnología o políticas corporativas.

---

# 3. Principios

## 3.1 El nombre expresa una responsabilidad

Un nombre debe permitir comprender qué representa sin depender de conocimiento implícito.

Se deben evitar nombres genéricos como `Manager`, `Helper`, `Utils`, `Common`, `Data` o `Service` cuando no expresen una responsabilidad concreta.

## 3.2 El Lenguaje Ubicuo es la fuente

Cuando un nombre representa un concepto del dominio, debe derivar de SRS-002.

No se permiten sinónimos para acortar, traducir o acomodar un concepto a una preferencia tecnológica.

## 3.3 La transformación técnica no cambia el significado

Una tecnología puede requerir cambios de mayúsculas, separadores, plural o caracteres permitidos.

La transformación debe conservar el término oficial y no crear un concepto alternativo.

## 3.4 Las abreviaturas son excepciones

Una abreviatura se permite únicamente cuando:

* Es un estándar técnico ampliamente reconocido.
* Está aprobada como representación de un Ambiente.
* Una restricción técnica impide utilizar el nombre completo.
* Se encuentra documentada en este estándar.

## 3.5 Consistencia dentro de cada límite

Una misma responsabilidad debe utilizar la misma convención dentro de documentación, código, contratos, persistencia y recursos del mismo tipo.

No se mezclan estilos de nombres dentro de un mismo límite.

---

# 4. Términos Oficiales

Los términos oficiales deben conservar su significado y forma conceptual:

* Negocio.
* Iniciativa.
* Solución.
* Componente.
* Solicitud.
* Conversación.
* Participante.
* Rol de Participación.
* Recurso.
* Documento.
* Versión.
* Ambiente.
* Despliegue.
* Historial.

Los actores definidos en SRS-002 mantienen sus nombres oficiales, incluidos Business Expert, Jefe de Proyecto, Technical Lead, Developer, Responsable Funcional, Usuario Final, Gestión Financiera TI, DevOps y DBA.

Los términos prohibidos y sus reemplazos son:

| Evitar | Utilizar |
| --- | --- |
| Proyecto | Iniciativa |
| Chat | Conversación |
| Cliente | Responsable Funcional |
| Sistema | Solución, cuando corresponda |
| Issue | Solicitud |

Los términos técnicos `Frontend`, `Backend`, `API`, `Aggregate Root`, `OpenTelemetry` y nombres propios de tecnologías no sustituyen conceptos del dominio.

---

# 5. Transformaciones por Contexto

Ejemplo con el concepto `Rol de Participación`:

| Contexto | Representación |
| --- | --- |
| Documentación e interfaz | `Rol de Participación` |
| Tipo C# o TypeScript | `RolParticipacion` |
| Propiedad JSON | `rolParticipacion` |
| Ruta, cuando corresponda | `roles-participacion` |
| Persistencia | `rol_participacion` |

Estas representaciones son transformaciones técnicas del mismo concepto. No constituyen términos nuevos.

Las tildes y la letra `ñ`:

* Se conservan en documentación e interfaz.
* Se omiten únicamente cuando el lenguaje, protocolo o plataforma requiera una representación portable.
* No autorizan traducir el término ni cambiar su significado.

---

# 6. Documentación

## 6.1 Títulos

Los títulos deben:

* Utilizar el nombre oficial del documento.
* Mantener tildes y caracteres del español.
* Evitar abreviaturas no definidas.
* Incluir el identificador cuando pertenezcan a una serie gobernada.

Ejemplos:

```text
SRS-002 - Lenguaje Ubicuo
ADR-006 - Tecnología y Estrategia de Persistencia
EST-004 - Convención de Nombres
```

## 6.2 Archivos

Para documentos nuevos pertenecientes a una serie:

```text
<TIPO>-<NNN>-<Titulo-sin-tildes>.md
```

Reglas:

* El tipo se escribe en mayúsculas.
* El número utiliza tres dígitos.
* Las palabras del título se separan con guion.
* Se omiten tildes y caracteres especiales en el nombre físico.
* La extensión es `.md`.
* El título dentro del documento conserva la escritura oficial.

Este estándar no renombra documentos Approved existentes. Cualquier normalización debe ejecutarse como un cambio separado, revisando enlaces y trazabilidad.

## 6.3 Secciones y referencias

Las referencias deben utilizar el identificador y título oficial del documento.

No se deben crear nombres abreviados diferentes para un mismo documento.

---

# 7. C# y .NET

Los nombres deben seguir las convenciones de .NET sin ocultar el Lenguaje Ubicuo:

| Elemento | Convención | Ejemplo |
| --- | --- | --- |
| Namespace | PascalCase | `Arauco.ProjectHub.Iniciativas` |
| Tipo | PascalCase | `Iniciativa` |
| Método | PascalCase | `RegistrarSolicitud` |
| Propiedad | PascalCase | `EstadoIniciativa` |
| Parámetro | camelCase | `iniciativaId` |
| Variable local | camelCase | `solicitud` |
| Campo privado | `_camelCase` | `_repositorioIniciativas` |
| Interfaz | `I` y PascalCase | `IRepositorioIniciativas` |
| Método asíncrono | sufijo `Async` | `ObtenerIniciativaAsync` |

Reglas adicionales:

* Los tipos del dominio utilizan sustantivos del Lenguaje Ubicuo.
* Las operaciones utilizan verbos que describen una capacidad aprobada.
* Las colecciones utilizan plural.
* Los valores booleanos expresan una condición verificable.
* Las excepciones técnicas terminan en `Exception`.
* Los sufijos técnicos solo se utilizan cuando aclaran la responsabilidad.

La cantidad y nombres de las unidades de compilación .NET permanecen Pendientes. Si su organización incorpora un patrón arquitectónico nuevo, se debe proponer un ADR.

---

# 8. TypeScript, Vue y Nuxt

| Elemento | Convención | Ejemplo |
| --- | --- | --- |
| Tipo o interfaz | PascalCase | `Iniciativa` |
| Componente Vue | PascalCase | `DetalleIniciativa.vue` |
| Función | camelCase | `registrarSolicitud` |
| Variable | camelCase | `iniciativaActual` |
| Propiedad | camelCase | `estadoIniciativa` |
| Constante global estable | MAYÚSCULAS_CON_GUION_BAJO | `TIEMPO_ESPERA_MAXIMO` |
| Composable | prefijo `use` | `useIniciativa` |
| Evento de componente | kebab-case | `solicitud-registrada` |

Reglas adicionales:

* Los componentes se nombran por la responsabilidad que presentan.
* Las páginas se nombran según el destino de navegación.
* Los composables expresan una capacidad o coordinación reconocible.
* Los nombres no deben depender de la ubicación para ser comprensibles.
* Se evitan componentes genéricos configurados para responsabilidades no relacionadas.

La convención definitiva de rutas físicas y archivos generados por Nuxt permanece Pendiente de la estructura inicial del Frontend.

---

# 9. API

## 9.1 Rutas

Las rutas deben:

* Utilizar minúsculas.
* Separar palabras mediante guion.
* Utilizar plural para colecciones.
* Mantener visible a la Iniciativa cuando define el contexto.
* Utilizar nombres del Lenguaje Ubicuo sin términos de implementación.

Ejemplos conceptuales ya respaldados por el Diseño de la API:

```text
/iniciativas
/iniciativas/{iniciativaId}
/iniciativas/{iniciativaId}/solicitudes
/iniciativas/{iniciativaId}/solicitudes/{solicitudId}
```

Estos ejemplos no aprueban por sí mismos un catálogo de endpoints.

## 9.2 Contratos

Las propiedades JSON utilizan camelCase:

```json
{
  "iniciativaId": "...",
  "estadoIniciativa": "Desarrollo"
}
```

Los contratos:

* Utilizan el Lenguaje Ubicuo.
* No exponen nombres físicos de persistencia.
* No incluyen sufijos técnicos innecesarios.
* Mantienen el mismo nombre para el mismo dato en entrada y salida cuando su significado no cambia.

## 9.3 Identificadores

Un identificador expuesto utiliza el nombre del concepto seguido de `Id`, por ejemplo `iniciativaId`.

El formato físico del valor permanece Pendiente y no debe codificarse en el nombre.

---

# 10. Persistencia

Los nombres físicos se rigen por el Diccionario de Datos Approved:

* Utilizan minúsculas.
* Utilizan singular para estructuras.
* Separan palabras mediante guion bajo.
* Evitan abreviaturas.
* Omiten tildes y caracteres especiales.

Ejemplos:

```text
iniciativa
solicitud
estado_iniciativa
iniciativa_identificador
```

Las claves foráneas expresan el concepto referenciado y terminan en `_identificador`.

Los nombres físicos aprobados no se traducen ni se reemplazan por convenciones automáticas de Entity Framework Core.

Índices, restricciones, migraciones y otros objetos técnicos deben derivar sus nombres de las estructuras involucradas. Su patrón físico definitivo permanece Pendiente de validar límites y convenciones de Azure SQL Database.

---

# 11. Ambientes

Los nombres oficiales de Ambiente son:

| Nombre oficial | Representación técnica corta |
| --- | --- |
| Desarrollo | `dev` |
| QAS | `qas` |
| PRD | `prd` |

La representación corta:

* Se utiliza únicamente cuando una restricción técnica o un patrón de recurso lo requiere.
* No cambia el nombre mostrado en documentación funcional o interfaz.
* Debe utilizarse de forma consistente dentro de una misma plataforma.

No se crean Ambientes adicionales mediante una convención de nombres.

---

# 12. Recursos Azure

Un nombre lógico de recurso debe permitir identificar, en este orden cuando la plataforma lo admita:

1. Producto.
2. Responsabilidad o servicio.
3. Ambiente.
4. Región, si es necesaria.
5. Instancia, si existe más de una.

Identificadores técnicos iniciales propuestos:

| Elemento | Identificador |
| --- | --- |
| Arauco Project Hub | `aph` |
| Desarrollo | `dev` |
| QAS | `qas` |
| PRD | `prd` |

Patrón lógico:

```text
aph-<responsabilidad>-<ambiente>-<region-opcional>-<instancia-opcional>
```

El patrón físico debe adaptarse a:

* Caracteres y longitud permitidos por el servicio.
* Unicidad global cuando corresponda.
* Convenciones corporativas.
* Información que el servicio ya representa fuera del nombre.

No se definen todavía abreviaturas para servicios, regiones o responsabilidades. Deben confirmarse con la política corporativa y documentarse antes de crear recursos.

Un nombre no debe contener:

* Datos personales.
* Información sensible.
* Credenciales.
* Identificadores de Iniciativa, Participante o Solicitud.
* Información mutable como responsable actual o estado operacional.

---

# 13. Ramas y Commits

Los nombres de rama deben:

* Ser breves y descriptivos.
* Utilizar minúsculas y guiones.
* Comenzar con un tipo compatible con Conventional Commits.
* Evitar datos personales y términos no aprobados.

Patrón:

```text
<tipo>/<descripcion-breve>
```

Ejemplos:

```text
docs/estandar-nombres
feat/registrar-solicitud
fix/corregir-estado-iniciativa
```

Los mensajes de commit se rigen por EST-003 y utilizan Conventional Commits.

---

# 14. Abreviaturas

Abreviaturas permitidas por este Draft:

| Abreviatura | Significado |
| --- | --- |
| `API` | Application Programming Interface |
| `ADR` | Architecture Decision Record |
| `SRS` | Software Requirements Specification |
| `EST` | Standard del Engineering Playbook |
| `DBA` | Actor definido en SRS-002 |
| `QAS` | Ambiente aprobado |
| `PRD` | Ambiente aprobado |
| `dev` | Representación técnica de Desarrollo |
| `aph` | Representación técnica de Arauco Project Hub |

Una abreviatura no incluida debe justificarse y documentarse antes de utilizarse de manera transversal.

---

# 15. Nombres Prohibidos

Además de los términos prohibidos por SRS-002, se deben evitar:

* Nombres genéricos que oculten responsabilidad.
* Números sin significado documentado.
* Abreviaturas locales.
* Traducciones distintas para un mismo concepto.
* Nombres de tecnología para representar conceptos del dominio.
* Nombres físicos de persistencia dentro de contratos públicos.
* Información sensible o mutable en nombres de recursos.
* Sufijos como `New`, `Old`, `Final`, `Temp` o versiones informales.

Cuando no exista un nombre adecuado, se debe revisar primero si la responsabilidad ya está definida. Si representa un concepto nuevo del dominio, se debe proponer una revisión de SRS-002.

---

# 16. Criterios de Cumplimiento

Una implementación cumple este estándar cuando:

* Utiliza el Lenguaje Ubicuo para conceptos del dominio.
* No utiliza términos prohibidos como equivalentes.
* Aplica la convención correspondiente a cada tecnología.
* Mantiene el mismo significado entre documentación, código, API y persistencia.
* Utiliza nombres físicos del Diccionario de Datos.
* Evita abreviaturas no documentadas.
* Distingue nombres del dominio y nombres técnicos.
* No incorpora información sensible en nombres.
* No crea conceptos o Ambientes mediante convenciones técnicas.

---

# 17. Trazabilidad

Este estándar deriva principalmente de:

* PHIL-001: FP-005, FP-009, FP-010, FP-011 y FP-012.
* SRS-002 - Lenguaje Ubicuo.
* Diccionario de Datos.
* Diseño de la API.
* Arquitectura del Frontend.
* Arquitectura del Backend.
* EST-001 - Estándar Tecnológico.
* EST-002 - Estándar Azure.
* EST-003 - Convención de Repositorios.

---

# 18. Validaciones de Implementación

* Confirmar el patrón para documentos nuevos.
* Confirmar las convenciones de C# y TypeScript.
* Confirmar camelCase para contratos JSON.
* Validar `dev`, `qas` y `prd` como representaciones técnicas.
* Validar `aph` como identificador técnico del producto.
* Confirmar el patrón lógico para recursos Azure con la política corporativa.
* Definir abreviaturas de servicios y regiones solo cuando sean necesarias.
* Confirmar la convención de nombres de ramas.
* Definir patrones para objetos de Azure SQL Database cuando se validen sus restricciones.

---

# 19. Siguiente Paso

Después de aprobar EST-004, el siguiente documento propuesto es:

EST-005 - CI/CD.

Objetivo:

Definir las validaciones y el flujo de integración y entrega del monorepo sin seleccionar una plataforma de despliegue no aprobada.

---

# 20. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para los nombres utilizados en documentación, código, API, persistencia y recursos técnicos de Arauco Project Hub.
