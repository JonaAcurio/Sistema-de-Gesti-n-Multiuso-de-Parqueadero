# ADR-003 Base local de garita

Estado: aceptado  
Fecha: 2026-07-18

## Decision

La garita mantendra una base local ligera y persistente con cache operativa, configuracion y cola de eventos.

## Alternativas

- solo memoria temporal;
- copia completa de la base central.

## Consecuencias

- se reduce dependencia de red;
- se evita sincronizar todo el modelo institucional.
