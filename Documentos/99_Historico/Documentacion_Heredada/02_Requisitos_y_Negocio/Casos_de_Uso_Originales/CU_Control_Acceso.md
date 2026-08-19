# Casos de Uso de Control de Acceso

## CU-ACC-001 - Validar acceso local

Actor principal: Aplicacion local de garita.  
Precondiciones: Controlador conectado y datos locales cargados.  
Flujo:
1. Recibir lectura.
2. Consultar TAG.
3. Validar estado.
4. Autorizar o denegar.
5. Registrar evento.
Resultado: Decision de acceso auditable.

## CU-ACC-002 - Autorizar entrada o salida

Actor principal: Aplicacion local de garita.  
Precondiciones: Existe una decision autorizada.  
Flujo:
1. Determinar punto de acceso.
2. Enviar orden al controlador.
3. Confirmar registro del evento.
Resultado: Apertura ejecutada y registrada.

## CU-ACC-003 - Apertura manual justificada

Actor principal: Operador de garita.  
Precondiciones: Permiso de apertura manual.  
Flujo:
1. Seleccionar acceso.
2. Registrar motivo.
3. Confirmar accion.
4. Enviar orden.
Resultado: Apertura manual auditable.

## CU-ACC-004 - Consultar eventos de acceso

Actor principal: Operador de garita.  
Precondiciones: Existen eventos registrados.  
Flujo:
1. Abrir vista de monitoreo.
2. Filtrar eventos.
3. Revisar detalle.
Resultado: Consulta de historial operativo.

## CU-ACC-005 - Recuperar comunicacion tecnica

Actor principal: Soporte tecnico.  
Precondiciones: Existe una desconexion o error.  
Flujo:
1. Detectar estado.
2. Reintentar conexion.
3. Registrar exito o fallo.
Resultado: Estado tecnico actualizado.

## CU-ACC-006 - Operar en contingencia local

Actor principal: Aplicacion local de garita.  
Precondiciones: Servicios centrales no disponibles.  
Flujo:
1. Continuar validando con datos locales.
2. Registrar eventos pendientes.
3. Marcar sincronizacion futura.
Resultado: Continuidad operativa local.
