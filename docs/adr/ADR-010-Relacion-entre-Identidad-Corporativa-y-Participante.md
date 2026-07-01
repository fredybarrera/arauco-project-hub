# Arauco Project Hub

## Architecture Decision Record

# ADR-010 - Relación entre Identidad Corporativa y Participante

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Contexto

ADR-009 define tenant y object identifier como identidad corporativa estable obtenida desde un token validado.

SRS-007 exige verificar que el actor sea Participante de la Iniciativa antes de autorizar CU-002 - Consultar una Iniciativa.

El modelo aprobado representa en Participante:

* Iniciativa.
* Identificación de la persona o equipo.
* Nombre.
* Rol de Participación.

La Identificación de la persona o equipo no fue definida como identificador de Microsoft Entra ID. Utilizarla directamente para autorización asumiría una equivalencia no aprobada.

También se debe conservar la diferencia entre:

* Identidad autenticada.
* Participante.
* Rol de Participación.
* Permisos dentro de una Iniciativa.

Sprint 1 exige resolver esta relación antes de implementar CU-002.

---

# 2. Fuerzas de Decisión

La alternativa debe:

* Utilizar únicamente claims provenientes de un token validado.
* Relacionar la identidad con Participante dentro de una Iniciativa.
* No utilizar correo o nombre como clave de autorización.
* No convertir grupos o roles externos en permisos del dominio.
* Mantener la Identificación de la persona o equipo con su significado aprobado.
* Permitir Participantes que representen personas o equipos.
* Evitar una entidad o servicio adicional sin necesidad demostrada.
* Mantener una restricción de unicidad verificable.
* Permitir una evolución posterior si aparecen varios proveedores o identidades por persona.
* Mantener la implementación inicial simple.

---

# 3. Opciones Consideradas

## 3.1 Reutilizar la Identificación de la persona o equipo

Guardar object identifier o una combinación de tenant y object identifier en `identificacion_persona_equipo`.

### Ventajas

* No requiere nuevos datos.
* Reduce el cambio inicial de persistencia.

### Desventajas

* Cambia el significado de un dato aprobado.
* Mezcla identificación funcional e identidad autenticada.
* No representa correctamente a equipos.
* Hace depender un dato del dominio de un proveedor técnico.
* Dificulta distinguir errores de vinculación.

## 3.2 Incorporar la identidad corporativa en Participante

Agregar tenant y object identifier como datos técnicos opcionales y conjuntos de Participante.

### Ventajas

* Mantiene la autorización dentro del contexto de la Iniciativa.
* No altera el significado de la Identificación de la persona o equipo.
* No requiere una entidad adicional.
* Permite una consulta directa para CU-002.
* Mantiene separados Rol de Participación e identidad.

### Desventajas

* Repite la misma identidad cuando una persona participa en varias Iniciativas.
* Requiere revisar el Modelo Relacional, DER y Diccionario de Datos.
* No resuelve por sí sola múltiples identidades para una persona.

## 3.3 Crear un registro global de identidad corporativa

Crear una estructura técnica global y relacionarla con uno o más Participantes.

### Ventajas

* Evita repetir tenant y object identifier.
* Centraliza cambios y desactivación de una identidad.
* Puede admitir varios proveedores o identidades en el futuro.

### Desventajas

* Agrega una estructura y relaciones que CU-002 no necesita.
* Requiere definir ciclo de vida, sincronización y administración.
* Introduce complejidad antes de contar con una necesidad aprobada.

## 3.4 Aprovisionar Participantes automáticamente

Crear o vincular un Participante durante el primer acceso a partir de claims externas.

### Ventajas

* Reduce preparación manual.
* Permite acceso inmediato después de autenticarse.

### Desventajas

* Confunde autenticación con participación.
* Puede otorgar contexto sin una decisión aprobada.
* No determina de forma segura el Rol de Participación.
* Convierte claims externas en fuente indirecta de autorización.

---

# 4. Decisión Propuesta

Se propone:

1. Incorporar tenant y object identifier como datos técnicos opcionales de Participante.
2. Tratar ambos datos como una unidad: están presentes juntos o ausentes juntos.
3. Mantener Identificación de la persona o equipo como un dato distinto.
4. Utilizar tenant y object identifier únicamente después de validar el token.
5. Resolver el Participante dentro de la Iniciativa solicitada.
6. Exigir unicidad de tenant y object identifier dentro de una Iniciativa.
7. No crear automáticamente un Participante durante el inicio de sesión.
8. No derivar Rol de Participación desde grupos, roles o claims externas.
9. No utilizar correo, nombre visible ni Identificación de la persona o equipo como sustitutos.
10. Permitir que un Participante que representa un equipo no tenga identidad corporativa asociada.
11. No autorizar como actor a un Participante sin identidad corporativa asociada.
12. No crear un registro global de identidad en la implementación inicial.

La identidad corporativa es un detalle técnico de autenticación. No constituye un nuevo actor, Rol de Participación ni concepto del dominio.

---

# 5. Reglas de Vinculación

La vinculación debe cumplir:

* El tenant corresponde al tenant aprobado para el Ambiente.
* El object identifier corresponde a la identidad dentro de ese tenant.
* La combinación se obtiene de claims validadas.
* La combinación no se acepta desde parámetros, encabezados propios o cuerpo de la solicitud.
* Un Participante no puede tener solo uno de los dos datos.
* La misma combinación no puede identificar dos Participantes dentro de una Iniciativa.
* La misma persona puede participar en distintas Iniciativas.
* Correo y nombre pueden cambiar sin alterar la vinculación.

---

# 6. Resolución para CU-002

Para consultar una Iniciativa:

1. La API valida el access token.
2. La API obtiene tenant y object identifier.
3. El Backend recibe la identidad validada.
4. La persistencia busca un Participante con esa combinación dentro de la Iniciativa solicitada.
5. Si existe, MP-001 permite la consulta.
6. Si no existe, no se expone información de la Iniciativa.

La resolución se realiza dentro del contexto de la Iniciativa. No se utiliza una consulta global como autorización suficiente.

---

# 7. Participantes que Representan Equipos

Un equipo puede permanecer como Participante conforme al modelo aprobado.

La pertenencia de una persona a un equipo y la autorización para actuar en su nombre no están definidas por los documentos Approved.

Por lo tanto:

* Un Participante que representa un equipo no se vincula automáticamente con grupos de Microsoft Entra ID.
* No se interpretan grupos externos como Roles de Participación.
* La autorización de personas por pertenencia a equipos permanece fuera del alcance.

---

# 8. Persistencia

Si este ADR es aprobado, la revisión controlada del modelo debe incorporar:

* Identificador del tenant en Participante.
* Object identifier en Participante.
* Regla de presencia conjunta.
* Unicidad de ambos datos dentro de una Iniciativa.
* Protección frente a valores vacíos.

Los nombres físicos, tipos, longitudes e índices se definirán conforme a EST-004 y ADR-006.

Antes de implementar se deben revisar:

* SRS-010 - Modelo Relacional.
* DER.
* Diccionario de Datos.

Este ADR no modifica por sí solo documentos Approved de mayor prioridad.

---

# 9. Seguridad

La implementación debe:

* Validar firma, emisor, audiencia y vigencia antes de leer la identidad.
* Aceptar únicamente el tenant corporativo aprobado.
* No registrar tokens.
* No registrar claims innecesarias.
* No exponer tenant u object identifier en respuestas de CU-002.
* No revelar si la Iniciativa existe cuando el actor no participa.
* Registrar fallos técnicos sin convertirlos en Historial.

---

# 10. Administración de la Vinculación

La capacidad para crear, cambiar o retirar una vinculación no forma parte de CU-002.

Durante la primera implementación:

* Los datos controlados de Desarrollo y pruebas podrán incluir vinculaciones deterministas.
* PRD no debe depender de datos de prueba.
* La administración productiva de vinculaciones requiere una capacidad y autorización aprobadas.

No se implementará un mecanismo administrativo oculto dentro de CU-002.

---

# 11. Consecuencias

## 11.1 Positivas

* CU-002 puede verificar participación con una identidad estable.
* La Identificación de la persona o equipo conserva su significado.
* La autorización permanece contextual por Iniciativa.
* No se incorpora una estructura global prematura.
* Los equipos no se confunden con identidades individuales.

## 11.2 Costos

* La identidad se repite entre Participantes de distintas Iniciativas.
* Se requieren revisiones controladas del modelo de datos.
* Se necesita una capacidad futura para administrar vinculaciones en PRD.

## 11.3 Riesgos

### Vinculación incorrecta

Una combinación asociada al Participante equivocado puede conceder acceso indebido.

**Mitigación:** unicidad, validación, pruebas y futura capacidad administrativa autorizada.

### Dependencia del proveedor

Tenant y object identifier provienen de Microsoft Entra ID.

**Mitigación:** mantenerlos fuera de las reglas del dominio y revisar la decisión si cambia el proveedor.

### Complejidad futura

Varias identidades por persona podrían volver insuficiente la representación propuesta.

**Mitigación:** revisar este ADR cuando exista esa necesidad y evaluar un registro global.

---

# 12. Criterios de Cumplimiento

La implementación cumple esta decisión cuando:

* Tenant y object identifier se obtienen de un token validado.
* Ambos datos están presentes o ausentes juntos.
* La combinación es única dentro de una Iniciativa.
* La resolución produce un Participante de la Iniciativa solicitada.
* Identificación de la persona o equipo mantiene su significado.
* Correo y nombre no se utilizan como claves de autorización.
* No se crea un Participante automáticamente.
* Grupos y roles externos no se convierten en Roles de Participación.
* Un actor sin vinculación no obtiene información de la Iniciativa.

---

# 13. Cuándo Revisar

Esta decisión deberá revisarse si:

* Una persona necesita varias identidades corporativas.
* Se incorpora otro proveedor de identidad.
* Se requiere administrar identidades fuera del contexto de una Iniciativa.
* Se aprueba autorización basada en pertenencia a equipos.
* Se necesita desactivar una identidad de forma global.
* La repetición entre Iniciativas produce una dificultad operacional demostrada.

---

# 14. Trazabilidad

Este ADR deriva principalmente de:

* SRS-003 - Modelo de Dominio.
* SRS-006 - Requerimientos No Funcionales.
* SRS-007 - Modelo de Permisos.
* SRS-009 - Casos de Uso.
* SRS-010 - Modelo Relacional.
* ADR-009 - Autenticación y Sesión para Frontend Estático.
* Arquitectura de Seguridad.
* Autenticación.
* Diccionario de Datos.
* Sprint 0 - Primera Capacidad Trazable.
* Sprint 1 - Implementación de CU-002.

---

# 15. Validaciones de Implementación

Antes de implementar esta decisión se debe:

* Validar que tenant y object identifier sean los datos corporativos disponibles.
* Confirmar que un Participante que representa una persona puede almacenar la vinculación.
* Confirmar la regla de unicidad dentro de una Iniciativa.
* Revisar el tratamiento de Participantes que representan equipos.
* Confirmar el proceso posterior para administrar vinculaciones en PRD.
* Validar la decisión con Seguridad, Identidad y el Technical Lead.

---

# 16. Siguiente Paso

Después de aprobar ADR-010, preparar revisiones controladas de SRS-010, DER y Diccionario de Datos antes de implementar CU-002.

---

# 17. Estado del Documento

**Estado actual:** Approved

Este ADR constituye la fuente oficial para relacionar la identidad corporativa estable con Participante.
