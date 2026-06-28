# Arauco Project Hub

## Architecture Decision Record

# ADR-005 - Proveedor de Identidad y Estrategia de Sesión

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Contexto

Arauco Project Hub requiere autenticar identidades corporativas antes de permitir acceso a capacidades e información no pública.

SRS-006 exige identidad autenticada, autorización en el Backend, menor privilegio y protección de credenciales. SRS-007 establece que la identidad no reemplaza al Participante ni al Rol de Participación. La Arquitectura de Seguridad y el diseño de Autenticación separan autenticación, sesión, autorización y reglas del dominio.

El Frontend utiliza Nuxt 4 y el Backend utiliza ASP.NET Core 10. Todavía permanecen Pendientes:

* El proveedor corporativo disponible.
* El protocolo admitido por dicho proveedor.
* El modo de renderizado y despliegue de Nuxt.
* La estrategia de sesión.
* Las políticas corporativas de duración, renovación, cierre y autenticación multifactor.

La decisión debe evitar que Arauco Project Hub administre contraseñas corporativas y reducir la exposición de credenciales en el navegador.

---

# 2. Fuerzas de Decisión

La alternativa debe:

* Integrarse con identidades corporativas existentes.
* Evitar almacenar contraseñas.
* Permitir autenticación centralizada y políticas corporativas.
* Permitir a la API validar cada solicitud protegida.
* Mantener la autorización contextual dentro de Arauco Project Hub.
* Evitar que roles o grupos externos reemplacen el Modelo de Permisos.
* Reducir credenciales accesibles por código del navegador.
* Permitir expiración, renovación, invalidación y cierre.
* Integrarse con Nuxt 4 y ASP.NET Core 10.
* Mantener una implementación simple y verificable.

---

# 3. Opciones Consideradas

## 3.1 Identidad local

Arauco Project Hub administra cuentas, contraseñas, recuperación y autenticación.

### Ventajas

* Control completo del flujo.
* Independencia de un proveedor externo.

### Desventajas

* Duplica identidades corporativas.
* Obliga a gestionar contraseñas y recuperación.
* Aumenta significativamente el riesgo y la carga operacional.
* Dificulta aplicar políticas corporativas comunes.

## 3.2 Proveedor corporativo con credencial manejada por el navegador

El Frontend obtiene una credencial mediante un protocolo federado y la presenta directamente a la API.

### Ventajas

* No administra contraseñas.
* Permite un Frontend exclusivamente cliente.
* La API puede validar la credencial sin una sesión propia.

### Desventajas

* La credencial queda expuesta al entorno del navegador.
* El Frontend asume mayor responsabilidad sobre renovación y almacenamiento.
* Requiere controles estrictos para evitar extracción o reutilización.

## 3.3 Proveedor corporativo con sesión mediada por el Frontend

El componente de servidor del Frontend completa el flujo federado, conserva las credenciales fuera del código del navegador y entrega al navegador una referencia de sesión protegida.

El Frontend presenta solicitudes al Backend mediante el límite de servidor aprobado.

### Ventajas

* No administra contraseñas.
* Reduce la exposición de credenciales al navegador.
* Centraliza inicio, renovación y cierre.
* Permite mantener una experiencia coherente en el Frontend.

### Desventajas

* Requiere ejecución de servidor para Nuxt.
* Incorpora estado o coordinación adicional.
* Aumenta la responsabilidad operacional del Frontend.
* Debe proteger falsificación y reutilización de la sesión.

---

# 4. Decisión

Se propone:

1. Utilizar un proveedor corporativo de identidad mediante un protocolo federado estándar.
2. No administrar contraseñas dentro de Arauco Project Hub.
3. Utilizar un flujo basado en redirección que no exponga credenciales del actor a Arauco Project Hub.
4. Preferir una sesión mediada por el componente de servidor de Nuxt para mantener las credenciales fuera del código del navegador.
5. Utilizar una referencia de sesión protegida para la interacción del navegador.
6. Mantener en el Backend la validación de la identidad presentada y toda autorización contextual.
7. Relacionar el identificador estable de la identidad con el Participante sin copiar roles externos como permisos del dominio.
8. Mantener separados los registros de autenticación, la autorización y el Historial.

Antes de implementar se debe confirmar:

* El proveedor corporativo disponible.
* El protocolo y flujos permitidos.
* La posibilidad de desplegar Nuxt con ejecución de servidor.
* Las políticas corporativas de sesión.

Si Nuxt debe desplegarse exclusivamente como contenido estático, se deberá revisar la opción 3.2 y documentar los controles adicionales antes de aprobar este ADR.

---

# 5. Vista Propuesta

```mermaid
sequenceDiagram
    actor Actor
    participant Navegador
    participant Frontend as Frontend Nuxt
    participant Identidad as Proveedor corporativo
    participant API

    Actor->>Navegador: Accede
    Navegador->>Frontend: Solicita autenticación
    Frontend->>Identidad: Inicia flujo federado
    Identidad-->>Frontend: Identidad autenticada
    Frontend-->>Navegador: Establece referencia de sesión protegida
    Navegador->>Frontend: Solicita capacidad
    Frontend->>API: Presenta identidad validable
    API->>API: Valida identidad y autorización
    API-->>Frontend: Resultado
    Frontend-->>Navegador: Presenta resultado
```

El mecanismo exacto de intercambio depende del proveedor y protocolo confirmados.

---

# 6. Consecuencias

## 6.1 Positivas

* Arauco Project Hub no conserva contraseñas.
* Las políticas de autenticación permanecen centralizadas.
* Las credenciales pueden mantenerse fuera del código del navegador.
* El Backend conserva control sobre permisos y reglas.
* Una misma identidad puede relacionarse con distintos Roles de Participación por Iniciativa.

## 6.2 Costos

* Nuxt requiere ejecución de servidor para la opción preferida.
* La sesión debe protegerse, renovarse e invalidarse.
* El despliegue y la disponibilidad del Frontend adquieren responsabilidad adicional.
* Las pruebas requieren representar al proveedor y la sesión.

## 6.3 Riesgos

### Dependencia del proveedor

La indisponibilidad del proveedor puede impedir nuevos inicios o renovaciones.

Mitigación:

* Definir comportamiento ante indisponibilidad.
* Observar fallos y latencia.
* Evitar dependencia de atributos propietarios cuando no sean necesarios.

### Sesión comprometida

Una referencia de sesión extraída podría reutilizarse.

Mitigación:

* Aplicar atributos y controles adecuados al mecanismo elegido.
* Limitar duración.
* Permitir invalidación.
* Proteger contra falsificación y reutilización.

### Roles externos como permisos

Grupos del proveedor podrían convertirse en una segunda fuente de permisos.

Mitigación:

* Usarlos solo si existe una regla aprobada.
* Mantener SRS-007 como fuente de autorización del producto.

---

# 7. Criterios de Cumplimiento

La implementación cumple cuando:

* Utiliza el proveedor y protocolo aprobados.
* No almacena contraseñas.
* Mantiene credenciales fuera del código accesible por el navegador cuando se adopta la opción preferida.
* La API valida cada solicitud protegida.
* La identidad se relaciona mediante un identificador estable.
* Los permisos se obtienen del contexto de Arauco Project Hub.
* Expiración, renovación, invalidación y cierre están definidos.
* Los Ambientes utilizan configuración y credenciales separadas.
* Errores y registros no exponen credenciales.
* Existen pruebas de inicio, expiración, cierre y rechazo.

---

# 8. Cuándo Revisar

Esta decisión deberá revisarse si:

* El proveedor corporativo no admite el flujo requerido.
* Nuxt debe desplegarse exclusivamente como contenido estático.
* La política corporativa exige otra estrategia de sesión.
* La topología aprobada impide mantener credenciales fuera del navegador.
* Aparecen consumidores distintos del Frontend.

---

# 9. Trazabilidad

Este ADR deriva principalmente de:

* SRS-006 - Requerimientos No Funcionales.
* SRS-007 - Modelo de Permisos.
* ADR-003 - Frontend con Nuxt 4.
* ADR-004 - Backend con .NET 10.
* Arquitectura de Seguridad.
* Autenticación.

---

# 10. Validaciones de Implementación

Antes de implementar:

* Confirmar el proveedor corporativo con Seguridad e Identidad.
* Confirmar protocolos y flujos admitidos.
* Confirmar el modo de despliegue de Nuxt.
* Confirmar políticas de sesión y autenticación multifactor.
* Validar requisitos de cierre e invalidación.
* Revisar amenazas específicas del mecanismo.

---

# 11. Estado del Documento

**Estado actual:** Approved

Este ADR constituye la fuente oficial para la estrategia de identidad federada y sesión de Arauco Project Hub.
