# INFORME COMPARATIVO DE ARQUITECTURA DE DATOS
## Evolución del Sistema de Gestión de Parqueaderos — PUCESA (SGP)

**Documento:** IT-BD-COMP-001  
**Versión:** 1.0  
**Fecha de Emisión:** 10 de Abril de 2026  
**Elaborado por:** Equipo de Desarrollo e Ingeniería SGP  
**Dirigido a:** Stakeholders / Dirección Administrativa / Comité de Implementación PUCESA  
**Estado:** Para Revisión y Aprobación  

---

## Resumen Ejecutivo

Este documento presenta, en términos comprensibles para todos los niveles de la organización, la **evolución estructural de la base de datos** que sustenta el Sistema de Gestión de Parqueaderos (SGP) de la PUCESA. Se comparan la arquitectura original (BD Antigua) con el nuevo diseño (BD Nueva), se identifican sus limitaciones y mejoras, y se explica cómo esta evolución técnica impacta directamente en la experiencia del usuario final y en la capacidad operativa de la institución.

Adicionalmente, se documenta la **integración técnica entre la base de datos y la infraestructura física** (sensores, lectores UHF, controladora y barrera), estableciendo un mapa claro de cómo el hardware y el software colaboran para automatizar el acceso vehicular.

> **Audiencia:** Este documento está redactado para ser comprendido tanto por el personal técnico como por los responsables administrativos y directivos que toman decisiones sobre el proyecto.

---

## Parte I — Diagnóstico Comparativo de Bases de Datos

### 1.1 La Base de Datos Antigua — Diagnóstico

> **📷 Diagrama BD Antigua**
> ![BD Antigua](../../../../Imagenes/BD%20Antigua.jpeg)
> *Descripción: Diagrama entidad-relación de la base de datos original del sistema.*

#### ¿Qué era y cómo funcionaba?

La base de datos original fue diseñada con un enfoque **centralizado en el registro histórico**. En lugar de organizar la información por entidades independientes (usuarios, vehículos, dispositivos), toda la operación giraba en torno a una única tabla principal.

#### Tabla Central: `UsoParqueadero` — El "todo en uno"

Esta tabla funcionaba como el núcleo absoluto del sistema. El problema es que lo hacía todo: registraba quién entró, con qué vehículo, cuándo, y también almacenaba datos estáticos del vehículo como la placa, marca y color. Esto generaba los siguientes problemas:

| Problema Identificado | Impacto Real |
| :--- | :--- |
| **Datos de vehículo duplicados** | Si Juan tiene 2 autos, la base de datos tenía columnas `Vehiculo1` y `Vehiculo2`. Para un tercer auto, habría que modificar la estructura de la tabla completa. |
| **Sin separación entre dispositivo y usuario** | Un tag RFID o tarjeta estaba "pegado" conceptualmente al usuario, no como un objeto independiente. Si el usuario perdía su tarjeta y se le emitía una nueva, había ambigüedad en el historial. |
| **Tarifas no dinámicas** | La lógica de cobro era simple y directa. No podía gestionar convenios institucionales, discapacidad, o diferentes tipos de membresía sin reescribir código. |
| **Escalabilidad limitada** | Añadir un nuevo parqueadero o un nuevo tipo de usuario requería cambios estructurales en múltiples tablas. |

#### Puntos Positivos a Rescatar

A pesar de sus limitaciones, la BD Antigua demostró intención de robustez:

- ✅ **`LogsSistema`:** La existencia de logs indica que el equipo original ya priorizaba la auditoría del sistema.
- ✅ **`Evidencias`:** Una tabla para registrar pruebas visuales o documentales muestra madurez en el pensamiento del control de errores.
- ✅ **Relación `UsoParqueadero → Factura`:** La lógica de cobro existía y era funcional, aunque simple.
- ✅ **Modelo comprensible:** Su simplicidad facilitaba la lectura para personal no técnico.

---

### 1.2 La Base de Datos Nueva — Diagnóstico

> **📷 Diagrama BD Nueva**
> ![BD Nueva](../../../../Imagenes/BD%20Nueva.jpeg)
> *Descripción: Diagrama entidad-relación de la nueva arquitectura desarrollada para el SGP versión actual.*

#### ¿Qué es y cómo funciona?

La nueva base de datos fue diseñada bajo el principio de **Arquitectura Basada en Entidades**. Cada "cosa" del mundo real tiene su propia tabla con responsabilidades claras. Las relaciones entre ellas se manejan mediante claves foráneas, garantizando integridad y trazabilidad total.

---

### 1.3 Mapa Comparativo: Antes vs. Después

La siguiente tabla es la referencia principal para los stakeholders. Muestra, módulo por módulo, cómo evolucionó cada área del sistema:

| Área Funcional | BD Antigua ❌ | BD Nueva ✅ | Beneficio Obtenido |
| :--- | :--- | :--- | :--- |
| **Gestión de Vehículos** | Columnas estáticas `Vehiculo1`, `Vehiculo2` en la tabla principal | Tabla independiente `Vehiculos` con relación 1:N a `Usuarios` | Un usuario puede registrar ilimitados vehículos sin tocar la estructura |
| **Dispositivos de Acceso** | El tag/tarjeta era un atributo del usuario | Tablas independientes: `Tags`, `Asignacion_Tags`, `Activacion_Tags` | Un tag perdido o vencido se desactiva sin afectar el historial del usuario |
| **Control de Acceso Vehicular** | Registro genérico en `UsoParqueadero` | Tabla `Accesos` con campos `tipo_acceso`, timestamps y relación con `Tags` | Trazabilidad exacta de cada entrada y salida, vinculando hardware con usuario |
| **Tarifas y Cobros** | Relación directa y fija entre uso y factura | `Tarifas` + `Asignacion_Tarifa` + `Metodos_Pago` | Soporte para tarifas dinámicas, descuentos por discapacidad, convenios |
| **Visitantes con Ticket** | No contemplado | Tabla `Tickets` con generación de QR y cálculo de tiempo | El sistema puede gestionar tanto mensualistas como visitantes ocasionales |
| **Infraestructura Física** | No existía representación en BD | `Garajes`, `Horarios_Garaje`, `Incidencias` | El sistema conoce su propio entorno físico y puede gestionarlo |
| **Sanciones** | No contemplado | `Sanciones` + `Tipo_Sanciones` | Gestión automática de infracciones con catálogo de penalizaciones configurables |
| **Auditoría del Sistema** | `LogsSistema` básica | `Logs` vinculada a `Usuarios` + `Transaccion` | Saber exactamente quién hizo qué y cuándo en cada operación |
| **Cumplimiento Legal** | No contemplado | `AcuerdoConfidencialidad` | Registro formal de aceptación de políticas de privacidad por usuario |
| **Multi-sede** | Diseño mono-parqueadero | Arquitectura multi-`Garaje` con llaves compuestas | Posibilidad de gestionar el Coliseo y otros parqueaderos desde un solo sistema |

---

### 1.4 Resumen Visual de Mejoras

```
BD ANTIGUA                          BD NUEVA
──────────────────────────────────────────────────────────
UsoParqueadero (todo en uno)   →   Usuarios
  ├── Placa (estático)             ├── Vehiculos (1:N)
  ├── Vehiculo1                    ├── Tags ──► Asignacion_Tags
  ├── Vehiculo2                    ├── Accesos (entrada/salida)
  └── Factura (simple)            ├── Tickets (visitantes)
                                   ├── Garajes + Horarios
LogsSistema (básica)           →   ├── Sanciones + Tipo_Sanciones
Evidencias                         ├── Pagos + Metodos_Pago
                                   ├── Tarifas + Asignacion_Tarifa
                                   ├── Logs (trazabilidad completa)
                                   └── AcuerdoConfidencialidad
```

---

## Parte II — Integración de la Base de Datos con la Infraestructura Física

Esta sección explica cómo el hardware instalado en el garaje "habla" con la base de datos. Es fundamental para que los stakeholders comprendan que el sistema no son componentes aislados, sino un ecosistema integrado.

### 2.1 El Desafío del Carril Bidireccional

El parqueadero opera con **un único carril** que sirve tanto para entradas como para salidas. Esto es eficiente en espacio, pero introduce un desafío técnico: el sistema debe saber en todo momento si el vehículo está entrando o saliendo para registrar correctamente en la base de datos.

La solución está en la **secuencia de activación de los sensores**:

| Secuencia de Sensores | Interpretación del Sistema | Acción en BD |
| :--- | :--- | :--- |
| **Sensor A → Sensor B** (orden entrada) | Vehículo ingresando | `INSERT` en `Accesos` con `tipo_acceso = 'Entrada'` |
| **Sensor B → Sensor A** (orden inverso) | Vehículo saliendo | `UPDATE` en `Accesos` cerrando el registro + `INSERT` en `Pagos` |

> **Nota de Gestión:** Al ser un carril único, el software deberá implementar un **semáforo lógico** (indicador visual o físico) para evitar que un vehículo intente ingresar mientras otro está saliendo. Esto se puede gestionar desde el panel de operaciones del SGP.

---

### 2.2 Arquitectura de Conexión Hardware → Base de Datos

El camino que sigue la información desde el momento en que un auto se acerca hasta que el registro queda guardado en SQL Server es el siguiente:

```
[VEHÍCULO con TAG UHF en parabrisas]
          │
          ▼ (Señal de radio 860–960 MHz)
[ANTENA UHF — ZKTeco UHF10 Pro]
          │
          ▼ (Protocolo Wiegand / TCP-IP)
[CONTROLADORA ZKTeco — Dentro de Caja Metálica]
          │
          ▼ (SDK / API ZKTeco)
[SERVIDOR SGP — Aplicación C# .NET]
          │
          ▼ (Queries T-SQL)
[SQL SERVER — Base de Datos BD Nueva]
   Tablas: Accesos, Tags, Usuarios, Pagos
```

#### Rol de cada componente en el flujo:

| Componente | Rol Técnico | Tabla(s) Involucrada(s) |
| :--- | :--- | :--- |
| **Tag UHF (Parabrisas)** | Identificador único del vehículo (EPC Code) | `Tags` |
| **Antena UHF x2** | Captura del EPC sin que el auto se detenga | — |
| **Loop Detector (Módulo riel DIN)** | Convierte señal magnética en "contacto seco" digital | — |
| **Controladora ZKTeco (InBIO/C3-200)** | Cerebro del hardware. Valida el tag y envía el evento al servidor | — |
| **Aplicación SGP (C#)** | Recibe el evento y ejecuta la lógica de negocio | `Accesos`, `Asignacion_Tags`, `Activacion_Tags` |
| **SQL Server** | Persiste el registro histórico permanente | `Accesos`, `Pagos`, `Logs`, `Sanciones` |

---

### 2.3 Integración Técnica de los Sensores Magnéticos (Loop Detectors)

Este es el punto que con frecuencia genera confusión. Los lazos magnéticos **no se conectan directamente a la controladora**. Requieren un módulo intermedio:

```
[LAZO FÍSICO — Cable enterrado en el asfalto]
          │ (Campo electromagnético detecta masa metálica)
          ▼
[DETECTOR DE MASA — Módulo en Riel DIN, dentro de la Caja]
  (Convierte la detección en un "contacto seco" — como un interruptor)
          │
          ▼
[ENTRADAS DIGITALES de la Controladora ZKTeco]
   ├── Input 1 → Sensor Entrada: Activa lectura UHF / Emisión de ticket
   ├── Input 2 → Sensor Brazo: BLOQUEA cierre de pluma (seguridad anti-aplastamiento)
   └── Input 3 → Sensor Salida: Ordena bajar la pluma + cierra registro en BD
```

#### Requerimientos mínimos de la Controladora para un carril bidireccional:

| Recurso de la Controladora | Cantidad Mínima | Función |
| :--- | :---: | :--- |
| Entradas digitales auxiliares (`Aux Input`) | **3** | Sensor Entrada + Sensor Brazo + Sensor Salida |
| Entradas para botón manual | **1** | Apertura de emergencia / Botón de ticket para visitantes |
| Salidas de relé (`Relay Output`) | **1** | Control del motor de la pluma (barrera) |

---

### 2.4 Flujo Completo: Usuario Mensualista con Tag UHF

Este es el flujo principal, diseñado para el 90% de los usuarios del parqueadero:

```
① VEHÍCULO INGRESA AL CARRIL
   └─ Sensor Entrada (Loop A) se activa

② ANTENA UHF LEE EL TAG
   └─ Captura el código EPC del parabrisas

③ CONTROLADORA VALIDA EN TIEMPO REAL
   ├─ ¿El tag existe en la tabla Tags?         → SI: continuar
   ├─ ¿El tag tiene Activacion_Tags vigente?   → SI: continuar
   └─ ¿El usuario tiene Sanciones activas?     → NO: continuar
                                                → SI: DENEGAR acceso

④ ACCESO CONCEDIDO
   └─ Controladora activa relé → Pluma SUBE

⑤ REGISTRO EN BASE DE DATOS
   └─ INSERT en tabla Accesos
      ├── id_tag (identificador del dispositivo)
      ├── tipo_acceso = 'Entrada'
      ├── fecha_hora_entrada = GETDATE()
      └── id_garaje (parqueadero físico)

⑥ SENSOR BRAZO vigila posición
   └─ Si hay vehículo debajo → pluma NO baja (seguridad)

⑦ SENSOR SALIDA detecta área libre
   └─ Pluma BAJA → Ciclo de entrada completado
```

---

### 2.5 Flujo Completo: Visitante con Ticket QR

Aunque este módulo está planificado para una fase futura, la **BD Nueva ya está preparada** para soportarlo sin modificaciones estructurales:

```
① VISITANTE LLEGA AL CARRIL
   └─ Sensor Entrada (Loop A) se activa

② SIN TAG RFID detectado
   └─ Sistema redirige al flujo de visitantes

③ VISITANTE PRESIONA BOTÓN FÍSICO
   └─ Señal llega a la controladora → Trigger al SGP

④ SGP GENERA REGISTRO EN BD
   └─ INSERT en tabla Tickets
      ├── id_ticket (UUID generado)
      ├── fecha_hora_entrada = GETDATE()
      └── estado = 'Activo'

⑤ IMPRESORA TÉRMICA EMITE TICKET
   └─ Código QR contiene el id_ticket encriptado

⑥ PLUMA SUBE → VEHÍCULO INGRESA

--- [AL MOMENTO DE SALIR] ---

⑦ VISITANTE PRESENTA QR EN LECTOR DE SALIDA
   └─ Sistema decodifica el id_ticket

⑧ SGP CALCULA EL COBRO
   └─ Diferencia de tiempo × tarifa en tabla Asignacion_Tarifa

⑨ VISITANTE PAGA
   └─ INSERT en tabla Pagos
      ├── monto calculado
      └── metodo_pago (Efectivo / Tarjeta)

⑩ PLUMA SUBE → VEHÍCULO SALE → Registro cerrado
```

#### ⚠️ Equipos necesarios para habilitar el módulo de visitantes:

| Equipo | Cantidad | Estado |
| :--- | :---: | :--- |
| Impresora Térmica 80mm (ya en presupuesto) | 2 | Incluida en presupuesto IT-INFRA-001 |
| Lector QR para salida (Gestión de visitantes) | 2 | Incluido en presupuesto IT-INFRA-001 |
| Botón físico de solicitud de ticket | 1 | Parte del Kit de Instalación |

---

## Parte III — Cuadro de Ventajas para Stakeholders

### 3.1 Ventajas Técnicas (Para el Equipo de TI)

| # | Ventaja | Descripción |
|:---:|:---|:---|
| 1 | **Normalización completa** | Elimina la redundancia de datos. Cada dato existe en un único lugar. |
| 2 | **Escalabilidad horizontal** | Añadir un nuevo garaje, tipo de usuario o tarifa no requiere cambiar la estructura. |
| 3 | **Trazabilidad total** | Cada operación queda registrada en `Logs` vinculada al usuario que la ejecutó. |
| 4 | **Integridad referencial** | SQL Server garantiza que no puede existir un acceso sin un tag válido, ni un pago sin un acceso. |
| 5 | **Recuperación ante desastres** | Scripts `Script.sql` y `dbo.bak` permiten reconstruir el entorno completo ante fallos. |

### 3.2 Ventajas Operativas (Para el Personal de Garita y Seguridad)

| # | Ventaja | Descripción |
|:---:|:---|:---|
| 1 | **Acceso automático sin detención** | Los lectores UHF permiten que el auto autorizado pase sin que el conductor baje el vidrio. |
| 2 | **Anti-aplastamiento garantizado** | El sensor de brazo impide que la pluma baje sobre un vehículo. No depende del operador. |
| 3 | **Apertura manual de emergencia** | Los interruptores físicos en la caja permiten operación manual si hay fallo del sistema. |
| 4 | **Detección automática de sanciones** | El sistema no abre la pluma a un usuario con infracciones activas, sin intervención humana. |

### 3.3 Ventajas Administrativas (Para la Dirección PUCESA)

| # | Ventaja | Descripción |
|:---:|:---|:---|
| 1 | **Reportes históricos precisos** | La tabla `Accesos` permite generar reportes de ocupación por hora, día o garaje en tiempo real. |
| 2 | **Gestión financiera robusta** | `Pagos` + `Metodos_Pago` + `Tarifas` permiten auditorías contables completas. |
| 3 | **Escalabilidad a múltiples sedes** | El sistema puede gestionar el Coliseo, la Facultad de Medicina y futuros parqueaderos sin nueva infraestructura de software. |
| 4 | **Cumplimiento de privacidad** | La tabla `AcuerdoConfidencialidad` asegura el cumplimiento de normativas de protección de datos (RGPD / LOPDP Ecuador). |
| 5 | **Independencia del hardware** | Si se cambia la marca del lector UHF en el futuro, solo cambia la capa de integración; la BD no se modifica. |

---

## Parte IV — Preguntas Abiertas y Decisiones Pendientes

Antes de la puesta en marcha definitiva, el equipo de ingeniería requiere clarificación sobre los siguientes puntos:

| # | Pregunta | Impacto si no se resuelve |
|:---:|:---|:---|
| 1 | **¿Se instalará un lector QR en el carril de salida?** | Sin él, el módulo de visitantes no puede operar. Los tickets impresos serían inútiles. |
| 2 | **¿La controladora dentro de la caja tiene mínimo 3 entradas digitales auxiliares?** | Con menos de 3 entradas, no es posible conectar los 3 lazos magnéticos de forma segura. |
| 3 | **¿La impresora de tickets se conectará vía USB a una PC en garita o tendrá IP de red propia?** | Define cómo el SGP enviará los comandos de impresión. Son dos arquitecturas distintas de software. |
| 4 | **¿Se implementará el semáforo lógico para el carril bidireccional?** | Sin esta lógica, existe riesgo de colisión de registros si dos vehículos usan el carril simultáneamente. |

---

## Conclusión

La evolución de la BD Antigua a la BD Nueva no es solo una mejora técnica; es el cimiento que transforma el parqueadero de la PUCESA de un **punto de control manual** a un **sistema automatizado de clase institucional**. La nueva arquitectura modular garantiza que cada mejora futura (app móvil, pagos en línea, reportes avanzados) pueda construirse sobre una base sólida, sin necesidad de rediseñar el sistema desde cero.

La integración entre el hardware físico (sensores, antenas, controladora) y la base de datos es precisa y está documentada en este informe. Cada componente tiene un rol claro y una contraparte definida en el esquema de datos.

---

**Elaborado por:** Equipo de Desarrollo e Ingeniería — Proyecto SGP PUCESA  
**Tecnología:** SQL Server 2022 | C# .NET | ZKTeco SDK | EPC Gen 2 UHF RFID  

| Rol | Nombre | Firma |
|:---|:---|:---|
| Elaborado por | Alberto Falconi, Sebastian Sanmartin | _____________ |
| Revisado por | _________________________ | _____________ |
| Aprobado por | _________________________ | _____________ |
