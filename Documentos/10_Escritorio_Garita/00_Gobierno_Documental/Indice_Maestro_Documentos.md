# Indice Maestro de Documentos

**Codigo documental:** CP-GOB-004  
**Versión:** 2.0
**Estado:** Índice controlado del corpus activo
**Fecha:** 2026-08-18

## Objetivo

Concentrar la estructura documental activa de la aplicación de escritorio de garita y separar expresamente los documentos históricos de los vigentes.

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
| Gobierno | Este índice | Vigente | Punto de navegación del corpus activo. |
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
| Requisitos | Actores_Roles_y_Permisos.md | Borrador controlado | Consolida actores, roles y permisos preliminares. |
| Requisitos | Requisitos_No_Funcionales.md | Vigente | Catalogo medible de RNF. |
| Requisitos | Backlog_Funcional.md | Vigente | Capa de planificacion funcional. |
| Requisitos | Matriz_Trazabilidad_Requisitos.md | Vigente | Trazabilidad integral. |
| Requisitos | Catalogo_Casos_de_Uso.md | Borrador controlado | Consolida los casos de uso y separa MVP de sistema completo. |
| Requisitos | Modelo_Procesos_Cato_Parking.md | Modelo textual para validación | Sustituye la carpeta mal denominada `Procesos_BPMN`; no contiene BPMN formal. |
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
| Datos | Modelo_Datos_Cato_Parking.md | Modelo para validación | Consolida modelo conceptual, local, lógico, estados, integridad y migraciones. |
| Pruebas | 06_Pruebas/README.md | Vigente | Define la estructura y regla de materializacion de casos de prueba. |
| Pruebas | 06_Pruebas/Casos_Prueba/* | Pendiente de materialización | Los `CP-*` reservados no son evidencia mientras no exista cada artefacto. |
| Pruebas | 06_Pruebas/Evidencias/* | Pendiente de materialización | La carpeta no contiene evidencia ejecutada. |
| Pruebas | 06_Pruebas/Matriz_Resultados_Pruebas.md | Vigente | Seguimiento de definicion, ejecucion y evidencia de `CP-*`. |

## Documentos sustituidos

| Documento anterior | Estado actual | Documento vigente que lo sustituye |
| --- | --- | --- |
| Documentos/01_Gestion_Proyecto/*.md heredados | Historizar | 99_Historico/Documentacion_Heredada/ |
| Documentos/02_Requisitos_y_Analisis/*.md heredados | Historizar | 99_Historico/Documentacion_Heredada/ |
| 10_Escritorio_Garita/02_Requisitos_y_Negocio/Casos_de_Uso/* | Consolidado e historizado | Catalogo_Casos_de_Uso.md |
| 10_Escritorio_Garita/02_Requisitos_y_Negocio/Procesos_BPMN/* | Consolidado e historizado | Modelo_Procesos_Cato_Parking.md |
| 10_Escritorio_Garita/02_Requisitos_y_Negocio/Catalogo_Actores_y_Perfiles.md + Matriz_Roles_Permisos.md | Combinados | Actores_Roles_y_Permisos.md |
| 10_Escritorio_Garita/04_Datos/* | Consolidado | Modelo_Datos_Cato_Parking.md |

## Regla de mantenimiento

- Ningún documento histórico debe usarse como fuente de aprobación vigente.
- La carpeta `10_Escritorio_Garita` es la fuente oficial para documentación activa del escritorio.
- Los documentos activos en borrador, propuestos o pendientes requieren validación según corresponda.
- Una carpeta reservada, un README o un identificador `CP-*` no constituye evidencia de implementación o ejecución.
- Los artefactos no Markdown heredados se mantienen fuera de este índice normativo y se describen como pendientes en `Context_Codex.md`.
