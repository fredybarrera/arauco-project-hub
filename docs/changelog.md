# Changelog

Este documento registra los hitos formales alcanzados por el Engineering Playbook de Arauco Project Hub.

---

## 2026-06-30

### ADR-010 - Relación entre Identidad Corporativa y Participante

**Documento aprobado:** ADR-010 - Relación entre Identidad Corporativa y Participante

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se mantuvieron separadas identidad autenticada, Participante, Rol de Participación y permisos.
* Se adoptaron tenant y object identifier como datos técnicos opcionales y conjuntos de Participante.
* Se exigió unicidad de la combinación dentro de una Iniciativa.
* Se conservó el significado de la Identificación de la persona o equipo.
* Se prohibió utilizar correo o nombre como claves de autorización.
* Se descartó el aprovisionamiento automático de Participantes.
* Se descartó inicialmente un registro global de identidades por complejidad innecesaria.
* Se mantuvo fuera del alcance la autorización de personas por pertenencia a equipos.
* Se exigieron revisiones controladas de SRS-010, DER y Diccionario de Datos.
* Se definió la revisión 1.1 de SRS-010 como siguiente documento.

---

### Sprint 1 - Implementación de CU-002

**Documento aprobado:** Sprint 1 - Implementación de CU-002

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió el resultado esperado para implementar CU-002.
* Se ordenó la entrega en base del monorepo, persistencia, Backend, API, autenticación, Frontend y recorrido integrado.
* Se exigió evidencia verificable para cada parte de la secuencia.
* Se mantuvo la consulta limitada a Negocio, nombre y Estado de Iniciativa.
* Se conservaron fuera del alcance el registro, actualización y cambio de Estado de Iniciativa.
* Se prohibió asumir que la identificación existente del Participante equivale a la identidad corporativa.
* Se exigió resolver mediante ADR la relación entre identidad corporativa y Participante.
* Se definió ADR-010 - Relación entre Identidad Corporativa y Participante como siguiente documento.

---

### Sprint 0 - Primera Capacidad Trazable

**Documento aprobado:** Sprint 0 - Primera Capacidad Trazable

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se seleccionó CU-002 - Consultar una Iniciativa como primera capacidad trazable.
* Se limitó la consulta a un Participante autenticado que participa en la Iniciativa.
* Se incorporó trazabilidad hacia RF-002, RF-003, MP-001, MP-004 y FN-002.
* Se definió un recorrido vertical que incluye Frontend, API, Backend, persistencia y autenticación.
* Se mantuvieron fuera del alcance el registro, la actualización y los cambios de Estado de Iniciativa.
* Se exigió no exponer información cuando el actor no participa en la Iniciativa.
* Se establecieron criterios de aceptación para seguridad, límites arquitectónicos, pruebas y observabilidad.
* Se definió Sprint 1 - Implementación de CU-002 como siguiente documento.

---

### ADR-009 - Autenticación y Sesión para Frontend Estático

**Documento aprobado:** ADR-009 - Autenticación y Sesión para Frontend Estático

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se confirmó Microsoft Entra ID como proveedor corporativo.
* Se adoptó OAuth 2.0 Authorization Code con PKCE para el Frontend estático.
* Se definió un registro de aplicación sin secreto para el Frontend y un recurso protegido para la API.
* Se exigió validar firma, emisor, audiencia y vigencia de cada token en el Backend.
* Se adoptó tenant y object identifier como identidad corporativa estable.
* Se mantuvieron separados identidad, Participante, Rol de Participación y autorización.
* Se prohibió utilizar grupos o roles externos como permisos del dominio.
* Se definió el almacenamiento inicial de tokens únicamente en memoria.
* Se mantuvo el enlace entre Azure Static Web Apps y Azure Container Apps como restricción adicional de ingreso.
* Se supersedió la estrategia de sesión mediada por servidor Nuxt definida en ADR-005.
* Se definió la preparación de la primera capacidad trazable de implementación como siguiente paso.

---

### ADR-008 - Plataforma y Estrategia de Despliegue

**Documento aprobado:** ADR-008 - Plataforma y Estrategia de Despliegue

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se seleccionó Azure Static Web Apps para desplegar el Frontend estático con Nuxt 4.
* Se seleccionó Azure Container Apps para desplegar la API y el Backend con ASP.NET Core 10.
* Se seleccionó Azure Container Registry como repositorio privado de imágenes.
* Se descartó explícitamente Azure App Service.
* Se definieron imágenes inmutables, revisiones controladas y reversión mediante tráfico.
* Se seleccionaron Azure Key Vault, identidades administradas, federación de GitHub Actions y Bicep.
* Se definió un Container Apps Job manual para ejecutar migraciones.
* Se documentaron las restricciones del Backend enlazado bajo `/api`.
* Se exigió revisar ADR-005 antes de implementar autenticación y sesión.
* Se definió ADR-009 - Autenticación y Sesión para Frontend Estático como el siguiente documento.

---

### EST-005 - CI/CD

**Documento aprobado:** EST-005 - CI/CD

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió el flujo de integración y entrega continua del monorepo.
* Se adoptó GitHub Actions como plataforma de automatización, sujeta a disponibilidad corporativa durante la implementación.
* Se establecieron validaciones para Engineering Playbook, Frontend, Backend, contratos, persistencia y seguridad.
* Se exigieron construcciones reproducibles y artefactos inmutables relacionados con un commit.
* Se definió la promoción controlada de la misma Versión entre Desarrollo, QAS y PRD.
* Se exigieron aprobación explícita, verificación posterior y estrategia de reversión antes de PRD.
* Se gobernaron permisos, secretos, migraciones, evidencia y reintentos.
* Se completó la Fase 3 - Standards.
* Se definió ADR-008 - Plataforma y Estrategia de Despliegue como el siguiente documento del Engineering Playbook.

---

### EST-004 - Convención de Nombres

**Documento aprobado:** EST-004 - Convención de Nombres

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se estableció el Lenguaje Ubicuo como fuente oficial de los nombres del dominio.
* Se definieron transformaciones técnicas consistentes para documentación, C#, TypeScript, Vue, Nuxt, API y persistencia.
* Se fijaron convenciones para títulos y nombres físicos de nuevos documentos.
* Se definieron rutas en minúsculas, contratos JSON en camelCase y nombres físicos de persistencia en singular con guion bajo.
* Se aprobaron representaciones técnicas para Ambientes y el identificador técnico `aph`.
* Se propuso un patrón lógico para nombres de recursos Azure, sujeto a sus restricciones y políticas corporativas.
* Se gobernaron nombres de ramas, abreviaturas y nombres prohibidos.
* Se definió EST-005 - CI/CD como el siguiente documento del Engineering Playbook.

---

### EST-003 - Convención de Repositorios

**Documento aprobado:** EST-003 - Convención de Repositorios

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió el alcance del monorepo como repositorio exclusivo de Arauco Project Hub.
* Se estableció la organización de primer nivel para documentación, Frontend, Backend, automatización y pruebas transversales.
* Se protegieron los límites y la dirección de dependencias entre Frontend y Backend.
* Se gobernó la incorporación de código compartido y nuevas carpetas de primer nivel.
* Se definieron los archivos que deben y no deben versionarse.
* Se adoptó Conventional Commits para los mensajes de commit.
* Se establecieron convenciones mínimas para ramas, revisiones y validaciones por componente.
* Se definió EST-004 - Convención de Nombres como el siguiente documento del Engineering Playbook.

---

### EST-002 - Estándar Azure

**Documento aprobado:** EST-002 - Estándar Azure

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron las condiciones comunes para utilizar los servicios Azure aprobados.
* Se limitó el estándar a Azure SQL Database, Azure Monitor Application Insights, Log Analytics y las capacidades de identidad ya respaldadas.
* Se exigió separar recursos, configuración, acceso y señales por Ambiente.
* Se establecieron menor privilegio, preferencia por identidad administrada y protección de secretos.
* Se documentaron condiciones para persistencia, observabilidad, protección de información, continuidad y costos.
* Se prohibió incorporar servicios Azure o topologías no respaldados por una decisión aprobada.
* Se mantuvieron explícitas las validaciones corporativas y operacionales necesarias para la implementación.
* Se definió EST-003 - Convención de Repositorios como el siguiente documento del Engineering Playbook.

---

### EST-001 - Estándar Tecnológico

**Documento aprobado:** EST-001 - Estándar Tecnológico

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se consolidaron las tecnologías y versiones mayores aprobadas para Frontend, Backend, persistencia, identidad y observabilidad.
* Se estableció que las versiones menores y de corrección deben actualizarse de manera controlada y permanecer soportadas.
* Se documentaron las condiciones y límites de Nuxt 4, Vue 3, .NET 10, ASP.NET Core 10 y Entity Framework Core 10.
* Se mantuvieron el Lenguaje Ubicuo, la Iniciativa y el Modelo de Dominio independientes de frameworks y servicios.
* Se gobernó la incorporación de dependencias y se exigió revisar los ADR ante cambios mayores.
* Se conservaron explícitas las tecnologías y definiciones todavía no aprobadas.
* Se cerró la Fase 2 - Architecture y se inició la Fase 3 - Standards.
* Se definió EST-002 - Estándar Azure como el siguiente documento del Engineering Playbook.

---

## 2026-06-28

### ADR-007 - Plataforma y Estándar de Observabilidad

**Documento aprobado:** ADR-007 - Plataforma y Estándar de Observabilidad

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se seleccionó Azure Monitor Application Insights como plataforma principal.
* Se adoptó OpenTelemetry para los componentes de servidor.
* Se adoptó W3C Trace Context para correlación.
* Se definió el SDK JavaScript de Application Insights como excepción para el navegador.
* Se aisló la telemetría del navegador cuando requiera autenticación local.
* Se evitó incorporar un OpenTelemetry Collector sin una necesidad validada.
* Se establecieron controles para identidad, muestreo, volumen, costo y protección de información.
* Se definió EST-001 - Estándar Tecnológico como el siguiente documento, sujeto a la revisión de cierre de Architecture.

---

### Arquitectura de Observabilidad

**Documento aprobado:** Arquitectura de Observabilidad

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron registros, métricas y trazas con responsabilidades diferenciadas.
* Se estableció correlación entre Frontend, API, Backend y adaptaciones.
* Se mantuvo la observabilidad separada del Historial.
* Se definieron señales para disponibilidad, errores, rendimiento, recursos y dependencias.
* Se establecieron responsabilidades para Frontend, API, Backend, persistencia e identidad.
* Se limitaron datos sensibles, credenciales, secretos y dimensiones de alta variabilidad.
* Se documentaron criterios para errores, fallos de observabilidad, pruebas y Ambientes.
* Se definió ADR-007 - Plataforma y Estándar de Observabilidad como el siguiente documento del Engineering Playbook.

---

### Arquitectura de Persistencia

**Documento aprobado:** Arquitectura de Persistencia

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron los límites y responsabilidades de la adaptación de persistencia.
* Se separaron los flujos de modificación y consulta.
* Se estableció la reconstrucción explícita del contexto requerido por cada capacidad.
* Se mantuvo Entity Framework Core fuera del dominio y de los contratos externos.
* Se definieron concurrencia optimista y transacciones locales por modificación de una Iniciativa.
* Se gobernó la evolución del esquema mediante migraciones versionadas y revisadas.
* Se establecieron criterios para integridad, errores, seguridad, observabilidad y pruebas.
* Se definió Arquitectura de Observabilidad como el siguiente documento del Engineering Playbook.

---

### ADR-006 - Tecnología y Estrategia de Persistencia

**Documento aprobado:** ADR-006 - Tecnología y Estrategia de Persistencia

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se seleccionaron Azure SQL Database y Entity Framework Core 10.
* Se mantuvo el dominio independiente de la tecnología de persistencia.
* Se definió reconstruir únicamente el contexto del Aggregate requerido por cada capacidad.
* Se adoptó concurrencia optimista mediante un valor técnico de versión.
* Se estableció consistencia transaccional entre el cambio del Aggregate y su Historial.
* Se definieron proyecciones sin seguimiento para consultas.
* Se estableció una evolución versionada y controlada del esquema.
* Se definió Arquitectura de Persistencia como el siguiente documento del Engineering Playbook.

---

### ADR-005 - Proveedor de Identidad y Estrategia de Sesión

**Documento aprobado:** ADR-005 - Proveedor de Identidad y Estrategia de Sesión

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se evaluaron identidad local, credencial manejada por el navegador y sesión mediada por el Frontend.
* Se decidió utilizar un proveedor corporativo mediante identidad federada.
* Se estableció que Arauco Project Hub no administrará contraseñas.
* Se prefirió una sesión mediada por el servidor de Nuxt para reducir exposición de credenciales.
* Se mantuvo la autorización contextual dentro del Backend.
* Se evitó convertir grupos externos en una segunda fuente de permisos.
* Se documentaron consecuencias, riesgos, criterios de cumplimiento y validaciones de implementación.
* Se definió ADR-006 - Tecnología y Estrategia de Persistencia como el siguiente documento del Engineering Playbook.

---

### Autenticación

**Documento aprobado:** Autenticación

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió el contrato general de autenticación entre Frontend y API.
* Se separaron identidad, sesión, autorización y reglas del dominio.
* Se establecieron responsabilidades para proveedor, Frontend, API y Backend.
* Se documentaron inicio, continuidad, expiración y cierre.
* Se prohibió utilizar identificadores libres del consumidor como identidad responsable.
* Se definieron criterios para errores, protección, observabilidad y pruebas.
* Se mantuvieron proveedor, protocolo y estrategia de sesión como decisiones Pendientes.
* Se definió ADR-005 - Proveedor de Identidad y Estrategia de Sesión como el siguiente documento del Engineering Playbook.

---

### Arquitectura de Seguridad

**Documento aprobado:** Arquitectura de Seguridad

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron los límites de seguridad entre Frontend, API y Backend.
* Se separaron autenticación, autorización, reglas del dominio, Historial y observabilidad.
* Se estableció autorización contextual por Iniciativa en el Backend.
* Se definieron responsabilidades para identidad, sesiones, protección de datos y secretos.
* Se documentaron amenazas iniciales, pruebas y criterios de cumplimiento.
* Se mantuvieron proveedor, protocolo y estrategia de sesión como decisiones Pendientes.
* Se exigió formalizar mediante ADR las decisiones tecnológicas importantes de seguridad.
* Se definió Autenticación como el siguiente documento del Engineering Playbook.

---

### SRS-009 - Casos de Uso

**Documento aprobado:** SRS-009 - Casos de Uso

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron trece Casos de Uso verificables.
* Se cubrieron registro, consulta y actualización de Iniciativas.
* Se incorporaron Participantes, Componentes, Recursos, Documentos y Conversaciones.
* Se documentaron cambios de estado, validación en QAS, Versiones y Despliegues.
* Se cubrieron registro y evolución de Solicitudes y consulta del Historial.
* Se incorporó una matriz de cobertura hacia Flujos de Negocio y Requerimientos Funcionales.
* Se mantuvieron explícitamente Pendientes las interacciones cuya autoridad o transición aún no está aprobada.
* Se definió Arquitectura de Seguridad como el siguiente documento del Engineering Playbook.

---

### SRS-008 - Flujos de Negocio

**Documento aprobado:** SRS-008 - Flujos de Negocio

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron nueve Flujos de Negocio de extremo a extremo.
* Se cubrieron registro, consulta, evaluación, preparación, Desarrollo, QAS y Producción.
* Se mantuvo la continuidad de la Iniciativa hacia Operación.
* Se documentaron el registro y la atención de Solicitudes.
* Se estableció que Cancelar o Cerrar no elimina la memoria trazable.
* Se integraron permisos, reglas, alternativas, resultados e Historial.
* Se mantuvieron explícitos los pasos que dependen de definiciones Pendientes.
* Se definió SRS-009 - Casos de Uso como el siguiente documento del Engineering Playbook.

---

### SRS-007 - Modelo de Permisos

**Documento aprobado:** SRS-007 - Modelo de Permisos

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió un Modelo de Permisos contextual por Iniciativa.
* Se separaron identidad, Participante y Rol de Participación.
* Se establecieron transparencia, menor privilegio y autorización en el Backend.
* Se documentaron 31 reglas para consulta y acciones aprobadas.
* Se definieron permisos sobre Iniciativas, Recursos, Documentos, Conversaciones, Solicitudes, Versiones y Despliegues.
* Se prohibió modificar el Historial para sustituir lo ocurrido.
* Se mantuvieron denegadas las capacidades cuya autoridad permanece Pendiente.
* Se definió SRS-008 - Flujos de Negocio como el siguiente documento del Engineering Playbook.

---

### SRS-006 - Requerimientos No Funcionales

**Documento aprobado:** SRS-006 - Requerimientos No Funcionales

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron 48 Requerimientos No Funcionales.
* Se cubrieron seguridad, privacidad, disponibilidad, rendimiento e integridad.
* Se incorporaron accesibilidad, compatibilidad, observabilidad, mantenibilidad y recuperación.
* Se definieron mecanismos de verificación y evidencia.
* Se mantuvieron separadas las necesidades de calidad de las decisiones tecnológicas.
* Se dejaron Pendientes los umbrales cuantitativos que requieren validación responsable.
* Se exigió documentar mediante ADR las decisiones arquitectónicas importantes derivadas.
* Se definió SRS-007 - Modelo de Permisos como el siguiente documento del Engineering Playbook.

---

### SRS-005 - Requerimientos Funcionales

**Documento aprobado:** SRS-005 - Requerimientos Funcionales

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron 38 Requerimientos Funcionales verificables.
* Se cubrieron Iniciativas, Participantes, Componentes, Recursos, Documentos y Conversaciones.
* Se definieron capacidades para el ciclo de vida de la Iniciativa y de sus Solicitudes.
* Se incorporaron Versiones, Despliegues, Historial y soporte de múltiples Negocios.
* Se mantuvo separada la definición funcional del diseño de pantallas, API y persistencia.
* Se incorporaron criterios de aceptación y trazabilidad hacia los documentos aprobados.
* Se conservaron como Pendientes las definiciones que requieren revisar SRS de mayor prioridad.
* Se definió SRS-006 - Requerimientos No Funcionales como el siguiente documento del Engineering Playbook.

---

### Diseño de la API

**Documento aprobado:** Diseño de la API

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron los principios generales de diseño de la API.
* Se mantuvo a la Iniciativa como recurso y contexto principal.
* Se separaron contratos externos, coordinación, dominio y persistencia.
* Se establecieron criterios para consultas, acciones, validación, resultados y errores.
* Se definieron límites para concurrencia, idempotencia, versionado, seguridad y observabilidad.
* Se exigió trazabilidad desde cada operación hacia un requerimiento aprobado.
* Se mantuvo Pendiente el catálogo de endpoints hasta aprobar los Requerimientos Funcionales.
* Se definió SRS-005 - Requerimientos Funcionales como el siguiente documento del Engineering Playbook.

---

### Arquitectura del Frontend

**Documento aprobado:** Arquitectura del Frontend

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron las responsabilidades internas del Frontend con Nuxt 4, Vue 3 y TypeScript.
* Se separaron navegación y páginas, presentación, coordinación de capacidades, estado de interfaz y comunicación con la API.
* Se mantuvo a la Iniciativa como centro del contexto presentado.
* Se establecieron contratos explícitos y límites para la comunicación con la API.
* Se documentaron los flujos de consulta y acción.
* Se definieron criterios para validación, errores, seguridad, accesibilidad y pruebas.
* Se protegieron las reglas del dominio de páginas, componentes, middleware y estado del cliente.
* Se mantuvieron Pendientes el diseño de la API, renderizado, autenticación, estilos y estructura física.
* Se definió el Diseño de la API como el siguiente documento del Engineering Playbook.

---

### Arquitectura del Backend

**Documento aprobado:** Arquitectura del Backend

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron las responsabilidades internas del Backend con .NET 10.
* Se separaron entrada y API, coordinación, módulo Iniciativas y adaptaciones técnicas.
* Se estableció la dirección de dependencias hacia el dominio.
* Se documentaron los flujos de modificación y consulta.
* Se definieron criterios para consistencia, validación, errores, trazabilidad y pruebas.
* Se protegió al Modelo de Dominio de ASP.NET Core, persistencia e integraciones.
* Se mantuvieron Pendientes el diseño de API, persistencia, autenticación, observabilidad y estructura física.
* Se definió la Arquitectura del Frontend como el siguiente documento del Engineering Playbook.

---

### Modelo de Dominio Arquitectónico

**Documento aprobado:** Modelo de Dominio Arquitectónico

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió cómo expresar el Modelo de Dominio dentro del módulo Iniciativas.
* Se mantuvo a la Iniciativa como Aggregate Root principal y responsable de la consistencia.
* Se documentó la representación arquitectónica de entidades y Objetos de Valor.
* Se estableció que las reglas del dominio no dependen del Frontend, la API o la persistencia.
* Se definió la relación entre cambios de estado, eventos e Historial.
* Se documentaron las dependencias permitidas y la adaptación de persistencia.
* Se conservaron como Pendientes las ambigüedades y definiciones que requieren revisar los SRS.
* Se definió la Arquitectura del Backend como el siguiente documento del Engineering Playbook.

---

### Módulos

**Documento aprobado:** Módulos

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió un único módulo de dominio inicial denominado Iniciativas.
* Se mantuvo a la Iniciativa como Aggregate Root principal y centro del contexto.
* Se estableció que las entidades relacionadas no constituyen módulos independientes.
* Se documentaron las responsabilidades internas de Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial.
* Se definieron límites técnicos y dependencias permitidas para Frontend, API, persistencia e integraciones.
* Se establecieron criterios para proponer nuevos módulos.
* Se exigió formalizar mediante ADR cualquier cambio futuro que agregue o divida módulos.
* Se definió el Modelo de Dominio Arquitectónico como el siguiente documento del Engineering Playbook.

---

### Visión de Arquitectura

**Documento aprobado:** Visión de Arquitectura

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se consolidaron los drivers y principios arquitectónicos aprobados.
* Se documentó el contexto de Arauco Project Hub y su vista de alto nivel.
* Se definieron las responsabilidades del Frontend, API, Backend, dominio, persistencia e integraciones.
* Se establecieron dependencias permitidas y límites entre componentes.
* Se describió el flujo general de una interacción desde los actores hasta la persistencia.
* Se consolidaron las decisiones de monorepo, Nuxt 4 y .NET 10.
* Se mantuvieron explícitamente Pendientes las decisiones de arquitectura interna, persistencia, seguridad, observabilidad e infraestructura.
* Se definió Módulos como el siguiente documento del Engineering Playbook.

---

### ADR-004 - Backend con .NET 10

**Documento aprobado:** ADR-004 - Backend con .NET 10

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se evaluaron .NET 10 con ASP.NET Core, Node.js con TypeScript y NestJS, y Java con Spring Boot.
* Se decidió implementar el Backend con .NET 10, C# y ASP.NET Core 10.
* Se estableció que .NET y ASP.NET Core son detalles tecnológicos y no definen conceptos ni reglas del dominio.
* Se exigió mantener las reglas del dominio separadas de la API, la persistencia y las integraciones.
* Se definieron contratos de API explícitos y separados de las entidades del dominio.
* Se documentaron riesgos de acoplamiento al framework, persistencia como fuente del modelo y complejidad accidental.
* Se postergaron la persistencia, autenticación, estilo de endpoints y despliegue para decisiones posteriores.
* Se definió la Visión de Arquitectura como el siguiente documento del Engineering Playbook.

---

### ADR-003 - Frontend con Nuxt 4

**Documento aprobado:** ADR-003 - Frontend con Nuxt 4

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se evaluaron Vue 3 con Vite, Nuxt 4 y Next.js como bases tecnológicas del Frontend.
* Se decidió implementar el Frontend con Nuxt 4, Vue 3 y TypeScript.
* Se estableció que Nuxt es un detalle tecnológico y no define conceptos ni reglas del dominio.
* Se exigió separar la presentación, la comunicación con la API y las reglas del dominio.
* Se definieron contratos explícitos con la API mediante TypeScript.
* Se documentaron riesgos de acoplamiento al framework, lógica concentrada en páginas y complejidad de renderizado.
* Se postergaron el modo de renderizado y el despliegue hasta contar con requerimientos aprobados.
* Se definió ADR-004 - Backend con .NET 10 como el siguiente documento del Engineering Playbook.

---

### ADR-002 - Monorepo

**Documento aprobado:** ADR-002 - Monorepo

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se evaluaron repositorios separados, una organización híbrida y un monorepo.
* Se decidió mantener el Engineering Playbook y los componentes de Arauco Project Hub en un único repositorio Git.
* Se estableció que compartir repositorio no implica un despliegue único ni una única tecnología.
* Se exigieron límites, dependencias y validaciones explícitas para cada componente.
* Se protegió la trazabilidad entre documentación e implementación.
* Se documentaron riesgos de acoplamiento accidental, validaciones lentas y organización orientada por tecnología.
* Se definieron criterios para revisar la decisión si aparecen límites operacionales reales.
* Se definió ADR-003 - Frontend con Nuxt 4 como el siguiente documento del Engineering Playbook.

---

### Diccionario de Datos

**Documento aprobado:** Diccionario de Datos

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definieron los nombres físicos provisionales de las estructuras y datos representados en el DER.
* Se documentaron los significados, tipos lógicos, obligatoriedad y claves.
* Se describieron las referencias entre Negocio, Iniciativa y sus estructuras relacionadas.
* Se registraron los valores gobernados por el dominio y los valores que permanecen Pendientes.
* Se establecieron condiciones de integridad referencial derivadas de SRS-010 y del DER.
* Se mantuvieron fuera del alcance los tipos físicos, longitudes, índices y decisiones tecnológicas.
* Se incorporó trazabilidad hacia SRS-002, SRS-003, SRS-010, ADR-001 y el DER.
* Se definió ADR-002 - Monorepo como el siguiente documento del Engineering Playbook.

---

### DER - Diagrama de Entidad-Relación

**Documento aprobado:** DER - Diagrama de Entidad-Relación

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se representaron visualmente las estructuras y relaciones aprobadas en SRS-010.
* Se documentaron claves primarias, claves foráneas y atributos mínimos.
* Se definieron las cardinalidades entre las estructuras del Modelo Relacional.
* Se mantuvo a la Iniciativa como Aggregate Root principal.
* Se conservaron las relaciones necesarias para la trazabilidad de Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial.
* Se documentaron las condiciones de integridad y su trazabilidad hacia los documentos aprobados.
* Se mantuvieron fuera del alcance los tipos físicos, índices y decisiones tecnológicas.
* Se definió el Diccionario de Datos como el siguiente documento del Engineering Playbook.

---

### SRS-010 - Modelo Relacional

**Documento aprobado:** SRS-010 - Modelo Relacional

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se representó el Modelo de Dominio aprobado mediante estructuras relacionales.
* Se mantuvo a la Iniciativa como Aggregate Root principal del modelo.
* Se definieron las relaciones entre Negocio, Iniciativa, Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Ambientes, Despliegues e Historial.
* Se establecieron reglas de integridad para proteger las relaciones y la trazabilidad aprobadas.
* Se mantuvieron los Objetos de Valor gobernados por el dominio fuera de la configuración libre.
* Se documentó la correspondencia entre las estructuras relacionales y sus fuentes aprobadas.
* Se postergaron la selección tecnológica y la estrategia de persistencia para una decisión arquitectónica específica.
* Se definió el DER como el siguiente documento del Engineering Playbook.

---

### ADR-001 - Arquitectura Basada en el Negocio

**Documento aprobado:** ADR-001 - Arquitectura Basada en el Negocio

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se formalizó que la arquitectura de Arauco Project Hub se deriva del dominio aprobado.
* Se evaluaron las alternativas de organización por tecnología, por pantallas o formularios y por dominio.
* Se establecieron criterios para proteger a la Iniciativa como centro del producto.
* Se definió la separación entre las reglas del dominio y los detalles tecnológicos.
* Se documentaron las implicancias para el Modelo Relacional, Backend, API, Frontend e integraciones.
* Se incorporaron criterios de cumplimiento y trazabilidad hacia PHIL-001 y los SRS aprobados.
* Se inició formalmente la Fase 2 - Architecture.

---

### PHIL-001 - Filosofía del Producto

**Documento aprobado:** PHIL-001 - Filosofía del Producto

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió la identidad y la convicción central de Arauco Project Hub.
* Se establecieron los principios permanentes del producto.
* Se definieron los límites que protegen el propósito de la plataforma.
* Se formalizó el orden de prioridad entre Filosofía del Producto, SRS, ADR, Decisions, Standards y código.
* Se incorporaron criterios para evaluar futuras decisiones.
* Se documentaron las tensiones entre simplicidad y flexibilidad, estandarización y autonomía, trazabilidad y esfuerzo, transparencia y protección, y evolución y estabilidad.
* Se estableció que la tecnología debe adaptarse al dominio y no definirlo.

---

### SRS-004 - Modelo Operacional

**Documento aprobado:** SRS-004 - Modelo Operacional

**Estado alcanzado:** Approved

#### Resumen de los cambios

* Se definió la diferencia entre las Etapas de Iniciativa y los Estados de Solicitud.
* Se documentaron el flujo AS-IS y el flujo TO-BE de una Iniciativa.
* Se describió el ciclo de vida desde Idea hasta Operación y evolución.
* Se estableció la participación operacional de los actores definidos en el Lenguaje Ubicuo.
* Se modelaron los flujos paralelos de Evaluación, Presupuesto, Recursos tecnológicos, DevOps, DBA, Desarrollo, QAS, Producción y Operación.
* Se aprobaron las reglas operacionales y las decisiones que mantienen la trazabilidad durante el ciclo de vida de una Iniciativa.
* Se completó formalmente la Fase 1 - Domain Design.
