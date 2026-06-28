# Arauco Project Hub

## Architecture Decision Record

# ADR-006 - Tecnología y Estrategia de Persistencia

**Versión:** 1.0

**Estado:** Approved

**Fecha:** 2026-06-28

---

# 1. Contexto

Arauco Project Hub requiere persistir el contexto completo de cada Iniciativa conforme al Modelo Relacional, el DER y el Diccionario de Datos aprobados.

La persistencia debe reconstruir el estado válido requerido por el dominio, conservar identidades y relaciones, aplicar integridad referencial y mantener de forma consistente los cambios del Aggregate y sus eventos de Historial.

ADR-001 establece que la persistencia se adapta al dominio. ADR-004 selecciona .NET 10, C# y ASP.NET Core 10 para el Backend, pero mantiene Pendientes el motor de base de datos, el acceso a datos, la reconstrucción del Aggregate, la concurrencia y las transacciones.

SRS-006 exige detectar intentos de sobrescribir un estado más reciente. También exige que una acción que modifique el Aggregate complete o revierta conjuntamente los cambios que requieren consistencia inmediata.

SRS-010 ya define un Modelo Relacional. No existe una necesidad aprobada de utilizar persistencia documental, eventos como fuente del estado actual, múltiples motores de base de datos ni una arquitectura distribuida.

---

# 2. Fuerzas de Decisión

La alternativa debe:

* Implementar el Modelo Relacional aprobado.
* Integrarse con .NET 10 y ASP.NET Core 10.
* Permitir que la persistencia se adapte al dominio.
* Reconstruir únicamente el estado válido requerido por cada capacidad.
* Mantener a la Iniciativa como Aggregate Root principal.
* Conservar cambio e Historial de forma atómica cuando pertenecen a la misma operación.
* Aplicar integridad referencial.
* Detectar y comunicar conflictos de concurrencia.
* Permitir consultas eficientes sin exponer estructuras de persistencia.
* Permitir evolución controlada del esquema.
* Favorecer respaldo, recuperación, cifrado y operación administrada.
* Mantener una implementación simple y verificable.

Los volúmenes, objetivos de rendimiento, disponibilidad, recuperación y residencia de datos permanecen Pendientes de validación.

---

# 3. Opciones Consideradas

## 3.1 Azure SQL Database con Entity Framework Core 10

Utilizar Azure SQL Database como motor relacional administrado y Entity Framework Core 10 como tecnología principal de acceso a datos.

### Ventajas

* Implementa naturalmente el Modelo Relacional aprobado.
* Entity Framework Core 10 se alinea con .NET 10 y su ciclo de soporte.
* Permite mapeo explícito sin introducir dependencias de persistencia en el dominio.
* Proporciona seguimiento de cambios, transacciones y concurrencia optimista.
* Permite administrar la evolución del esquema mediante migraciones versionadas.
* Azure SQL Database proporciona operación administrada, respaldos y capacidades de alta disponibilidad.
* Reduce la cantidad de bibliotecas y mecanismos que el equipo debe mantener.

### Desventajas

* Introduce dependencia de Azure SQL Database y Entity Framework Core.
* El seguimiento automático puede cargar o modificar más información de la necesaria si no se controla.
* La reconstrucción de relaciones amplias requiere diseñar consultas explícitas.
* Las migraciones deben gobernarse para evitar cambios accidentales del esquema.
* El costo y la configuración operativa dependen de requisitos todavía Pendientes.

## 3.2 Azure SQL Database con acceso SQL explícito

Utilizar Azure SQL Database con comandos SQL y un componente liviano de mapeo.

### Ventajas

* Entrega control directo sobre las consultas.
* Hace explícito el acceso a datos.
* Reduce el comportamiento implícito de seguimiento y mapeo.

### Desventajas

* Requiere implementar manualmente más mapeo, seguimiento de cambios y reconstrucción.
* Aumenta el código necesario para persistir el Modelo Relacional.
* Exige gobernar de manera adicional las transacciones y la concurrencia.
* No existe una necesidad de rendimiento validada que justifique esta complejidad como estrategia principal.

## 3.3 PostgreSQL con Entity Framework Core 10

Utilizar PostgreSQL como motor relacional y Entity Framework Core 10 mediante su proveedor correspondiente.

### Ventajas

* Implementa el Modelo Relacional aprobado.
* Permite mantener Entity Framework Core como tecnología de acceso a datos.
* Ofrece capacidades relacionales maduras.

### Desventajas

* Incorpora un proveedor adicional respecto de la plataforma .NET seleccionada.
* Su operación administrada y su encaje con la plataforma corporativa requieren validación.
* No presenta una ventaja aprobada frente a Azure SQL Database para las necesidades actuales.

## 3.4 Persistencia documental o Event Sourcing

Utilizar documentos o eventos como representación principal del estado.

### Ventajas

* Puede facilitar determinados patrones de evolución o reconstrucción histórica.
* Event Sourcing conserva una secuencia explícita de eventos.

### Desventajas

* Contradice la dirección relacional ya aprobada o exige una representación adicional.
* Confunde el Historial con la fuente del estado vigente.
* Aumenta la complejidad de consultas, reconstrucción y operación.
* No responde a una necesidad aprobada.

---

# 4. Decisión Propuesta

Se propone:

1. Utilizar Azure SQL Database como tecnología principal de persistencia relacional.
2. Utilizar Entity Framework Core 10 y el proveedor oficial para Azure SQL como tecnología principal de acceso a datos.
3. Mantener el dominio libre de dependencias, atributos y clases de Entity Framework Core.
4. Definir el mapeo mediante configuración explícita dentro de la adaptación de persistencia.
5. Mantener un contexto de persistencia alineado con el módulo Iniciativas, sin convertirlo en una interfaz del dominio.
6. Aplicar el Modelo Relacional, el DER y el Diccionario de Datos aprobados como fuente del esquema.
7. Utilizar migraciones versionadas para evolucionar el esquema; toda migración deberá derivar de documentación aprobada.
8. Reconstruir para cada operación únicamente el contexto del Aggregate requerido para aplicar sus reglas.
9. Evitar la carga automática implícita de relaciones.
10. Utilizar proyecciones sin seguimiento para consultas que no modifican el Aggregate.
11. Utilizar concurrencia optimista mediante un valor técnico de versión administrado por la base de datos en la Iniciativa.
12. Tratar un conflicto de versión como un conflicto de concurrencia y comunicarlo sin sobrescribir el estado más reciente.
13. Persistir en una única transacción local el estado del Aggregate, las entidades relacionadas modificadas y el evento de Historial correspondiente.
14. Utilizar una sola confirmación de cambios por operación siempre que la capacidad pueda completarse de esa forma.
15. No incluir integraciones externas dentro de la transacción de base de datos.
16. Incorporar SQL explícito únicamente cuando una necesidad medida demuestre que Entity Framework Core no genera una consulta adecuada.

El valor técnico de versión no constituye un concepto del dominio ni forma parte del Lenguaje Ubicuo. Existe exclusivamente para cumplir RNF-021 y permanece encapsulado en la adaptación de persistencia y en los contratos técnicos que requieran detectar conflictos.

La configuración concreta de servicio, capacidad, redundancia, respaldo, retención y recuperación de Azure SQL Database deberá derivar de objetivos no funcionales validados antes del despliegue.

---

# 5. Reconstrucción del Aggregate

La Iniciativa mantiene su responsabilidad como Aggregate Root principal, pero esto no obliga a cargar todas sus relaciones en cada operación.

Cada capacidad deberá declarar el contexto requerido para aplicar sus reglas. La adaptación de persistencia deberá:

1. Identificar la Iniciativa.
2. Recuperar su versión vigente.
3. Recuperar las entidades y Objetos de Valor necesarios para la operación.
4. Reconstruir un estado válido mediante mecanismos controlados por el dominio.
5. Entregar el Aggregate a la coordinación.
6. Persistir únicamente después de que el dominio aplique y valide el cambio.

No se permite:

* Construir entidades en estados inválidos para facilitar el mapeo.
* Exponer setters públicos únicamente para Entity Framework Core.
* Utilizar carga automática implícita de relaciones.
* Modificar entidades relacionadas sin pasar por las operaciones aprobadas del Aggregate.
* Cargar colecciones completas cuando una proyección o un contexto acotado resuelve una consulta.

La estrategia de carga de cada capacidad deberá verificarse con datos representativos cuando se validen los volúmenes.

---

# 6. Concurrencia

La concurrencia será optimista.

Cuando una operación recupere una Iniciativa, conservará su valor técnico de versión. Al persistir, la modificación deberá comprobar que la versión almacenada no cambió.

Si otra operación modificó antes la misma Iniciativa:

* No se sobrescribirá el estado vigente.
* No se confirmará parcialmente el cambio ni su Historial.
* La operación comunicará un conflicto de concurrencia.
* El actor deberá recuperar el estado vigente antes de intentar una nueva acción.

No se reintentará automáticamente una acción de dominio después de un conflicto, porque el estado y las reglas aplicables pueden haber cambiado.

---

# 7. Transacciones

Una operación que modifica una Iniciativa utilizará una transacción local de Azure SQL Database.

La misma transacción incluirá, cuando corresponda:

* El estado de la Iniciativa.
* Las entidades relacionadas modificadas.
* El evento de Historial.
* Las relaciones requeridas por el Modelo Relacional.

Si una parte falla, la operación completa deberá revertirse.

La transacción deberá mantenerse acotada a una capacidad y no permanecer abierta durante llamadas de red, interacción con el actor ni integraciones externas.

El comportamiento transaccional proporcionado por una única confirmación de Entity Framework Core será suficiente mientras la operación no requiera múltiples confirmaciones. Una transacción explícita solo se utilizará cuando una capacidad validada requiera coordinar múltiples operaciones de persistencia.

---

# 8. Consultas

Las consultas que no modifican el Aggregate:

* Utilizarán proyecciones explícitas hacia representaciones de salida.
* Recuperarán únicamente los campos necesarios.
* No expondrán entidades del dominio ni de persistencia.
* No utilizarán seguimiento de cambios.
* Aplicarán paginación cuando el resultado pueda crecer.
* Mantendrán el alcance de autorización requerido.

Entity Framework Core será la estrategia inicial también para consultas. No se introduce un segundo mecanismo de acceso a datos hasta que una medición demuestre su necesidad.

---

# 9. Evolución del Esquema

Las migraciones:

* Se mantendrán versionadas en el repositorio.
* Serán revisables antes de aplicarse.
* No se generarán ni aplicarán automáticamente en Producción durante el inicio de la aplicación.
* Mantendrán trazabilidad hacia el documento aprobado que origina el cambio.
* Incluirán una estrategia de despliegue y recuperación proporcional al cambio.

Las migraciones no podrán introducir conceptos, estados, tipos ni relaciones que no estén aprobados.

Los datos iniciales se limitarán a valores gobernados definidos por el dominio y a información técnica indispensable. No se utilizarán datos iniciales para crear configuraciones libres que sustituyan reglas del dominio.

---

# 10. Consecuencias

## 10.1 Positivas

* La tecnología implementa directamente el Modelo Relacional aprobado.
* El acceso a datos se integra con la plataforma .NET 10 seleccionada.
* El dominio permanece independiente de la persistencia.
* Cambio e Historial pueden conservarse de forma atómica.
* Los conflictos de concurrencia se detectan sin bloqueos prolongados.
* El esquema puede evolucionar de forma versionada y trazable.
* Las consultas pueden optimizarse sin exponer el modelo interno.
* La operación administrada reduce tareas de mantenimiento del motor.

## 10.2 Costos y Restricciones

* El equipo deberá conocer Azure SQL Database y Entity Framework Core 10.
* El mapeo entre dominio y persistencia deberá mantenerse explícitamente.
* Las consultas y cargas deberán revisarse para evitar exceso de datos y recorridos innecesarios.
* Las migraciones requerirán revisión y coordinación operacional.
* La solución dependerá de capacidades específicas de concurrencia del motor seleccionado.

## 10.3 Riesgos

### Modelo determinado por Entity Framework Core

Las convenciones del ORM podrían trasladarse al dominio.

Mitigación:

* Mantener configuración y mapeo en la adaptación de persistencia.
* Prohibir dependencias de Entity Framework Core en el dominio.
* Probar el dominio sin persistencia.

### Carga excesiva del Aggregate

La amplitud de relaciones de la Iniciativa podría generar consultas costosas.

Mitigación:

* Cargar el contexto requerido por cada capacidad.
* Evitar carga automática implícita.
* Medir consultas con volúmenes representativos.
* Utilizar proyecciones para lectura.

### Pérdida de actualización

Dos actores podrían modificar una Iniciativa sobre el mismo estado.

Mitigación:

* Utilizar un valor técnico de versión.
* Rechazar la segunda confirmación.
* Exigir recuperar el estado vigente antes de una nueva acción.

### Migración incompatible

Un cambio de esquema podría afectar datos o despliegues existentes.

Mitigación:

* Revisar migraciones antes de aplicarlas.
* No ejecutarlas automáticamente al iniciar en Producción.
* Definir recuperación y compatibilidad para cada cambio relevante.

### Dependencia de Azure

Una restricción corporativa o de despliegue podría impedir utilizar Azure SQL Database.

Mitigación:

* Validar plataforma, residencia, conectividad y operación antes de implementar.
* Mantener el dominio independiente del proveedor.
* Revisar este ADR si la plataforma corporativa aprobada exige otro motor.

---

# 11. Criterios de Cumplimiento

La implementación cumple cuando:

* Utiliza Azure SQL Database y Entity Framework Core 10.
* El dominio no depende de Entity Framework Core.
* El esquema implementa el Modelo Relacional, el DER y el Diccionario de Datos aprobados.
* El mapeo se define dentro de la adaptación de persistencia.
* Las capacidades reconstruyen un estado válido con el contexto requerido.
* No existe carga automática implícita de relaciones.
* Las consultas de lectura utilizan proyecciones sin seguimiento cuando corresponde.
* Los cambios del Aggregate y su Historial se confirman o revierten conjuntamente.
* Los conflictos de concurrencia se detectan y comunican sin sobrescribir el estado vigente.
* Las migraciones están versionadas, revisadas y son trazables.
* Producción no aplica migraciones automáticamente durante el inicio.
* Existen pruebas de mapeo, reconstrucción, integridad, transacciones y concurrencia.
* La configuración operacional deriva de requerimientos no funcionales validados.

---

# 12. Cuándo Revisar

Esta decisión deberá revisarse si:

* La plataforma corporativa aprobada no permite Azure SQL Database.
* Los requisitos de residencia, continuidad o recuperación no pueden cumplirse.
* Mediciones representativas demuestran que Entity Framework Core no satisface los objetivos acordados.
* El tamaño del Aggregate impide reconstruir de forma eficiente el contexto requerido.
* Aparece una necesidad aprobada de consistencia entre múltiples servicios o motores.
* El Modelo Relacional aprobado es revisado.
* .NET 10 o Entity Framework Core 10 se aproximan al fin de soporte sin una ruta de actualización aprobada.

---

# 13. Trazabilidad

Este ADR deriva principalmente de:

* PHIL-001: FP-002, FP-004, FP-006, FP-009, FP-011 y FP-012.
* SRS-002 - Lenguaje Ubicuo.
* SRS-003 - Modelo de Dominio.
* SRS-006: RNF-013, RNF-014 y RNF-020 a RNF-023.
* SRS-010 - Modelo Relacional.
* ADR-001 - Arquitectura Basada en el Negocio.
* ADR-004 - Backend con .NET 10.
* DER.
* Diccionario de Datos.
* Modelo de Dominio Arquitectónico.
* Arquitectura del Backend.
* Arquitectura de Seguridad.

---

# 14. Fuentes Técnicas Consultadas

* [Novedades de Entity Framework Core 10](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-10.0/whatsnew).
* [Transacciones en Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/saving/transactions).
* [Control de conflictos de concurrencia en Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/saving/concurrency).
* [Consultas eficientes con Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/performance/efficient-querying).
* [Confiabilidad en Azure SQL Database](https://learn.microsoft.com/en-us/azure/reliability/reliability-sql-database).

Las fuentes técnicas respaldan capacidades de la alternativa propuesta. La decisión se fundamenta en la Filosofía del Producto y los documentos aprobados de Arauco Project Hub.

---

# 15. Validaciones Pendientes

Antes de aprobar este ADR:

* Confirmar que Azure SQL Database forma parte de la plataforma corporativa permitida.
* Confirmar requisitos de residencia y clasificación de datos.
* Confirmar conectividad e identidad del Backend hacia la base de datos.
* Acordar objetivos de disponibilidad, respaldo, recuperación y retención.
* Validar volúmenes y concurrencia esperados.
* Validar el mecanismo de despliegue de migraciones.
* Ejecutar una prueba técnica de reconstrucción y concurrencia sobre una capacidad representativa.

---

# 16. Decisiones Posteriores

Este ADR deberá orientar, sin anticiparlas, las decisiones sobre:

* Arquitectura de Persistencia.
* Configuración operacional de Azure SQL Database.
* Administración de secretos y claves.
* Observabilidad de persistencia.
* Estrategia de respaldo y recuperación.
* Despliegue de migraciones.

Una decisión importante deberá documentarse mediante ADR cuando corresponda.

---

# 17. Estado del Documento

**Estado actual:** Approved

Este documento constituye la fuente oficial para la tecnología y estrategia de persistencia de Arauco Project Hub.
