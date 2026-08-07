# Backlog Funcional

**Codigo documental:** CP-BKF-001  
**Version:** 1.0  
**Estado:** Activo  
**Fecha:** 2026-07-17

### HU-ACC-001 - Validacion local de acceso

Como: Aplicacion local de garita.  
Quiero: Validar un TAG activo con informacion local antes de abrir la barrera.  
Para: Autorizar o denegar accesos con trazabilidad.  
Criterios de aceptacion:
1. Solo un TAG existente y activo puede autorizarse.
2. Toda decision deja evento.
3. Un TAG inexistente o desactivado se deniega.
Requisitos relacionados: RF-ACC-001, RF-ACC-004.  
Reglas relacionadas: RN-ACC-001, RN-ACC-002.  
Caso de uso: CU-ACC-001.  
Prioridad: MUST.  
Fase: MVP.  
Estado: Aprobado para desarrollo.

### HU-ACC-002 - Apertura manual justificada

Como: Operador de garita.  
Quiero: Abrir manualmente la barrera registrando el motivo.  
Para: Resolver contingencias sin perder auditoria.  
Criterios de aceptacion:
1. La accion solo esta disponible a perfiles autorizados.
2. El motivo es obligatorio.
3. El evento registra actor, acceso, fecha y hora.
Requisitos relacionados: RF-GAR-001, RF-AUD-001.  
Reglas relacionadas: RN-ACC-005, RN-AUD-001.  
Caso de uso: CU-ACC-003.  
Prioridad: MUST.  
Fase: MVP.  
Estado: Aprobado para desarrollo.

### HU-TAG-001 - Registro basico de TAG

Como: Operador de garita.  
Quiero: Registrar un TAG con su usuario y vehiculo asociados.  
Para: Habilitar la validacion local de accesos.  
Criterios de aceptacion:
1. No se permiten TAG duplicados.
2. El TAG queda con estado inicial visible.
3. El registro incompleto no queda operativo.
Requisitos relacionados: RF-TAG-001.  
Reglas relacionadas: RN-TAG-001, RN-TAG-002.  
Caso de uso: CU-TAG-001.  
Prioridad: MUST.  
Fase: MVP.  
Estado: Aprobado para desarrollo.

### HU-TAG-002 - Cambio de estado de TAG

Como: Operador de garita.  
Quiero: Activar o desactivar un TAG sin perder su historial.  
Para: Controlar autorizaciones vigentes.  
Criterios de aceptacion:
1. El cambio queda auditado.
2. Un TAG desactivado no autoriza accesos.
Requisitos relacionados: RF-TAG-002.  
Reglas relacionadas: RN-TAG-003.  
Caso de uso: CU-TAG-002.  
Prioridad: MUST.  
Fase: MVP.  
Estado: Aprobado para desarrollo.

### HU-GAR-001 - Monitoreo de eventos tecnicos

Como: Soporte tecnico.  
Quiero: Consultar eventos tecnicos y reconexiones.  
Para: Diagnosticar fallas y recuperaciones.  
Criterios de aceptacion:
1. Las desconexiones relevantes quedan registradas.
2. Los intentos de reconexion conservan resultado.
Requisitos relacionados: RF-GAR-002, RF-SIN-002.  
Reglas relacionadas: RN-AUD-002, RN-GAR-003.  
Caso de uso: CU-ACC-005.  
Prioridad: SHOULD.  
Fase: MVP.  
Estado: Pendiente de validacion.

### HU-PAG-001 - Revision de comprobante

Como: Analista financiero.  
Quiero: Aprobar o rechazar comprobantes de pago.  
Para: Determinar el estado de solicitudes institucionales.  
Criterios de aceptacion:
1. Solo financiero decide.
2. Toda decision registra observacion.
Requisitos relacionados: RF-PAG-001.  
Reglas relacionadas: RN-PAG-001.  
Caso de uso: CU-PAG-001.  
Prioridad: SHOULD.  
Fase: Sistema completo.  
Estado: Pendiente de aprobacion institucional.
