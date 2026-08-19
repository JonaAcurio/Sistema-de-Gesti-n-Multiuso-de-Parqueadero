# AGENTS.md — Gobierno documental Cato Parking

## Alcance
Estas instrucciones aplican a todo el repositorio, con prioridad especial sobre `Documentos/`.

## Regla obligatoria antes de trabajar en documentación
Antes de auditar, crear, modificar, mover, combinar, historizar o eliminar cualquier archivo dentro de `Documentos/`:

1. Leer `Context_Codex.md` completo.
2. Leer `.codex/skills/auditoria-documental-cato-parking/SKILL.md`.
3. Inspeccionar el árbol actual de `Documentos/`.
4. Trabajar exclusivamente con la documentación como fuente de verdad para esta fase.
5. NO usar el estado del código fuente del repositorio para validar, negar o reinterpretar requisitos, procesos, arquitectura o alcance documental. El código visible está desactualizado y no representa la realidad actual del proyecto.

## Fuente única de verdad operativa
`Context_Codex.md` es el contexto rector del trabajo documental.

Debe mantenerse como una fotografía del estado vigente del proyecto, NO como historial de cambios.

Después de cualquier tarea que cambie estructura documental, decisiones de conservación/fusión/eliminación, nombres oficiales, alcance, estado de auditoría, arquitectura documental objetivo, dependencias entre documentos o pendientes críticos, actualizar `Context_Codex.md` para que vuelva a reflejar el estado actual consolidado.

No agregar entradas tipo “el día X se hizo” o “en el commit Y se cambió”, salvo que ese dato histórico sea necesario para comprender el estado vigente.

## Reglas anti-alucinación
- No inventar requisitos, reglas, actores, procesos, tecnologías, decisiones institucionales, fechas, cantidades, estados ni aprobaciones.
- No completar huecos con conocimiento general.
- Si dos documentos se contradicen y no existe una fuente documental superior que resuelva el conflicto, marcarlo como `PENDIENTE DE RESOLUCIÓN`.
- Si una afirmación carece de soporte documental, eliminarla, degradarla a propuesta o marcarla como pendiente según corresponda.
- No convertir una propuesta en decisión aprobada.
- No convertir una carpeta vacía, README de estructura o identificador reservado en evidencia de implementación o prueba.
- No crear documentos solo para llenar una categoría.
- No conservar un archivo solo porque ya existe.

## Regla de modificación
Toda modificación dentro de `Documentos/` debe poder justificarse con una de estas razones: consolidar duplicación, corregir contradicción documental, mejorar suficiencia, separar vigente de histórico, corregir estructura/taxonomía, restaurar trazabilidad real, eliminar contenido sin función documental o completar un documento usando únicamente información ya soportada por el corpus documental.

## Seguridad de cambios
Antes de eliminar un archivo:
1. comprobar referencias internas;
2. preservar la información útil en el documento destino o en histórico;
3. actualizar enlaces e índices;
4. evitar pérdida de trazabilidad.

No modificar archivos fuera de `Documentos/`, salvo `Context_Codex.md`, este `AGENTS.md`, la skill documental y archivos auxiliares estrictamente necesarios para validar la documentación.
