# Arauco Project Hub

## Engineering Playbook

# EST-003 - Convención de Repositorios

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Objetivo

Este documento define las convenciones para organizar y mantener el monorepo de Arauco Project Hub.

Su propósito es conservar trazabilidad entre el Engineering Playbook y la implementación, mantener visibles los límites de cada componente y evitar que compartir repositorio produzca acoplamiento o duplicación.

---

# 2. Alcance

Este estándar establece:

* El contenido permitido en el monorepo.
* La organización de primer nivel.
* Los límites entre documentación, Frontend, Backend y automatización.
* Las reglas para dependencias y elementos compartidos.
* Las convenciones mínimas para cambios, commits y validaciones.
* Los archivos que no deben versionarse.

Este documento no:

* Selecciona una herramienta de gestión del monorepo.
* Define la estructura interna completa del Frontend o Backend.
* Define una plataforma de CI/CD.
* Define la estrategia de despliegue.
* Crea repositorios adicionales.
* Autoriza nuevos componentes, módulos o conceptos del dominio.

---

# 3. Principios

## 3.1 Un repositorio, un producto

El repositorio contiene exclusivamente elementos que forman parte de Arauco Project Hub.

No debe utilizarse como agrupación genérica de Soluciones, experimentos o utilidades sin relación directa con el producto.

## 3.2 El dominio antes que la estructura

Las carpetas y proyectos técnicos no definen módulos del dominio.

La estructura debe conservar el Lenguaje Ubicuo y respetar al módulo Iniciativas y a la Iniciativa como Aggregate Root principal.

## 3.3 Límites explícitos

Frontend, Backend, Engineering Playbook y automatización comparten repositorio, pero mantienen responsabilidades, dependencias y validaciones propias.

La proximidad física no autoriza acceso directo entre componentes ni dependencias que contradigan la arquitectura.

## 3.4 Trazabilidad del cambio

Un cambio debe incluir la documentación, implementación y validaciones necesarias para mantener coherencia.

Cuando una implementación derive de un requerimiento, ADR o Standard, su relación debe poder reconocerse durante la revisión.

## 3.5 Simplicidad

No se incorporará una herramienta de gestión del monorepo, generación, caché o ejecución distribuida hasta que una necesidad medida justifique su complejidad.

---

# 4. Contenido del Monorepo

El monorepo debe contener:

* El Engineering Playbook.
* El Frontend.
* El Backend.
* Pruebas y configuración propias de cada componente.
* Automatización común aprobada.
* Infraestructura cuando exista una decisión aprobada para incorporarla.

No debe contener:

* Otros productos.
* Copias de repositorios externos.
* Credenciales, claves o secretos.
* Artefactos generados que puedan reconstruirse.
* Dependencias descargadas.
* Datos de Producción.
* Exportaciones de información sensible.
* Herramientas binarias sin una necesidad y política aprobadas.

---

# 5. Organización de Primer Nivel

La organización inicial propuesta es:

| Ruta | Responsabilidad |
| --- | --- |
| `/docs` | Engineering Playbook y documentación oficial |
| `/frontend` | Frontend con Nuxt 4, Vue 3 y TypeScript |
| `/backend` | Backend con .NET 10, C# y ASP.NET Core 10 |
| `/.github` | Automatización y plantillas específicas de GitHub cuando sean aprobadas |
| `/tests` | Pruebas transversales únicamente cuando no pertenezcan de forma clara a un componente |

La infraestructura tendrá una ubicación propia solo después de que su alcance y tecnología sean aprobados.

La carpeta genérica `/src` no debe competir con `/frontend` y `/backend` como una segunda raíz de implementación. Antes de incorporar código debe resolverse si se elimina o recibe una responsabilidad única y documentada.

No se agregarán nuevas carpetas de primer nivel sin:

1. Una responsabilidad reconocible.
2. Un contenido que no pertenezca a una ubicación existente.
3. Trazabilidad hacia una necesidad aprobada.
4. Revisión de su efecto sobre límites y validaciones.

---

# 6. Engineering Playbook

`/docs` conserva la memoria oficial del producto.

La documentación debe:

* Respetar la prioridad entre Filosofía del Producto, SRS, ADR, Decisions, Standards y código.
* Mantener estados Draft y Approved explícitos cuando corresponda.
* Evitar duplicar una definición cuya fuente oficial ya existe.
* Utilizar enlaces o trazabilidad documental en lugar de copiar contenido.
* Actualizar `CURRENT_STATE.md` y `changelog.md` conforme al flujo de aprobación.

Un cambio de código no puede contradecir documentación Approved.

Los documentos Approved no se modifican sin una nueva revisión.

---

# 7. Frontend

`/frontend` debe contener únicamente responsabilidades del Frontend.

Debe:

* Mantener sus dependencias y validaciones explícitas.
* Utilizar el Lenguaje Ubicuo cuando representa conceptos del dominio.
* Comunicarse con el Backend mediante contratos de la API.
* Mantener reglas del dominio fuera de Nuxt, páginas, componentes y estado del cliente.
* Conservar pruebas cerca de la responsabilidad que verifican cuando la herramienta lo permita.

No debe:

* Acceder directamente a Azure SQL Database.
* Referenciar proyectos internos del Backend.
* Duplicar entidades del Backend como una segunda fuente del dominio.
* Incorporar capacidades de servidor que sustituyan al Backend.

La estructura interna definitiva permanece Pendiente de las capacidades iniciales y convenciones de Nuxt aprobadas.

---

# 8. Backend

`/backend` debe contener la API, coordinación, dominio y adaptaciones técnicas conforme a la Arquitectura del Backend.

Debe:

* Mantener dependencias dirigidas hacia el Modelo de Dominio.
* Mantener ASP.NET Core, Entity Framework Core y Azure fuera del dominio.
* Conservar contratos externos separados de las entidades del dominio.
* Mantener pruebas propias por responsabilidad.
* Hacer visibles los límites entre entrada, coordinación, dominio y adaptaciones.

No debe:

* Depender del código del Frontend.
* Exponer estructuras de persistencia como contratos de la API.
* Organizar el dominio únicamente según frameworks o tipos técnicos.

La estructura física de la solución y sus unidades de compilación .NET permanece Pendiente.

---

# 9. Pruebas

Las pruebas deben ubicarse con el componente cuya responsabilidad verifican.

`/tests` se reserva para pruebas que atraviesen componentes y que no puedan pertenecer de forma clara al Frontend o Backend.

Una prueba transversal debe:

* Tener un alcance explícito.
* Evitar duplicar pruebas del componente.
* Poder ejecutarse sin depender de información sensible.
* Identificar las dependencias y Ambientes requeridos.

Este estándar no selecciona frameworks de pruebas ni define porcentajes de cobertura.

---

# 10. Dependencias y Código Compartido

Cada componente debe declarar sus dependencias.

No se permite:

* Referenciar código interno de otro componente por conveniencia.
* Compartir entidades del dominio mediante paquetes técnicos sin una decisión arquitectónica.
* Crear una carpeta común para código que todavía no tiene una necesidad repetida y estable.
* Duplicar configuración o contratos para evitar definir un límite explícito.

El código compartido solo se incorporará cuando:

* Exista una necesidad validada en más de un consumidor.
* La responsabilidad tenga un propietario claro.
* Su dirección de dependencia respete la arquitectura.
* Sus cambios y compatibilidad puedan validarse.

Una dependencia compartida que modifique límites importantes requiere proponer un ADR.

---

# 11. Archivos Versionados

Se deben versionar:

* Código fuente.
* Documentación.
* Configuración no sensible necesaria para construir y validar.
* Archivos de resolución de dependencias.
* Migraciones aprobadas.
* Scripts y automatización necesarios para reproducir validaciones.

No se deben versionar:

* Dependencias restauradas.
* Resultados de compilación.
* Cobertura generada.
* Archivos temporales o del editor.
* Configuración local con datos personales.
* Secretos o credenciales.
* Registros técnicos.
* Copias de bases de datos.

El archivo `.gitignore` debe mantenerse en la raíz y cubrir los artefactos de las tecnologías aprobadas cuando comience la implementación.

---

# 12. Cambios y Commits

Cada commit debe:

* Representar un cambio coherente.
* Mantener el repositorio en un estado revisable.
* Evitar mezclar modificaciones no relacionadas.
* Incluir las pruebas o documentación necesarias.
* No contener secretos ni artefactos generados.

Los mensajes deben seguir Conventional Commits:

```text
<tipo>(<alcance opcional>): <descripción>
```

Tipos iniciales:

| Tipo | Uso |
| --- | --- |
| `docs` | Engineering Playbook y documentación |
| `feat` | Capacidad funcional aprobada |
| `fix` | Corrección de un comportamiento |
| `test` | Pruebas |
| `refactor` | Cambio interno sin alterar comportamiento |
| `build` | Construcción o dependencias |
| `ci` | Automatización de integración |
| `chore` | Mantenimiento que no corresponde a otro tipo |

El alcance debe utilizar una responsabilidad reconocible. No debe introducir sinónimos ni conceptos nuevos del dominio.

---

# 13. Ramas y Revisión

Los cambios deben desarrollarse en ramas de vida acotada y revisarse antes de integrarse a la rama principal cuando el flujo de colaboración lo permita.

Una rama debe:

* Representar un objetivo reconocible.
* Evitar acumular cambios sin relación.
* Mantenerse actualizada de forma controlada.
* Eliminarse cuando su cambio ya fue integrado y no tenga trabajo vigente.

La protección concreta de la rama principal, revisores obligatorios y verificaciones requeridas permanecen Pendientes del estándar de CI/CD y de la configuración corporativa del repositorio.

---

# 14. Validaciones

Cada componente debe exponer validaciones propias y permitir ejecutarlas de forma independiente.

Un cambio debe ejecutar:

* Las validaciones del componente afectado.
* Las validaciones de contratos cuando atraviesa Frontend y Backend.
* Las validaciones documentales cuando modifica el Engineering Playbook.
* Una validación integral cuando el riesgo del cambio lo requiera.

La ejecución selectiva no debe omitir una dependencia afectada.

Las herramientas, comandos y automatización se definirán cuando exista implementación y en EST-005 - CI/CD.

---

# 15. Criterios de Cumplimiento

El repositorio cumple este estándar cuando:

* Representa únicamente a Arauco Project Hub.
* Conserva el Engineering Playbook y los componentes en un monorepo.
* Mantiene límites explícitos entre Frontend y Backend.
* Mantiene documentación e implementación trazables.
* Utiliza el Lenguaje Ubicuo.
* Mantiene dependencias y validaciones propias por componente.
* No incorpora código compartido sin una necesidad validada.
* No contiene secretos, dependencias descargadas ni artefactos generados.
* Utiliza Conventional Commits.
* No incorpora herramientas de monorepo sin justificación.

---

# 16. Trazabilidad

Este estándar deriva principalmente de:

* PHIL-001: FP-004, FP-005, FP-009, FP-010, FP-011 y FP-012.
* SRS-002 - Lenguaje Ubicuo.
* ADR-001 - Arquitectura Basada en el Negocio.
* ADR-002 - Monorepo.
* ADR-003 - Frontend con Nuxt 4.
* ADR-004 - Backend con .NET 10.
* EST-001 - Estándar Tecnológico.
* Arquitectura del Frontend.
* Arquitectura del Backend.

---

# 17. Validaciones de Implementación

* Confirmar la organización de primer nivel propuesta.
* Resolver el propósito o retiro futuro de `/src`.
* Confirmar si `/tests` se reserva para pruebas transversales.
* Confirmar la convención corporativa para ramas.
* Confirmar los tipos y alcances de Conventional Commits.
* Definir responsables de revisión cuando exista una política corporativa.

---

# 18. Siguiente Paso

Después de aprobar EST-003, el siguiente documento propuesto es:

EST-004 - Convención de Nombres.

Objetivo:

Definir nombres consistentes para documentación, código y recursos técnicos sin crear sinónimos del Lenguaje Ubicuo.

---

# 19. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para la organización y mantenimiento del monorepo de Arauco Project Hub.
