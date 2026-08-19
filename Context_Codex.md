# Context_Codex.md — Fuente Única de Verdad para la Documentación de Cato Parking

## 1. Propósito y regla de trabajo

Este archivo describe el estado vigente del corpus documental de Cato Parking. No es un changelog ni un registro cronológico. Debe leerse antes de cualquier nueva auditoría, modificación, consolidación, historización o eliminación dentro de `Documentos/`.

La documentación es la fuente de verdad para requisitos, reglas, alcance, procesos, arquitectura, datos, UX/UI, pruebas y decisiones institucionales. El código del repositorio está fuera de esa fuente de verdad y no debe utilizarse para validar, negar o reinterpretar el contenido documental.

## 2. Gobierno documental vigente

- Nombre público: **Cato Parking**.
- Nombre técnico: **Sistema Institucional de Gestión de Parqueaderos Cato Parking**.
- Institución beneficiaria: **Pontificia Universidad Católica del Ecuador, Sede Ambato (PUCESA)**.
- Contexto institucional: iniciativa Smart Campus orientada a la gestión de parqueaderos.
- Fuente activa: `Documentos/10_Escritorio_Garita/`.
- Índice activo: `Documentos/10_Escritorio_Garita/00_Gobierno_Documental/Indice_Maestro_Documentos.md`.
- Evidencia histórica y fuentes sustituidas: `Documentos/99_Historico/`.

Las denominaciones antiguas —SGP PUCESA, Sistema de Gestión Multiuso de Parqueadero, Sistema de Gestión Multisitio de Parqueaderos y similares— son históricas salvo que un documento vigente las cite expresamente como referencia anterior.

## 3. Alcance

La documentación distingue obligatoriamente:

- **Prototipo:** evidencia o descripción histórica/técnica de versiones tempranas.
- **MVP:** núcleo mínimo formalmente definido para la operación local de garita y su validación.
- **Sistema completo:** visión institucional ampliada, con plataforma central, autoservicio, periodos, pagos, visitantes u otras capacidades sujetas a decisiones posteriores.

Un documento activo en borrador, propuesto, reservado o pendiente no demuestra aprobación institucional, implementación ni ejecución de pruebas.

## 4. Arquitectura documental activa

La estructura activa vigente es:

1. `10_Escritorio_Garita/00_Gobierno_Documental/`: identidad, glosario, decisiones e índice.
2. `10_Escritorio_Garita/01_Gestion_Proyecto/`: alcance, stakeholders, planificación, preguntas y control documental.
3. `10_Escritorio_Garita/02_Requisitos_y_Negocio/`: ERS, reglas, actores/roles/permisos, RNF, backlog funcional, catálogo de casos de uso, modelo textual de procesos y trazabilidad.
4. `10_Escritorio_Garita/03_Arquitectura/`: arquitectura, ADR, C4, despliegue, hardware, integraciones, seguridad y pruebas de arquitectura.
5. `10_Escritorio_Garita/04_Datos/`: `Modelo_Datos_Cato_Parking.md`, modelo consolidado conceptual/lógico/local, estados, integridad y migraciones.
6. `10_Escritorio_Garita/05_UX_UI/`: arquitectura de información, navegación, flujos, vistas y mensajes.
7. `10_Escritorio_Garita/06_Pruebas/`: matriz y reglas para materializar casos y evidencias.
8. `99_Historico/`: fuentes heredadas, documentos sustituidos, fragmentos consolidados y auditorías fechadas.

`Documentos/04_Desarrollo/` se mantiene como guía operativa del equipo; sus referencias al prototipo no gobiernan requisitos ni alcance documental.

Los documentos fragmentados de casos de uso, procesos, actores/permisos, datos, hardware y despliegue fueron consolidados. Sus fuentes completas se preservan en `99_Historico/Documentacion_Heredada/` y conservan los identificadores necesarios para trazabilidad histórica.

## 5. Estado de auditoría

Se revisaron todos los Markdown del corpus, incluidos documentos generales, gestión, requisitos, arquitectura, datos, UX/UI, pruebas, desarrollo e histórico. El inventario vigente contiene 126 archivos Markdown: 59 activos bajo `10_Escritorio_Garita/`, 63 históricos bajo `99_Historico/` y 4 guías de desarrollo bajo `04_Desarrollo/`.

La auditoría por bloques se considera completada para esta fase:

1. Gobierno y gestión vigente.
2. Requisitos y negocio, usando la auditoría previa como antecedente sin repetirla innecesariamente.
3. Arquitectura y sus subcapas.
4. Datos.
5. UX/UI.
6. Pruebas.
7. Documentación heredada y documentos generales.
8. Histórico.

## 6. Decisiones consolidadas

- `Cato Parking` es el nombre público vigente y la denominación técnica completa se usa en documentos formales.
- El escritorio de garita es el núcleo documental activo; la plataforma web, Microsoft SSO, pagos, periodos, prioridades y visitantes se mantienen como sistema completo o capacidades sujetas a validación cuando así se indique.
- El núcleo MVP documentado incluye configuración local, datos operativos mínimos, TAG, usuario/vehículo básicos, validación de acceso, entrada/salida con topología técnica pendiente donde corresponda, apertura manual justificada, auditoría, eventos técnicos y continuidad local con sincronización posterior.
- El límite documentado de dos vehículos activos por usuario se conserva como regla del baseline, pendiente de ratificación institucional si una nueva fuente superior lo contradice.
- La aplicación local no administra por sí sola tarifas, conciliación financiera, sanciones ni reglas institucionales amplias.
- `InBIO 260` es el controlador objetivo documentado. Reader, relé, sensor, firmware, IP, puerto, códigos E0/E20/E27, LOCK 1/LOCK 2 y compatibilidad de DLL permanecen sujetos a validación técnica; no se presentan como topología definitiva.
- Los procesos activos son modelos textuales editables. La carpeta y denominación `Procesos_BPMN` fueron retiradas del corpus activo porque no contenían BPMN formal.
- Los identificadores `PR-*`, `CU-*`, `RF-*`, `RN-*`, `V-*`, `HU-*` y `CP-*` se conservan para equivalencias. Los `CP-*` no son evidencia mientras no exista el caso de prueba y su evidencia ejecutada.

## 7. Documentos activos principales

- Gobierno: `Identidad_y_Denominacion_Oficial.md`, `Glosario_Cato_Parking.md`, `Registro_Decisiones.md`, `Indice_Maestro_Documentos.md`.
- Gestión: `Definicion_MVP.md`, `Vision_Sistema_Completo.md`, `Registro_Stakeholders.md`, `Matriz_RACI_Inicial.md`, `Backlog_Proyecto.md`, `Estado_Entregables.md`, `Preguntas_Pendientes_PUCESA.md`, `Registro_Inconsistencias_Documentales.md`.
- Requisitos: `ERS_Cato_Parking.md`, `Catalogo_Reglas_Negocio.md`, `Actores_Roles_y_Permisos.md`, `Requisitos_No_Funcionales.md`, `Backlog_Funcional.md`, `Catalogo_Casos_de_Uso.md`, `Modelo_Procesos_Cato_Parking.md`, `Matriz_Trazabilidad_Requisitos.md`.
- Arquitectura: `Documento_Arquitectura_Escritorio_Garita.md`, `Catalogo_Componentes.md`, `Principios_Arquitectura.md`, `Requisitos_Arquitectonicamente_Significativos.md`, estrategias, ADR, C4, despliegue, hardware, integraciones, seguridad y pruebas de arquitectura.
- Datos: `Modelo_Datos_Cato_Parking.md`.
- UX/UI: `Arquitectura_Informacion.md`, `Mapa_Navegacion.md`, `Flujos_por_Rol.md`, `Inventario_Vistas.md`, `Estados_y_Mensajes.md`.
- Pruebas: `06_Pruebas/README.md`, `Matriz_Resultados_Pruebas.md`, y las carpetas reservadas para casos y evidencias.

## 8. Trazabilidad y validaciones actuales

- `RF ↔ RN`: estructuralmente trazado.
- `RF/RN ↔ PR/CU`: trazado mediante el modelo textual y el catálogo consolidado.
- `CU ↔ V`: trazado en el inventario de vistas cuando existe vista documentada.
- `RF ↔ HU`: parcial; las historias viven dentro de `Backlog_Funcional.md` y no son archivos independientes.
- `RF ↔ CP`: previsto, no verificable extremo a extremo; no existen casos de prueba materializados ni evidencias ejecutadas.
- No debe afirmarse que una prueba, aprobación, integración, topología o despliegue existe solo porque se menciona o porque hay una carpeta reservada.

## 9. Pendientes reales

- Validación institucional de responsables nominales, alcance, reglamento, excepciones, horarios, cupos, prioridades, tarifas, reposición, visitantes, sanciones, retención de datos y RPO/RTO.
- Validación técnica del InBIO 260 instalado, lectores, relés, sensores, firmware, IP, puerto, SDK/DLL, códigos de eventos y comandos.
- Definición y aprobación de contratos, autenticación técnica, sincronización definitiva, conflictos, reintentos y cambios descendentes.
- Materialización y ejecución de los casos `CP-*`, con evidencias asociadas.
- Modelo físico de datos aprobado y relación normativa con el SQL heredado; el SQL existente se conserva como artefacto técnico no normativo.
- Diagramas formales, incluidos BPMN si fueran exigidos, solo podrán incorporarse con información y aprobación suficiente.
- Localización del insumo oficial `Marca_Cato_Parking.docx`, que no está presente en el repositorio de trabajo.

## 10. Reglas permanentes de reconstrucción

- No inventar requisitos, reglas, actores, cantidades, tiempos, tecnologías, aprobaciones ni decisiones.
- No usar código, clases, formularios, SQL o comportamiento observable del repositorio como fuente de verdad documental.
- No convertir una propuesta, un pendiente, un índice, un README o un identificador reservado en evidencia.
- Resolver contradicciones con una fuente documental superior; si no existe, marcar `PENDIENTE DE RESOLUCIÓN`.
- Antes de eliminar, comprobar referencias, conservar información útil y actualizar índices y equivalencias.
- Actualizar este archivo para que refleje el estado consolidado después de cada bloque significativo y al finalizar cualquier tarea documental.
