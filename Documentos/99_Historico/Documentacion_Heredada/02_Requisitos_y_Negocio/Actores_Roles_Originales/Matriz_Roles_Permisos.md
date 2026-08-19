# Matriz de Roles y Permisos

**Codigo documental:** CP-RLP-001  
**Version:** 1.0  
**Estado:** Borrador para validacion institucional  
**Fecha:** 2026-07-17

| Funcionalidad o permiso | Admin funcional | Financiero | Garita | Seguridad | Usuario institucional | Soporte tecnico | Admin tecnico |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Consultar usuario | Si | Limitado | Limitado | Limitado | Propio | No | Limitado |
| Registrar TAG | Si | No | Si | No | No | No | No |
| Cambiar estado TAG | Si | No | Si | No | No | No | No |
| Consultar accesos | Si | Parcial | Si | Si | Propio | Tecnico | Parcial |
| Abrir manualmente | Configurable | No | Si | Si | No | Diagnostico | No |
| Registrar motivo de apertura manual | Si | No | Si | Si | No | Diagnostico | No |
| Consultar auditoria | Si | Parcial | Propia | Parcial | No | Tecnica | Tecnica |
| Consultar eventos tecnicos | No | No | Si | Parcial | No | Si | Si |
| Configurar conexion local | No | No | No | No | No | Si | Si |
| Reintentar reconexion | No | No | No | No | No | Si | Si |
| Aprobar pago | No | Si | No | No | No | No | No |
| Rechazar pago | No | Si | No | No | No | No | No |
| Configurar periodo | Si | No | No | No | No | No | No |
| Asignar rol | Si | No | No | No | No | No | Si |
| Exportar reporte | Si | Parcial | No | Parcial | No | Tecnico | Tecnico |

## Notas

- `Configurable` significa que PUCESA debe ratificar si el rol conserva o delega esa accion.
- `Propio` significa acceso exclusivo a datos asociados con el mismo usuario.
- `Tecnico` significa acceso orientado a soporte y diagnostico, no a operacion funcional.
