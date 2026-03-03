using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace InterfazParqueadero
{
    public partial class Form1 : Form
    {
        private ZKTecoManager zkManager = null!;

        // El reloj espía que leerá los sensores en tiempo real
        private System.Windows.Forms.Timer timerMonitoreo = null!;

        // DataTable para almacenar las lecturas de tarjetas RFID
        private DataTable tablaTarjetas = null!;

        // ★ BASE DE DATOS LOCAL DE TARJETAS AUTORIZADAS ★
        private TarjetasDB tarjetasDB = null!;
        private bool modoDeteccion = false; // Indica si está esperando detectar tarjeta
        private DataTable tablaGestion = null!;
        
        // ★ ANTI-REBOTE: Evita procesar la misma tarjeta muy rápido ★
        private string ultimaTarjetaLeida = "";
        private int ultimoPuertaID = 0;
        private DateTime ultimaLecturaTime = DateTime.MinValue;

        public Form1()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            zkManager = new ZKTecoManager();
            zkManager.OnLog += ManejarLog;

            // Suscribimos la interfaz a los eventos físicos (Sensores y Botón)
            zkManager.OnEventoHardware += ZkManager_OnEventoHardware;

            ConfigurarRelojEspia(); // Inicializamos el reloj
            ConfigurarDataGridTarjetas(); // Inicializamos la tabla de tarjetas

            // ★ INICIALIZAR BASE DE DATOS DE TARJETAS ★
            tarjetasDB = new TarjetasDB();
            ConfigurarDataGridGestion();
            ConfigurarBotonesGestion();
            ActualizarTablaGestion();

            ActualizarEstadoConexion(false);

            // ============================================================
            // 📌 CONFIGURACIÓN INICIAL - AJUSTA ESTOS VALORES AQUÍ
            // ============================================================
            txtIP.Text = "192.168.1.201";      // IP del InBIO
            txtPuerto.Text = "4370";             // Puerto TCP (generalmente 4370)
            txtTimeout.Text = "4000";            // Timeout en milisegundos (aumentado)
            // ============================================================

            CargarLogoPorDefecto();
        }

        // ============================================================
        // 🔖 CONFIGURACIÓN DE LA TABLA DE TARJETAS RFID
        // ============================================================

        private void ConfigurarDataGridTarjetas()
        {
            try
            {
                // Crear el DataTable con las columnas necesarias
                tablaTarjetas = new DataTable();
                tablaTarjetas.Columns.Add("Hora", typeof(string));
                tablaTarjetas.Columns.Add("Lector", typeof(string));
                tablaTarjetas.Columns.Add("Nº Tarjeta", typeof(string));
                tablaTarjetas.Columns.Add("PIN/Usuario", typeof(string));
                tablaTarjetas.Columns.Add("Evento", typeof(string));
                tablaTarjetas.Columns.Add("Estado", typeof(string));

                // Enlazar el DataTable al DataGridView
                dataGridTarjetas.DataSource = tablaTarjetas;

                // Configurar estilos del DataGridView
                dataGridTarjetas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
                dataGridTarjetas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridTarjetas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dataGridTarjetas.EnableHeadersVisualStyles = false;
                dataGridTarjetas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configurando tabla RFID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 🕒 LÓGICA DEL MONITOREO EN TIEMPO REAL
        // ============================================================

        private void ConfigurarRelojEspia()
        {
            timerMonitoreo = new System.Windows.Forms.Timer();
            timerMonitoreo.Interval = 500; // Medio segundo
            timerMonitoreo.Tick += TimerMonitoreo_Tick;
        }

        private void TimerMonitoreo_Tick(object? sender, EventArgs e)
        {
            // En cada "tic-tac", si estamos conectados, leemos la memoria del panel
            if (zkManager != null && zkManager.EstaConectado)
            {
                zkManager.EscucharSensoresYBotones();
            }
        }

        private void ZkManager_OnEventoHardware(int puertaID, int eventoID, string logCompleto)
        {
            // Aseguramos que los cambios visuales ocurran en el hilo principal de la pantalla
            if (InvokeRequired)
            {
                Invoke(new Action(() => ZkManager_OnEventoHardware(puertaID, eventoID, logCompleto)));
                return;
            }

            // ═══════════════════════════════════════════════════════════════
            // MAPA DE EVENTOS — InBIO 206  (sensores en NC, que es lo correcto)
            // ═══════════════════════════════════════════════════════════════
            // Puerta 1  →  LOCK 1  →  sensor UP-OK    →  BARRERA ARRIBA
            // Puerta 2  →  LOCK 2  →  sensor DOWN-OK  →  BARRERA ABAJO
            //
            // ARQUITECTURA DEL SISTEMA:
            //   • Control Wireless: actúa DIRECTO sobre el motor (bypass del InBIO)
            //   • Button1 InBIO: genera Evento 202, activa LOCK 1 → sube brazo
            //   • Sensores NC: UP-OK y DOWN-OK conectados al InBIO (SEN + GND)
            //   • Software: envía comandos ControlDevice → activa LOCK 1 o LOCK 2
            //
            // FLUJO DE EVENTOS:
            //   1. Wireless/Button1/Software → brazo se mueve
            //   2. Brazo llega a límite → sensor NC ABRE → Evento 2 (límite alcanzado)
            //   3. Brazo sale de límite → sensor NC CIERRA → Evento 3 (en movimiento)
            //
            // TABLA DE EVENTOS:
            //   202 = Button1 presionado (tu InBIO específico)
            //     2 = Sensor NC abrió → LÍMITE ALCANZADO (arriba o abajo) ★★★
            //     3 = Sensor NC cerró → brazo SALIÓ de límite (en tránsito)
            //     8 = Relay activado (comando software o button1)
            //    12 = Relay en reposo (confirmación)
            //   255 = Panel idle (spam, se filtra)

            // ── FILTRAR SPAM: Evento 255 (Panel Idle) ──────────────────────────────────
            if (eventoID == 255) return; // Ignoramos para no saturar el log

            // ── MOSTRAR DIAGNÓSTICO: Eventos relevantes ────────────────────────────────
            string nombreEvento = ObtenerNombreEvento(eventoID);
            ManejarLog($"🔍 [P{puertaID}] Evento {eventoID} ({nombreEvento})", ZKTecoManager.TipoMensaje.Informacion);

            // ══════════════════════════════════════════════════════════════════════════
            // 🔖 LECTORES RFID — Detección de Tarjetas (Evento 0 y 1)
            // ══════════════════════════════════════════════════════════════════════════
            // InBIO 206 tiene 2 puertas, cada puerta puede tener 2 lectores (IN y OUT)
            //   • Reader 1 = Door 1 Reader IN  (cables: WD1, WD0)
            //   • Reader 2 = Door 1 Reader OUT
            //   • Reader 3 = Door 2 Reader IN
            //   • Reader 4 = Door 2 Reader OUT (cables: GLED, WD1)
            //
            // Evento 0 = Acceso Normal (tarjeta válida leída)
            // Evento 1 = Acceso Denegado (tarjeta no autorizada)
            // Evento 20 = Acceso Concedido (Extendido) - variante del evento 0
            //
            // Formato del log: "Fecha Hora, PIN, Tarjeta, Puerta, Evento, Estado, Verificacion"
            //   PIN = ID de usuario en la base de datos
            //   Tarjeta = Número de tarjeta RFID
            //   Puerta = 1 o 2
            //   Estado = 0 (entrada/IN) o 1 (salida/OUT)
            if (eventoID == 0 || eventoID == 1 || eventoID == 20)
            {
                // Obtener número de tarjeta del log
                string[] partes = logCompleto.Split(',');
                string numeroTarjeta = partes.Length >= 3 ? partes[2].Trim() : "";

                // ★★★ MODO DETECCIÓN: Capturar tarjeta automáticamente ★★★
                if (modoDeteccion && !string.IsNullOrEmpty(numeroTarjeta) && (eventoID == 0 || eventoID == 20))
                {
                    // Capturar tarjeta detectada
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtNumeroTarjeta.Text = numeroTarjeta;
                        txtNumeroTarjeta.Enabled = true;
                        modoDeteccion = false;
                        btnDetectarTarjeta.BackColor = Color.FromArgb(52, 152, 219);
                        btnDetectarTarjeta.Text = "🔍 Detectar";
                        txtNumeroTarjeta.PlaceholderText = "Ej: 3846765";
                        txtNombreUsuario.Focus(); // Mover foco al campo de nombre
                    });

                    ManejarLog($"✅ Tarjeta detectada: {numeroTarjeta} - Ingrese nombre de usuario", ZKTecoManager.TipoMensaje.Exito);
                    return; // No procesar más, solo capturamos el número
                }

                // Procesar lectura (agregar a tabla de accesos)
                ProcesarLecturaTarjeta(puertaID, eventoID, logCompleto);
                
                // ★★★ CONTROL AUTOMÁTICO DE BARRERA ★★★
                // Si InBIO envía E0 o E20 (Acceso Concedido) → CONFIAR EN EL InBIO y abrir barrera
                if (eventoID == 0 || eventoID == 20) // Acceso concedido por el InBIO (evento 0 o 20)
                {
                    // Parsear el estado del log para saber si es IN (0) o OUT (1)
                    if (partes.Length >= 6)
                    {
                        string estado = partes[5].Trim(); // 0=IN (entrada), 1=OUT (salida)
                        
                        // ★★★ ANTI-REBOTE: Ignorar lecturas duplicadas en menos de 5 segundos ★★★
                        TimeSpan tiempoTranscurrido = DateTime.Now - ultimaLecturaTime;
                        if (numeroTarjeta == ultimaTarjetaLeida && 
                            puertaID == ultimoPuertaID && 
                            tiempoTranscurrido.TotalSeconds < 5)
                        {
                            ManejarLog($"⏭️ Lectura duplicada ignorada ({tiempoTranscurrido.TotalSeconds:F1}s) - Anti-rebote activo", ZKTecoManager.TipoMensaje.Advertencia);
                            return; // Ignorar lectura duplicada
                        }
                        
                        // Actualizar última lectura
                        ultimaTarjetaLeida = numeroTarjeta;
                        ultimoPuertaID = puertaID;
                        ultimaLecturaTime = DateTime.Now;
                        
                        // Obtener info de la tarjeta (si existe en BD local)
                        var tarjeta = tarjetasDB.ObtenerTarjeta(numeroTarjeta);
                        string nombreUsuario = tarjeta?.NombreUsuario ?? "Usuario InBIO";
                        
                        // ⚠️ ADVERTENCIA si no está en BD local (solo informativo, NO bloquea)
                        if (tarjeta == null)
                        {
                            ManejarLog($"ℹ️ Tarjeta {numeroTarjeta} autorizada por InBIO pero NO está en base local", ZKTecoManager.TipoMensaje.Advertencia);
                        }
                        
                        // ★★★ CONFIGURACIÓN SIN PUENTE FÍSICO ★★★
                        // Reader 1 (P1, estado 0 = IN) → LOCK 1 (ABRIR)
                        // Reader 4 (P2, estado 1 = OUT) → LOCK 1 (ABRIR) - mismo LOCK
                        // Solo hay 1 puerta física, ambos readers la controlan
                        
                        if (puertaID == 1 && estado == "0")
                        {
                            // ENTRADA: Reader 1 → Activa LOCK 1
                            ManejarLog($"🚗 ✅ AUTORIZADO: {nombreUsuario} (Tarjeta {numeroTarjeta}) - ENTRADA", ZKTecoManager.TipoMensaje.Exito);
                            zkManager.LevantarBrazo(puerta: 1); 
                        }
                        else if (puertaID == 2 && estado == "1")
                        {
                            // SALIDA: Reader 4 → Activa LOCK 1 con cancelarLock2=true
                            // Razón: InBIO auto-activa LOCK 2 al conceder acceso Door 2.
                            // Eso genera señal BAJAR simultánea con SUBIR → motor bloqueado.
                            // cancelarLock2=true anula ese pulso antes de activar LOCK 1.
                            ManejarLog($"🚗 ✅ AUTORIZADO: {nombreUsuario} (Tarjeta {numeroTarjeta}) - SALIDA", ZKTecoManager.TipoMensaje.Exito);
                            zkManager.LevantarBrazo(puerta: 1, cancelarLock2: true);
                        }
                    }
                }
                else if (eventoID == 1)
                {
                    // Evento 1 = Acceso denegado por el InBIO (tarjeta no registrada en el panel)
                    ManejarLog($"⚠️ Tarjeta {numeroTarjeta} rechazada por el InBIO - No registrada en el panel", ZKTecoManager.TipoMensaje.Advertencia);
                }
                
                return; // Ya procesado, no seguir con lógica de barrera
            }

            // ══════════════════════════════════════════════════════════════════════════
            // ⚡ BUTTON1 DEL INBIO (Evento 202)
            // ══════════════════════════════════════════════════════════════════════════
            if (puertaID == 1 && eventoID == 202)
            {
                ManejarLog($"⚡ ¡Button1 presionado! Ejecutando apertura...", ZKTecoManager.TipoMensaje.Exito);
                // El Button1 solo notifica pero NO activa el relay automáticamente
                // Nosotros debemos enviar el comando
                if (zkManager.LevantarBrazo())
                {
                    MostrarBarreraArriba(); // Feedback inmediato
                }
                return;
            }

            // ══════════════════════════════════════════════════════════════════════════
            // 🔘 EXIT BUTTON VARIANT (Evento 27/28)
            // ══════════════════════════════════════════════════════════════════════════
            // El Reader 4 genera E27 para tags que NO están en la memoria interna del InBIO.
            // Si el tag SÍ está en nuestro JSON local → autorizar salida y abrir LOCK 1.
            // Si no está en JSON → ignorar (no es un vehículo autorizado).
            if (eventoID == 27 || eventoID == 28)
            {
                string[] partesE27 = logCompleto.Split(',');
                string tarjetaE27 = partesE27.Length >= 3 ? partesE27[2].Trim() : "";

                if (!string.IsNullOrEmpty(tarjetaE27) && tarjetaE27 != "0")
                {
                    // Verificar si está en JSON local
                    var tarjetaJson = tarjetasDB.ObtenerTarjeta(tarjetaE27);
                    if (tarjetaJson != null)
                    {
                        // ★ Tag en JSON → autorizar salida por Reader 4 ★
                        // Anti-rebote: ignorar si se acaba de procesar
                        TimeSpan tiempoE27 = DateTime.Now - ultimaLecturaTime;
                        if (tarjetaE27 == ultimaTarjetaLeida && puertaID == ultimoPuertaID && tiempoE27.TotalSeconds < 5)
                        {
                            ManejarLog($"⏭️ E27 duplicado ignorado ({tiempoE27.TotalSeconds:F1}s) - Anti-rebote", ZKTecoManager.TipoMensaje.Advertencia);
                            return;
                        }
                        ultimaTarjetaLeida = tarjetaE27;
                        ultimoPuertaID = puertaID;
                        ultimaLecturaTime = DateTime.Now;

                        ManejarLog($"🚗 ✅ AUTORIZADO vía JSON: {tarjetaJson.NombreUsuario} (Tarjeta {tarjetaE27}) - SALIDA (E27)", ZKTecoManager.TipoMensaje.Exito);
                        zkManager.LevantarBrazo(puerta: 1, cancelarLock2: true);
                        return;
                    }
                }

                // Sin número de tarjeta o no está en JSON → ignorar
                ManejarLog($"🔘 E{eventoID} sin autorización JSON - Ignorando", ZKTecoManager.TipoMensaje.Informacion);
                return;
            }

            // ⬆️ BARRERA ARRIBA — Puerta 1 (LOCK 1 / sensor UP-OK)
            // ══════════════════════════════════════════════════════════════════════════
            // Detecta CUALQUIER forma de subir el brazo:
            //   • Comando software → Evento 8 (relay LOCK 1)
            //   • Button1 InBIO → Evento 202 → luego Evento 8
            //   • Sensor UP-OK activado → Evento 220 (límite alcanzado) ⭐
            //   • Sensor UP-OK en AUX → Evento 101 (AUX1 Input)
            //   • Sensor UP-OK en DOOR → Evento 2 (Door Sensor)
            if (puertaID == 1 && (eventoID == 2 || eventoID == 8 || eventoID == 12 || eventoID == 101 || eventoID == 220))
            {
                if (eventoID == 220)
                    ManejarLog($"🎯 ✓ Sensor UP-OK activado (E220) → Barrera ARRIBA", ZKTecoManager.TipoMensaje.Exito);
                else if (eventoID == 2)
                    ManejarLog($"🎯 ✓ Sensor UP-OK activado (Door Sensor) → Barrera ARRIBA", ZKTecoManager.TipoMensaje.Exito);
                else if (eventoID == 101)
                    ManejarLog($"🎯 ✓ Sensor UP-OK activado (AUX1) → Barrera ARRIBA", ZKTecoManager.TipoMensaje.Exito);
                else if (eventoID == 8)
                    ManejarLog($"⚙️ ✓ LOCK 1 activado → Subiendo brazo", ZKTecoManager.TipoMensaje.Exito);
                else
                    ManejarLog($"✓ Confirmación LOCK 1 en reposo", ZKTecoManager.TipoMensaje.Exito);
                
                MostrarBarreraArriba();
            }
            // ══════════════════════════════════════════════════════════════════════════
            // ⬇️ BARRERA ABAJO — Puerta 2 (LOCK 2 / sensor DOWN-OK)
            // ══════════════════════════════════════════════════════════════════════════
            // Detecta CUALQUIER forma de bajar el brazo:
            //   • Comando software → Evento 8 (relay LOCK 2)
            //   • Sensor DOWN-OK activado → Evento 220 (límite alcanzado) ⭐
            //   • Sensor DOWN-OK en AUX → Evento 102 (AUX2 Input)
            //   • Sensor DOWN-OK en DOOR → Evento 2 (Door Sensor)
            else if (puertaID == 2 && (eventoID == 2 || eventoID == 8 || eventoID == 12 || eventoID == 102 || eventoID == 220))
            {
                if (eventoID == 220)
                    ManejarLog($"🎯 ✓ Sensor DOWN-OK activado (E220) → Barrera ABAJO", ZKTecoManager.TipoMensaje.Exito);
                else if (eventoID == 2)
                    ManejarLog($"🎯 ✓ Sensor DOWN-OK activado (Door Sensor) → Barrera ABAJO", ZKTecoManager.TipoMensaje.Exito);
                else if (eventoID == 102)
                    ManejarLog($"🎯 ✓ Sensor DOWN-OK activado (AUX2) → Barrera ABAJO", ZKTecoManager.TipoMensaje.Exito);
                else if (eventoID == 8)
                    ManejarLog($"⚙️ ✓ LOCK 2 activado → Bajando brazo", ZKTecoManager.TipoMensaje.Exito);
                else
                    ManejarLog($"✓ Confirmación LOCK 2 en reposo", ZKTecoManager.TipoMensaje.Exito);
                
                MostrarBarreraAbajo();
            }
            // ══════════════════════════════════════════════════════════════════════════
            // ↔️ BRAZO EN MOVIMIENTO (Evento 3 o 221: Sensor desactivado)
            // ══════════════════════════════════════════════════════════════════════════
            else if (eventoID == 3 || eventoID == 221)
            {
                if (eventoID == 221)
                    ManejarLog($"↔️ Brazo en tránsito (E221: salió de límite P{puertaID})", ZKTecoManager.TipoMensaje.Advertencia);
                else
                    ManejarLog($"↔️ Brazo en tránsito (salió de límite P{puertaID})", ZKTecoManager.TipoMensaje.Advertencia);
            }
            // ══════════════════════════════════════════════════════════════════════════
            // 🔍 DIAGNÓSTICO: Capturar eventos desconocidos de P1/P2 (sensores wireless)
            // ══════════════════════════════════════════════════════════════════════════
            else if (puertaID == 1 || puertaID == 2)
            {
                ManejarLog($"⚠️ EVENTO NO MANEJADO en P{puertaID}: E{eventoID}", ZKTecoManager.TipoMensaje.Advertencia);
                ManejarLog($"   → Si usaste el control wireless, este puede ser el código del sensor", ZKTecoManager.TipoMensaje.Informacion);
            }
        }

        private string ObtenerNombreEvento(int eventoID)
        {
            return eventoID switch
            {
                0 => "Normal Open (Acceso Concedido)",
                1 => "Normal Close (Acceso Denegado)",
                2 => "Sensor NC Abrió (Límite Alcanzado)",
                3 => "Sensor NC Cerró (Brazo Salió)",
                5 => "Exit Button",
                8 => "Relay Activado",
                9 => "Exit Button Pressed",
                10 => "Door Open Too Long",
                12 => "Relay en Reposo",
                20 => "Access Granted (Extended)",
                27 => "Exit Button Variant",
                28 => "Exit Button Long Press",
                34 => "Duress Alarm",
                101 => "AUX Input Alarm 1",
                102 => "AUX Input Alarm 2",
                202 => "Button1 Presionado (InBIO)",
                220 => "Sensor Activado (Límite Alcanzado)",
                221 => "Sensor Desactivado (Salió de Límite)",
                255 => "Panel Idle",
                _ => "Desconocido"
            };
        }

        private void MostrarBarreraArriba()
        {
            lblIndicadorArriba.BackColor = Color.MediumSeaGreen;
            lblIndicadorAbajo.BackColor = Color.DimGray;
        }

        private void MostrarBarreraAbajo()
        {
            lblIndicadorAbajo.BackColor = Color.Tomato;
            lblIndicadorArriba.BackColor = Color.DimGray;
        }

        // ============================================================
        // 🎨 LOGO Y DISEÑO BÁSICO
        // ============================================================

        private void CargarLogoPorDefecto()
        {
            string rutaLogo = System.IO.Path.Combine(Application.StartupPath, "logo.png");

            if (System.IO.File.Exists(rutaLogo))
            {
                try
                {
                    pictureBoxLogo.Image = Image.FromFile(rutaLogo);
                    ManejarLog("Logo cargado correctamente.", ZKTecoManager.TipoMensaje.Exito);
                }
                catch (Exception ex)
                {
                    ManejarLog($"No se pudo cargar el logo: {ex.Message}", ZKTecoManager.TipoMensaje.Advertencia);
                    CrearLogoPlaceholder();
                }
            }
            else
            {
                CrearLogoPlaceholder();
            }
        }

        private void CrearLogoPlaceholder()
        {
            Bitmap placeholder = new Bitmap(60, 60);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.FromArgb(41, 128, 185));
                using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString("LOGO", font, brush, new RectangleF(0, 0, 60, 60), sf);
                }
            }
            pictureBoxLogo.Image = placeholder;
        }

        private void PictureBoxLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                ofd.Title = "Selecciona el logo de tu universidad";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBoxLogo.Image = Image.FromFile(ofd.FileName);
                        ManejarLog("Logo actualizado correctamente.", ZKTecoManager.TipoMensaje.Exito);

                        string rutaDestino = System.IO.Path.Combine(Application.StartupPath, "logo.png");
                        System.IO.File.Copy(ofd.FileName, rutaDestino, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================================
        // ⚙️ CONTROLES Y EVENTOS DE INTERFAZ
        // ============================================================

        private void ManejarLog(string mensaje, ZKTecoManager.TipoMensaje tipo)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ManejarLog(mensaje, tipo)));
                return;
            }

            string textoFinal = $"[{DateTime.Now:HH:mm:ss}] {mensaje}";
            listBoxLogs.Items.Add(textoFinal);

            int index = listBoxLogs.Items.Count - 1;
            listBoxLogs.TopIndex = index;

            Color color = tipo switch
            {
                ZKTecoManager.TipoMensaje.Exito => Color.Green,
                ZKTecoManager.TipoMensaje.Error => Color.Red,
                ZKTecoManager.TipoMensaje.Advertencia => Color.Orange,
                _ => Color.Blue
            };

            listBoxLogs.ForeColor = color;
            listBoxLogs.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManejarLog("Sistema de Control de Parqueadero PUCESA iniciado.", ZKTecoManager.TipoMensaje.Exito);
            ManejarLog("SDK ZKTeco cargado correctamente.", ZKTecoManager.TipoMensaje.Informacion);
            ManejarLog("Configure la IP y presione 'CONECTAR' para iniciar.", ZKTecoManager.TipoMensaje.Informacion);
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            if (zkManager.EstaConectado)
            {
                timerMonitoreo.Stop(); // Detenemos el reloj antes de desconectar

                zkManager.Desconectar();
                ActualizarEstadoConexion(false);
                btnConectar.Text = "🔌 CONECTAR";
                btnConectar.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                string ip = string.IsNullOrEmpty(txtIP.Text) ? "192.168.1.201" : txtIP.Text;
                int puerto = int.TryParse(txtPuerto.Text, out int p) ? p : 4370;
                int timeout = int.TryParse(txtTimeout.Text, out int t) ? t : 4000;

                bool conectado = zkManager.Conectar(ip, puerto, timeout);

                ActualizarEstadoConexion(conectado);

                if (conectado)
                {
                    timerMonitoreo.Start(); // Arrancamos el reloj al conectar con éxito

                    btnConectar.Text = "🔌 DESCONECTAR";
                    btnConectar.BackColor = Color.Crimson;
                }
            }
        }

        /// <summary>
        /// BOTÓN DE EMERGENCIA: Resetea completamente el sistema InBIO
        /// Apaga todos los relés, restaura modo automático
        /// Útil cuando el sistema se queda en un estado inconsistente
        /// </summary>
        private void BtnResetearSistema_Click(object sender, EventArgs e)
        {
            if (!zkManager.EstaConectado)
            {
                MessageBox.Show("Debe estar conectado al InBIO para resetear el sistema.",
                    "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "⚠️ ADVERTENCIA\n\n" +
                "Esto apagará TODOS los relés (LOCK1 y LOCK2) y restaurará el sistema.\n\n" +
                "¿Está seguro de que desea continuar?",
                "Resetear Sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool exito = zkManager.ResetearSistemaEmergencia();
                
                if (exito)
                {
                    MessageBox.Show("✓ Sistema reseteado correctamente.\n\nTodos los relés apagados y restaurados a modo automático.",
                        "Reseteo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("✗ Hubo errores durante el reseteo.\n\nRevise los logs para más detalles.",
                        "Reseteo con Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// BOTÓN DE EMERGENCIA: Detiene inmediatamente todas las salidas
        /// Sin confirmación para uso rápido en emergencias
        /// </summary>
        private void BtnStopEmergencia_Click(object sender, EventArgs e)
        {
            if (!zkManager.EstaConectado)
            {
                MessageBox.Show("Debe estar conectado al InBIO para ejecutar el STOP.",
                    "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SIN confirmación - acción inmediata en emergencias
            zkManager.DetenerTodasSalidas();
            
            MessageBox.Show("🛑 STOP ejecutado.\n\nTodas las salidas han sido detenidas.",
                "Stop Ejecutado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLevantar_Click(object sender, EventArgs e)
        {
            if (zkManager.LevantarBrazo())
                MostrarBarreraArriba();
        }

        private void BtnBajar_Click(object sender, EventArgs e)
        {
            if (zkManager.BajarBrazo())
                MostrarBarreraAbajo();
        }

        private void BtnAutomatico_Click(object sender, EventArgs e)
        {
            zkManager.ModoDiagnostico();
        }

        private void BtnLimpiarLogs_Click(object sender, EventArgs e)
        {
            listBoxLogs.Items.Clear();
            ManejarLog("Logs limpiados.", ZKTecoManager.TipoMensaje.Informacion);
        }

        private void BtnCopiarLogs_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLogs.Items.Count == 0)
                {
                    ManejarLog("No hay logs para copiar.", ZKTecoManager.TipoMensaje.Advertencia);
                    return;
                }

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine("═══════════════════════════════════════════════════");
                sb.AppendLine("LOGS DEL SISTEMA - INTERFAZ PARQUEADERO PUCESA");
                sb.AppendLine($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                sb.AppendLine("═══════════════════════════════════════════════════");
                sb.AppendLine();

                foreach (var item in listBoxLogs.Items)
                {
                    sb.AppendLine(item.ToString());
                }

                sb.AppendLine();
                sb.AppendLine("═══════════════════════════════════════════════════");
                sb.AppendLine("FIN DE LOGS");
                sb.AppendLine("═══════════════════════════════════════════════════");

                Clipboard.SetText(sb.ToString());

                ManejarLog($"✓ {listBoxLogs.Items.Count} líneas copiadas al portapapeles.", ZKTecoManager.TipoMensaje.Exito);
            }
            catch (Exception ex)
            {
                ManejarLog($"Error al copiar: {ex.Message}", ZKTecoManager.TipoMensaje.Error);
            }
        }

        // ============================================================
        // 🔖 PROCESAMIENTO DE LECTURAS DE TARJETAS RFID
        // ============================================================

        private void ProcesarLecturaTarjeta(int puertaID, int eventoID, string logCompleto)
        {
            try
            {
                // Formato InBIO: "Fecha Hora, PIN, Tarjeta, Puerta, Evento, Estado, Verificacion"
                // Ejemplo: "2026-02-26 16:30:45,1234,567890,1,0,0,1"
                string[] partes = logCompleto.Split(',');
                
                if (partes.Length >= 7)
                {
                    string fechaHora = partes[0].Trim();
                    string pin = partes[1].Trim();
                    string numTarjeta = partes[2].Trim();
                    string estado = partes[5].Trim(); // 0=IN (entrada), 1=OUT (salida)
                    string verificacion = partes[6].Trim();

                    // Determinar qué lector específico
                    // Reader 1 = P1 IN (estado 0)
                    // Reader 2 = P1 OUT (estado 1)
                    // Reader 3 = P2 IN (estado 0)
                    // Reader 4 = P2 OUT (estado 1)
                    string nombreLector = "";
                    if (puertaID == 1 && estado == "0")
                        nombreLector = "Reader 1 (D1-IN)"; // Tu Reader 1 con WD1, WD0
                    else if (puertaID == 1 && estado == "1")
                        nombreLector = "Reader 2 (D1-OUT)";
                    else if (puertaID == 2 && estado == "0")
                        nombreLector = "Reader 3 (D2-IN)";
                    else if (puertaID == 2 && estado == "1")
                        nombreLector = "Reader 4 (D2-OUT)"; // Tu Reader 4 con GLED, WD1
                    else
                        nombreLector = $"P{puertaID} (E{estado})";

                    // Determinar el tipo de evento (E0 o E20 = Concedido, E1 = Denegado)
                    string tipoEvento = (eventoID == 0 || eventoID == 20) ? "✅ Acceso Concedido" : "❌ Acceso Denegado";
                    string estadoTexto = estado == "0" ? "ENTRADA (IN)" : "SALIDA (OUT)";

                    // Agregar fila a la tabla (las más nuevas arriba)
                    DataRow fila = tablaTarjetas.NewRow();
                    fila["Hora"] = fechaHora;
                    fila["Lector"] = nombreLector;
                    fila["Nº Tarjeta"] = numTarjeta;
                    fila["PIN/Usuario"] = pin;
                    fila["Evento"] = tipoEvento;
                    fila["Estado"] = estadoTexto;
                    tablaTarjetas.Rows.InsertAt(fila, 0); // Insertar al inicio

                    // Actualizar label con último acceso
                    lblUltimoAcceso.Text = $"Último acceso: {nombreLector} - Tarjeta {numTarjeta} a las {fechaHora}";
                    lblUltimoAcceso.ForeColor = eventoID == 0 ? Color.FromArgb(46, 204, 113) : Color.FromArgb(231, 76, 60);

                    // Log en consola
                    ManejarLog($"🔖 {tipoEvento} | {nombreLector} | Tarjeta: {numTarjeta} | Usuario: {pin}", 
                               eventoID == 0 ? ZKTecoManager.TipoMensaje.Exito : ZKTecoManager.TipoMensaje.Error);

                    // Limitar a 100 registros en la tabla
                    while (tablaTarjetas.Rows.Count > 100)
                    {
                        tablaTarjetas.Rows.RemoveAt(tablaTarjetas.Rows.Count - 1);
                    }

                    // Resaltar la fila más reciente
                    if (dataGridTarjetas.Rows.Count > 0)
                    {
                        dataGridTarjetas.FirstDisplayedScrollingRowIndex = 0;
                        dataGridTarjetas.Rows[0].Selected = true;
                    }
                }
                else
                {
                    ManejarLog($"⚠️ Formato de log de tarjeta incorrecto: {logCompleto}", ZKTecoManager.TipoMensaje.Advertencia);
                }
            }
            catch (Exception ex)
            {
                ManejarLog($"Error procesando tarjeta: {ex.Message}", ZKTecoManager.TipoMensaje.Error);
            }
        }

        private void BtnLimpiarTarjetas_Click(object? sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea limpiar todas las lecturas de tarjetas?",
                    "Confirmar Limpieza",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int cantidad = tablaTarjetas.Rows.Count;
                    tablaTarjetas.Clear();
                    lblUltimoAcceso.Text = "Último acceso: Esperando lectura...";
                    lblUltimoAcceso.ForeColor = Color.FromArgb(41, 128, 185);
                    ManejarLog($"🗑️ Tabla de tarjetas limpiada ({cantidad} registros eliminados)", ZKTecoManager.TipoMensaje.Informacion);
                }
            }
            catch (Exception ex)
            {
                ManejarLog($"Error al limpiar tabla: {ex.Message}", ZKTecoManager.TipoMensaje.Error);
            }
        }

        // ============================================================
        // MÉTODOS AUXILIARES
        // ============================================================

        private void ActualizarEstadoConexion(bool conectado)
        {
            panelEstado.BackColor = conectado ? Color.LimeGreen : Color.Gray;
            lblEstado.Text = conectado ? "CONECTADO" : "DESCONECTADO";
            lblEstado.ForeColor = Color.White;

            if (!conectado)
            {
                lblIndicadorArriba.BackColor = Color.DimGray;
                lblIndicadorAbajo.BackColor = Color.DimGray;
            }

            btnLevantar.Enabled = conectado;
            btnBajar.Enabled = conectado;
            btnAutomatico.Enabled = conectado;

            toolStripStatusLabel.Text = conectado
                ? $"Conectado a {txtIP.Text}"
                : "Sin conexión";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (zkManager.EstaConectado)
            {
                timerMonitoreo.Stop(); // Apagamos el reloj
                zkManager.Desconectar();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════════════════════════════════════
        // 🎫 GESTIÓN DE TARJETAS RFID - BASE DE DATOS LOCAL
        // ══════════════════════════════════════════════════════════════════════════

        private void ConfigurarDataGridGestion()
        {
            try
            {
                // Crear el DataTable para gestión
                tablaGestion = new DataTable();
                tablaGestion.Columns.Add("Número", typeof(string));
                tablaGestion.Columns.Add("Usuario", typeof(string));
                tablaGestion.Columns.Add("Observaciones", typeof(string));
                tablaGestion.Columns.Add("Fecha Registro", typeof(string));
                tablaGestion.Columns.Add("Estado", typeof(string));

                // Enlazar al DataGridView
                dataGridGestion.DataSource = tablaGestion;

                // Estilos
                dataGridGestion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
                dataGridGestion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridGestion.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dataGridGestion.EnableHeadersVisualStyles = false;
                dataGridGestion.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configurando tabla gestión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarBotonesGestion()
        {
            btnAgregarManual.Click += BtnAgregarManual_Click;
            btnDetectarTarjeta.Click += BtnDetectarTarjeta_Click;
            btnEliminarTarjeta.Click += BtnEliminarTarjeta_Click;
            btnHabilitarDeshabilitar.Click += BtnHabilitarDeshabilitar_Click;
        }

        private void ActualizarTablaGestion()
        {
            tablaGestion.Clear();

            var tarjetas = tarjetasDB.ObtenerTodas();
            foreach (var tarjeta in tarjetas)
            {
                DataRow fila = tablaGestion.NewRow();
                fila["Número"] = tarjeta.Numero;
                fila["Usuario"] = tarjeta.NombreUsuario;
                fila["Observaciones"] = tarjeta.Observaciones;
                fila["Fecha Registro"] = tarjeta.FechaRegistro.ToString("dd/MM/yyyy HH:mm");
                fila["Estado"] = tarjeta.Habilitada ? "✅ HABILITADA" : "❌ DESHABILITADA";
                tablaGestion.Rows.Add(fila);
            }

            // Actualizar estadísticas
            var stats = tarjetasDB.ObtenerEstadisticas();
            lblEstadisticas.Text = $"Total: {stats.total} | Habilitadas: {stats.habilitadas} | Deshabilitadas: {stats.deshabilitadas}";
        }

        private void BtnAgregarManual_Click(object? sender, EventArgs e)
        {
            string numero = txtNumeroTarjeta.Text.Trim();
            string usuario = txtNombreUsuario.Text.Trim();
            string observaciones = txtObservaciones.Text.Trim();

            // Validaciones
            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Debe ingresar el número de tarjeta.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Debe ingresar el nombre del usuario.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar agregar
            bool agregado = tarjetasDB.AgregarTarjeta(numero, usuario, observaciones);

            if (agregado)
            {
                MessageBox.Show($"✅ Tarjeta {numero} agregada exitosamente y HABILITADA.\n\nUsuario: {usuario}", 
                    "Tarjeta Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                txtNumeroTarjeta.Clear();
                txtNombreUsuario.Clear();
                txtObservaciones.Clear();

                // Actualizar tabla
                ActualizarTablaGestion();

                ManejarLog($"✅ Nueva tarjeta registrada: {numero} ({usuario})", ZKTecoManager.TipoMensaje.Exito);
            }
            else
            {
                MessageBox.Show($"❌ La tarjeta {numero} ya existe en la base de datos.", 
                    "Tarjeta Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDetectarTarjeta_Click(object? sender, EventArgs e)
        {
            if (!zkManager.EstaConectado)
            {
                MessageBox.Show("Debe estar conectado al InBIO para detectar tarjetas.", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!modoDeteccion)
            {
                // ACTIVAR MODO DETECCIÓN
                modoDeteccion = true;
                btnDetectarTarjeta.BackColor = Color.FromArgb(231, 76, 60); // Rojo
                btnDetectarTarjeta.Text = "⏹ Cancelar";
                txtNumeroTarjeta.Text = "";
                txtNumeroTarjeta.PlaceholderText = "Esperando lectura...";
                txtNumeroTarjeta.Enabled = false;

                ManejarLog("🔍 MODO DETECCIÓN ACTIVADO: Presente una tarjeta en cualquier reader...", ZKTecoManager.TipoMensaje.Advertencia);
                MessageBox.Show("🔍 Modo Detección Activado\n\nPresente una tarjeta RFID en cualquier reader (entrada o salida).\n\nEl número se capturará automáticamente.",
                    "Esperando Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // CANCELAR MODO DETECCIÓN
                modoDeteccion = false;
                btnDetectarTarjeta.BackColor = Color.FromArgb(52, 152, 219); // Azul
                btnDetectarTarjeta.Text = "🔍 Detectar";
                txtNumeroTarjeta.PlaceholderText = "Ej: 3846765";
                txtNumeroTarjeta.Enabled = true;

                ManejarLog("⏹ Modo detección cancelado", ZKTecoManager.TipoMensaje.Informacion);
            }
        }

        private void BtnEliminarTarjeta_Click(object? sender, EventArgs e)
        {
            if (dataGridGestion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tarjeta de la lista para eliminar.", "Ninguna Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dataGridGestion.SelectedRows[0];
            string numero = filaSeleccionada.Cells["Número"].Value?.ToString() ?? "";
            string usuario = filaSeleccionada.Cells["Usuario"].Value?.ToString() ?? "";

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de ELIMINAR la tarjeta?\n\nNúmero: {numero}\nUsuario: {usuario}\n\n⚠️ Esta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                bool eliminado = tarjetasDB.EliminarTarjeta(numero);

                if (eliminado)
                {
                    MessageBox.Show($"✅ Tarjeta {numero} eliminada exitosamente.", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaGestion();
                    ManejarLog($"🗑️ Tarjeta eliminada: {numero} ({usuario})", ZKTecoManager.TipoMensaje.Advertencia);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnHabilitarDeshabilitar_Click(object? sender, EventArgs e)
        {
            if (dataGridGestion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tarjeta de la lista.", "Ninguna Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dataGridGestion.SelectedRows[0];
            string numero = filaSeleccionada.Cells["Número"].Value?.ToString() ?? "";
            string usuario = filaSeleccionada.Cells["Usuario"].Value?.ToString() ?? "";
            string estadoActual = filaSeleccionada.Cells["Estado"].Value?.ToString() ?? "";

            bool estaHabilitada = estadoActual.Contains("HABILITADA");
            bool nuevoEstado = !estaHabilitada;

            string accion = nuevoEstado ? "HABILITAR" : "DESHABILITAR";
            string emoji = nuevoEstado ? "✅" : "❌";

            var confirmacion = MessageBox.Show(
                $"¿Desea {accion} la tarjeta?\n\nNúmero: {numero}\nUsuario: {usuario}",
                $"Confirmar {accion}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                bool cambiado = tarjetasDB.CambiarEstado(numero, nuevoEstado);

                if (cambiado)
                {
                    MessageBox.Show($"{emoji} Tarjeta {numero} {(nuevoEstado ? "habilitada" : "deshabilitada")} exitosamente.",
                        "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaGestion();
                    ManejarLog($"{emoji} Tarjeta {numero} ({usuario}) → {(nuevoEstado ? "HABILITADA" : "DESHABILITADA")}", 
                        nuevoEstado ? ZKTecoManager.TipoMensaje.Exito : ZKTecoManager.TipoMensaje.Advertencia);
                }
                else
                {
                    MessageBox.Show("Error al cambiar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}