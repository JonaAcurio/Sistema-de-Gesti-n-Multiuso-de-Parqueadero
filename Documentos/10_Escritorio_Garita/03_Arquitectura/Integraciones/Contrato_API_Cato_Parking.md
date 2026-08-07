# Contrato API Cato Parking para Garita

**Codigo documental:** CP-INT-301  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Alcance

Contrato minimo para integracion entre la garita y la plataforma central.

## Endpoints iniciales

| Metodo | Ruta | Uso |
| --- | --- | --- |
| POST | /sync/eventos | Enviar eventos originados en garita |
| GET | /sync/cambios | Obtener cambios operativos aplicables a la garita |
| POST | /sync/confirmaciones | Confirmar lotes procesados localmente |
| GET | /sync/configuracion | Obtener configuracion operativa vigente |

## Reglas comunes

- autenticacion tecnica por dispositivo;
- versionado de API;
- respuesta idempotente por `evento_id`;
- errores distinguibles entre reintentables y permanentes.
