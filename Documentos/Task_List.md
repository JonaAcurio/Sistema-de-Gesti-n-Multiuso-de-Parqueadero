## Actividades

* [x] Apertura y cierre automático de puertas
* [x] Uso e implementación de TAGs para control de acceso
* [x] Instalación de nuevas conexiones electrónicas
* [ ] Base de datos en proceso de desarrollo
* [ ] Diseño e implementación de interfaces de usuario

## Requisitos Funcionales (RF)

**Configuración del Sistema**

* [ ] **Gestionar Parqueaderos (RF-01):** Crear, editar y listar los parqueaderos con su ubicación y capacidad total.
* [ ] **Definir Periodos de Registro (RF-02):** Configurar las fechas de inicio y fin para los procesos de registro semestral.
* [ ] **Bloqueo de Registro por Fechas (RF-03):** Bloqueo automático del sistema si se intenta hacer un registro fuera de las fechas permitidas.

**Usuarios y Seguridad**

* [ ] **Registro de Usuarios por Rol (RF-04):** Crear cuentas y asignar permisos para Docentes, Estudiantes, Guardias, Financieros y Administradores.
* [ ] **Autenticación Microsoft SSO (RF-05):** Permitir el acceso seguro utilizando la cuenta institucional.
* [ ] **Registro de Vehículos (RF-06):** Guardar los datos de los vehículos (placa, modelo, color, tipo) asociados a cada dueño.
* [ ] **Restricción de Flota por Usuario (RF-07):** Control para asegurar que ningún usuario institucional registre más de 2 vehículos.

**Gestión de Credenciales (TAGs)**

* [ ] **Generación de Solicitud de TAG (RF-08):** Generar el pedido de la credencial vinculando al usuario con su vehículo, parqueadero y periodo.
* [ ] **Inventario de TAGs (RF-10):** Controlar el stock físico (disponibles, asignados, perdidos, dados de baja).
* [ ] **Gestión de Pérdida y Reposición (RF-11):** Inhabilitar chips perdidos y gestionar el cobro de la nueva credencial.
* [ ] **Emisión y Control de Estados (RF-12):** Activar, suspender o caducar credenciales para permitir o denegar el paso en las plumas.

**Pagos y Facturación**

* [ ] **Aprobación/Rechazo de Solicitud (RF-09):** Validar los pagos institucionales, emitir facturas, registrar observaciones obligatorias y cambiar el estado del trámite.
* [ ] **Configuración de Tarifas Fijas (RF-17):** Ajustar los precios semestrales y mantener la trazabilidad de quién y cuándo hizo el cambio.
* [ ] **Tarifas Variables y Excepciones (RF-18):** Aplicar tarifas diferenciadas automáticamente (ej. por discapacidad o tipo de vehículo).

**Operación y Control de Acceso**

* [ ] **Registro de Bitácora de Accesos (RF-13):** Guardar historial de cada intento de entrada y salida con resultado (permitido o denegado).
* [ ] **Validación de Acceso Lógica (RF-14):** Impedir la entrada si hay sanciones, cupo lleno o si está fuera del horario permitido para ese rol.
* [ ] **Control de Plumas (Auto/Manual) (RF-15):** Apertura automática por chip y apertura manual por el guardia con ingreso de justificación obligatoria.
* [ ] **Gestión de Acceso y Cobro de Visitantes (RF-16):** Controlar el ingreso de no registrados y gestionar el cobro en efectivo por hora o fracción.
* [ ] **Aplicación de Sanciones (RF-19):** Bloquear el acceso a usuarios durante el tiempo estipulado por incumplimiento de normas.

**Reportes y Consultas**

* [ ] **Reportes Financieros (RF-20):** Ver ingresos detallados diferenciando pagos por transferencia institucional y dinero en efectivo en garita.
* [ ] **Reportes de Usuario Final (RF-21):** Permitir que el usuario estándar vea exclusivamente su propio historial de accesos y estado de solicitudes.

## Requisitos No Funcionales (RNF)

**Seguridad y Confianza**

* [ ] **Seguridad y Auditoría (RNF-01):** Garantizar que cada acción importante (cambio de tarifas, sanciones, aperturas manuales) guarde un registro inmutable.
* [ ] **Trazabilidad Total (RNF-04):** Permitir reconstruir el historial completo de cualquier usuario, vehículo o credencial por fecha y hora.
* [ ] **Respaldo de Información (RNF-07):** Sistema de copias de seguridad automáticas y opción de descargar los reportes en formatos PDF y Excel.

**Velocidad y Desempeño**

* [ ] **Disponibilidad del Sistema (RNF-02):** Asegurar que el módulo de garita funcione de forma estable y sin caídas durante toda la jornada.
* [ ] **Rapidez de Respuesta (RNF-03):** Lograr que la lectura del chip y la decisión de abrir la pluma ocurran en pocos segundos.

**Facilidad de Uso e Integración**

* [ ] **Interfaz Amigable (RNF-05):** Diseñar la pantalla del operador de garita para que permita registrar visitas manuales en 5 clics o menos.
* [ ] **Conexión con Equipos (RNF-06):** Asegurar que el sistema se comunique fluidamente con Microsoft SSO y el hardware físico (Plumas, TAGs).