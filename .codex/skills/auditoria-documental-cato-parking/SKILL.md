---
name: auditoria-documental-cato-parking
description: Audita, consolida y reconstruye la documentación Markdown de Cato Parking dentro de Documentos/, usando Context_Codex.md como fuente única de contexto y evitando inventar información.
---

# Auditoría y saneamiento documental de Cato Parking

## Objetivo
Ejecutar de principio a fin la auditoría y reconstrucción documental de `Documentos/` sin depender del código fuente ni de conversaciones anteriores.

Responsabilidades obligatorias:
1. **Auditar todas las carpetas y documentos Markdown de `Documentos/`.**
2. **Aplicar los cambios derivados de la auditoría en todo `Documentos/`: mejorar, modificar, combinar, mover, historizar o eliminar según corresponda.**

No detenerse después de producir un informe si la tarea solicitada incluye aplicar los cambios.

## Precondición obligatoria
Antes de cualquier acción:
1. leer `Context_Codex.md`;
2. leer el `AGENTS.md` aplicable;
3. inspeccionar el árbol completo de `Documentos/`;
4. identificar qué bloques ya fueron auditados y no repetir trabajo innecesario;
5. confirmar que el trabajo se basa en documentación y no en código.

Si `Context_Codex.md` contradice el árbol real, actualizar primero el contexto con hechos verificables del corpus documental.

## Prohibición de usar código como fuente de verdad
En esta fase:
- no inspeccionar código para decidir qué requisito es real;
- no negar documentación porque una implementación visible no coincida;
- no derivar reglas ni procesos desde clases, formularios o bases de datos del código;
- no usar el estado de implementación como criterio de conservación documental.

## Método de auditoría por archivo
Para cada `.md` registrar internamente: ruta, propósito, alcance, dependencias, duplicación, contradicciones, suficiencia, trazabilidad, vigencia, decisión, acción requerida y documento destino si se combina.

Decisiones válidas: `MANTENER`, `MEJORAR`, `MODIFICAR`, `COMBINAR`, `HISTORIZAR`, `ELIMINAR`.

## Criterio de conservación
Un archivo independiente sobrevive solo si tiene función documental inequívoca, contenido suficiente, no duplica innecesariamente otro artefacto, es mantenible, su alcance está claro y sus referencias tienen sentido semántico.

## Tratamiento de contradicciones
Orden de resolución:
1. decisión documental explícita y vigente;
2. documento rector de alcance/gobierno;
3. ERS/reglas vigentes según la materia;
4. documento especializado;
5. documentos heredados/históricos.

Si no existe base suficiente: marcar `PENDIENTE DE RESOLUCIÓN`. No elegir arbitrariamente.

## Tratamiento de información incompleta
- buscar información compatible en el corpus documental;
- consolidarla;
- no crear valores faltantes;
- no fijar cantidades, tiempos, prioridades, tarifas o políticas no aprobadas;
- no inventar actores o flujos;
- usar `Pendiente de definición/validación/aprobación` cuando corresponda.

## Auditoría por bloques
Seguir el orden definido en `Context_Codex.md`: gobierno/gestión, requisitos ya auditados, arquitectura, datos, UX/UI, pruebas, heredados e histórico.

No comenzar la reconstrucción masiva definitiva hasta tener visión suficiente de dependencias cruzadas.

## Fase de reconstrucción
Después de auditar:
1. diseñar arquitectura documental objetivo;
2. comparar estructura actual vs objetivo;
3. preparar mapa de migración de cada archivo;
4. aplicar fusiones;
5. mejorar documentos supervivientes;
6. mover históricos;
7. eliminar redundantes;
8. actualizar enlaces;
9. actualizar índices;
10. corregir referencias de trazabilidad;
11. verificar que no queden archivos huérfanos;
12. actualizar `Context_Codex.md`.

## Reglas especiales ya acordadas
### Requisitos y negocio
Estructura provisional: ERS, Reglas de Negocio, Actores/Roles/Permisos, RNF, Backlog, Catálogo de Casos de Uso, Modelo de Procesos y Matriz de Trazabilidad. Validar dependencias globales antes de cerrarla.

### Casos de uso
No conservar múltiples archivos diminutos por módulo cuando un catálogo consolidado sea más mantenible. Cada caso superviviente debe tener suficiente especificación.

### Procesos
No llamar `BPMN` a simples listas de pasos. Si no se crean modelos BPMN reales, renombrar la capa documental como procesos de negocio/modelo de procesos.

### Histórico
Los artefactos fuera de alcance que solo sobreviven por referencia histórica deben salir del corpus activo.

## Validaciones finales obligatorias
### Estructura
- ningún archivo activo sin función clara;
- ningún índice apuntando a retirados;
- ningún duplicado evidente;
- históricos fuera del corpus activo;
- nombres de carpetas coherentes.

### Consistencia
Buscar denominaciones antiguas usadas como vigentes, alcance MVP/futuro mezclado, reglas incompatibles, referencias rotas, IDs inexistentes, procesos/casos inexistentes, pruebas declaradas sin artefacto y aprobaciones no soportadas.

### Trazabilidad
Validar semánticamente `RF ↔ RN ↔ CU ↔ Proceso ↔ Actor ↔ Datos ↔ Arquitectura ↔ UX ↔ Prueba`. No rellenar columnas solo para aparentar completitud.

### Git
Revisar `git diff` y `git status`, resumir cambios reales y no afirmar validaciones no ejecutadas.

## Actualización obligatoria de contexto
Al finalizar cada bloque y toda la tarea, actualizar `Context_Codex.md` reemplazando estado viejo por vigente. No convertirlo en diario.

## Resultado esperado de una ejecución completa
Entregar auditoría completa, estructura objetivo, modificaciones aplicadas, archivos combinados/mejorados, históricos separados, redundancias eliminadas, enlaces/trazabilidad corregidos, `Context_Codex.md` actualizado y resumen final de supervivientes/cambios/pendientes.

La calidad se mide por coherencia y utilidad documental, no por cantidad de archivos generados.
