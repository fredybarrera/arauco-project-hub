# Changelog

Este documento registra los hitos formales alcanzados por el Engineering Playbook de Arauco Project Hub.

---

## 2026-06-28

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
