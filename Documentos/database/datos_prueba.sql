USE [dbo];
GO

-- =============================================
-- 1. TABLAS MAESTRAS (Nivel 1)
-- =============================================

-- Roles
INSERT INTO [dbo].[Roles] (nombre, descripcion, estado) VALUES
('Administrador', 'Control total', 1), ('Estudiante', 'Usuario pregrado', 1),
('Docente', 'Personal académico', 1), ('Administrativo', 'Personal oficina', 1),
('Visita', 'Externos', 1), ('Seguridad', 'Guardias', 1),
('Mantenimiento', 'Técnicos', 1), ('Postgrado', 'Estudiantes maestría', 1),
('Convenio', 'Empresas aliadas', 1), ('Inactivo', 'Sin acceso', 0);

-- Garajes
INSERT INTO [dbo].[Garajes] (nombre, ubicacion, descripcion, fecha_creacion, estado, capacidad_max_espacios, ocupaciones) VALUES
('Central A', 'Norte', 'Principal', '2025-01-01', 1, 100, 5),
('Edificio B', 'Sur', 'Sótano 1', '2025-01-10', 1, 50, 3),
('VIP Torre', 'Centro', 'Exclusivo', '2025-02-01', 1, 20, 2),
('Este 1', 'Este', 'Abierto', '2025-03-01', 1, 80, 0),
('Oeste 2', 'Oeste', 'Cerca canchas', '2025-03-15', 1, 60, 0),
('Subterráneo 3', 'Norte', 'Bloque C', '2025-04-01', 1, 40, 0),
('Motos Norte', 'Norte', 'Solo motos', '2025-04-10', 1, 100, 10),
('Visitantes', 'Puerta 3', 'Temporal', '2025-05-01', 1, 30, 0),
('Nocturno', 'Norte', '24 Horas', '2025-06-01', 1, 50, 0),
('Motos Sur', 'Sur', 'Solo motos', '2025-06-15', 1, 80, 0);

-- Tags
INSERT INTO [dbo].[Tags] (codigo_epc, lote, estado) VALUES
('EPC001', 10, 1), ('EPC002', 10, 1), ('EPC003', 10, 1), ('EPC004', 11, 1),
('EPC005', 11, 0), ('EPC006', 11, 1), ('EPC007', 12, 1), ('EPC008', 12, 1),
('EPC009', 13, 2), ('EPC010', 13, 1);

-- Metodos de Pago
INSERT INTO [dbo].[Metodos_Pago] (nombre, estado) VALUES
('Efectivo', 1), ('Tarjeta Crédito', 1), ('Tarjeta Débito', 1),
('Transferencia', 1), ('App Móvil', 1), ('Billetera Web', 1),
('Cheque', 0), ('Puntos', 1), ('Nómina', 1), ('PayPal', 1);

-- Tipo de Sanciones
INSERT INTO [dbo].[Tipo_Sanciones] (nombre, descripcion, estado, monto) VALUES
('Mal estacionado', 'Fuera de línea', 1, 15.00), ('Exceso velocidad', 'Max 20kmh', 1, 30.00),
('Obstrucción', 'Bloqueo rampa', 1, 50.00), ('Sin Tag', 'No porta sensor', 1, 10.00),
('Discapacidad', 'Puesto indebido', 1, 40.00), ('Riña', 'Pelea física', 1, 100.00),
('Fuga', 'Evasión pago', 1, 20.00), ('Daño Barrera', 'Golpe físico', 1, 150.00),
('Horario', 'Fuera de tiempo', 1, 25.00), ('Basura', 'Arrojar desechos', 1, 5.00);

-- =============================================
-- 2. TABLAS DE USUARIOS Y TARIFAS (Nivel 2)
-- =============================================

-- Usuarios
INSERT INTO [dbo].[Usuarios] (id_rol, cedula, nombres, apellidos, correo, estado_usuario, fecha_creacion, tiene_discapacidad, n_sancion) VALUES
(1, '1701', 'Juan', 'Perez', 'juan@mail.com', 1, '2025-01-01', 0, 0),
(2, '1702', 'Ana', 'Gomez', 'ana@mail.com', 1, '2025-01-05', 0, 0),
(2, '1703', 'Luis', 'Mena', 'luis@mail.com', 1, '2025-01-10', 1, 0),
(3, '1704', 'Rosa', 'Diaz', 'rosa@mail.com', 1, '2025-01-15', 0, 1),
(4, '1705', 'Jose', 'Ruiz', 'jose@mail.com', 1, '2025-02-01', 0, 0),
(2, '1706', 'Carla', 'Sosa', 'carla@mail.com', 1, '2025-02-05', 0, 0),
(5, '1707', 'Pedro', 'Vaca', 'pedro@mail.com', 1, '2025-02-10', 0, 0),
(3, '1708', 'Ines', 'Luna', 'ines@mail.com', 1, '2025-02-15', 1, 0),
(2, '1709', 'Raul', 'Vega', 'raul@mail.com', 1, '2025-03-01', 0, 0),
(6, '1710', 'Sonia', 'Paz', 'sonia@mail.com', 1, '2025-03-05', 0, 0);

-- Tarifas
INSERT INTO [dbo].[Tarifas] (tipo, precio, id_garaje) VALUES
('Hora Est.', 0.50, 1), ('Hora Doc.', 0.80, 1), ('Hora Visita', 1.50, 1),
('Mensual Est.', 25.00, 2), ('Mensual Doc.', 35.00, 2), ('VIP Hora', 2.00, 3),
('Nocturna', 1.00, 9), ('Motos', 0.25, 7), ('Convenio', 0.40, 4), ('Especial', 1.20, 5);

-- Horarios Garaje
INSERT INTO [dbo].[Horarios_Garaje] (hora_apertura, hora_cierre, id_garaje) VALUES
('06:00:00', '22:00:00', 1), ('07:00:00', '21:00:00', 2), ('08:00:00', '18:00:00', 3),
('06:00:00', '22:00:00', 4), ('06:00:00', '22:00:00', 5), ('07:00:00', '20:00:00', 6),
('06:00:00', '21:00:00', 7), ('08:00:00', '17:00:00', 8), ('00:00:00', '23:59:59', 9),
('06:00:00', '21:00:00', 10);

-- Periodos de Inscripcion (MARZO 2026 ACTIVO)
INSERT INTO [dbo].[Periodo_Inscripcion] (id_rol, fecha_inicio, fecha_fin, estado) VALUES
(2, '2026-03-01', '2026-03-31', 1), (3, '2026-03-01', '2026-03-31', 1),
(2, '2026-04-01', '2026-04-30', 1), (3, '2026-04-01', '2026-04-30', 1),
(4, '2026-03-01', '2026-06-30', 1), (5, '2026-03-01', '2026-03-15', 1),
(8, '2026-03-01', '2026-03-31', 1), (2, '2025-12-01', '2025-12-31', 0),
(9, '2026-01-01', '2026-12-31', 1), (10, '2026-03-01', '2026-03-05', 1);

-- =============================================
-- 3. VEHICULOS Y OPERACIONES (Nivel 3)
-- =============================================

-- Vehiculos
INSERT INTO [dbo].[Vehiculos] (id_usuario, placa, tipo_vehiculo, marca, modelo, anio, color, fecha_creacion, estado) VALUES
(1, 'PBA-001', 'SUV', 'Toyota', 'Rav4', 2022, 'Gris', '2025-01-01', 1),
(2, 'PBA-002', 'Sedan', 'Kia', 'Rio', 2021, 'Blanco', '2025-01-05', 1),
(3, 'PBA-003', 'Hatch', 'Ford', 'Fiesta', 2020, 'Rojo', '2025-01-10', 1),
(4, 'PBA-004', 'Truck', 'Chevrolet', 'D-Max', 2023, 'Negro', '2025-01-15', 1),
(5, 'PBA-005', 'Sedan', 'Mazda', '3', 2019, 'Azul', '2025-02-01', 1),
(6, 'PBA-006', 'SUV', 'Hyundai', 'Tucson', 2022, 'Vino', '2025-02-05', 1),
(7, 'PBA-007', 'Moto', 'Honda', 'CBR', 2024, 'Verde', '2025-02-10', 1),
(8, 'PBA-008', 'Sedan', 'Nissan', 'Versa', 2018, 'Plata', '2025-02-15', 1),
(9, 'PBA-009', 'Moto', 'Suzuki', 'Gixxer', 2023, 'Negro', '2025-03-01', 1),
(10, 'PBA-010', 'SUV', 'Jeep', 'Compass', 2024, 'Blanco', '2025-03-05', 1);

-- Franjas
INSERT INTO [dbo].[Franja] (nombre, hora_inicio, hora_fin, id_tarifa) VALUES
('Mañana Est.', '07:00:00', '12:00:00', 1), ('Tarde Est.', '13:00:00', '18:00:00', 1),
('Mañana Doc.', '07:00:00', '13:00:00', 2), ('VIP Mañana', '08:00:00', '14:00:00', 6),
('Nocturna A', '22:00:00', '23:59:00', 7), ('Motos AM', '06:00:00', '14:00:00', 8),
('Convenio X', '08:00:00', '17:00:00', 9), ('Visita AM', '09:00:00', '12:00:00', 3),
('Especial F', '15:00:00', '21:00:00', 10), ('Tarde Doc.', '14:00:00', '21:00:00', 2);

-- Activacion Tags
INSERT INTO [dbo].[Activacion_Tags] (id_tag, fecha_inicio, fecha_fin, estado) VALUES
(1, '2025-01-01', NULL, 1), (2, '2025-01-01', NULL, 1), (3, '2025-01-01', NULL, 1),
(4, '2025-01-01', NULL, 1), (6, '2025-02-01', NULL, 1), (7, '2025-02-01', NULL, 1),
(8, '2025-02-01', NULL, 1), (10, '2025-03-01', NULL, 1), (9, '2025-03-01', '2026-01-01', 0),
(5, '2025-01-01', '2025-05-01', 0);

-- =============================================
-- 4. TRANSACCIONALES (Nivel 4)
-- =============================================

-- Sanciones
INSERT INTO [dbo].[Sanciones] (id_tipo_sancion, id_usuario, fecha_sancion, estado_factura, estado_sancion) VALUES
(1, 4, '2026-03-01', 1, 1), (2, 2, '2026-03-02', 0, 1), (5, 8, '2026-03-03', 1, 1);
-- (Añadir 7 más si es necesario, he puesto 3 clave para no saturar los pagos)

-- Asignacion Tags
INSERT INTO [dbo].[Asignacion_Tags] (id_tag, id_vehiculo, fecha_asignacion, estado_asignacion) VALUES
(1, 1, '2025-01-02', 1), (2, 2, '2025-01-06', 1), (3, 3, '2025-01-11', 1),
(4, 4, '2025-01-16', 1), (6, 6, '2025-02-06', 1), (7, 7, '2025-02-11', 1),
(8, 8, '2025-02-16', 1), (10, 10, '2025-03-06', 1), (1, 1, '2026-01-01', 1),
(2, 2, '2026-01-01', 1);

-- Accesos (SIMULACIÓN HOY 4 DE MARZO)
INSERT INTO [dbo].[Accesos] (id_vehiculo, id_garaje, id_asignacion_tag, fecha_entrada, fecha_salida, estado) VALUES
(1, 1, 1, '2026-03-04 07:00:00', NULL, 1), -- ADENTRO
(2, 1, 2, '2026-03-04 08:00:00', '2026-03-04 12:00:00', 1),
(3, 1, 3, '2026-03-04 09:30:00', NULL, 1), -- ADENTRO
(4, 2, 4, '2026-03-04 07:45:00', NULL, 1), -- ADENTRO
(7, 7, 6, '2026-03-04 06:30:00', '2026-03-04 14:00:00', 1),
(10, 3, 8, '2026-03-04 10:00:00', NULL, 1), -- ADENTRO
(8, 1, 7, '2026-03-03 08:00:00', '2026-03-03 17:00:00', 1),
(1, 1, 1, '2026-03-03 07:00:00', '2026-03-03 18:00:00', 1),
(2, 1, 2, '2026-03-02 08:00:00', '2026-03-02 12:00:00', 1),
(6, 2, 5, '2026-03-04 13:00:00', NULL, 1); -- ADENTRO

-- Tickets
INSERT INTO [dbo].[Tickets] (fecha_entrada, fecha_salida, tiempo_total, id_tarifa, total_pago, id_usuario, nombres, apellidos, estado_factura, cedula, correo) VALUES
('2026-03-04 08:00:00', NULL, NULL, 1, NULL, 2, 'Ana', 'Gomez', 0, '1702', 'ana@mail.com'),
('2026-03-04 09:00:00', '2026-03-04 11:00:00', 2.0, 3, 3.00, 7, 'Pedro', 'Vaca', 1, '1707', 'pedro@mail.com'),
('2026-03-03 10:00:00', '2026-03-03 15:00:00', 5.0, 1, 2.50, 6, 'Carla', 'Sosa', 1, '1706', 'carla@mail.com'),
('2026-03-04 12:00:00', NULL, NULL, 2, NULL, 4, 'Rosa', 'Diaz', 0, '1704', 'rosa@mail.com'),
('2026-03-04 07:00:00', '2026-03-04 08:00:00', 1.0, 8, 0.25, 9, 'Raul', 'Vega', 1, '1709', 'raul@mail.com'),
('2026-03-02 18:00:00', '2026-03-02 21:00:00', 3.0, 7, 3.00, 10, 'Sonia', 'Paz', 1, '1710', 'sonia@mail.com'),
('2026-03-04 08:30:00', '2026-03-04 10:30:00', 2.0, 3, 3.00, 7, 'Pedro', 'Vaca', 2, '1707', 'pedro@mail.com'),
('2026-03-04 13:00:00', NULL, NULL, 6, NULL, 8, 'Ines', 'Luna', 0, '1708', 'ines@mail.com'),
('2026-03-01 07:00:00', '2026-03-01 17:00:00', 10.0, 1, 5.00, 2, 'Ana', 'Gomez', 1, '1702', 'ana@mail.com'),
('2026-03-03 14:00:00', '2026-03-03 16:00:00', 2.0, 1, 1.00, 6, 'Carla', 'Sosa', 1, '1706', 'carla@mail.com');

-- Asignacion Tarifa
INSERT INTO [dbo].[Asignacion_Tarifa] (id_asignacion_tag, id_tarifa, fecha_pago, estado, estado_factura, total_horas) VALUES
(1, 4, '2026-03-01', 1, 1, 160), (2, 4, '2026-03-01', 1, 1, 160),
(3, 4, '2026-03-01', 1, 1, 160), (4, 5, '2026-03-01', 1, 1, 160),
(6, 5, '2026-03-01', 1, 1, 160), (7, 4, '2026-03-01', 1, 1, 160),
(1, 4, '2026-02-01', 1, 1, 160), (2, 4, '2026-02-01', 1, 1, 160),
(10, 4, '2026-03-01', 1, 0, 160), (8, 5, '2026-03-01', 1, 1, 160);

-- Inscripciones
INSERT INTO [dbo].[Inscripciones] (id_usuario, id_periodo_inscripcion, fecha_inscripcion, estado) VALUES
(2, 1, '2026-03-01', 1), (3, 1, '2026-03-01', 1), (6, 1, '2026-03-01', 1),
(9, 1, '2026-03-01', 1), (4, 5, '2026-03-01', 1), (8, 2, '2026-03-01', 1),
(1, 9, '2026-01-10', 1), (7, 6, '2026-03-01', 1), (10, 7, '2026-03-01', 1),
(5, 5, '2026-03-01', 1);

-- Franja Horaria
INSERT INTO [dbo].[Franja_Horaria] (id_usuario, id_franja, estado) VALUES
(2, 1, 1), (3, 1, 1), (4, 3, 1), (6, 2, 1), (8, 4, 1),
(9, 6, 1), (1, 7, 1), (7, 8, 1), (10, 9, 1), (4, 10, 1);

-- Incidencias
INSERT INTO [dbo].[Incidencias] (id_usuario, id_garaje, id_vehiculo, descripcion, estado) VALUES
(2, 1, 2, 'Coche vecino muy pegado', 1), (4, 2, 4, 'Fuga de aceite detectada', 0),
(10, 3, 10, 'Tag no leyó al entrar', 2);

-- Pagos (Final)
INSERT INTO [dbo].[Pagos] (id_usuario, id_metodo_pago, id_asignacion_tarifa, id_sancion, total_pago, estado_pago, estado_factura, n_factura) VALUES
(2, 1, 1, NULL, 25.00, 1, 1, 5001),
(4, 2, NULL, 1, 15.00, 1, 1, 5002),
(8, 3, 6, 3, 75.00, 1, 1, 5003),
(3, 1, 3, NULL, 25.00, 1, 1, 5004),
(6, 5, 5, NULL, 35.00, 1, 1, 5005);

-- Logs
INSERT INTO [dbo].[Logs] (id_usuario, tabla, id_modificado, tipo) VALUES
(1, 'Usuarios', 1, 'INSERT'), (1, 'Vehiculos', 1, 'INSERT'), (1, 'Tarifas', 1, 'UPDATE');
GO