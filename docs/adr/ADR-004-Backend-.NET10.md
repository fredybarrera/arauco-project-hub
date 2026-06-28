# Arauco Project Hub

## Architecture Decision Record

# ADR-004 - Backend con .NET 10

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Contexto

Arauco Project Hub necesita un Backend que proteja las reglas del dominio y acompañe el ciclo de vida completo de una Iniciativa, desde la Idea hasta la Operación.

El Backend deberá mantener dentro del contexto de la Iniciativa sus Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial. También deberá conservar la independencia entre el Estado de Iniciativa y el Estado de Solicitud, aplicar las reglas aprobadas y proporcionar capacidades a través de una API.

ADR-001 exige separar las reglas del dominio de frameworks, persistencia y servicios externos. ADR-002 sitúa el Backend dentro del monorepo con límites y validaciones propias. ADR-003 establece que el Frontend se comunicará mediante contratos explícitos con la API sin compartir reglas del dominio.

Sin una decisión sobre la tecnología principal del Backend, podrían aparecer:

* Modelos y convenciones diferentes para representar el mismo dominio.
* Reglas distribuidas entre endpoints, persistencia e integraciones.
* Contratos de API determinados por estructuras de almacenamiento.
* Configuración repetida para validación, observabilidad y manejo de errores.
* Dependencias tecnológicas difíciles de sustituir.

Esta decisión selecciona la base tecnológica del Backend. No define la arquitectura interna definitiva, el estilo de endpoints, la persistencia, la autenticación, la autorización, la mensajería, la observabilidad ni el despliegue.

---

# 2. Fuerzas de Decisión

La decisión debe:

* Permitir expresar el Lenguaje Ubicuo mediante tipos y capacidades explícitas.
* Proteger a la Iniciativa como Aggregate Root principal.
* Mantener las reglas del dominio separadas de la API y la persistencia.
* Permitir construir una API con contratos claros.
* Favorecer validaciones automatizadas.
* Proporcionar soporte de largo plazo y actualizaciones de seguridad.
* Integrarse al monorepo sin acoplarse al Frontend.
* Permitir adaptar persistencia e integraciones al dominio.
* Evitar complejidad distribuida antes de contar con una necesidad validada.
* Mantener una ruta de actualización soportada.

La familiaridad del equipo, la plataforma de despliegue, el motor de persistencia y los requerimientos no funcionales específicos permanecen Pendientes de validación.

---

# 3. Opciones Consideradas

## 3.1 .NET 10 con ASP.NET Core

Construir el Backend con .NET 10, C# y ASP.NET Core.

### Ventajas

* .NET 10 es una versión de soporte de largo plazo.
* C# permite representar reglas, estados y Objetos de Valor mediante tipos explícitos.
* ASP.NET Core proporciona capacidades para construir Web APIs.
* La plataforma integra compilación, pruebas, configuración, inyección de dependencias y observabilidad básica.
* Permite mantener el dominio en componentes que no dependan directamente de ASP.NET Core.
* Ofrece una ruta oficial de mantenimiento y actualización.

### Desventajas

* Requiere mantener el runtime y el SDK actualizados dentro de la versión soportada.
* Sus capacidades pueden incentivar abstracciones y capas innecesarias si no se prioriza la simplicidad.
* El equipo deberá dominar C#, .NET y ASP.NET Core.
* La integración con bibliotecas específicas puede introducir acoplamiento si no se mantienen límites explícitos.

## 3.2 Node.js con TypeScript y NestJS

Construir el Backend con Node.js, TypeScript y NestJS.

### Ventajas

* Permite utilizar TypeScript en Frontend y Backend.
* Proporciona convenciones para módulos, inyección de dependencias y endpoints.
* Cuenta con un ecosistema amplio para aplicaciones web.

### Desventajas

* Compartir lenguaje con el Frontend no garantiza compartir correctamente el dominio.
* La flexibilidad del ecosistema exige gobernar versiones y bibliotecas adicionales.
* Los tipos de TypeScript no existen por sí mismos durante la ejecución.
* No existe una necesidad aprobada que exija una única plataforma de lenguaje en ambos componentes.

## 3.3 Java con Spring Boot

Construir el Backend con Java y Spring Boot.

### Ventajas

* Ofrece tipos explícitos y un ecosistema consolidado para aplicaciones corporativas.
* Proporciona capacidades para Web APIs, configuración, validación e integración.
* Permite separar el dominio de los adaptadores tecnológicos.

### Desventajas

* Incorpora otra plataforma y ecosistema que el equipo deberá mantener.
* Puede introducir configuración y abstracciones adicionales.
* No presenta una ventaja validada frente a .NET 10 para las necesidades aprobadas.

---

# 4. Decisión

El Backend de Arauco Project Hub se implementará con .NET 10, C# y ASP.NET Core 10.

La decisión se aplicará bajo las siguientes condiciones:

1. .NET y ASP.NET Core serán detalles tecnológicos del Backend y no definirán conceptos ni reglas del dominio.
2. El código que representa el dominio utilizará el Lenguaje Ubicuo.
3. La Iniciativa mantendrá su responsabilidad como Aggregate Root principal.
4. Las reglas del dominio no dependerán directamente de ASP.NET Core, del acceso a datos ni de servicios externos.
5. La API expresará capacidades del dominio y no expondrá directamente estructuras de persistencia.
6. Los contratos de entrada y salida serán explícitos y estarán separados de las entidades del dominio.
7. La persistencia y las integraciones se adaptarán al dominio mediante límites definidos.
8. El Backend mantendrá validaciones automatizadas propias dentro del monorepo.
9. La versión mayor será .NET 10; las versiones de corrección deberán mantenerse actualizadas para conservar soporte.
10. Las bibliotecas adicionales se incorporarán únicamente cuando exista una necesidad validada.

La decisión no selecciona Entity Framework Core, un motor de base de datos, Controllers, Minimal APIs ni una arquitectura de capas específica.

---

# 5. Consecuencias

## 5.1 Consecuencias Positivas

* El dominio puede expresarse mediante tipos explícitos de C#.
* La plataforma cuenta con soporte LTS y actualizaciones oficiales.
* ASP.NET Core proporciona una base integrada para la API.
* Las pruebas pueden ejecutarse con herramientas del SDK.
* El Backend puede evolucionar dentro del monorepo manteniendo validaciones independientes.
* La persistencia y las integraciones pueden definirse posteriormente sin redefinir el dominio.

## 5.2 Costos y Restricciones

* El equipo deberá conocer C#, .NET 10 y ASP.NET Core 10.
* Los entornos de desarrollo, integración y producción deberán mantener versiones soportadas.
* Será necesario instalar oportunamente las actualizaciones de corrección.
* Las convenciones del framework no deberán convertirse automáticamente en límites del dominio.
* La selección de bibliotecas deberá evitar duplicar capacidades de la plataforma sin justificación.

## 5.3 Riesgos

### Dominio acoplado a ASP.NET Core

Las entidades y reglas podrían depender de endpoints, atributos o tipos del framework.

Mitigación:

* Mantener el dominio independiente de ASP.NET Core.
* Traducir contratos de API en los límites del Backend.
* Verificar dependencias mediante pruebas y revisión de arquitectura.

### Persistencia como fuente del modelo

Las estructuras relacionales podrían determinar la forma del dominio.

Mitigación:

* Aplicar SRS-010, el DER y el Diccionario de Datos como derivados del dominio.
* Mantener el acceso a datos fuera de las reglas del dominio.
* No exponer entidades de persistencia directamente en la API.

### Complejidad accidental

El ecosistema permite incorporar múltiples patrones, capas y bibliotecas.

Mitigación:

* Comenzar con la estructura mínima que proteja el dominio.
* Justificar cada abstracción mediante una necesidad concreta.
* Evitar implementar capacidades para escenarios hipotéticos.

### Dependencia de una versión

.NET 10 tiene un ciclo de soporte definido.

Mitigación:

* Mantener las actualizaciones de corrección.
* Planificar la actualización de versión antes del fin de soporte.
* Evitar APIs descontinuadas sin una necesidad justificada.

---

# 6. Criterios de Cumplimiento

La implementación de esta decisión cumple cuando:

* Utiliza .NET 10, C# y ASP.NET Core 10.
* Utiliza el Lenguaje Ubicuo para representar conceptos del dominio.
* Mantiene a la Iniciativa como Aggregate Root principal.
* Mantiene las reglas del dominio fuera de endpoints, persistencia e integraciones.
* Utiliza contratos de API explícitos.
* No expone directamente estructuras de persistencia.
* Mantiene validaciones automatizadas propias.
* Mantiene versiones soportadas y actualizadas.
* Justifica las bibliotecas y abstracciones adicionales.
* Conserva trazabilidad hacia los documentos aprobados.

---

# 7. Cuándo Revisar esta Decisión

Esta decisión deberá revisarse si:

* .NET 10 se aproxima al fin de soporte sin una ruta de actualización aprobada.
* La plataforma de despliegue resulta incompatible con las capacidades requeridas.
* El equipo no puede mantener .NET y ASP.NET Core de forma sostenible.
* Los requerimientos de rendimiento o seguridad no pueden satisfacerse.
* La tecnología obliga a contradecir el Modelo de Dominio o el Modelo Operacional.

Una preferencia tecnológica aislada no constituye por sí sola una razón suficiente para sustituir la plataforma.

---

# 8. Trazabilidad

Este ADR deriva principalmente de:

* PHIL-001: FP-001, FP-002, FP-003, FP-004, FP-006, FP-009, FP-011 y FP-012.
* SRS-001: propósito, alcance y principios de diseño.
* SRS-002: Lenguaje Ubicuo.
* SRS-003: Modelo de Dominio y reglas del dominio.
* SRS-004: Modelo Operacional y reglas operacionales.
* SRS-010: Modelo Relacional derivado del dominio.
* ADR-001: arquitectura derivada del dominio.
* ADR-002: organización en monorepo con límites y validaciones por componente.
* ADR-003: contratos explícitos entre Frontend y API.

---

# 9. Fuentes Técnicas Consultadas

* [Novedades de .NET 10](https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-10/overview).
* [Política oficial de soporte de .NET](https://dotnet.microsoft.com/es-es/platform/support/policy/dotnet-core).
* [Creación de Web APIs con ASP.NET Core 10](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0).
* [Arquitecturas comunes de aplicaciones web con .NET](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures).

Las fuentes técnicas respaldan las capacidades y el ciclo de soporte considerados. La decisión se fundamenta en las necesidades y principios aprobados de Arauco Project Hub.

---

# 10. Decisiones Posteriores

Este ADR deberá orientar, sin anticiparlas, las decisiones sobre:

* Arquitectura interna del Backend.
* Diseño de la API.
* Estrategia de persistencia.
* Tecnología de persistencia.
* Autenticación y autorización.
* Integraciones.
* Observabilidad.
* Estrategia de pruebas del Backend.
* Despliegue del Backend.

Cada decisión importante deberá documentarse mediante un ADR cuando corresponda.

---

# 11. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para la tecnología principal del Backend de Arauco Project Hub.
