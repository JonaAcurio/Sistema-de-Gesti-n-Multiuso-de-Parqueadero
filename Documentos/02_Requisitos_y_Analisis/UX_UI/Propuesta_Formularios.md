# Propuesta de Formularios

> Estado actual: documento sustituido para Fase 2.  
> Las fuentes vigentes son los documentos de `Documentos/05_UX_UI/`.  
> Este archivo se conserva como historico y no debe usarse para derivar vistas antes de procesos, casos de uso y permisos.

**Código documental:** CP-UX-001  
**Versión:** 2.0  
**Estado:** Borrador estabilizado para validación  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre documentación existente del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 2.0 | 2026-07-17 | Reorganiza la propuesta separando prototipo, MVP y sistema completo. |
| 1.x | 2026-03 | Propuesta previa con formularios futuros presentados como cercanos al MVP. |

## 1. Propósito

Establecer una propuesta de formularios coherente con el estado real del proyecto y con la separación entre prototipo actual, MVP y sistema completo.

## 2. Formularios del prototipo actual

| Código | Formulario o vista | Estado | Observación |
| --- | --- | --- | --- |
| FP-01 | Configuración de hardware | Evidencia en prototipo | Base del control local de conexión. |
| FP-02 | Monitoreo de accesos RFID | Evidencia en prototipo | Visualización de eventos en tiempo real. |
| FP-03 | Gestión básica de tarjetas | Evidencia en prototipo | Alta, edición, habilitación y deshabilitación básica. |

## 3. Formularios requeridos para el MVP

| Código | Formulario o vista | Estado documental | Propósito |
| --- | --- | --- | --- |
| FM-01 | Configuración de conexión local | Requerido para MVP | Configurar IP, puerto, timeout y estado del controlador. |
| FM-02 | Panel de monitoreo de accesos | Requerido para MVP | Visualizar intentos de acceso y eventos técnicos. |
| FM-03 | Gestión básica de TAG | Requerido para MVP | Registrar, activar, desactivar y consultar TAG. |
| FM-04 | Registro o edición básica de asociación TAG-usuario-vehículo | Requerido para MVP | Mantener datos mínimos de autorización. |
| FM-05 | Apertura manual con motivo obligatorio | Requerido para MVP | Ejecutar contingencias con trazabilidad. |
| FM-06 | Visualización de eventos y errores técnicos | Requerido para MVP | Apoyar diagnóstico local y pruebas físicas. |

## 4. Formularios previstos para el sistema completo

| Código | Formulario o vista | Estado documental | Observación |
| --- | --- | --- | --- |
| FS-01 | Login institucional con Microsoft SSO | Previsto para sistema completo | No forma parte del MVP. |
| FS-02 | Gestión de usuarios, perfiles y roles | Previsto para sistema completo | Requiere matriz de roles validada. |
| FS-03 | Gestión de parqueaderos | Previsto para sistema completo | Requiere visión multisitio operativa. |
| FS-04 | Gestión de periodos y prioridades | Previsto para sistema completo | Parámetros pendientes de aprobación. |
| FS-05 | Gestión integral de vehículos | Previsto para sistema completo | Reglas finales pendientes. |
| FS-06 | Inventario central de TAG | Previsto para sistema completo | Ciclo de vida completo. |
| FS-07 | Módulo financiero | Previsto para sistema completo | Tarifas y facturación pendientes. |
| FS-08 | Visitantes | Previsto para sistema completo | Reglas pendientes. |
| FS-09 | Sanciones e incidencias | Previsto para sistema completo | Reglamento pendiente. |
| FS-10 | Reportes y auditoría | Previsto para sistema completo | Requiere decisiones institucionales adicionales. |

## 5. Exclusiones del MVP

No deben presentarse como formularios terminados del MVP:

- login SSO;
- recuperación de contraseña institucional;
- gestión completa de tarifas y pagos;
- visitantes con cobro completo;
- sanciones;
- reportes avanzados;
- dashboards administrativos completos;
- aplicación móvil;
- portal web de autoservicio.

## 6. Relación con el modelo de datos

El esquema SQL existente documenta entidades del sistema completo, pero el prototipo actual opera con persistencia local. En consecuencia:

- las pantallas del MVP deben diseñarse para operar con persistencia local verificable;
- la transición a SQL Server debe considerarse una evolución posterior;
- no debe asumirse que todas las entidades del esquema SQL están activas en la aplicación local actual.

## 7. Criterios de calidad documental

- cada formulario debe indicar si pertenece al prototipo, MVP o sistema completo;
- no debe presentarse como implementado ningún formulario sin evidencia en la aplicación actual;
- cualquier detalle financiero, de visitantes o sanciones depende de decisiones pendientes de PUCESA.
