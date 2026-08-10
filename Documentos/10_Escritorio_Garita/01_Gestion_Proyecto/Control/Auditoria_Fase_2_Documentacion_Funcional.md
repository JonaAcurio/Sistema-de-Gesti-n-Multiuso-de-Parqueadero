# Auditoria de Fase 2 - Documentacion Funcional

**Codigo documental:** CP-CTL-003  
**Version:** 1.1  
**Estado:** Ejecutada internamente, recalibrada tras CP-CTL-004  
**Fecha:** 2026-08-10

## Objetivo

Verificar que la Fase 2 no cierre con falsos positivos documentales, funciones inventadas o aparentes cumplimientos sin evidencia.

## Evidencia revisada

- `README.md`
- `Documentos/10_Escritorio_Garita/00_Gobierno_Documental/Registro_Decisiones.md`
- `Documentos/10_Escritorio_Garita/02_Requisitos_y_Negocio/*.md`
- `Form1.cs`
- `ZKTecoManager.cs`
- `TarjetasDB.cs`

## Hallazgos de evidencia tecnica real

| Afirmacion | Evidencia | Conclusion |
| --- | --- | --- |
| Persistencia local JSON | `TarjetasDB.cs` | Confirmada. |
| Registro y cambio de estado de TAG | `TarjetasDB.cs` | Confirmada parcialmente; existe base local y cambio de estado. |
| Apertura manual | `Form1.cs`, `ZKTecoManager.cs` | Confirmada. |
| Anti-rebote de lecturas | `Form1.cs` | Confirmada. |
| Registro de eventos tecnicos visibles | `Form1.cs`, `ZKTecoManager.cs` | Confirmada. |
| Operacion con cache local y sincronizacion posterior | Definicion funcional vigente del equipo y persistencia local observable | Confirmada como objetivo funcional del escritorio. |
| SSO Microsoft | Sin evidencia en codigo operativo actual | No confirmada. Se mantiene como sistema completo. |
| Modulo financiero | Sin evidencia operativa local | No confirmada. Se mantiene como sistema completo. |
| Visitantes y sanciones | Sin evidencia operativa local | No confirmadas. Se mantienen como sistema completo. |
| Persistencia central SQL en la app local | Sin evidencia operativa actual | No confirmada. |

## Resultado contra condiciones de cierre

| Control | Resultado | Observacion |
| --- | --- | --- |
| Nombre y alcance estables | Cumple | Gobernado por README y decisiones. |
| Actores identificados | Cumple | Catalogo creado. |
| Roles diferenciados | Cumple | Matriz preliminar creada. |
| Permisos preliminares | Cumple | Matriz de permisos creada. |
| Reglas clasificadas | Cumple | Aprobadas, propuestas y pendientes diferenciadas. |
| Procesos centrales modelados | Cumple | Modelos textuales editables creados en `Procesos_BPMN`. |
| Cobertura funcional documental | Cumple | Existe cobertura alta hasta requisitos, procesos, casos de uso e interfaces; la validacion por pruebas sigue pendiente. |
| Requisitos atomicos | Cumple | ERS nueva creada desde cero. |
| Criterios de aceptacion verificables | Cumple | Cada RF creado incluye criterios. |
| RNF medibles o pendientes explicitos | Cumple | Sin adjetivos ambiguos sin marcar. |
| Trazabilidad estructural | Cumple | La matriz conecta RF, RN, PR, CU, vistas e historias con consistencia general. |
| Trazabilidad verificable extremo a extremo | Parcial | Los identificadores `CP-*` aun no estaban materializados como artefactos independientes al cierre de Fase 2. |
| Separacion MVP/sistema completo | Cumple | Presente en ERS, backlog y UX/UI. |
| Preguntas institucionales registradas | Cumple | Documento de control ya existente reutilizado. |
| Documentos sustituidos enviados a historico | Parcial | Existe historico y marcado inicial, pero aun coexisten copias y rutas antiguas de alta visibilidad. |
| Aprobacion documental registrada | Parcial | Existe estado de borrador y aprobador por designar; depende de PUCESA. |

## Revision cuantitativa minima

| Control | Resultado |
| --- | --- |
| Requisitos sin fuente | 0 |
| Requisitos sin alcance | 0 |
| Requisitos sin criterio de aceptacion | 0 |
| Reglas sin estado | 0 |
| Casos de uso sin actor | 0 |
| RNF ambiguos no marcados | 0 |
| Decisiones inventadas | 0 detectadas en la documentacion nueva |
| Archivos historicos eliminados | 0 |
| Pantallas sin proceso relacionado | 0 en el inventario nuevo |
| Requisitos duplicados | 0 detectados en la ERS nueva |
| Casos de prueba materializados | 0 |

## Riesgos abiertos

- Los responsables nominales de aprobacion siguen pendientes.
- La topologia final de hardware sigue con validacion tecnica pendiente.
- SSO, pagos y visitantes siguen siendo sistema completo, no MVP observado.
- El catalogo de sanciones queda fuera del alcance funcional propio de esta documentacion.
- Los identificadores `CP-*` se mantenian como referencias previstas y no como artefactos de prueba ya definidos.
- Los procesos BPMN quedaron como modelos textuales editables; si PUCESA exige notacion grafica formal, eso sera un entregable adicional, no un falso positivo actual.

## Conclusion

La Fase 2 dejo una base documental util y mayormente alineada con el estado real del sistema, pero su cierre no debe interpretarse como trazabilidad completa de extremo a extremo. Lo confirmado por codigo se refleja como MVP observado; lo que no tenia evidencia, prueba materializada o aprobacion institucional debe mantenerse explicitamente como pendiente o como vision del sistema completo.
