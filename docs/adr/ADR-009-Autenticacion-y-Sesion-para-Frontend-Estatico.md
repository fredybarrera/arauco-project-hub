# Arauco Project Hub

## Architecture Decision Record

# ADR-009 - Autenticación y Sesión para Frontend Estático

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Contexto

ADR-005 seleccionó un proveedor corporativo federado y prefirió una sesión mediada por el servidor de Nuxt para mantener credenciales fuera del navegador.

ADR-008 seleccionó:

* Azure Static Web Apps para el Frontend.
* Nuxt 4 como aplicación estática.
* Azure Container Apps para la API y el Backend.
* Una vinculación bajo `/api`.

Esta plataforma no ejecuta el servidor Nuxt requerido por la estrategia preferida en ADR-005.

Azure Static Web Apps puede administrar autenticación y propagar un principal hacia APIs. Sin embargo:

* Su `userId` es específico de cada recurso Static Web Apps.
* El mismo actor obtiene identificadores diferentes en recursos distintos.
* El encabezado enviado a la API no incluye todas las claims del proveedor.
* El identificador no es adecuado como vínculo corporativo estable con el Participante.

Arauco Project Hub requiere una identidad estable, verificable y separada de Participante y Rol de Participación. El Backend debe autenticar cada solicitud protegida y mantener la autorización contextual definida en SRS-007.

Este ADR revisará y, cuando sea aprobado, supersederá ADR-005.

---

# 2. Fuerzas de Decisión

La alternativa debe:

* Funcionar con un Frontend estático.
* Utilizar el proveedor corporativo Microsoft Entra ID.
* No administrar contraseñas.
* Utilizar un protocolo estándar.
* Evitar secretos en el Frontend.
* Proporcionar un identificador corporativo estable.
* Permitir que ASP.NET Core valide cada solicitud.
* Mantener identidad, Participante y permisos separados.
* No convertir grupos o roles de Entra ID en permisos del dominio.
* Permitir inicio, renovación, expiración y cierre.
* Evitar almacenamiento persistente innecesario de credenciales.
* Mantener el Backend accesible mediante `/api`.
* Mantener una implementación simple y verificable.

Las políticas corporativas de sesión, autenticación multifactor, acceso condicional y duración permanecen Pendientes.

---

# 3. Opciones Consideradas

## 3.1 Autenticación administrada por Static Web Apps

Utilizar los endpoints `/.auth` y la sesión administrada de Static Web Apps. El Backend consume el principal propagado por la plataforma.

### Ventajas

* Reduce código de autenticación en el Frontend.
* La plataforma administra inicio y sesión.
* Se integra con rutas y roles de Static Web Apps.
* No entrega un access token al código del Frontend.

### Desventajas

* `userId` es específico de cada Static Web App.
* Recrear o cambiar el recurso puede cambiar el identificador.
* Desarrollo, QAS y PRD producen identificadores distintos.
* El principal de API no contiene todas las claims.
* `userDetails` puede ser mutable y no debe utilizarse como clave.
* El Backend dependería de un encabezado propietario como identidad principal.

## 3.2 Aplicación pública con Authorization Code y PKCE

Registrar el Frontend como aplicación pública de una sola página en Microsoft Entra ID.

Utilizar MSAL en el navegador para:

1. Iniciar autenticación mediante redirección.
2. Completar OAuth 2.0 Authorization Code con PKCE.
3. Obtener un access token destinado a la API.
4. Presentarlo como Bearer token en solicitudes `/api`.

ASP.NET Core valida el token y obtiene el identificador estable desde claims corporativas.

### Ventajas

* Utiliza protocolos estándar.
* No requiere secreto en el Frontend.
* La API valida emisor, audiencia, vigencia y firma.
* Proporciona claims corporativas estables.
* Funciona con un Frontend estático.
* Mantiene la autorización del dominio en el Backend.
* Reduce dependencia de encabezados propietarios de Static Web Apps.

### Desventajas

* El access token existe en el entorno del navegador.
* Requiere MSAL y configuración de dos registros de aplicación.
* Exige proteger el Frontend frente a ejecución de código no confiable.
* Renovación, almacenamiento y errores requieren una implementación explícita.

## 3.3 Componente adicional de sesión

Incorporar Azure Functions, otra Container App o un servicio intermediario para mantener una sesión fuera del navegador.

### Ventajas

* Puede conservar credenciales fuera del código del navegador.
* Permite una sesión mediada similar a ADR-005.

### Desventajas

* Agrega otro componente, despliegue y límite operacional.
* Duplica responsabilidades de entrada.
* Aumenta costo, red y observabilidad.
* No existe una necesidad aprobada que justifique esta complejidad.

---

# 4. Decisión Propuesta

Se propone:

1. Utilizar Microsoft Entra ID como proveedor corporativo.
2. Utilizar OpenID Connect para autenticación.
3. Utilizar OAuth 2.0 Authorization Code con PKCE para obtener access tokens.
4. Registrar el Frontend como aplicación de una sola página sin secreto.
5. Registrar la API como recurso protegido con una audiencia propia.
6. Utilizar MSAL para coordinar inicio, adquisición, renovación y cierre en el Frontend.
7. Mantener tokens únicamente en memoria durante la etapa inicial.
8. No utilizar `localStorage` para access tokens.
9. No utilizar cookies creadas por Arauco Project Hub para transportar access tokens.
10. Enviar el access token mediante `Authorization: Bearer` en solicitudes `/api`.
11. Validar el token en ASP.NET Core 10.
12. Validar firma, emisor, audiencia y vigencia en cada solicitud protegida.
13. Utilizar la combinación de tenant y object identifier como identidad corporativa estable.
14. Relacionar esa identidad con el Participante cuando una capacidad lo requiera.
15. Mantener SRS-007 como fuente de autorización.
16. No convertir grupos, roles de aplicación ni claims externas en Roles de Participación.
17. Mantener el enlace Static Web Apps–Container Apps como restricción adicional de ingreso.
18. No confiar en el enlace como sustituto de autenticación.
19. No utilizar `x-ms-client-principal` como fuente oficial de identidad.
20. Utilizar `/.auth/me` solo si existe una necesidad de interfaz no autoritativa.
21. Permitir el acceso anónimo únicamente a rutas explícitamente públicas.
22. Aplicar políticas corporativas de acceso condicional y autenticación multifactor en Microsoft Entra ID.

Esta decisión supersederá ADR-005 cuando sea aprobada.

---

# 5. Vista Propuesta

```mermaid
sequenceDiagram
    actor Actor
    participant Frontend as Static Web Apps
    participant Entra as Microsoft Entra ID
    participant API as Container Apps / ASP.NET Core
    participant Backend

    Actor->>Frontend: Accede
    Frontend->>Entra: Authorization Code con PKCE
    Entra-->>Frontend: ID token y access token para API
    Frontend->>API: /api + Bearer token
    API->>API: Valida firma, emisor, audiencia y vigencia
    API->>Backend: Identidad corporativa validada
    Backend->>Backend: Resuelve Participante y autorización
    Backend-->>API: Resultado
    API-->>Frontend: Respuesta
```

El navegador conserva el contexto mínimo de autenticación. El Backend conserva la responsabilidad sobre autorización y reglas del dominio.

---

# 6. Registros de Aplicación

## 6.1 Frontend

El registro del Frontend debe:

* Ser una aplicación de una sola página.
* Utilizar únicamente destinos de retorno aprobados.
* Mantener destinos separados por Ambiente.
* No tener secreto de cliente.
* Solicitar únicamente los scopes necesarios.
* Limitarse al tenant corporativo cuando corresponda.

## 6.2 API

El registro de la API debe:

* Definir una audiencia estable.
* Exponer scopes explícitos.
* Aceptar únicamente emisores corporativos aprobados.
* Mantener configuración separada por Ambiente cuando la política lo exija.

Los nombres, identificadores y scopes concretos deben definirse durante la implementación conforme a EST-004.

---

# 7. Identidad Estable

La identidad autenticada se representará mediante:

* Identificador del tenant.
* Object identifier de la identidad dentro del tenant.

La combinación debe:

* Provenir exclusivamente de un token validado.
* No ser controlable por el consumidor.
* Permanecer separada del correo y nombre visible.
* Permitir relacionar acciones con su responsable.

Correo, nombre y otros datos descriptivos pueden utilizarse para presentación, pero no como clave de autorización.

El Backend no aceptará `participanteId`, correo u otro identificador enviado libremente como sustituto de la identidad autenticada.

---

# 8. Tokens

## 8.1 ID Token

El ID token representa el resultado de autenticación para el Frontend.

No se utiliza para invocar la API.

## 8.2 Access Token

El access token:

* Está destinado a la API.
* Se envía como Bearer token.
* Tiene vigencia limitada.
* No se registra.
* No se incluye en rutas.
* No se persiste en `localStorage`.

## 8.3 Renovación

MSAL intentará adquirir tokens de forma silenciosa cuando el contexto y las políticas lo permitan.

Si la renovación requiere interacción:

* El Frontend conserva el destino seguro.
* Inicia nuevamente el flujo.
* No confirma acciones que no hayan obtenido resultado del Backend.

Las duraciones y políticas provienen de Microsoft Entra ID y de la configuración corporativa.

---

# 9. Almacenamiento en el Navegador

La estrategia inicial utilizará memoria.

Consecuencias:

* Una recarga puede requerir reconstruir el contexto mediante MSAL.
* Una nueva pestaña puede requerir coordinación o nueva autenticación.
* Se reduce la persistencia de tokens ante acceso posterior al navegador.

No se utilizará `localStorage`.

El uso futuro de `sessionStorage` requerirá:

* Una necesidad validada.
* Revisión de amenazas.
* Pruebas de cierre y expiración.
* Confirmación de políticas corporativas.

---

# 10. Validación en la API

ASP.NET Core debe:

* Exigir autenticación por defecto.
* Validar firma con metadatos del proveedor.
* Validar emisor.
* Validar audiencia.
* Validar vigencia.
* Rechazar tokens ausentes, expirados o destinados a otro recurso.
* Obtener la identidad únicamente del principal validado.
* Evitar exponer causas internas de validación.

La API no debe confiar únicamente en:

* Que la solicitud provenga de `/api`.
* El enlace de Static Web Apps.
* `x-ms-client-principal`.
* Encabezados de identidad sin token validado.
* Estado del Frontend.

---

# 11. Autorización

Después de autenticar:

1. La API obtiene tenant y object identifier.
2. El Backend resuelve el Participante para la Iniciativa.
3. Recupera sus Roles de Participación.
4. Evalúa SRS-007.
5. Ejecuta la capacidad únicamente si está permitida.

Los siguientes datos no conceden permisos por sí mismos:

* Grupos de Microsoft Entra ID.
* Roles de aplicación.
* Roles de Static Web Apps.
* Correo o dominio.
* Presencia de un token válido.

Una identidad autenticada puede no ser Participante de una Iniciativa.

---

# 12. Inicio y Cierre

## 12.1 Inicio

El Frontend:

1. Detecta ausencia de contexto.
2. Inicia redirección hacia Microsoft Entra ID.
3. Valida el retorno mediante MSAL.
4. Obtiene un access token para la API.
5. Continúa al destino validado.

## 12.2 Cierre

El cierre debe:

* Limpiar cuentas y tokens mantenidos por MSAL.
* Finalizar el contexto local.
* Coordinar cierre con Microsoft Entra ID cuando la política lo requiera.
* Limpiar información protegida del Frontend.
* Evitar reutilizar el contexto cerrado.

El alcance del cierre entre aplicaciones y dispositivos permanece sujeto a la política corporativa.

---

# 13. Static Web Apps y Container Apps

El enlace entre plataformas:

* Mantiene las solicitudes de la API bajo `/api`.
* Reduce la exposición directa del Backend.
* No sustituye la validación del access token.
* No define permisos del dominio.

Se debe probar que:

* El encabezado `Authorization` llega intacto a ASP.NET Core.
* Solicitudes directas al ingreso del Backend son rechazadas.
* Encabezados `x-ms-client-principal` manipulados no autentican.
* Un token para otra audiencia es rechazado.
* Un token válido sin Participante no obtiene acceso.

---

# 14. Seguridad del Frontend

Debido a que el access token existe en el navegador, el Frontend debe:

* Aplicar una política de seguridad de contenido compatible.
* Evitar scripts no necesarios.
* Controlar dependencias y actualizaciones.
* Evitar HTML no confiable.
* No registrar tokens.
* No incluir tokens en errores, métricas o trazas.
* Mantener secretos fuera del artefacto.
* Validar destinos de retorno.

Una vulnerabilidad de ejecución de scripts puede exponer el token mantenido en memoria. Esta es la principal consecuencia de utilizar un Frontend estático.

---

# 15. Errores

La API debe distinguir:

* Autenticación requerida.
* Token inválido o expirado.
* Identidad válida sin Participante.
* Acción no permitida.
* Regla del dominio incumplida.
* Fallo del proveedor o de metadatos.

Las respuestas no deben exponer:

* Token.
* Claims completas.
* Configuración del proveedor.
* Detalles de validación explotables.
* Trazas.

---

# 16. Observabilidad

Se debe poder conocer:

* Inicios exitosos y fallidos en la medida permitida.
* Fallos de adquisición y renovación.
* Rechazos por token ausente, inválido o expirado.
* Rechazos por audiencia o emisor.
* Identidades válidas sin Participante.
* Fallos técnicos del proveedor.

Los registros:

* No contienen tokens.
* No contienen claims completas.
* No convierten object identifiers en dimensiones de métricas.
* No reemplazan el Historial.

---

# 17. Pruebas

La estrategia debe verificar:

* Inicio mediante redirección.
* Authorization Code con PKCE.
* Destino de retorno inválido.
* Solicitud sin token.
* Token expirado.
* Firma inválida.
* Emisor incorrecto.
* Audiencia incorrecta.
* Token de otro Ambiente.
* Renovación silenciosa.
* Renovación que requiere interacción.
* Cierre.
* Recarga y nueva pestaña.
* Identidad sin Participante.
* Roles distintos por Iniciativa.
* Ausencia de tokens en registros, rutas y errores.
* Rechazo de encabezados manipulados.

---

# 18. Consecuencias

## 18.1 Positivas

* Funciona con Azure Static Web Apps.
* Utiliza estándares OAuth 2.0 y OpenID Connect.
* No requiere secreto en el Frontend.
* La API valida cada solicitud.
* Utiliza un identificador corporativo estable.
* Mantiene permisos dentro de Arauco Project Hub.
* Evita depender de `userId` de Static Web Apps.
* No incorpora un componente adicional de sesión.

## 18.2 Costos y Restricciones

* El access token existe en el navegador.
* El equipo debe configurar y mantener MSAL.
* Se requieren registros de aplicación y scopes.
* La experiencia depende de políticas y disponibilidad de Microsoft Entra ID.
* La recarga y múltiples pestañas requieren tratamiento explícito.

## 18.3 Riesgos

### Extracción de token

Código no confiable puede acceder al token.

Mitigación:

* Memoria como almacenamiento inicial.
* Política de seguridad de contenido.
* Control de dependencias.
* Tokens de corta vigencia.

### Claims usadas como permisos

Grupos externos pueden convertirse en una segunda fuente de autorización.

Mitigación:

* Utilizar claims solo para identidad.
* Aplicar SRS-007 en el Backend.

### Configuración cruzada entre Ambientes

Un token puede enviarse a una API equivocada.

Mitigación:

* Audiencias y destinos de retorno separados.
* Validación estricta.
* Pruebas entre Ambientes.

---

# 19. Criterios de Cumplimiento

La implementación cumple cuando:

* Utiliza Microsoft Entra ID.
* Utiliza Authorization Code con PKCE.
* El Frontend no tiene secreto.
* Utiliza MSAL.
* Mantiene tokens en memoria inicialmente.
* No utiliza `localStorage`.
* Envía access tokens destinados a la API.
* ASP.NET Core valida firma, emisor, audiencia y vigencia.
* Utiliza tenant y object identifier como identidad estable.
* Mantiene Participante y Roles de Participación en el dominio.
* No utiliza grupos externos como permisos.
* Rechaza solicitudes directas y encabezados manipulados.
* Implementa inicio, renovación, expiración y cierre.
* No expone tokens en registros, rutas o errores.

---

# 20. Cuándo Revisar

Esta decisión deberá revisarse si:

* La política corporativa prohíbe access tokens en aplicaciones de una sola página.
* Microsoft Entra ID no es el proveedor disponible.
* Static Web Apps no propaga `Authorization` al Backend enlazado.
* Se requiere una sesión central invalidable de forma inmediata.
* Aparecen consumidores distintos del Frontend.
* Se incorpora un componente de servidor para el Frontend.
* Los requisitos de seguridad justifican un Backend for Frontend.

---

# 21. Supersesión

Cuando este ADR sea Approved:

* Supersederá ADR-005 - Proveedor de Identidad y Estrategia de Sesión.
* Mantendrá vigentes sus decisiones de no administrar contraseñas, utilizar identidad federada y separar identidad, Participante, autorización e Historial.
* Reemplazará la preferencia por sesión mediada por servidor Nuxt.

ADR-005 permanecerá sin modificaciones como registro histórico de la decisión anterior.

---

# 22. Trazabilidad

Este ADR deriva principalmente de:

* SRS-006 - Requerimientos No Funcionales.
* SRS-007 - Modelo de Permisos.
* ADR-003 - Frontend con Nuxt 4.
* ADR-004 - Backend con .NET 10.
* ADR-005 - Proveedor de Identidad y Estrategia de Sesión.
* ADR-008 - Plataforma y Estrategia de Despliegue.
* Arquitectura de Seguridad.
* Autenticación.
* EST-002 - Estándar Azure.
* EST-005 - CI/CD.

---

# 23. Fuentes Técnicas Consultadas

* [Autenticación en Azure Static Web Apps](https://learn.microsoft.com/en-us/azure/static-web-apps/add-authentication).
* [Autenticación personalizada en Azure Static Web Apps](https://learn.microsoft.com/en-us/azure/static-web-apps/authentication-custom).
* [Información de actores en Azure Static Web Apps](https://learn.microsoft.com/en-us/azure/static-web-apps/user-information).
* [Azure Static Web Apps con Azure Container Apps](https://learn.microsoft.com/en-us/azure/static-web-apps/apis-container-apps).
* [Autenticación en Azure Container Apps](https://learn.microsoft.com/en-us/azure/container-apps/authentication).
* [Autenticación de aplicaciones y actores con Microsoft Entra ID](https://learn.microsoft.com/en-us/entra/architecture/authenticate-applications-and-users).

Las fuentes técnicas respaldan las capacidades y restricciones actuales. La decisión se fundamenta en los documentos Approved de Arauco Project Hub.

---

# 24. Validaciones de Implementación

Antes de implementar esta decisión se debe:

* Confirmar Microsoft Entra ID como proveedor corporativo.
* Confirmar Authorization Code con PKCE para aplicaciones de una sola página.
* Confirmar políticas de acceso condicional y autenticación multifactor.
* Definir registros de aplicación por Ambiente.
* Definir scopes y audiencias.
* Confirmar object identifier y tenant como clave corporativa.
* Probar propagación de `Authorization` mediante el Backend enlazado.
* Probar validación de tokens en ASP.NET Core 10.
* Probar adquisición silenciosa, expiración y cierre.
* Evaluar la experiencia con almacenamiento en memoria.
* Completar modelado de amenazas del Frontend estático.

---

# 25. Siguiente Paso

Revisar este Draft con Seguridad, Identidad, el Technical Lead y el equipo de Desarrollo.

Después de aprobar ADR-009, actualizar el estado de ADR-005 a Superseded mediante una revisión controlada y preparar la primera capacidad trazable de implementación.

---

# 26. Estado del Documento

**Estado actual:** Approved

Este ADR constituye la fuente oficial para la autenticación y sesión compatibles con el Frontend estático de Arauco Project Hub.
