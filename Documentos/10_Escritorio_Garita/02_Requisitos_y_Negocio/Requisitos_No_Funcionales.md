# Requisitos No Funcionales

**Codigo documental:** CP-RNF-001  
**Version:** 1.1  
**Estado:** Borrador para validacion institucional  
**Fecha:** 2026-07-17

## Rendimiento

### RNF-REN-001 - Tiempo maximo de decision local

Descripcion: El tiempo entre una lectura RFID valida y el envio de la orden de apertura no debe exceder 1,5 segundos en el MVP.  
Estado: Pendiente de validacion mediante prueba fisica.  
Fuente: Propuesta de Fase 2.

## Disponibilidad

### RNF-DIS-001 - Horario operativo documentado

Descripcion: El sistema debe declarar explicitamente el horario de operacion aprobado por parqueadero.  
Estado: Parametrizable fuera del alcance fijo del escritorio.  
Fuente: DA-021.

### RNF-DIS-002 - Continuidad local minima

Descripcion: Durante contingencias de servicios centrales, la aplicacion local debe mantener operacion con datos locales mientras el equipo y el controlador permanezcan disponibles.  
Estado: Aprobado internamente.  
Fuente: DA-023, DT-008.

## Operacion offline

### RNF-OFF-001 - Datos minimos locales

Descripcion: El nodo local debe disponer al menos de configuracion, TAG habilitados, asociaciones minimas y cola de eventos para operar offline.  
Estado: Aprobado internamente.  
Fuente: RF-SIN-001.

### RNF-OFF-002 - Recuperacion de eventos pendientes

Descripcion: Los eventos generados offline deben quedar marcados para futura sincronizacion y no perder su secuencia temporal.  
Estado: Aprobado internamente.  
Fuente: DA-023, DT-008.

## Seguridad

### RNF-SEG-001 - Minimo privilegio

Descripcion: Cada rol solo puede ejecutar acciones expresamente autorizadas en la matriz de permisos.  
Estado: Aprobado internamente.  
Fuente: RN-SEG-001.

### RNF-SEG-002 - Gestion de secretos externos

Descripcion: Credenciales de integracion o parametros sensibles no deben quedar hardcodeados en documentacion operativa final.  
Estado: Pendiente de diseno tecnico posterior.  
Fuente: Buenas practicas y validacion TI.

## Integridad

### RNF-INT-001 - No duplicar eventos funcionales por rebote

Descripcion: Una misma lectura en ventana de anti-rebote no debe generar dos autorizaciones funcionales.  
Estado: Aprobado internamente.  
Fuente: RN-ACC-006.

### RNF-INT-002 - No perder trazabilidad de acciones manuales

Descripcion: Toda apertura manual debe conservar actor, momento, acceso y motivo.  
Estado: Aprobado internamente.  
Fuente: RN-AUD-001.

## Respaldo y recuperacion

### RNF-REC-001 - RPO institucional declarado

Descripcion: La documentacion del sistema completo debe registrar el RPO aprobado por TI PUCESA.  
Estado: Pendiente de aprobacion institucional.  
Fuente: PD-022.

### RNF-REC-002 - RTO institucional declarado

Descripcion: La documentacion del sistema completo debe registrar el RTO aprobado por TI PUCESA.  
Estado: Pendiente de aprobacion institucional.  
Fuente: PD-022.

## Usabilidad

### RNF-USA-001 - Registro de visitante medible

Descripcion: Un operador capacitado debe registrar una visita regular en un maximo de 8 pasos una vez definidos los datos obligatorios.  
Estado: Pendiente de reglamento de visitantes.  
Fuente: Propuesta de Fase 2.

### RNF-USA-002 - Apertura manual sin ambiguedad

Descripcion: El flujo de apertura manual debe exigir motivo visible antes de habilitar la confirmacion.  
Estado: Aprobado internamente.  
Fuente: RF-GAR-001.

## Mantenibilidad

### RNF-MAN-001 - Configuracion externa identificable

Descripcion: Los parametros operativos del controlador deben ser localizables y modificables sin recompilar en la version objetivo posterior al prototipo.  
Estado: Pendiente de evolucion tecnica.  
Fuente: Propuesta de Fase 2.

### RNF-MAN-002 - Logging consultable

Descripcion: La operacion debe dejar registros funcionales y tecnicos distinguibles para soporte y auditoria.  
Estado: Aprobado internamente.  
Fuente: RF-AUD-001, RF-GAR-002.

## Compatibilidad

### RNF-COM-001 - Entorno Windows

Descripcion: El nodo de garita del MVP debe ejecutarse en Windows, coherente con la aplicacion local observada.  
Estado: Aprobado internamente.  
Fuente: Evidencia del prototipo.

### RNF-COM-002 - Compatibilidad de hardware validada

Descripcion: La documentacion del MVP no debe afirmar compatibilidad final del InBIO 260 sin validacion tecnica formal.  
Estado: Aprobado internamente.  
Fuente: DT-005.

## Privacidad

### RNF-PRI-001 - Politica de retencion declarada

Descripcion: Los tiempos de retencion para accesos, auditoria y pagos deben quedar explicitados antes de produccion institucional.  
Estado: Pendiente de aprobacion institucional.  
Fuente: PD-020.
