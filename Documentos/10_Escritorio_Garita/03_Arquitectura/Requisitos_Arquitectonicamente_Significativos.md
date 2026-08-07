# Requisitos Arquitectonicamente Significativos

**Codigo documental:** CP-ARQ-303  
**Version:** 1.0  
**Fecha:** 2026-07-18

| ID | Tipo | Requisito | Impacto arquitectonico |
| --- | --- | --- | --- |
| RAS-001 | Disponibilidad | Operacion local sin internet | Obliga a cache y persistencia local |
| RAS-002 | Rendimiento | Decidir acceso en baja latencia | Obliga a no depender del backend en tiempo real |
| RAS-003 | Integridad | No duplicar eventos | Obliga a UUID e idempotencia |
| RAS-004 | Auditoria | Trazabilidad de aperturas manuales y accesos | Obliga a eventos auditables separados |
| RAS-005 | Hardware | Integracion estable con InBIO 260 | Obliga a adaptador tecnico encapsulado |
| RAS-006 | Recuperacion | Reconexion y reenvio tras caida | Obliga a cola persistente y reintentos |
| RAS-007 | Seguridad | Proteccion de credenciales y configuracion | Obliga a cifrado y control local por rol |
| RAS-008 | Escalabilidad | Evolucion a multiples garitas | Obliga a identidad de dispositivo y sincronizacion desacoplada |
