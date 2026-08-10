# ERS Cato Parking

**Codigo documental:** CP-ERS-001  
**Version:** 1.2  
**Estado:** Borrador formal para validacion institucional  
**Fecha:** 2026-08-10

## 1. Control documental

- Sustituye funcionalmente a `02_Requisitos_y_Analisis/Plantillas/Plantilla_IEEE830_Parqueadero.md`.
- Usa como fuentes `README.md`, `Registro_Decisiones.md`, `Registro_Stakeholders.md`, `Preguntas_Pendientes_PUCESA.md` y evidencia observable del prototipo local.

## 2. Introduccion

Esta ERS describe que debe hacer Cato Parking, quien puede hacerlo, bajo que condiciones y como se demostrara el cumplimiento de cada requisito.

## 3. Proposito

Servir como base aprobable para arquitectura, datos, interfaces, planificacion, desarrollo, pruebas y aceptacion institucional.

## 4. Alcance del documento

Incluye MVP y sistema completo, diferenciados por un campo explicito de alcance.

## 5. Alcance del producto

- MVP: operacion local de garita, lectura RFID, validacion basica, apertura automatica, apertura manual auditada, altas basicas de usuarios y TAG, registro de entradas y salidas, reportes operativos y cache local con sincronizacion posterior.
- Sistema completo: autenticacion, periodos, pagos, visitantes, reportes institucionales, sincronizacion y administracion ampliada.

## 6. Relacion entre prototipo, MVP y sistema completo

- Prototipo: lo observable hoy en la app local Windows Forms.
- MVP: lo minimo que debe quedar completamente definido y verificable.
- Sistema completo: vision funcional institucional que puede conservar parametros pendientes.

## 7. Definiciones y glosario

Aplican las definiciones de `Glosario_Cato_Parking.md`.

## 8. Referencias

- `README.md`
- `Registro_Decisiones.md`
- `Registro_Stakeholders.md`
- `Preguntas_Pendientes_PUCESA.md`
- `Definicion_MVP.md`
- `Vision_Sistema_Completo.md`

## 9. Stakeholders

Los stakeholders formales estan en `Registro_Stakeholders.md`. Los que aprueban decisiones funcionales criticas son PUCESA, TI, Administracion, Seguridad y Financiero.

## 10. Actores del sistema

- Usuario institucional
- Operador de garita
- Personal de seguridad
- Analista financiero
- Administrador funcional
- Administrador tecnico
- Soporte tecnico
- Visitante
- Sistema Microsoft SSO
- Aplicacion local de garita
- Plataforma web
- Controlador InBIO 260
- Servicio de sincronizacion

## 11. Contexto operacional

- La garita opera en Windows con comunicacion hacia el controlador local.
- El MVP debe poder decidir accesos aun sin servicios centrales.
- El MVP se concentra principalmente en la operacion local de garita, incluyendo la conexion con hardware, la gestion operativa minima de usuarios, vehiculos y TAG, el control de entradas y salidas, la auditoria basica y los mecanismos de continuidad local necesarios para dicha operacion.
- El sistema completo agrega servicios web e integraciones institucionales.

## 12. Supuestos y dependencias

- La topologia final del hardware sera validada por responsables tecnicos.
- PUCESA debe aprobar responsables nominales y politicas institucionales de datos.
- Los valores administrativos fluctuantes se administraran como parametros configurables y no como constantes fijas en esta ERS.
- El MVP no depende de SQL productivo para quedar definido documentalmente.

## 13. Restricciones

- No asumir reglamento aprobado donde no exista evidencia.
- No declarar implementado el sistema completo.
- No eliminar documentos historicos.
- No usar valores financieros o sancionatorios no aprobados como hechos.
- No incorporar como alcance propio catalogos de sanciones ajenos al equipo actual.

## 14. Modulos funcionales

- Autenticacion y perfiles
- Usuarios y vehiculos
- TAG RFID
- Control de acceso
- Garita y operacion local
- Periodos e inscripciones
- Pagos
- Visitantes
- Reportes y auditoria
- Configuracion y sincronizacion

## 15. Requisitos funcionales

### RF-CON-001 - Configurar conexion con InBIO 260

Modulo: Configuracion  
Alcance: MVP  
Descripcion: El sistema debe permitir registrar y validar la configuracion minima de conexion local hacia el controlador antes de iniciar la operacion.  
Actor principal: Administrador tecnico  
Actores secundarios: Soporte tecnico, InBIO 260  
Precondiciones:
- El equipo local se encuentra encendido.
- Existe direccion de red del controlador.
Entradas:
- IP
- Puerto
- Timeout
Proceso:
1. Registrar parametros.
2. Probar conectividad.
3. Mostrar resultado.
4. Guardar configuracion valida.
Resultado exitoso: La aplicacion queda lista para operar con el controlador.  
Resultados alternativos:
- Parametros invalidos.
- Controlador no responde.
Reglas relacionadas: RN-GAR-001  
Datos relacionados: configuracion_local, controlador  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-004, DA-006  
Criterios de aceptacion:
- CA-RF-CON-001-01: la prueba de conexion indica exito o error en pantalla.
- CA-RF-CON-001-02: la configuracion valida queda persistida localmente.

### RF-TAG-001 - Registrar TAG con datos minimos

Modulo: TAG RFID  
Alcance: MVP  
Descripcion: El sistema debe permitir registrar un TAG con codigo, estado, usuario asociado, vehiculo asociado y observaciones basicas.  
Actor principal: Operador de garita  
Actores secundarios: Administrador funcional  
Precondiciones:
- El operador esta autenticado localmente.
- El TAG no existe previamente.
Entradas:
- Identificador del TAG
- Usuario
- Vehiculo
- Observaciones
Proceso:
1. Capturar datos.
2. Validar unicidad local.
3. Crear registro activo.
Resultado exitoso: El TAG queda disponible para validacion de accesos.  
Resultados alternativos:
- TAG duplicado.
- Datos incompletos.
Reglas relacionadas: RN-TAG-001, RN-TAG-002  
Datos relacionados: tag, usuario, vehiculo  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-007, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-TAG-001-01: no se permite guardar un TAG duplicado.
- CA-RF-TAG-001-02: el estado inicial del TAG queda registrado.

### RF-USR-001 - Registrar usuario basico para operacion local

Modulo: Usuarios  
Alcance: MVP  
Descripcion: El sistema debe permitir registrar la informacion basica de un usuario necesaria para asociarlo con un TAG y controlar sus accesos locales.  
Actor principal: Operador de garita  
Actores secundarios: Administrador funcional  
Precondiciones:
- El operador dispone de los datos minimos requeridos.
Entradas:
- Identificador institucional o local
- Nombres
- Apellidos
- Estado
Proceso:
1. Capturar datos basicos.
2. Validar existencia previa.
3. Registrar usuario.
Resultado exitoso: El usuario queda disponible para asociacion local con vehiculos y TAG.  
Resultados alternativos:
- Usuario duplicado.
- Datos incompletos.
Reglas relacionadas: RN-USR-001  
Datos relacionados: usuario  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-020  
Criterios de aceptacion:
- CA-RF-USR-001-01: no se permite crear el mismo usuario dos veces en el repositorio local.
- CA-RF-USR-001-02: el usuario queda disponible para asociaciones operativas.

### RF-VEH-001 - Registrar vehiculo y asociarlo a un usuario

Modulo: Vehiculos  
Alcance: MVP  
Descripcion: El sistema debe permitir registrar un vehiculo y asociarlo a un usuario para habilitar el control local de acceso.  
Actor principal: Operador de garita  
Actores secundarios: Administrador funcional  
Precondiciones:
- El usuario existe en el sistema local.
Entradas:
- Placa
- Tipo de vehiculo
- Usuario asociado
Proceso:
1. Capturar datos del vehiculo.
2. Validar que la placa no exista.
3. Asociar el vehiculo al usuario.
4. Registrar la operacion.
Resultado exitoso: El vehiculo queda habilitado para asociarse con un TAG y participar en validaciones de acceso.  
Resultados alternativos:
- Placa duplicada.
- Usuario inexistente.
- Limite de vehiculos excedido.
Reglas relacionadas: RN-VEH-001  
Datos relacionados: vehiculo, usuario  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-020, DA-022  
Criterios de aceptacion:
- CA-RF-VEH-001-01: no se registra una placa duplicada.
- CA-RF-VEH-001-02: el sistema impide superar el limite de vehiculos por usuario.

### RF-TAG-002 - Activar o desactivar TAG

Modulo: TAG RFID  
Alcance: MVP  
Descripcion: El sistema debe permitir cambiar el estado operativo de un TAG sin eliminar su historial.  
Actor principal: Operador de garita  
Actores secundarios: Administrador funcional  
Precondiciones:
- El TAG existe.
Entradas:
- Identificador del TAG
- Nuevo estado
Proceso:
1. Buscar TAG.
2. Validar existencia.
3. Cambiar estado.
4. Registrar la accion.
Resultado exitoso: El TAG cambia de estado y conserva trazabilidad.  
Resultados alternativos:
- TAG inexistente.
Reglas relacionadas: RN-TAG-003  
Datos relacionados: tag, auditoria  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-007, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-TAG-002-01: un TAG desactivado no es autorizado.
- CA-RF-TAG-002-02: el cambio queda visible para auditoria.

### RF-ACC-001 - Validar acceso mediante TAG activo

Modulo: Control de acceso  
Alcance: MVP  
Descripcion: El sistema debe validar el TAG detectado antes de emitir una orden de apertura.  
Actor principal: Aplicacion local de garita  
Actores secundarios: Operador de garita, InBIO 260  
Precondiciones:
- El controlador esta conectado.
- Existe informacion local disponible.
Entradas:
- Identificador del TAG
- Punto de acceso
- Fecha y hora
Proceso:
1. Recibir lectura.
2. Identificar TAG.
3. Consultar estado local.
4. Determinar autorizacion.
5. Registrar decision.
Resultado exitoso: El acceso queda autorizado y registrado.  
Resultados alternativos:
- TAG inexistente.
- TAG desactivado.
- Lectura duplicada.
- Error de comunicacion.
Reglas relacionadas: RN-ACC-001, RN-ACC-002  
Datos relacionados: tag, vehiculo, usuario, punto_acceso, evento_acceso  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-007, DA-008, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-ACC-001-01: un TAG activo y existente produce una decision registrada.
- CA-RF-ACC-001-02: un TAG inexistente no abre la barrera.

### RF-ACC-002 - Autorizar entrada

Modulo: Control de acceso  
Alcance: MVP  
Descripcion: El sistema debe emitir una orden de apertura para una entrada autorizada.  
Actor principal: Aplicacion local de garita  
Actores secundarios: InBIO 260  
Precondiciones:
- Existe un resultado autorizado.
Entradas:
- Decision de acceso
- Punto de entrada
Proceso:
1. Verificar autorizacion.
2. Enviar orden de apertura.
3. Registrar evento.
Resultado exitoso: La barrera recibe una orden de apertura y el evento queda como autorizado.  
Resultados alternativos:
- Fallo de envio.
- Controlador desconectado.
Reglas relacionadas: RN-ACC-003  
Datos relacionados: evento_acceso, controlador  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-007, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-ACC-002-01: la orden solo se envia cuando la decision es autorizada.
- CA-RF-ACC-002-02: el resultado queda registrado con fecha y hora.

### RF-ACC-003 - Autorizar salida

Modulo: Control de acceso  
Alcance: MVP  
Descripcion: El sistema debe procesar la salida autorizada considerando la topologia fisica aprobada.  
Actor principal: Aplicacion local de garita  
Actores secundarios: InBIO 260  
Precondiciones:
- Existe un TAG autorizado para salida.
Entradas:
- Lectura del TAG
- Punto de salida
Proceso:
1. Validar TAG.
2. Evaluar reglas de salida.
3. Emitir orden.
4. Registrar evento.
Resultado exitoso: La salida queda autorizada y auditada.  
Resultados alternativos:
- Lectura no autorizada.
- Topologia sin validar.
Reglas relacionadas: RN-ACC-004  
Datos relacionados: evento_acceso, punto_acceso  
Prioridad: MUST  
Estado: Aprobado con validacion tecnica pendiente  
Fuente: DA-008, DT-001, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-ACC-003-01: la salida solo se registra como autorizada si existe decision valida.
- CA-RF-ACC-003-02: la topologia usada debe quedar documentada como validada o pendiente.

### RF-ACC-004 - Denegar acceso no autorizado

Modulo: Control de acceso  
Alcance: MVP  
Descripcion: El sistema debe impedir la apertura y registrar la denegacion cuando no se cumplan las condiciones de acceso.  
Actor principal: Aplicacion local de garita  
Actores secundarios: Operador de garita  
Precondiciones:
- Existe una lectura o solicitud de acceso.
Entradas:
- Identificador del TAG
- Resultado de validacion
Proceso:
1. Detectar incumplimiento.
2. No emitir apertura.
3. Registrar motivo.
Resultado exitoso: El acceso queda denegado y trazado.  
Resultados alternativos:
- Error de lectura.
Reglas relacionadas: RN-ACC-002  
Datos relacionados: evento_acceso, auditoria  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-007, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-ACC-004-01: un TAG inexistente genera denegacion registrada.
- CA-RF-ACC-004-02: un TAG desactivado genera denegacion registrada.

### RF-GAR-001 - Abrir barrera manualmente con motivo obligatorio

Modulo: Garita  
Alcance: MVP  
Descripcion: El sistema debe permitir apertura manual solo a perfiles autorizados y con motivo obligatorio.  
Actor principal: Operador de garita  
Actores secundarios: Personal de seguridad, InBIO 260  
Precondiciones:
- El actor tiene permiso de apertura manual.
Entradas:
- Punto de acceso
- Motivo
- Observacion
Proceso:
1. Solicitar apertura manual.
2. Validar permiso.
3. Exigir motivo.
4. Enviar orden.
5. Registrar evento auditable.
Resultado exitoso: La barrera se abre y queda trazabilidad completa.  
Resultados alternativos:
- Usuario sin permiso.
- Motivo vacio.
- Falla de comunicacion.
Reglas relacionadas: RN-ACC-005, RN-AUD-001  
Datos relacionados: apertura_manual, auditoria, incidente  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-010, DA-014, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-GAR-001-01: la accion no se ejecuta sin motivo.
- CA-RF-GAR-001-02: el registro conserva actor, acceso, fecha, hora y motivo.

### RF-AUD-001 - Registrar cada intento de acceso

Modulo: Auditoria  
Alcance: MVP  
Descripcion: El sistema debe registrar cada intento de acceso con su resultado y origen.  
Actor principal: Aplicacion local de garita  
Actores secundarios: Operador de garita  
Precondiciones:
- Existe una lectura o accion manual.
Entradas:
- Fecha y hora
- Tipo de evento
- TAG o referencia
- Resultado
Proceso:
1. Construir evento.
2. Persistirlo localmente.
3. Mostrarlo al operador cuando corresponda.
Resultado exitoso: El evento queda disponible para consulta y futura sincronizacion.  
Resultados alternativos:
- Error de persistencia local.
Reglas relacionadas: RN-AUD-001, RN-AUD-002  
Datos relacionados: evento_acceso, evento_tecnico, auditoria  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-010, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-AUD-001-01: todo acceso autorizado o denegado deja evento.
- CA-RF-AUD-001-02: toda apertura manual deja evento.

### RF-GAR-002 - Registrar eventos tecnicos

Modulo: Garita  
Alcance: MVP  
Descripcion: El sistema debe registrar errores, desconexiones y mensajes tecnicos relevantes para soporte.  
Actor principal: Aplicacion local de garita  
Actores secundarios: Soporte tecnico  
Precondiciones:
- La aplicacion se encuentra operativa.
Entradas:
- Tipo de mensaje
- Fecha y hora
- Contexto tecnico
Proceso:
1. Detectar evento tecnico.
2. Clasificarlo.
3. Persistirlo.
4. Exponerlo para diagnostico.
Resultado exitoso: El evento tecnico queda disponible para soporte.  
Resultados alternativos:
- Error de persistencia.
Reglas relacionadas: RN-GAR-002, RN-AUD-002  
Datos relacionados: evento_tecnico  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-010, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-GAR-002-01: las desconexiones relevantes quedan registradas.
- CA-RF-GAR-002-02: los eventos son consultables por soporte.

### RF-ACC-005 - Filtrar lecturas duplicadas

Modulo: Control de acceso  
Alcance: MVP  
Descripcion: El sistema debe ignorar lecturas repetidas dentro de una ventana de anti-rebote definida para evitar aperturas o registros duplicados.  
Actor principal: Aplicacion local de garita  
Actores secundarios: InBIO 260  
Precondiciones:
- Existe una lectura previa reciente del mismo TAG en el mismo contexto.
Entradas:
- TAG
- Fecha y hora
- Punto de acceso
Proceso:
1. Comparar con lectura reciente.
2. Determinar si cae en anti-rebote.
3. Ignorar o procesar.
Resultado exitoso: El sistema evita duplicidad funcional y auditora.  
Resultados alternativos:
- Ventana no configurada.
Reglas relacionadas: RN-ACC-006  
Datos relacionados: evento_acceso  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-ACC-005-01: una lectura duplicada no vuelve a abrir la barrera.
- CA-RF-ACC-005-02: la lectura ignorada puede dejar evidencia tecnica.

### RF-SIN-001 - Operar con almacenamiento local

Modulo: Sincronizacion  
Alcance: MVP  
Descripcion: El sistema debe poder operar con datos locales minimos cuando no dependan de servicios centrales.  
Actor principal: Aplicacion local de garita  
Actores secundarios: Soporte tecnico  
Precondiciones:
- Existe almacenamiento local accesible.
Entradas:
- Datos de TAG
- Eventos de acceso
Proceso:
1. Cargar datos locales.
2. Resolver accesos con informacion disponible.
3. Persistir resultados locales.
Resultado exitoso: La operacion local continua durante la contingencia definida.  
Resultados alternativos:
- Almacenamiento no disponible.
Reglas relacionadas: RN-SIN-001  
Datos relacionados: tag, evento_acceso, cola_sincronizacion  
Prioridad: MUST  
Estado: Aprobado para MVP  
Fuente: DA-006, DT-008, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-SIN-001-01: el sistema puede validar con datos locales cargados.
- CA-RF-SIN-001-02: los eventos generados quedan pendientes de sincronizacion si aplica.

### RF-SIN-002 - Recuperarse de una desconexion

Modulo: Sincronizacion  
Alcance: MVP  
Descripcion: El sistema debe permitir retomar la comunicacion local con el controlador y continuar registrando eventos despues de una desconexion.  
Actor principal: Soporte tecnico  
Actores secundarios: Aplicacion local de garita, InBIO 260  
Precondiciones:
- Existio una desconexion previa.
Entradas:
- Solicitud de reconexion
Proceso:
1. Detectar estado desconectado.
2. Intentar reconexion.
3. Confirmar nuevo estado.
4. Registrar resultado.
Resultado exitoso: La aplicacion vuelve a intercambiar eventos con el controlador.  
Resultados alternativos:
- Reconexion fallida.
Reglas relacionadas: RN-GAR-003  
Datos relacionados: evento_tecnico, controlador  
Prioridad: SHOULD  
Estado: Aprobado para MVP  
Fuente: DT-008, evidencia del prototipo  
Criterios de aceptacion:
- CA-RF-SIN-002-01: el operador puede identificar si la reconexion fue exitosa.
- CA-RF-SIN-002-02: el intento queda registrado.

### RF-AUT-001 - Iniciar sesion con Microsoft SSO

Modulo: Autenticacion  
Alcance: Sistema completo  
Descripcion: El sistema debe permitir autenticacion institucional mediante Microsoft SSO.  
Actor principal: Usuario institucional  
Actores secundarios: Sistema Microsoft SSO  
Precondiciones:
- La integracion institucional fue aprobada.
Entradas:
- Credenciales institucionales
Proceso:
1. Redirigir al proveedor.
2. Validar respuesta.
3. Obtener perfil.
Resultado exitoso: El usuario inicia sesion con identidad institucional valida.  
Resultados alternativos:
- Token invalido.
- Usuario sin perfil habilitado.
Reglas relacionadas: RN-SEG-001  
Datos relacionados: usuario, sesion, rol  
Prioridad: SHOULD  
Estado: Pendiente de validacion institucional  
Fuente: DA-011  
Criterios de aceptacion:
- CA-RF-AUT-001-01: solo perfiles autorizados acceden al sistema.
- CA-RF-AUT-001-02: los errores de autenticacion son informados sin exponer secretos.

### RF-PER-001 - Publicar periodo de inscripcion

Modulo: Periodos e inscripciones  
Alcance: Sistema completo  
Descripcion: El sistema debe permitir crear y publicar un periodo con fechas y prioridades aprobadas.  
Actor principal: Administrador funcional  
Actores secundarios: Usuario institucional  
Precondiciones:
- Existen parametros institucionales aprobados.
Entradas:
- Nombre del periodo
- Fechas
- Prioridades
Proceso:
1. Registrar periodo.
2. Validar integridad.
3. Publicarlo.
Resultado exitoso: El periodo queda habilitado para solicitudes.  
Resultados alternativos:
- Fechas invalidas.
- Prioridades incompletas.
Reglas relacionadas: RN-PER-001, RN-PRI-001  
Datos relacionados: periodo, prioridad  
Prioridad: SHOULD  
Estado: Pendiente de validacion institucional  
Fuente: DA-017, DA-018, PD-001, PD-002, PD-003  
Criterios de aceptacion:
- CA-RF-PER-001-01: no puede publicarse un periodo con fechas inconsistentes.
- CA-RF-PER-001-02: el estado del periodo es visible para los actores relevantes.

### RF-PAG-001 - Aprobar pago institucional

Modulo: Pagos  
Alcance: Sistema completo  
Descripcion: El sistema debe permitir revisar y aprobar o rechazar un comprobante de pago asociado con una solicitud.  
Actor principal: Analista financiero  
Actores secundarios: Usuario institucional  
Precondiciones:
- Existe una solicitud con comprobante cargado.
Entradas:
- Solicitud
- Comprobante
- Decision
Proceso:
1. Revisar comprobante.
2. Aprobar o rechazar.
3. Registrar observacion.
Resultado exitoso: La solicitud cambia a estado aprobado o rechazado.  
Resultados alternativos:
- Comprobante ilegible.
- Parametros de tarifa pendientes.
Reglas relacionadas: RN-PAG-001  
Datos relacionados: solicitud, pago, comprobante  
Prioridad: SHOULD  
Estado: Pendiente de validacion institucional  
Fuente: DA-016, PD-007, PD-018, PD-019  
Criterios de aceptacion:
- CA-RF-PAG-001-01: solo el rol financiero puede aprobar o rechazar.
- CA-RF-PAG-001-02: la decision queda asociada a observaciones y fecha.

### RF-VIS-001 - Registrar visitante y su vehiculo

Modulo: Visitantes  
Alcance: Sistema completo  
Descripcion: El sistema debe permitir registrar un visitante, su vehiculo, motivo y anfitrion antes de autorizar el ingreso.  
Actor principal: Operador de garita  
Actores secundarios: Visitante  
Precondiciones:
- Existen reglas de visitantes vigentes.
Entradas:
- Identificacion
- Vehiculo
- Motivo
- Anfitrion
Proceso:
1. Capturar datos.
2. Validar reglas aplicables.
3. Registrar visita.
Resultado exitoso: La visita queda lista para autorizarse o denegarse.  
Resultados alternativos:
- Datos incompletos.
- Regla no aprobada.
Reglas relacionadas: RN-VIS-001  
Datos relacionados: visitante, vehiculo, visita  
Prioridad: COULD  
Estado: Pendiente de validacion institucional  
Fuente: PD-014  
Criterios de aceptacion:
- CA-RF-VIS-001-01: no se registra una visita sin identificacion minima.
- CA-RF-VIS-001-02: la visita queda asociada a un motivo y anfitrion cuando aplique.

## 16. Requisitos no funcionales

Se detallan formalmente en `Requisitos_No_Funcionales.md`.

## 17. Interfaces externas

- Controlador ZKTeco InBIO 260
- Lectores RFID
- Plataforma web del sistema completo
- Microsoft SSO

## 18. Reglas de negocio relacionadas

Se detallan en `Catalogo_Reglas_Negocio.md`.

## 19. Requisitos de datos

- El MVP requiere como minimo TAG, usuario asociado, vehiculo asociado, estados y eventos.
- El sistema completo agregara solicitud, periodo, pago, visitante, rol y auditoria extendida.

## 20. Matriz de prioridad

- MUST: requisitos del MVP indispensables para control de acceso.
- SHOULD: requisitos del sistema completo priorizados para una fase posterior.
- COULD: requisitos dependientes de reglamentos o decisiones aun no cerradas.

## 21. Criterios generales de aceptacion

- Todo requisito debe tener fuente, alcance y criterio verificable.
- Ninguna decision pendiente puede declararse como aprobada.
- Todo requisito MVP debe poder probarse contra evidencia tecnica o documental.

## 22. Exclusiones

- Rediseno de SQL y arquitectura.
- Cierre de valores institucionales aun pendientes.
- Declaracion de produccion operativa del sistema completo.

## 23. Preguntas pendientes

Aplican las preguntas de `Preguntas_Pendientes_PUCESA.md`, en especial responsables nominales, politicas de datos, infraestructura central y sincronizacion.

## 24. Historial de cambios

| Version | Fecha | Descripcion |
| --- | --- | --- |
| 1.2 | 2026-08-10 | Sincroniza control documental y corrige la formulacion del alcance del MVP para alinearlo con los RF vigentes. |
| 1.1 | 2026-07-18 | Ajusta alcance al escritorio de garita, agrega usuarios y vehiculos basicos, y excluye sanciones. |
| 1.0 | 2026-07-17 | Creacion de la ERS formal de Fase 2. |
