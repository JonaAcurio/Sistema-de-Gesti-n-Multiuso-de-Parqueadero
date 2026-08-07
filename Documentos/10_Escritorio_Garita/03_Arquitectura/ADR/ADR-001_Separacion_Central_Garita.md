# ADR-001 Separacion plataforma central y aplicacion local

Estado: aceptado  
Fecha: 2026-07-18

## Contexto

La apertura de barrera no puede depender del servidor central ni de la plataforma web.

## Decision

Mantener una aplicacion local de garita separada de la plataforma central.

## Alternativas evaluadas

- cliente delgado dependiente del backend;
- aplicacion totalmente centralizada.

## Consecuencias positivas

- operacion offline;
- menor latencia;
- aislamiento de hardware.

## Consecuencias negativas

- necesidad de sincronizacion;
- mayor complejidad operativa.

## Requisitos relacionados

RF-ACC-001, RF-SIN-001, RNF-OFF-001.
