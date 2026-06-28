# Arauco Project Hub

## Engineering Playbook

# Autenticación

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define el contrato y flujo general de autenticación de Arauco Project Hub.

Su propósito es establecer cómo el Frontend obtiene y mantiene un contexto de autenticación y cómo la API valida la identidad en cada solicitud protegida, manteniendo separados identidad, sesión, autorización y reglas del dominio.

Este documento no selecciona proveedor, protocolo, credencial ni mecanismo de sesión.

---

# 2. Alcance

Este documento establece:

* Responsabilidades del Frontend y de la API.
* Inicio, continuidad, expiración y cierre de autenticación.
* Información mínima de identidad.
* Tratamiento general de errores.
* Relación entre identidad y Participante.
* Criterios de seguridad y pruebas.

Quedan fuera del alcance:

* Selección del proveedor de identidad.
* OAuth, OpenID Connect u otro protocolo concreto.
* Cookies, tokens u otra credencial concreta.
* Duraciones y renovación.
* Autenticación multifactor.
* Recuperación de cuentas.
* Permisos y autorización detallados.
* Identidades técnicas de integraciones.

---

# 3. Principios

* Toda capacidad no pública requiere identidad autenticada.
* El Frontend no valida definitivamente una identidad.
* La API valida la credencial en cada solicitud protegida.
* La identidad no reemplaza al Participante ni al Rol de Participación.
* Estar autenticado no implica estar autorizado.
* El consumidor no puede elegir libremente la identidad responsable.
* Las credenciales no deben exponerse en rutas, registros ni mensajes.
* La ausencia o invalidez de autenticación no modifica información.

---

# 4. Responsabilidades

## 4.1 Proveedor de Identidad

Debe:

* Autenticar la identidad mediante el mecanismo aprobado.
* Entregar evidencia verificable de autenticación.
* Permitir expiración e invalidación conforme a la política aprobada.

El proveedor permanece Pendiente.

## 4.2 Frontend

Debe:

* Iniciar el flujo de autenticación.
* Mantener únicamente el contexto requerido.
* Adjuntar o presentar la credencial según el mecanismo aprobado.
* Detectar expiración o rechazo.
* Limpiar información protegida al cerrar o perder la autenticación.
* No inferir permisos a partir de la identidad.

## 4.3 API

Debe:

* Exigir autenticación en operaciones protegidas.
* Validar integridad, vigencia y destinatario de la credencial cuando corresponda.
* Obtener la identidad exclusivamente desde una credencial validada.
* Rechazar credenciales ausentes, inválidas o expiradas.
* Entregar una identidad validada al Backend.
* No exponer detalles internos de validación.

## 4.4 Backend

Debe:

* Relacionar la identidad validada con el Participante cuando la capacidad lo requiera.
* Evaluar autorización mediante SRS-007.
* Aplicar reglas del dominio después de autorizar.
* Conservar identidad y Participante responsable en acciones relevantes.

---

# 5. Vista General

```mermaid
sequenceDiagram
    actor Actor
    participant Frontend
    participant Identidad as Proveedor de identidad
    participant API
    participant Backend

    Actor->>Frontend: Accede a capacidad protegida
    Frontend->>Identidad: Inicia autenticación
    Identidad-->>Frontend: Evidencia de autenticación
    Frontend->>API: Solicitud protegida
    API->>API: Valida credencial
    API->>Backend: Identidad validada y solicitud
    Backend->>Backend: Resuelve Participante y autorización
    Backend-->>API: Resultado
    API-->>Frontend: Respuesta
```

La forma concreta de intercambiar la evidencia depende del ADR de identidad y sesión.

---

# 6. Información de Identidad

La identidad validada debe proporcionar un identificador:

* Estable.
* No controlado libremente por el consumidor.
* Suficiente para relacionar acciones con su responsable.
* Independiente de datos mutables como nombre visible.

Nombre y otros datos descriptivos pueden utilizarse para presentación, pero no como clave de autorización.

La vinculación entre identidad corporativa y Participante permanece Pendiente.

---

# 7. Inicio de Autenticación

Flujo general:

1. El actor intenta acceder a una capacidad protegida.
2. El Frontend detecta que no existe contexto válido.
3. Inicia el flujo con el proveedor aprobado.
4. El proveedor autentica al actor.
5. El Frontend recibe o establece el contexto conforme al mecanismo elegido.
6. El Frontend continúa hacia el destino permitido.

Reglas:

* El destino de retorno debe validarse.
* Un fallo no debe revelar información protegida.
* El producto no debe solicitar credenciales corporativas directamente salvo que el ADR lo autorice expresamente.

---

# 8. Solicitudes Protegidas

Para cada solicitud:

1. El Frontend construye el contrato de API.
2. Presenta la credencial según el mecanismo aprobado.
3. La API valida la credencial antes de procesar la capacidad.
4. Si es válida, obtiene la identidad.
5. El Backend resuelve la participación y autorización.
6. Solo entonces coordina la capacidad.

La API no debe aceptar un `participanteId`, correo u otro dato del contrato como sustituto de la identidad autenticada.

---

# 9. Expiración e Invalidez

Cuando la credencial está ausente, expirada o es inválida:

* La API rechaza la solicitud.
* No se ejecuta la capacidad.
* No se modifica información.
* La respuesta no revela la causa interna detallada.
* El Frontend descarta el contexto inválido.
* Puede iniciar nuevamente la autenticación cuando sea seguro.

La renovación automática solo se incorporará si el mecanismo aprobado permite hacerlo sin aumentar indebidamente la exposición.

---

# 10. Cierre de Autenticación

El cierre debe:

* Invalidar o retirar el contexto local.
* Limpiar información protegida mantenida por el Frontend.
* Evitar que una navegación posterior reutilice el contexto cerrado.
* Coordinar el cierre con el proveedor cuando el mecanismo lo requiera.

El alcance del cierre entre dispositivos y aplicaciones permanece Pendiente.

---

# 11. Sesión

La estrategia debe definir:

* Dónde reside el estado.
* Cómo se protege.
* Duración máxima e inactividad.
* Renovación.
* Invalidación.
* Comportamiento entre ventanas y dispositivos.
* Protección frente a reutilización y falsificación.

Estas decisiones dependen del proveedor, protocolo, renderizado y despliegue. Deben resolverse mediante ADR antes de implementar.

---

# 12. Autenticación y Autorización

La autenticación responde: “¿qué identidad presenta la solicitud?”.

La autorización responde: “¿puede esa identidad ejecutar esta capacidad en esta Iniciativa?”.

Una identidad autenticada:

* Puede no ser Participante de la Iniciativa.
* Puede tener Roles de Participación distintos en otras Iniciativas.
* No obtiene permisos globales por defecto.
* No puede ejecutar capacidades Pendientes.

---

# 13. Errores

La API debe distinguir conceptualmente:

* Autenticación requerida.
* Credencial inválida o expirada.
* Acción no permitida.
* Fallo técnico del mecanismo de autenticación.

Las respuestas no deben exponer:

* Datos internos de la credencial.
* Reglas de validación explotables.
* Secretos.
* Configuración del proveedor.
* Trazas.

El formato y correspondencia con HTTP deben alinearse con el Diseño de la API.

---

# 14. Protección

* Las comunicaciones deben utilizar cifrado en tránsito.
* Las credenciales no se escriben en registros técnicos.
* Los secretos no se incluyen en el Frontend ni en el repositorio.
* Los Ambientes utilizan configuración y credenciales separadas.
* Los destinos de retorno y orígenes permitidos deben validarse.
* Los mecanismos elegidos deben proteger frente a falsificación, reutilización y extracción de credenciales.

Los controles concretos se definirán con el ADR.

---

# 15. Observabilidad

Se debe poder conocer:

* Intentos exitosos y fallidos en la medida permitida.
* Rechazos por credencial ausente o inválida.
* Fallos técnicos del proveedor.
* Correlación de solicitudes.

Los registros no deben contener credenciales ni datos sensibles completos y no reemplazan el Historial.

---

# 16. Pruebas

La estrategia debe verificar:

* Acceso sin credencial.
* Credencial inválida, expirada o para otro destinatario.
* Alteración y reutilización de credenciales.
* Inicio y cierre.
* Expiración durante una interacción.
* Acceso directo a la API.
* Identidad autenticada sin Participante.
* Identidad con roles distintos por Iniciativa.
* Ausencia de credenciales en rutas, errores y registros.
* Fallo o indisponibilidad del proveedor.

---

# 17. Criterios de Cumplimiento

La implementación cumple cuando:

* Toda operación protegida exige identidad válida.
* La API valida cada solicitud.
* El consumidor no elige la identidad responsable.
* La identidad se mantiene separada de Participante y permisos.
* Una autenticación válida no evita la autorización.
* Expiración y cierre eliminan el contexto protegido.
* Errores y registros no exponen credenciales.
* El mecanismo puede probarse de forma automatizada.

---

# 18. Trazabilidad

Este documento deriva principalmente de:

* SRS-006: RNF-001 a RNF-011.
* SRS-007 - Modelo de Permisos.
* Arquitectura de Seguridad.
* Arquitectura del Frontend.
* Arquitectura del Backend.
* Diseño de la API.

---

# 19. ADR Requerido

Antes de implementar se debe crear un ADR que evalúe y seleccione conjuntamente:

* Proveedor de identidad.
* Protocolo.
* Tipo de aplicación y flujo.
* Estrategia de sesión.
* Almacenamiento y transporte de credenciales.
* Cierre, renovación e invalidación.

La decisión debe considerar Nuxt 4, ASP.NET Core 10, despliegue, navegadores corporativos y controles de Arauco.

---

# 20. Pendientes

* Identificar proveedores corporativos disponibles.
* Validar requisitos de Seguridad de Arauco.
* Seleccionar protocolo y flujo.
* Definir estrategia de sesión.
* Definir vinculación con Participante.
* Definir duración, renovación e invalidación.
* Definir comportamiento de cierre.
* Definir respuestas HTTP definitivas.
* Definir observabilidad y retención.

---

# 21. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para el diseño general de Autenticación de Arauco Project Hub.
