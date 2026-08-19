# Informe ejecutivo del saneamiento documental

## 1. Propósito y alcance

Este informe reconstruye la rendición de cuentas del saneamiento documental ya realizado en `Documentos/`. No inicia una nueva auditoría, no modifica ningún archivo dentro de `Documentos/`, no usa el código del repositorio como fuente de verdad y no convierte pendientes en decisiones.

La comparación usa:

- **Antes:** árbol y archivos de `Documentos/` en `HEAD`.
- **Después:** árbol de trabajo actual, incluyendo archivos no rastreados ya preparados por el saneamiento.
- **Criterio:** conteos recursivos de archivos; las carpetas se cuentan cuando están representadas por al menos un archivo. Las rutas históricas se distinguen de los documentos activos.

El estado documental rector utilizado fue `Context_Codex.md`, junto con `AGENTS.md` y `.codex/skills/auditoria-documental-cato-parking/SKILL.md`. El informe queda fuera de `Documentos/` por solicitud expresa.

## 2. Resultado cuantitativo Before → After

| Indicador | Antes (`HEAD`) | Después | Lectura ejecutiva |
|---|---:|---:|---|
| Carpetas representadas por archivos dentro de `Documentos/` | 43 | 62 | La expansión corresponde principalmente a una histórica explícita y a la separación por bloques; los 9 directorios de primer nivel se conservan. |
| Archivos totales | 148 | 152 | El total casi no cambia; el saneamiento fue de estructura, vigencia y trazabilidad, no de acumulación. |
| Markdown total | 122 | 126 | El corpus final contiene 4 Markdown más, pero con una reducción fuerte del activo y una preservación histórica explícita. |
| Markdown activo | 93 | 59 | Se retiraron fragmentos, duplicados y auditorías fechadas de la superficie normativa. |
| Markdown histórico | 4 | 63 | Se preservaron fuentes heredadas, auditorías y fragmentos retirados en `99_Historico/`. |
| Nuevas rutas Markdown | 0 | 63 | 4 son documentos canónicos activos y 59 son rutas históricas nuevas. |
| Nuevos documentos canónicos activos | 0 | 4 | Actores/roles, casos de uso, procesos y modelo de datos. |
| Documentos Markdown llevados a histórico | 0 | 59 | 54 conservan exactamente el contenido binario de una ruta de `HEAD`; 5 fueron reescritos en destino como registro histórico. |
| Grupos de consolidación | 0 | 6 | Los grupos se detallan en la sección 4. |
| Fuentes Markdown involucradas en consolidaciones | 0 | 36 | 2 actores/roles, 9 casos de uso, 10 procesos, 9 fragmentos de datos, 3 de hardware y 3 de despliegue. |
| Markdown sin copia byte a byte en el estado final | 0 | 5 | Corresponden a material redundante, propuesta o índice sustituido; se detallan en la sección 5. |
| Documentos no Markdown eliminados sin copia | 0 | 0 | Los 2 PDF retirados de sus rutas originales reaparecen con el mismo contenido en histórico. |

La diferencia entre “nuevas rutas” y “nuevos documentos” es intencional: una ruta histórica nueva no representa una especificación nueva.

## 3. Estado por carpeta

Los conteos de la tabla son Markdown recursivos dentro de cada alcance. En carpetas de soporte sin Markdown se informa también el estado de los archivos no Markdown.

| Carpeta / alcance | MD antes → después | Estado de auditoría | Resultado del saneamiento | Revisión humana pendiente |
|---|---:|---|---|---|
| `Documentos/` | 122 → 126 | Consolidado | Se estableció `10_Escritorio_Garita/` como superficie activa y `99_Historico/` como repositorio histórico; se corrigieron índices y referencias principales. | Confirmar que la separación activo/histórico sea la convención institucional definitiva. |
| `01_Gestion_Proyecto/` | 16 → 0 | Auditado y historizado | Se retiró la copia heredada de gestión, actas, informes y tareas de la superficie activa. | Decidir si algún informe heredado requiere una recuperación formal como evidencia vigente. |
| `02_Requisitos_y_Analisis/` | 3 → 0 | Auditado y historizado | Se retiraron plantilla, propuesta y análisis heredados; no se presentan como requisitos aprobados. | Confirmar si existe alguna fuente institucional superior no incluida en el corpus. |
| `03_Base_de_Datos/` | 0 → 0 | Revisado como artefacto de soporte | `dbo.sql` permanece sin reinterpretarse; no se lo convirtió en fuente normativa de requisitos o modelo físico aprobado. | Resolver la relación formal entre el modelo documental y el SQL cuando exista decisión institucional. |
| `04_Desarrollo/` | 4 → 4 | Revisado como soporte no normativo | Se conservaron guías de desarrollo; la guía de errores quedó explícitamente fuera de la fuente normativa documental. | Ninguna decisión de saneamiento inmediata; solo revisar si se quiere mantenerla en el corpus documental. |
| `10_Escritorio_Garita/` | 93 → 59 | Auditado y reconstruido como activo | Se redujeron fragmentos y se mantuvieron documentos canónicos, gobierno, arquitectura, UX/UI y pruebas. | Validar el alcance operativo y los pendientes institucionales listados en `Context_Codex.md`. |
| `10/.../00_Gobierno_Documental/` | 4 → 4 | Auditado | Se mantuvieron glosario, identidad, índice maestro y registro de decisiones; el índice refleja la arquitectura final. | Confirmar responsables y autoridad de aprobación del registro de decisiones. |
| `10/.../01_Gestion_Proyecto/` | 11 → 9 | Auditado | Se historizaron dos auditorías fechadas y se actualizaron planificación, entregables, preguntas e inconsistencias. | Resolver las preguntas abiertas y cerrar las inconsistencias que requieran decisión institucional. |
| `10/.../02_Requisitos_y_Negocio/` | 26 → 8 | Auditado y consolidado | Se reemplazaron fragmentos de actores, casos y procesos por catálogos/modelos canónicos; se ajustaron reglas, ERS, RNF y trazabilidad. | Aprobar actores, reglas, alcance, casos y procesos; confirmar el tratamiento de sanciones y elementos pendientes. |
| `10/.../03_Arquitectura/` | 33 → 27 | Auditado y consolidado | Se consolidaron hardware y despliegue; se conservaron ADR, C4, seguridad, integraciones, operación offline y sincronización. | Validar hardware, contratos de integración, operación offline/sincronización y necesidad de diagramas formales. |
| `10/.../04_Datos/` | 9 → 1 | Auditado y consolidado | Los fragmentos conceptuales, lógicos, locales, reglas y migraciones se concentraron en `Modelo_Datos_Cato_Parking.md`. | Aprobar el modelo físico, sus relaciones con `dbo.sql` y las reglas de integridad institucionales. |
| `10/.../05_UX_UI/` | 5 → 5 | Auditado | Se conservaron los documentos complementarios y se alinearon flujos, estados, vistas y navegación con el alcance vigente. | Validar flujos por rol, mensajes y criterios de aceptación de la experiencia. |
| `10/.../06_Pruebas/` | 4 → 4 | Auditado | La matriz y los README se conservaron como estructura de pruebas; no se presentaron placeholders como evidencia ejecutada. | Proporcionar o aprobar casos de prueba, resultados y evidencias reales. |
| `99_Historico/` | 4 → 63 | Auditado y reorganizado | Se separaron auditorías, documentación preestabilización, heredada, fragmentos e índices desplazados; los históricos no compiten con el activo. | Confirmar la política de retención y si los cinco documentos reescritos deben conservar una copia literal adicional. |
| `06_Gráficos/` | 0 → 0 | Sin cambios de contenido | Se conservaron 8 imágenes de soporte; no se usaron como evidencia de requisitos o implementación. | Ninguna decisión derivada del saneamiento Markdown. |
| `Imagenes/` | 0 → 0 | Sin cambios de contenido | Se conservaron 5 imágenes de soporte. | Ninguna decisión derivada del saneamiento Markdown. |
| `PDF/` | 0 → 0 | Sin cambios de contenido | Se conservaron 9 PDF; los 2 PDF de carpetas heredadas trasladados a histórico mantienen su contenido. | Confirmar si algún PDF debe tener una clasificación documental vigente distinta. |

### Hallazgos ejecutivos por bloque

- **Gobierno y raíz:** existían índices y guías competidores; se dejó un índice maestro activo y se movieron los índices heredados a histórico.
- **Gestión:** había material fechado y duplicado que podía confundirse con el estado actual; quedó fuera de la superficie activa y se conservaron preguntas e inconsistencias explícitas.
- **Requisitos y negocio:** actores, roles, permisos, casos de uso y procesos estaban fragmentados; quedaron en cuatro documentos canónicos, sin convertir propuestas o supuestos en aprobaciones.
- **Arquitectura:** hardware y despliegue estaban repartidos en fragmentos; se concentraron en sus documentos de arquitectura correspondientes, manteniendo pendientes de validación.
- **Datos:** los nueve fragmentos no formaban una fuente única; se consolidaron en un modelo documental y se dejó pendiente la aprobación física y su relación normativa con SQL.
- **UX/UI:** el bloque era compacto y se conservó; se ajustaron referencias semánticas sin inventar criterios de aceptación.
- **Pruebas:** la estructura existe, pero los README y la matriz no se trataron como resultados ejecutados; faltan casos/evidencias verificables.
- **Histórico:** las fuentes se preservaron fuera de la superficie activa, incluyendo documentos heredados, auditorías y fragmentos desplazados.

## 4. Mapa de consolidaciones y reemplazos

| Grupo | Fuentes retiradas de activo | Destino canónico / decisión | Resultado |
|---|---|---|---|
| Actores, roles y permisos | `Catalogo_Actores_y_Perfiles.md` + `Matriz_Roles_Permisos.md` | `10/.../02_Requisitos_y_Negocio/Actores_Roles_y_Permisos.md` | Una vista única; originales preservados en `99_Historico/.../Actores_Roles_Originales/`. |
| Casos de uso | 8 casos + `Indice_Casos_Uso.md` | `10/.../02_Requisitos_y_Negocio/Catalogo_Casos_de_Uso.md` | Catálogo activo único; originales preservados en `Casos_de_Uso_Originales/`. |
| Procesos | `PR-01` a `PR-10` | `10/.../02_Requisitos_y_Negocio/Modelo_Procesos_Cato_Parking.md` | Modelo consolidado; se retiró el uso impropio de “BPMN” para documentos que no contienen BPMN real. |
| Datos | 9 fragmentos de modelo, diccionario, estados, integridad, migraciones y README | `10/.../04_Datos/Modelo_Datos_Cato_Parking.md` | Fuente documental única del modelo; fragmentos preservados en `04_Datos_Fragmentados/`. |
| Hardware | `Inventario_Hardware.md`, `Mapeo_Lectores_Reles_Sensores.md`, `Matriz_Eventos_Comandos.md` | `10/.../03_Arquitectura/Hardware/Especificacion_Integracion_InBIO_260.md` | Se eliminó la dispersión; no se cerraron valores no soportados. |
| Despliegue | `Estrategia_Actualizacion.md`, `Matriz_Ambientes.md`, `Requisitos_Infraestructura.md` | `10/.../03_Arquitectura/Despliegue/Arquitectura_Despliegue.md` | Se concentró la arquitectura de despliegue; la validación institucional sigue pendiente. |

Además, las copias heredadas de `01_Gestion_Proyecto/`, `02_Requisitos_y_Analisis/`, los índices raíz y las auditorías fechadas se retiraron de sus ubicaciones activas y se organizaron en histórico. Esto es un saneamiento de ubicación y vigencia, no una aprobación del contenido heredado.

## 5. Cambios importantes de significado y contenido

| Área | Antes | Después | Motivo |
|---|---|---|---|
| Vigencia documental | El material heredado coexistía con el activo y podía leerse como vigente. | `10_Escritorio_Garita/` es el activo y `99_Historico/` conserva fuentes retiradas. | Separar estado actual de antecedentes sin perder trazabilidad. |
| Actores y permisos | Dos documentos con solapamiento y terminología no unificada. | Un catálogo canónico, con pendientes de validación institucional. | Evitar lecturas divergentes de roles y permisos. |
| Casos de uso | Casos separados, índice y fragmentos con distinto nivel de suficiencia. | Catálogo único y equivalencias históricas. | Restituir navegación y trazabilidad semántica. |
| Procesos | Carpeta llamada `Procesos_BPMN` aunque los Markdown no eran BPMN real. | Modelo de procesos descriptivo sin atribuirle formalidad BPMN. | Corregir la taxonomía sin inventar diagramas. |
| Datos | Modelo central, local, conceptual, lógico, diccionario y reglas separados. | Modelo documental consolidado; SQL permanece como artefacto no reinterpretado. | Tener una fuente documental única y dejar explícito el pendiente físico. |
| Hardware y despliegue | Fragmentos separados con referencias cruzadas débiles. | Especificación de integración y arquitectura de despliegue canónicas. | Reducir duplicación y recuperar trazabilidad. |
| Pruebas | README, matriz y carpetas podían sugerir más evidencia de la disponible. | Estructura de pruebas separada de resultados ejecutados; faltan evidencias reales. | Evitar presentar placeholders como pruebas. |
| Índices | Existían índice maestro, guía e índice heredado en ubicaciones competidoras. | Un índice maestro activo; índices antiguos en histórico. | Evitar rutas contradictorias y mejorar navegación. |

## 6. Clasificación de la documentación activa

La clasificación es de gobierno documental: **A** es fuente normativa o de decisión, **B** es soporte necesario para operar, diseñar o verificar, y **C** es contexto, guía, plantilla o soporte no normativo. No implica aprobación institucional.

### Nivel A — fuente normativa o de decisión (8 documentos)

1. `10/.../02_Requisitos_y_Negocio/ERS_Cato_Parking.md`: concentra el marco de requisitos funcionales y alcance que debe gobernar las derivaciones.
2. `10/.../02_Requisitos_y_Negocio/Catalogo_Reglas_Negocio.md`: concentra las reglas de negocio documentadas y sus pendientes de resolución.
3. `10/.../02_Requisitos_y_Negocio/Actores_Roles_y_Permisos.md`: establece la vista única de actores, roles y permisos documentados.
4. `10/.../02_Requisitos_y_Negocio/Catalogo_Casos_de_Uso.md`: concentra la relación activa de casos de uso y evita que los fragmentos históricos compitan.
5. `10/.../02_Requisitos_y_Negocio/Modelo_Procesos_Cato_Parking.md`: ofrece el modelo vigente de procesos sin presentarlo como BPMN formal.
6. `10/.../03_Arquitectura/Documento_Arquitectura_Escritorio_Garita.md`: funciona como documento arquitectónico integrador del alcance de la solución.
7. `10/.../04_Datos/Modelo_Datos_Cato_Parking.md`: reúne el modelo documental de datos y sus pendientes de validación física.
8. `10/.../02_Requisitos_y_Negocio/Matriz_Trazabilidad_Requisitos.md`: conecta requisitos con artefactos y deja visibles las brechas de cobertura.

### Nivel B — soporte operativo, técnico o de verificación

- Gobierno: `Glosario_Cato_Parking.md`, `Identidad_y_Denominacion_Oficial.md`, `Indice_Maestro_Documentos.md` y `Registro_Decisiones.md`.
- Gestión: alcance, visión, backlog, estado de entregables, plan de fase, stakeholders, preguntas e inconsistencias.
- Requisitos: `Backlog_Funcional.md` y `Requisitos_No_Funcionales.md`.
- Arquitectura: ADR, C4, catálogo de componentes, estrategias offline/sincronización/observabilidad, integraciones, seguridad, hardware, despliegue y pruebas arquitectónicas.
- UX/UI: arquitectura de información, estados y mensajes, flujos por rol, inventario de vistas y mapa de navegación.
- Pruebas: README, matriz de resultados y carpetas de casos/evidencias, mientras no existan resultados ejecutados verificables.

### Nivel C — contexto o soporte no normativo

- Guías de `04_Desarrollo/`.
- README estructurales de pruebas y documentos históricos que aparecen únicamente bajo `99_Historico/`.
- Imágenes, PDF y demás artefactos auxiliares que no constituyen por sí mismos aprobación, requisito, prueba o decisión.

## 7. Qué debe revisar Jonathan

| # | Decisión humana requerida | Por qué | Documentos afectados | Consecuencia si queda pendiente |
|---:|---|---|---|---|
| 1 | Aprobar actores, roles y permisos institucionales. | El catálogo consolida el corpus, pero no puede sustituir la autoridad institucional. | `Actores_Roles_y_Permisos.md`, `Flujos_por_Rol.md`, ERS. | Casos, UX y seguridad no tendrán una base definitiva. |
| 2 | Confirmar el alcance funcional y del MVP. | El saneamiento ordena fuentes, pero no decide prioridades de negocio. | `Definicion_MVP.md`, `Vision_Sistema_Completo.md`, `ERS_Cato_Parking.md`, backlog. | Trazabilidad y planificación seguirán marcadas como sujetas a validación. |
| 3 | Resolver reglas de negocio abiertas o contradictorias. | No existe una fuente documental superior para cerrarlas automáticamente. | `Catalogo_Reglas_Negocio.md`, ERS, matriz de trazabilidad. | No se puede afirmar comportamiento normativo en esos puntos. |
| 4 | Confirmar el catálogo de casos de uso y el tratamiento de sanciones. | La consolidación conserva equivalencias, pero la vigencia de cada caso requiere decisión. | `Catalogo_Casos_de_Uso.md`, históricos de casos, ERS. | El alcance de análisis y pruebas seguirá incompleto. |
| 5 | Validar el modelo de procesos y decidir si se requieren diagramas BPMN formales. | El modelo actual es descriptivo y no debe llamarse BPMN sin diagramas reales. | `Modelo_Procesos_Cato_Parking.md`, `Matriz_Trazabilidad_Requisitos.md`. | No habrá una representación formal aprobada del flujo operativo. |
| 6 | Aprobar la operación offline y la sincronización. | Son decisiones arquitectónicas con dependencias de negocio y técnica. | ADR-002, ADR-004, estrategias offline/sincronización, protocolo. | Persisten límites no cerrados para arquitectura, datos y pruebas. |
| 7 | Validar hardware, lectores, relés, sensores y eventos soportados. | La consolidación eliminó fragmentación, no inventario ni aprobaciones. | `Especificacion_Integracion_InBIO_260.md`, históricos de hardware. | La integración física no puede considerarse definitiva. |
| 8 | Validar contratos de API, SSO y financiera. | Las integraciones activas contienen contratos documentales que requieren autoridad externa/institucional. | `Contrato_API_Cato_Parking.md`, `Integracion_Microsoft_SSO.md`, `Integracion_Financiera.md`. | Arquitectura e implementación no tendrán interfaces aprobadas. |
| 9 | Definir la relación normativa entre el modelo de datos y el esquema físico/SQL. | El SQL no se usó como fuente de verdad para esta fase. | `Modelo_Datos_Cato_Parking.md`, `03_Base_de_Datos/Esquema/dbo.sql`. | No se puede declarar aprobado el modelo físico ni su trazabilidad. |
| 10 | Validar UX/UI por rol y criterios de aceptación. | Los documentos se alinearon semánticamente, pero la aceptación es humana. | Todo `05_UX_UI/`, ERS, casos de uso. | Pruebas de aceptación y diseño pueden divergir. |
| 11 | Entregar o aprobar casos, resultados y evidencias de prueba. | La estructura actual no demuestra ejecución. | `06_Pruebas/`, `Matriz_Resultados_Pruebas.md`, trazabilidad. | El área de pruebas permanece en rojo. |
| 12 | Confirmar la existencia y ubicación de `Marca_Cato_Parking.docx` o declarar el faltante. | El contexto persistente identifica ese documento como faltante. | `Context_Codex.md`, gobierno documental e identidad. | La identidad documental seguirá con pendiente abierto. |
| 13 | Aprobar la política de retención de históricos y de copias literales. | Cinco Markdown se reescribieron en destino histórico y no tienen copia byte a byte. | `99_Historico/Documentacion_Heredada/`, índices y registro de decisiones. | Puede quedar pendiente el nivel de preservación archivística requerido. |

## 8. Semáforo ejecutivo

| Área | Estado | Justificación |
|---|---|---|
| Gobierno | 🟢 Verde | Existe una superficie activa, un histórico separado, índice maestro y registro de decisiones. |
| Gestión | 🟡 Amarillo | La estructura está saneada, pero preguntas, inconsistencias y entregables requieren cierres humanos. |
| Requirements | 🟡 Amarillo | Requisitos, reglas y RNF están centralizados; falta validación institucional de alcance y reglas. |
| Casos de uso | 🟡 Amarillo | Hay catálogo canónico y equivalencias históricas; la aprobación del catálogo y sanciones sigue pendiente. |
| Procesos | 🟡 Amarillo | Hay modelo consolidado, pero no BPMN formal ni aprobación final del flujo. |
| Arquitectura | 🟡 Amarillo | ADR, C4, seguridad, integraciones, hardware y despliegue están ordenados; faltan validaciones críticas. |
| Data | 🟡 Amarillo | Existe modelo único documental; quedan pendientes modelo físico, SQL y reglas de integridad aprobadas. |
| UX/UI | 🟡 Amarillo | El bloque está alineado y conservado; falta aceptación institucional por rol y flujo. |
| Tests | 🔴 Rojo | No se dispone de evidencia ejecutada suficiente; README y matrices no sustituyen resultados. |
| History | 🟢 Verde | Fuentes heredadas, auditorías y fragmentos están separados de la superficie activa y localizables. |

## 9. Cierre y límites de esta rendición

- La arquitectura documental objetivo quedó definida alrededor de `10_Escritorio_Garita/` como activo y `99_Historico/` como histórico.
- Los cambios derivados del saneamiento ya estaban aplicados antes de elaborar este informe; durante esta tarea no se modificó ningún archivo de `Documentos/`.
- Se revisaron `git diff` y `git status`; no se hizo commit.
- Los archivos de gobierno `AGENTS.md`, `Context_Codex.md` y `.codex/skills/auditoria-documental-cato-parking/SKILL.md` permanecen fuera de las métricas de `Documentos/`.
- Este informe no valida aprobación institucional, ejecución técnica, pruebas, contratos ni decisiones de negocio; deja esas decisiones explícitas para revisión humana.
