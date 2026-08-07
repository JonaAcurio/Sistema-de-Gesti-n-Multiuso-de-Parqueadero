# Definición del MVP

**Código documental:** CP-ALC-001  
**Versión:** 1.0  
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre insumos existentes del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 1.0 | 2026-07-17 | Primera definición formal, realista y verificable del MVP. |

## 1. Propósito

Establecer el alcance mínimo verificable para validar técnicamente el control de acceso vehicular de Cato Parking en PUCESA, sin confundirlo con la visión completa del sistema.

## 2. Problema

El proyecto cuenta con un prototipo funcional de garita y, al mismo tiempo, con documentación que describe capacidades institucionales más amplias. Esta mezcla impide medir avances, validar prioridades y distinguir entre lo ya implementado, lo mínimo viable y lo previsto para fases posteriores.

## 3. Alcance incluido

El MVP incluye exclusivamente:

- aplicación local de garita operativa en Windows;
- conexión estable con ZKTeco InBIO 260 mediante TCP/IP y librerías oficiales o compatibles;
- lectura en tiempo real de TAG RFID;
- identificación del punto de lectura como entrada o salida cuando la instalación física lo permita;
- registro básico de TAG con código, estado, usuario o propietario asociado, vehículo asociado, observaciones y fecha de registro;
- activación y desactivación manual de TAG;
- validación básica de autorización por existencia, estado y asociación vigente;
- apertura automática de barrera cuando corresponda;
- denegación cuando el TAG no exista o esté deshabilitado;
- apertura manual por operador con motivo obligatorio;
- registro de intentos de acceso con resultado y origen;
- protección contra lecturas repetidas;
- registro básico de eventos técnicos y errores de comunicación;
- persistencia local funcional para pruebas, con transición planificada hacia SQL Server;
- interfaz mínima de configuración, monitoreo, gestión básica de TAG, apertura manual y visualización de eventos;
- pruebas físicas documentadas.

## 4. Exclusiones

Quedan fuera del MVP:

- Microsoft SSO;
- pagos institucionales;
- facturación;
- tarifas variables;
- cobro de visitantes;
- sanciones automáticas;
- portal de autoservicio;
- reportes administrativos avanzados;
- aplicación móvil;
- reservas;
- notificaciones institucionales;
- analítica avanzada;
- integración financiera completa;
- administración integral de periodos;
- priorización productiva por roles;
- sincronización productiva completa entre plataforma web y garita.

## 5. Actores del MVP

- operadores de garita;
- personal de seguridad;
- administradores funcionales del sistema;
- soporte técnico;
- usuarios portadores de TAG autorizados.

## 6. Procesos del MVP

1. Configuración de conexión con el controlador.
2. Registro básico y administración de TAG.
3. Detección de lectura RFID.
4. Validación básica de autorización.
5. Apertura automática o denegación.
6. Apertura manual justificada.
7. Registro técnico y operativo del evento.

## 7. Módulos del MVP

- configuración de hardware y conectividad;
- monitoreo de accesos en tiempo real;
- gestión básica de TAG;
- apertura manual y eventos técnicos;
- persistencia local de prueba.

## 8. Requisitos mínimos

- estación Windows operativa;
- conectividad TCP/IP con el controlador;
- librerías de comunicación disponibles;
- lector RFID instalado y documentado;
- un punto de acceso físico con barrera funcional;
- procedimiento de prueba física documentado;
- respaldo local de los datos de prueba.

## 9. Criterios de éxito

Se considera exitoso el MVP cuando exista evidencia verificable de:

- lectura de TAG autorizada;
- lectura de TAG denegada;
- diferenciación documentada entre entrada y salida, si aplica;
- apertura manual con motivo obligatorio;
- registro de cada intento de acceso;
- anti-rebote funcional;
- detección de desconexión y reconexión;
- persistencia local recuperable durante pruebas.

## 10. Criterios de cierre

El MVP podrá declararse completado cuando:

- las pruebas físicas mínimas estén ejecutadas y documentadas;
- la documentación de alcance y decisiones esté estabilizada;
- no existan contradicciones entre README, SRS, formularios y Task List respecto al MVP;
- las dependencias técnicas pendientes estén identificadas y separadas de la visión futura.

## 11. Dependencias

- validación técnica del InBIO 260;
- disponibilidad física del hardware y red local;
- definición mínima del procedimiento operativo de garita;
- confirmación de la topología física de lectores y barreras;
- soporte institucional para pruebas controladas.

## 12. Riesgos

- persistencia de contradicciones documentales sobre hardware y alcance;
- dependencia de librerías y configuraciones no formalizadas;
- ausencia de validación técnica de algunos eventos y comandos;
- interpretación incorrecta del prototipo como producto final institucional;
- falta de responsables nominales confirmados por PUCESA.

## 13. Relación con el prototipo actual

El prototipo actual es la base técnica más cercana al MVP, pero no equivale por sí solo al MVP aprobado. El MVP exige una definición verificable, criterios de éxito explícitos y separación clara frente al sistema completo.
