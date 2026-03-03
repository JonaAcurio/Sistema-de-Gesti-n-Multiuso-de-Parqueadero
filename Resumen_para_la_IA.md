# Especificaciones Técnicas — Sistema de Parqueadero PUCESA
## Documento para integración con SQL Server

> **Propósito:** Este documento describe toda la información que maneja actualmente el sistema en C#
> para que pueda construirse el backend en SQL Server que lo complemente.

---

## 1. Contexto General del Sistema

El sistema controla una **barrera vehicular** en el parqueadero de PUCESA mediante:
- **ZKTeco InBIO 206** — Panel de control de acceso con 2 puertas físicas
- **2 lectores RFID** — Reader 1 (entrada) y Reader 4 (salida del mismo LOCK)
- **SDK:** `plcommpro.dll` — DLL nativa que comunica el panel con el software vía TCP
- **Lógica de autorización:** JSON local actualmente → **migrará a SQL Server**

El flujo es: vehículo activa sensor de piso → lector detecta TAG RFID → sistema consulta BD → si autorizado → LOCK 1 activa motor → brazo sube.

---

## 2. Diccionario de Datos

### 2.1 Modelo principal: `TarjetaRFID` (clase C#)

Esta es la entidad central que actualmente vive en JSON y debe migrar a SQL Server.

| Variable C# | Tipo C# | Tipo SQL sugerido | Descripción |
|---|---|---|---|
| `Numero` | `string` | `VARCHAR(20) PK` | Número único del TAG RFID leído por el lector |
| `NombreUsuario` | `string` | `NVARCHAR(100)` | Nombre del propietario del vehículo/TAG |
| `Observaciones` | `string` | `NVARCHAR(250)` | Notas adicionales (placa, tipo vehículo, etc.) |
| `FechaRegistro` | `DateTime` | `DATETIME2` | Cuándo fue registrado el TAG en el sistema |
| `Habilitada` | `bool` | `BIT` | Si el TAG puede abrir la barrera (1=activo, 0=bloqueado) |

### 2.2 Datos del evento de acceso (parseados desde la DLL en tiempo real)

Cada vez que el panel detecta un TAG, la DLL devuelve una línea CSV. Estos son los campos que el sistema parsea y que **deben guardarse como registro de acceso** en SQL:

| Variable C# | Tipo C# | Tipo SQL sugerido | Descripción | Ejemplo |
|---|---|---|---|---|
| `partes[0]` → `fechaHora` | `string` → `DateTime` | `DATETIME2` | Timestamp del evento según el reloj del panel | `2026-02-27 11:15:52` |
| `partes[1]` → `pin` | `string` → `int` | `INT` | ID de usuario en la memoria interna del InBIO (0 = no registrado en InBIO) | `380` o `0` |
| `partes[2]` → `numeroTarjeta` | `string` | `VARCHAR(20) FK` | Número del TAG RFID leído | `3846766` |
| `partes[3]` → `puertaID` | `int` | `TINYINT` | ID de puerta en el InBIO (1=entrada, 2=salida) | `1` o `2` |
| `partes[4]` → `eventoID` | `int` | `SMALLINT` | Código de evento (ver tabla de eventos) | `0`, `20`, `27` |
| `partes[5]` → `estado` | `string` | `TINYINT` | Dirección del acceso (0=IN/entrada, 1=OUT/salida) | `0` o `1` |
| `partes[6]` → `verificacion` | `string` | `SMALLINT` | Código de verificación del InBIO | `200` o `0` |
| (calculado) → `nombreLector` | `string` | `VARCHAR(20)` | Nombre descriptivo del lector | `Reader 1 (D1-IN)` |
| (calculado) → `fueAutorizado` | `bool` | `BIT` | Si el sistema abrió la barrera | `true` / `false` |
| (calculado) → `fuenteAutorizacion` | `string` | `VARCHAR(10)` | Quién autorizó: `InBIO` o `JSON`/`SQL` | `InBIO` |
| (runtime) → `timestampRecepcion` | `DateTime` | `DATETIME2` | Cuándo el PC procesó el evento (puede diferir del panel) | `2026-02-27 11:21:03` |

### 2.3 Datos de configuración de conexión (actualmente en UI)

| Variable C# | Tipo C# | Tipo SQL sugerido | Descripción |
|---|---|---|---|
| `txtIP.Text` | `string` | `VARCHAR(15)` | IP del panel InBIO |
| `txtPuerto.Text` | `int` | `INT` | Puerto TCP (default 4370) |
| `txtTimeout.Text` | `int` | `INT` | Timeout de conexión en ms |

---

## 3. Esquema Relacional Propuesto

```
┌─────────────────────────┐       ┌──────────────────────────────────┐
│       Tarjetas          │       │         RegistrosAcceso           │
├─────────────────────────┤       ├──────────────────────────────────┤
│ NumeroTarjeta  PK VARCHAR│──────▶│ IdRegistro     PK BIGINT AUTO    │
│ NombreUsuario  NVARCHAR │       │ NumeroTarjeta  FK VARCHAR        │
│ Observaciones  NVARCHAR │       │ FechaHoraPanel    DATETIME2      │
│ FechaRegistro  DATETIME2│       │ FechaHoraPC       DATETIME2      │
│ Habilitada     BIT      │       │ PuertaID          TINYINT        │
└─────────────────────────┘       │ EventoID          SMALLINT       │
                                  │ Estado            TINYINT (0/1)  │
                                  │ NombreLector      VARCHAR(20)    │
                                  │ FueAutorizado     BIT            │
                                  │ FuenteAutorizacion VARCHAR(10)   │
                                  │ PinInBIO          INT            │
                                  │ CodigoVerificacion SMALLINT      │
                                  │ RawLog            VARCHAR(100)   │
                                  └──────────────────────────────────┘

┌──────────────────────────┐       ┌───────────────────────────────┐
│       Lectores           │       │     EventosHardware           │
├──────────────────────────┤       ├───────────────────────────────┤
│ PuertaID    PK TINYINT   │       │ IdEvento     PK BIGINT AUTO   │
│ EstadoID    TINYINT      │       │ FechaHora       DATETIME2     │
│ NombreLector VARCHAR(20) │       │ PuertaID        TINYINT       │
│ Descripcion  VARCHAR(50) │       │ EventoID        SMALLINT      │
└──────────────────────────┘       │ NombreEvento    VARCHAR(50)   │
                                   │ RawLog          VARCHAR(100)  │
                                   └───────────────────────────────┘
```

### Descripción de tablas

| Tabla | Propósito |
|---|---|
| `Tarjetas` | Reemplaza el `tarjetas_autorizadas.json` actual. Catálogo de TAGs autorizados. |
| `RegistrosAcceso` | Log permanente de cada entrada/salida de vehículos. Equivale a la tabla de la pestaña "Lectores" en la UI. |
| `Lectores` | Tabla de referencia estática: Reader 1 (P1/Estado 0), Reader 4 (P2/Estado 1). |
| `EventosHardware` | Log técnico de todos los eventos del InBIO (relays, sensores, botones). Útil para diagnóstico. |

---

## 4. Puntos de Interacción CRUD

### 4.1 Pestaña "⚙️ Configuración" — `Form1.cs`

| Evento UI | Operación SQL | Detalle |
|---|---|---|
| Botón **CONECTAR** | `SELECT` | Verificar si el panel está registrado / traer configuración guardada |
| Conectar exitoso | `INSERT/UPDATE` | Guardar timestamp de última conexión |

### 4.2 Pestaña "🎫 Gestión de Tarjetas" — `Form1.cs` + `TarjetasDB.cs`

| Evento UI | Operación SQL | Tabla | Método C# actual |
|---|---|---|---|
| Botón **Agregar** | `INSERT` | `Tarjetas` | `TarjetasDB.AgregarTarjeta()` |
| Botón **Eliminar** | `DELETE` | `Tarjetas` | `TarjetasDB.EliminarTarjeta()` |
| Botón **Actualizar** | `UPDATE` | `Tarjetas` | `TarjetasDB.ActualizarTarjeta()` |
| Botón **Habilitar/Deshabilitar** | `UPDATE Habilitada` | `Tarjetas` | `TarjetasDB.CambiarEstado()` |
| Botón **🔍 Detectar** | `SELECT` | `Tarjetas` | Al detectar TAG, modo escucha para registro |
| Cargar pestaña | `SELECT *` | `Tarjetas` | `TarjetasDB.ObtenerTodas()` |
| Estadísticas (labels) | `SELECT COUNT(*)` | `Tarjetas` | `TarjetasDB.ObtenerEstadisticas()` |

### 4.3 Evento en tiempo real — `ZkManager_OnEventoHardware()` en `Form1.cs`

**Este es el punto más crítico.** Se dispara cada vez que el lector RFID detecta un TAG (cada ~500ms el timer llama a `GetRTLog`).

| Condición | Operación SQL | Tabla | Detalle |
|---|---|---|---|
| Cualquier TAG leído (E0, E20, E27) | `SELECT` | `Tarjetas` | Buscar si el número de tarjeta existe y está habilitada |
| TAG autorizado (barrera abierta) | `INSERT` | `RegistrosAcceso` | Guardar el registro de acceso con `FueAutorizado=1` |
| TAG denegado (no en BD) | `INSERT` | `RegistrosAcceso` | Guardar con `FueAutorizado=0` para auditoría |
| Cualquier evento de hardware | `INSERT` | `EventosHardware` | Guardar raw log para diagnóstico (opcional) |

### 4.4 Pestaña "🔖 Control de Acceso (RFID)" — tabla en pantalla

| Evento UI | Operación SQL | Tabla |
|---|---|---|
| Cargar / abrir pestaña | `SELECT TOP 100 ... ORDER BY FechaHoraPC DESC` | `RegistrosAcceso` |
| Botón limpiar tabla | Solo limpia la vista local (no DELETE en BD) | — |

---

## 5. Rol de la DLL (`plcommpro.dll`)

### Qué es
Librería nativa de ZKTeco para comunicación con el panel InBIO 206 vía TCP.
Se importa como P/Invoke en C#:

```csharp
[DllImport("plcommpro.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
private static extern IntPtr Connect(string parameters);

[DllImport("plcommpro.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
private static extern int GetRTLog(IntPtr handle, byte[] buffer, int bufferSize);

[DllImport("plcommpro.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
private static extern int ControlDevice(IntPtr handle, int operationID, int p1, int p2, int p3, int p4, string options);
```

### Qué devuelve `GetRTLog` (la fuente de todos los datos de acceso)

La función llena un buffer de bytes con líneas CSV. Cada línea es un evento:

```
2026-02-27 11:15:52,380,3846765,2,0,1,0
     │              │    │      │ │ │ └── Verificación (200 = biométrico, 0 = solo tarjeta)
     │              │    │      │ │ └──── Estado (0=entrada/IN, 1=salida/OUT)
     │              │    │      │ └────── EventoID (0=acceso concedido, 20=extended, 27=exit variant)
     │              │    │      └──────── PuertaID (1=Door1/Reader1, 2=Door2/Reader4)
     │              │    └─────────────── NumeroTarjeta (el dato principal para consultar SQL)
     │              └──────────────────── PIN/UserID en memoria interna InBIO (0 = no registrado en InBIO)
     └─────────────────────────────────── FechaHora según reloj del panel (puede tener retraso vs. PC)
```

### Qué información de la DLL debe almacenarse en SQL

| Dato de la DLL | ¿Guardar en SQL? | Tabla | Razón |
|---|---|---|---|
| NumeroTarjeta (`partes[2]`) | **SÍ — crítico** | `RegistrosAcceso`, `Tarjetas` | Es la llave para identificar el vehículo |
| FechaHora panel (`partes[0]`) | **SÍ** | `RegistrosAcceso.FechaHoraPanel` | Timestamp real del acceso físico |
| PuertaID (`partes[3]`) | **SÍ** | `RegistrosAcceso.PuertaID` | Identifica si fue entrada o salida |
| EventoID (`partes[4]`) | **SÍ** | `RegistrosAcceso.EventoID` | Tipo de autorización (E0/E20/E27) |
| Estado (`partes[5]`) | **SÍ** | `RegistrosAcceso.Estado` | 0=IN, 1=OUT → dirección del acceso |
| PIN InBIO (`partes[1]`) | Opcional | `RegistrosAcceso.PinInBIO` | Solo útil si se usa memoria del InBIO |
| Verificación (`partes[6]`) | Opcional | `RegistrosAcceso.CodigoVerificacion` | Diagnóstico técnico |
| RawLog (línea completa) | Recomendado | `RegistrosAcceso.RawLog` | Para auditoría y troubleshooting |

### Qué hace `ControlDevice` (comandos hacia el hardware)

No devuelve datos a guardar en BD. Solo envía comandos al relay:

```csharp
// Subir brazo: ControlDevice(handle, op=1, p1=1(Door1), p2=1(Lock), p3=1(Pulso), p4=0, "")
// Cancelar:    ControlDevice(handle, op=1, p1=2(Door2), p2=1(Lock), p3=0(OFF), p4=0, "")
```

El resultado (int 0=éxito, 1=éxito alt, negativo=error) se puede guardar en `EventosHardware` para diagnóstico si se desea.

---

## 6. Códigos de Eventos Relevantes para SQL

La columna `EventoID` en `RegistrosAcceso` tendrá estos valores:

| EventoID | Nombre | ¿Genera acceso a BD? | Observación |
|---|---|---|---|
| `0` | Normal Open (Acceso Concedido) | SÍ | TAG en memoria interna InBIO ✅ |
| `1` | Acceso Denegado InBIO | SÍ (denegado) | TAG rechazado por el panel |
| `8` | Relay Activado | NO | Confirmación de hardware, no de acceso |
| `20` | Access Granted Extended | SÍ | Variante de E0 para entrada ✅ |
| `27` | Exit Button Variant | SÍ (si está en SQL) | TAG en BD local pero NO en InBIO → Reader 4 salida ✅ |
| `220` | Sensor Límite Alcanzado | NO | Sensor de posición del brazo |
| `221` | Sensor Salió de Límite | NO | Brazo en movimiento |
| `255` | Panel Idle | NO | Filtrado antes de llegar al sistema |

---

## 7. Consulta SQL mínima requerida en tiempo real

Esta es la consulta que el sistema C# necesita ejecutar **en cada lectura de TAG** (cada vez que llega E0/E20/E27):

```sql
-- Consulta principal de autorización (reemplaza TarjetasDB.ObtenerTarjeta())
SELECT NumeroTarjeta, NombreUsuario, Observaciones, Habilitada
FROM Tarjetas
WHERE NumeroTarjeta = @NumeroTarjeta

-- Si Habilitada = 1 → abrir barrera
-- Si Habilitada = 0 → denegar acceso
-- Si no existe → denegar acceso
```

Y el INSERT de registro de acceso que debe ejecutarse inmediatamente después:

```sql
INSERT INTO RegistrosAcceso 
    (NumeroTarjeta, FechaHoraPanel, FechaHoraPC, PuertaID, EventoID, 
     Estado, NombreLector, FueAutorizado, FuenteAutorizacion, PinInBIO, RawLog)
VALUES 
    (@NumeroTarjeta, @FechaHoraPanel, GETDATE(), @PuertaID, @EventoID,
     @Estado, @NombreLector, @FueAutorizado, @FuenteAutorizacion, @PinInBIO, @RawLog)
```

---

## 8. Consideraciones de Rendimiento

- `GetRTLog` se llama cada **500ms** (timer en Form1.cs) → el SELECT de autorización debe responder en < 100ms
- Se recomienda índice en `Tarjetas.NumeroTarjeta` (ya es PK, pero verificar)
- Se recomienda índice en `RegistrosAcceso.FechaHoraPC` para consultas de historial
- La tabla `RegistrosAcceso` crecerá continuamente → planificar particionado por fecha o archivado periódico
- La conexión SQL debe mantenerse abierta o usar pool de conexiones (no abrir/cerrar en cada evento)

---

## 9. Cadena de conexión sugerida (C#)

```csharp
// En appsettings o Form1.cs
string connectionString = "Server=SERVIDOR_SQL;Database=ParqueaderoPUCESA;User Id=parqueadero_user;Password=***;TrustServerCertificate=True;";
```

El sistema actual usa .NET 10.0 Windows Forms (x86) — usar `Microsoft.Data.SqlClient` NuGet.
