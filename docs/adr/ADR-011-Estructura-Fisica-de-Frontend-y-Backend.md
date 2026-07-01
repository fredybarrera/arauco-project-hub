# Arauco Project Hub

## Architecture Decision Record

# ADR-011 - Estructura Física de Frontend y Backend

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Contexto

Sprint 1 versión 1.1 autoriza iniciar la base del monorepo para implementar CU-002.

EST-003 aprueba `/frontend` y `/backend` como raíces de implementación, pero mantiene Pendientes:

* La estructura física interna del Frontend.
* La cantidad y organización de proyectos .NET.
* Las unidades de compilación del Backend.
* El propósito o retiro de `/src`.

Las arquitecturas de Frontend y Backend exigen límites explícitos, pero no fijan carpetas ni proyectos.

Crear el scaffold sin resolver estas decisiones convertiría preferencias técnicas en arquitectura implícita.

---

# 2. Fuerzas de Decisión

La estructura debe:

* Mantener visible al módulo Iniciativas.
* Separar API, coordinación, dominio y adaptaciones.
* Mantener el dominio independiente de ASP.NET Core y Entity Framework Core.
* Separar páginas, presentación, coordinación de interfaz y comunicación con la API.
* Permitir pruebas por responsabilidad.
* Evitar carpetas genéricas y código compartido prematuro.
* Permitir construir Frontend y Backend de forma independiente.
* Mantener una cantidad mínima de proyectos y dependencias.
* No crear una segunda raíz de implementación.

---

# 3. Opciones Consideradas

## 3.1 Un proyecto por componente

Mantener un proyecto .NET para todo el Backend y la estructura predeterminada de Nuxt para todo el Frontend.

### Ventajas

* Scaffold inicial pequeño.
* Menor cantidad de archivos de construcción.

### Desventajas

* Los límites dependen solo de disciplina.
* ASP.NET Core y Entity Framework Core pueden alcanzar fácilmente el dominio.
* Las responsabilidades de CU-002 quedan menos visibles.

## 3.2 Un proyecto por cada capa técnica

Crear proyectos separados para API, coordinación, dominio, persistencia, contratos y cada tipo de prueba.

### Ventajas

* Dependencias físicamente explícitas.
* Aislamiento fuerte de responsabilidades.

### Desventajas

* Demasiadas unidades para una única capacidad inicial.
* Aumenta referencias, configuración y mantenimiento.
* Puede convertir capas técnicas en la organización principal.

## 3.3 Estructura mínima con límites explícitos

Utilizar tres proyectos productivos de Backend y organizar el Frontend alrededor de la capacidad Iniciativas.

### Ventajas

* Protege el dominio con pocas unidades.
* Mantiene API y persistencia fuera del módulo Iniciativas.
* Evita fragmentación prematura.
* Permite evolucionar cuando aparezca una necesidad comprobada.

### Desventajas

* Coordinación y dominio comparten una unidad de compilación.
* Requiere reglas de namespaces y referencias.
* Una división futura puede requerir mover código.

---

# 4. Decisión Propuesta

Se propone adoptar la estructura mínima con límites explícitos.

## 4.1 Backend

```text
backend/
  Arauco.ProjectHub.slnx
  src/
    Arauco.ProjectHub.Api/
    Arauco.ProjectHub.Iniciativas/
    Arauco.ProjectHub.Infrastructure/
  tests/
    Arauco.ProjectHub.Iniciativas.Tests/
    Arauco.ProjectHub.Api.Tests/
```

Responsabilidades:

* `Arauco.ProjectHub.Api`: entrada HTTP, autenticación, contratos externos, composición y traducción de resultados.
* `Arauco.ProjectHub.Iniciativas`: coordinación de CU-002, Modelo de Dominio y contratos requeridos por adaptaciones.
* `Arauco.ProjectHub.Infrastructure`: Entity Framework Core, Azure SQL Database y adaptaciones técnicas.
* `Arauco.ProjectHub.Iniciativas.Tests`: reglas y coordinación sin infraestructura real.
* `Arauco.ProjectHub.Api.Tests`: contrato HTTP e integración de la capacidad.

Dependencias permitidas:

```text
Api -> Iniciativas
Api -> Infrastructure
Infrastructure -> Iniciativas
Iniciativas -> ninguna unidad productiva
```

No se crea inicialmente un proyecto separado de contratos, código compartido o modelos de lectura.

## 4.2 Frontend

```text
frontend/
  app/
    pages/
      iniciativas/
    components/
      iniciativas/
    composables/
      iniciativas/
    api/
      iniciativas/
  test/
```

Responsabilidades:

* `pages/iniciativas`: destinos de navegación y composición.
* `components/iniciativas`: presentación propia de la capacidad.
* `composables/iniciativas`: coordinación de carga y resultados.
* `api/iniciativas`: contrato TypeScript y comunicación con CU-002.
* `test`: configuración y apoyo de pruebas del Frontend.

No se crea una carpeta global de estado, utilidades o código compartido.

## 4.3 Raíz `/src`

La raíz `/src` existente no tendrá responsabilidad dentro del monorepo.

Después de aprobar este ADR:

* Se retirará `/src` y su contenido vacío.
* El código vivirá únicamente bajo `/frontend` y `/backend`.
* No se creará una raíz `/tests` mientras no existan pruebas transversales.

---

# 5. Reglas de Dependencia

* El Frontend no referencia proyectos del Backend.
* `Arauco.ProjectHub.Iniciativas` no referencia ASP.NET Core, Entity Framework Core ni Azure.
* `Arauco.ProjectHub.Infrastructure` implementa contratos definidos por Iniciativas.
* `Arauco.ProjectHub.Api` no consulta directamente el contexto de persistencia.
* Los contratos JSON pertenecen al límite de API.
* Los contratos TypeScript representan la API sin copiar entidades internas.
* Las pruebas permanecen con el componente cuya responsabilidad verifican.

---

# 6. Consecuencias

## 6.1 Positivas

* La dirección de dependencias puede verificarse por referencias de proyectos.
* El dominio permanece aislado de frameworks.
* La estructura sigue la capacidad Iniciativas.
* Frontend y Backend se construyen de forma independiente.
* Se evita una herramienta adicional de gestión del monorepo.

## 6.2 Costos

* El Backend comienza con tres proyectos productivos.
* Coordinación y dominio requieren separación interna clara.
* Los nombres y referencias deben mantenerse consistentes.

## 6.3 Riesgos

### Crecimiento de Iniciativas

La unidad puede acumular demasiadas responsabilidades.

**Mitigación:** dividirla solo cuando una dependencia o frecuencia de cambio lo justifique.

### Carpetas técnicas genéricas

El Frontend puede perder orientación por capacidad.

**Mitigación:** mantener subcarpetas `iniciativas` y evitar utilidades globales prematuras.

---

# 7. Criterios de Cumplimiento

La implementación cumple cuando:

* Utiliza `/frontend` y `/backend` como únicas raíces de código.
* Retira la raíz `/src`.
* Respeta las referencias permitidas del Backend.
* El módulo Iniciativas compila sin dependencias de infraestructura.
* La comunicación del Frontend con CU-002 permanece en `api/iniciativas`.
* Las páginas no llaman directamente al transporte HTTP.
* Cada componente ejecuta sus pruebas de forma independiente.
* No incorpora carpetas o proyectos adicionales sin necesidad aprobada.

---

# 8. Cuándo Revisar

Esta decisión deberá revisarse si:

* Iniciativas necesita separar coordinación y dominio por una dependencia real.
* Aparece un segundo módulo de dominio aprobado.
* Existen contratos compartidos con más de un consumidor.
* Se requieren pruebas transversales fuera de Frontend y Backend.
* La construcción independiente deja de ser suficiente.

---

# 9. Trazabilidad

Este ADR deriva principalmente de:

* ADR-002 - Monorepo.
* ADR-003 - Frontend con Nuxt 4.
* ADR-004 - Backend con .NET 10.
* Arquitectura del Frontend.
* Arquitectura del Backend.
* EST-003 - Convención de Repositorios.
* EST-004 - Convención de Nombres.
* Sprint 1 - Implementación de CU-002, versión 1.1.

---

# 10. Validaciones de Implementación

Al crear la base del monorepo se debe:

* Confirmar tres proyectos productivos para el Backend.
* Confirmar coordinación y dominio dentro de Iniciativas.
* Confirmar la estructura por capacidad del Frontend.
* Confirmar el retiro de `/src`.
* Validar los nombres con EST-004.
* Validar la decisión con el Technical Lead y el equipo de Desarrollo.

---

# 11. Siguiente Paso

Después de aprobar ADR-011, crear la base del monorepo y verificar construcción y pruebas independientes.

---

# 12. Estado del Documento

**Estado actual:** Approved

Este ADR constituye la fuente oficial para la estructura física inicial de Frontend y Backend.
