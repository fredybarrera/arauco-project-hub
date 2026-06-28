# Arauco Project Hub

## Software Requirements Specification

# SRS-006 - Requerimientos No Funcionales

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Objetivo

Este documento define los Requerimientos No Funcionales iniciales de Arauco Project Hub.

Su propósito es establecer atributos de calidad y restricciones verificables que protejan la seguridad, confiabilidad, rendimiento, accesibilidad, mantenibilidad y operación del producto sin imponer decisiones tecnológicas prematuras.

Este documento define condiciones que debe satisfacer el producto. No selecciona servicios, bibliotecas, infraestructura ni mecanismos de implementación.

---

# 2. Alcance

Este documento comprende:

* Seguridad y protección de la información.
* Privacidad y datos sensibles.
* Disponibilidad y continuidad.
* Rendimiento y capacidad.
* Integridad y consistencia.
* Accesibilidad y experiencia.
* Compatibilidad.
* Observabilidad.
* Mantenibilidad y calidad.
* Despliegue, recuperación y operación.

Quedan fuera del alcance:

* Proveedor de identidad.
* Servicios de infraestructura.
* Topología de despliegue.
* Herramientas de observabilidad.
* Tecnología de persistencia.
* Navegadores concretos todavía no validados.
* SLA, RPO, RTO y umbrales cuantitativos todavía no aprobados.

---

# 3. Principios

* Los atributos de calidad deben proteger el contexto y la trazabilidad de la Iniciativa.
* La seguridad no debe depender únicamente del Frontend.
* La observabilidad técnica no reemplaza el Historial.
* La recuperación no debe producir estados parciales o inconsistentes.
* Las restricciones deben ser proporcionales al riesgo y a la necesidad real.
* Todo umbral cuantitativo debe contar con fuente y responsable de validación.
* Una decisión tecnológica importante derivada de estos requerimientos debe documentarse mediante ADR.

---

# 4. Seguridad

## RNF-001 - Autenticación

El producto debe exigir una identidad autenticada para acceder a capacidades e información no pública.

**Verificación:**

* Una solicitud sin identidad válida no accede a información protegida.
* La identidad utilizada por el Backend puede relacionarse con el actor responsable.

El proveedor y mecanismo de autenticación permanecen Pendientes.

## RNF-002 - Autorización en el Backend

El Backend debe verificar la autorización de cada acción protegida.

**Verificación:**

* Ocultar una acción en el Frontend no permite ejecutarla directamente en la API.
* Una acción no autorizada no modifica información.

Los permisos específicos deben derivarse de SRS-007.

## RNF-003 - Menor privilegio

El producto debe otorgar únicamente el acceso necesario para cada responsabilidad aprobada.

**Verificación:**

* Un actor no puede ejecutar capacidades que no le corresponden.
* Las credenciales técnicas no entregan privilegios mayores a los requeridos.

## RNF-004 - Protección durante la comunicación

Toda comunicación que incluya información o credenciales protegidas debe utilizar canales cifrados.

**Verificación:**

* Los accesos no cifrados son rechazados o redirigidos de forma segura según el límite aprobado.
* Las credenciales no se transmiten como texto visible.

## RNF-005 - Protección de información almacenada

La información sensible debe protegerse durante su almacenamiento conforme a su clasificación corporativa.

La clasificación, alcance y mecanismo permanecen Pendientes de validación con Seguridad.

## RNF-006 - Gestión de secretos

Credenciales, claves y secretos no deben almacenarse en código fuente, documentos públicos ni configuración versionada.

**Verificación:**

* El repositorio puede revisarse sin encontrar secretos operacionales.
* Los secretos pueden rotarse sin modificar el Modelo de Dominio.

## RNF-007 - Validación de entradas

Todo dato externo debe validarse antes de utilizarse.

**Verificación:**

* Datos con forma inválida son rechazados.
* El rechazo no expone trazas ni información interna.
* La validación del Frontend no reemplaza la validación del Backend.

## RNF-008 - Errores seguros

Los errores públicos no deben exponer excepciones internas, consultas, rutas físicas, secretos ni información sensible.

---

# 5. Privacidad y Protección de Datos

## RNF-009 - Minimización de datos

El producto debe solicitar, presentar y conservar únicamente la información necesaria para una capacidad aprobada.

## RNF-010 - Exposición controlada

La API y el Frontend deben evitar exponer información que el actor no necesita para completar su responsabilidad.

## RNF-011 - Registros técnicos

Los registros técnicos no deben contener secretos ni información sensible completa.

Las reglas de enmascaramiento y retención permanecen Pendientes de clasificación.

---

# 6. Disponibilidad y Continuidad

## RNF-012 - Disponibilidad

El producto debe estar disponible durante las ventanas de uso acordadas por la organización.

El porcentaje objetivo y las exclusiones por mantenimiento permanecen Pendientes.

## RNF-013 - Fallos controlados

Ante la indisponibilidad de una dependencia, el producto debe:

* Evitar corrupción o cambios parciales.
* Comunicar que la acción no pudo completarse.
* Permitir recuperación o reintento cuando la operación sea segura.
* Conservar información suficiente para diagnóstico.

## RNF-014 - Continuidad de trazabilidad

Un fallo técnico no debe producir un cambio de estado sin su evento de Historial correspondiente cuando ambos formen parte de la misma operación.

## RNF-015 - Mantenimiento planificado

Los mantenimientos que afecten disponibilidad deben poder ejecutarse de forma controlada y comunicarse a los actores por el mecanismo que se defina.

---

# 7. Rendimiento y Capacidad

## RNF-016 - Tiempo de respuesta

Las consultas y acciones interactivas deben responder dentro de objetivos medibles acordados para cada categoría de operación.

Los percentiles, tiempos y condiciones de medición permanecen Pendientes.

## RNF-017 - Operaciones prolongadas

Una operación que no pueda completarse dentro del tiempo interactivo acordado debe evitar bloquear indefinidamente al actor y comunicar su estado mediante un mecanismo aprobado.

Este requerimiento no autoriza incorporar procesamiento asíncrono sin una decisión arquitectónica.

## RNF-018 - Capacidad

El producto debe soportar el volumen validado de:

* Actores concurrentes.
* Iniciativas.
* Solicitudes.
* Documentos.
* Conversaciones.
* Eventos del Historial.

Los volúmenes objetivo y su horizonte permanecen Pendientes.

## RNF-019 - Degradación controlada

El aumento de carga no debe provocar pérdida silenciosa de información ni saltarse reglas del dominio.

---

# 8. Integridad y Consistencia

## RNF-020 - Consistencia de cambios

Una acción que modifique el Aggregate debe completar o revertir conjuntamente los cambios que requieran consistencia inmediata.

## RNF-021 - Conflictos de concurrencia

El producto debe detectar y comunicar intentos de sobrescribir un estado más reciente.

La estrategia concreta permanece Pendiente junto con la persistencia.

## RNF-022 - Integridad referencial

La persistencia debe impedir relaciones que contradigan el Modelo Relacional aprobado.

## RNF-023 - Conservación

Cerrar o Cancelar una Iniciativa o Solicitud no debe eliminar sus Documentos, Conversaciones ni Historial.

## RNF-024 - Fechas

Las fechas deben almacenarse y transmitirse sin ambigüedad, preservando el instante real de las acciones relevantes.

La zona de presentación puede adaptarse al contexto del actor sin modificar el instante registrado.

---

# 9. Accesibilidad y Experiencia

## RNF-025 - Operación mediante teclado

Las capacidades interactivas deben poder utilizarse mediante teclado.

## RNF-026 - Estructura y etiquetas

La interfaz debe utilizar estructura semántica y asociar etiquetas, ayudas y errores con sus controles.

## RNF-027 - Comunicación no dependiente del color

El estado, los errores y los resultados no deben comunicarse únicamente mediante color.

## RNF-028 - Foco y mensajes

Después de una navegación, validación o acción, el foco y los mensajes deben permitir comprender el resultado y continuar.

## RNF-029 - Estándar de accesibilidad

El nivel y versión del estándar corporativo de accesibilidad deben validarse antes de definir criterios cuantitativos de cumplimiento.

## RNF-030 - Simplicidad de registro

El registro de información debe solicitar solo datos necesarios y evitar repetir datos disponibles en el contexto.

---

# 10. Compatibilidad

## RNF-031 - Navegadores

El Frontend debe funcionar en los navegadores y versiones corporativas aprobadas.

La matriz de soporte permanece Pendiente.

## RNF-032 - Diseño adaptable

La interfaz debe conservar comprensión y operación en los tamaños de pantalla definidos para los actores.

Los dispositivos y resoluciones objetivo permanecen Pendientes.

## RNF-033 - Contratos de API

Los cambios de contratos deben preservar compatibilidad o contar con una estrategia explícita de transición.

---

# 11. Observabilidad

## RNF-034 - Correlación

Las interacciones técnicas deben poder correlacionarse a través del Frontend, la API, el Backend y las adaptaciones involucradas.

## RNF-035 - Registros técnicos

El producto debe registrar información suficiente para diagnosticar fallos sin duplicar el Historial ni exponer datos sensibles.

## RNF-036 - Señales operacionales

La operación debe contar con señales que permitan conocer:

* Disponibilidad.
* Errores.
* Rendimiento.
* Uso de recursos técnicos.
* Estado de dependencias.

Las métricas, umbrales y alertas permanecen Pendientes.

## RNF-037 - Separación del Historial

Los registros, métricas y trazas técnicas no reemplazan los eventos funcionales del Historial.

---

# 12. Mantenibilidad y Calidad

## RNF-038 - Dependencias hacia el dominio

El Modelo de Dominio debe poder probarse sin Frontend, ASP.NET Core, persistencia ni integraciones.

## RNF-039 - Límites verificables

Las validaciones automatizadas deben detectar dependencias que contradigan la arquitectura aprobada.

## RNF-040 - Pruebas automatizadas

Cada cambio debe incorporar pruebas proporcionales al riesgo y a la responsabilidad modificada.

La estrategia y los umbrales de cobertura permanecen Pendientes.

## RNF-041 - Reproducibilidad

La construcción y las pruebas deben poder ejecutarse de manera repetible desde el monorepo con dependencias declaradas.

## RNF-042 - Actualizaciones controladas

Las actualizaciones de dependencias deben verificar compatibilidad, seguridad y comportamiento antes de incorporarse.

## RNF-043 - Lenguaje Ubicuo

Documentación, API, interfaz y código deben utilizar el Lenguaje Ubicuo cuando representen conceptos del dominio.

---

# 13. Despliegue y Recuperación

## RNF-044 - Despliegue verificable

Todo despliegue del producto debe permitir identificar la versión desplegada y verificar su resultado.

## RNF-045 - Reversión

Un cambio que afecte la operación debe contar con una estrategia de reversión o recuperación proporcional a su riesgo.

## RNF-046 - Respaldo

La información necesaria para reconstruir el contexto de las Iniciativas debe incluirse en una estrategia de respaldo.

La frecuencia, retención y alcance permanecen Pendientes.

## RNF-047 - Recuperación

La recuperación debe conservar integridad, relaciones y trazabilidad.

RPO y RTO permanecen Pendientes de validación con los responsables del Negocio y Operación.

## RNF-048 - Separación de Ambientes

Los Ambientes deben mantener configuración, credenciales e información operacional separadas.

---

# 14. Verificación y Evidencia

Cada Requerimiento No Funcional aprobado debe relacionarse con uno o más mecanismos de evidencia:

* Prueba automatizada.
* Prueba de seguridad.
* Prueba de carga.
* Revisión de accesibilidad.
* Validación de arquitectura.
* Ejercicio de recuperación.
* Métrica o alerta operacional.
* Revisión documental.

Los valores objetivo deben registrar:

* Fuente de la necesidad.
* Condiciones de medición.
* Ambiente de evaluación.
* Responsable de aprobación.
* Frecuencia de revisión.

---

# 15. Trazabilidad

| Requerimientos | Fuente principal |
| --- | --- |
| RNF-001 a RNF-011 | PHIL-001, Arquitectura del Backend, Arquitectura del Frontend y Diseño de la API |
| RNF-012 a RNF-019 | SRS-001, PHIL-001 y continuidad operacional |
| RNF-020 a RNF-024 | SRS-003, SRS-004, SRS-010 y Arquitectura del Backend |
| RNF-025 a RNF-030 | PHIL-001 y Arquitectura del Frontend |
| RNF-031 a RNF-033 | ADR-003 y Diseño de la API |
| RNF-034 a RNF-037 | PHIL-001 y documentos de arquitectura aprobados |
| RNF-038 a RNF-043 | ADR-001 a ADR-004 y documentos de arquitectura aprobados |
| RNF-044 a RNF-048 | SRS-004, continuidad y trazabilidad del producto |

---

# 16. Pendientes

* Validar clasificación de información y controles corporativos de Seguridad.
* Definir permisos mediante SRS-007.
* Definir porcentaje y ventanas de disponibilidad.
* Definir objetivos de tiempo de respuesta.
* Definir volúmenes y concurrencia.
* Definir RPO, RTO, respaldo y retención.
* Definir navegadores, dispositivos y estándar de accesibilidad.
* Definir métricas, alertas y retención de observabilidad.
* Definir estrategia y alcance de pruebas.
* Definir requisitos corporativos de despliegue y operación.
* Priorizar los Requerimientos No Funcionales para el alcance inicial.

Estos valores deben validarse con los responsables correspondientes antes de aprobar este documento.

---

# 17. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial de Requerimientos No Funcionales de Arauco Project Hub.
