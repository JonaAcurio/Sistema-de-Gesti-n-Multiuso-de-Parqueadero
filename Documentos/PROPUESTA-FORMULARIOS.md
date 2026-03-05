# 📋 RECOMENDACIÓN DE FORMULARIOS - Sistema de Gestión de Parqueadero PUCESA

**Documento de Análisis Técnico**
Fecha: Marzo 2026
Versión: 1.0

---

## 📊 Resumen Ejecutivo

Basándose en el análisis de la estructura actual del proyecto, la base de datos diseñada y los requisitos funcionales definidos, se recomienda implementar **32 formularios/pantallas** distribuidos en **8 módulos funcionales principales**.

**Estado Actual:** 3 pestañas (Configuración, Control de Acceso, Gestión de Tarjetas)
**Estado Propuesto:** 8 módulos con arquitectura escalable

El presente documento establece:
- ✅ Formularios esenciales para MVP (Fase 1-2)
- 🚧 Formularios de desarrollo posterior (Fase 3-4)
- 📈 Mejoras futuras (Fase 5+)

---

## 🎯 MÓDULO 1: AUTENTICACIÓN Y SEGURIDAD

### Propósito
Controlar el acceso al sistema y diferenciar permisos según rol de usuario.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **1.1** | **FormLogin** | ✅ | Autenticación inicial | Usuario, Contraseña, Rememberme | Usuarios, Roles |
| **1.2** | **FormLoginSSO** | 🚧 | Autenticación con Microsoft 365 | Token OAuth | Usuarios, Roles |
| **1.3** | **FormCambiarContraseña** | 🚧 | Permitir cambio de password | Contraseña Actual, Nueva, Confirmación | Usuarios |
| **1.4** | **FormRecuperarContraseña** | 🚧 | Reset de contraseña | Email, Código de confirmación | Usuarios |
| **1.5** | **FormGestionRoles** | 🚧 | Crear/editar roles | Nombre Rol, Descripción, Permisos | Roles |
| **1.6** | **FormPermisosRol** | 🚧 | Asignar permisos a rol | Checkboxes de módulos, Crear, Leer, Editar, Borrar | Roles |

**Entidades de Base de Datos:**
- `Usuarios`: id_usuario, cedula, nombres, apellidos, correo, password_hash, estado_usuario, id_rol, fecha_creacion
- `Roles`: id_rol, nombre, descripcion, estado
- `Logs`: id_log, id_usuario, tabla, id_modificado, tipo, fecha

---

## 🏢 MÓDULO 2: CONFIGURACIÓN DEL SISTEMA

### Propósito
Administrar parámetros globales, conexiones de hardware y periodos operativos.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **2.1** | **FormConfiguracionHardware** | ✅ | Conectar panel InBIO 206 | IP, Puerto, Timeout, Status | (Config local) |
| **2.2** | **FormGestionGarajes** | 🚧 | CRUD de parqueaderos | Nombre, Ubicación, Capacidad Máxima, Estado | Garajes |
| **2.3** | **FormDetalleGaraje** | 🚧 | Ver/Editar parqueadero específico | Nombre, Ubicación, Descripción, Ocupación Actual | Garajes, Accesos |
| **2.4** | **FormHorariosGaraje** | 🚧 | Establecer horas de operación | Hora Apertura, Hora Cierre (por día) | Horarios_Garaje |
| **2.5** | **FormPeriodesInscripcion** | 🚧 | Crear períodos semestrales | Nombre Período, Fecha Inicio, Fecha Fin, Rol | Periodo_Inscripcion, Roles |
| **2.6** | **FormConfiguracionGeneral** | 🚧 | Parámetros del sistema | Nombre Institución, Logo, Tema, Idioma, Zona Horaria | (Config local) |
| **2.7** | **FormMantenimientoBaseDatos** | 🚧 | Backups y limpieza | Botones: Hacer Backup, Restaurar, Limpiar Logs | (Sistema) |

**Entidades de Base de Datos:**
- `Garajes`: id_garaje, nombre, ubicacion, descripcion, fecha_creacion, estado, capacidad_max_espacios, ocupaciones
- `Horarios_Garaje`: id_horario_garaje, hora_apertura, hora_cierre, id_garaje
- `Periodo_Inscripcion`: id_periodo_inscripcion, id_rol, fecha_inicio, fecha_fin, estado

---

## 👥 MÓDULO 3: GESTIÓN DE USUARIOS Y ROLES

### Propósito
Administrar cuentas de usuario, perfiles y asignación de roles.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **3.1** | **FormListaUsuarios** | 🚧 | Listar todos los usuarios | DataGrid con Cédula, Nombre, Email, Rol, Estado | Usuarios |
| **3.2** | **FormAgregarUsuario** | 🚧 | Crear nuevo usuario | Cédula, Nombres, Apellidos, Email, Rol, Tiene Discapacidad | Usuarios, Roles |
| **3.3** | **FormEditarUsuario** | 🚧 | Editar datos de usuario | (igual a agregar) | Usuarios |
| **3.4** | **FormBuscarUsuario** | 🚧 | Búsqueda avanzada | Cédula, Nombre, Email, Rol, Estado | Usuarios |
| **3.5** | **FormDetalleUsuario** | 🚧 | Perfil del usuario | Datos personales, Vehículos, Tarjetas, Historial | Usuarios, Vehiculos, Tags, Accesos |
| **3.6** | **FormDesactivarUsuario** | 🚧 | Deshabilitar/habilitar usuario | Razón, Fecha Desactivación | Usuarios |
| **3.7** | **FormHistorialUsuario** | 🚧 | Ver auditoría de cambios | DataGrid: Fecha, Acción, Usuario que Modificó, Cambio | Logs |

**Entidades de Base de Datos:**
- `Usuarios`: id_usuario, id_rol, cedula, nombres, apellidos, correo, estado_usuario, fecha_creacion, tiene_discapacidad, n_sancion
- `Roles`: id_rol, nombre, descripcion, estado

---

## 🚗 MÓDULO 4: GESTIÓN DE VEHÍCULOS

### Propósito
Registrar y administrar vehículos asociados a usuarios.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **4.1** | **FormListaVehiculos** | 🚧 | Listar vehículos registrados | DataGrid: Placa, Usuario, Tipo, Marca, Modelo, Estado | Vehiculos, Usuarios |
| **4.2** | **FormAgregarVehiculo** | 🚧 | Registrar nuevo vehículo | Placa, Tipo, Marca, Modelo, Año, Color, Usuario | Vehiculos, Usuarios |
| **4.3** | **FormEditarVehiculo** | 🚧 | Editar datos de vehículo | (igual a agregar) | Vehiculos |
| **4.4** | **FormDetalleVehiculo** | 🚧 | Ver perfil completo del vehículo | Datos vehículo, TAG asignado, Historial de accesos | Vehiculos, Asignacion_Tags, Accesos |
| **4.5** | **FormBuscarVehiculo** | 🚧 | Búsqueda por placa o usuario | Placa, Usuario, Tipo de Vehículo | Vehiculos |
| **4.6** | **FormValidarPlaca** | 🚧 | Verificar placas duplicadas | Placa, Resultado validación | Vehiculos |
| **4.7** | **FormLimitarVehiculos** | 🚧 | Verificar límite (máx 2) | Usuario, Cantidad Actual, Límite | Vehiculos, Usuarios |

**Entidades de Base de Datos:**
- `Vehiculos`: id_vehiculo, id_usuario, placa, tipo_vehiculo, marca, modelo, anio, color, fecha_creacion, estado

---

## 🎫 MÓDULO 5: GESTIÓN DE TARJETAS RFID

### Propósito
Administrar el inventario de TAGs RFID, asignaciones y estado de credenciales.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **5.1** | **FormGestionTarjetas** | ✅ (EXISTE) | Listar y CRUD de tarjetas | DataGrid: Nº Tarjeta, Usuario, Observaciones, Habilitada | Tags, Usuarios |
| **5.2** | **FormAgregarTarjeta** | ✅ (EXISTE) | Registrar nuevo TAG | Nº Tarjeta, Nombre Usuario, Observaciones, Habilitada | Tags (o Tarjetas JSON) |
| **5.3** | **FormEditarTarjeta** | ✅ (EXISTE) | Editar información TAG | (igual a agregar) | Tags |
| **5.4** | **FormDetectarTarjeta** | ✅ (EXISTE) | Lectura automática de TAG | Auto-detección pasando por lector | Tags |
| **5.5** | **FormInventarioTags** | 🚧 | Gestionar stock de chips físicos | Código EPC, Lote, Estado (disponible, asignado, dañado), Cantidad | Tags, Activacion_Tags |
| **5.6** | **FormAsignacionTags** | 🚧 | Vincular TAG → Vehículo | Selection: TAG, Vehículo, Fecha Asignación | Asignacion_Tags, Tags, Vehiculos |
| **5.7** | **FormActivacionDesactivacion** | 🚧 | Habilitar/Deshabilitar TAGs | Selection: TAG, Nueva Estado, Razón, Fecha Efectiva | Activacion_Tags, Tags |
| **5.8** | **FormReposicionPerdida** | 🚧 | Gestionar pérdida/daño | TAG Anterior, Nuevo TAG, Razón, Costo Reposición | Tags, Asignacion_Tags, Pagos |
| **5.9** | **FormHistorialTags** | 🚧 | Auditoría de cambios TAG | DataGrid: Fecha, Acción, Usuario, TAG, Detalles | Logs, Tags |

**Entidades de Base de Datos:**
- `Tags`: id_tag, codigo_epc, lote, estado (0=disponible, 1=asignado, 2=dañado)
- `Asignacion_Tags`: id_asignacion_tag, id_tag, id_vehiculo, fecha_asignacion, estado_asignacion
- `Activacion_Tags`: id_activacion_tag, id_tag, fecha_inicio, fecha_fin, estado

---

## 🚪 MÓDULO 6: OPERACIÓN DE BARRERA EN TIEMPO REAL

### Propósito
Monitorear y controlar la barrera vehicular durante operación normal.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **6.1** | **FormControlAccesoRFID** | ✅ (EXISTE) | Visualizar eventos en vivo | DataGrid: Hora, Lector, Tarjeta, Usuario, Estado autorización | Accesos, Tags, Usuarios |
| **6.2** | **FormDashboardBarrera** | 🚧 | Panel en tiempo real | Estado barrera (arriba/abajo), Última lectura, Contador accesos hoy | (Datos en vivo) |
| **6.3** | **FormControlManualBarrera** | 🚧 | Abrir/Cerrar barrera manualmente | Botones: Subir, Bajar, Auto, Stop Emergency | (Control directo) |
| **6.4** | **FormJustificacionAccesoManual** | 🚧 | Registrar justificación si se abre manual | Razón, Observaciones, Usuario Guardia | Accesos, Usuarios |
| **6.5** | **FormMonitorSensores** | 🚧 | Estado de sensores físicos | Sensor Entrada, Sensor Centro, Sensor Salida, Estado | (Datos hardware) |
| **6.6** | **FormDiagnosticoHardware** | 🚧 | Diagnóstico técnico del panel | IP, Conexión, Última comunicación, Eventos últimas 24h | (Config, Logs) |
| **6.7** | **FormEstadisticasBarrera** | 🚧 | Estadísticas operativas diarias | Total accesos, Autorizados, Denegados, Horario pico | Accesos |

**Entidades de Base de Datos:**
- `Accesos`: id_acceso, id_vehiculo, id_garaje, id_asignacion_tag, fecha_entrada, fecha_salida, estado
- `Logs`: (datos técnicos de operación)

---

## 📊 MÓDULO 7: TRANSACCIONES DE ACCESO

### Propósito
Registrar, visualizar y reportar historial de entradas y salidas.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **7.1** | **FormHistorialAccesos** | 🚧 | Listar todas las transacciones | DataGrid: Fecha Entrada, Fecha Salida, Usuario, Vehículo, Tiempo, Tarifa | Accesos, Usuarios, Vehiculos |
| **7.2** | **FormBuscarAcceso** | 🚧 | Búsqueda filtrada | Fecha Rango, Usuario, Vehículo, Parqueadero, TAG | Accesos |
| **7.3** | **FormDetalleAcceso** | 🚧 | Ver detalles de entrada/salida | Datos completos: horarios, duracion, cobro | Accesos, Tickets, Pagos |
| **7.4** | **FormExportarAccesos** | 🚧 | Exportar a Excel/PDF | Selección de rango, Formato de salida | Accesos |
| **7.5** | **FormAnalisisOcupacion** | 🚧 | Ocupación por franja horaria | Gráfico línea: Hora vs Cantidad Vehículos | Accesos |
| **7.6** | **FormPeaksHorarios** | 🚧 | Analizar horarios pico | Tabla: Hora, Entradas, Salidas, Ocupación % | Accesos |

**Entidades de Base de Datos:**
- `Accesos`: id_acceso, id_vehiculo, id_garaje, id_asignacion_tag, fecha_entrada, fecha_salida, estado
- `Tickets`: id_ticket, fecha_entrada, fecha_salida, tiempo_total, total_pago

---

## 💰 MÓDULO 8: TARIFAS, PAGOS Y FACTURACIÓN

### Propósito
Gestionar tarifas, cobros, pagos y emisión de facturas.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **8.1** | **FormConfiguracionTarifas** | 🚧 | Definir precios | Tipo Tarifa, Precio Base, Unidad Tiempo, Parqueadero | Tarifas, Garajes |
| **8.2** | **FormFranjasTarifarias** | 🚧 | Crear franjas horarias | Nombre, Hora Inicio, Hora Fin, Tarifa Asociada | Franja, Tarifas |
| **8.3** | **FormTarifasEspeciales** | 🚧 | Precios diferenciados | Tipo (Discapacidad, Mixto), Rol Aplica, % Descuento | Tarifas, Roles |
| **8.4** | **FormGeneracionTickets** | 🚧 | Crear ticket de visitante | Placa, Hora Entrada, Teléfono (opcional), Guardia | Tickets |
| **8.5** | **FormCierre Ticket** | 🚧 | Registrar salida visitante | Ticket, Calcular tarifa, Monto a pagar | Tickets, Tarifas |
| **8.6** | **FormRegistroPagos** | 🚧 | CRUD de transacciones | Monto, Fecha, Método, Usuario, Estado | Pagos, Metodos_Pago |
| **8.7** | **FormEmisionFactura** | 🚧 | Generar factura | Artículos, Cantidades, Valores, RUC Empresa | Facturas (tabla futura) |
| **8.8** | **FormPagoPendiente** | 🚧 | Ver deudas | DataGrid: Usuario, Monto, Fecha Vencimiento, Acción | Pagos, Usuarios |
| **8.9** | **FormCobroPagoPendiente** | 🚧 | Cobrar deuda | Seleccionar Usuario, Mostrar deuda, Nueva transacción | Pagos, Usuarios |

**Entidades de Base de Datos:**
- `Tarifas`: id_tarifa, tipo, precio, id_garaje
- `Franja`: id_franja, nombre, hora_inicio, hora_fin, id_tarifa
- `Tickets`: id_ticket, fecha_entrada, fecha_salida, tiempo_total, id_tarifa, total_pago, id_usuario
- `Pagos`: id_pago, id_usuario, id_metodo_pago, total_pago, fecha_pago, estado_pago, estado_factura
- `Metodos_Pago`: id_metodo_pago, nombre, estado

---

## ⚖️ MÓDULO 9: GESTIÓN DE SANCIONES

### Propósito
Aplicar, monitorear y gestionar sanciones a usuarios por incumplimientos.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **9.1** | **FormTiposSanciones** | 🚧 | Definir tipos de multas | Nombre Sanción, Descripción, Monto, Estado | Tipo_Sanciones |
| **9.2** | **FormAplicarSancion** | 🚧 | Crear nueva sanción | Usuario, Tipo, Razón, Monto, Fecha Vigencia | Sanciones, Usuarios |
| **9.3** | **FormListaSanciones** | 🚧 | Ver todas las sanciones | DataGrid: Usuario, Tipo, Monto, Fecha, Estado | Sanciones |
| **9.4** | **FormSancionesUsuario** | 🚧 | Historial de sanciones por usuario | DataGrid filtrado para usuario seleccionado | Sanciones, Usuarios |
| **9.5** | **FormBloqueoAcceso** | 🚧 | Ver usuarios bloqueados | DataGrid: Usuario, Razón, Fecha Bloqueo, Acción | Usuarios, Sanciones |
| **9.6** | **FormDesbloqueoSancion** | 🚧 | Levantar sanción | Usuario, Descuento/Condonación, Autorización | Sanciones |
| **9.7** | **FormPagoSancion** | 🚧 | Registrar pago de multa | Sanción, Monto, Método, Comprobante | Sanciones, Pagos |

**Entidades de Base de Datos:**
- `Tipo_Sanciones`: id_tipo_sancion, nombre, descripcion, estado, monto
- `Sanciones`: id_sancion, id_tipo_sancion, id_usuario, fecha_sancion, estado_factura, estado_sancion

---

## 📈 MÓDULO 10: REPORTES Y ANÁLISIS

### Propósito
Generar reportes estratégicos, tácticos y operativos.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **10.1** | **FormReporteOcupacion** | 🚧 | Ocupación por parqueadero | Gráfico barras: Parqueadero vs Ocupación %, Detalles | Accesos, Garajes |
| **10.2** | **FormReporteAccesos** | 🚧 | Historial de accesos filtrado | Tabla exportable: Período, Usuario, Vehículo, Cantidad | Accesos |
| **10.3** | **FormReporteFinanciero** | 🚧 | Ingresos y recaudación | Tabla: Período, Ingresos Total, por Método, por Usuario | Pagos, Tickets |
| **10.4** | **FormReporteTagsInventario** | 🚧 | Estado actual de TAGs | Tabla: Total, Disponibles, Asignados, Dañados, % | Tags, Asignacion_Tags |
| **10.5** | **FormReporteSanciones** | 🚧 | Multas aplicadas y cobradas | Tabla: Tipo, Cantidad Aplicadas, Cantidad Pagadas, Pendiente | Sanciones, Pagos |
| **10.6** | **FormReporteMantenimiento** | 🚧 | Incidencias y mantenimiento | Gráfico: Mes vs Cantidad Fallas, Detalles | Incidencias |
| **10.7** | **FormDashboardAdministrativo** | 🚧 | Panel resumen ejecutivo | KPIs: Ocupación %, Ingresos día, TAGs activos, Alertas | (Todos) |

**Entidades de Base de Datos:**
- (Múltiples, consultas que unen varias tablas)

---

## 🔧 MÓDULO 11: GESTIÓN DE INCIDENCIAS

### Propósito
Reportar, dar seguimiento y resolver problemas técnicos.

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|---|---|
| **11.1** | **FormReportarIncidencia** | 🚧 | Crear nuevo reporte | Descripción, Usuario, Equipo Afectado, Fecha | Incidencias |
| **11.2** | **FormListaIncidencias** | 🚧 | Ver todas las incidencias | DataGrid: Fecha, Descripción, Estado, Responsable | Incidencias |
| **11.3** | **FormDetalleIncidencia** | 🚧 | Ver y editar incidencia | Datos completo, Historial de cambios, Adjuntos | Incidencias |
| **11.4** | **FormAsignarTecnico** | 🚧 | Designar responsable | Incidencia, Técnico, Fecha Estimada Resolución | Incidencias |
| **11.5** | **FormCierreIncidencia** | 🚧 | Marcar como resuelta | Incidencia, Descripción Solución, Fecha Resolución | Incidencias |

**Entidades de Base de Datos:**
- `Incidencias`: id_incidencia, id_usuario, id_garaje, id_vehiculo, descripcion, fecha_creacion, fecha_resolucion, estado

---

## 👥 MÓDULO 12: GESTIÓN DE VISITANTES

### Propósito
Gestionar acceso temporal de vehículos no registrados (visitantes).

| # | Formulario | MVP | Propósito | Campos Principales | Entidades Relacionadas |
|---|-----------|-----|----------|-----------------|----------------------|
| **12.1** | **FormRegistroVisitante** | 🚧 | Crear entrada para visitante | Placa, Nombre Visitante, Teléfono, Hora Esperada Salida | Tickets (reutilizable) |
| **12.2** | **FormSalidaVisitante** | 🚧 | Registrar salida visitante | Búsqueda por Placa, Cálculo Tarifa, Método Pago | Tickets |
| **12.3** | **FormListaVisitantes** | 🚧 | Visitantes activos hoy | DataGrid: Placa, Nombre, Hora Entrada, Tiempo Transcurrido | Tickets |
| **12.4** | **FormProlongacionVisita** | 🚧 | Extender estadía | Visitante, Horas Adicionales, Costo Extra | Tickets |

**Entidades de Base de Datos:**
- `Tickets`: (reutilizable para visitantes temporales)

---

## 🗂️ RESUMEN DE IMPLEMENTACIÓN

### FASE 1 - MVP (Meses 1-2)
**Formularios ESENCIALES - Funcionalidad Mínima Viable**

1. FormLogin (1.1) ✅
2. FormConfiguracionHardware (2.1) ✅
3. FormGestionTarjetas + Agregar/Editar (5.1-5.4) ✅
4. FormControlAccesoRFID (6.1) ✅
5. FormListaUsuarios + CRUD (3.1-3.3) 🚧
6. FormListaVehiculos + CRUD (4.1-4.3) 🚧
7. FormHistorialAccesos (7.1) 🚧
8. FormHistorialAccesos (7.1) 🚧

**Total Fase 1:** ~8-10 formularios

### FASE 2 - Funcionalidad Principal (Meses 3-4)
**Agregar capacidades operativas fundamentales**

- Tarifas básicas (8.1-8.2)
- Pagos básicos (8.6)
- Búsquedas filtradas (3.4, 4.5, 7.2)
- Desactivación usuarios (3.6)
- Detalles de entidades (3.5, 4.4, 7.3)
- Dashboard operativo básico (6.2)

**Total Fase 2:** ~15-18 formularios acumulados

### FASE 3 - Funcionalidades Avanzadas (Meses 5-6)
**Agregar features complejas y reportes**

- Tarifas avanzadas (8.3-8.5)
- Sanciones (Módulo 9 completo)
- Reportes (Módulo 10 - básico)
- Incidencias (Módulo 11 - básico)
- Visitantes (Módulo 12 - básico)

**Total Fase 3:** ~25+ formularios