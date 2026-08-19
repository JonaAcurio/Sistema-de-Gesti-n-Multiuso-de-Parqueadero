# Auditoria Exhaustiva de Trazabilidad y Cobertura

**Codigo documental:** CP-CTL-004  
**Version:** 1.1  
**Estado:** Ejecutada internamente  
**Fecha:** 2026-08-07

> Nota posterior:
> Los hallazgos descritos corresponden al estado auditado del 2026-08-07. Varias correcciones fueron aplicadas posteriormente y deben verificarse mediante una auditoria de cierre independiente.

## Objetivo

Verificar si la documentacion vigente del escritorio de garita puede considerarse consistente, navegable y trazable de extremo a extremo, distinguiendo entre:

- trazabilidad estructural;
- trazabilidad verificable;
- documentos vigentes;
- documentos historicos;
- evidencia real;
- referencias nominales aun no materializadas.

## Alcance revisado

- `README.md`
- `Documentos/10_Escritorio_Garita/`
- `Documentos/01_Gestion_Proyecto/`
- `Documentos/02_Requisitos_y_Analisis/`
- `Documentos/99_Historico/`

## Metodologia

1. Busqueda de enlaces absolutos no portables.
2. Cruce de identificadores `RF-*`, `RN-*`, `PR-*`, `CU-*`, `V-*`, `CP-*` y `HU-*`.
3. Verificacion de existencia de artefactos citados por la matriz de trazabilidad.
4. Revision puntual de documentos que se contradicen entre si.
5. Revision de la auditoria de Fase 2 contra la evidencia actual.

## Resultado ejecutivo

- Gobierno documental: fuerte.
- Separacion entre escritorio vigente e historico: buena, pero incompleta.
- Cobertura funcional documental: alta, pendiente de validacion mediante pruebas.
- Trazabilidad estructural: cumple.
- Trazabilidad verificable extremo a extremo: parcial.
- Navegacion en GitHub: no cumple todavia.
- Cierre documental: no recomendable aun.

## Hallazgos principales

| Severidad | Hallazgo | Evidencia | Impacto |
| --- | --- | --- | --- |
| Alta | El `README.md` raiz contiene enlaces absolutos `/E:/a/...` incompatibles con GitHub. | `README.md:125`, `README.md:154-165` | La navegacion principal del repositorio falla fuera del entorno local donde se generaron los enlaces. |
| Alta | La matriz declara casos de prueba `CP-*` que no existen como artefactos verificables. | `Matriz_Trazabilidad_Requisitos.md:10-28` y busqueda global de `CP-CON-001`, `CP-ACC-018`, `CP-VIS-001`, etc. | La trazabilidad completa se sobredeclara. Los extremos de prueba solo existen como texto en la matriz. |
| Alta | La auditoria de Fase 2 marca como `Cumple` controles que dependen de artefactos no verificables. | `Auditoria_Fase_2_Documentacion_Funcional.md:46-50`, `:53` | Genera falso positivo en el documento que debia impedirlo. |
| Media-Alta | La ERS contradice su propia definicion del MVP. | `ERS_Cato_Parking.md:73` frente a `ERS_Cato_Parking.md:83-87` y multiples RF MVP de usuarios, vehiculos, TAG, auditoria y configuracion. | El alcance del MVP queda semantica y contractualmente ambiguo. |
| Media-Alta | La ERS tiene fecha de cabecera y fecha de historial desincronizadas. | `ERS_Cato_Parking.md:4-6`, `ERS_Cato_Parking.md:727-728` | Debilita el control documental y la auditabilidad de cambios. |
| Media-Alta | Existen dos versiones del informe tecnico del servidor y una de ellas introduce un error tecnico en el diagrama. | `Actas/Informe_Tecnico_Servidor_SGP.md:63-79` frente a `Informes_Tecnicos/Informe_Tecnico_Servidor_SGP.md:56-71` | Una copia modela `Windows Server version 16.0` como si fuera el nodo SQL, contradiciendo el texto del mismo informe. |
| Media | Persisten documentos historicos o sustituidos con alta visibilidad y sin marcado frontal suficiente. | `Documentos/01_Gestion_Proyecto/Actas/`, `Documentos/02_Requisitos_y_Analisis/`, `README.md` | Facilita que un lector llegue a contenido reemplazado y lo interprete como vigente. |
| Media | Se expone informacion operativa de infraestructura cuya combinacion facilita el reconocimiento innecesario del entorno institucional. | Ambos informes del servidor, especialmente `:12`, `:19-20`, `:45`, `:49` | Publica datos que, combinados, aumentan innecesariamente la superficie de reconocimiento del entorno. |
| Baja-Media | El README raiz no refleja completamente la estructura oficial vigente. | `README.md:167+` y existencia de `03_Arquitectura`, `04_Datos`, `05_UX_UI`, `99_Historico` | La estructura oficial queda parcialmente invisible en la portada del repo. |

## Trazabilidad: estado real

### Lo que si existe y puede abrirse

- `RF-*`: existen como requisitos formales en la ERS y aparecen reutilizados en arquitectura, reglas y trazabilidad.
- `RN-*`: existen como catalogo formal de reglas.
- `PR-*`: existen como procesos textuales, con la excepcion especial de `PR-06`, que se conserva solo para no romper referencias historicas.
- `CU-*`: existen como casos de uso formales.
- `V-*`: existen como inventario de vistas dentro de `Inventario_Vistas.md`.
- `HU-*`: existen en `Backlog_Funcional.md`, pero como historias incluidas dentro de un solo documento, no como artefactos separados.

### Lo que no existe como artefacto verificable independiente

Los siguientes IDs de prueba aparecen solo en la matriz y no tienen documento, carpeta ni evidencia propia:

- `CP-CON-001`
- `CP-USR-001`
- `CP-VEH-001`
- `CP-TAG-001`
- `CP-TAG-002`
- `CP-ACC-001`
- `CP-ACC-002`
- `CP-ACC-003`
- `CP-ACC-004`
- `CP-ACC-005`
- `CP-ACC-018`
- `CP-AUD-001`
- `CP-GAR-001`
- `CP-SIN-001`
- `CP-SIN-002`
- `CP-AUT-001`
- `CP-PER-001`
- `CP-PAG-001`
- `CP-VIS-001`

## Matriz de anomalias y accion requerida

| Prioridad | Archivo a modificar | Problema | Cambio requerido |
| --- | --- | --- | --- |
| 1 | `README.md` | Enlaces absolutos `/E:/a/...` en portada. | Reemplazar por rutas relativas compatibles con GitHub. |
| 1 | `Documentos/10_Escritorio_Garita/02_Requisitos_y_Negocio/Matriz_Trazabilidad_Requisitos.md` | Columna `Caso de prueba` aparenta trazabilidad cerrada, pero los `CP-*` no existen como artefactos. | Mantener el identificador previsto y agregar un `Estado de prueba` hasta que exista evidencia materializada. |
| 1 | `Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Control/Auditoria_Fase_2_Documentacion_Funcional.md` | Declara `Casos de uso completos`, `Trazabilidad` y `Documentos sustituidos enviados a historico` como `Cumple` sin respaldo pleno. | Cambiar a una redaccion mas rigurosa: `Trazabilidad estructural: Cumple`, `Trazabilidad verificable: Parcial`; revisar tambien el criterio de historico visible. |
| 2 | `Documentos/10_Escritorio_Garita/02_Requisitos_y_Negocio/ERS_Cato_Parking.md` | La frase `El MVP se enfoca exclusivamente...` contradice el resto del documento. | Sustituir `exclusivamente` por una formula compatible con el alcance real del MVP documentado. |
| 2 | `Documentos/10_Escritorio_Garita/02_Requisitos_y_Negocio/ERS_Cato_Parking.md` | Fecha de cabecera `2026-07-17` no coincide con historial `1.1` del `2026-07-18`. | Sincronizar cabecera, version y tabla de historial. |
| 2 | `Documentos/01_Gestion_Proyecto/Actas/Informe_Tecnico_Servidor_SGP.md` | Duplicado con error tecnico en el diagrama. | Corregir el diagrama para que el nodo SQL vuelva a ser `Microsoft SQL Server 2016` o marcar el documento como historico/no vigente. |
| 3 | `Documentos/01_Gestion_Proyecto/Actas/Informe_Tecnico_UX_UI_V1.md` | Mantiene enlace absoluto local a su copia vigente. | Cambiar a ruta relativa o marcar la referencia como historica. |
| 3 | `Documentos/02_Requisitos_y_Analisis/Plantillas/Plantilla_IEEE830_Parqueadero.md` | Mantiene enlace absoluto local a stakeholders. | Cambiar a ruta relativa o agregar aviso frontal de documento historico. |
| 3 | `Documentos/01_Gestion_Proyecto/Informes_Tecnicos/Informe_Tecnico_Servidor_SGP.md` y `Documentos/01_Gestion_Proyecto/Actas/Informe_Tecnico_Servidor_SGP.md` | Exponen IP interna, usuarios de host y detalles operativos. | Sanitizar datos sensibles o mover la version completa fuera del repositorio publico. |

## Evaluacion detallada por cadena de trazabilidad

| Tramo | Estado | Observacion |
| --- | --- | --- |
| `RF -> RN` | Fuerte | La correspondencia esta bien establecida y es verificable. |
| `RN -> PR` | Fuerte | Los procesos textuales referencian reglas de forma consistente. |
| `RF -> CU` | Fuerte | Los casos de uso citados existen y son localizables mediante los requisitos vigentes. |
| `PR <-> CU` | Aceptable | Existe correspondencia funcional consistente entre procesos y casos de uso, aunque ambos se trazan principalmente mediante el requisito comun y no siempre por referencia bidireccional directa. |
| `CU -> V` | Aceptable | Las vistas existen como inventario, aunque no como especificaciones individuales. |
| `RF -> HU` | Parcial | Solo algunos requisitos tienen `HU-*`, y esas historias viven dentro de un unico backlog. |
| `RF -> CP` | Debil | Los `CP-*` citados no existen fuera de la propia matriz. |

## Evaluacion de la auditoria de Fase 2

La auditoria existente sigue siendo util como fotografia de intencion, pero no puede mantenerse sin ajustes como evidencia de cierre. Las correcciones minimas recomendadas son:

- cambiar `Casos de uso completos: Cumple` por una formulacion basada en existencia y cobertura real;
- cambiar `Trazabilidad: Cumple` por `Trazabilidad estructural: Cumple` y `Trazabilidad verificable: Parcial`;
- revisar `Documentos sustituidos enviados a historico: Cumple`, porque aun coexisten duplicados y documentos sustituibles de alta visibilidad;
- agregar un riesgo explicito sobre `CP-*` no materializados.

## Historial de cambios

| Version | Fecha | Descripcion |
| --- | --- | --- |
| 1.1 | 2026-08-10 | Ajusta precision terminologica del diagnostico sin alterar los hallazgos identificados el 2026-08-07. |
| 1.0 | 2026-08-07 | Emision inicial de la auditoria exhaustiva previa al saneamiento documental. |

## Conclusion

La base documental vigente es buena y no requiere una reconstruccion total. Sin embargo, todavia no conviene declararla cerrada ni libre de contradicciones.

La conclusion tecnica mas precisa es esta:

- trazabilidad estructural: cumple;
- trazabilidad verificable extremo a extremo: parcial;
- navegacion GitHub: parcial;
- control de version documental: parcial;
- cierre institucional: aun no recomendado.

## Orden recomendado de correccion

1. Reparar enlaces absolutos.
2. Corregir o historizar duplicados tecnicos.
3. Corregir contradiccion y fechas de la ERS.
4. Auditar y materializar `CP-*` o marcarlos como pendientes.
5. Recalcular la auditoria de Fase 2 con base en evidencia verificable.
6. Reducir visibilidad o sanear informacion sensible en historicos tecnicos.
