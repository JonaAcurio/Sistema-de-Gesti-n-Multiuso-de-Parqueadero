# Modelo de Procesos Cato Parking

**Código documental:** CP-PRO-001
**Versión:** 2.0
**Estado:** Modelo textual para validación
**Fecha:** 2026-08-18

## Alcance y notación

Este documento consolida los procesos que estaban distribuidos en `Procesos_BPMN/`. Los contenidos son flujos textuales editables; no son diagramas ni modelos BPMN formales. La denominación `BPMN` no debe utilizarse para esta capa mientras no exista una representación BPMN real.

Los identificadores `PR-*` se conservan para equivalencias y trazabilidad histórica. Los procesos sujetos a reglas institucionales permanecen explícitamente pendientes.

## PR-01 — Inscripción institucional

**Participantes:** Usuario institucional, Cato Parking, Financiero, Administrador funcional.
**Alcance:** Sistema completo; depende de periodo, prioridades y reglas financieras aprobadas.

**Flujo principal:**

1. Periodo habilitado.
2. Usuario inicia sesión.
3. Registra o selecciona vehículo.
4. Presenta solicitud.
5. El sistema valida condiciones conocidas.
6. Usuario carga comprobante o inicia proceso de pago.
7. Financiero revisa.
8. Administrador funcional asigna cupo o rechaza.
9. El sistema confirma resultado.

**Alternativas:** solicitud incompleta; pago rechazado; cupo agotado.
**Excepciones:** periodo cerrado; prioridades sin aprobar.
**Reglas:** RN-PER-001, RN-PRI-001, RN-PAG-001.
**Casos de uso:** CU-PER-001, CU-PER-002, CU-PAG-001.

## PR-02 — Acceso vehicular institucional

**Participantes:** Vehículo, InBIO 260, aplicación local de garita, operador de garita.
**Alcance:** MVP.

**Flujo principal:** vehículo llega; lector detecta TAG; InBIO 260 emite evento; la aplicación recibe la lectura; valida estado local y reglas; autoriza o deniega; registra evento; abre o mantiene cerrada la barrera.

**Alternativas:** TAG desactivado; lectura duplicada.
**Excepciones:** error de comunicación; topología de salida pendiente de validación.
**Reglas:** RN-ACC-001, RN-ACC-002, RN-ACC-003, RN-ACC-006.
**Casos de uso:** CU-ACC-001, CU-ACC-002, CU-ACC-004.

## PR-03 — Apertura manual

**Participantes:** Operador de garita, Seguridad, Aplicación local, InBIO 260.
**Alcance:** MVP.

**Flujo principal:** solicitar apertura; verificar permiso; exigir motivo; registrar justificación; enviar orden; registrar actor, acceso, fecha y hora.

**Alternativa:** Seguridad ejecuta la acción.
**Excepciones:** usuario sin permiso; motivo ausente; falla de comunicación.
**Reglas:** RN-ACC-005, RN-AUD-001.
**Caso de uso:** CU-ACC-003.

## PR-04 — Pérdida y reposición de TAG

**Participantes:** Usuario institucional, Operador de garita, Administrador funcional, Financiero.
**Alcance:** Pendiente de formalización; no se presenta como núcleo MVP.

**Flujo principal:** usuario reporta pérdida; se desactiva TAG anterior; se valida reposición según reglas vigentes; se registra nuevo TAG; se reasocia al usuario y vehículo.

**Alternativas:** reposición sin costo si PUCESA lo aprueba.
**Excepciones:** costo o política no aprobados.
**Reglas:** RN-TAG-003, RN-PAG-001.
**Casos de uso:** CU-TAG-002, CU-TAG-003.

## PR-05 — Ingreso y salida de visitante

**Participantes:** Visitante, Operador de garita, Seguridad, Cato Parking.
**Alcance:** Sistema completo, pendiente de reglamento.

**Flujo principal:** visitante presenta identificación; operador registra datos, vehículo, motivo y anfitrión; sistema valida reglas; autoriza o deniega ingreso; registra permanencia; autoriza salida.

**Alternativa:** visitante institucional con excepción aprobada.
**Excepciones:** reglas no aprobadas; datos incompletos.
**Regla:** RN-VIS-001.
**Casos de uso:** CU-VIS-001, CU-VIS-002.

## PR-07 y PR-08 — Operación offline y sincronización posterior

**Participantes:** Aplicación local, Operador de garita, Servicio de sincronización, Plataforma central, Soporte técnico.
**Alcance:** MVP para continuidad local y recuperación, con detalles de integración pendientes.

**Operación offline:** detectar indisponibilidad central; mantener operación con datos locales; registrar accesos y eventos; marcar pendientes. Alternativa: operación limitada solo a acceso. Excepción: almacenamiento local no disponible. Regla: RN-SIN-001, RN-AUD-002. Caso: CU-ACC-006.

**Sincronización posterior:** restablecer conectividad; preparar eventos; enviar al servicio central; confirmar recepción; marcar eventos sincronizados. Alternativa: reintento parcial. Excepciones: conflicto de datos; reconexión fallida. Regla: RN-GAR-003. Casos: CU-ACC-005, CU-ACC-006.

## PR-09 — Gestión de periodos y prioridades

**Participantes:** Administrador funcional, Usuario institucional, Cato Parking.
**Alcance:** Sistema completo, pendiente de decisiones institucionales.

**Flujo principal:** registrar periodo; configurar prioridades aprobadas; publicar; usuario presenta solicitud.
**Alternativa:** renovación de periodo previo.
**Excepciones:** fechas inválidas; orden de prioridades no aprobado.
**Reglas:** RN-PER-001, RN-PRI-001.
**Caso:** CU-PER-001.

## PR-10 — Validación financiera

**Participantes:** Usuario institucional, Analista financiero, Cato Parking.
**Alcance:** Sistema completo, pendiente de reglas financieras e integración.

**Flujo principal:** usuario carga comprobante; financiero revisa evidencia; aprueba o rechaza; sistema actualiza estado.
**Alternativa:** solicitar corrección del comprobante.
**Excepciones:** tarifa no aprobada; integración financiera pendiente.
**Regla:** RN-PAG-001.
**Caso:** CU-PAG-001.

## Equivalencias y exclusiones

| Identificador histórico | Tratamiento actual |
| --- | --- |
| PR-01 a PR-05 | Consolidado en este modelo; se conserva su identificación para trazabilidad. |
| PR-06 Sanciones | Historizar; fuera del alcance funcional propio de esta fase. |
| PR-07 y PR-08 | Unificados conceptualmente en la capa de continuidad y sincronización. |
| PR-09 y PR-10 | Se mantienen como subprocesos del flujo institucional futuro, sujetos a aprobación. |
