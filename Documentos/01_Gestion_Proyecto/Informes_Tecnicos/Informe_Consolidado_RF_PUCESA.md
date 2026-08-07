# Informe Consolidado de Especificación de Requerimientos Funcionales

> **Nota de estabilización documental - 2026-07-17**
>
> Este informe se conserva como insumo histórico de requerimientos consolidados. Después de la fase de estabilización conceptual:
>
> - no debe interpretarse por sí solo como la fuente oficial única del alcance actual;
> - las decisiones aprobadas se leen desde `Documentos/00_Gobierno_Documental/Registro_Decisiones.md`;
> - la separación entre prototipo, MVP y sistema completo se rige por los documentos de alcance creados en 2026-07-17;
> - cualquier capacidad aquí descrita que exceda el MVP debe entenderse como visión del sistema completo o propuesta pendiente de validación.

## Sistema de Gestión de Parqueaderos e Identificación Vehicular — PUCESA

| Campo                    | Detalle                                        |
| ------------------------ | ---------------------------------------------- |
| **Versión**       | 1.0 Consolidada                                |
| **Fecha**          | 9 de abril de 2026                             |
| **Preparado por**  | Jonathan Acurio                                |
| **Estado**         | Revisado y Auditado — Listo para Stakeholders |
| **Clasificación** | Uso Interno Institucional                      |

---

## Tabla de Contenidos

1. [Resumen Ejecutivo](#1-resumen-ejecutivo)
2. [Alcance y Objetivos del Sistema](#2-alcance-y-objetivos-del-sistema)
3. [Glosario de Términos Clave](#3-glosario-de-términos-clave)
4. [Actores del Sistema](#4-actores-del-sistema)
5. [Catálogo Completo de Requerimientos Funcionales (RF-01 a RF-21)](#5-catálogo-completo-de-requerimientos-funcionales)
6. [Máquina de Estados: TAG y Solicitudes](#6-máquina-de-estados-tag-y-solicitudes)
7. [Mapa de Cobertura Estratégica](#7-mapa-de-cobertura-estratégica)
8. [Auditoría Técnica del Documento](#8-auditoría-técnica-del-documento)
9. [Recomendaciones Prioritarias](#9-recomendaciones-prioritarias)
10. [Estado del Proyecto y Próximos Pasos](#10-estado-del-proyecto-y-próximos-pasos)

---

## 1. Resumen Ejecutivo

El presente documento constituye el **informe consolidado y auditado** de los veintiún (21) requerimientos funcionales del Sistema de Gestión de Parqueaderos e Identificación Vehicular de la PUCESA. Integra los tres informes independientes emitidos previamente (Fase I: RF-01 a RF-10; Fase II: RF-11 a RF-20; Informe Final: RF-21) en una única fuente de verdad oficial para la revisión y aprobación de los Stakeholders.

El sistema abarca el ciclo de vida completo de la operación de un parqueadero institucional: desde la configuración administrativa inicial, pasando por la integración de identidad institucional mediante **Microsoft Azure Active Directory (SSO)**, el control de acceso vehicular con un **motor de reglas multicapa**, la gestión del ciclo de vida de los dispositivos **TAG**, la administración financiera y tarifaria, hasta el **autoservicio** del usuario final para consulta de su propio historial.

> **Nota para los Stakeholders:** Este documento reemplaza a los tres informes previos y debe ser considerado la **versión oficial** para su aprobación. Las correcciones detectadas en la auditoría (sección 8) se reflejan directamente en el catálogo de requerimientos de la sección 5.

---

## 2. Alcance y Objetivos del Sistema

### 2.1 Objetivo General

Desarrollar un sistema de software institucional que permita la **administración integral, segura y trazable** del parqueadero de la PUCESA, automatizando el control de acceso, la gestión de dispositivos TAG, la recaudación de tarifas y la generación de reportes.

### 2.2 Objetivos Específicos

| # | Objetivo Estratégico                                              | RFs Vinculados                           |
| - | ------------------------------------------------------------------ | ---------------------------------------- |
| 1 | Centralizar la configuración del parqueadero y sus políticas     | RF-01, RF-02, RF-03                      |
| 2 | Garantizar la seguridad de acceso mediante identidad institucional | RF-04, RF-05                             |
| 3 | Gestionar el ciclo completo de vehículos y dispositivos TAG       | RF-06, RF-07, RF-08, RF-09, RF-10, RF-11 |
| 4 | Automatizar el control físico de acceso con auditoría total      | RF-12, RF-13, RF-14, RF-15               |
| 5 | Administrar el cobro a visitantes externos y configurar tarifas    | RF-16, RF-17, RF-18                      |
| 6 | Gestionar sanciones y garantizar el cumplimiento de normas         | RF-19                                    |
| 7 | Proveer visibilidad financiera y de uso del sistema                | RF-20, RF-21                             |

### 2.3 Límites del Sistema

El sistema gestiona exclusivamente el parqueadero **dentro del campus de la PUCESA**. Quedan fuera del alcance:

- Parqueaderos externos o de terceros.
- Gestión de seguros vehiculares.
- Integración directa con pasarelas de cobro bancario externo (puede considerarse en fases futuras).

---

## 3. Glosario de Términos Clave

| Término                            | Definición                                                                                                                                                                                     |
| ----------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **TAG**                       | Dispositivo físico de identificación vehicular (tarjeta RFID, sticker o llavero) que se vincula a un vehículo y permite el acceso automatizado al parqueadero.                               |
| **Pluma**                     | Barrera física de acceso al parqueadero. Puede estar en estado abierto (acceso permitido) o cerrado (acceso denegado).                                                                         |
| **Bitácora**                 | Registro cronológico e inmutable de todos los eventos de acceso al sistema, tanto permitidos como denegados.                                                                                   |
| **SSO**                       | *Single Sign-On*. Mecanismo de autenticación único que permite al usuario ingresar al sistema con sus credenciales institucionales de Microsoft sin necesidad de una contraseña adicional. |
| **JWT**                       | *JSON Web Token*. Estándar de seguridad utilizado para transmitir de forma segura la identidad del usuario autenticado entre el proveedor (Azure AD) y el sistema.                           |
| **Motor de Reglas**           | Componente lógico del sistema que evalúa múltiples condiciones (sanciones, horarios, capacidad) para tomar una decisión de acceso de forma automatizada.                                    |
| **Periodo de Registro**       | Rango de fechas habilitado por el Administrador durante el cual los usuarios pueden inscribir sus vehículos.                                                                                   |
| **Rol Financiero**            | Actor del sistema con permisos para revisar comprobantes de pago, aprobar o rechazar solicitudes de TAG y generar reportes financieros.                                                         |
| **Versionamiento de Tarifas** | Mecanismo que guarda el historial de cambios en las tarifas, preservando valores anteriores para auditorías.                                                                                   |
| **IDOR**                      | *Insecure Direct Object Reference*. Vulnerabilidad de seguridad donde un usuario podría acceder a datos de otro usuario manipulando identificadores en la petición.                         |

---

## 4. Actores del Sistema

Los siguientes actores participan en los procesos definidos por los requerimientos funcionales. La tabla es uniforme y aplica para todos los módulos del sistema.

| Actor                              | Descripción                                                                                                                                             | Requerimientos Principales                      |
| ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------- |
| **Administrador**            | Configura la infraestructura del sistema, gestiona parqueaderos, periodos, usuarios y aplica sanciones. Tiene registro ilimitado de vehículos.          | RF-01, RF-02, RF-03, RF-04, RF-07, RF-17, RF-19 |
| **Usuario Institucional**    | Docente o estudiante de la PUCESA. Registra vehículos, solicita TAGs y consulta su historial personal. Tiene límite de 2 vehículos activos.           | RF-05, RF-06, RF-07, RF-08, RF-11, RF-21        |
| **Rol Financiero**           | Valida comprobantes de pago, aprueba o rechaza solicitudes de TAG y genera reportes económicos.                                                         | RF-09, RF-17, RF-20                             |
| **Administrador de Entrega** | Vincula físicamente un TAG del inventario a una solicitud aprobada y gestiona la reposición de TAGs perdidos.                                          | RF-10, RF-11                                    |
| **Operador de Garita**       | Monitorea el acceso físico al parqueadero y puede ejecutar aperturas manuales de pluma con justificación obligatoria.                                  | RF-12, RF-15, RF-16                             |
| **Visitante Externo**        | Usuario sin credenciales institucionales que accede al parqueadero mediante ticket temporal de pago por tiempo.                                          | RF-16, RF-18                                    |
| **Sistema (Automatizado)**   | Componente que ejecuta validaciones en tiempo real, registra bitácoras, aplica reglas de acceso y restaura sanciones vencidas sin intervención humana. | RF-03, RF-12, RF-13, RF-14, RF-18, RF-19        |

---

## 5. Catálogo Completo de Requerimientos Funcionales

---

### MÓDULO 1: Gestión Administrativa y de Configuración

---

#### RF-01 — Gestionar Parqueaderos

| Campo                     | Detalle                                                 |
| ------------------------- | ------------------------------------------------------- |
| **Actor Principal** | Administrador                                           |
| **Precondición**   | Usuario autenticado con rol de Administrador.           |
| **Postcondición**  | Nuevo registro de parqueadero disponible en el sistema. |

**Descripción:**
Permite al Administrador dar de alta nuevas áreas de estacionamiento dentro del campus. Al registrar un parqueadero, se definen los siguientes atributos: nombre, capacidad total (número de espacios), y ubicación física o descripción. El registro queda disponible para la asignación de usuarios y la configuración de reglas de acceso.

---

#### RF-02 — Definir Periodos de Registro

| Campo                     | Detalle                                                                             |
| ------------------------- | ----------------------------------------------------------------------------------- |
| **Actor Principal** | Administrador                                                                       |
| **Precondición**   | Existencia de al menos un parqueadero registrado (RF-01).                           |
| **Postcondición**  | Período activo configurado y disponible para la validación automática del RF-03. |

**Descripción:**
Establece los rangos temporales (Fecha de Inicio y Fecha de Fin) dentro de los cuales el sistema habilitará el formulario de registro vehicular para los usuarios. El Administrador puede definir múltiples períodos y gestionarlos desde el panel de configuración.

---

#### RF-03 — Bloqueo de Registro por Fechas

| Campo                     | Detalle                                                                        |
| ------------------------- | ------------------------------------------------------------------------------ |
| **Actor Principal** | Sistema (automatizado)                                                         |
| **Precondición**   | Período de registro configurado (RF-02).                                      |
| **Postcondición**  | Acceso al formulario de registro permitido o denegado con mensaje informativo. |

**Descripción:**
Mecanismo de control que compara la fecha y hora actual con el período de registro habilitado. Si la fecha está fuera del rango configurado, el sistema bloquea el acceso al formulario de registro y muestra un mensaje descriptivo al usuario indicando cuándo estará disponible el próximo período.

---

### MÓDULO 2: Seguridad e Identidad

---

#### RF-04 — Registro de Usuarios por Rol

| Campo                     | Detalle                                                     |
| ------------------------- | ----------------------------------------------------------- |
| **Actor Principal** | Administrador                                               |
| **Precondición**   | Usuario autenticado con rol de Administrador.               |
| **Postcondición**  | Cuenta de usuario activa con permisos asignados según rol. |

**Descripción:**
Permite al Administrador crear cuentas de usuario manualmente. Durante la creación, se asigna el rol correspondiente (Financiero, Docente, Estudiante, Operador de Garita, Administrador de Entrega) y el sistema vincula automáticamente la matriz de permisos asociada a dicho rol.

---

#### RF-05 — Autenticación Microsoft SSO

| Campo                     | Detalle                                                                     |
| ------------------------- | --------------------------------------------------------------------------- |
| **Actor Principal** | Usuario Institucional                                                       |
| **Tecnología**     | OAuth 2.0 / OpenID Connect con Microsoft Azure Active Directory             |
| **Precondición**   | El usuario posee credenciales institucionales activas de la PUCESA.         |
| **Postcondición**  | Usuario autenticado con sesión activa y perfil sincronizado en el sistema. |

**Descripción:**
Integración con **Microsoft Azure Active Directory** para el inicio de sesión institucional. El flujo es el siguiente:

1. El usuario selecciona "Iniciar sesión con cuenta institucional".
2. El sistema redirige al portal de autenticación de Microsoft.
3. Azure AD valida las credenciales y devuelve un **token JWT**.
4. El sistema valida el token y extrae los siguientes atributos del perfil institucional: correo electrónico, nombre completo, número de carnet/cédula y rol académico.
5. **Si el usuario es nuevo:** se crea automáticamente un perfil en el sistema con los atributos extraídos.
6. **Si el usuario ya existe:** se actualiza la sesión sin modificar los datos existentes.

> **Punto de atención para los Stakeholders:** El mapeo exacto entre atributos del token Azure AD y los campos del perfil institucional debe ser validado con el departamento de TI de la PUCESA antes del inicio del desarrollo.

---

### MÓDULO 3: Gestión de Vehículos y Flotas

---

#### RF-06 — Registro de Vehículos

| Campo                       | Detalle                                                                                          |
| --------------------------- | ------------------------------------------------------------------------------------------------ |
| **Actor Principal**   | Usuario Institucional                                                                            |
| **Precondición**     | Usuario autenticado. Período de registro activo (RF-03). Límite de flota no alcanzado (RF-07). |
| **Postcondición**    | Vehículo registrado y vinculado al perfil del usuario.                                          |
| **Validación clave** | Unicidad del número de placa en toda la base de datos.                                          |

**Descripción:**
Proceso de inscripción de un vehículo por parte del usuario. El formulario solicita: número de placa, tipo de vehículo (automóvil / motocicleta), marca, modelo y año. Antes de guardar, el sistema valida que la placa ingresada no exista en la base de datos. Si la placa ya está registrada, se muestra un mensaje de error descriptivo indicando el conflicto.

---

#### RF-07 — Restricción de Flota por Usuario

| Campo                     | Detalle                                                  |
| ------------------------- | -------------------------------------------------------- |
| **Actor Principal** | Sistema (automatizado)                                   |
| **Precondición**   | Usuario intenta registrar un nuevo vehículo.            |
| **Postcondición**  | Registro permitido o bloqueado según la regla aplicada. |

**Descripción:**
Regla de negocio que limita el número de vehículos activos que un usuario no-administrador puede mantener registrado simultáneamente.

**Regla de negocio:**

```
SI (Rol ≠ Administrador) Y (VehículosActivos ≥ 2)
  → BLOQUEAR registro con mensaje: "Ha alcanzado el límite de vehículos activos."
SI (Rol = Administrador)
  → PERMITIR registro sin restricción de cantidad
```

**Gestión de baja de vehículos:**
Si un usuario ya tiene 2 vehículos activos y desea registrar uno nuevo, puede **dar de baja** uno de los existentes desde su panel. Al dar de baja un vehículo, su TAG asociado cambia automáticamente al estado **"INACTIVO"** y se libera el cupo para un nuevo registro.

---

### MÓDULO 4: Proceso de Solicitud y Asignación de TAGs

---

#### RF-08 — Generación de Solicitud de TAG

| Campo                     | Detalle                                                                                 |
| ------------------------- | --------------------------------------------------------------------------------------- |
| **Actor Principal** | Usuario Institucional                                                                   |
| **Precondición**   | Vehículo registrado (RF-06). Sin solicitud activa duplicada para el mismo vehículo.   |
| **Postcondición**  | Solicitud creada en estado**PENDIENTE**. Notificación enviada al Rol Financiero. |

**Descripción:**
El Usuario Institucional selecciona un vehículo de su flota registrada y genera una solicitud de TAG adjuntando el comprobante de pago correspondiente. Un usuario puede tener solicitudes activas para diferentes vehículos de forma simultánea, pero **no puede tener dos solicitudes activas para el mismo vehículo**. La nueva solicitud queda en estado **PENDIENTE** a la espera de la revisión del Rol Financiero.

---

#### RF-09 — Aprobación / Rechazo de Solicitud de TAG

| Campo                     | Detalle                                                             |
| ------------------------- | ------------------------------------------------------------------- |
| **Actor Principal** | Rol Financiero                                                      |
| **Precondición**   | Solicitud en estado PENDIENTE (RF-08).                              |
| **Postcondición**  | Solicitud en estado APROBADA o RECHAZADA con trazabilidad completa. |

**Descripción:**
El Rol Financiero evalúa el comprobante de pago adjunto a la solicitud. El proceso tiene dos caminos:

- **Aprobación:** El sistema genera una factura y cambia el estado de la solicitud a **"APROBADA"**. Se notifica al usuario y la solicitud queda disponible para asignación física del TAG (RF-10).
- **Rechazo:** El Rol Financiero **debe ingresar obligatoriamente un motivo de rechazo**. El sistema cambia el estado a **"RECHAZADA"** y notifica al usuario con el motivo. El usuario puede corregir el comprobante y reenviar la solicitud hasta un **máximo de 3 intentos**. Superado este límite, la solicitud se cierra definitivamente y el usuario debe iniciar una nueva.

---

#### RF-10 — Inventario de TAGs (Asignación Física)

| Campo                     | Detalle                                                                                                            |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| **Actor Principal** | Administrador de Entrega                                                                                           |
| **Precondición**   | Solicitud en estado APROBADA (RF-09). Existencia de TAGs disponibles en inventario.                                |
| **Postcondición**  | TAG vinculado al vehículo y usuario. Estado del TAG:**ACTIVO**. Estado de la solicitud: **ASIGNADA**. |

**Descripción:**
El Administrador de Entrega accede al listado de solicitudes aprobadas, selecciona la solicitud, y vincula un TAG físico del inventario (en estado DISPONIBLE) al vehículo correspondiente. Al confirmar la asignación:

- El TAG pasa de estado **DISPONIBLE** → **ACTIVO**.
- La solicitud pasa de estado **APROBADA** → **ASIGNADA**.
- Se registra la fecha de asignación y el responsable de la entrega.

---

#### RF-11 — Gestión de Pérdida y Reposición de TAG

| Campo                     | Detalle                                                                                            |
| ------------------------- | -------------------------------------------------------------------------------------------------- |
| **Actor Principal** | Usuario Institucional / Administrador de Entrega                                                   |
| **Precondición**   | TAG en estado ACTIVO vinculado al usuario.                                                         |
| **Postcondición**  | TAG anterior en estado INACTIVO. Nueva solicitud de reposición generada en el módulo financiero. |

**Descripción:**
Cuando un usuario reporta la pérdida o daño de su TAG, el flujo es el siguiente:

1. El usuario o el Administrador reporta la pérdida en el sistema.
2. El sistema marca el TAG como **INACTIVO**, desactivando inmediatamente su acceso.
3. El sistema genera automáticamente una nueva solicitud de reposición con el **costo de reposición vigente** configurado por el Administrador.
4. La solicitud de reposición sigue el mismo flujo de aprobación financiera que una solicitud nueva (RF-09).

> **Nota:** El monto del costo de reposición es un parámetro configurable por el Administrador en el panel de configuración del sistema.

---

### MÓDULO 5: Control de Acceso Físico y Auditoría

---

#### RF-12 — Control de Estados del TAG en Acceso Físico

| Campo                     | Detalle                                                                        |
| ------------------------- | ------------------------------------------------------------------------------ |
| **Actor Principal** | Sistema (automatizado por hardware lector)                                     |
| **Precondición**   | Lector de TAG activo y conectado al sistema.                                   |
| **Postcondición**  | Apertura de pluma o denegación con registro automático en bitácora (RF-13). |

**Descripción:**
En cada lectura de TAG, el sistema verifica en tiempo real el estado del dispositivo detectado. La lógica de decisión es:

| Estado del TAG       | Acción del Sistema                                                                    |
| -------------------- | -------------------------------------------------------------------------------------- |
| **ACTIVO**     | Pluma abierta. Registro de acceso permitido.                                           |
| **SUSPENDIDO** | Pluma cerrada. Registro de intento denegado con motivo: "TAG suspendido por sanción". |
| **VENCIDO**    | Pluma cerrada. Registro de intento denegado con motivo: "TAG vencido".                 |
| **INACTIVO**   | Pluma cerrada. Registro de intento denegado con motivo: "TAG inactivo o extraviado".   |

---

#### RF-13 — Registro de Bitácora de Accesos

| Campo                     | Detalle                                                            |
| ------------------------- | ------------------------------------------------------------------ |
| **Actor Principal** | Sistema (automatizado)                                             |
| **Precondición**   | Cualquier evento de lectura de TAG (permitido o denegado).         |
| **Postcondición**  | Registro generado en bitácora con todos los atributos del evento. |

**Descripción:**
Cada evento de lectura genera un registro en la bitácora inmutable del sistema. Los atributos almacenados por evento son:

- Timestamp (fecha y hora exacta)
- ID del TAG leído
- ID del vehículo asociado
- Usuario propietario del TAG
- Parqueadero donde ocurrió el evento
- Resultado: `PERMITIDO` o `DENEGADO`
- Motivo de denegación (si aplica)

**Inmutabilidad:** Los registros de bitácora son **de solo inserción**. Ningún usuario, incluyendo el Administrador, puede modificar o eliminar registros existentes. Este comportamiento se garantiza a nivel de base de datos mediante una restricción de permisos que prohíbe las operaciones `UPDATE` y `DELETE` en la tabla de bitácora.

---

#### RF-14 — Validación de Acceso Lógica (Motor de Reglas Multicapa)

| Campo                     | Detalle                                                         |
| ------------------------- | --------------------------------------------------------------- |
| **Actor Principal** | Sistema (motor de reglas)                                       |
| **Precondición**   | TAG en estado ACTIVO (RF-12 validado).                          |
| **Postcondición**  | Acceso autorizado o denegado con motivo específico registrado. |

**Descripción:**
El motor de reglas evalúa **tres condiciones secuenciales** antes de autorizar el acceso. Si cualquier condición falla, el proceso se detiene, se deniega el acceso y se registra el motivo específico.

```
CONDICIÓN 1 — Sanciones:
  ¿El usuario tiene bloqueos vigentes? → SI: DENEGAR ("Acceso suspendido por sanción vigente")

CONDICIÓN 2 — Horarios:
  ¿El acceso ocurre dentro del horario permitido para el rol del usuario? → NO: DENEGAR ("Acceso fuera del horario permitido")

CONDICIÓN 3 — Capacidad:
  ¿El parqueadero ha alcanzado su capacidad máxima? → SI: DENEGAR ("Parqueadero al máximo de capacidad")

→ Si las 3 condiciones pasan: AUTORIZAR acceso y abrir pluma.
```

> **Configuración de horarios:** Los rangos horarios permitidos por rol son configurados por el Administrador en el panel de gestión del sistema. Pueden modificarse en cualquier momento y entran en vigor inmediatamente.

---

#### RF-15 — Control de Plumas (Apertura Manual Auditable)

| Campo                     | Detalle                                                                          |
| ------------------------- | -------------------------------------------------------------------------------- |
| **Actor Principal** | Operador de Garita                                                               |
| **Precondición**   | Operador autenticado en el sistema de garita.                                    |
| **Postcondición**  | Pluma abierta. Evento de auditoría registrado con justificación y responsable. |

**Descripción:**
En casos excepcionales (falla de lector, emergencia, etc.), el Operador de Garita puede forzar la apertura de la pluma. El sistema **obliga** al ingreso de una justificación textual antes de ejecutar la apertura. El registro de auditoría incluye: identificador del operador, timestamp, pluma afectada y justificación ingresada. Este mecanismo **no puede bypassearse** desde la interfaz.

> **Control adicional:** Todo registro de apertura manual es visible para el Administrador en el panel de auditoría y puede ser exportado en los reportes.

---

### MÓDULO 6: Gestión Económica y Tarifaria

---

#### RF-16 — Gestión de Acceso y Cobro de Visitantes

| Campo                     | Detalle                                                         |
| ------------------------- | --------------------------------------------------------------- |
| **Actor Principal** | Operador de Garita / Visitante Externo                          |
| **Precondición**   | El visitante no posee TAG institucional.                        |
| **Postcondición**  | Ticket generado al ingreso. Factura de cobro generada al salir. |

**Descripción:**
Proceso completo para usuarios externos al campus:

- **Ingreso:** El Operador de Garita registra manualmente el ingreso del visitante. El sistema genera un **ticket virtual** con número único y timestamp de entrada. La pluma se abre.
- **Salida:** Al salir, el sistema calcula el tiempo de permanencia y aplica la tarifa vigente para visitantes (RF-18). Se genera la factura con el desglose: tiempo transcurrido, tarifa por hora y total a pagar. La pluma se abre una vez confirmado el pago.
- **Ticket Abandonado:** Si un ticket no es cerrado dentro de las **24 horas**, el sistema lo marca automáticamente como **"VENCIDO"** y genera una alerta para el Administrador. La deuda queda registrada vinculada a la placa del vehículo si fue capturada.

---

#### RF-17 — Configuración de Tarifas Fijas (con Versionamiento)

| Campo                     | Detalle                                                                                       |
| ------------------------- | --------------------------------------------------------------------------------------------- |
| **Actor Principal** | Administrador / Rol Financiero                                                                |
| **Precondición**   | Usuario con permiso de gestión de tarifas.                                                   |
| **Postcondición**  | Nueva versión de tarifa activa. Versión anterior en estado INACTIVA con historial completo. |

**Descripción:**
Al crear o modificar una tarifa, el sistema aplica **versionamiento automático**:

1. La versión de tarifa actualmente vigente pasa al estado **INACTIVA** (se conserva para historial).
2. Se crea una nueva versión de tarifa con el valor actualizado, la fecha de vigencia y el identificador del usuario responsable del cambio.
3. El historial completo de tarifas es consultable desde el panel de administración.

> **Control de cambios:** Cualquier modificación de tarifa genera una notificación visible en el panel del Administrador principal para garantizar visibilidad de los cambios económicos.

---

#### RF-18 — Tarifas Variables y Excepciones (Cálculo Automático)

| Campo                     | Detalle                                                                      |
| ------------------------- | ---------------------------------------------------------------------------- |
| **Actor Principal** | Sistema (motor de cálculo)                                                  |
| **Precondición**   | Ticket activo (para visitantes) o evento de acceso de usuario institucional. |
| **Postcondición**  | Monto calculado con desglose de variables aplicadas.                         |

**Descripción:**
El motor de cálculo determina el monto final ajustando la tarifa base según dos variables:

| Variable                     | Opciones                                    | Efecto                                     |
| ---------------------------- | ------------------------------------------- | ------------------------------------------ |
| **Perfil del usuario** | Persona con discapacidad, usuario estándar | Aplica porcentaje de descuento configurado |
| **Tipo de vehículo**  | Automóvil, Motocicleta                     | Aplica tarifa diferenciada por categoría  |

El desglose del cálculo (tarifa base, descuento aplicado, total) se incluye en la factura generada.

---

### MÓDULO 7: Disciplina y Sanciones

---

#### RF-19 — Aplicación y Validación de Sanciones

| Campo                     | Detalle                                                                                            |
| ------------------------- | -------------------------------------------------------------------------------------------------- |
| **Actor Principal** | Administrador                                                                                      |
| **Precondición**   | Usuario institucional con infracción registrada.                                                  |
| **Postcondición**  | Acceso del usuario bloqueado durante el período de sanción. Restauración automática al vencer. |

**Descripción:**
El Administrador puede aplicar una sanción temporal a un usuario. Al activarse la sanción:

1. El o los TAGs del usuario pasan al estado **SUSPENDIDO**.
2. El motor de reglas (RF-14, Condición 1) bloqueará cualquier intento de acceso.
3. El sistema valida automáticamente, de forma diaria, si la fecha de expiración de la sanción ha sido alcanzada.
4. Al vencer la sanción, los TAGs se restauran al estado **ACTIVO** sin intervención manual.

> **Proceso de apelación:** Si un usuario considera que la sanción es incorrecta, puede presentar una solicitud de revisión al Administrador a través del panel de usuario. La solicitud queda registrada para seguimiento.

---

### MÓDULO 8: Reportabilidad y Autoservicio

---

#### RF-20 — Generación de Reportes Financieros

| Campo                     | Detalle                                       |
| ------------------------- | --------------------------------------------- |
| **Actor Principal** | Rol Financiero / Administrador                |
| **Precondición**   | Usuario con permisos de reportes.             |
| **Postcondición**  | Reporte consolidado disponible para descarga. |

**Descripción:**
Módulo de consolidación de ingresos del parqueadero. El sistema permite filtrar los reportes por:

- **Rango de fechas** (Fecha de inicio y Fecha de fin).
- **Método de pago** (efectivo, transferencia, etc.).
- **Tipo de usuario** (institucional, visitante externo).
- **Parqueadero** (en caso de existir múltiples áreas).

El reporte agrupa los totales por las categorías seleccionadas y puede **exportarse en formato PDF o Excel** para uso oficial e institucional.

---

#### RF-21 — Reportes de Usuario Final (Autoservicio)

| Campo                     | Detalle                                                                                                        |
| ------------------------- | -------------------------------------------------------------------------------------------------------------- |
| **Actor Principal** | Usuario Institucional                                                                                          |
| **Precondición**   | Usuario autenticado con sesión activa.                                                                        |
| **Postcondición**  | Panel de historial personal disponible, filtrado por la sesión activa del usuario.                            |
| **Seguridad**       | Filtro obligatorio por `Session_UserID` aplicado en el **backend** (servidor), no solo en la interfaz. |

**Descripción:**
Permite al Usuario Institucional acceder a su información personal de forma autónoma, sin necesidad de contactar a un administrador. El panel muestra:

- **Línea de tiempo de accesos:** Historial de ingresos y salidas del parqueadero (últimos 6 meses).
- **Historial de pagos:** Facturas y cobros realizados.
- **Estado de TAGs:** Estado actual y historial de sus dispositivos.

**Seguridad:** El filtro por `Session_UserID` se aplica en el **controlador del servidor (backend)**. El sistema rechaza cualquier petición que intente consultar datos de un identificador de usuario diferente al de la sesión activa, previniendo vulnerabilidades de tipo IDOR.

---

## 6. Máquina de Estados: TAG y Solicitudes

### 6.1 Estados del TAG

```
               [Registrado en inventario]
                        │
                        ▼
                   DISPONIBLE
                        │
            (RF-10: Asignación aprobada)
                        │
                        ▼
                     ACTIVO  ◄─────────────────────────────────┐
                  /    │    \                                   │
                 /     │     \                                  │
     (RF-19)   /   (RF-11)   \ (RF-12: TAG vence)              │
    Sanción   /     Pérdida    \                                │
             ▼        ▼         ▼                               │
        SUSPENDIDO  INACTIVO  VENCIDO                           │
             │                                                  │
    (RF-19: Sanción                                             │
      vencida, auto)                                            │
             └──────────────────────────────────────────────────┘
```

### 6.2 Estados de la Solicitud de TAG

```
    [Usuario genera solicitud]
              │
              ▼
          PENDIENTE
          /       \
    (RF-09)       (RF-09)
    Aprueba       Rechaza
         │              │
         ▼              ▼
     APROBADA       RECHAZADA ──► (≤ 3 reintentos) ──► PENDIENTE
         │                              │
    (RF-10)                    (> 3 rechazos)
    Asignación                          │
         │                              ▼
         ▼                         CANCELADA
      ASIGNADA
```

---

## 7. Mapa de Cobertura Estratégica

| Pilar Estratégico                         | Requerimientos                                  | Estado de Cobertura |
| ------------------------------------------ | ----------------------------------------------- | ------------------- |
| **Administración y Configuración** | RF-01, RF-02, RF-03, RF-04                      | ✅ Completa         |
| **Seguridad e Identidad**            | RF-05, RF-12, RF-13, RF-14, RF-15               | ✅ Completa         |
| **Operatividad Vehicular y TAGs**    | RF-06, RF-07, RF-08, RF-09, RF-10, RF-11, RF-19 | ✅ Completa         |
| **Gestión Financiera y Tarifas**    | RF-16, RF-17, RF-18, RF-20                      | ✅ Completa         |
| **Autogestión y Transparencia**     | RF-21                                           | ✅ Completa         |

**Total de Requerimientos Funcionales Documentados: 21 / 21** ✅

---

*Elaborado por: Jonathan Acurio — 9 de abril de 2026*
*Sistema de Gestión de Parqueaderos e Identificación Vehicular — PUCESA*
