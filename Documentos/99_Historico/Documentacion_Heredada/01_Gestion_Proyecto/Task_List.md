# Task List de Estabilización

> Estado actual: documento sustituido para Fase 2.  
> Usar como fuente vigente `Documentos/01_Gestion_Proyecto/Planificacion/Backlog_Proyecto.md` y `Documentos/01_Gestion_Proyecto/Planificacion/Estado_Entregables.md`.  
> Este archivo se conserva como historico y no debe recibir nuevos requisitos funcionales.

**Código documental:** CP-GPR-001  
**Versión:** 2.0  
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre documentación existente del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 2.0 | 2026-07-17 | Reorganiza la lista de trabajo separando prototipo, MVP, sistema completo y pendientes institucionales. |
| 1.x | 2026-03 a 2026-04 | Lista previa con mezcla de estados de implementación y visión futura. |

## 1. Actividades de estabilización documental

- [x] Consolidar identidad oficial de Cato Parking.
- [x] Diferenciar prototipo actual, MVP y sistema completo.
- [x] Crear registro de decisiones, stakeholders e inconsistencias.
- [x] Identificar decisiones pendientes de validación por PUCESA.
- [ ] Confirmar responsables institucionales nominales.
- [ ] Localizar o incorporar la referencia oficial `Marca_Cato_Parking.docx`.
- [ ] Validar técnicamente las referencias específicas del hardware InBIO 260.

## 2. Estado del prototipo actual

| Elemento | Estado | Observación |
| --- | --- | --- |
| Aplicación local de garita en Windows | Implementado en prototipo | Evidencia en código fuente y README estabilizado. |
| Lectura de TAG RFID | Implementado en prototipo | Evidencia en código fuente. |
| Conexión TCP/IP con controladora | Implementado en prototipo | Evidencia en código fuente y documentación técnica histórica. |
| Persistencia local JSON | Implementado en prototipo | No equivale a persistencia central institucional. |
| Apertura manual | Implementado en prototipo | Debe auditarse bajo lineamiento del MVP. |

## 3. Alcance del MVP estabilizado

| ID | Elemento | Estado documental | Observación |
| --- | --- | --- | --- |
| MVP-01 | Aplicación local de garita operativa | Consolidado | Forma parte del MVP. |
| MVP-02 | Conexión estable con InBIO 260 | Consolidado con validación técnica pendiente | El modelo queda fijado; detalles técnicos específicos siguen pendientes. |
| MVP-03 | Lectura RFID en tiempo real | Consolidado | Parte del núcleo mínimo. |
| MVP-04 | Identificación entrada/salida | Consolidado con validación técnica pendiente | Sujeto a topología física. |
| MVP-05 | Registro básico de TAG | Consolidado | Debe mantenerse mínimo y verificable. |
| MVP-06 | Activación/desactivación manual de TAG | Consolidado | Parte del alcance mínimo. |
| MVP-07 | Validación básica de autorización | Consolidado | No incluye motor completo de reglas institucionales. |
| MVP-08 | Apertura automática válida | Consolidado | Parte del control mínimo. |
| MVP-09 | Denegación básica | Consolidado | Parte del control mínimo. |
| MVP-10 | Apertura manual con motivo | Consolidado | Requisito obligatorio. |
| MVP-11 | Registro de intentos de acceso | Consolidado | Debe incluir origen y resultado. |
| MVP-12 | Anti-rebote | Consolidado | Evidencia observada en prototipo. |
| MVP-13 | Eventos técnicos y errores | Consolidado | Mínimo requerido. |
| MVP-14 | Persistencia local funcional | Consolidado | Transición a SQL Server planificada. |
| MVP-15 | Interfaz mínima operativa | Consolidado | Configuración, monitoreo, gestión básica y eventos. |
| MVP-16 | Pruebas físicas documentadas | Pendiente de ejecución formal | Requisito de cierre del MVP. |

## 4. Funcionalidades del sistema completo no incluidas en el MVP

| Tema | Estado documental | Observación |
| --- | --- | --- |
| Microsoft SSO | Previsto para sistema completo | No implementado ni incluido en MVP. |
| Pagos institucionales | Previsto para sistema completo | Pendiente de definición financiera. |
| Facturación | Previsto para sistema completo | Pendiente de validación institucional. |
| Tarifas variables | Previsto para sistema completo | Pendiente de decisión. |
| Visitantes con cobro | Previsto para sistema completo | Pendiente de reglas. |
| Sanciones automáticas | Previsto para sistema completo | Pendiente de reglamento y catálogo. |
| Portal web | Previsto para sistema completo | No operativo en esta fase. |
| Reportes avanzados | Previsto para sistema completo | No operativo en esta fase. |
| Sincronización productiva web-garita | Previsto para sistema completo | No operativo en esta fase. |

## 5. Pendientes institucionales críticos

- definir periodos, prioridades y cupos;
- definir tarifas, reposición de TAG y facturación;
- definir reglamento, sanciones y visitantes;
- definir responsables nominales y aprobadores;
- validar hardware y compatibilidad exacta del controlador.
