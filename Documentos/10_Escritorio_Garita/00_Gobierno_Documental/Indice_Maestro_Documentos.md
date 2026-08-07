# Indice Maestro de Documentos

**Codigo documental:** CP-GOB-004  
**Version:** 1.2  
**Estado:** Borrador controlado  
**Fecha:** 2026-07-18

## Objetivo

Concentrar la estructura documental activa de la aplicacion de escritorio de garita y separar expresamente los documentos historicos de los vigentes.

## Regla de alcance

- Esta carpeta documenta solo la parte de escritorio de garita.
- La documentacion de la plataforma web debe mantenerse en una estructura independiente.

## Documentos vigentes

| Area | Documento | Estado | Observacion |
| --- | --- | --- | --- |
| Gobierno | Identidad_y_Denominacion_Oficial.md | Vigente | Fuente oficial de nombre y denominacion. |
| Gobierno | Registro_Decisiones.md | Vigente | Base para fuentes y estados. |
| Gobierno | Glosario_Cato_Parking.md | Vigente | Fuente terminologica de Fase 2. |
| Gobierno | Indice_Maestro_Documentos.md | Vigente | Este documento. |
| Gestion | Definicion_MVP.md | Vigente | Define el alcance minimo del escritorio. |
| Gestion | Vision_Sistema_Completo.md | Vigente | Solo se conserva como frontera de integracion con la plataforma central. |
| Gestion | Registro_Stakeholders.md | Vigente | Identifica stakeholders. |
| Gestion | Matriz_RACI_Inicial.md | Vigente | Gobierno preliminar. |
| Gestion | Plan_Fase_2_Documentacion_Funcional.md | Vigente | Orden y control de la fase. |
| Gestion | Backlog_Proyecto.md | Vigente | Seguimiento de trabajo. |
| Gestion | Estado_Entregables.md | Vigente | Estado consolidado de salida. |
| Gestion | Registro_Inconsistencias_Documentales.md | Vigente | Control de contradicciones. |
| Gestion | Preguntas_Pendientes_PUCESA.md | Vigente | Pendientes institucionales. |
| Requisitos | ERS_Cato_Parking.md | Vigente | ERS formal de referencia. |
| Requisitos | Catalogo_Reglas_Negocio.md | Vigente | Politicas separadas de requisitos. |
| Requisitos | Catalogo_Actores_y_Perfiles.md | Vigente | Catalogo formal de actores y perfiles. |
| Requisitos | Matriz_Roles_Permisos.md | Vigente | Matriz preliminar de permisos. |
| Requisitos | Requisitos_No_Funcionales.md | Vigente | Catalogo medible de RNF. |
| Requisitos | Backlog_Funcional.md | Vigente | Capa de planificacion funcional. |
| Requisitos | Matriz_Trazabilidad_Requisitos.md | Vigente | Trazabilidad integral. |
| Requisitos | Procesos_BPMN/*.md | Vigente | Modelos editables de procesos. |
| Requisitos | Casos_de_Uso/*.md | Vigente | Catalogo de interacciones. |
| UX/UI | Arquitectura_Informacion.md | Vigente | Organizacion por tareas. |
| UX/UI | Mapa_Navegacion.md | Vigente | Relacion entre vistas. |
| UX/UI | Flujos_por_Rol.md | Vigente | Flujos operativos por actor. |
| UX/UI | Inventario_Vistas.md | Vigente | Inventario de vistas y estados. |
| UX/UI | Estados_y_Mensajes.md | Vigente | Comportamientos de feedback. |
| Arquitectura | 03_Arquitectura/*.md | Vigente | Arquitectura tecnica del escritorio de garita. |
| Arquitectura | 03_Arquitectura/C4/*.md | Vigente | Vistas C4 de referencia. |
| Arquitectura | 03_Arquitectura/ADR/*.md | Vigente | Decisiones arquitectonicas. |
| Arquitectura | 03_Arquitectura/Hardware/*.md | Vigente | Integracion con InBIO 260 y hardware asociado. |
| Arquitectura | 03_Arquitectura/Integraciones/* | Vigente | Contratos y fronteras de integracion. |
| Arquitectura | 03_Arquitectura/Seguridad/* | Vigente | Modelo de seguridad local y de integracion. |
| Arquitectura | 03_Arquitectura/Despliegue/* | Vigente | Ambientes e infraestructura del escritorio. |
| Arquitectura | 03_Arquitectura/Pruebas_Arquitectura/* | Vigente | Evidencia y plan tecnico de validacion. |
| Datos | 04_Datos/* | Vigente | Modelo de datos local y relacion con central. |

## Documentos sustituidos

| Documento anterior | Estado actual | Documento vigente que lo sustituye |
| --- | --- | --- |
| 02_Requisitos_y_Analisis/Plantillas/Plantilla_IEEE830_Parqueadero.md | Sustituido e historico | 10_Escritorio_Garita/02_Requisitos_y_Negocio/ERS_Cato_Parking.md |
| 01_Gestion_Proyecto/Task_List.md | Sustituido e historico | 10_Escritorio_Garita/01_Gestion_Proyecto/Planificacion/Backlog_Proyecto.md |
| 02_Requisitos_y_Analisis/UX_UI/Propuesta_Formularios.md | Sustituido e historico | 10_Escritorio_Garita/05_UX_UI/*.md |

## Regla de mantenimiento

- Ningun documento historico debe usarse como fuente de aprobacion vigente sin enlace expreso desde un documento actual.
- La carpeta `10_Escritorio_Garita` es la fuente oficial para documentacion activa del escritorio.
