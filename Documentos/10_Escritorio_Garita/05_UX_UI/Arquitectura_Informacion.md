# Arquitectura de Informacion

**Codigo documental:** CP-UX-101  
**Version:** 1.0  
**Estado:** Borrador derivado de procesos y requisitos  
**Fecha:** 2026-07-17

## Principio

La interfaz se organiza por tareas reales y no por CRUD disperso.

## Areas de informacion

| Area | Tareas principales | Roles |
| --- | --- | --- |
| Operacion de garita | Monitorear acceso, apertura manual, incidentes | GARITA, SEGURIDAD |
| Gestion de credenciales | Registrar TAG, cambiar estado, asociar vehiculo | GARITA, ADMIN_FUNCIONAL |
| Gestion institucional | Periodos, prioridades, roles, cupos | ADMIN_FUNCIONAL |
| Revision financiera | Revisar comprobantes y decisiones | FINANCIERO |
| Soporte tecnico | Conexion, eventos tecnicos, recuperacion | SOPORTE_TECNICO, ADMIN_TECNICO |
| Autoservicio | Solicitudes, estado propio, perfil | USUARIO_INSTITUCIONAL |
