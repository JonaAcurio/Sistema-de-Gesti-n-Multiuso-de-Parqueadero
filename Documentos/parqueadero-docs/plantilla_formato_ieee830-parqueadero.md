# Especificación de requisitos de software

Proyecto: Sistema de Gestión Multisitio de Parqueaderos

Revisión: 1.0

## Ficha del documento

| Fecha | Revisión | Autor | Aprobación |
| :--- | :--- | :--- | :--- |
| 23/02/2026 | 1.0 | Carlos Parreño<br>Jonathan Acurio | |

Documento validado por las partes en fecha: 09/03/2026


## Contenido

## 1. Introducción

El propósito de este documento es definir la Especificación de Requisitos de Software (SRS) para el nuevo Sistema de Gestión Multi-Parqueadero Institucional. Este sistema permitirá administrar de forma centralizada la asignación de espacios de estacionamiento, controlar los accesos físicos mediante TAG, gestionar cobros (fijos y por hora/fracción), validar pagos y aplicar reglas de negocio incluyendo sanciones para distintos perfiles de la comunidad universitaria.

### 1.1 Alcance

El sistema a desarrollar contempla:
* La administración de múltiples parqueaderos físicos con numeración individual y capacidad variable.
* La gestión de usuarios y roles diferenciados (Administrador, Financiero, Control/Garita, Docente, Estudiante, Administrativo, Visitante).
* El registro y control de vehículos (limitado a un máximo de 2 por usuario institucional).
* La gestión del inventario de credenciales de acceso (aproximadamente 600 TAGs iniciales).
* La integración con hardware de control de acceso (plumas mecánicas y lectores de TAG).
* La integración con plataformas externas: inicio de sesión único (Microsoft SSO) y flujo de validación de pagos (transferencias y efectivo).
* Un módulo completo de reportes, auditoría y aplicación automática de sanciones por mal uso.

### 1.2 Personal involucrado

**1.2.1 Gestor del Proyecto**
| Nombre | Categoría profesional | Responsabilidades | Información de contacto |
| :--- | :--- | :--- | :--- |
| Dennys Coronel | Docente | Gestor de proyectos | 099 512 0616 |

**1.2.2 Cliente/Stakeholders**
| Nombre | Categoría profesional | Responsabilidades | Información de contacto |
| :--- | :--- | :--- | :--- |
| | | | |

**1.2.3 Equipo de Desarrollo**
| Nombre | Categoría profesional | Responsabilidades | Información de contacto |
| :--- | :--- | :--- | :--- |
| Carlos Ortega | Estudiante | | 096 909 9790 |
| Jeremy Jacome | Estudiante | | 099 540 8705 |
| Jonathan Acurio | Estudiante | | 096 341 0492 |
| Sebastian Sanmartin | Estudiante | | 096 711 0610 |
| Sebastian Falconi | Estudiante | | 098 194 7131 |
| David Ojeda | Estudiante | | 098 250 0589 |
| Carlos Parreño | Estudiante | Levantamiento de requerimientos | 099 972 0694 |

### 1.3 Definiciones, acrónimos y abreviaturas

* **TAG:** Etiqueta o dispositivo electrónico RFID utilizado para la identificación vehicular.
* **SSO:** Single Sign-On (Inicio de sesión único), utilizando credenciales de Microsoft institucionales.
* **Pluma:** Brazo mecánico o barrera física utilizada en las entradas y salidas de los parqueaderos.
* **MoSCoW:** Método de priorización de requisitos (MUST: Debe tener, SHOULD: Debería tener, COULD: Podría tener, WON'T: No tendrá por ahora).
* **CA:** Criterio de Aceptación.

### 1.4 Resumen

El resto de este documento detalla la perspectiva del producto, las características de los usuarios, las reglas de negocio principales y, finalmente, el desglose pormenorizado de los requisitos funcionales y no funcionales estructurados mediante prioridades MoSCoW.

---

## 2. Descripción general

### 2.1 Perspectiva del producto

El sistema actuará como el núcleo central para la gestión vehicular de la institución, interactuando activamente con el ecosistema tecnológico actual. Depende del directorio activo de Microsoft para la autenticación, del personal Financiero para la validación manual/semiautomática de transferencias, y del hardware de los parqueaderos para aperturas físicas e identificación mediante TAGs.

### 2.2 Funcionalidad del producto

* Autenticación restringida a correos institucionales mediante Microsoft SSO.
* CRUD de vehículos por usuario institucional (límite estricto de 2 placas, excepto para administrador que no dispone de límite).
* Gestión de reservas, periodos activos y validación de comprobantes de pago.
* Control de acceso basado en franjas horarias, vigencia, sanciones y cupos disponibles.
* Gestión de inventario de TAGs (asignación, bloqueos, pérdidas).
* Módulo de cobro a visitantes en efectivo (cálculo por hora/fracción).
* Trazabilidad completa y reportes analíticos para administración y finanzas.

### 2.3 Características de los usuarios

* **Administrador del sistema:** Configuración global del multisitio, auditoría completa, reportes y gestión de permisos, gestión de tarifas (fijas y variables), reportes de ingresos.
* **Financiero:** Gestión de tarifas (fijas y variables), revisión/validación de comprobantes de pagos (transferencias), envío de facturas correspondientes y reportes de ingresos.
* **Garita:** Operación de ingreso/salida, apertura manual con auditoría, cobro en efectivo a visitantes y registro de incidencias.
* **Docente:** (Docente tiempo completo / Docente tiempo parcial).
* **Estudiante:** Usuario institucional sujeto a validación de pagos y franjas horarias (máximo 2 placas).
* **Administrativo:** Usuario institucional con beneficio de horario extendido para uso de parqueadero todo el día (máximo 2 placas).
* **Visitante:** Usuario no registrado en el sistema institucional. Genera cobro por hora o fracción pagadero únicamente en efectivo al salir.
* **Visitantes Alto Nivel:** Se debe definir cuántos lugares se le asignan. Este tipo de usuario no paga ninguna tarifa.

### 2.4 Restricciones

* El pago de visitantes requiere un manejo en efectivo controlado exclusivamente en garita, sin integración a la pasarela digital de transferencias.
* Queda eliminado por completo el uso de tarjetas físicas antiguas, migrando al lote de TAGs nuevos.
* La apertura manual de las plumas requerirá obligatoriamente el registro de un motivo auditable.

### 2.5 Suposiciones y dependencias

* Se asume la disponibilidad y estabilidad del servicio SSO de Microsoft.
* Se asume que el hardware en sitio (plumas) está correctamente configurado para recibir peticiones del sistema.

### 2.6 Reglas de Negocio (RB)

| ID | Regla de Negocio | Prioridad |
| :--- | :--- | :--- |
| RB-01 | El sistema debe soportar múltiples parqueaderos (multisitio), cada uno con capacidad y reglas configurables. | MUST |
| RB-02 | Cada parqueadero debe poseer un número de espacios configurable y estados (disponible/ocupado/reservado/fuera de servicio). | MUST |
| RB-03 | El registro/renovación institucional solo se habilita dentro de fechas de un periodo activo (activador por fechas). | MUST |
| RB-04 | Docentes, Estudiantes y Administrativos pueden registrar un máximo de 2 placas (vehículos) por usuario. | MUST |
| RB-05 | Visitantes: cobro por hora o fracción; pago únicamente en efectivo en garita. | MUST |
| RB-06 | Tarifas ajustables y variables: por periodo (semestral), por tipo de automotor, discapacidad y esquema mixto. | MUST |
| RB-07 | Horarios: Administrativo ocupa todo el día; otros roles institucionales dependen de horarios y franjas configurables por día. | MUST |
| RB-08 | Sanciones por mal uso deshabilitan el acceso (por usuario y/o credencial) durante la vigencia estipulada de la sanción. | MUST |
| RB-09 | Inventario de TAGs: el sistema administrará el stock físico (aprox. 1000 iniciales), asignación, bloqueo y baja. | MUST |
| RB-10 | Toda apertura manual de pluma debe quedar auditada (quién, cuándo y el motivo). | MUST |
| RB-11 | El primer TAG se incluye sin costo adicional con el pago del parqueadero y es reutilizable. En caso de pérdida, el usuario repone el valor del TAG según un costo ajustable en el sistema. | MUST |

---

## 3. Requisitos específicos

### 3.1 Requisitos comunes de las interfaces

**3.1.1 Interfaces de usuario**
El sistema proveerá paneles web adaptados a cada rol: un dashboard de control ágil para Garita, un panel de reportes para el Administrador, y un portal de autoservicio para Estudiantes/Docentes/Administrativos.

**3.1.2 Interfaces de hardware**
* El sistema emitirá los comandos hacia las controladoras de las plumas de los parqueaderos.
* El sistema capturará las lecturas de los dispositivos TAG instalados en los accesos.

**3.1.3 Interfaces de software**
* Microsoft API: Para el inicio de sesión único (SSO).

### 3.2 Requisitos funcionales

| ID | Requisito | Prioridad | Criterio de Aceptación (CA) |
| :--- | :--- | :--- | :--- |
| RF-01 | Gestionar Parqueaderos | MUST | Dado un Administrador, cuando registra un parqueadero con capacidad X, entonces el parqueadero aparece en la lista y queda disponible. |
| RF-02 | Definir Periodos de Registro | MUST | Al crear un periodo, el sistema permite definir tipo, inicio, fin, y muestra su estado (activo/inactivo). |
| RF-03 | Bloqueo de Registro por Fechas | MUST | Si la fecha actual está fuera del periodo activo, el sistema DENIEGA la solicitud y muestra un mensaje de restricción al usuario. |
| RF-04 | Registro de Usuarios por Rol | MUST | Al crear un usuario con rol, el sistema lo habilita con los permisos exactos asociados a su rol. |
| RF-05 | Autenticación Microsoft SSO | MUST | Cuando un usuario institucional inicia sesión con Microsoft, el sistema crea/actualiza su perfil y permite acceso según rol. |
| RF-06 | Registro de Vehículos | MUST | Cuando se registra un vehículo, la placa queda como registro único por vehículo y se asocia al usuario. |
| RF-07 | Restricción de Flota por Usuario | MUST | Si el usuario ya tiene 2 vehículos registrados, el sistema impide registrar un tercero y genera un evento de auditoría. |
| RF-08 | Generación de Solicitud de TAG | MUST | Al enviar la solicitud, esta queda en estado 'Pendiente' y es visible para el rol Financiero. |
| RF-09 | Aprobación/Rechazo de Solicitud | MUST | Al aprobar, la solicitud cambia a 'Aprobada' y se envía factura; al rechazar, se registra el motivo obligatoriamente. |
| RF-10 | Inventario de TAGs | MUST | El sistema no permite asignar a un usuario un TAG que no se encuentre previamente en estado 'Disponible'. |
| RF-11 | Gestión de Pérdida y Reposición | MUST | Al reportar pérdida, el TAG pasa a 'Inactivo/Perdido' y genera solicitud de reposición con costo. (El primer TAG es Gratis). |
| RF-12 | Emisión y Control de Estados | MUST | Si una credencial es leída pero está 'Suspendida' o 'Vencida', el acceso debe ser denegado por la pluma. |
| RF-13 | Registro de Bitácora de Accesos | MUST | Cada intento de acceso físico genera un registro de bitácora (permitido/denegado) consultable en reportes. |
| RF-14 | Validación de Acceso Lógica | MUST | Si existe sanción activa, el parqueadero está lleno, o está fuera de horario, el sistema deniega el acceso aunque el TAG sea VÁLIDO. |
| RF-15 | Control de Plumas (Auto/Manual) | MUST | Cada apertura manual exige el ingreso de un motivo auditable guardando usuario Garita, fecha-hora y parqueadero. |
| RF-16 | Gestión de Acceso y Cobro de Visitantes | MUST | PENDIENTE |
| RF-17 | Configuración de Tarifas Fijas | MUST | Cuando se modifica el valor de una tarifa, el cambio queda versionado (fecha, usuario) para mantener trazabilidad contable. |
| RF-18 | Tarifas Variables y Excepciones | SHOULD | Al seleccionar un perfil de excepción (p.ej., discapacidad), el sistema aplicará automáticamente la tarifa diferenciada. |
| RF-19 | Aplicación de Sanciones | MUST | Con una sanción activa en el sistema, el usuario no puede ingresar; al expirar el tiempo de castigo, recupera acceso. |
| RF-20 | Reportes Financieros | MUST | El reporte distingue contablemente los ingresos por transferencia (institucionales) vs dinero en efectivo (visitantes). |
| RF-21 | Reportes de Usuario Final | SHOULD | Un usuario estándar solo puede acceder a su propia información histórica y estado de solicitudes, sin ver datos de terceros. |

### 3.3 Requisitos no funcionales

| ID | Requerimiento | Prioridad | Criterio de Aceptación (CA) |
| :--- | :--- | :--- | :--- |
| RNF-01 | Seguridad: Control de acceso granular por roles, permisos y auditoría obligatoria en acciones críticas. | MUST | Toda acción de impacto (cambio de tarifas, sanciones, aprobaciones, apertura manual) genera un registro inmutable de auditoría. |
| RNF-02 | Disponibilidad: Operación estable y resiliente en horario institucional; soporte de interfaz de garita con latencia ultrabaja. | MUST | El módulo operativo de garita debe operar sin interrupciones perceptibles durante toda la jornada institucional. |
| RNF-03 | Rendimiento: Validación de acceso vehicular en garita en pocos segundos en condiciones normales. | MUST | Cada validación de hardware (lectura credencial -> decisión de pluma) debe responder en tiempo operativo para asegurar el flujo. |
| RNF-04 | Trazabilidad: Bitácora completa e inalterable de todos los accesos, pagos, aprobaciones y sanciones. | MUST | El administrador debe poder reconstruir el historial completo de cualquier usuario, vehículo o credencial por fecha y hora. |
| RNF-05 | Usabilidad: Interfaz de operador de garita diseñada en pocos pasos y con mensajes visuales claros de decisión. | SHOULD | Un operador de garita debe poder registrar una operación manual de ingreso/salida de visitante en ≤5 clics o toques. |
| RNF-06 | Interoperabilidad: Integración fluida y segura con Microsoft SSO y controladores físicos (Plumas, TAG). | MUST | El sistema autentica correctamente el token de Microsoft y emite/consume eventos hacia el hardware según la configuración. |
| RNF-07 | Respaldo y Exportación: Generación de backups de base de datos y exportación de todos los reportes operativos a formatos estándar. | SHOULD | Todos los reportes listados permiten descarga directa en PDF y Excel; existe una tarea de respaldo (backup) programable. |