# Arquitectura de Despliegue

**Codigo documental:** CP-DPL-301  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Nodos

- equipo Windows de garita;
- controlador InBIO 260;
- red local;
- API central;
- base de datos central;
- almacenamiento de respaldos.

## Ambientes

- desarrollo;
- pruebas;
- preproduccion;
- produccion.

## Dependencias

- .NET en equipo local;
- conectividad local con controlador;
- conectividad saliente a API cuando exista red;
- almacenamiento local persistente.

## Ambientes y actualización

| Ambiente | Propósito |
| --- | --- |
| Desarrollo | Pruebas de cliente y adaptador |
| Pruebas | Validación técnica controlada |
| Preproducción | Validación integrada antes de salida |
| Producción | Operación real en garita |

La estrategia de actualización debe versionar el cliente, respaldar la configuración local antes de actualizar, conservar una ruta de rollback, usar una ventana controlada y verificar después la conectividad, la cola y el hardware. Los detalles de versiones, puertos, respaldos y responsables siguen pendientes de definición institucional o técnica.
