# Arauco Project Hub

## Architecture Decision Record

# ADR-003 - Frontend con Nuxt 4

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Contexto

Arauco Project Hub necesita un Frontend que permita representar el ciclo de vida completo de una Iniciativa y mantener en un mismo contexto sus Participantes, Componentes, Recursos, Documentos, Conversaciones, Solicitudes, Versiones, Despliegues e Historial.

El Frontend deberá utilizar el Lenguaje Ubicuo, respetar el Modelo Operacional y evitar que las pantallas o formularios se conviertan en la fuente de definición del dominio.

ADR-001 establece que la tecnología debe servir al dominio y mantener separadas sus reglas de los detalles del framework. ADR-002 establece que el Frontend formará parte del monorepo, manteniendo límites y validaciones explícitas.

Sin una decisión sobre la tecnología principal del Frontend, podrían aparecer:

* Convenciones diferentes para navegación, obtención de datos y manejo de estados.
* Configuración repetida para capacidades comunes.
* Dependencia excesiva de decisiones particulares de cada pantalla.
* Dificultad para mantener una experiencia coherente durante el ciclo de vida de la Iniciativa.
* Acoplamiento entre el dominio, la API y los componentes visuales.

Esta decisión selecciona la base tecnológica del Frontend. No define el diseño visual, la estructura definitiva de carpetas, la biblioteca de componentes, el mecanismo de autenticación, el modo de renderizado ni la estrategia de despliegue.

---

# 2. Fuerzas de Decisión

La decisión debe:

* Permitir representar el contexto y ciclo de vida de una Iniciativa.
* Favorecer componentes visuales comprensibles y reutilizables.
* Utilizar TypeScript para hacer explícitos los contratos del Frontend.
* Proporcionar convenciones claras para navegación, layouts, obtención de datos y manejo de errores.
* Mantener separadas la presentación, la comunicación con la API y las reglas del dominio.
* Permitir validaciones automatizadas.
* Integrarse al monorepo sin acoplarse al Backend.
* Evitar complejidad de configuración que no aporte valor al producto.
* Permitir elegir el modo de renderizado cuando existan requerimientos no funcionales aprobados.
* Mantener una ruta de actualización soportada.

La familiaridad del equipo, los requisitos de navegadores corporativos y el modelo de despliegue permanecen Pendientes de validación.

---

# 3. Opciones Consideradas

## 3.1 Vue 3 con Vite

Construir el Frontend directamente con Vue 3, Vue Router, Vite y las bibliotecas adicionales que se seleccionen.

### Ventajas

* Base inicial pequeña.
* Control explícito sobre cada dependencia.
* Vue ofrece soporte oficial de TypeScript.
* Permite incorporar únicamente las capacidades necesarias.

### Desventajas

* Requiere seleccionar y mantener convenciones para navegación, layouts, obtención de datos y manejo de errores.
* Aumenta las decisiones iniciales de integración.
* Puede producir diferencias entre capacidades si las convenciones no se gobiernan.

## 3.2 Nuxt 4

Construir el Frontend con Nuxt 4, Vue 3 y TypeScript.

### Ventajas

* Integra Vue 3 bajo convenciones comunes.
* Proporciona enrutamiento basado en archivos y división de código por página.
* Proporciona convenciones para layouts, middleware, obtención de datos y manejo de errores.
* Mantiene soporte para diferentes modos de renderizado.
* Reduce configuración inicial sin impedir organizar el código según el dominio.
* Conserva la posibilidad de usar las capacidades oficiales del ecosistema Vue.

### Desventajas

* Incorpora capacidades que una aplicación exclusivamente cliente podría no necesitar.
* Sus convenciones pueden orientar incorrectamente la arquitectura si se confunden carpetas del framework con límites del dominio.
* Requiere mantener compatibilidad con los requisitos de ejecución de Nuxt.
* Los auto-imports pueden ocultar dependencias si se utilizan sin una convención clara.

## 3.3 Next.js

Construir el Frontend con Next.js, React y TypeScript.

### Ventajas

* Proporciona enrutamiento, layouts, TypeScript y capacidades de renderizado integradas.
* Cuenta con convenciones para aplicaciones web completas.
* Permite componentes ejecutados en servidor y cliente.

### Desventajas

* Introduce React como modelo de componentes cuando Vue ya ofrece una alternativa más directa para la opción propuesta.
* El App Router incorpora decisiones de ejecución en servidor y cliente que deben comprenderse y gobernarse.
* No existe una necesidad aprobada que haga imprescindible su modelo de Server Components.
* Cambia simultáneamente framework, convenciones y modelo de renderizado sin un beneficio validado para el producto.

---

# 4. Decisión

El Frontend de Arauco Project Hub se implementará con Nuxt 4, Vue 3 y TypeScript.

La decisión se aplicará bajo las siguientes condiciones:

1. Nuxt será un detalle tecnológico del Frontend y no definirá conceptos, estados ni reglas del dominio.
2. El Lenguaje Ubicuo se utilizará en rutas, componentes, contratos y capacidades cuando representen conceptos del negocio.
3. Las páginas coordinarán la presentación y no concentrarán reglas del dominio.
4. La comunicación con la API se mantendrá separada de los componentes visuales.
5. Los contratos intercambiados con la API se representarán explícitamente mediante TypeScript.
6. Los componentes reutilizables se incorporarán cuando exista una necesidad real y no como generalización anticipada.
7. Los auto-imports de Nuxt no deberán ocultar dependencias entre capacidades del producto.
8. El Frontend mantendrá validaciones propias dentro del monorepo.
9. La versión mayor será Nuxt 4; las versiones menores y de corrección se administrarán mediante actualización controlada.
10. El modo de renderizado se decidirá posteriormente a partir de requerimientos no funcionales y de despliegue aprobados.

Esta decisión no autoriza implementar reglas del dominio en middleware de navegación, componentes visuales, estado del cliente o capacidades del servidor de Nuxt.

---

# 5. Consecuencias

## 5.1 Consecuencias Positivas

* El Frontend parte de convenciones comunes para navegación y composición de vistas.
* Vue 3 y TypeScript permiten componentes con contratos explícitos.
* Se reduce la configuración inicial de capacidades habituales.
* El equipo puede elegir posteriormente el modo de renderizado sin reemplazar el framework.
* La división de código por rutas favorece cargar solo lo necesario para cada vista.
* El Frontend puede evolucionar dentro del monorepo manteniendo validaciones independientes.

## 5.2 Costos y Restricciones

* El equipo deberá conocer Vue 3, TypeScript y las convenciones de Nuxt 4.
* La implementación requerirá una versión de Node.js compatible con Nuxt 4.
* Será necesario distinguir entre capacidades del Frontend y capacidades del servidor incluidas por Nuxt.
* Las actualizaciones deberán verificar compatibilidad y comportamiento.
* La flexibilidad de renderizado no deberá convertirse en múltiples estrategias sin justificación.

## 5.3 Riesgos

### Acoplamiento al framework

Las reglas o contratos del producto podrían depender directamente de APIs de Nuxt.

Mitigación:

* Mantener los conceptos del dominio en estructuras TypeScript independientes del framework cuando corresponda.
* Encapsular la obtención de datos y los detalles de navegación.
* Revisar la implementación contra ADR-001.

### Lógica concentrada en páginas

El enrutamiento por archivos puede incentivar páginas con demasiadas responsabilidades.

Mitigación:

* Mantener las páginas como puntos de composición.
* Extraer capacidades y componentes con responsabilidades explícitas.
* Evitar duplicar reglas entre páginas.

### Complejidad de renderizado

Nuxt permite varios modos de renderizado y ejecución.

Mitigación:

* Elegir un modo inicial solo después de aprobar los requerimientos correspondientes.
* Evitar combinaciones por ruta mientras no exista una necesidad validada.

### Dependencias implícitas

Los auto-imports pueden dificultar reconocer el origen de una dependencia.

Mitigación:

* Definir convenciones de uso.
* Preferir dependencias explícitas cuando atraviesen límites internos.

---

# 6. Criterios de Cumplimiento

La implementación de esta decisión cumple cuando:

* Utiliza Nuxt 4, Vue 3 y TypeScript.
* Utiliza el Lenguaje Ubicuo para representar conceptos del dominio.
* Mantiene las reglas del dominio fuera de los detalles de Nuxt.
* Separa componentes visuales, comunicación con la API y coordinación de estado.
* Mantiene contratos explícitos con la API.
* Evita duplicar reglas entre páginas o componentes.
* Mantiene validaciones propias del Frontend.
* No incorpora capacidades de servidor o renderizado sin una necesidad aprobada.
* Conserva trazabilidad hacia los documentos que respaldan cada capacidad.

---

# 7. Cuándo Revisar esta Decisión

Esta decisión deberá revisarse si:

* Nuxt 4 deja de recibir soporte antes de contar con una ruta de actualización viable.
* Los navegadores corporativos requeridos no son compatibles.
* El equipo no puede mantener Vue 3 y Nuxt 4 de forma sostenible.
* El modelo de despliegue aprobado resulta incompatible con las capacidades requeridas.
* Las restricciones de rendimiento o seguridad no pueden satisfacerse sin contradecir el dominio.

Una preferencia tecnológica aislada no constituye por sí sola una razón suficiente para sustituir el framework.

---

# 8. Trazabilidad

Este ADR deriva principalmente de:

* PHIL-001: FP-002, FP-003, FP-006, FP-007, FP-009, FP-011, FP-012 y FP-014.
* SRS-001: propósito, alcance y principios de diseño.
* SRS-002: Lenguaje Ubicuo.
* SRS-003: Iniciativa como Aggregate Root principal.
* SRS-004: ciclo de vida y Modelo Operacional.
* ADR-001: arquitectura derivada del dominio.
* ADR-002: organización en monorepo con límites y validaciones por componente.

---

# 9. Fuentes Técnicas Consultadas

* [Instalación de Nuxt 4](https://nuxt.com/docs/4.x/getting-started/installation/).
* [Desarrollo con Vue en Nuxt 4](https://nuxt.com/docs/4.x/guide/concepts/vuejs-development).
* [Enrutamiento de Nuxt 4](https://nuxt.com/docs/4.x/getting-started/routing/).
* [TypeScript en Vue](https://vuejs.org/guide/typescript/overview).
* [App Router de Next.js](https://nextjs.org/docs/app).

Las fuentes técnicas respaldan las capacidades comparadas. La decisión se fundamenta en las necesidades y principios aprobados de Arauco Project Hub.

---

# 10. Decisiones Posteriores

Este ADR deberá orientar, sin anticiparlas, las decisiones sobre:

* Arquitectura interna del Frontend.
* Modo de renderizado.
* Estrategia de despliegue del Frontend.
* Comunicación con la API.
* Manejo de estado del cliente.
* Biblioteca de componentes y estilos.
* Estrategia de pruebas del Frontend.

Cada decisión importante deberá documentarse mediante un ADR cuando corresponda.

---

# 11. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para la tecnología principal del Frontend de Arauco Project Hub.
