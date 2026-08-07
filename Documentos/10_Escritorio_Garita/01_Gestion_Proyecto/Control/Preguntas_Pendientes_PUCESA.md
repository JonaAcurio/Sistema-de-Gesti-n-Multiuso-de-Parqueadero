# Preguntas Pendientes para PUCESA

**Código documental:** CP-CTL-002  
**Versión:** 1.1  
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre insumos existentes del proyecto  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 1.1 | 2026-07-18 | Ajusta pendientes al alcance real del escritorio de garita y a la parametrización administrativa externa. |
| 1.0 | 2026-07-17 | Consolidación inicial de preguntas institucionales pendientes. |

## 1. Autoridades

- ¿Cuál es la unidad que aprobará formalmente el alcance del sistema?
- ¿Existe un reglamento oficial vigente para parqueaderos o debe emitirse uno nuevo?
- ¿Qué excepciones institucionales deben existir para autoridades u otros perfiles especiales?

## 2. TI y plataforma central

- ¿Cuál será la infraestructura objetivo de producción?
- ¿Se autoriza Microsoft SSO en una fase posterior y bajo qué lineamientos técnicos?
- ¿Qué política institucional de respaldo y recuperación aplicará a los servidores centrales?

## 3. Parametrización administrativa

- ¿Qué valores administrativos deberán ser editables desde la plataforma central o administrativa?
- ¿Qué controles de auditoría deberán aplicarse cuando se modifiquen cupos, espacios, precios, tarifas o parámetros operativos?
- ¿Qué parámetros deberán sincronizarse hacia la app de escritorio para la operación local?

## 4. Operación institucional

- ¿Cuántos parqueaderos formarán parte del alcance inicial?
- ¿Qué horarios operativos deben aplicarse por parqueadero?
- ¿Qué eventos de acceso deben escalarse formalmente a seguridad institucional?

## 5. Garita y hardware

- ¿Qué reglas de contingencia aplican cuando falle el controlador o la red?
- ¿Qué datos mínimos debe registrar el operador en cada incidente?
- ¿Qué tiempos y condiciones deben activar un modo de contingencia local?
- ¿La topología final usa exactamente Reader 1 para entrada y Reader 4 para salida?
- ¿Qué cantidad exacta de puertas, lectores, relés y sensores se utilizará?
- ¿Está formalmente validada la compatibilidad de `plcommpro.dll` y `pltcpcomm.dll` con el InBIO 260 instalado?
- ¿Dónde se encuentra el documento oficial `Marca_Cato_Parking.docx` y la evidencia técnica oficial del hardware?

## 6. Usuarios y web

- ¿Cómo se reflejará en la plataforma web el límite de 2 vehículos por usuario?
- ¿Cómo se priorizarán estudiantes, docentes y administrativos en periodos?
- ¿Qué necesidades diferenciales existen para grupos con atención prioritaria?

## 7. Datos personales

- ¿Qué política de retención de datos aplicará a accesos, auditoría y pagos?
- ¿Qué datos personales pueden almacenarse en la base central y por cuánto tiempo?
- ¿Qué responsables institucionales custodiarán estos datos?

## 8. Sincronización y operación

- ¿Qué datos mínimos deben viajar en la cola de sincronización entre escritorio y servidores centrales?
- ¿Cuál será el mecanismo oficial de sincronización entre garita y plataforma central?
- ¿Qué indicadores de operación deben monitorearse?
