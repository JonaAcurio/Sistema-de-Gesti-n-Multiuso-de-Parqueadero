# Registro de Inconsistencias Documentales

**Código documental:** CP-CTL-001  
**Versión:** 2.0
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-08-18
**Autor:** Codex sobre insumos existentes del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 1.1 | 2026-08-10 | Actualiza estados tras el saneamiento de trazabilidad, navegación y consistencia documental. |
| 1.0 | 2026-07-17 | Registro inicial de contradicciones y acciones de estabilización. |

## 1. Matriz de inconsistencias

| ID | Inconsistencia | Evidencia principal | Estado actual | Acción aplicada | Documento afectado |
| --- | --- | --- | --- | --- | --- |
| INC-001 | InBIO 206 versus InBIO 260 | README anterior, informe UX/UI y referencias en código | Abierta con corrección conceptual | Se fija InBIO 260 como decisión aprobada; detalles técnicos específicos quedan pendientes de validación | README; informes UX/UI; registro de decisiones |
| INC-002 | 600 TAG versus 1.000 TAG | SRS previa y otros documentos de alcance | Corregida conceptualmente | Se fija 1.000 TAG como cifra oficial de planificación | README; SRS; formularios |
| INC-003 | Múltiples nombres del sistema | README e informes históricos | Corregida conceptualmente | Se consolida Cato Parking como nombre oficial y se dejan los demás como históricos | README; identidad oficial |
| INC-004 | SRS marcada como validada con campos pendientes y datos personales no controlados | Plantilla IEEE 830 anterior | Corregida parcialmente | Se reescribe la base SRS en modo estabilizado y se eliminan afirmaciones no consolidadas y contactos nominales | SRS |
| INC-005 | Stakeholders incompletos o mezclados con personas no confirmadas | SRS previa y actas | Corregida | Se crea registro formal por áreas institucionales | Registro de stakeholders |
| INC-006 | Funcionalidades planificadas presentadas como alcance consolidado o implementado | README anterior, SRS previa, formularios, informes RF | Corregida documentalmente | Se separa prototipo actual, MVP y sistema completo; los documentos heredados se marcan como historicos o de referencia | README; MVP; vision; indices; guias |
| INC-007 | Contradicciones entre prototipo local y sistema futuro | README anterior y Task List | Corregida documentalmente | Se documenta que el prototipo usa JSON local y que SQL Server/SSO/web pertenecen a fases posteriores; el backlog vigente sustituye al Task List | README; Backlog_Proyecto; guias |
| INC-008 | Referencias a reglamentos aún no aprobados como si fueran reglas vigentes | SRS previa e informes RF | Corregida parcialmente | Se reclasifican como decisiones pendientes | Registro de decisiones; preguntas pendientes |
| INC-009 | Duplicidad de rutas documentales entre `Actas` y `Actas_de_Reuniones` / `Informes_Tecnicos` | Estructura previa del repositorio | Corregida mediante historizacion | Las fuentes heredadas se movieron a `99_Historico/Documentacion_Heredada/`; el corpus activo queda concentrado en `10_Escritorio_Garita/` | Indice maestro; historico |
| INC-010 | Ausencia local verificable de `Marca_Cato_Parking.docx` | Búsqueda en workspace | Abierta | Se documenta como insumo oficial faltante en el repositorio de trabajo | Identidad oficial; preguntas pendientes |
| INC-011 | Referencias técnicas a Reader 1, Reader 4, E0, E20, E27, LOCK 1 y LOCK 2 tratadas como definitivas | Documentación técnica histórica del prototipo | Abierta con validación técnica pendiente | Se mantienen solo como hipótesis técnicas o comportamiento observado, sin fijar la topología final | Especificación InBIO 260; preguntas pendientes; decisiones |
| INC-012 | SQL heredado confundible con el modelo de datos objetivo | Artefacto SQL y documentación histórica | Abierta como pendiente de clasificación técnica | El SQL se conserva como artefacto no normativo; el modelo activo se gobierna desde `04_Datos/Modelo_Datos_Cato_Parking.md` | Modelo de datos; preguntas pendientes |
| INC-013 | Fragmentación de casos, procesos, actores/permisos, datos, hardware y despliegue | Estructura previa de `10_Escritorio_Garita/` | Corregida mediante consolidación | Se crearon documentos canónicos y se preservaron las fuentes en histórico con equivalencias de identificadores | Índice maestro; documentos consolidados |
| INC-014 | Casos `CP-*` y evidencias reservadas podían interpretarse como pruebas existentes | Matriz de trazabilidad y carpeta de pruebas | Abierta | Se explicita que los identificadores están previstos y que no hay pruebas materializadas ni ejecutadas | Matriz de trazabilidad; pruebas |

## 2. Observaciones

- Este registro no elimina evidencia histórica.
- Toda corrección posterior debe reflejarse también en el historial del documento afectado.
