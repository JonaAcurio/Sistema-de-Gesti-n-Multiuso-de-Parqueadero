# 🛠️ Guía de Errores y Soluciones del Sistema

Esta guía documenta los errores comunes encontrados durante el desarrollo, sus causas raíz, las soluciones aplicadas y el procedimiento a seguir en caso de que vuelvan a ocurrir.

---

## 🏎️ FASE 1 — Contadores y Dashboard

### ERROR 1 — Moto manual no resta espacio disponible
**Afecta a:** `Form1.cs` -> método `ActualizarTarjetasCapacidad()`

- **Causa raíz:** Las tarjetas de "OCUPADOS TAG" y "VISITANTES" de la sección MOTOS estaban hardcodeadas a `"0"`. Aunque `CapacidadService` incrementaba el contador, la pantalla no lo reflejaba.
- **Solución:** Se vinculó el texto de las tarjetas a `CapacidadService.MotosAdentro` y `CapacidadService.AdentroVisitante`.
- **Procedimiento:** Si las tarjetas de motos no se actualizan, verificar que las variables en `CapacidadService` estén siendo consultadas en el método de actualización del UI.

### ERROR 2 — Dashboard no refresca tras exoneración
**Afecta a:** `Form1.cs` -> método `ProcesarSalidaEscanerDashboard()`

- **Causa raíz:** No se llamaba a `ActualizarResumenCajaDiaria()` tras procesar una salida desde el escáner del dashboard.
- **Solución:** Se añadió la llamada al método de resumen de caja inmediatamente después de actualizar las tarjetas de capacidad.
- **Procedimiento:** Si el total de caja no cambia tras una salida exonerada, forzar un refresco llamando a `ActualizarResumenCajaDiaria()`.

### ERROR 3 — Contadores de Tags congelados o desincronizados
**Afecta a:** `CapacidadService.cs` + `Form1.cs` -> `Form1_Load()`

- **Causa raíz:** AI reiniciar la app, los contadores del JSON (posiblemente obsoletos) no se sincronizaban con los datos reales de la base de datos recopilados en el inicio.
- **Solución:** 
  1. Se creó `CapacidadService.SincronizarContadores(...)`.
  2. En el inicio, se sincronizan los contadores con la cantidad de tags activos en la DB.
- **Procedimiento:** Si el dashboard no coincide con la realidad física, usar el botón **Resetear Estado Tags** (rol admin) para forzar la sincronía desde la base de datos.
  ```sql
  -- Consulta de validación manual:
  SELECT COUNT(DISTINCT TagCode) FROM RegistrosAcceso
  WHERE FechaSalida IS NULL AND FechaEntrada >= DATEADD(HOUR,-24,GETDATE())
  AND TagCode IS NOT NULL AND TagCode != '';
  ```

---

## 📡 FASE 2 — Lectura de Tags, Barrera y Estados

### ERROR 4 — Lectura invertida (Entrada registra Salida)
- **Causa raíz:** Configuración incorrecta del lector en el firmware del InBIO (marcado como OUT en lugar de IN).
- **Solución:** Se implementó una validación estricta en el software para bloquear la salida si el tag no está registrado como "adentro".
- **Procedimiento:** Ejecutar **Diagnóstico de Antenas** (menú admin). Si aparece `Dir. sistema: SALIDA ⚠️ INVERTIDO`, cambiar la dirección del lector en el software de control de acceso del hardware.

### ERROR 5 — Lectura fantasma o parcial (Salida automática)
**Afecta a:** `Form1.cs` -> `ProcesarTagAutorizacionAsync()`

- **Causa raíz:** El sistema permitía procesar salidas de tags que no tenían entrada previa registrada.
- **Solución:** Bloqueo estricto: si el tag no está en `_tagsAdentro`, la barrera no sube y el flujo se detiene.
- **Procedimiento:** Verificar que el tag esté correctamente registrado en la base de datos como "adentro".

### ERROR 6 — Rebote de lectura (Entrada + Salida inmediata)
- **Causa raíz:** Lectura sucesiva del mismo tag en milisegundos tras una entrada exitosa.
- **Solución:** Se implementó un cooldown de **4 minutos** (configurables) para el mismo tag entre una entrada y una salida.
- **Procedimiento:** Si un usuario necesita salir inmediatamente después de entrar (error humano), el administrador puede usar el botón de **Resetear Estado Tags** o esperar a que expire el cooldown de 4 minutos.

---

> [!TIP]
> **Nota para el Administrador:** Ante cualquier discrepancia visual o lógica en los contadores, el primer paso siempre debe ser el **Resetear Estado Tags** desde el panel de administración para refrescar la memoria del sistema con la Base de Datos.
