# Informe Técnico UX/UI del Módulo de Garita

**Código documental:** CP-UX-TEC-001  
**Versión:** 2.0  
**Estado:** Documento estabilizado para referencia técnica local  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre insumos existentes del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 2.0 | 2026-07-17 | Ajusta nombre oficial, separa prototipo del sistema completo y marca validaciones técnicas pendientes del hardware. |
| 1.x | 2026-04 | Versiones previas con referencia a InBIO 206 y mezcla de alcance implementado y futuro. |

## 1. Propósito

Documentar el enfoque de interfaz y experiencia de usuario del módulo local de garita del prototipo actual de Cato Parking, sin extender su alcance a la totalidad del sistema institucional.

## 2. Alcance del documento

Este informe describe únicamente:

- la operación local del módulo de garita;
- la interacción básica con eventos RFID y apertura manual;
- las consideraciones de interfaz mínimas observables en el prototipo.

No documenta como implementados:

- Microsoft SSO;
- plataforma web institucional;
- pagos, sanciones o reportes avanzados;
- sincronización productiva completa con SQL Server.

## 3. Identidad del proyecto

- **Nombre público vigente:** Cato Parking.
- **Nombre técnico vigente:** Sistema Institucional de Gestión de Parqueaderos Cato Parking.
- **Institución:** PUCESA.

## 4. Consideraciones técnicas de hardware

- **Controlador objetivo aprobado documentalmente:** ZKTeco InBIO 260.
- **Estado de validación técnica detallada:** pendiente.

Las siguientes afirmaciones deben tratarse como información técnica preliminar u observada en el prototipo, no como validación definitiva del hardware objetivo:

- correspondencia exacta entre `Reader 1` y entrada;
- correspondencia exacta entre `Reader 4` y salida;
- semántica exacta de `E0`, `E20` y `E27`;
- uso operativo de `LOCK 1` y `LOCK 2`;
- compatibilidad exacta de `plcommpro.dll` y `pltcpcomm.dll` con la instalación definitiva del InBIO 260.

## 5. Lineamientos UI/UX consolidados

- la interfaz de garita debe priorizar claridad operativa y velocidad de lectura;
- la vista principal debe exponer estado de conexión, eventos recientes y acciones manuales permitidas;
- la apertura manual debe requerir motivo obligatorio;
- los mensajes deben distinguir entre autorización, denegación, advertencia técnica y error de comunicación;
- la gestión básica de TAG debe mantenerse separada de módulos futuros no implementados.

## 6. Relación con el MVP

Este informe se alinea con el MVP solo en lo relativo a:

- configuración local;
- monitoreo de accesos;
- gestión básica de TAG;
- apertura manual;
- visualización de eventos.

## 7. Observación documental

La versión histórica de este informe referenciaba `InBIO 206`. Esa referencia se registra como inconsistencia documental corregida conceptualmente en la fase de estabilización.
