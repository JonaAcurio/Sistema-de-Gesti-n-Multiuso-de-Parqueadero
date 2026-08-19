# Catálogo de Casos de Uso

**Código documental:** CP-CU-001
**Versión:** 2.0
**Estado:** Borrador para validación institucional
**Fecha:** 2026-08-18

## Propósito y regla de alcance

Este catálogo consolida los casos de uso que estaban fragmentados en varios archivos. Conserva los identificadores `CU-*` para trazabilidad. La etiqueta de alcance distingue el núcleo MVP de los flujos previstos para el sistema completo; un caso listado aquí no implica implementación ni aprobación institucional.

## Casos del MVP

### CU-ACC-001 — Validar acceso local

Actor principal: Aplicación local de garita.
Precondiciones: Controlador conectado y datos locales cargados.
Flujo: recibir lectura; consultar TAG; validar estado; autorizar o denegar; registrar evento.
Resultado: decisión de acceso auditable.

### CU-ACC-002 — Autorizar entrada o salida

Actor principal: Aplicación local de garita.
Precondiciones: Existe una decisión autorizada.
Flujo: determinar punto de acceso; enviar orden al controlador; confirmar registro del evento.
Resultado: apertura ejecutada y registrada.

### CU-ACC-003 — Apertura manual justificada

Actor principal: Operador de garita.
Precondiciones: Permiso de apertura manual.
Flujo: seleccionar acceso; registrar motivo; confirmar acción; enviar orden.
Resultado: apertura manual auditable.

### CU-ACC-004 — Consultar eventos de acceso

Actor principal: Operador de garita.
Precondiciones: Existen eventos registrados.
Flujo: abrir monitoreo; filtrar eventos; revisar detalle.
Resultado: historial operativo consultable.

### CU-ACC-005 — Recuperar comunicación técnica

Actor principal: Soporte técnico.
Precondiciones: Existe una desconexión o error.
Flujo: detectar estado; reintentar conexión; registrar éxito o fallo.
Resultado: estado técnico actualizado.

### CU-ACC-006 — Operar en contingencia local

Actor principal: Aplicación local de garita.
Precondiciones: Servicios centrales no disponibles y datos locales accesibles.
Flujo: continuar validando con datos locales; registrar eventos pendientes; marcar sincronización futura.
Resultado: continuidad operativa local dentro de los límites definidos.

### CU-TAG-001 — Registrar TAG

Actor principal: Operador de garita.
Precondiciones: El TAG no existe.
Flujo: capturar identificador; asociar usuario y vehículo; guardar estado inicial.
Resultado: TAG disponible para operación.

### CU-TAG-002 — Activar o desactivar TAG

Actor principal: Operador de garita.
Precondiciones: El TAG existe.
Flujo: buscar TAG; cambiar estado; confirmar registro.
Resultado: estado actualizado con historial.

### CU-VEH-001 — Registrar vehículo

Actor principal: Usuario institucional u operador autorizado.
Precondiciones: Existe actor habilitado para el registro.
Flujo: capturar placa y datos básicos; validar integridad; guardar vehículo.
Resultado: vehículo disponible para asociación.

### CU-VEH-002 — Asociar vehículo a usuario y TAG

Actor principal: Operador de garita.
Precondiciones: Existe vehículo y TAG.
Flujo: seleccionar usuario; seleccionar vehículo; seleccionar TAG; guardar asociación.
Resultado: relación operativa para validación de acceso.

### CU-REP-001 — Consultar auditoría de accesos

Actor principal: Administrador funcional.
Precondiciones: Existen eventos registrados.
Flujo: seleccionar rango o filtro; consultar eventos; revisar detalle.
Resultado: evidencia operativa consultable.

### CU-REP-002 — Consultar estado técnico

Actor principal: Soporte técnico.
Precondiciones: Existen registros técnicos.
Flujo: abrir vista técnica; filtrar errores o desconexiones; revisar historial.
Resultado: diagnóstico técnico disponible.

## Casos del sistema completo o sujetos a validación

### CU-TAG-003 — Reponer TAG por pérdida

Actor principal: Administrador funcional.
Precondiciones: Existe un TAG reportado como perdido.
Flujo: desactivar TAG anterior; registrar nuevo TAG; reasociar usuario y vehículo.
Resultado: nueva credencial operativa.
Pendiente: política institucional y tratamiento financiero de la reposición.

### CU-PER-001 — Configurar y publicar periodo

Actor principal: Administrador funcional.
Precondiciones: Existen fechas y prioridades aprobadas.
Flujo: registrar periodo; cargar parámetros; publicar.
Resultado: periodo disponible para solicitudes.
Pendiente: fechas y prioridades institucionales.

### CU-PER-002 — Presentar solicitud

Actor principal: Usuario institucional.
Precondiciones: Existe periodo habilitado.
Flujo: iniciar sesión; seleccionar vehículo; presentar solicitud.
Resultado: solicitud en revisión.

### CU-PAG-001 — Revisar pago institucional

Actor principal: Analista financiero.
Precondiciones: Existe solicitud con comprobante.
Flujo: abrir bandeja; verificar comprobante; aprobar o rechazar; registrar observación.
Resultado: solicitud con estado financiero actualizado.
Pendiente: reglas financieras, tarifas e integración aprobadas.

### CU-VIS-001 — Registrar visitante

Actor principal: Operador de garita.
Precondiciones: Reglas de visitantes definidas.
Flujo: capturar identificación y vehículo; registrar motivo y anfitrión; guardar visita.
Resultado: visita lista para autorización.
Pendiente: reglamento de visitantes.

### CU-VIS-002 — Autorizar salida de visitante

Actor principal: Operador de garita.
Precondiciones: Existe visita activa.
Flujo: consultar visita; validar permanencia o pago si aplica; registrar salida.
Resultado: cierre de visita auditable.
Pendiente: reglas de visitantes y tratamiento financiero.

## Caso fuera del alcance activo

`CU_Sanciones.md` se historiza. El catálogo de sanciones no pertenece al alcance funcional propio documentado para esta fase y no debe tratarse como caso activo.

## Dependencias de trazabilidad

La relación con requisitos, reglas, procesos, vistas, historias y pruebas se mantiene en `Matriz_Trazabilidad_Requisitos.md`. Los `CP-*` siguen siendo identificadores previstos: mientras no exista el artefacto correspondiente en `06_Pruebas/Casos_Prueba/`, el estado es `Pendiente de materialización`.
