# Cato Parking

**Subtítulo:** Sistema Institucional de Gestión de Parqueaderos de PUCESA  
**Código documental:** CP-README-001  
**Versión:** 2.1  
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-08-10  
**Autor:** Codex sobre documentación existente del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 2.1 | 2026-08-10 | Corrige navegacion relativa, refleja la estructura vigente e incorpora la nueva capa documental de pruebas. |
| 2.0 | 2026-07-17 | Reestructura el README como fuente de contexto estable; separa prototipo, MVP y sistema completo; consolida nombre oficial e inconsistencias documentales. |
| 1.x | 2026-03 a 2026-04 | Versiones previas del proyecto con mezcla de alcance implementado y visión futura. |

## 1. Identidad oficial

- **Nombre público aprobado:** Cato Parking.
- **Nombre técnico aprobado:** Sistema Institucional de Gestión de Parqueaderos Cato Parking.
- **Institución beneficiaria:** Pontificia Universidad Católica del Ecuador, Sede Ambato (PUCESA).
- **Contexto institucional aprobado:** iniciativa Smart Campus orientada a la gestión de parqueaderos.

Las denominaciones `Sistema de Gestión Multiuso de Parqueadero`, `Sistema de Gestión Multisitio de Parqueaderos`, `Sistema Multi-Parqueadero` y `SGP PUCESA` deben tratarse como denominaciones históricas en documentos anteriores.

## 2. Estado actual del repositorio

Este repositorio contiene dos niveles de realidad técnica que deben leerse por separado:

1. **Prototipo actual de garita**
   - Aplicación local de escritorio en Windows Forms.
   - Persistencia local basada en `tarjetas_autorizadas.json`.
   - Comunicación por TCP/IP con controladora ZKTeco mediante `plcommpro.dll`.
   - Lectura de TAG RFID, autorización local, apertura automática y registro visual de eventos.
   - Apertura manual y control básico operativo.

2. **Documentación del sistema objetivo**
   - Requisitos, propuesta funcional, esquema SQL y visión institucional más amplia.
   - Parte de esta documentación describe capacidades previstas y no debe interpretarse como funcionalidades implementadas.

## 3. Prototipo actual

### 3.1 Funcionalidad implementada observada

Con base en el código fuente actual y el material técnico disponible, el prototipo implementa o evidencia:

- aplicación local de garita para Windows;
- conexión de red con controladora ZKTeco;
- lectura de TAG RFID en tiempo real;
- autorización local con almacenamiento JSON;
- apertura automática cuando el TAG es válido;
- denegación básica cuando el TAG no está registrado o está deshabilitado;
- apertura manual desde la interfaz local;
- anti-rebote básico de lecturas;
- visualización de eventos y mensajes técnicos en tiempo real.

### 3.2 Limitaciones actuales del prototipo

- la persistencia central en SQL Server no está operativa en la aplicación local actual;
- no existe evidencia de integración productiva con Microsoft SSO;
- no existe evidencia de operación productiva del módulo financiero;
- no existe evidencia de portal web funcional integrado con la garita;
- no existe evidencia documental suficiente para declarar operativo el catálogo completo de sanciones, periodos o reportes avanzados.

## 4. Definición formal del MVP

El MVP de Cato Parking valida el control de acceso vehicular y el núcleo mínimo de gestión institucional, sin representar aún el sistema completo.

### 4.1 Alcance incluido en el MVP

- aplicación local de garita operativa en Windows;
- conexión estable con controlador ZKTeco InBIO 260 por TCP/IP con librerías oficiales o compatibles;
- lectura de TAG RFID en tiempo real;
- identificación de punto de lectura como entrada o salida cuando la instalación física lo permita;
- registro básico de TAG, usuario asociado, vehículo asociado y estado;
- activación y desactivación manual de TAG;
- validación básica de autorización;
- apertura automática de barrera;
- denegación por TAG inexistente o deshabilitado;
- apertura manual con motivo obligatorio;
- registro de cada intento de acceso;
- protección contra lecturas repetidas;
- registro básico de eventos técnicos;
- persistencia local funcional para pruebas;
- interfaz mínima de configuración, monitoreo, gestión básica y eventos;
- pruebas físicas documentadas de entrada, salida, autorizaciones, denegaciones y contingencias.

### 4.2 Fuera del MVP

- Microsoft SSO;
- pagos institucionales;
- facturación;
- tarifas variables;
- visitantes con cobro completo;
- sanciones automáticas;
- portal de autoservicio;
- reportes administrativos avanzados;
- aplicación móvil;
- reservas;
- notificaciones institucionales;
- analítica avanzada;
- sincronización productiva completa entre web y garita.

## 5. Visión del sistema completo

La visión objetivo de Cato Parking contempla, de forma modular y no implementada todavía:

- identidad y autenticación institucional;
- usuarios, perfiles y roles;
- administración de múltiples parqueaderos;
- periodos y prioridades por roles o grupos;
- vehículos e inscripciones;
- inventario y ciclo de vida de TAG;
- módulo financiero;
- control de acceso integral;
- visitantes;
- sanciones e incidencias;
- reportes y auditoría;
- configuración;
- integración y sincronización;
- operación y soporte.

La descripción detallada de esta visión se mantiene en [Vision_Sistema_Completo.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Alcance/Vision_Sistema_Completo.md).

## 6. Hardware y validación técnica

### 6.1 Decisión consolidada

El **controlador principal aprobado** para la documentación del proyecto es **ZKTeco InBIO 260**.

### 6.2 Contenido pendiente de validación técnica

Persisten referencias históricas que no deben tomarse como afirmaciones técnicas consolidadas hasta ser verificadas contra el InBIO 260:

- mapeo exacto de `Reader 1` para entrada y `Reader 4` para salida;
- interpretación exacta de eventos `E0`, `E20` y `E27`;
- uso operativo de `LOCK 1` y `LOCK 2`;
- cantidad exacta de puertas, lectores, relés y sensores utilizados;
- compatibilidad exacta de `plcommpro.dll` y `pltcpcomm.dll` con la instalación física objetivo;
- temporización de pulsos y estrategia final de operación offline.

## 7. Inventario inicial planificado

La cifra oficial de planificación documental es:

- **1.000 TAG RFID**

Las referencias a `600 TAG`, cantidades aproximadas o inventarios distintos deben tratarse como inconsistencias históricas o supuestos pendientes de corrección.

## 8. Documentación de gobierno y alcance

Los documentos vigentes del escritorio de garita se concentran en [Documentacion de Escritorio Garita](Documentos/10_Escritorio_Garita/README.md).

- [Identidad_y_Denominacion_Oficial.md](Documentos/10_Escritorio_Garita/00_Gobierno_Documental/Identidad_y_Denominacion_Oficial.md)
- [Registro_Decisiones.md](Documentos/10_Escritorio_Garita/00_Gobierno_Documental/Registro_Decisiones.md)
- [Definicion_MVP.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Alcance/Definicion_MVP.md)
- [Vision_Sistema_Completo.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Alcance/Vision_Sistema_Completo.md)
- [Registro_Stakeholders.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Stakeholders/Registro_Stakeholders.md)
- [Matriz_RACI_Inicial.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Stakeholders/Matriz_RACI_Inicial.md)
- [Registro_Inconsistencias_Documentales.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Control/Registro_Inconsistencias_Documentales.md)
- [Preguntas_Pendientes_PUCESA.md](Documentos/10_Escritorio_Garita/01_Gestion_Proyecto/Control/Preguntas_Pendientes_PUCESA.md)
- [Indice_Maestro_Documentos.md](Documentos/10_Escritorio_Garita/00_Gobierno_Documental/Indice_Maestro_Documentos.md)
- [ERS_Cato_Parking.md](Documentos/10_Escritorio_Garita/02_Requisitos_y_Negocio/ERS_Cato_Parking.md)
- [Documento_Arquitectura_Escritorio_Garita.md](Documentos/10_Escritorio_Garita/03_Arquitectura/Documento_Arquitectura_Escritorio_Garita.md)
- [Modelo_Conceptual.md](Documentos/10_Escritorio_Garita/04_Datos/Modelo_Conceptual.md)
- [Inventario_Vistas.md](Documentos/10_Escritorio_Garita/05_UX_UI/Inventario_Vistas.md)
- [README.md del historico](Documentos/99_Historico/Documentacion_Funcional_Pre_Estabilizacion/README.md)

## 9. Estructura documental relevante

```text
Documentos/
├── 10_Escritorio_Garita/
│   ├── 00_Gobierno_Documental/
│   ├── 01_Gestion_Proyecto/
│   ├── 02_Requisitos_y_Negocio/
│   ├── 03_Arquitectura/
│   ├── 04_Datos/
│   ├── 05_UX_UI/
│   └── 06_Pruebas/
├── 01_Gestion_Proyecto/
├── 02_Requisitos_y_Analisis/
├── 04_Desarrollo/
├── PDF/
├── Imagenes/
└── 99_Historico/
```

## 10. Reglas para esta fase

- no modificar código funcional ni esquema SQL;
- no presentar funcionalidades futuras como implementadas;
- no asumir aprobaciones que no consten en las decisiones consolidadas;
- no eliminar evidencia histórica;
- registrar toda corrección conceptual en el registro de inconsistencias.
