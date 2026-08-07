# ADR-002 Operacion offline

Estado: aceptado  
Fecha: 2026-07-18

## Contexto

La red institucional o internet pueden fallar sin detener la operacion fisica del acceso.

## Decision

Usar cache operativa local y cola persistente de sincronizacion.

## Consecuencias positivas

- continuidad operativa;
- no perdida inmediata de eventos.

## Consecuencias negativas

- conflictos y reenvios;
- necesidad de manejo de reloj y versionado.
