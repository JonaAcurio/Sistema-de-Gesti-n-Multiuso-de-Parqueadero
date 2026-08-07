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
