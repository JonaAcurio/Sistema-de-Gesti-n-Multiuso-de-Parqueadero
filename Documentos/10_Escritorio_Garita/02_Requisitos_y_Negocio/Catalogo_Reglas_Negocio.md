# Catalogo de Reglas de Negocio

**Codigo documental:** CP-RN-001  
**Version:** 1.1  
**Estado:** Borrador para validacion institucional  
**Fecha:** 2026-08-18

> “Aprobada” identifica una regla consolidada en el baseline documental. Las reglas que requieren decision de PUCESA permanecen como pendientes; ninguna entrada de este catalogo constituye por si sola aprobacion institucional.

## Convencion de estados

- Aprobada
- Propuesta
- Pendiente de aprobacion
- Historica
- Descartada

## Reglas

### RN-GAR-001 - La operacion de garita requiere configuracion tecnica valida

Descripcion: La garita solo debe operar contra el controlador cuando exista una configuracion local validada.  
Valor actual: Aplicable.  
Tipo: Restriccion.  
Aplica a: Administrador tecnico, soporte tecnico.  
Excepciones: Ninguna.  
Consecuencia: No se habilita la operacion si la prueba de conexion falla.  
Fuente: DA-004, DA-006.  
Estado: Aprobada.  
Requisitos relacionados: RF-CON-001.

### RN-TAG-001 - El identificador del TAG debe ser unico

Descripcion: Un TAG no puede registrarse dos veces en el mismo repositorio operativo.  
Valor actual: Obligatorio.  
Tipo: Integridad.  
Aplica a: Operador de garita, administrador funcional.  
Excepciones: Ninguna.  
Consecuencia: El sistema rechaza el alta duplicada.  
Fuente: Evidencia del prototipo.  
Estado: Aprobada.  
Requisitos relacionados: RF-TAG-001.

### RN-TAG-002 - Todo TAG del MVP debe asociarse al menos con un usuario y un vehiculo

Descripcion: Para el MVP, la autorizacion local se basa en una asociacion minima entre TAG, usuario y vehiculo.  
Valor actual: Obligatorio.  
Tipo: Restriccion.  
Aplica a: Operador de garita.  
Excepciones: Ninguna aprobada.  
Consecuencia: El registro incompleto no debe quedar habilitado para acceso.  
Fuente: DA-007.  
Estado: Aprobada.  
Requisitos relacionados: RF-TAG-001, RF-ACC-001.

### RN-TAG-003 - La desactivacion no elimina historial

Descripcion: Cambiar el estado de un TAG no debe borrar su trazabilidad previa.  
Valor actual: Obligatorio.  
Tipo: Auditoria.  
Aplica a: Operador de garita, administrador funcional.  
Excepciones: Ninguna.  
Consecuencia: El sistema conserva el historial del TAG.  
Fuente: DA-010.  
Estado: Aprobada.  
Requisitos relacionados: RF-TAG-002.

### RN-USR-001 - El registro local de usuario debe contener identificacion operativa minima

Descripcion: La app de escritorio solo debe exigir los datos minimos necesarios para asociar un usuario con vehiculos, TAG y eventos de acceso.  
Valor actual: Obligatorio.  
Tipo: Restriccion operativa.  
Aplica a: Operador de garita.  
Excepciones: Ninguna.  
Consecuencia: No se registran usuarios sin identificacion basica.  
Fuente: DA-020.  
Estado: Aprobada.  
Requisitos relacionados: RF-USR-001.

### RN-VEH-001 - Limite de 2 vehiculos por usuario

Descripcion: Un usuario puede mantener hasta 2 vehiculos asociados dentro del sistema.  
Valor actual: 2 vehiculos.  
Tipo: Restriccion.  
Aplica a: Usuarios institucionales.  
Excepciones: No documentadas en esta fase.  
Consecuencia: El sistema impide una tercera asociacion activa.  
Fuente: DA-022.  
Estado: Aprobada.  
Requisitos relacionados: RF-VEH-001.

### RN-ACC-001 - Solo un TAG activo puede generar una autorizacion positiva

Descripcion: El acceso positivo exige que el TAG exista y este activo.  
Valor actual: Obligatorio.  
Tipo: Restriccion.  
Aplica a: Aplicacion local de garita.  
Excepciones: Apertura manual.  
Consecuencia: El acceso se deniega si el TAG no cumple.  
Fuente: DA-007.  
Estado: Aprobada.  
Requisitos relacionados: RF-ACC-001.

### RN-ACC-002 - Los accesos denegados deben registrarse

Descripcion: Toda denegacion forma parte de la trazabilidad operativa.  
Valor actual: Obligatorio.  
Tipo: Auditoria.  
Aplica a: Aplicacion local de garita.  
Excepciones: Ninguna.  
Consecuencia: No puede haber denegaciones invisibles.  
Fuente: DA-010.  
Estado: Aprobada.  
Requisitos relacionados: RF-ACC-001, RF-ACC-004, RF-AUD-001.

### RN-ACC-003 - La apertura automatica depende de una decision previa registrada

Descripcion: La barrera solo debe recibir orden automatica despues de una autorizacion documentada.  
Valor actual: Obligatorio.  
Tipo: Control.  
Aplica a: Aplicacion local de garita.  
Excepciones: Apertura manual justificada.  
Consecuencia: No debe enviarse apertura sin decision.  
Fuente: DA-007.  
Estado: Aprobada.  
Requisitos relacionados: RF-ACC-002.

### RN-ACC-004 - La topologia de salida debe mantenerse marcada mientras no exista validacion tecnica final

Descripcion: Cualquier regla de salida dependiente de lectores o relays debe conservar estado tecnico verificable.  
Valor actual: Pendiente de ratificacion.  
Tipo: Restriccion tecnica.  
Aplica a: Soporte tecnico, administrador tecnico.  
Excepciones: Ninguna.  
Consecuencia: La documentacion no puede presentar la topologia como definitiva sin validacion.  
Fuente: DT-001.  
Estado: Pendiente de aprobacion.  
Requisitos relacionados: RF-ACC-003.

### RN-ACC-005 - La apertura manual exige motivo obligatorio

Descripcion: Toda apertura manual debe registrar una justificacion antes de ejecutarse.  
Valor actual: Obligatorio.  
Tipo: Auditoria.  
Aplica a: Operador de garita, seguridad.  
Excepciones: Ninguna aprobada.  
Consecuencia: No se envia la orden sin motivo.  
Fuente: DA-014.  
Estado: Aprobada.  
Requisitos relacionados: RF-GAR-001.

### RN-ACC-006 - Las lecturas duplicadas deben filtrarse

Descripcion: Lecturas repetidas del mismo contexto no deben generar eventos funcionales duplicados.  
Valor actual: Obligatorio.  
Tipo: Integridad.  
Aplica a: Aplicacion local de garita.  
Excepciones: Ninguna.  
Consecuencia: Se ignoran lecturas dentro de la ventana de anti-rebote.  
Fuente: Evidencia del prototipo.  
Estado: Aprobada.  
Requisitos relacionados: RF-ACC-005.

### RN-AUD-001 - Toda accion excepcional debe ser auditable

Descripcion: Aperturas manuales, cambios de estado y decisiones criticas deben conservar actor, fecha, hora y motivo.  
Valor actual: Obligatorio.  
Tipo: Auditoria.  
Aplica a: Todos los roles operativos.  
Excepciones: Ninguna.  
Consecuencia: No se admite operacion excepcional sin rastro.  
Fuente: DA-010, DA-014.  
Estado: Aprobada.  
Requisitos relacionados: RF-GAR-001, RF-AUD-001.

### RN-AUD-002 - Los eventos tecnicos forman parte de la evidencia operativa

Descripcion: Errores, desconexiones y reconexiones deben conservarse para soporte y auditoria tecnica.  
Valor actual: Obligatorio.  
Tipo: Auditoria tecnica.  
Aplica a: Aplicacion local, soporte tecnico.  
Excepciones: Ninguna.  
Consecuencia: Deben existir registros tecnicos consultables.  
Fuente: DA-010.  
Estado: Aprobada.  
Requisitos relacionados: RF-GAR-002, RF-SIN-002.

### RN-SIN-001 - La operacion local debe usar datos minimos disponibles durante contingencia

Descripcion: El MVP debe seguir resolviendo accesos con informacion local mientras la contingencia definida lo permita.  
Valor actual: Operacion con cache local y sincronizacion posterior.  
Tipo: Continuidad operativa.  
Aplica a: Aplicacion local.  
Excepciones: Falla total del almacenamiento local.  
Consecuencia: Los accesos se basan en la ultima informacion local disponible.  
Fuente: DA-023, DT-008.  
Estado: Aprobada.  
Requisitos relacionados: RF-SIN-001.

### RN-GAR-002 - Los eventos tecnicos visibles al operador no reemplazan el registro tecnico persistente

Descripcion: Mostrar mensajes en pantalla no basta; debe existir persistencia consultable.  
Valor actual: Obligatorio.  
Tipo: Soporte.  
Aplica a: Aplicacion local, soporte tecnico.  
Excepciones: Ninguna.  
Consecuencia: No se considera cumplido si solo existe feedback visual transitorio.  
Fuente: DA-010.  
Estado: Aprobada.  
Requisitos relacionados: RF-GAR-002.

### RN-GAR-003 - Toda reconexion debe quedar registrada con resultado

Descripcion: Las acciones de recuperacion tecnica deben dejar trazabilidad.  
Valor actual: Obligatorio.  
Tipo: Soporte.  
Aplica a: Soporte tecnico.  
Excepciones: Ninguna.  
Consecuencia: Se registra exito o fallo de reconexion.  
Fuente: DA-023, DT-008.  
Estado: Aprobada.  
Requisitos relacionados: RF-SIN-002.

### RN-SEG-001 - El acceso al sistema completo aplica minimo privilegio

Descripcion: Cada rol debe acceder solo a las funciones necesarias para su tarea.  
Valor actual: Obligatorio.  
Tipo: Seguridad.  
Aplica a: Todos los roles.  
Excepciones: Ninguna aprobada.  
Consecuencia: La matriz de permisos limita funcionalidades.  
Fuente: DA-011.  
Estado: Aprobada.  
Requisitos relacionados: RF-AUT-001.

### RN-PER-001 - Ningun periodo puede publicarse sin fechas validadas

Descripcion: Los periodos de inscripcion requieren fechas consistentes y estado oficial.  
Valor actual: Pendiente de aprobacion institucional.  
Tipo: Restriccion.  
Aplica a: Administrador funcional.  
Excepciones: Ninguna.  
Consecuencia: Se bloquea la publicacion incompleta.  
Fuente: DA-017, PD-001.  
Estado: Pendiente de aprobacion.  
Requisitos relacionados: RF-PER-001.

### RN-PRI-001 - El orden de prioridades debe provenir de PUCESA

Descripcion: El sistema no debe inventar prioridades ni intervalos entre grupos.  
Valor actual: Pendiente de aprobacion institucional.  
Tipo: Politica institucional.  
Aplica a: Administrador funcional.  
Excepciones: Ninguna.  
Consecuencia: Los flujos de inscripcion quedan marcados como pendientes si falta esta decision.  
Fuente: DA-018, PD-002, PD-003.  
Estado: Pendiente de aprobacion.  
Requisitos relacionados: RF-PER-001.

### RN-PAG-001 - Ningun pago puede aprobarse sin reglas financieras vigentes

Descripcion: Las decisiones financieras dependen de tarifas, comprobantes y proceso contable aprobados.  
Valor actual: Pendiente de aprobacion institucional.  
Tipo: Politica financiera.  
Aplica a: Analista financiero.  
Excepciones: Ninguna.  
Consecuencia: El flujo financiero se mantiene como sistema completo pendiente.  
Fuente: DA-016, PD-007, PD-018, PD-019.  
Estado: Pendiente de aprobacion.  
Requisitos relacionados: RF-PAG-001.

### RN-VIS-001 - Toda visita requiere identificacion minima y motivo

Descripcion: El ingreso de visitantes depende de identificar al visitante y el motivo de acceso.  
Valor actual: Pendiente de reglamento.  
Tipo: Politica operativa.  
Aplica a: Operador de garita.  
Excepciones: Pendientes para autoridades o invitados especiales.  
Consecuencia: Sin regla aprobada no debe declararse operativo el modulo de visitantes.  
Fuente: PD-014, PD-016.  
Estado: Pendiente de aprobacion.  
Requisitos relacionados: RF-VIS-001.

## Nota de alcance

Los catalogos de sanciones y su aplicacion formal quedan fuera del alcance funcional propio documentado para esta fase y para la app de escritorio de garita.
