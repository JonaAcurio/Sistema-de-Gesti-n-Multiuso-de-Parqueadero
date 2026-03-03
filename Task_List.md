## Actividades

* [X] Apertura y cierre automático de puertas
* [X] Uso e implementación de TAGs para control de acceso
* [X] Instalación de nuevas conexiones electrónicas
* [ ] Base de datos en proceso de desarrollo
* [ ] Diseño e implementación de interfaces de usuario

## Requisitos Funcionales (RF)

**Configuración del Sistema**

* [ ] **Gestión de Parqueaderos (RF-01):** Crear, editar y listar los parqueaderos con su ubicación y capacidad total.
* [ ] **Control de Espacios (RF-02):** Visualizar y actualizar en tiempo real si un puesto está ocupado, libre o fuera de servicio.
* [ ] **Clasificación de Puestos (RF-03):** Identificar espacios especiales para discapacidad o uso mixto en los reportes.
* [ ] **Definición de Periodos (RF-04):** Configurar las fechas de inicio y fin para los procesos de registro semestral.
* [ ] **Control de Fechas (RF-05):** Bloqueo automático del sistema si se intenta hacer un registro fuera de las fechas permitidas.

**Usuarios y Seguridad**

* [ ] **Registro de Usuarios y Roles (RF-06):** Crear cuentas para Docentes, Estudiantes, Guardias y Financieros con sus respectivos permisos.
* [ ] **Ingreso Institucional (RF-07):** Permitir el acceso seguro utilizando la cuenta de Microsoft (SSO).
* [ ] **Registro de Vehículos (RF-08):** Guardar los datos de los vehículos (placa, modelo, color) asociados a cada dueño.
* [ ] **Límite de Vehículos (RF-09):** Control para asegurar que ningún usuario institucional registre más de 2 vehículos.

**Gestión de Credenciales (TAGs)**

* [ ] **Solicitud de TAG (RF-10):** Generar el pedido de la credencial vinculando al usuario con su vehículo y parqueadero.
* [ ] **Inventario de Chips (RF-13):** Controlar el stock de TAGs (disponibles, asignados, perdidos o dañados).
* [ ] **Reposición por Pérdida (RF-14):** Inhabilitar chips perdidos y gestionar el cobro de la nueva credencial.
* [ ] **Control de Estado (RF-15):** Activar o suspender chips para permitir o denegar el paso en las plumas.

**Pagos y Facturación**

* [ ] **Evidencia de Pago (RF-11):** Obligar al usuario a subir el comprobante de transferencia para poder procesar su solicitud.
* [ ] **Aprobación Financiera (RF-12):** Validar los pagos, emitir facturas y enviar notificaciones de aprobación o rechazo.
* [ ] **Configuración de Tarifas (RF-20 y RF-21):** Ajustar los precios fijos del semestre y las tarifas especiales (discapacidad/mixto).

**Operación y Control de Acceso**

* [ ] **Registro de Movimientos (RF-16):** Guardar historial de cada entrada y salida con fecha, hora y datos del vehículo.
* [ ] **Validación de Acceso (RF-17):** Impedir la entrada si el parqueadero está lleno, el usuario tiene una sanción o está fuera de horario.
* [ ] **Control de Plumas (RF-18):** Apertura automática con el chip y opción de apertura manual por el guardia con justificación.
* [ ] **Gestión de Visitantes (RF-19):** (En proceso de definición técnica).
* [ ] **Sanciones Automáticas (RF-22):** Bloquear el acceso a usuarios que incumplan las normas u horarios establecidos.
* [ ] **Reporte de Incidencias (RF-23):** Registrar y dar seguimiento a fallas técnicas en las plumas o chips defectuosos.

**Reportes y Consultas**

* [ ] **Reportes Administrativos (RF-24):** Consultar ocupación, historial de accesos y estado de los chips en PDF o Excel.
* [ ] **Reportes Financieros (RF-25):** Ver ingresos detallados diferenciando pagos por transferencia y dinero en efectivo.
* [ ] **Consulta de Usuario (RF-26):** Permitir que cada usuario vea su propio historial y el estado de su trámite.

## Requisitos No Funcionales (RNF)

**Seguridad y Confianza**

* [ ] **Seguridad y Auditoría (RNF-01):** Garantizar que cada acción importante (como cambios de precios o sanciones) guarde un registro que nadie pueda borrar.
* [ ] **Trazabilidad Total (RNF-04):** Permitir que el administrador rastree paso a paso el historial de cualquier usuario, vehículo o pago en cualquier fecha.
* [ ] **Respaldo de Información (RNF-07):** Sistema de copias de seguridad automáticas y opción de descargar todos los reportes en formatos PDF y Excel.

**Velocidad y Desempeño**

* [ ] **Disponibilidad del Sistema (RNF-02):** Asegurar que el programa funcione de forma estable y sin caídas durante todo el horario de atención.
* [ ] **Rapidez de Respuesta (RNF-03):** Lograr que la lectura del chip y la apertura de la pluma ocurran en pocos segundos para evitar filas de vehículos.

**Facilidad de Uso e Integración**

* [ ] **Interfaz Amigable (RNF-05):** Diseñar la pantalla del guardia para que sea visualmente clara y permita registrar visitas en menos de 5 clics.
* [ ] **Conexión con Equipos (RNF-06):** Asegurar que el programa se comunique perfectamente con los correos de Microsoft y con el hardware de las plumas físicas.
