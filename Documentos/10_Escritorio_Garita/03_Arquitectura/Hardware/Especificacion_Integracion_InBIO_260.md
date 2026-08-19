# Especificacion de Integracion InBIO 260

**Codigo documental:** CP-HDW-301  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Identificacion fisica

- Modelo: ZKTeco InBIO 260
- Numero de serie: por validar
- Firmware: por validar
- Ubicacion: garita principal
- IP: por validar
- Puerto: por validar

## SDK y librerias

- `plcommpro.dll`
- `pltcpcomm.dll`
- Arquitectura: por validar segun instalacion
- Origen: librerias ZKTeco usadas en el prototipo
- Limitaciones: dependencia propietaria y validacion formal pendiente

## Eventos a validar

| Codigo | Nombre propuesto | Origen | Datos | Accion esperada | Validacion |
| --- | --- | --- | --- | --- | --- |
| E0 | Acceso concedido | Lector | TAG, puerta, fecha | Procesar | Pendiente |
| E20 | Acceso concedido alterno | Lector | TAG, puerta, fecha | Procesar | Pendiente |
| E27 | Lectura de salida usada por prototipo | Lector | TAG, puerta, fecha | Procesar o ignorar segun contexto | Pendiente |

## Comandos

- apertura de barrera;
- cancelacion o apagado de relay;
- lectura de estado;
- reconexion.

## Estados de conexion

- desconectado
- conectando
- conectado
- degradado
- reconectando
- error

## Inventario documentado

| Elemento | Estado |
| --- | --- |
| Controlador InBIO 260 | Objetivo confirmado |
| Lectores RFID | Por validar mapeo exacto |
| Reles y sensores | Por validar cableado exacto |
| Barrera | Presente en entorno de garita |
| Equipo Windows de garita | Nodo de ejecucion local |
| Red local | Requerida para controlador y API |

## Mapeo de lectores, reles y sensores

| Acceso logico | Dispositivo | Reader | Rele | Sensor | Estado |
| --- | --- | --- | --- | --- | --- |
| Entrada principal | InBIO 260 | Por validar | Por validar | Por validar | Pendiente de validacion tecnica |
| Salida principal | InBIO 260 | Por validar | Por validar | Por validar | Pendiente de validacion tecnica |

## Matriz de eventos y comandos

| Tipo | Codigo o accion | Interpretacion actual | Estado |
| --- | --- | --- | --- |
| Evento | E0 | Acceso concedido usado por el prototipo | Pendiente de validacion |
| Evento | E20 | Variante de acceso concedido usada por el prototipo | Pendiente de validacion |
| Evento | E27 | Lectura utilizada en salida por el prototipo | Pendiente de validacion |
| Comando | LOCK 1 | Pulso asociado a movimiento de barrera | Pendiente de validacion |
| Comando | LOCK 2 | Pulso asociado a movimiento de barrera | Pendiente de validacion |

Los detalles técnicos de eventos, lectores, relés, sensores, firmware, IP, puerto y compatibilidad de DLL permanecen pendientes de validación formal. Las referencias al comportamiento observado del prototipo no fijan la topología final.
