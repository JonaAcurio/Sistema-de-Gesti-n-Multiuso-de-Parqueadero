# Catalogo de Actores y Perfiles

**Codigo documental:** CP-ACT-001  
**Version:** 1.0  
**Estado:** Borrador para validacion institucional  
**Fecha:** 2026-07-17

## Criterio de clasificacion

| Nivel | Definicion |
| --- | --- |
| Stakeholder | Area o interesada institucional que valida o influye. |
| Actor de negocio | Persona o sistema que participa en un proceso. |
| Rol de software | Agrupacion de permisos dentro del sistema. |
| Permiso | Accion puntual autorizable. |

## Actores de negocio

| ID | Nombre | Tipo | Area | Objetivo | Responsabilidades | Restricciones | Estado |
| --- | --- | --- | --- | --- | --- | --- | --- |
| ACT-USR-001 | Usuario institucional | Humano interno | Comunidad universitaria | Solicitar y usar acceso institucional | Gestionar su informacion, solicitud y uso permitido | No configura reglas ni pagos | Pendiente de validacion |
| ACT-GAR-001 | Operador de garita | Humano interno | Seguridad/operacion | Controlar la operacion diaria del acceso | Supervisar eventos, registrar visitantes, apertura manual, incidentes | No modifica tarifas ni roles | Pendiente de validacion |
| ACT-SEG-001 | Personal de seguridad | Humano interno | Seguridad | Gestionar contingencias y evidencias | Monitorear incidentes, validar contingencias, revisar sanciones | No aprueba pagos | Pendiente de validacion |
| ACT-FIN-001 | Analista financiero | Humano interno | Financiero | Revisar transacciones y comprobantes | Aprobar, rechazar y conciliar pagos | No opera la barrera | Pendiente de validacion |
| ACT-ADM-001 | Administrador funcional | Humano interno | Administracion | Configurar reglas funcionales aprobadas | Gestionar periodos, cupos, permisos funcionales y catalogos | No redefine seguridad tecnica | Pendiente de validacion |
| ACT-TEC-001 | Administrador tecnico | Humano interno | TI | Configurar operacion tecnica | Configurar integraciones, conectividad y parametros tecnicos | No aprueba politica funcional | Pendiente de validacion |
| ACT-SOP-001 | Soporte tecnico | Humano interno | Soporte | Diagnosticar y recuperar operacion | Revisar logs, reconectar servicios, escalar fallas | No aprueba reglas institucionales | Pendiente de validacion |
| ACT-VIS-001 | Visitante | Humano externo | Externo | Ingresar temporalmente con autorizacion | Presentar identificacion y motivo | No accede a autoservicio institucional | Pendiente de validacion |
| ACT-SSO-001 | Sistema Microsoft SSO | Sistema externo | TI institucional | Autenticar usuarios del sistema completo | Emitir identidad institucional | No gestiona permisos internos | Pendiente de validacion |
| ACT-GRT-001 | Aplicacion local de garita | Sistema interno | Operacion local | Resolver accesos y registrar eventos | Validar, abrir, denegar, auditar | Opera con datos locales definidos | Pendiente de validacion |
| ACT-WEB-001 | Plataforma web | Sistema interno | Servicios centrales | Exponer autoservicio y administracion ampliada | Periodos, pagos, roles, reportes | No opera directamente hardware local | Pendiente de validacion |
| ACT-HDW-001 | Controlador InBIO 260 | Sistema externo | Hardware | Ejecutar eventos y ordenes fisicas | Leer RFID y recibir ordenes de apertura | Requiere validacion tecnica formal | Pendiente de validacion |
| ACT-SIN-001 | Servicio de sincronizacion | Sistema interno | Integracion | Replicar informacion entre nodos | Encolar, transferir y confirmar datos | Depende de politica de contingencia | Pendiente de validacion |

## Roles de software preliminares

| Rol | Descripcion | Actores compatibles |
| --- | --- | --- |
| USUARIO_INSTITUCIONAL | Perfil de autoservicio y consulta propia | Usuario institucional |
| GARITA | Perfil operativo de acceso y contingencia | Operador de garita |
| SEGURIDAD | Perfil de monitoreo y contingencia | Personal de seguridad |
| FINANCIERO | Perfil de revisiones de pago y conciliacion | Analista financiero |
| ADMIN_FUNCIONAL | Perfil de configuracion funcional | Administrador funcional |
| ADMIN_TECNICO | Perfil de configuracion tecnica | Administrador tecnico |
| SOPORTE_TECNICO | Perfil de diagnostico y recuperacion | Soporte tecnico |

## Permisos preliminares

- CONSULTAR_ACCESOS
- REGISTRAR_TAG
- CAMBIAR_ESTADO_TAG
- ABRIR_MANUALMENTE
- REGISTRAR_VISITANTE
- REGISTRAR_INCIDENTE
- CONFIGURAR_CONEXION
- CONSULTAR_EVENTOS_TECNICOS
- APROBAR_PAGO
- RECHAZAR_PAGO
- CONFIGURAR_PERIODO
- ASIGNAR_ROL
- CONSULTAR_AUDITORIA
