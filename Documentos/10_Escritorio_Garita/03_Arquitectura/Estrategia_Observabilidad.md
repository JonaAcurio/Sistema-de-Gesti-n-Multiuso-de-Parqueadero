# Estrategia de Observabilidad

**Codigo documental:** CP-ARQ-307  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Objetivo

Observar con claridad el estado del hardware, la operacion local y la sincronizacion sin mezclar finalidades.

## Señales minimas

- estado de conexion del InBIO 260;
- ultima lectura recibida;
- latencia lectura a decision;
- tamanio de cola pendiente;
- ultimo intento de sincronizacion;
- errores tecnicos recientes;
- espacio disponible de almacenamiento local.

## Tipos de registro

### Log tecnico

- errores de DLL;
- timeouts;
- reconexiones;
- fallos de API;
- excepciones.

### Log operativo

- accesos autorizados;
- denegaciones;
- aperturas manuales;
- movimientos.

### Auditoria

- acciones humanas criticas;
- cambios de configuracion;
- cambio de estados;
- anulaciones o correcciones.

## Visualizacion local

La UI debe exponer un panel tecnico resumido y un panel operativo separado.
