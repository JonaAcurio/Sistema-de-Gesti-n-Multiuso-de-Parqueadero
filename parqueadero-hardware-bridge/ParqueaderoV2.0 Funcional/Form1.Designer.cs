namespace InterfazParqueadero
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSuperior = new Panel();
            panelEstado = new Panel();
            lblEstado = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            btnConectar = new Button();
            txtTimeout = new TextBox();
            lblTimeout = new Label();
            txtPuerto = new TextBox();
            lblPuerto = new Label();
            txtIP = new TextBox();
            lblIP = new Label();
            tabControl = new TabControl();
            tabBarrera = new TabPage();
            panelControl = new GroupBox();
            btnAutomatico = new Button();
            btnBajar = new Button();
            btnLevantar = new Button();
            panelEstadoBarrera = new GroupBox();
            lblIndicadorArriba = new Label();
            lblIndicadorAbajo = new Label();
            tabLectores = new TabPage();
            panelLectores = new GroupBox();
            btnLimpiarTarjetas = new Button();
            lblUltimoAcceso = new Label();
            dataGridTarjetas = new DataGridView();
            tabGestion = new TabPage();
            panelGestionTarjetas = new GroupBox();
            dataGridGestion = new DataGridView();
            lblNumeroTarjeta = new Label();
            txtNumeroTarjeta = new TextBox();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnAgregarManual = new Button();
            btnDetectarTarjeta = new Button();
            btnHabilitarDeshabilitar = new Button();
            btnEliminarTarjeta = new Button();
            lblEstadisticas = new Label();
            tabConfiguracion = new TabPage();
            panelConfiguracion = new GroupBox();
            btnResetearSistema = new Button();
            btnStopEmergencia = new Button();
            panelLogs = new GroupBox();
            btnLimpiarLogs = new Button();
            btnCopiarLogs = new Button();
            listBoxLogs = new ListBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabelHora = new ToolStripStatusLabel();
            btnSalir = new Button();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            tabControl.SuspendLayout();
            tabBarrera.SuspendLayout();
            panelControl.SuspendLayout();
            panelEstadoBarrera.SuspendLayout();
            tabLectores.SuspendLayout();
            panelLectores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTarjetas).BeginInit();
            tabGestion.SuspendLayout();
            panelGestionTarjetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridGestion).BeginInit();
            tabConfiguracion.SuspendLayout();
            panelConfiguracion.SuspendLayout();
            panelLogs.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(41, 128, 185);
            panelSuperior.Controls.Add(btnSalir);
            panelSuperior.Controls.Add(panelEstado);
            panelSuperior.Controls.Add(lblEstado);
            panelSuperior.Controls.Add(pictureBoxLogo);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(3, 4, 3, 4);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1174, 90);
            panelSuperior.TabIndex = 0;
            // 
            // panelEstado
            // 
            panelEstado.BackColor = Color.Gray;
            panelEstado.Location = new Point(937, 20);
            panelEstado.Margin = new Padding(3, 4, 3, 4);
            panelEstado.Name = "panelEstado";
            panelEstado.Size = new Size(34, 40);
            panelEstado.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEstado.ForeColor = Color.White;
            lblEstado.Location = new Point(977, 27);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(161, 25);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "DESCONECTADO";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxLogo.Image = Properties.Resources.Logo_PUCESD;
            pictureBoxLogo.Location = new Point(17, 13);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(68, 79);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += PictureBoxLogo_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(97, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(650, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Control de Parqueadero PUCESA";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(192, 57, 43);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(1030, 20);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 50);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "✖ SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabBarrera);
            tabControl.Controls.Add(tabLectores);
            tabControl.Controls.Add(tabGestion);
            tabControl.Controls.Add(tabConfiguracion);
            tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabControl.Location = new Point(23, 110);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1097, 380);
            tabControl.TabIndex = 7;
            // 
            // tabBarrera
            // 
            tabBarrera.BackColor = Color.FromArgb(236, 240, 241);
            tabBarrera.Controls.Add(panelControl);
            tabBarrera.Controls.Add(panelEstadoBarrera);
            tabBarrera.Location = new Point(4, 32);
            tabBarrera.Name = "tabBarrera";
            tabBarrera.Padding = new Padding(3);
            tabBarrera.Size = new Size(1089, 344);
            tabBarrera.TabIndex = 0;
            tabBarrera.Text = "🚗 Control de Barrera";
            // 
            // panelControl
            // 
            panelControl.Controls.Add(btnAutomatico);
            panelControl.Controls.Add(btnBajar);
            panelControl.Controls.Add(btnLevantar);
            panelControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            panelControl.Location = new Point(6, 6);
            panelControl.Margin = new Padding(3, 4, 3, 4);
            panelControl.Name = "panelControl";
            panelControl.Padding = new Padding(3, 4, 3, 4);
            panelControl.Size = new Size(1077, 120);
            panelControl.TabIndex = 2;
            panelControl.TabStop = false;
            panelControl.Text = "🎮 PANEL DE CONTROL";
            // 
            // btnAutomatico
            // 
            btnAutomatico.BackColor = Color.FromArgb(52, 152, 219);
            btnAutomatico.Enabled = false;
            btnAutomatico.FlatStyle = FlatStyle.Flat;
            btnAutomatico.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAutomatico.ForeColor = Color.White;
            btnAutomatico.Location = new Point(723, 30);
            btnAutomatico.Margin = new Padding(3, 4, 3, 4);
            btnAutomatico.Name = "btnAutomatico";
            btnAutomatico.Size = new Size(320, 70);
            btnAutomatico.TabIndex = 2;
            btnAutomatico.Text = "🔄 MODO AUTOMÁTICO";
            btnAutomatico.UseVisualStyleBackColor = false;
            btnAutomatico.Click += BtnAutomatico_Click;
            // 
            // btnBajar
            // 
            btnBajar.BackColor = Color.FromArgb(231, 76, 60);
            btnBajar.Enabled = false;
            btnBajar.FlatStyle = FlatStyle.Flat;
            btnBajar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBajar.ForeColor = Color.White;
            btnBajar.Location = new Point(377, 30);
            btnBajar.Margin = new Padding(3, 4, 3, 4);
            btnBajar.Name = "btnBajar";
            btnBajar.Size = new Size(320, 70);
            btnBajar.TabIndex = 1;
            btnBajar.Text = "⬇️ BAJAR BRAZO";
            btnBajar.UseVisualStyleBackColor = false;
            btnBajar.Click += BtnBajar_Click;
            // 
            // btnLevantar
            // 
            btnLevantar.BackColor = Color.FromArgb(46, 204, 113);
            btnLevantar.Enabled = false;
            btnLevantar.FlatStyle = FlatStyle.Flat;
            btnLevantar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLevantar.ForeColor = Color.White;
            btnLevantar.Location = new Point(34, 30);
            btnLevantar.Margin = new Padding(3, 4, 3, 4);
            btnLevantar.Name = "btnLevantar";
            btnLevantar.Size = new Size(320, 70);
            btnLevantar.TabIndex = 0;
            btnLevantar.Text = "⬆️ LEVANTAR BRAZO";
            btnLevantar.UseVisualStyleBackColor = false;
            btnLevantar.Click += BtnLevantar_Click;
            // 
            // panelEstadoBarrera
            // 
            panelEstadoBarrera.Controls.Add(lblIndicadorArriba);
            panelEstadoBarrera.Controls.Add(lblIndicadorAbajo);
            panelEstadoBarrera.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            panelEstadoBarrera.Location = new Point(6, 133);
            panelEstadoBarrera.Name = "panelEstadoBarrera";
            panelEstadoBarrera.Size = new Size(1077, 75);
            panelEstadoBarrera.TabIndex = 6;
            panelEstadoBarrera.TabStop = false;
            panelEstadoBarrera.Text = "🚦 ESTADO DE LA BARRERA";
            // 
            // lblIndicadorArriba
            // 
            lblIndicadorArriba.AutoSize = false;
            lblIndicadorArriba.BackColor = Color.DimGray;
            lblIndicadorArriba.Cursor = Cursors.Default;
            lblIndicadorArriba.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblIndicadorArriba.ForeColor = Color.White;
            lblIndicadorArriba.Location = new Point(10, 26);
            lblIndicadorArriba.Name = "lblIndicadorArriba";
            lblIndicadorArriba.Size = new Size(520, 45);
            lblIndicadorArriba.TabIndex = 0;
            lblIndicadorArriba.Text = "⬆️  BARRERA ARRIBA";
            lblIndicadorArriba.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIndicadorAbajo
            // 
            lblIndicadorAbajo.AutoSize = false;
            lblIndicadorAbajo.BackColor = Color.DimGray;
            lblIndicadorAbajo.Cursor = Cursors.Default;
            lblIndicadorAbajo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblIndicadorAbajo.ForeColor = Color.White;
            lblIndicadorAbajo.Location = new Point(540, 26);
            lblIndicadorAbajo.Name = "lblIndicadorAbajo";
            lblIndicadorAbajo.Size = new Size(520, 45);
            lblIndicadorAbajo.TabIndex = 1;
            lblIndicadorAbajo.Text = "⬇️  BARRERA ABAJO";
            lblIndicadorAbajo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabLectores
            // 
            tabLectores.BackColor = Color.FromArgb(236, 240, 241);
            tabLectores.Controls.Add(panelLectores);
            tabLectores.Location = new Point(4, 32);
            tabLectores.Name = "tabLectores";
            tabLectores.Padding = new Padding(3);
            tabLectores.Size = new Size(1089, 344);
            tabLectores.TabIndex = 1;
            tabLectores.Text = "🔖 Control de Acceso (RFID)";            // 
            // tabGestion
            // 
            tabGestion.BackColor = Color.FromArgb(236, 240, 241);
            tabGestion.Controls.Add(panelGestionTarjetas);
            tabGestion.Location = new Point(4, 32);
            tabGestion.Name = "tabGestion";
            tabGestion.Padding = new Padding(3);
            tabGestion.Size = new Size(1089, 344);
            tabGestion.TabIndex = 2;
            tabGestion.Text = "🎫 Gestión de Tarjetas";
            // 
            // panelGestionTarjetas
            // 
            panelGestionTarjetas.Controls.Add(lblEstadisticas);
            panelGestionTarjetas.Controls.Add(btnEliminarTarjeta);
            panelGestionTarjetas.Controls.Add(btnHabilitarDeshabilitar);
            panelGestionTarjetas.Controls.Add(btnDetectarTarjeta);
            panelGestionTarjetas.Controls.Add(btnAgregarManual);
            panelGestionTarjetas.Controls.Add(txtObservaciones);
            panelGestionTarjetas.Controls.Add(lblObservaciones);
            panelGestionTarjetas.Controls.Add(txtNombreUsuario);
            panelGestionTarjetas.Controls.Add(lblNombreUsuario);
            panelGestionTarjetas.Controls.Add(txtNumeroTarjeta);
            panelGestionTarjetas.Controls.Add(lblNumeroTarjeta);
            panelGestionTarjetas.Controls.Add(dataGridGestion);
            panelGestionTarjetas.Dock = DockStyle.Fill;
            panelGestionTarjetas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            panelGestionTarjetas.ForeColor = Color.FromArgb(52, 73, 94);
            panelGestionTarjetas.Location = new Point(3, 3);
            panelGestionTarjetas.Name = "panelGestionTarjetas";
            panelGestionTarjetas.Size = new Size(1083, 248);
            panelGestionTarjetas.TabIndex = 0;
            panelGestionTarjetas.TabStop = false;
            panelGestionTarjetas.Text = "Base de Datos de Tarjetas RFID Autorizadas";
            // 
            // dataGridGestion
            // 
            dataGridGestion.AllowUserToAddRows = false;
            dataGridGestion.AllowUserToDeleteRows = false;
            dataGridGestion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridGestion.BackgroundColor = Color.White;
            dataGridGestion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridGestion.Location = new Point(20, 30);
            dataGridGestion.Name = "dataGridGestion";
            dataGridGestion.ReadOnly = true;
            dataGridGestion.RowHeadersWidth = 51;
            dataGridGestion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridGestion.Size = new Size(720, 200);
            dataGridGestion.TabIndex = 0;
            // 
            // lblNumeroTarjeta
            // 
            lblNumeroTarjeta.AutoSize = true;
            lblNumeroTarjeta.Font = new Font("Segoe UI", 9F);
            lblNumeroTarjeta.ForeColor = Color.Black;
            lblNumeroTarjeta.Location = new Point(760, 35);
            lblNumeroTarjeta.Name = "lblNumeroTarjeta";
            lblNumeroTarjeta.Size = new Size(88, 20);
            lblNumeroTarjeta.TabIndex = 1;
            lblNumeroTarjeta.Text = "Nº Tarjeta:";
            // 
            // txtNumeroTarjeta
            // 
            txtNumeroTarjeta.Font = new Font("Segoe UI", 10F);
            txtNumeroTarjeta.Location = new Point(760, 58);
            txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            txtNumeroTarjeta.PlaceholderText = "Ej: 3846765";
            txtNumeroTarjeta.Size = new Size(150, 30);
            txtNumeroTarjeta.TabIndex = 2;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 9F);
            lblNombreUsuario.ForeColor = Color.Black;
            lblNombreUsuario.Location = new Point(920, 35);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(68, 20);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "Usuario:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Segoe UI", 10F);
            txtNombreUsuario.Location = new Point(920, 58);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.PlaceholderText = "Nombre completo";
            txtNombreUsuario.Size = new Size(150, 30);
            txtNombreUsuario.TabIndex = 4;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9F);
            lblObservaciones.ForeColor = Color.Black;
            lblObservaciones.Location = new Point(760, 95);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(112, 20);
            lblObservaciones.TabIndex = 5;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Font = new Font("Segoe UI", 9F);
            txtObservaciones.Location = new Point(760, 118);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Ej: Vehículo placa ABC-123";
            txtObservaciones.Size = new Size(310, 50);
            txtObservaciones.TabIndex = 6;
            // 
            // btnAgregarManual
            // 
            btnAgregarManual.BackColor = Color.FromArgb(46, 204, 113);
            btnAgregarManual.FlatStyle = FlatStyle.Flat;
            btnAgregarManual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarManual.ForeColor = Color.White;
            btnAgregarManual.Location = new Point(760, 175);
            btnAgregarManual.Name = "btnAgregarManual";
            btnAgregarManual.Size = new Size(150, 35);
            btnAgregarManual.TabIndex = 7;
            btnAgregarManual.Text = "✅ Agregar";
            btnAgregarManual.UseVisualStyleBackColor = false;
            // 
            // btnDetectarTarjeta
            // 
            btnDetectarTarjeta.BackColor = Color.FromArgb(52, 152, 219);
            btnDetectarTarjeta.FlatStyle = FlatStyle.Flat;
            btnDetectarTarjeta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDetectarTarjeta.ForeColor = Color.White;
            btnDetectarTarjeta.Location = new Point(920, 175);
            btnDetectarTarjeta.Name = "btnDetectarTarjeta";
            btnDetectarTarjeta.Size = new Size(150, 35);
            btnDetectarTarjeta.TabIndex = 8;
            btnDetectarTarjeta.Text = "🔍 Detectar";
            btnDetectarTarjeta.UseVisualStyleBackColor = false;
            // 
            // btnHabilitarDeshabilitar
            // 
            btnHabilitarDeshabilitar.BackColor = Color.FromArgb(241, 196, 15);
            btnHabilitarDeshabilitar.FlatStyle = FlatStyle.Flat;
            btnHabilitarDeshabilitar.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnHabilitarDeshabilitar.ForeColor = Color.White;
            btnHabilitarDeshabilitar.Location = new Point(20, 235);
            btnHabilitarDeshabilitar.Name = "btnHabilitarDeshabilitar";
            btnHabilitarDeshabilitar.Size = new Size(150, 30);
            btnHabilitarDeshabilitar.TabIndex = 9;
            btnHabilitarDeshabilitar.Text = "🔄 Habilitar/Deshab.";
            btnHabilitarDeshabilitar.UseVisualStyleBackColor = false;
            // 
            // btnEliminarTarjeta
            // 
            btnEliminarTarjeta.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminarTarjeta.FlatStyle = FlatStyle.Flat;
            btnEliminarTarjeta.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnEliminarTarjeta.ForeColor = Color.White;
            btnEliminarTarjeta.Location = new Point(180, 235);
            btnEliminarTarjeta.Name = "btnEliminarTarjeta";
            btnEliminarTarjeta.Size = new Size(150, 30);
            btnEliminarTarjeta.TabIndex = 10;
            btnEliminarTarjeta.Text = "❌ Eliminar";
            btnEliminarTarjeta.UseVisualStyleBackColor = false;
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.AutoSize = true;
            lblEstadisticas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadisticas.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstadisticas.Location = new Point(340, 240);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(250, 20);
            lblEstadisticas.TabIndex = 11;
            lblEstadisticas.Text = "Total: 0 | Habilitadas: 0 | Deshabilitadas: 0";
            // 
            // tabConfiguracion
            // 
            tabConfiguracion.BackColor = Color.FromArgb(236, 240, 241);
            tabConfiguracion.Controls.Add(panelConfiguracion);
            tabConfiguracion.Location = new Point(4, 32);
            tabConfiguracion.Name = "tabConfiguracion";
            tabConfiguracion.Padding = new Padding(3);
            tabConfiguracion.Size = new Size(1089, 344);
            tabConfiguracion.TabIndex = 3;
            tabConfiguracion.Text = "⚙️ Configuración";
            // 
            // panelConfiguracion
            // 
            panelConfiguracion.Controls.Add(btnStopEmergencia);
            panelConfiguracion.Controls.Add(btnResetearSistema);
            panelConfiguracion.Controls.Add(btnConectar);
            panelConfiguracion.Controls.Add(txtTimeout);
            panelConfiguracion.Controls.Add(lblTimeout);
            panelConfiguracion.Controls.Add(txtPuerto);
            panelConfiguracion.Controls.Add(lblPuerto);
            panelConfiguracion.Controls.Add(txtIP);
            panelConfiguracion.Controls.Add(lblIP);
            panelConfiguracion.Dock = DockStyle.Fill;
            panelConfiguracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            panelConfiguracion.Location = new Point(3, 3);
            panelConfiguracion.Name = "panelConfiguracion";
            panelConfiguracion.Size = new Size(1083, 248);
            panelConfiguracion.TabIndex = 0;
            panelConfiguracion.TabStop = false;
            panelConfiguracion.Text = "🔌 Configuración de Conexión";
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIP.ForeColor = Color.FromArgb(52, 73, 94);
            lblIP.Location = new Point(30, 50);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(130, 23);
            lblIP.TabIndex = 0;
            lblIP.Text = "Dirección IP:";
            // 
            // txtIP
            // 
            txtIP.Font = new Font("Segoe UI", 10F);
            txtIP.Location = new Point(170, 47);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(200, 30);
            txtIP.TabIndex = 1;
            txtIP.Text = "192.168.1.201";
            // 
            // lblPuerto
            // 
            lblPuerto.AutoSize = true;
            lblPuerto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPuerto.ForeColor = Color.FromArgb(52, 73, 94);
            lblPuerto.Location = new Point(420, 50);
            lblPuerto.Name = "lblPuerto";
            lblPuerto.Size = new Size(73, 23);
            lblPuerto.TabIndex = 2;
            lblPuerto.Text = "Puerto:";
            // 
            // txtPuerto
            // 
            txtPuerto.Font = new Font("Segoe UI", 10F);
            txtPuerto.Location = new Point(500, 47);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(120, 30);
            txtPuerto.TabIndex = 3;
            txtPuerto.Text = "4370";
            // 
            // lblTimeout
            // 
            lblTimeout.AutoSize = true;
            lblTimeout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimeout.ForeColor = Color.FromArgb(52, 73, 94);
            lblTimeout.Location = new Point(30, 100);
            lblTimeout.Name = "lblTimeout";
            lblTimeout.Size = new Size(160, 23);
            lblTimeout.TabIndex = 4;
            lblTimeout.Text = "Timeout (ms):";
            // 
            // txtTimeout
            // 
            txtTimeout.Font = new Font("Segoe UI", 10F);
            txtTimeout.Location = new Point(170, 97);
            txtTimeout.Name = "txtTimeout";
            txtTimeout.Size = new Size(120, 30);
            txtTimeout.TabIndex = 5;
            txtTimeout.Text = "2000";
            // 
            // btnConectar
            // 
            btnConectar.BackColor = Color.FromArgb(39, 174, 96);
            btnConectar.FlatStyle = FlatStyle.Flat;
            btnConectar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConectar.ForeColor = Color.White;
            btnConectar.Location = new Point(30, 150);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(200, 50);
            btnConectar.TabIndex = 6;
            btnConectar.Text = "➡️ CONECTAR";
            btnConectar.UseVisualStyleBackColor = false;
            btnConectar.Click += BtnConectar_Click;
            // 
            // btnResetearSistema
            // 
            btnResetearSistema.BackColor = Color.FromArgb(230, 126, 34);
            btnResetearSistema.FlatStyle = FlatStyle.Flat;
            btnResetearSistema.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnResetearSistema.ForeColor = Color.White;
            btnResetearSistema.Location = new Point(250, 150);
            btnResetearSistema.Name = "btnResetearSistema";
            btnResetearSistema.Size = new Size(230, 50);
            btnResetearSistema.TabIndex = 7;
            btnResetearSistema.Text = "🚨 RESETEAR SISTEMA";
            btnResetearSistema.UseVisualStyleBackColor = false;
            btnResetearSistema.Click += BtnResetearSistema_Click;
            // 
            // btnStopEmergencia
            // 
            btnStopEmergencia.BackColor = Color.FromArgb(192, 57, 43);
            btnStopEmergencia.FlatStyle = FlatStyle.Flat;
            btnStopEmergencia.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStopEmergencia.ForeColor = Color.White;
            btnStopEmergencia.Location = new Point(500, 150);
            btnStopEmergencia.Name = "btnStopEmergencia";
            btnStopEmergencia.Size = new Size(180, 50);
            btnStopEmergencia.TabIndex = 8;
            btnStopEmergencia.Text = "🛑 STOP";
            btnStopEmergencia.UseVisualStyleBackColor = false;
            btnStopEmergencia.Click += BtnStopEmergencia_Click;
            // 
            // panelLectores
            // 
            panelLectores.Controls.Add(btnLimpiarTarjetas);
            panelLectores.Controls.Add(lblUltimoAcceso);
            panelLectores.Controls.Add(dataGridTarjetas);
            panelLectores.Dock = DockStyle.Fill;
            panelLectores.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            panelLectores.Location = new Point(3, 3);
            panelLectores.Name = "panelLectores";
            panelLectores.Size = new Size(1083, 248);
            panelLectores.TabIndex = 0;
            panelLectores.TabStop = false;
            panelLectores.Text = "📡 LECTURAS DE TARJETAS RFID";
            // 
            // btnLimpiarTarjetas
            // 
            btnLimpiarTarjetas.BackColor = Color.FromArgb(149, 165, 166);
            btnLimpiarTarjetas.FlatStyle = FlatStyle.Flat;
            btnLimpiarTarjetas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarTarjetas.ForeColor = Color.White;
            btnLimpiarTarjetas.Location = new Point(923, 197);
            btnLimpiarTarjetas.Name = "btnLimpiarTarjetas";
            btnLimpiarTarjetas.Size = new Size(140, 40);
            btnLimpiarTarjetas.TabIndex = 2;
            btnLimpiarTarjetas.Text = "🗑️ Limpiar Tabla";
            btnLimpiarTarjetas.UseVisualStyleBackColor = false;
            btnLimpiarTarjetas.Click += BtnLimpiarTarjetas_Click;
            // 
            // lblUltimoAcceso
            // 
            lblUltimoAcceso.AutoSize = true;
            lblUltimoAcceso.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUltimoAcceso.ForeColor = Color.FromArgb(41, 128, 185);
            lblUltimoAcceso.Location = new Point(17, 208);
            lblUltimoAcceso.Name = "lblUltimoAcceso";
            lblUltimoAcceso.Size = new Size(353, 25);
            lblUltimoAcceso.TabIndex = 1;
            lblUltimoAcceso.Text = "Último acceso: Esperando lectura...";
            // 
            // dataGridTarjetas
            // 
            dataGridTarjetas.AllowUserToAddRows = false;
            dataGridTarjetas.AllowUserToDeleteRows = false;
            dataGridTarjetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridTarjetas.BackgroundColor = Color.White;
            dataGridTarjetas.BorderStyle = BorderStyle.Fixed3D;
            dataGridTarjetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTarjetas.Location = new Point(17, 30);
            dataGridTarjetas.Name = "dataGridTarjetas";
            dataGridTarjetas.ReadOnly = true;
            dataGridTarjetas.RowHeadersWidth = 51;
            dataGridTarjetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTarjetas.Size = new Size(1046, 160);
            dataGridTarjetas.TabIndex = 0;
            // 
            // panelLogs
            // 
            panelLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLogs.Controls.Add(btnLimpiarLogs);
            panelLogs.Controls.Add(btnCopiarLogs);
            panelLogs.Controls.Add(listBoxLogs);
            panelLogs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            panelLogs.Location = new Point(23, 510);
            panelLogs.Margin = new Padding(3, 4, 3, 4);
            panelLogs.Name = "panelLogs";
            panelLogs.Padding = new Padding(3, 4, 3, 4);
            panelLogs.Size = new Size(1097, 360);
            panelLogs.TabIndex = 3;
            panelLogs.TabStop = false;
            panelLogs.Text = "📋 REGISTRO DE EVENTOS (LOGS)";
            // 
            // btnLimpiarLogs
            // 
            btnLimpiarLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLimpiarLogs.BackColor = Color.FromArgb(149, 165, 166);
            btnLimpiarLogs.FlatStyle = FlatStyle.Flat;
            btnLimpiarLogs.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarLogs.ForeColor = Color.White;
            btnLimpiarLogs.Location = new Point(937, 310);
            btnLimpiarLogs.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarLogs.Name = "btnLimpiarLogs";
            btnLimpiarLogs.Size = new Size(137, 40);
            btnLimpiarLogs.TabIndex = 1;
            btnLimpiarLogs.Text = "🗑️ Limpiar";
            btnLimpiarLogs.UseVisualStyleBackColor = false;
            btnLimpiarLogs.Click += BtnLimpiarLogs_Click;
            // 
            // btnCopiarLogs
            // 
            btnCopiarLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopiarLogs.BackColor = Color.FromArgb(52, 152, 219);
            btnCopiarLogs.FlatStyle = FlatStyle.Flat;
            btnCopiarLogs.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCopiarLogs.ForeColor = Color.White;
            btnCopiarLogs.Location = new Point(780, 310);
            btnCopiarLogs.Margin = new Padding(3, 4, 3, 4);
            btnCopiarLogs.Name = "btnCopiarLogs";
            btnCopiarLogs.Size = new Size(137, 40);
            btnCopiarLogs.TabIndex = 2;
            btnCopiarLogs.Text = "📋 Copiar";
            btnCopiarLogs.UseVisualStyleBackColor = false;
            btnCopiarLogs.Click += BtnCopiarLogs_Click;
            // 
            // listBoxLogs
            // 
            listBoxLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxLogs.BackColor = Color.FromArgb(44, 62, 80);
            listBoxLogs.Font = new Font("Consolas", 9F);
            listBoxLogs.ForeColor = Color.LimeGreen;
            listBoxLogs.FormattingEnabled = true;
            listBoxLogs.Location = new Point(17, 33);
            listBoxLogs.Margin = new Padding(3, 4, 3, 4);
            listBoxLogs.Name = "listBoxLogs";
            listBoxLogs.Size = new Size(1062, 270);
            listBoxLogs.TabIndex = 0;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(52, 73, 94);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripStatusLabelHora });
            statusStrip.Location = new Point(0, 962);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1174, 26);
            statusStrip.TabIndex = 4;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.ForeColor = Color.White;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(93, 20);
            toolStripStatusLabel.Text = "Sin conexión";
            // 
            // toolStripStatusLabelHora
            // 
            toolStripStatusLabelHora.ForeColor = Color.White;
            toolStripStatusLabelHora.Name = "toolStripStatusLabelHora";
            toolStripStatusLabelHora.Size = new Size(1064, 20);
            toolStripStatusLabelHora.Spring = true;
            toolStripStatusLabelHora.Text = "Listo";
            toolStripStatusLabelHora.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1174, 988);
            Controls.Add(statusStrip);
            Controls.Add(panelLogs);
            Controls.Add(tabControl);
            Controls.Add(panelSuperior);
            FormBorderStyle = FormBorderStyle.Sizable;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = true;
            MinimumSize = new Size(1200, 800);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Control Parqueadero PUCESA - ZKTeco";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            tabControl.ResumeLayout(false);
            tabBarrera.ResumeLayout(false);
            panelControl.ResumeLayout(false);
            panelEstadoBarrera.ResumeLayout(false);
            tabLectores.ResumeLayout(false);
            panelLectores.ResumeLayout(false);
            panelLectores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTarjetas).EndInit();
            tabGestion.ResumeLayout(false);
            panelGestionTarjetas.ResumeLayout(false);
            panelGestionTarjetas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridGestion).EndInit();
            tabConfiguracion.ResumeLayout(false);
            panelConfiguracion.ResumeLayout(false);
            panelConfiguracion.PerformLayout();
            panelLogs.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private PictureBox pictureBoxLogo;
        private Label lblEstado;
        private Panel panelEstado;
        private Label lblIP;
        private TextBox txtIP;
        private TextBox txtPuerto;
        private Label lblPuerto;
        private TextBox txtTimeout;
        private Label lblTimeout;
        private Button btnConectar;
        private GroupBox panelControl;
        private Button btnLevantar;
        private Button btnBajar;
        private Button btnAutomatico;
        private GroupBox panelLogs;
        private ListBox listBoxLogs;
        private Button btnLimpiarLogs;
        private Button btnCopiarLogs;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabelHora;
        private Button btnSalir;
        private GroupBox panelEstadoBarrera;
        private Label lblIndicadorArriba;
        private Label lblIndicadorAbajo;
        private TabControl tabControl;
        private TabPage tabBarrera;
        private TabPage tabLectores;
        private GroupBox panelLectores;
        private DataGridView dataGridTarjetas;
        private Label lblUltimoAcceso;
        private Button btnLimpiarTarjetas;
        private TabPage tabGestion;
        private GroupBox panelGestionTarjetas;
        private DataGridView dataGridGestion;
        private Label lblNumeroTarjeta;
        private TextBox txtNumeroTarjeta;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Button btnAgregarManual;
        private Button btnDetectarTarjeta;
        private Button btnHabilitarDeshabilitar;
        private Button btnEliminarTarjeta;
        private Label lblEstadisticas;
        private TabPage tabConfiguracion;
        private GroupBox panelConfiguracion;
        private Button btnResetearSistema;
        private Button btnStopEmergencia;
    }
}