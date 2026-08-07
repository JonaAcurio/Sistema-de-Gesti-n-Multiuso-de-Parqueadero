# Documento de Arquitectura del Escritorio de Garita

**Codigo documental:** CP-ARQ-301  
**Version:** 1.0  
**Estado:** Borrador tecnico de Fase 3  
**Fecha:** 2026-07-18

## 1. Proposito

Definir la arquitectura tecnica de referencia de la aplicacion de escritorio de garita de Cato Parking y sus fronteras de integracion con la plataforma central.

## 2. Alcance

Este documento cubre:

- aplicacion local de garita;
- almacenamiento local;
- control de hardware InBIO 260;
- operacion offline;
- sincronizacion con servicios centrales;
- observabilidad tecnica y operativa;
- seguridad local y de integracion;
- despliegue del nodo de garita.

No cubre el diseno interno completo de la plataforma web central.

## 3. Contexto

La aplicacion actual de escritorio valida hardware y flujo basico de acceso, pero concentra demasiadas responsabilidades en una sola capa. La arquitectura objetivo separa interfaz, casos de uso, dominio e infraestructura para permitir evolucion tecnica controlada.

## 4. Requisitos arquitectonicamente significativos

- operacion local sin dependencia inmediata de internet;
- decision de acceso de baja latencia;
- persistencia local antes de perder eventos;
- sincronizacion idempotente con el servidor central;
- separacion de logs tecnicos, eventos operativos y auditoria;
- integracion encapsulada con InBIO 260;
- configuracion externa;
- soporte para multiples accesos fisicos y futura extension a multiples garitas.

## 5. Restricciones

- la apertura de barrera no puede depender del servidor central;
- la base local no debe ser una copia indiscriminada de la base central;
- Microsoft SSO pertenece a la plataforma institucional, no al nodo local de acceso;
- el escritorio no administra tarifas, sanciones ni reglas institucionales amplias;
- el comportamiento del InBIO 260 solo se da por validado cuando exista evidencia tecnica verificable.

## 6. Principios arquitectonicos

- operacion local autonoma;
- persistencia antes de perdida;
- integraciones mediante adaptadores;
- reglas operativas separadas de la interfaz;
- configuracion externa y auditable;
- idempotencia por defecto en sincronizacion;
- minimo privilegio;
- degradacion controlada ante fallos.

## 7. Vista de contenedores

- Aplicacion de Escritorio de Garita
- Base Local de Garita
- Cola Local de Sincronizacion
- API Central Versionada
- Base Central de Plataforma
- Microsoft SSO como dependencia de la plataforma central
- Controlador ZKTeco InBIO 260

## 8. Vista de componentes de la garita

- UI de Operacion
- Coordinador de Casos de Uso
- Motor de Autorizacion Operativa
- Adaptador InBIO 260
- Repositorio Local
- Cola Persistente de Sincronizacion
- Cliente API de Sincronizacion
- Registro Tecnico
- Registro Operativo
- Gestor de Configuracion

## 9. Responsabilidades por componente

| Componente | Responsabilidad principal |
| --- | --- |
| UI de Operacion | Mostrar estado, eventos, errores y comandos manuales |
| Coordinador de Casos de Uso | Orquestar lectura, validacion, apertura, persistencia y sincronizacion |
| Motor de Autorizacion Operativa | Aplicar reglas locales minimas de acceso |
| Adaptador InBIO 260 | Encapsular DLL, eventos, comandos y estados de conexion |
| Repositorio Local | Persistir datos operativos y lecturas locales |
| Cola Persistente | Mantener eventos pendientes hasta confirmacion central |
| Cliente API | Enviar eventos y recibir cambios o configuracion |
| Registro Tecnico | Errores, reconexiones, latencias y fallos |
| Registro Operativo | Accesos, aperturas, denegaciones y movimientos |
| Gestor de Configuracion | Parametros del controlador, endpoints, tiempos y modo de operacion |

## 10. Comunicaciones

- InBIO 260 -> Adaptador InBIO -> Coordinador de Casos de Uso
- Coordinador -> Motor de Autorizacion -> Repositorio Local
- Coordinador -> Adaptador InBIO para apertura o no apertura
- Coordinador -> Registro Operativo y Cola Persistente
- Servicio de Sincronizacion -> API Central versionada

## 11. Datos

La fuente de verdad administrativa es la plataforma central. La fuente de verdad operativa temporal es la base local de garita para eventos, cache operativa y estado de sincronizacion.

## 12. Operacion offline

El nodo local debe seguir validando accesos con cache operativa, registrar eventos y reintentar sincronizacion en segundo plano. La estrategia completa se detalla en `Estrategia_Operacion_Offline.md`.

## 13. Seguridad

- autenticacion tecnica por dispositivo para integracion;
- credenciales cifradas localmente;
- segregacion entre configuracion, operacion y soporte;
- bitacora de aperturas manuales y cambios sensibles.

## 14. Despliegue

El escritorio se ejecuta en un equipo Windows de garita con acceso de red al InBIO 260 y conectividad hacia la API central cuando este disponible.

## 15. Riesgos principales

- dependencia de DLL propietarias;
- comportamiento no validado de eventos o relays;
- reloj local inconsistente;
- corrupcion de cola local;
- duplicados por reconexion o reenvio;
- mezcla de logica operativa con interfaz.

## 16. Decisiones tecnologicas iniciales

- aplicacion local .NET para Windows;
- base local ligera y persistente;
- SQL Server central como almacenamiento institucional;
- API versionada para sincronizacion;
- UUID para eventos de acceso;
- auditoria separada de logs tecnicos.

## 17. Trazabilidad

Este documento responde principalmente a RF-CON-001, RF-USR-001, RF-VEH-001, RF-TAG-001, RF-ACC-001, RF-GAR-001, RF-AUD-001, RF-GAR-002, RF-ACC-005, RF-SIN-001 y RF-SIN-002.
