IF DB_ID('dbo') IS NOT NULL
BEGIN
    ALTER DATABASE [dbo] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [dbo];
END
CREATE DATABASE [dbo];

USE [dbo];

CREATE TABLE [dbo].[Roles] (
    [id_rol] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100) NOT NULL,
    [descripcion] varchar(255) NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_rol]),
    CONSTRAINT [UQ_Roles_nombre] UNIQUE ([nombre]),
    CONSTRAINT [CK_Roles_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Garajes] (
    [id_garaje] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100) NOT NULL,
    [ubicacion] varchar(200) NOT NULL,
    [descripcion] varchar(255) NULL,
    [fecha_creacion] date NOT NULL,
    [estado] int NOT NULL,
    [capacidad_max_espacios] int NOT NULL,
    [ocupaciones] int NOT NULL DEFAULT 0,
    PRIMARY KEY ([id_garaje]),
    CONSTRAINT [UQ_Garajes_nombre] UNIQUE ([nombre]),
    CONSTRAINT [CK_Garajes_estado] CHECK ([estado] IN (0, 1)),
    CONSTRAINT [CK_Garajes_capacidad] CHECK ([capacidad_max_espacios] > 0),
    CONSTRAINT [CK_Garajes_ocupaciones] CHECK ([ocupaciones] >= 0),
    CONSTRAINT [CK_Garajes_ocupaciones_max] CHECK ([ocupaciones] <= [capacidad_max_espacios])
);

CREATE TABLE [dbo].[Tags] (
    [id_tag] int IDENTITY(1,1) NOT NULL,
    [codigo_epc] varchar(128) NOT NULL,
    [lote] int NOT NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_tag]),
    CONSTRAINT [UQ_Tags_codigo_epc] UNIQUE ([codigo_epc]),
    CONSTRAINT [CK_Tags_estado] CHECK ([estado] IN (0, 1, 2))
);

CREATE TABLE [dbo].[Metodos_Pago] (
    [id_metodo_pago] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50) NOT NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_metodo_pago]),
    CONSTRAINT [UQ_MetodosPago_nombre] UNIQUE ([nombre]),
    CONSTRAINT [CK_MetodosPago_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Usuarios] (
    [id_usuario] int IDENTITY(1,1) NOT NULL,
    [id_rol] int NOT NULL,
    [cedula] varchar(20) NOT NULL,
    [nombres] varchar(100) NOT NULL,
    [apellidos] varchar(100) NOT NULL,
    [correo] varchar(150) NOT NULL,
    [estado_usuario] int NOT NULL,
    [fecha_creacion] date NOT NULL,
    [tiene_discapacidad] int NOT NULL DEFAULT 0,
    [n_sancion] int NOT NULL DEFAULT 0,
    PRIMARY KEY ([id_usuario]),
    CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY ([id_rol]) REFERENCES [dbo].[Roles]([id_rol]),
    CONSTRAINT [UQ_Usuarios_cedula] UNIQUE ([cedula]),
    CONSTRAINT [UQ_Usuarios_correo] UNIQUE ([correo]),
    CONSTRAINT [CK_Usuarios_estado] CHECK ([estado_usuario] IN (0, 1, 2)),
    CONSTRAINT [CK_Usuarios_discapacidad] CHECK ([tiene_discapacidad] IN (0, 1)),
    CONSTRAINT [CK_Usuarios_n_sancion] CHECK ([n_sancion] >= 0),
    CONSTRAINT [CK_Usuarios_correo_formato] CHECK ([correo] LIKE '%_@_%.__%')
);

CREATE TABLE [dbo].[Tarifas] (
    [id_tarifa] int IDENTITY(1,1) NOT NULL,
    [tipo] varchar(50) NOT NULL,
    [precio] decimal(10,2) NOT NULL,
    [id_garaje] int NOT NULL,
    PRIMARY KEY ([id_tarifa]),
    CONSTRAINT [FK_Tarifas_Garajes] FOREIGN KEY ([id_garaje]) REFERENCES [dbo].[Garajes]([id_garaje]),
    CONSTRAINT [CK_Tarifas_precio] CHECK ([precio] > 0)
);

CREATE TABLE [dbo].[Horarios_Garaje] (
    [id_horario_garaje] int IDENTITY(1,1) NOT NULL,
    [hora_apertura] time NOT NULL,
    [hora_cierre] time NOT NULL,
    [id_garaje] int NOT NULL,
    PRIMARY KEY ([id_horario_garaje]),
    CONSTRAINT [FK_HorariosGaraje_Garajes] FOREIGN KEY ([id_garaje]) REFERENCES [dbo].[Garajes]([id_garaje]),
    CONSTRAINT [CK_HorariosGaraje_horario] CHECK ([hora_apertura] < [hora_cierre])
);

CREATE TABLE [dbo].[Periodo_Inscripcion] (
    [id_periodo_inscripcion] int IDENTITY(1,1) NOT NULL,
    [id_rol] int NOT NULL,
    [fecha_inicio] date NOT NULL,
    [fecha_fin] date NOT NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_periodo_inscripcion]),
    CONSTRAINT [FK_PeriodoInscripcion_Roles] FOREIGN KEY ([id_rol]) REFERENCES [dbo].[Roles]([id_rol]),
    CONSTRAINT [CK_PeriodoInscripcion_fechas] CHECK ([fecha_inicio] <= [fecha_fin]),
    CONSTRAINT [CK_PeriodoInscripcion_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Tipo_Sanciones] (
    [id_tipo_sancion] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100) NOT NULL,
    [descripcion] varchar(255) NULL,
    [estado] int NOT NULL,
    [monto] decimal(10,2) NOT NULL,
    PRIMARY KEY ([id_tipo_sancion]),
    CONSTRAINT [UQ_TipoSanciones_nombre] UNIQUE ([nombre]),
    CONSTRAINT [CK_TipoSanciones_estado] CHECK ([estado] IN (0, 1)),
    CONSTRAINT [CK_TipoSanciones_monto] CHECK ([monto] > 0)
);

CREATE TABLE [dbo].[Vehiculos] (
    [id_vehiculo] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int NOT NULL,
    [placa] varchar(10) NOT NULL,
    [tipo_vehiculo] varchar(50) NOT NULL,
    [marca] varchar(50) NOT NULL,
    [modelo] varchar(50) NOT NULL,
    [anio] int NOT NULL,
    [color] varchar(30) NOT NULL,
    [fecha_creacion] date NOT NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_vehiculo]),
    CONSTRAINT [FK_Vehiculos_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [UQ_Vehiculos_placa] UNIQUE ([placa]),
    CONSTRAINT [CK_Vehiculos_estado] CHECK ([estado] IN (0, 1)),
    CONSTRAINT [CK_Vehiculos_anio] CHECK ([anio] >= 1900 AND [anio] <= 2100)
);

CREATE TABLE [dbo].[Franja] (
    [id_franja] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100) NOT NULL,
    [hora_inicio] time NOT NULL,
    [hora_fin] time NOT NULL,
    [id_tarifa] int NOT NULL,
    PRIMARY KEY ([id_franja]),
    CONSTRAINT [FK_Franja_Tarifas] FOREIGN KEY ([id_tarifa]) REFERENCES [dbo].[Tarifas]([id_tarifa]),
    CONSTRAINT [UQ_Franja_nombre] UNIQUE ([nombre]),
    CONSTRAINT [CK_Franja_horario] CHECK ([hora_inicio] < [hora_fin])
);

CREATE TABLE [dbo].[Incidencias] (
    [id_incidencia] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int NOT NULL,
    [id_garaje] int NULL,
    [id_vehiculo] int NULL,
    [descripcion] varchar(500) NOT NULL,
    [fecha_creacion] datetime NOT NULL DEFAULT GETDATE(),
    [fecha_resolucion] datetime NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_incidencia]),
    CONSTRAINT [FK_Incidencias_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [FK_Incidencias_Garajes] FOREIGN KEY ([id_garaje]) REFERENCES [dbo].[Garajes]([id_garaje]),
    CONSTRAINT [FK_Incidencias_Vehiculos] FOREIGN KEY ([id_vehiculo]) REFERENCES [dbo].[Vehiculos]([id_vehiculo]),
    CONSTRAINT [CK_Incidencias_estado] CHECK ([estado] IN (0, 1, 2))
);

CREATE TABLE [dbo].[Tickets] (
    [id_ticket] int IDENTITY(1,1) NOT NULL,
    [fecha_entrada] datetime NOT NULL,
    [fecha_salida] datetime NULL,
    [tiempo_total] decimal(10,2) NULL,
    [id_tarifa] int NOT NULL,
    [total_pago] decimal(10,2) NULL,
    [id_usuario] int NOT NULL,
    [nombres] varchar(100) NOT NULL,
    [apellidos] varchar(100) NOT NULL,
    [estado_factura] int NOT NULL,
    [cedula] varchar(20) NOT NULL,
    [correo] varchar(150) NOT NULL,
    PRIMARY KEY ([id_ticket]),
    CONSTRAINT [FK_Tickets_Tarifas] FOREIGN KEY ([id_tarifa]) REFERENCES [dbo].[Tarifas]([id_tarifa]),
    CONSTRAINT [FK_Tickets_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [CK_Tickets_fechas] CHECK ([fecha_salida] IS NULL OR [fecha_salida] >= [fecha_entrada]),
    CONSTRAINT [CK_Tickets_total_pago] CHECK ([total_pago] IS NULL OR [total_pago] >= 0),
    CONSTRAINT [CK_Tickets_tiempo_total] CHECK ([tiempo_total] IS NULL OR [tiempo_total] >= 0),
    CONSTRAINT [CK_Tickets_estado_factura] CHECK ([estado_factura] IN (0, 1, 2))
);

CREATE TABLE [dbo].[Pagos] (
    [id_pago] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int NOT NULL,
    [id_metodo_pago] int NOT NULL,
    [id_asignacion_tarifa] int NULL,
    [id_sancion] int NULL,
    [total_pago] decimal(10,2) NOT NULL,
    [fecha_pago] datetime NOT NULL DEFAULT GETDATE(),
    [estado_pago] int NOT NULL,
    [estado_factura] int NOT NULL,
    [n_factura] int NULL,
    PRIMARY KEY ([id_pago]),
    CONSTRAINT [FK_Pagos_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [FK_Pagos_MetodosPago] FOREIGN KEY ([id_metodo_pago]) REFERENCES [dbo].[Metodos_Pago]([id_metodo_pago]),
    CONSTRAINT [CK_Pagos_total_pago] CHECK ([total_pago] >= 0),
    CONSTRAINT [CK_Pagos_estado_pago] CHECK ([estado_pago] IN (0, 1, 2)),
    CONSTRAINT [CK_Pagos_estado_factura] CHECK ([estado_factura] IN (0, 1, 2)),
    CONSTRAINT [UQ_Pagos_n_factura] UNIQUE ([n_factura])
);

CREATE TABLE [dbo].[Sanciones] (
    [id_sancion] int IDENTITY(1,1) NOT NULL,
    [id_tipo_sancion] int NOT NULL,
    [id_usuario] int NOT NULL,
    [fecha_sancion] datetime NOT NULL DEFAULT GETDATE(),
    [estado_factura] int NOT NULL,
    [estado_sancion] int NOT NULL,
    PRIMARY KEY ([id_sancion]),
    CONSTRAINT [FK_Sanciones_TipoSanciones] FOREIGN KEY ([id_tipo_sancion]) REFERENCES [dbo].[Tipo_Sanciones]([id_tipo_sancion]),
    CONSTRAINT [FK_Sanciones_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [CK_Sanciones_estado_factura] CHECK ([estado_factura] IN (0, 1, 2)),
    CONSTRAINT [CK_Sanciones_estado_sancion] CHECK ([estado_sancion] IN (0, 1))
);

CREATE TABLE [dbo].[Activacion_Tags] (
    [id_activacion_tag] int IDENTITY(1,1) NOT NULL,
    [id_tag] int NOT NULL,
    [fecha_inicio] datetime NOT NULL,
    [fecha_fin] datetime NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_activacion_tag]),
    CONSTRAINT [FK_ActivacionTags_Tags] FOREIGN KEY ([id_tag]) REFERENCES [dbo].[Tags]([id_tag]),
    CONSTRAINT [CK_ActivacionTags_fechas] CHECK ([fecha_fin] IS NULL OR [fecha_fin] >= [fecha_inicio]),
    CONSTRAINT [CK_ActivacionTags_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Logs] (
    [id_log] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int NOT NULL,
    [tabla] varchar(100) NOT NULL,
    [id_modificado] int NOT NULL,
    [tipo] varchar(50) NOT NULL,
    [fecha] datetime NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY ([id_log]),
    CONSTRAINT [FK_Logs_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [CK_Logs_tipo] CHECK ([tipo] IN ('INSERT', 'UPDATE', 'DELETE'))
);

CREATE TABLE [dbo].[Asignacion_Tags] (
    [id_asignacion_tag] int IDENTITY(1,1) NOT NULL,
    [id_tag] int NOT NULL,
    [id_vehiculo] int NOT NULL,
    [fecha_asignacion] date NOT NULL,
    [estado_asignacion] int NOT NULL,
    PRIMARY KEY ([id_asignacion_tag]),
    CONSTRAINT [FK_AsignacionTags_Tags] FOREIGN KEY ([id_tag]) REFERENCES [dbo].[Tags]([id_tag]),
    CONSTRAINT [FK_AsignacionTags_Vehiculos] FOREIGN KEY ([id_vehiculo]) REFERENCES [dbo].[Vehiculos]([id_vehiculo]),
    CONSTRAINT [CK_AsignacionTags_estado] CHECK ([estado_asignacion] IN (0, 1))
);

CREATE TABLE [dbo].[Accesos] (
    [id_acceso] int IDENTITY(1,1) NOT NULL,
    [id_vehiculo] int NOT NULL,
    [id_garaje] int NOT NULL,
    [id_asignacion_tag] int NOT NULL,
    [fecha_entrada] datetime NOT NULL,
    [fecha_salida] datetime NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_acceso]),
    CONSTRAINT [FK_Accesos_Vehiculos] FOREIGN KEY ([id_vehiculo]) REFERENCES [dbo].[Vehiculos]([id_vehiculo]),
    CONSTRAINT [FK_Accesos_Garajes] FOREIGN KEY ([id_garaje]) REFERENCES [dbo].[Garajes]([id_garaje]),
    CONSTRAINT [FK_Accesos_AsignacionTags] FOREIGN KEY ([id_asignacion_tag]) REFERENCES [dbo].[Asignacion_Tags]([id_asignacion_tag]),
    CONSTRAINT [CK_Accesos_fechas] CHECK ([fecha_salida] IS NULL OR [fecha_salida] >= [fecha_entrada]),
    CONSTRAINT [CK_Accesos_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Franja_Horaria] (
    [id_franja_horaria] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int NOT NULL,
    [id_franja] int NOT NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_franja_horaria]),
    CONSTRAINT [FK_FranjaHoraria_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [FK_FranjaHoraria_Franja] FOREIGN KEY ([id_franja]) REFERENCES [dbo].[Franja]([id_franja]),
    CONSTRAINT [UQ_FranjaHoraria_usuario_franja] UNIQUE ([id_usuario], [id_franja]),
    CONSTRAINT [CK_FranjaHoraria_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Inscripciones] (
    [id_inscripcion] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int NOT NULL,
    [id_periodo_inscripcion] int NOT NULL,
    [fecha_inscripcion] date NOT NULL,
    [estado] int NOT NULL,
    PRIMARY KEY ([id_inscripcion]),
    CONSTRAINT [FK_Inscripciones_Usuarios] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios]([id_usuario]),
    CONSTRAINT [FK_Inscripciones_PeriodoInscripcion] FOREIGN KEY ([id_periodo_inscripcion]) REFERENCES [dbo].[Periodo_Inscripcion]([id_periodo_inscripcion]),
    CONSTRAINT [CK_Inscripciones_estado] CHECK ([estado] IN (0, 1))
);

CREATE TABLE [dbo].[Asignacion_Tarifa] (
    [id_asignacion_tarifa] int IDENTITY(1,1) NOT NULL,
    [id_asignacion_tag] int NOT NULL,
    [id_tarifa] int NOT NULL,
    [fecha_pago] date NOT NULL,
    [estado] int NOT NULL,
    [estado_factura] int NOT NULL,
    [total_horas] int NOT NULL,
    PRIMARY KEY ([id_asignacion_tarifa]),
    CONSTRAINT [FK_AsignacionTarifa_AsignacionTags] FOREIGN KEY ([id_asignacion_tag]) REFERENCES [dbo].[Asignacion_Tags]([id_asignacion_tag]),
    CONSTRAINT [FK_AsignacionTarifa_Tarifas] FOREIGN KEY ([id_tarifa]) REFERENCES [dbo].[Tarifas]([id_tarifa]),
    CONSTRAINT [CK_AsignacionTarifa_total_horas] CHECK ([total_horas] > 0),
    CONSTRAINT [CK_AsignacionTarifa_estado] CHECK ([estado] IN (0, 1, 2)),
    CONSTRAINT [CK_AsignacionTarifa_estado_factura] CHECK ([estado_factura] IN (0, 1, 2))
);

ALTER TABLE [dbo].[Pagos]
    ADD CONSTRAINT [FK_Pagos_Sanciones]
    FOREIGN KEY ([id_sancion]) REFERENCES [dbo].[Sanciones]([id_sancion]);

ALTER TABLE [dbo].[Pagos]
    ADD CONSTRAINT [FK_Pagos_AsignacionTarifa]
    FOREIGN KEY ([id_asignacion_tarifa]) REFERENCES [dbo].[Asignacion_Tarifa]([id_asignacion_tarifa]);

