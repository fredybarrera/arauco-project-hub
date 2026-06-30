# Arauco Project Hub

## Engineering Playbook

# EST-002 - Estándar Azure

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-30

---

# 1. Objetivo

Este documento define las condiciones comunes para utilizar los servicios Azure aprobados en Arauco Project Hub.

Su propósito es mantener seguridad, separación entre Ambientes, trazabilidad y control operacional sin seleccionar servicios, configuraciones o topologías que todavía permanecen Pendientes.

---

# 2. Alcance

Este estándar aplica a:

* Azure SQL Database.
* Azure Monitor Application Insights.
* Log Analytics.
* La identidad administrada y Microsoft Entra ID cuando las decisiones aprobadas permiten utilizarlos.
* Los recursos Azure que se aprueben posteriormente para Arauco Project Hub.

Este documento no:

* Selecciona una plataforma de despliegue.
* Define una topología de infraestructura.
* Incorpora servicios Azure adicionales.
* Define nombres concretos de recursos.
* Define infraestructura como código.
* Define regiones, suscripciones, grupos de recursos o redes.
* Sustituye los ADR ni los requerimientos corporativos de Seguridad y Operación.

---

# 3. Principios

## 3.1 Azure sirve al producto

Los servicios Azure son detalles tecnológicos. No definen conceptos, reglas, estados ni relaciones del dominio.

La Iniciativa y el Modelo de Dominio deben permanecer independientes de SDK, identidades, recursos y configuraciones de Azure.

## 3.2 Solo servicios aprobados

Un servicio Azure se puede incorporar únicamente cuando:

* Está respaldado por un ADR Approved.
* Responde a una necesidad aprobada.
* Sus responsabilidades y límites son explícitos.
* Su costo y operación pueden ser evaluados.

La disponibilidad de un servicio en Azure no constituye justificación para utilizarlo.

## 3.3 Separación entre Ambientes

Cada Ambiente debe mantener recursos, configuración, credenciales y señales identificables de forma inequívoca.

No se debe compartir información operacional entre Ambientes cuando esto pueda mezclar datos, permisos, costos o diagnósticos.

## 3.4 Menor privilegio

Toda identidad técnica debe recibir únicamente los permisos necesarios para su responsabilidad.

Se deben preferir mecanismos de identidad sobre secretos persistentes cuando el servicio y la plataforma aprobada lo permitan.

## 3.5 Configuración trazable, secretos protegidos

La configuración no sensible debe poder revisarse y relacionarse con una decisión aprobada.

Credenciales, claves, cadenas de conexión y secretos no deben almacenarse en el repositorio ni en documentos del Engineering Playbook.

---

# 4. Servicios Aprobados

| Responsabilidad | Servicio o capacidad | Condición |
| --- | --- | --- |
| Persistencia relacional | Azure SQL Database | Aprobado por ADR-006 |
| Observabilidad | Azure Monitor Application Insights | Aprobado por ADR-007 |
| Consulta y conservación de señales | Log Analytics | Aprobado por ADR-007 |
| Ingesta de observabilidad de servidor | Microsoft Entra ID e identidad administrada | Preferidos cuando la plataforma de despliegue lo permita |
| Telemetría del navegador | Ingesta local aislada de Application Insights | Permitida únicamente por la limitación documentada en ADR-007 |

Este inventario no autoriza una configuración concreta ni servicios implícitamente relacionados.

---

# 5. Organización de Recursos

Los recursos deben:

* Pertenecer al alcance organizacional autorizado para Arauco Project Hub.
* Identificar su producto, responsabilidad y Ambiente.
* Mantener etiquetas o metadatos de gobierno cuando la política corporativa los exija.
* Tener un responsable técnico y operacional reconocible.
* Evitar agrupar responsabilidades no relacionadas por conveniencia.
* Permitir identificar costos por producto y Ambiente.

La estructura de suscripciones, grupos de recursos, regiones y etiquetas permanece Pendiente de validación corporativa.

Las convenciones concretas de nombres se definirán en EST-004 - Convención de Nombres.

---

# 6. Ambientes

Cada Ambiente debe:

* Utilizar configuración propia.
* Mantener permisos e identidades acotados.
* Evitar acceso accidental desde otro Ambiente.
* Separar datos y señales de Producción.
* Permitir validar cambios antes de Producción.
* Identificarse de forma consistente en observabilidad.

Producción no debe depender de credenciales, datos ni recursos creados exclusivamente para pruebas.

La cantidad y propósito definitivo de Ambientes permanece Pendiente. Este estándar no crea nuevos Ambientes.

---

# 7. Identidad y Acceso

El acceso a recursos Azure debe:

* Preferir identidad administrada cuando la plataforma aprobada la soporte.
* Utilizar Microsoft Entra ID cuando el servicio y la política corporativa lo permitan.
* Aplicar menor privilegio.
* Separar permisos de administración, despliegue y ejecución.
* Evitar credenciales compartidas entre personas, componentes o Ambientes.
* Permitir retirar o rotar acceso sin modificar el Modelo de Dominio.
* Mantener trazabilidad de cambios de permisos mediante las capacidades corporativas disponibles.

La autenticación local debe deshabilitarse cuando la alternativa de identidad aprobada cubra la responsabilidad y la plataforma lo permita.

La excepción de autenticación local para la telemetría del navegador debe permanecer aislada de los recursos de observabilidad de servidor.

Los roles concretos, grupos y procesos de aprobación permanecen Pendientes de la política corporativa.

---

# 8. Configuración y Secretos

La implementación debe:

* Mantener configuración sensible fuera del repositorio.
* Evitar incluir secretos en imágenes, artefactos, registros o respuestas.
* Separar configuración por Ambiente.
* Permitir rotación sin cambiar reglas del dominio.
* Limitar quién puede consultar o modificar secretos y configuración operacional.
* Evitar que una credencial del Frontend otorgue acceso directo a persistencia.

Este estándar no selecciona un servicio de administración de secretos. Su selección requiere una decisión aprobada si introduce una dependencia arquitectónica nueva.

---

# 9. Azure SQL Database

Azure SQL Database debe:

* Implementar el Modelo Relacional, DER y Diccionario de Datos aprobados.
* Ser accedido mediante la adaptación de persistencia del Backend.
* Mantener el Modelo de Dominio independiente del servicio.
* Separar datos y acceso por Ambiente.
* Utilizar conexiones cifradas.
* Preferir identidad administrada cuando la plataforma lo permita.
* Mantener respaldos y recuperación conforme a objetivos validados.
* Mantener migraciones versionadas, revisadas y fuera del inicio automático de Producción.
* Proporcionar señales operacionales sin exponer consultas o valores sensibles.

La capacidad, redundancia, residencia, retención, recuperación, conectividad privada y configuración física permanecen Pendientes.

---

# 10. Azure Monitor Application Insights y Log Analytics

La observabilidad debe:

* Mantener recursos separados por Ambiente.
* Utilizar OpenTelemetry en los componentes de servidor.
* Utilizar W3C Trace Context para correlación.
* Mantener separada la telemetría del navegador cuando requiera autenticación local.
* Preferir Microsoft Entra ID para ingesta de servidor.
* Evitar credenciales, referencias de sesión, cuerpos y datos sensibles completos.
* Mantener dimensiones acotadas.
* No utilizar señales técnicas como sustituto del Historial.
* Controlar volumen, retención y costo a partir de mediciones.
* Restringir consulta y administración según menor privilegio.

No se incorporará un OpenTelemetry Collector sin una necesidad validada y una decisión arquitectónica cuando corresponda.

Los porcentajes de muestreo, retención, límites diarios, alertas y tableros permanecen Pendientes.

---

# 11. Protección de Información

Antes de almacenar o emitir información hacia Azure se debe:

1. Confirmar que el dato es necesario.
2. Conocer su clasificación.
3. Limitar su exposición.
4. Protegerlo durante comunicación y almacenamiento.
5. Definir acceso y retención.
6. Verificar que registros y errores no revelen su contenido.

La región y residencia de datos deben cumplir la política corporativa y las restricciones aplicables antes de habilitar Producción.

Este estándar no define clasificaciones ni períodos de retención que todavía no han sido aprobados.

---

# 12. Continuidad y Recuperación

Cada recurso necesario para operar el producto debe contar, antes de Producción, con:

* Objetivo de disponibilidad validado.
* Responsabilidad operacional definida.
* Estrategia de respaldo cuando corresponda.
* Procedimiento de recuperación verificable.
* Tratamiento de indisponibilidad.
* Evidencia de pruebas proporcional al riesgo.

La indisponibilidad de observabilidad no debe corromper el dominio. La indisponibilidad de persistencia no debe producir cambios parciales ni un Historial inconsistente.

SLA, RPO, RTO, redundancia y ventanas de mantenimiento permanecen Pendientes.

---

# 13. Costos

Todo recurso Azure debe:

* Tener una responsabilidad reconocible.
* Poder asociarse con Arauco Project Hub y su Ambiente.
* Utilizar una capacidad proporcional a mediciones o estimaciones validadas.
* Permitir detectar crecimiento anómalo de consumo.
* Revisarse cuando cambien volumen, retención o topología.

No se fijarán capacidades, presupuestos ni alertas arbitrarias para completar este documento.

---

# 14. Cambios

Un cambio de recurso o configuración debe:

* Derivar de una necesidad aprobada.
* Mantener trazabilidad hacia el documento que lo origina.
* Revisar seguridad, disponibilidad, costo y recuperación.
* Validarse antes de Producción.
* Contar con una estrategia de reversión proporcional al riesgo.

La incorporación de un nuevo servicio Azure o un cambio transversal de topología requiere proponer un ADR.

---

# 15. Criterios de Cumplimiento

Una implementación cumple este estándar cuando:

* Utiliza únicamente servicios Azure aprobados.
* Mantiene el Modelo de Dominio independiente de Azure.
* Separa recursos, configuración, acceso y señales por Ambiente.
* Aplica menor privilegio.
* Mantiene secretos fuera del repositorio.
* Protege información durante comunicación y almacenamiento.
* Mantiene Azure SQL Database conforme a ADR-006.
* Mantiene Application Insights y Log Analytics conforme a ADR-007.
* Permite identificar responsabilidad y costo de cada recurso.
* No resuelve configuraciones Pendientes mediante supuestos.
* Propone un ADR ante un nuevo servicio o una decisión arquitectónica importante.

---

# 16. Trazabilidad

Este estándar deriva principalmente de:

* PHIL-001: FP-005, FP-009, FP-011 y FP-012.
* SRS-006 - Requerimientos No Funcionales.
* ADR-005 - Proveedor de Identidad y Estrategia de Sesión.
* ADR-006 - Tecnología y Estrategia de Persistencia.
* ADR-007 - Plataforma y Estándar de Observabilidad.
* EST-001 - Estándar Tecnológico.
* Arquitectura de Seguridad.
* Arquitectura de Persistencia.
* Arquitectura de Observabilidad.

---

# 17. Validaciones de Implementación

* Confirmar las políticas corporativas aplicables a Azure.
* Confirmar suscripciones, regiones y residencia permitidas.
* Confirmar la clasificación de datos y señales.
* Confirmar los mecanismos corporativos de identidad y acceso.
* Confirmar la plataforma de despliegue.
* Definir los objetivos operacionales que condicionan capacidad y recuperación.
* Confirmar responsables de administración, seguridad, costo y operación.
* Determinar si la administración de secretos requiere una decisión arquitectónica específica.

---

# 18. Siguiente Paso

Después de aprobar EST-002, el siguiente documento propuesto es:

EST-003 - Convención de Repositorios.

Objetivo:

Definir las convenciones aplicables al monorepo aprobado, sin seleccionar herramientas de gestión no justificadas.

---

# 19. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para las condiciones comunes de uso de los servicios Azure aprobados en Arauco Project Hub.
