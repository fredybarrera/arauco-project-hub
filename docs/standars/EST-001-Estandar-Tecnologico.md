# Arauco Project Hub

## Engineering Playbook

# EST-001 - Estándar Tecnológico

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Objetivo

Este documento consolida las tecnologías y versiones mayores aprobadas para implementar Arauco Project Hub, junto con sus condiciones de uso y límites.

El estándar permite verificar que la implementación utilice una base tecnológica coherente sin duplicar las decisiones y fundamentos contenidos en los ADR.

---

# 2. Alcance

Este documento establece:

* Las tecnologías aprobadas para el Frontend, Backend, persistencia y observabilidad.
* La política general de versiones.
* Las condiciones y límites que deben respetar las implementaciones.
* Las tecnologías y definiciones que permanecen Pendientes.

Este documento no:

* Modifica decisiones arquitectónicas aprobadas.
* Define conceptos, reglas ni estados del dominio.
* Selecciona herramientas que no hayan sido aprobadas.
* Define la estructura física del monorepo.
* Define infraestructura, despliegue o automatización de entrega.
* Sustituye los ADR ni los documentos de arquitectura.

---

# 3. Principios

## 3.1 El dominio tiene prioridad

La tecnología debe servir al dominio y no definirlo.

La implementación debe utilizar el Lenguaje Ubicuo y mantener a la Iniciativa como Aggregate Root principal. Ningún framework, biblioteca, servicio o convención puede introducir conceptos o reglas no aprobados.

## 3.2 Una necesidad antes que una dependencia

Toda dependencia adicional debe responder a una necesidad validada. No se incorporarán bibliotecas, servicios o abstracciones para anticipar escenarios hipotéticos.

## 3.3 Versiones soportadas y controladas

Las versiones mayores aprobadas se mantienen fijas hasta que un ADR las revise. Las versiones menores y de corrección deben actualizarse de manera controlada, verificando compatibilidad, seguridad y pruebas.

No se utilizarán versiones sin soporte en desarrollo, integración o Producción.

## 3.4 Límites explícitos

El Frontend, Backend, persistencia, identidad y observabilidad deben conservar responsabilidades explícitas. Compartir un monorepo no autoriza dependencias directas entre componentes.

---

# 4. Base Tecnológica Aprobada

| Área | Tecnología o estándar | Versión aprobada | Fuente |
| --- | --- | --- | --- |
| Organización | Monorepo Git | No aplica | ADR-002 |
| Frontend | Nuxt | 4 | ADR-003 |
| Frontend | Vue | 3 | ADR-003 |
| Frontend | TypeScript | Pendiente de versión concreta | ADR-003 |
| Ejecución de servidor del Frontend | Node.js | Compatible con Nuxt 4; versión concreta Pendiente | ADR-003 y ADR-007 |
| Backend | .NET | 10 | ADR-004 |
| Backend | C# | Correspondiente a .NET 10 | ADR-004 |
| API | ASP.NET Core | 10 | ADR-004 |
| Persistencia | Azure SQL Database | Servicio administrado; configuración Pendiente | ADR-006 |
| Acceso a datos | Entity Framework Core | 10 | ADR-006 |
| Identidad | Proveedor corporativo con protocolo federado estándar | Proveedor y protocolo Pendientes de confirmación | ADR-005 |
| Sesión | Sesión mediada por el servidor de Nuxt | Mecanismo concreto Pendiente de confirmación | ADR-005 |
| Observabilidad de servidor | OpenTelemetry con distribución de Azure Monitor | Versiones concretas Pendientes | ADR-007 |
| Observabilidad de navegador | SDK JavaScript de Application Insights | Versión concreta Pendiente | ADR-007 |
| Plataforma de observabilidad | Azure Monitor Application Insights y Log Analytics | Servicio administrado; configuración Pendiente | ADR-007 |
| Correlación | W3C Trace Context | Estándar vigente compatible | ADR-007 |

Una versión marcada como Pendiente no puede fijarse por conveniencia dentro de la implementación. Debe seleccionarse durante la preparación técnica, respetando compatibilidad, soporte y las fuentes aprobadas.

---

# 5. Frontend

El Frontend debe:

* Utilizar Nuxt 4, Vue 3 y TypeScript.
* Mantener reglas del dominio fuera de páginas, componentes, middleware, estado del cliente y capacidades de servidor de Nuxt.
* Utilizar contratos explícitos para comunicarse con la API.
* Mantener separadas presentación, coordinación de capacidades y comunicación con la API.
* Utilizar el Lenguaje Ubicuo cuando represente conceptos del dominio.
* Mantener un estado de interfaz mínimo y con fuente reconocible.
* Incorporar componentes reutilizables solo ante una necesidad repetida y estable.
* Mantener validaciones automatizadas propias.

El modo de renderizado, la biblioteca de componentes, la biblioteca de estado, la estructura física de carpetas y las herramientas de pruebas permanecen Pendientes.

Las capacidades del servidor de Nuxt no reemplazan al Backend ni autorizan duplicar reglas del dominio.

---

# 6. Backend y API

El Backend debe:

* Utilizar .NET 10, C# y ASP.NET Core 10.
* Mantener el Modelo de Dominio independiente de ASP.NET Core, persistencia e integraciones.
* Expresar capacidades mediante contratos explícitos separados de las entidades del dominio.
* Mantener a la API como adaptador de entrada.
* Evitar exponer estructuras de persistencia.
* Mantener dependencias dirigidas hacia el dominio.
* Incorporar bibliotecas adicionales solo cuando exista una necesidad validada.
* Mantener validaciones automatizadas propias.

La elección entre Controllers y Minimal APIs, la estructura física de proyectos y las bibliotecas de pruebas permanecen Pendientes.

---

# 7. Persistencia

La persistencia debe:

* Utilizar Azure SQL Database.
* Utilizar Entity Framework Core 10 y su proveedor oficial para Azure SQL como mecanismo principal de acceso a datos.
* Implementar el Modelo Relacional, el DER y el Diccionario de Datos aprobados.
* Mantener Entity Framework Core fuera del dominio.
* Definir mapeos explícitos dentro de la adaptación de persistencia.
* Evitar la carga automática implícita de relaciones.
* Utilizar proyecciones sin seguimiento para consultas que no modifican el Aggregate cuando corresponda.
* Aplicar concurrencia optimista según ADR-006.
* Mantener migraciones versionadas y trazables.
* No aplicar migraciones automáticamente al iniciar en Producción.
* Confirmar o revertir conjuntamente los cambios del Aggregate y su Historial cuando pertenecen a la misma operación.

SQL explícito solo puede incorporarse cuando una medición demuestre que Entity Framework Core no produce una consulta adecuada.

La capacidad, redundancia, respaldo, retención, recuperación, conectividad e identidad de acceso permanecen Pendientes de requisitos y validaciones operacionales.

---

# 8. Identidad y Sesión

La implementación debe:

* Utilizar un proveedor corporativo de identidad mediante un protocolo federado estándar.
* No administrar contraseñas dentro de Arauco Project Hub.
* Utilizar un flujo basado en redirección.
* Preferir una sesión mediada por el servidor de Nuxt.
* Mantener credenciales fuera del código del navegador.
* Utilizar una referencia de sesión protegida para la interacción del navegador.
* Mantener en el Backend la validación de identidad y la autorización contextual.
* Mantener identidad, Participante y Rol de Participación como responsabilidades distintas.

El proveedor, protocolo, flujo definitivo, duración, renovación, invalidación y políticas corporativas de sesión permanecen Pendientes de confirmación.

Si la plataforma de despliegue no permite ejecución de servidor para Nuxt, se debe revisar ADR-005 antes de implementar otra estrategia.

---

# 9. Observabilidad

La implementación debe:

* Utilizar Azure Monitor Application Insights conectado a Log Analytics.
* Utilizar OpenTelemetry en ASP.NET Core y en el servidor de Nuxt ejecutado sobre Node.js.
* Utilizar W3C Trace Context para propagar el contexto de trazas.
* Utilizar el SDK JavaScript de Application Insights únicamente para la telemetría del navegador.
* Mantener la instrumentación fuera del Modelo de Dominio.
* Mantener registros estructurados y correlacionados.
* Separar recursos por Ambiente.
* Preferir identidad administrada y Microsoft Entra ID para la ingesta de servidor cuando la plataforma lo permita.
* Mantener observabilidad e Historial separados.
* Evitar credenciales, secretos y datos sensibles completos en las señales.
* No incorporar un OpenTelemetry Collector sin una necesidad validada.

El muestreo, retención, límites de costo, métricas personalizadas, alertas, tableros y niveles de registro permanecen Pendientes de mediciones y objetivos operacionales.

---

# 10. Gestión de Dependencias y Versiones

Toda incorporación o actualización debe:

1. Mantener compatibilidad con las versiones mayores aprobadas.
2. Utilizar una versión con soporte vigente.
3. Revisar vulnerabilidades y avisos de seguridad conocidos.
4. Ejecutar las validaciones del componente afectado.
5. Mantener archivos de resolución de dependencias versionados cuando la herramienta los utilice.
6. Evitar rangos que permitan cambios mayores no controlados.
7. Registrar una decisión cuando el cambio altere la arquitectura, los límites o una tecnología aprobada.

Una actualización mayor de Nuxt, Vue, .NET, ASP.NET Core o Entity Framework Core requiere revisar el ADR correspondiente.

Las herramientas concretas para administrar paquetes, automatizar actualizaciones y coordinar tareas del monorepo permanecen Pendientes.

---

# 11. Tecnologías No Aprobadas

Este estándar no autoriza todavía:

* Una herramienta específica de gestión del monorepo.
* Una versión concreta de Node.js o TypeScript.
* Una biblioteca de componentes o estado para el Frontend.
* Una biblioteca adicional de acceso a datos.
* Un mecanismo diferente de persistencia.
* Un OpenTelemetry Collector.
* Una plataforma de despliegue.
* Una herramienta de infraestructura como código.
* Una plataforma o flujo de CI/CD.
* Una estrategia de contenedores.

Estas definiciones deben responder a necesidades aprobadas. Si alteran de forma importante la arquitectura, se debe proponer un ADR.

---

# 12. Criterios de Cumplimiento

Una implementación cumple este estándar cuando:

* Utiliza únicamente tecnologías aprobadas para cada responsabilidad.
* Respeta las versiones mayores definidas.
* Mantiene el Lenguaje Ubicuo y los límites del dominio.
* No incorpora dependencias sin una necesidad validada.
* Mantiene Frontend, Backend, persistencia y observabilidad desacoplados del Modelo de Dominio según los ADR.
* Mantiene versiones soportadas y actualizaciones controladas.
* Conserva trazabilidad desde la dependencia hasta su decisión aprobada.
* No resuelve definiciones Pendientes mediante supuestos.
* Propone un ADR cuando una selección modifica una decisión arquitectónica importante.

---

# 13. Trazabilidad

Este estándar deriva principalmente de:

* PHIL-001: FP-005, FP-009, FP-010, FP-011 y FP-012.
* SRS-002 - Lenguaje Ubicuo.
* SRS-006 - Requerimientos No Funcionales.
* ADR-001 - Arquitectura Basada en el Negocio.
* ADR-002 - Monorepo.
* ADR-003 - Frontend con Nuxt 4.
* ADR-004 - Backend con .NET 10.
* ADR-005 - Proveedor de Identidad y Estrategia de Sesión.
* ADR-006 - Tecnología y Estrategia de Persistencia.
* ADR-007 - Plataforma y Estándar de Observabilidad.
* Arquitectura del Frontend.
* Arquitectura del Backend.
* Arquitectura de Seguridad.
* Autenticación.
* Arquitectura de Persistencia.
* Arquitectura de Observabilidad.

---

# 14. Validaciones de Implementación

* Confirmar si la Fase 2 - Architecture puede cerrarse sin definir todavía Infraestructura y Despliegue.
* Confirmar las plataformas corporativas permitidas.
* Confirmar el proveedor, protocolo y políticas de identidad y sesión.
* Confirmar la plataforma de despliegue del Frontend y Backend.
* Definir las versiones iniciales soportadas de Node.js y TypeScript.
* Validar compatibilidad entre las versiones iniciales seleccionadas.
* Confirmar si las herramientas de construcción y gestión de paquetes deben formar parte de este estándar o de un estándar posterior.

---

# 15. Siguiente Paso

Después de aprobar EST-001, el siguiente documento propuesto es:

EST-002 - Estándar Azure.

Objetivo:

Definir las condiciones comunes para utilizar los servicios Azure ya aprobados, sin seleccionar todavía una plataforma de despliegue ni incorporar servicios no respaldados por una decisión arquitectónica.

---

# 16. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para las tecnologías, versiones mayores, condiciones de uso y límites tecnológicos de Arauco Project Hub.
