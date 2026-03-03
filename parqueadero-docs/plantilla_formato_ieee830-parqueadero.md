# Especification de requisitos de software

Proyecto: Sistema de Gestion Multisitio de

Parqueaderos

Revision: 1.0

# Ficha del documento

<table><tr><td>Fecha</td><td>Revisión</td><td>Autor</td><td>Aprobación</td></tr><tr><td>23/02/2026</td><td>1.0</td><td>Carlos Parreño
Jonathan Acurio</td><td></td></tr></table>

Documento validado por las partes en fecha: 23/02/2026

<table><tr><td>Por el cliente</td><td>Por laEmpresa suministradora</td></tr><tr><td></td><td></td></tr><tr><td>Fdo. D./Dña</td><td>Fdo. D./Dña</td></tr></table>

# Contidente

# 1 Introduccion

El propósito de este documento es definir la Especficación de Requisitos de Software (SRS) para el nuevo Sistema de Gestión Multi-Parqueadero Institucional. Este sistemas permitirá administrar de forma centralizada la asignación de espacios de estacioncimiento, controlar los accesós fisicos mediante TAG, gestionar cobros (fijos y por hora/fracción), validar+pagos y aplicarreglasdenegocioincluyendo sanionesparadistinctosperfilesde la comunidad universitaria.

# 1.1 Alcance

El sistema a deserollar contempla:

- La administración de multíplies parqueaderos físicos con numeroación individual y capacité variable.   
#   
- La gestion de usuario y roles diferenciados (Administrator, Financiero, Control/Garita, Docente, Estudiante, Administrativo, Visitante).   
#   
- El registrar y control de vehículos (limitado a un máximo de 2 por usuario institucional).   
#   
- La gestion del inventario de credenciales de acceso (aproximamente 600 TAGs iniciales).   
•   
- La integración con hardware de control de acceso (plumas mecánicas y lectores de TAG).   
#   
- La integrazione con plataformas externas: inizio de sesión unico (Microsoft SSO) y flujo de validacion de pagar (transferencias y efectivo).   
#   
- Un modulopleteo de reportes, auditoria y aplicacion automatica de sanaciones por mal uso.

# 1.2 Personal involucrado

1.2.1 Gestor del Proyecto   

<table><tr><td>Nombre</td><td>Dennys Coronel</td></tr><tr><td>Categoría profesional</td><td>Docente</td></tr><tr><td>Responsabilitades</td><td>Gestor de proyectos</td></tr><tr><td>Información de contacto</td><td>099 512 0616</td></tr></table>

1.2.2 Cliente/Stakeholders   

<table><tr><td>Nombre</td><td></td></tr><tr><td>Categoría profesional</td><td></td></tr><tr><td>Responsibilidades</td><td></td></tr><tr><td>Información de contacto</td><td></td></tr></table>

1.2.3 Equipo de Desarrollo   

<table><tr><td>Nombre</td><td>Carlos Ortega</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsabilitades</td><td></td></tr><tr><td>Información de contacto</td><td>096 909 9790</td></tr></table>

<table><tr><td>Nombre</td><td>Jeremy Jacome</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsabilitades</td><td></td></tr><tr><td>Información de contacto</td><td>099 540 8705</td></tr></table>

<table><tr><td>Nombre</td><td>Jonathan Acurio</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsabilitades</td><td></td></tr><tr><td>Información de contacto</td><td>0 96 341 0492</td></tr></table>

<table><tr><td>Nombre</td><td>Sebastian Sanmartin</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsabilitades</td><td></td></tr><tr><td>Información de contacto</td><td>096 711 0610</td></tr><tr><td>Nombre</td><td>Sebastian Falconi</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsabilitades</td><td></td></tr><tr><td>Información de contacto</td><td>098 194 7131</td></tr></table>

<table><tr><td>Nombre</td><td>David Ojeda</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsables</td><td></td></tr><tr><td>Información de contacto</td><td>098 250 0589</td></tr></table>

<table><tr><td>Nombre</td><td>Carlos Parreño</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsables</td><td>Levantimiento de requisimientos</td></tr><tr><td>Información de contacto</td><td>099 972 0694</td></tr></table>

<table><tr><td>Nombre</td><td>Nancy Chango</td></tr><tr><td>Categoría profesional</td><td>Estudiante</td></tr><tr><td>Responsables</td><td>Levantimiento de requisimientos</td></tr><tr><td>Información de contacto</td><td>0984493463</td></tr></table>

# 1.3 Definuciones, acrónimos y abreviaturas

- TAG: Etiqueta o dispositivo electrónico RFID utilizdo para la identificación vehicular.   
SSO: Single Sign-On (Inicio de sesión únicos), utilizing credenciales de Microsoft instituciones.   
- Pluma: Brazo mecánico o barreraFsicautilizada enlas entradas ysalidas de los parqueaderos.   
- MoSCoW:该如何 prioritizaciones de requisitos (MUST: Debe tener, SHOULD: Debería tener, COULD: Podría tener, WON'T: No tendrá por ahora).   
CA: Criterio de Acepación.

# 1.4 Resumen

El resto de este documento detalla la perspectiva del producto, las caracteristicas de los usuario, las reglas de trabajo principals y, finalmente, el desglose pormenorizo de los requisitos sociales y no funciona estrucurados mediante prioridades MoSCoW.

# 2 Descripción general

# 2.1 Perspectiva del producto

El sistemas actuará como el nucleo central para la gestión vehicular de la institución, interactuando activamente con el ecosistema technologicalo actual. Depend del directorio activo de Microsoft para la autenticación, del personal Financiero para la validación manual/semiautomática de transferencias, y del hardware de los parqueaderos para aperturas fisicas e identificacion mediante TAGs.

# 2.2 Funcorialidad del producto

- Autenticación restringida a correos instituciones mediante Microsoft SSO.   
- CRUD de vehículos por usuario institucional (limite estricto de 2 placas, excepto para administrador que no dispone de limite).   
- Gestión de reservas, periodos activos y validación de comprobantes de pago.   
- Control de acces bajo en franjas horarias, vigencia, saniones y cupos disponibles.   
- Gestión de inventario de TAGs (asignación, bloqueos, perdidas).   
- Módulo de cobro a visitantes en efectivo (calculo por hora/fracción).   
- Trazabilidad completa y reportes analíticos para administración y finanzas.

# 2.3 Characteristicas de los usuario

- Administrador del sistema: Configuración global del multisitio, auditoría completa, reportes y gestion de permisos, gestion de tarifas (fijas y variables), reportes de ingresos.   
- Financiero: Gestion de tarifas (fijas y variables), revisión/validación de comprobantes de+pagos(transferencias),envio de facturas correspondientes y reportes de ingresos   
- Garita: Operación de ingresso/salida, aperture manual con auditoría, cobro en efectivo a visitantes y registrar de incidencias.   
- Docente: Nombre de los permittos de la calidad de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittos de los permittOS.

Docente tiempoocompleteo   
Docente tiempo parcial

- Estudiante: Nombre institucional sujejo a validacion de pagos y franjas horarias (máximo 2 placas).   
- Administrativo: Nombre institucional con Beneficio de horario extendido para uso de parqueadero todo el día (máximo 2 placas).   
- Visitante: Nombre no registrado en el Sistema institucional. Genera cobro por hora o refracción pagadero únicamente en efectivo al salir.   
- Visitantes Alto Nivel: Se debe definircottos lugares se le asignan. Este tipo de usuario no paga ninguna tarifa.

# 2.4 Restricciones

- El pago de visitantes require un manejo en efectivo controlado exclusivamente en garita, sin integrazione a la pasarela digital de transferencias.   
- Queda eliminado por completeo el uso de tarjetas físicas antiguas, migrando al lote de TAGs nuevos.   
- La aperture manual de las plumasrequireiráobligatoriamenteel registrarde un motivoauditable.

# 2.5 Suppositories y dependencies

- Se asume la disponibilitad y estabilitad del serviceo SSO de Microsoft.   
- Se asume que el hardware en situ (plumas新业态) está corRECTamente configurado para recibir peteciones del sistema.

# 2.6 Reglas de Negocio (RB)

<table><tr><td>ID</td><td>Regla de Negocio</td><td>Prioridad</td></tr><tr><td>RB-01</td><td>El sistema debe soportarmultiples parqueaderos (multisitio), cada uno con capacité yreglas configurables.</td><td>MUST</td></tr><tr><td>RB-02</td><td>Cada parqueaderodebesoperun numero del espacios configurable y Estados (disponible/ocupado/reservado/fuera de serviceo).</td><td>MUST</td></tr><tr><td>RB-03</td><td>El registrar/renovacion institucional solo sehabilitadentrode fechas de un periodo activo (activador por fechas).</td><td>MUST</td></tr><tr><td>RB-04</td><td>Docentes, Estudiantes y Administrativosuen做什么 registrar un的最大imo de 2placas (vehículos) por usuario.</td><td>MUST</td></tr><tr><td>RB-05</td><td>Visitantes:cobro por hora o refracción;pagounicamente en efectivo en garita.</td><td>MUST</td></tr><tr><td>RB-06</td><td>Tarifasajustables yvariables:por periodo (semestral), por tipo de automotor, incapacidad yesquema mixto.</td><td>MUST</td></tr><tr><td>RB-07</td><td>Horarios: Administrativo ocupa todo el día;otros roles institUTIONalesdependen delhorarios yfranjas configurables por día.</td><td>MUST</td></tr><tr><td>RB-08</td><td>Sanciones por mal uso deshabilitan el acceso (por usuario y/o credencial) durante la vigencia estipulada de la sancción.</td><td>MUST</td></tr><tr><td>RB-09</td><td>Inventario de TAGs: el sistema administría el stock=fisico (aprox. 1000 iniciales), asignación, bloqueo y baja.</td><td>MUST</td></tr><tr><td>RB-10</td><td>Toda aperture manual de pluma debe quedar auditada (quien lozano, cuando y el motivo).</td><td>MUST</td></tr><tr><td>RB-11</td><td>El primer TAG se incluye sin costo adicional con el pago del parqueadero y es reutilizable. En caso de pérdida, el usuario repone el valor del TAG según un costo ajustable en el sistemas.</td><td>MUST</td></tr></table>

# 3 Requisitospecíficos

<table><tr><td>Número de requisito</td><td></td></tr><tr><td>Nombre de requisito</td><td></td></tr><tr><td>Tipo</td><td>□ Requisito    □ Restrición</td></tr><tr><td>Fuente del requisito</td><td></td></tr><tr><td>Prioridad del requisito</td><td>□ Alta/Esencial   □ Media/Deseado   □ Baja/ Oponcial</td></tr></table>

# 3.1 Requisitos comunes de las interfaces

# 3.1.1 Interfaces de usuario

El sistema proveerá paneles web adaptados a cada rol: un dashboard de control agil para Garita, un panel de reportes para el Administrador, y un portal de autoservicio para Estudiantes/Docentes/Administrativos.

# 3.1.2 Interfaces de hardware

- El Sistema emittirá los comandos hacerlas controladoras de las plumas de los parqueadores.   
- El sistemas capturará laslectureas de los dispositivos TAG instalados en los accesos.

# 3.1.3 Interfaces de software

Microsoft API: Para el inicio de sesión之乡 (SSO).

# 3.2 Requisitos sociales

<table><tr><td>ID</td><td>Requisito</td><td>Prioridad</td><td>Criterio de Aceptación (CA)</td></tr><tr><td>RF-01</td><td>Gestionar parqueaderos (crear/editor/deshabilitar) con nombre,ubicación y capacité.</td><td>MUST</td><td>Dado un Administrador, cuando registrar un parqueadero con capacité X,entries el parqueadero aparece en el lista y queda disponible.</td></tr><tr><td>RF-02</td><td>Configurar espacios por parqueadero y su estado (disponible/ocupado/reservado/fuera de servicios).</td><td>MUST</td><td>Dado un parqueadero, cuando seactualiza el estado de un'espacio,entries el estado se refleja en el tablero de occupancy en tiempo real.</td></tr><tr><td>RF-03</td><td>Clasificar espacios (normal/discapacidad/mixto).</td><td>SHOULD</td><td>Cuando semarca un espacio como稀缺adadecuentces el reporte de occupancy lo contabiliza en su catégorieSeparateda.</td></tr><tr><td>RF-04</td><td>Definir periodos de registrar (semestral) con Fecha在内的 fin.</td><td>MUST</td><td>Al crear un periodo, elsystema Permite definir tipo,在内的 fin,y muestra su estado (activo/inactivo).</td></tr><tr><td>RF-05</td><td>Bloquear registrar/renovación si el periodo no está activo (activador por fechas).</td><td>MUST</td><td>Si lacke actual está fuera del periodo activo, el sistema DENIEGA la Solicitud y muestra un mensaje de restricción al usuario.</td></tr><tr><td>RF-06</td><td>RegistrarOOKeros por rol (Docente/Estudiante/Administrativo/Garita/Financiero/Adminstrador).</td><td>MUST</td><td>Al crear un usuario con rol社会稳定, el sistemas lo habilita con los permisos exactos asociados a su rol.</td></tr><tr><td>RF-07</td><td>Autenticación institucional mediate Microsoft (SSO).</td><td>MUST</td><td>Cuando un usuario institucional inicia sesión con Microsoft, el sistemas create/actualiza su perfil y permite acceso según rol.</td></tr><tr><td>RF-08</td><td>Registrar vehículos asociados a usuario con placac, color, modelos y tipo de automotor.</td><td>MUST</td><td>Cuando se registra unvehicluro,la colocada como registrar unico por vehicluro y se asocia al usuario.</td></tr><tr><td>RF-09</td><td>Restringir a Tmaximo 2 vehículos por usuario institucional.</td><td>MUST</td><td>Si el usuario ya Tiene 2 vehículos registrados, el sistema impide registrar un tercero y genera un evento de auditoría.</td></tr><tr><td>RF-10</td><td>Generar Solicitud de credencial (TAG) asociada a usuario,vehicle, parqueadero y periodo.</td><td>MUST</td><td>Al enviar la solicitud, esta queda en estado 'Pendiente' y es visible para el rol Financiero.</td></tr><tr><td>RF-11</td><td>Adjuntar evidencia de transferencia para pagar instituciones.</td><td>MUST</td><td>La solicitud del usuario no pueda pagar a estado 'En revisión' sin evidencia digital adjunta (o justificación autorizada).</td></tr><tr><td>RF-12</td><td>Aprobar/rechazar Solicitud y pago (Financiero) con observación obligatoria y envío de factura.</td><td>MUST</td><td>Al aprobar, la solicitud cambia a 'Aprobada' con el ID del aprobador/fecha, y se debe enviar la factura correspondiente al usuario; al rechazar, se registra el motivo.</td></tr><tr><td>RF-13</td><td>Gestionar inventario de TAGs (~1000 unid.): disponible, asignados, bloqueados, perdidos, de baja.</td><td>MUST</td><td>El sistema no permite asignar fácilmente a un usuario un TAG que no se encuentre previamente en estado 'Disponible'.</td></tr><tr><td>RF-14</td><td>Gestionar pédida y reposición de TAGs con costo ajustable.</td><td>MUST</td><td>Al reportar pédida, el TAG actualdea a estado 'Inactivo/Perdido'. El sistemas genera una solicitud de reposición con el costo configurado que el usuario debepagar para recibir un TAG nuevo. (El primer TAG del usuario es Gratis).</td></tr><tr><td>RF-15</td><td>Emitir/activar credencial (TAG) y controlar su estado actual (activo/suspendido/vincido).</td><td>MUST</td><td>Si una credencial es leía pero está 'Suspendida' o 'Vencida', el accesodebserdenegado por lapluma.</td></tr><tr><td>RF-16</td><td>Registrar entradas/salidas con parqueadero, Fecha-hora, usuario/visitante, vehiculo, credencial y的结果ado.</td><td>MUST</td><td>Cada intentodeccesso fisico genera un registrar de bitácora (permítido/denegado) consultable en reportes.</td></tr><tr><td>RF-17</td><td>Validar acceso considerando vigencia,horario permitido (junto al limitede salute), sanión activa y cupo.</td><td>MUST</td><td>Si existesa sanción activa, el parqueadero está lleno, o está fuera de horario, el sistemas deniesga el acceso=aunque el TAG sea VFÁIDO.</td></tr><tr><td>RF-18</td><td>Controlar plumas: aperture automática por validación y aperture manual por usuario Garita con logs de auditoría.</td><td>MUST</td><td>Cada aperture manual exige el ingreso de un motivo; el registrar guarda al usuario Garita, Fecha-hora y parqueadero.</td></tr><tr><td>RF-19</td><td>Modo visitante: PENDIENTE</td><td>MUST</td><td>PENDIENTE</td></tr><tr><td>RF-20</td><td>Configurar tarifas fijas (semestral) ajustables.</td><td>MUST</td><td>Cuando se modifica el valor de una tarifa, el cambio queda versionado (fecha, usuario) paraMaintener la trazabilidad contable.</td></tr><tr><td>RF-21</td><td>Configurar tarifas variables por tipo de automotor, incapacidad y mixto.</td><td>SHOULD</td><td>Al selección un perfil de exception (p.ej.,缺席 validity), el sistema aplicará automatistically la tarifa diferenciada.</td></tr><tr><td>RF-22</td><td>Aclarar sanciones por mal uso (ej. 3 incumplimientos de horario) y deshabilitar accesos.</td><td>MUST</td><td>Con una sanción activ en el sistema, el usuario no pueda ingresar; al expirear el tiempo de castigo (ajustable), recupera acceso.</td></tr><tr><td>RF-23</td><td>Registrar incidencias desde garita(problemas de hardware pluma, TAGdefectuoso) y dar seguido.</td><td>SHOULD</td><td>Cada incidencia levantanada tiene un estado(abierta/enproceso/cerrada)y permite asignar a un responsable técnico.</td></tr><tr><td>RF-24</td><td>Reportes para el Administrador delsystema (occupacion, accesos historicos,sanciones, estado de TAGs).</td><td>MUST</td><td>El reportepermite aplicarfiltros multiples por parqueaderoy rango defechas,y permiteexportacion aPDF/Excel.</td></tr><tr><td>RF-25</td><td>Reportes para el rol Financiero (ingresos por periodo, por parqueadero, por tipo;caja de perdentes yaprobados).</td><td>MUST</td><td>El reportedistinguecontablementelos ingressos portransferencia(instituciones)vs dinero eneffectivo(visitantes).</td></tr><tr><td>RF-26</td><td>Reportes por usuario regular(docente/estudiante/adminstrativo): estado de vigencia, accesos propios.</td><td>SHOULD</td><td>Un usuarioestándar solopuede acceder asu propiainformationhistorica y estado desolicitues, sinver datos delterceros.</td></tr></table>

# 3.3 Requisitos no functionales

<table><tr><td>ID</td><td>Requerimiento</td><td>Prioridad</td><td>Criterio de Aceptación (CA)</td></tr><tr><td>RNF-01</td><td>SegURITY: Control de acceso granular por roles, permisos y auditoría obligatoria en actionscriticas.</td><td>MUST</td><td>Todaacular de impacto(cambio de tarifas, sanaciones,aprobaciones, aperture manual)genera un registrar inmutable deauditoría.</td></tr><tr><td>RNF-02</td><td>Disponibiliad: Operaciónestable y resiliente en horarioinstitutional; soporte de interfazde garita con LATencia ultrabaja.</td><td>MUST</td><td>El modulo operativo de garitadebbe operar sin interrupcionesperceptibles durante toda lajornada institucional.</td></tr><tr><td>RNF-03</td><td>Rendimiento: Validación deaccesso vehicular en garita enpocos segundos en conditionenormales.</td><td>MUST</td><td>Cada validación de hardware(lectura credencial -&gt; decidiónde pluma)debe responder entiempo operativo para asegurarel flujo continuo de vehículos.</td></tr><tr><td>RNF-04</td><td>Trazabilidad: Bitácora complea e inalterable de todos los accesos,+pagos,aprobaciones ysanaciones.</td><td>MUST</td><td>El administrador debeppoderreconstruir bajo a paskelateralcompleto de qualquier 用户,vehicle o credencialpor Fecha y hora.</td></tr><tr><td>RNF-05</td><td>Usabilidad: Interfaz de operadorde garita disñana en pocopasos y con mensajes visualesclaros de decideón.</td><td>SHOULD</td><td>Un operador de garita depebboder registrar una operación manual deingreso/salta de visitante en ≤5clics o aconteces.</td></tr><tr><td>RNF-06</td><td>Interoperability: Integraciónfluida y segura con MicrosoftSSO y controladores fisicos(Plumas, TAG).</td><td>MUST</td><td>El systemaautenticacorrectamente el token deMicrosoft y emite/consumeeventos hacela hardwaresegún la configuración技术水平a.</td></tr><tr><td>RNF-07</td><td>Respaldo y Exportación: 
Generación de backups de base de datos y exportación de todos los reportes operativos a formatos estándar.</td><td>SHOULD</td><td>Todos los reportes listados permiten descarga directa en PDF y Excel; existe unaarea de respaldo (backup) programable por el administrador.</td></tr></table>

# 4 Anexos
