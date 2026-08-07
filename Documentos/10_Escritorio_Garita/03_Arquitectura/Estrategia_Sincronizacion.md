# Estrategia de Sincronizacion

**Codigo documental:** CP-ARQ-306  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Modelo

Sincronizacion basada en eventos y cambios versionados.

## Identidad de eventos

Cada evento generado en garita debe llevar:

- `evento_id` UUID;
- `dispositivo_id`;
- `origen`;
- `fecha_hora_evento`;
- `version`;
- `estado_sync`.

## Estados de la cola

- PENDIENTE
- ENVIANDO
- CONFIRMADO
- ERROR_REINTENTABLE
- ERROR_PERMANENTE
- CONFLICTO

## Flujo

1. El evento nace en garita.
2. Se persiste localmente.
3. Ingresa a cola PENDIENTE.
4. El cliente API intenta enviarlo.
5. El servidor responde confirmacion o conflicto.
6. El estado local se actualiza.

## Idempotencia

El servidor central debe reconocer `evento_id` duplicados y responder sin crear dos accesos.

## Cambios descendentes

La garita consulta:

- operadores habilitados;
- TAG y asociaciones operativas;
- configuracion aplicable;
- estados relevantes para acceso.

No debe descargar toda la base central.
