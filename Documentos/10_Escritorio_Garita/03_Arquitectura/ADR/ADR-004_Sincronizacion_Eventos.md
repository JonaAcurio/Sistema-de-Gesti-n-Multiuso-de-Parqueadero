# ADR-004 Sincronizacion basada en eventos

Estado: aceptado  
Fecha: 2026-07-18

## Decision

Sincronizar accesos y cambios operativos mediante eventos con UUID e idempotencia.

## Consecuencias positivas

- reduce duplicados;
- soporta reintentos controlados.

## Consecuencias negativas

- requiere contratos claros y confirmaciones del servidor.
