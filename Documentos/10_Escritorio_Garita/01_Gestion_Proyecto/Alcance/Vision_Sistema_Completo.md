# Visión del Sistema Completo

**Código documental:** CP-ALC-002  
**Versión:** 1.0  
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre insumos existentes del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 1.0 | 2026-07-17 | Formalización de la visión objetivo modular del sistema completo. |

## 1. Visión objetivo

Cato Parking evolucionará hacia una solución institucional centralizada para administrar uno o varios parqueaderos de PUCESA, combinando operación local en garita, plataforma institucional, base de datos central e integraciones aprobadas por la universidad.

> Nota de separación documental:
>
> Este documento se conserva dentro de la carpeta del escritorio solo como frontera de integración y visión de contexto.
> La especificación formal de la plataforma web deberá mantenerse en una carpeta documental independiente.

## 2. Arquitectura conceptual

La arquitectura objetivo contempla los siguientes componentes:

- plataforma institucional central;
- base de datos central;
- aplicación local de garita;
- controladores y lectores de hardware;
- servicios de autenticación institucional;
- mecanismos de sincronización y auditoría.

## 3. Módulos previstos

### SC-01. Identidad y autenticación institucional

- Microsoft SSO;
- gestión de sesión;
- creación o sincronización de perfiles;
- control por roles y permisos.

### SC-02. Usuarios, perfiles y roles

- estudiantes;
- docentes;
- administrativos;
- financieros;
- garita;
- seguridad;
- administradores;
- soporte;
- autoridades o perfiles especiales.

### SC-03. Parqueaderos

- múltiples parqueaderos;
- capacidad;
- ubicación;
- accesos;
- barreras;
- lectores;
- horarios;
- espacios reservados;
- estados operativos.

### SC-04. Periodos

- creación;
- configuración;
- vigencia;
- apertura y cierre;
- prioridades por rol;
- fechas escalonadas;
- cupos;
- renovaciones;
- excepciones.

### SC-05. Vehículos

- registro;
- asociación con propietarios;
- límite institucional;
- validación de placa;
- estados;
- historial.

### SC-06. Solicitudes e inscripciones

- solicitud de uso;
- revisión;
- aprobación;
- rechazo;
- observaciones;
- asignación;
- renovación;
- cancelación.

### SC-07. Inventario y ciclo de vida de TAG

- inventario inicial de 1.000 unidades;
- disponible;
- reservado;
- asignado;
- activo;
- suspendido;
- perdido;
- dañado;
- dado de baja;
- repuesto.

### SC-08. Financiero

- tarifas;
- comprobantes;
- validación;
- pagos;
- estados de pago;
- facturación o vinculación con el proceso institucional correspondiente;
- reposición de TAG;
- reportes financieros.

### SC-09. Control de acceso

- entradas;
- salidas;
- autorización;
- ocupación;
- horarios;
- vigencia;
- sanciones;
- apertura manual;
- operación local;
- contingencias.

### SC-10. Visitantes

- registro temporal;
- vehículo;
- motivo de visita;
- responsable o anfitrión;
- ingreso;
- salida;
- cálculo o cobro cuando corresponda;
- excepciones institucionales aprobadas.

### SC-11. Sanciones e incidencias

- catálogo de infracciones;
- niveles;
- evidencias;
- vigencia;
- suspensión;
- revisión o apelación si PUCESA lo aprueba;
- historial.

### SC-12. Reportes

- accesos;
- ocupación;
- usuarios;
- vehículos;
- TAG;
- pagos;
- sanciones;
- incidencias;
- aperturas manuales;
- auditoría.

### SC-13. Auditoría

- acciones críticas;
- cambios;
- usuario responsable;
- fecha y hora;
- valor anterior;
- valor nuevo;
- origen.

### SC-14. Configuración

- parámetros;
- prioridades;
- fechas;
- horarios;
- tarifas;
- límites;
- reglas de acceso;
- equipos.

### SC-15. Integración y sincronización

- plataforma web;
- base de datos central;
- aplicación local de garita;
- hardware;
- Microsoft SSO;
- servicios institucionales aprobados.

### SC-16. Operación y soporte

- monitoreo;
- respaldos;
- contingencias;
- recuperación;
- mantenimiento;
- gestión de incidentes.

## 4. Actores

- autoridades de PUCESA;
- Smart Campus;
- TI institucional;
- administración de parqueaderos;
- seguridad institucional;
- operadores de garita;
- unidad financiera;
- administradores funcionales;
- soporte técnico;
- estudiantes;
- docentes;
- personal administrativo;
- visitantes.

## 5. Procesos generales

- autenticación institucional;
- registro y administración de usuarios;
- inscripción y asignación de parqueaderos;
- registro y asociación de vehículos;
- gestión del inventario de TAG;
- validación de pagos y estados;
- autorización de acceso y auditoría;
- gestión de visitantes e incidencias;
- generación de reportes.

## 6. Integraciones previstas

- Microsoft SSO;
- base de datos central institucional;
- plataforma web;
- aplicación local de garita;
- hardware ZKTeco y periféricos aprobados;
- servicios institucionales y financieros aprobados.

## 7. Restricciones

- no presentar esta visión como estado implementado;
- no asumir integraciones financieras automáticas sin aprobación;
- no fijar reglas de prioridad, tarifas, reglamentos o sanciones sin validación institucional;
- no sustituir reglamentos formales por documentos promocionales o ejemplos.

## 8. Fases posteriores

- formalización institucional de reglas de negocio;
- validación técnica integral del hardware;
- consolidación del modelo de datos central;
- diseño e implementación de la plataforma web;
- integraciones institucionales aprobadas;
- despliegue productivo y soporte operativo.

## 9. Exclusiones aún no aprobadas

Las siguientes capacidades pueden existir como propuestas, pero no están aprobadas para ejecución en esta fase:

- automatización financiera completa;
- tiempos definitivos entre prioridades;
- tarifas y excepciones finales;
- reglamento oficial y sanciones definitivas;
- políticas finales de retención de datos;
- infraestructura productiva final;
- niveles de disponibilidad y continuidad formalmente comprometidos.
