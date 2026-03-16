# INFORME TÉCNICO DE INGENIERÍA: DISEÑO Y OPTIMIZACIÓN DE INTERFAZ DE USUARIO (UI/UX)

**Proyecto:** Sistema de Gestión de Parqueaderos PUCESA (SGP)
**Versión de Documento:** 1.0 (Prototipo Funcional V2.0)
**Fecha de Actividad:** Martes, 03 de Marzo de 2026
**Tecnología y Entorno:** 
- Lenguaje: C# (.NET 10.0 Windows — Arquitectura x86)
- Framework UI: Windows Forms (`System.Windows.Forms` / `System.Drawing`)
- IDE / Herramientas: Microsoft Visual Studio, GitHub Copilot, Claude Opus 4.6
- Hardware Objetivo: Panel ZKTeco InBIO 206 (2 puertas, 4 lectores RFID)

---

## 1. Resumen Arquitectónico (Abstract)

El presente informe documenta las especificaciones arquitectónicas orientadas al diseño de interfaz (UI) y experiencia de usuario (UX) para el módulo de escritorio de garita del sistema SGP. El cliente pesado fue diseñado bajo un esquema *Edge Computing*, estableciendo comunicación directa a nivel de red con el hardware inBio 206 mediante su SDK propietario (`plcommpro.dll`). Esta arquitectura desacoplada garantiza la resiliencia operativa de los controles de barrera y mapeo físico en entornos con cortes prolongados de conectividad externa.

## 2. Especificación de Requerimientos de Diseño

El diseño de la vista se fundamenta en principios estrictos de accesibilidad, operatividad y auditoría:

*   **Identidad Institucional Estricta:** Implementación de constantes de color HEX alineadas al manual de marca de la PUCESA.
*   **Eficiencia Cognitiva:** Reducción de la curva de aprendizaje a través de controles semánticos y retroalimentación interactiva (Visual Feedback).
*   **Trazabilidad de Nivel Cero:** Aplicación de políticas de software que impiden manipulaciones mecánicas de hardware sin su correspondiente registro en bitácora (Timestamp + Operador + Motivo).
*   **Telemetría en Interfaz:** Despliegue de indicadores visuales en tiempo real reflejando el estado físico de la placa controladora y periféricos.

## 3. Diccionario de Diseño Visual y Paleta Cromática

### 3.1 Carga Visual Promedio (Regla 60-30-10)
Se estableció un balance matemático de ocupación de color en los formularios principales para mitigar la fatiga visual de los operarios:
*   **60% (Fondo Dominante):** Variables estructurales de bajo contraste (`#F5F7FA` y `#FFFFFF`).
*   **30% (Identidad Institucional):** Herencia de marca PUCESA (`#003366` y `#0052A5`).
*   **10% (Alertas y Acentos):** Semántica de estado; verde (`#28A745`) para transacciones correctas, rojo (`#DC3545`) para bloqueos.

### 3.2 Clasificación Hexadecimal de la Interfaz

**Tabla 1: Estructura e Identidad**
| Variable/Concepto | Valor HEX | Aplicación Arquitectónica |
| :--- | :--- | :--- |
| Deep Sapphire | `#003366` | Cabecera (Header) primaria y contenedor del inicio de sesión. |
| Azul Institucional | `#0052A5` | Acciones primarias (Botón Login) y separadores de grillas (DataGrid). |
| Azul Sidebar | `#002855` | Contenedor de la barra de navegación lateral. |
| Azul Accent | `#4A90D9` | Interacciones secundarias (Botón Conectar Hardware). |

**Tabla 2: Semántica de Estados Operativos (Telemetría)**
| Variable/Concepto | Valor HEX | Aplicación Arquitectónica |
| :--- | :--- | :--- |
| Verde Esmeralda | `#28A745` | Renderizado `LED` en estado alto ("BARRERA ARRIBA") / Evento `Aprobado`. |
| Rojo Suave | `#DC3545` | Renderizado `LED` en estado bajo ("BARRERA ABAJO") / Evento `Excepción`. |
| Rojo Intenso | `#C0392B` | Interrupción de emergencia (`STOP`) y clasificación temporal "Visitantes". |
| Dorado | `#FFC107` | Secuencias de advertencia o purga de hardware (`RESETEAR`). |

**Tabla 3: Clasificación Espacial del Flujo Vehicular (Mapas)**
| Entidad | Valor HEX | Identificador Visual |
| :--- | :--- | :--- |
| Docente | `#2980B9` | Azul |
| Estudiante | `#27AE60` | Verde |
| Administrativo | `#F39C12` | Naranja |
| Puesto Discapacidad | `#8E44AD` | Morado |
| Puesto Moto | `#D35400` | Naranja Intenso |

## 4. Ingeniería de Usabilidad (Heurísticas de Nielsen Aplicadas)

Se auditó la aplicación contra los principios estándar de interacción humana-computadora:

1.  **Visibilidad del Estado de Sistema:** Dibujado GDI+ de indicadores LED con `anti-aliasing` dinámicos atados a la respuesta TCP/IP de la barrera.
2.  **Mapeo Mundo Real:** Implementación de etiquetas semánticas universales (ej. "Abrir Barrera") prescindiendo de argot de redes.
3.  **Control y Libertad del Usuario:** Secuencia física `STOP` asíncrona (sin ventanas modales de confirmación) para interrupción inmediata de accidentes.
4.  **Consistencia y Estándares:** Fuente estandarizada `Segoe UI` y renderizado de componentes `FlatStyle.Flat` eliminando bordes 3D heredados del OS.
5.  **Prevención de Errores (Safety Lock):** Inyección del modal obligatorio `MotiveForm.cs`. El evento de apertura TCP no se dispara hasta confirmar el string de justificación.
6.  **Reconocimiento vs Recuerdo:** Indicador en el sidebar persistente resaltando el controlador activo con una banda selectora de `4px` grosor.
7.  **Flexibilidad y Eficiencia:** Implementación de *hotkeys* nativas (Ej. `Key.Enter` -> *Submit*, `Key.Escape` -> *Dismiss*) y temporizador lógico automático de 3000ms para cierre de barrera.
8.  **Diseño Minimalista:** Redirección de streams de excepciones técnicas (`Exception Logs`) hacia el componente `StatusBar`, manteniendo limpia el área central transaccional.
9.  **Tolerancia y Recuperación a Fallos:** Captura y formateo de errores de autenticación limitados por iteraciones (Ej. "Credenciales incorrectas. Intentos: 3").
10. **Ayuda Integrada:** Inclusión de *Placeholders* (Watermarks) nativos en controles de texto para guiar el formateo de datos.

## 5. Arquitectura de Módulos Visuales (Front-End Local)

El proyecto se estructuró separando las lógicas visuales de las reglas de persistencia, con 8 archivos base:

*   `LoginForm.cs`: Interfaz modal de autenticación segura (Split-Screen UI).
*   `Form1.cs`: Módulo Dashboard `[Main]`. Agrupa telemetría de red y métricas.
*   `MotiveForm.cs`: Diálogo restrictivo para capturar parámetros de auditoría manual.
*   `ParkingSlotForm.cs`: Representación vectorial del recinto. Utiliza los colores de segmentación (Docente, Moto, etc.).
*   `TagRegistroForm.cs`: Módulo transaccional de entrada/salida para el catálogo de entidades vehiculares (CRUD de EPCs).
*   `TicketVisitanteForm.cs`: Interfaz de generación y cálculo financiero de accesos no registrados en base de datos central.
*   *Lógica Desacoplada:*
    *   `DataService.cs`: Puente intermedio para volcado rápido temporal de información en JSON.
    *   `ZKTecoManager.cs`: Singleton encargado del encapsulamiento de punteros y conexiones socket.

## 6. Optimizaciones Críticas a Nivel Código (Rendering & Eventos)

*   **Rasterizado (GDI+):** Uso exhaustivo de bibliotecas nativas de pintado `LinearGradientBrush` en cabeceras superpuestas y polígonos `FillEllipse` procesados con interpolación de suavizado (`Anti-Aliasing`) para los semáforos LED en el mapa.
*   **Debounce Lógico (Anti-Rebote):** Implementación de bloqueos de tiempo transaccional (`Mutex` lógico) que descarta lecturas duplicadas de antenas RFID menores a `5000ms`, previniendo inyección espuria en la base de datos de "Accesos".
*   **Responsividad Geométrica:** Configuración nativa `Anchor` y `Dock`, unidos a overrides genéricos del evento `OnResize`, permitiendo escalado del Layout a cualquier resolución monitor en relación de aspecto estándar.
*   **Aseguramiento de Accesibilidad (WCAG):** Se auditó la paleta contra los estándares Web, validando un contraste matemático de `12.8:1` para fondos azules y fuentes blancas, y ampliando las regiones de impacto (Hitboxes) a un área mínima de `210x48px` previniendo clics fallidos por fatiga del operario.

---

**Firmas de Validación de Ingeniería:**

- Redactado por: Alberto Falconi (UI Designer / Desarrollador SGP)
- Auditado por: _____________________________
- Aprobado por: _____________________________
