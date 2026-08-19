# INFORME TÉCNICO DE INGENIERÍA: ARQUITECTURA E IMPLEMENTACIÓN DE LA BASE DE DATOS Relacional (SQL)

**Proyecto:** Sistema de Gestión de Parqueaderos PUCESA (SGP)
**Versión de Documento:** 1.0 (Estructura de Persistencia Completada)
**Fecha de Actividad:** Miércoles, 04 de Marzo de 2026
**Tecnología y Entorno:** SQL Server 22.3.2 | SQL Server Management Studio (SSMS)

---

## 1. Resumen Arquitectónico y Objetivos

El presente documento técnico detalla la estructura, normalización y políticas de aseguramiento de la base de datos relacional para el sistema SGP. La migración de la lógica de negocio a la capa de persistencia en SQL Server ha sido diseñada priorizando la **integridad referencial**, la seguridad de los datos transaccionales, y el cumplimiento estricto de las normativas de negocio institucionales de la PUCESA.

Este documento sirve como referencia primaria para futuros ingenieros de software, administradores de bases de datos (DBA) y personal de soporte que requieran comprender la arquitectura de la información del sistema.

## 2. Diccionario de Datos y Modelo de Entidades

La base de datos fue normalizada para aislar responsabilidades y asegurar la escalabilidad transaccional. A continuación, se detalla el diccionario de las tablas maestras y transaccionales del sistema:

### 2.1. Entidades de Seguridad y Usuarios
*   **Usuarios:** Entidad principal (Persona). Contiene datos personales, estado de discapacidad y banderas lógicas de sanciones.
*   **Roles:** Modelo de Control de Acceso Basado en Roles (RBAC). Define los perfiles y permisos (Admin, Estudiante, Seguridad, etc.).
*   **Inscripciones:** Tabla de relación formal que vincula a un usuario como entidad activa dentro del sistema en un periodo académico vigente.
*   **Periodo_Inscripcion:** Entidad gestora que controla los rangos de fechas (constraints temporales) permitidos para nuevas inscripciones.

### 2.2. Entidades de Hardware e Infraestructura
*   **Garajes:** Representación física y lógica de la infraestructura (ej. Central A, VIP Torre). Mantiene estados de capacidad máxima y ocupación en tiempo real.
*   **Horarios_Garaje:** Configuración de las ventanas de tiempo operativas autorizadas para cada parqueadero físico.
*   **Tags:** Registro de inventario físico. Almacena los identificadores hexadecimales (EPC) de los sensores RFID adquiridos.
*   **Incidencias:** Bitácora operativa para registrar novedades de hardware, red u obstáculos detectados físicamente en las garitas.

### 2.3. Entidades de Reglas de Negocio Institucional
*   **Vehiculos:** Entidad que registra las propiedades técnicas de los automóviles. Depende lógicamente de la tabla `Usuarios`.
*   **Tarifas:** Catálogo paramétrico de precios estructurado por tipo de servicio y garaje asignado.
*   **Franja:** Definición abstracta de bloques horarios disponibles en la institución.
*   **Franja_Horaria:** Tabla de resolución N:M. Asigna una franja o bloque horario de permiso a un `Usuario` específico.
*   **Tipo_Sanciones:** Catálogo que parametriza las posibles infracciones y los montos económicos o penalizaciones a aplicar.
*   **Metodos_Pago:** Catálogo de interfaces o pasarelas de pago aceptadas (Efectivo, Tarjeta, App).

### 2.4. Entidades Operativas (Relaciones Críticas)
*   **Asignacion_Tags:** Tabla puente de alta transaccionalidad. Establece la vinculación unívoca entre: un `Usuario`, un `Vehículo` y un identificador `Tag` (Hardware).
*   **Activacion_Tags:** Entidad de control temporal (Logs de tiempo libre/ocupado) para validar la vigencia temporal operativa de un Tag físico.
*   **Asignacion_Tarifa:** Relación financiera abstracta entre el uso efectivo de un tag por carril y la tarifa base que le aplica.

### 2.5. Entidades Transaccionales y Auditoría
*   **Accesos:** Tabla "Core" de flujo vehicular. Registra históricamente, con estampas de tiempo (`datetime`), cada entrada y salida física registrada por las antenas.
*   **Pagos:** Entidad financiera. Registra transacciones monetarias completadas, en proceso y su auditoría de facturación correspondiente.
*   **Sanciones:** Registro transaccional de penalizaciones aplicadas a entidades `Usuario`.
*   **Logs (Auditoria_Sistema):** Sistema de rastreo integrado (Audit Trail) que documenta toda modificación (INSERT, UPDATE, DELETE) en tablas maestras. Garantiza la trazabilidad por usuario.

---

## 3. Validaciones Técnicas, Desempeño e Integridad

El esquema (DDL) ha sido validado mediante revisión por pares (Peer Review) por la Dirección del Proyecto y el Equipo de Desarrollo, certificando:

*   **Eficiencia en Tipos de Datos:** Alineación estricta a buenas prácticas. Uso prioritario de `DECIMAL(p, s)` para consistencia financiera en montos y `DATETIME / DATETIME2` para evitar desbordes temporales en la auditoría (`Logs`, `Accesos`).
*   **Restricciones a Nivel de Motor (Constraints):** Prevención pasiva de inyección e inconsistencias. Ej. Aplicación de `CHECK` constraints en la tabla `Usuarios` vía expresiones regulares nativas para estandarizar cadenas de correo electrónico.
*   **Escalabilidad Multi-Sede:** El diseño permite soportar múltiples sucursales (ej. Principal y Secundaria) resolviendo las consultas mediante claves foráneas compuestas escalables y limitando lecturas en caliente.

## 4. Gestión de Contingencias, Entornos y Despliegues

*   **Poblamiento de Pruebas (Data Seeding):** Se desarrolló y ejecutó el script `datos_prueba.sql`. Este archivo DML inyecta registros sintéticos (mock data) de roles, garajes y pagos, utilizados exclusivamente para pruebas unitarias de lógica lógica de cobros e inscripciones.
*   **Respaldos Transaccionales y Scripts (Disaster Recovery):** Haciendo uso de SSMS se han generado dos artefactos obligatorios para la migración a Producción:
    1.  Copia física y binaria de restauración: `dbo.bak`
    2.  Esquema estricto programable abstracto: `Script.sql` (Contiene todos los T-SQL `CREATE TABLE` y `ALTER TABLE` necesarios para regenerar el entorno vacío).

## 5. Deuda Técnica y Hoja de Ruta Inmediata

Si bien la base de datos es estructuralmente sólida en su versión 1.0, se documentan las siguientes tareas técnicas programadas para el *Sprint* actual:

*   **Implementación de Disparadores Automáticos (Triggers DML):** Se requiere el desarrollo de scripts T-SQL a nivel base de datos para controlar la capa de negocio secundaria: Validar en tiempo de ejecución (`BEFORE INSERT` en la tabla `Accesos`) la apertura de barreras en función del estado lógico del `Tag` y la ausencia de penalizaciones activas (`Sanciones`) asociadas al `Usuario`.

---

**Firmas de Validación de Ingeniería:**

- Elaborado por: Alberto Falconi, Sebastian Sanmartin (Equipo de Desarrollo SGP)
- Revisado por: _____________________________
- Aprobado por: _____________________________
