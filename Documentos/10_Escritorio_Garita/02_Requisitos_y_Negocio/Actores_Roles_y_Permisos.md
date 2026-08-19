# Actores, Roles y Permisos

**Código documental:** CP-ACT-001 / CP-RLP-001 consolidado
**Versión:** 2.0
**Estado:** Borrador para validación institucional
**Fecha:** 2026-08-18

## Propósito y alcance

Este documento consolida el catálogo de actores, los roles de software y la matriz preliminar de permisos. No sustituye la validación institucional de responsables nominales, delegaciones ni reglas de autorización.

La distinción obligatoria es:

| Nivel | Definición |
| --- | --- |
| Stakeholder | Área o parte interesada institucional que valida o influye. Se registra en `Registro_Stakeholders.md`. |
| Actor de negocio | Persona o sistema que participa en un proceso. |
| Rol de software | Agrupación de permisos dentro del sistema. |
| Permiso | Acción puntual autorizable. |

## Actores de negocio

| ID | Nombre | Tipo | Área | Objetivo o responsabilidad | Restricciones | Estado |
| --- | --- | --- | --- | --- | --- | --- |
| ACT-USR-001 | Usuario institucional | Humano interno | Comunidad universitaria | Solicitar y usar acceso institucional | No configura reglas ni pagos | Pendiente de validación |
| ACT-GAR-001 | Operador de garita | Humano interno | Seguridad/operación | Supervisar eventos, registrar visitantes, ejecutar aperturas manuales e incidentes | No modifica tarifas ni roles | Pendiente de validación |
| ACT-SEG-001 | Personal de seguridad | Humano interno | Seguridad | Gestionar contingencias y evidencias | No aprueba pagos | Pendiente de validación |
| ACT-FIN-001 | Analista financiero | Humano interno | Financiero | Revisar, aprobar o rechazar transacciones y comprobantes | No opera la barrera | Pendiente de validación |
| ACT-ADM-001 | Administrador funcional | Humano interno | Administración | Configurar reglas funcionales aprobadas, periodos, cupos y permisos funcionales | No redefine seguridad técnica | Pendiente de validación |
| ACT-TEC-001 | Administrador técnico | Humano interno | TI | Configurar integraciones, conectividad y parámetros técnicos | No aprueba política funcional | Pendiente de validación |
| ACT-SOP-001 | Soporte técnico | Humano interno | Soporte | Diagnosticar y recuperar la operación | No aprueba reglas institucionales | Pendiente de validación |
| ACT-VIS-001 | Visitante | Humano externo | Externo | Ingresar temporalmente con autorización | No accede a autoservicio institucional | Pendiente de validación |
| ACT-SSO-001 | Sistema Microsoft SSO | Sistema externo | TI institucional | Autenticar usuarios del sistema completo | No gestiona permisos internos | Pendiente de validación |
| ACT-GRT-001 | Aplicación local de garita | Sistema interno | Operación local | Resolver accesos y registrar eventos | Opera con datos locales definidos | Pendiente de validación |
| ACT-WEB-001 | Plataforma web | Sistema interno | Servicios centrales | Exponer autoservicio y administración ampliada | No opera directamente el hardware local | Pendiente de validación |
| ACT-HDW-001 | Controlador InBIO 260 | Sistema externo | Hardware | Ejecutar eventos y órdenes físicas | Requiere validación técnica formal | Pendiente de validación |
| ACT-SIN-001 | Servicio de sincronización | Sistema interno | Integración | Replicar información entre nodos | Depende de política de contingencia | Pendiente de validación |

## Roles de software preliminares

| Rol | Descripción | Actores compatibles |
| --- | --- | --- |
| USUARIO_INSTITUCIONAL | Autoservicio y consulta propia | Usuario institucional |
| GARITA | Operación de acceso y contingencia | Operador de garita |
| SEGURIDAD | Monitoreo y contingencia | Personal de seguridad |
| FINANCIERO | Revisión de pagos y conciliación | Analista financiero |
| ADMIN_FUNCIONAL | Configuración funcional | Administrador funcional |
| ADMIN_TECNICO | Configuración técnica | Administrador técnico |
| SOPORTE_TECNICO | Diagnóstico y recuperación | Soporte técnico |

## Permisos preliminares

`CONSULTAR_ACCESOS`, `REGISTRAR_TAG`, `CAMBIAR_ESTADO_TAG`, `ABRIR_MANUALMENTE`, `REGISTRAR_VISITANTE`, `REGISTRAR_INCIDENTE`, `CONFIGURAR_CONEXION`, `CONSULTAR_EVENTOS_TECNICOS`, `APROBAR_PAGO`, `RECHAZAR_PAGO`, `CONFIGURAR_PERIODO`, `ASIGNAR_ROL`, `CONSULTAR_AUDITORIA`.

## Matriz preliminar de permisos

| Funcionalidad o permiso | Admin funcional | Financiero | Garita | Seguridad | Usuario institucional | Soporte técnico | Admin técnico |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Consultar usuario | Sí | No definido | Limitado | Limitado | Propio | No | Limitado |
| Registrar TAG | Sí | No | Sí | No | No | No | No |
| Cambiar estado TAG | Sí | No | Sí | No | No | No | No |
| Consultar accesos | Sí | Parcial | Sí | Sí | Propio | Técnico | Parcial |
| Abrir manualmente | Configurable | No | Sí | Sí | No | Diagnóstico | No |
| Registrar motivo de apertura manual | Sí | No | Sí | Sí | No | Diagnóstico | No |
| Consultar auditoría | Sí | Parcial | Propia | Parcial | No | Técnica | Técnica |
| Consultar eventos técnicos | No | No | Sí | Parcial | No | Sí | Sí |
| Configurar conexión local | No | No | No | No | No | Sí | Sí |
| Reintentar reconexión | No | No | No | No | No | Sí | Sí |
| Aprobar pago | No | Sí | No | No | No | No | No |
| Rechazar pago | No | Sí | No | No | No | No | No |
| Configurar periodo | Sí | No | No | No | No | No | No |
| Asignar rol | Sí | No | No | No | No | No | Sí |
| Exportar reporte | Sí | Parcial | No | Parcial | No | Técnico | Técnico |

## Convenciones y pendientes

- `Configurable` requiere ratificación de PUCESA sobre delegación.
- `Propio` significa acceso exclusivo a datos asociados con el mismo usuario.
- `Técnico` significa acceso orientado a soporte y diagnóstico, no a operación funcional.
- Los responsables nominales, la autoridad de aprobación y la matriz final de permisos siguen pendientes de validación institucional.
- Los permisos de pagos, periodos, visitantes y autoservicio pertenecen al sistema completo o a integraciones futuras; no deben presentarse como capacidad operativa confirmada de la garita.
