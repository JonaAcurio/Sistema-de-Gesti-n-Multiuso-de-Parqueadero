# Catalogo de Componentes

**Codigo documental:** CP-ARQ-304  
**Version:** 1.0  
**Fecha:** 2026-07-18

## COM-GAR-001

Nombre: UI de Operacion  
Responsabilidad: Exponer monitoreo, comandos y estados visuales sin contener reglas de acceso.  
Entradas: eventos procesados, estado de hardware, comandos del operador.  
Salidas: solicitudes de accion, filtros, confirmaciones.  
Dependencias: coordinador de casos de uso.  
Requisitos relacionados: RF-GAR-001, RF-AUD-001.  
Estado: Propuesto.

## COM-GAR-002

Nombre: Coordinador de Casos de Uso  
Responsabilidad: Orquestar lectura, validacion, persistencia, apertura y sincronizacion.  
Entradas: lecturas RFID, acciones del operador, estados del adaptador.  
Salidas: decisiones, comandos, eventos y reintentos.  
Dependencias: motor de autorizacion, repositorio local, adaptador InBIO.  
Requisitos relacionados: RF-ACC-001, RF-ACC-002, RF-SIN-001.  
Estado: Propuesto.

## COM-GAR-003

Nombre: Motor de Autorizacion Operativa  
Responsabilidad: Evaluar estado local de TAG, usuario, vehiculo, vigencia y reglas locales.  
Entradas: lectura normalizada, cache local.  
Salidas: autorizado, denegado, motivo.  
Dependencias: repositorio local.  
Requisitos relacionados: RF-ACC-001, RF-ACC-004, RF-ACC-005.  
Estado: Propuesto.

## COM-GAR-004

Nombre: Adaptador InBIO 260  
Responsabilidad: Establecer y mantener comunicacion con el controlador.  
Entradas: eventos del dispositivo, ordenes de control, configuracion de red.  
Salidas: lectura normalizada, estado de conexion, resultado de comandos, errores tecnicos.  
Dependencias: SDK ZKTeco, red local, controlador fisico.  
Requisitos relacionados: RF-CON-001, RF-ACC-002, RF-SIN-002.  
Riesgos: DLL propietaria, firmware, bloqueo de conexion.  
Estado: Propuesto.

## COM-GAR-005

Nombre: Repositorio Local  
Responsabilidad: Persistir cache operativa, configuracion y eventos locales.  
Entradas: cambios de configuracion, altas basicas, accesos, eventos tecnicos.  
Salidas: consultas locales y lotes de sincronizacion.  
Dependencias: base local.  
Requisitos relacionados: RF-USR-001, RF-VEH-001, RF-TAG-001, RF-SIN-001.  
Estado: Propuesto.

## COM-GAR-006

Nombre: Cola Persistente de Sincronizacion  
Responsabilidad: Mantener eventos pendientes hasta confirmacion central.  
Entradas: accesos, aperturas manuales, eventos tecnicos sincronizables.  
Salidas: lotes para envio y estados de sincronizacion.  
Dependencias: repositorio local, cliente API.  
Requisitos relacionados: RF-SIN-001, RF-SIN-002.  
Estado: Propuesto.

## COM-GAR-007

Nombre: Cliente API de Sincronizacion  
Responsabilidad: Intercambiar cambios con la API central usando contratos versionados.  
Entradas: eventos pendientes, solicitud de cambios, configuracion.  
Salidas: confirmaciones, novedades, errores y reintentos.  
Dependencias: red institucional, API central.  
Requisitos relacionados: RF-SIN-001, RF-SIN-002.  
Estado: Propuesto.

## COM-GAR-008

Nombre: Registro Tecnico  
Responsabilidad: Persistir errores, reconexiones, latencias y estados del SDK o de la red.  
Entradas: excepciones, timeouts, cambios de estado.  
Salidas: diagnostico tecnico.  
Dependencias: repositorio local.  
Requisitos relacionados: RF-GAR-002.  
Estado: Propuesto.
