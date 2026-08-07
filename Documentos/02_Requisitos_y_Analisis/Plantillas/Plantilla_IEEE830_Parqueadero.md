# Especificación de Requisitos de Software

> Estado actual: documento sustituido para Fase 2.  
> La fuente vigente es `Documentos/02_Requisitos_y_Negocio/ERS_Cato_Parking.md`.  
> Este archivo se conserva como historico y no debe seguir parchandose como ERS activa.

**Sistema:** Sistema Institucional de Gestión de Parqueaderos Cato Parking  
**Código documental:** CP-SRS-001  
**Versión:** 2.0  
**Estado:** Borrador estabilizado para validación institucional  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre documentación existente del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 2.0 | 2026-07-17 | Reescritura estabilizada de la SRS con separación entre prototipo, MVP y sistema completo. |
| 1.x | 2026-02 a 2026-03 | Versiones previas con mezcla de propuestas, datos nominales y reglas no aprobadas. |

## 1. Introducción

### 1.1 Propósito

Definir una base estabilizada de requisitos para Cato Parking, diferenciando:

- decisiones aprobadas;
- requisitos del MVP;
- visión del sistema completo;
- pendientes de validación institucional o técnica.

### 1.2 Identidad del sistema

- **Nombre público:** Cato Parking.
- **Nombre técnico:** Sistema Institucional de Gestión de Parqueaderos Cato Parking.
- **Institución:** Pontificia Universidad Católica del Ecuador, Sede Ambato (PUCESA).
- **Contexto:** iniciativa Smart Campus.

### 1.3 Alcance documental

Esta SRS no declara como implementadas las funcionalidades futuras. El documento distingue expresamente entre:

- **prototipo actual:** aplicación local de garita existente;
- **MVP:** núcleo mínimo validable de control de acceso;
- **sistema completo:** visión objetivo modular institucional.

## 2. Glosario mínimo

- **TAG RFID:** credencial física utilizada para identificación vehicular.
- **Garita:** punto operativo local de control de acceso.
- **MVP:** producto mínimo viable para validar el núcleo técnico y operativo.
- **SSO:** autenticación institucional Microsoft prevista para el sistema completo.
- **PUCESA:** Pontificia Universidad Católica del Ecuador, Sede Ambato.

## 3. Contexto del producto

### 3.1 Prototipo actual

El repositorio evidencia una aplicación local Windows Forms con persistencia JSON y comunicación con controladora ZKTeco. Esta base no debe confundirse con una plataforma institucional completa.

### 3.2 Alcance del MVP

El MVP cubre únicamente:

- operación local de garita;
- lectura de TAG;
- validación básica de autorización;
- apertura automática y manual;
- registro de eventos y persistencia local de pruebas.

### 3.3 Visión del sistema completo

El sistema completo contempla autenticación institucional, usuarios, parqueaderos, periodos, financiero, visitantes, sanciones, reportes, auditoría, configuración e integraciones.

## 4. Stakeholders y actores

Los stakeholders institucionales se documentan formalmente en [Registro_Stakeholders.md](/E:/a/Documentos/01_Gestion_Proyecto/Stakeholders/Registro_Stakeholders.md).

Actores generales reconocidos:

- estudiantes;
- docentes;
- personal administrativo;
- personal de seguridad;
- operadores de garita;
- visitantes;
- autoridades;
- personal financiero;
- administradores del sistema;
- personal de tecnología o soporte.

## 5. Restricciones y decisiones consolidadas

- El controlador documental objetivo es **ZKTeco InBIO 260**.
- El inventario inicial de planificación es **1.000 TAG RFID**.
- No se asume reglamento oficial aprobado en esta fase.
- No se asume integración financiera automática aprobada.
- No se asume que categorías de usuarios equivalgan automáticamente a roles de software.

## 6. Supuestos y dependencias

### 6.1 Supuestos técnicos

- la red local permitirá la comunicación entre la aplicación y el controlador;
- las librerías de comunicación estarán disponibles para pruebas;
- la topología física de lectores y barreras podrá documentarse.

### 6.2 Dependencias

- validación técnica del hardware;
- confirmación institucional de periodos, cupos y tarifas;
- designación de responsables institucionales;
- políticas de seguridad y datos de PUCESA.

## 7. Requisitos funcionales del MVP

| ID | Requisito | Estado | Observación |
| --- | --- | --- | --- |
| RF-MVP-01 | Configurar conexión local con el controlador | Requerido para MVP | Debe existir interfaz mínima y evidencia de conexión. |
| RF-MVP-02 | Leer TAG RFID en tiempo real | Requerido para MVP | Parte del núcleo técnico. |
| RF-MVP-03 | Registrar TAG con datos básicos | Requerido para MVP | Código, estado, usuario, vehículo, observaciones y fecha. |
| RF-MVP-04 | Activar y desactivar TAG manualmente | Requerido para MVP | Parte de la administración mínima. |
| RF-MVP-05 | Validar autorización básica | Requerido para MVP | TAG registrado, activo, asociación vigente y vehículo autorizado. |
| RF-MVP-06 | Abrir barrera automáticamente | Requerido para MVP | Solo ante autorización válida. |
| RF-MVP-07 | Denegar acceso básico | Requerido para MVP | TAG inexistente o deshabilitado. |
| RF-MVP-08 | Abrir manualmente con motivo obligatorio | Requerido para MVP | Debe registrar operador, fecha, acceso, motivo y observación. |
| RF-MVP-09 | Registrar cada intento de acceso | Requerido para MVP | Debe almacenar fecha, tipo, TAG, usuario, vehículo, resultado y origen. |
| RF-MVP-10 | Evitar lecturas repetidas | Requerido para MVP | Protección anti-rebote. |
| RF-MVP-11 | Registrar eventos técnicos | Requerido para MVP | Errores y comunicación. |

## 8. Requisitos funcionales del sistema completo

| ID | Requisito | Estado | Observación |
| --- | --- | --- | --- |
| RF-SC-01 | Autenticación Microsoft SSO | Previsto para sistema completo | No forma parte del MVP. |
| RF-SC-02 | Gestión central de usuarios, perfiles y roles | Previsto para sistema completo | Matriz final pendiente. |
| RF-SC-03 | Administración de múltiples parqueaderos | Previsto para sistema completo | Visión objetivo aprobada. |
| RF-SC-04 | Gestión de periodos y prioridades | Previsto para sistema completo | Fechas y orden pendientes. |
| RF-SC-05 | Gestión institucional de vehículos | Previsto para sistema completo | Límites definitivos pendientes. |
| RF-SC-06 | Solicitudes e inscripciones | Previsto para sistema completo | Flujo final pendiente de aprobación. |
| RF-SC-07 | Inventario central de TAG | Previsto para sistema completo | Ciclo de vida completo. |
| RF-SC-08 | Módulo financiero | Previsto para sistema completo | No aprobado a nivel de reglas finales. |
| RF-SC-09 | Visitantes | Previsto para sistema completo | Reglas pendientes. |
| RF-SC-10 | Sanciones | Previsto para sistema completo | Catálogo y reglamento pendientes. |
| RF-SC-11 | Reportes y auditoría | Previsto para sistema completo | Alcance detallado posterior. |
| RF-SC-12 | Integración web y sincronización | Previsto para sistema completo | No implementado en esta fase. |

## 9. Requisitos no funcionales estabilizados

| ID | Requisito | Estado | Observación |
| --- | --- | --- | --- |
| RNF-01 | Trazabilidad de accesos y aperturas manuales | Requerido para MVP | Debe existir registro verificable. |
| RNF-02 | Operación local durante pruebas | Requerido para MVP | Persistencia local funcional. |
| RNF-03 | Registro de eventos técnicos | Requerido para MVP | Debe apoyar diagnóstico. |
| RNF-04 | Disponibilidad objetivo institucional | Pendiente de decisión | Valor pendiente de aprobación. |
| RNF-05 | Integración con SSO | Previsto para sistema completo | No parte del MVP. |
| RNF-06 | Respaldo y recuperación institucional | Pendiente de decisión | Depende de TI PUCESA. |

## 10. Pendientes de validación

- topología exacta del hardware InBIO 260;
- periodos, prioridades, cupos y límites finales;
- reglas financieras y de visitantes;
- reglamento y sanciones;
- infraestructura productiva;
- responsables nominales.
