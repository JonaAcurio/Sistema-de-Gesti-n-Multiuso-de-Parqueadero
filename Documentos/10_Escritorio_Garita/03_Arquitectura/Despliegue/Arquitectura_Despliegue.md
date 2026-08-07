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
