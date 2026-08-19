# Registro de Decisiones

**Código documental:** CP-GOB-002  
**Versión:** 2.0
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-08-18

> Las decisiones de este registro se basan en el corpus documental y en lineamientos documentados. Las referencias a artefactos técnicos históricos solo conservan hipótesis del prototipo; no convierten el código ni una implementación observable en fuente de verdad ni en validación institucional.
**Autor:** Codex sobre insumos existentes del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 1.1 | 2026-07-18 | Ajusta decisiones al alcance real del escritorio de garita y a la parametrización administrativa externa. |
| 1.0 | 2026-07-17 | Creación del registro inicial de decisiones consolidadas, históricas y pendientes. |

## 1. Convenciones de estado

- **APROBADA**
- **APROBADA CON VALIDACIÓN TÉCNICA PENDIENTE**
- **PROPUESTA**
- **PENDIENTE DE DECISIÓN**
- **DESCARTADA**
- **HISTÓRICA/SUSTITUIDA**

## 2. Matriz de decisiones

| ID | Decisión | Fecha | Origen | Estado | Responsable de validación | Documentos afectados | Observaciones |
| --- | --- | --- | --- | --- | --- | --- | --- |
| DA-001 | Uso de la marca Cato Parking | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; identidad; alcance; índices | Nombre público oficial. |
| DA-002 | Institución beneficiaria: PUCESA | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | Todos los documentos base | Debe usarse PUCESA como abreviatura interna. |
| DA-003 | Contexto Smart Campus | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; visión; stakeholders | No implica aprobación de todas las funcionalidades futuras. |
| DA-004 | Controlador principal: ZKTeco InBIO 260 | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; informes UX/UI; hardware; inconsistencias | Sustituye referencias históricas a InBIO 206 como nombre del modelo objetivo. |
| DA-005 | Inventario inicial planificado: 1.000 TAG | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; SRS; formularios; inconsistencias | Cifra oficial de planificación. |
| DA-006 | Existencia de aplicación local de garita | 2026-07-17 | Documentación vigente y lineamientos | APROBADA | Responsable institucional por designar | README; MVP; visión | Base documental del prototipo actual. |
| DA-007 | Control de acceso mediante TAG RFID | 2026-07-17 | Documentación vigente y lineamientos | APROBADA | Responsable institucional por designar | README; MVP; SRS; formularios | Núcleo funcional mínimo documentado. |
| DA-008 | Necesidad de registrar entradas y salidas | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; MVP; SRS | Registro mínimo exigido. |
| DA-009 | Necesidad de diferenciar usuarios institucionales | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | visión; stakeholders; SRS | La matriz de roles queda pendiente de formalización final. |
| DA-010 | Necesidad de operación y auditoría | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | MVP; visión; SRS | Incluye aperturas manuales y eventos técnicos. |
| DA-011 | Microsoft SSO como objetivo del sistema completo | 2026-07-17 | Lineamientos de estabilización | APROBADA | TI PUCESA | visión; SRS; formularios | No se considera implementado ni parte del MVP. |
| DA-012 | Plataforma web como parte del sistema completo | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; visión; SRS | No debe presentarse como operativa. |
| DA-013 | Administración de múltiples parqueaderos como visión objetivo | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | visión; SRS | Visión objetivo, no estado implementado. |
| DA-014 | Apertura manual con motivo obligatorio | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | MVP; SRS; Task List | Requisito mínimo de auditoría. |
| DA-015 | Gestión centralizada de TAG | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | visión; SRS; formularios | El prototipo actual usa persistencia local. |
| DA-016 | Pagos y gestión financiera como módulo independiente | 2026-07-17 | Lineamientos de estabilización | APROBADA | Unidad Financiera PUCESA | visión; SRS; formularios | No implementado en esta fase. |
| DA-017 | Periodos de inscripción | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | visión; SRS | Sin fechas aprobadas aún. |
| DA-018 | Priorización por roles o grupos | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | visión; preguntas pendientes | Orden e intervalos no aprobados. |
| DA-019 | Diferencia entre prototipo, MVP y sistema completo | 2026-07-17 | Lineamientos de estabilización | APROBADA | Responsable institucional por designar | README; alcance; Task List | Regla base de toda la estabilización. |
| DA-020 | La app de escritorio se limita a operación de garita y hardware | 2026-07-18 | Definición actual del equipo | APROBADA | Equipo del proyecto | README; alcance; ERS; RNF | Incluye lectura de TAG, altas básicas, control de acceso, reportes operativos y sincronización. |
| DA-021 | Los valores administrativos fluctuantes serán parametrizables | 2026-07-18 | Definición actual del equipo | APROBADA | Equipo del proyecto | preguntas pendientes; visión; ERS | Aplica a espacios, cupos, precios, tarifas y disponibilidad configurable. |
| DA-022 | Límite funcional adoptado: 2 vehículos por usuario | 2026-07-18 | Definición actual del equipo | APROBADA | Equipo del proyecto | ERS; reglas; visión web | Regla vigente para el sistema. |
| DA-023 | La app de escritorio opera con caché local y sincronización diferida | 2026-07-18 | Definición actual del equipo | APROBADA | Equipo del proyecto | README; ERS; RNF; trazabilidad | Si se cae la conectividad, la operación continúa y luego sincroniza. |
| DA-024 | El catálogo de sanciones no pertenece al alcance funcional del equipo actual | 2026-07-18 | Definición actual del equipo | APROBADA | Equipo del proyecto | ERS; reglas; trazabilidad; preguntas pendientes | No se documentará como funcionalidad propia de esta fase. |
| DT-001 | Reader 1 para entrada y Reader 4 para salida | 2026-07-17 | Documentación técnica histórica del prototipo | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware; inconsistencias | Hipótesis técnica; no fija la topología del InBIO 260. |
| DT-002 | Códigos de evento E0, E20 y E27 | 2026-07-17 | Documentación técnica histórica del prototipo | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware; inconsistencias | Debe confirmarse semántica exacta. |
| DT-003 | Comandos LOCK 1 y LOCK 2 | 2026-07-17 | Documentación técnica histórica del prototipo | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware | Debe confirmarse correspondencia con relés y barreras. |
| DT-004 | Cantidad exacta de puertas, lectores y relés en uso | 2026-07-17 | Informes técnicos históricos | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware; inconsistencias | La documentación actual no es concluyente. |
| DT-005 | Compatibilidad exacta de plcommpro.dll y pltcpcomm.dll con InBIO 260 | 2026-07-17 | Acta histórica e informes previos | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware; preguntas pendientes | Falta validación formal. |
| DT-006 | Temporización de pulsos | 2026-07-17 | Informes técnicos históricos | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware | No hay parámetro aprobado institucionalmente. |
| DT-007 | Comportamiento de sensores | 2026-07-17 | Informes técnicos históricos | PENDIENTE DE VALIDACIÓN TÉCNICA | Responsable técnico de hardware ZKTeco | hardware | Debe confirmarse cableado y lógica de campo. |
| DT-008 | Estrategia definitiva de operación offline | 2026-07-17 | Documentación del prototipo y arquitectura objetivo | PENDIENTE DE VALIDACIÓN TÉCNICA | TI PUCESA y soporte técnico | MVP; visión; preguntas pendientes | La continuidad local está documentada; la estrategia definitiva requiere validación. |
| PD-001 | Fechas exactas de los periodos | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | visión; preguntas pendientes | Valor pendiente de aprobación. |
| PD-002 | Días entre prioridades | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | visión; preguntas pendientes | Parámetro pendiente de aprobación. |
| PD-003 | Orden definitivo de prioridades | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | stakeholders; visión | No consolidado. |
| PD-004 | Cupos por rol | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | visión; SRS | Parámetro administrativo configurable; no bloquea la app de escritorio. |
| PD-005 | Cupos por parqueadero | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | visión; SRS | Parámetro administrativo configurable; no bloquea la app de escritorio. |
| PD-006 | Límite definitivo de vehículos por usuario | 2026-07-17 | Estabilización | HISTÓRICA/SUSTITUIDA | Equipo del proyecto | SRS; preguntas pendientes | Sustituida por DA-022 con valor operativo de 2 vehículos. |
| PD-007 | Tarifa institucional | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Unidad Financiera PUCESA | financiero; SRS | Parámetro administrativo configurable fuera del alcance del escritorio. |
| PD-008 | Tarifas diferenciadas | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Unidad Financiera PUCESA | financiero; SRS | Parámetro administrativo configurable fuera del alcance del escritorio. |
| PD-009 | Costo de reposición de TAG | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Unidad Financiera PUCESA | financiero; SRS | Parámetro administrativo configurable fuera del alcance del escritorio. |
| PD-010 | Reglamento oficial | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Autoridades PUCESA | inconsistencias; preguntas pendientes | No reemplazar propuestas publicitarias por reglamento. |
| PD-011 | Catálogo de sanciones | 2026-07-17 | Estabilización | DESCARTADA | Autoridades PUCESA | visión; SRS | Fuera del alcance funcional propio documentado en esta fase. |
| PD-012 | Duración de sanciones | 2026-07-17 | Estabilización | DESCARTADA | Autoridades PUCESA | visión; SRS | Fuera del alcance funcional propio documentado en esta fase. |
| PD-013 | Velocidad máxima | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Autoridades PUCESA | reglamento; preguntas pendientes | No aprobada. |
| PD-014 | Reglas de visitantes | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Administración y Seguridad PUCESA | visión; preguntas pendientes | No aprobadas. |
| PD-015 | Cobro por hora o fracción | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Unidad Financiera PUCESA | financiero; SRS | Parámetro administrativo configurable fuera del alcance del escritorio. |
| PD-016 | Excepciones para autoridades | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Autoridades PUCESA | preguntas pendientes | No aprobadas. |
| PD-017 | Número de espacios reservados | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Administración PUCESA | visión; preguntas pendientes | Parámetro administrativo configurable; no bloquea la app de escritorio. |
| PD-018 | Proceso exacto de facturación | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | Unidad Financiera PUCESA | financiero; preguntas pendientes | No aprobado. |
| PD-019 | Integración con sistema financiero | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | TI y Finanzas PUCESA | visión; preguntas pendientes | No aprobado. |
| PD-020 | Tiempos de retención de datos | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | auditoría; datos personales | No aprobados. |
| PD-021 | Disponibilidad requerida | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | operación; RNF | Valor institucional configurable o contractual; no se fija en esta fase del escritorio. |
| PD-022 | RPO y RTO | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | TI PUCESA | operación; TI | No aprobados. |
| PD-023 | Infraestructura de producción | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | TI PUCESA | visión; operación | No aprobada. |
| PD-024 | Responsables nominales de aprobación | 2026-07-17 | Estabilización | PENDIENTE DE DECISIÓN | PUCESA | stakeholders; RACI | Se mantiene "Responsable institucional por designar". |
| HS-001 | Uso de SGP PUCESA como nombre oficial vigente | 2026-07-17 | Documentación previa | HISTÓRICA/SUSTITUIDA | Equipo del proyecto | README; informes previos | Sustituida por Cato Parking. |
| HS-002 | Uso de InBIO 206 como modelo documental objetivo | 2026-07-17 | Documentación previa | HISTÓRICA/SUSTITUIDA | Equipo del proyecto | README; informes UX/UI; inconsistencias | Sustituida por InBIO 260. |
| HS-003 | Inventario inicial de 600 TAG | 2026-07-17 | Documentación previa | HISTÓRICA/SUSTITUIDA | Equipo del proyecto | SRS; inconsistencias | Sustituida por 1.000 TAG. |
