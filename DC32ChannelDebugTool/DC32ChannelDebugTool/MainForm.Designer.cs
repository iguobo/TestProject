namespace DC32ChannelDebugTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.numDeviceAddress = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDroppedChannels = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAcOnSignal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFanCurrent = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCurrentTemp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBoardName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewVoltage = new System.Windows.Forms.DataGridView();
            this.ChannelNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDropped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopMonitor = new System.Windows.Forms.Button();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.numMonitorInterval = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReadOnce = new System.Windows.Forms.Button();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceAddress)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoltage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonitorInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备配置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 设备配置ToolStripMenuItem
            // 
            this.设备配置ToolStripMenuItem.Name = "设备配置ToolStripMenuItem";
            this.设备配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设备配置ToolStripMenuItem.Text = "设备配置";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatus,
            this.toolStripStatusLabel2,
            this.lblLastUpdate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 656);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态：";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 17);
            this.lblStatus.Text = "未连接";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(992, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(105, 17);
            this.lblLastUpdate.Text = "最后更新: 从未更新";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.numDeviceAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbComPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接设置";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(680, 35);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(80, 25);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(590, 35);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 25);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // numDeviceAddress
            // 
            this.numDeviceAddress.Location = new System.Drawing.Point(470, 37);
            this.numDeviceAddress.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numDeviceAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDeviceAddress.Name = "numDeviceAddress";
            this.numDeviceAddress.Size = new System.Drawing.Size(100, 21);
            this.numDeviceAddress.TabIndex = 5;
            this.numDeviceAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "设备地址：";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600"});
            this.cmbBaudRate.Location = new System.Drawing.Point(270, 37);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(100, 20);
            this.cmbBaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(80, 37);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(100, 20);
            this.cmbComPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDroppedChannels);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblAcOnSignal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblFanCurrent);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblCurrentTemp);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblSerialNumber);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblBoardName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblVersion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblAddress);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1200, 120);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备信息";
            // 
            // lblDroppedChannels
            // 
            this.lblDroppedChannels.AutoSize = true;
            this.lblDroppedChannels.ForeColor = System.Drawing.Color.Red;
            this.lblDroppedChannels.Location = new System.Drawing.Point(680, 85);
            this.lblDroppedChannels.Name = "lblDroppedChannels";
            this.lblDroppedChannels.Size = new System.Drawing.Size(17, 12);
            this.lblDroppedChannels.TabIndex = 15;
            this.lblDroppedChannels.Text = "--";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(600, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "跳落通道数：";
            // 
            // lblAcOnSignal
            // 
            this.lblAcOnSignal.AutoSize = true;
            this.lblAcOnSignal.Location = new System.Drawing.Point(490, 85);
            this.lblAcOnSignal.Name = "lblAcOnSignal";
            this.lblAcOnSignal.Size = new System.Drawing.Size(17, 12);
            this.lblAcOnSignal.TabIndex = 13;
            this.lblAcOnSignal.Text = "--";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(400, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "AC on 信号：";
            // 
            // lblFanCurrent
            // 
            this.lblFanCurrent.AutoSize = true;
            this.lblFanCurrent.Location = new System.Drawing.Point(290, 85);
            this.lblFanCurrent.Name = "lblFanCurrent";
            this.lblFanCurrent.Size = new System.Drawing.Size(17, 12);
            this.lblFanCurrent.TabIndex = 11;
            this.lblFanCurrent.Text = "--";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "风扇电流：";
            // 
            // lblCurrentTemp
            // 
            this.lblCurrentTemp.AutoSize = true;
            this.lblCurrentTemp.Location = new System.Drawing.Point(100, 85);
            this.lblCurrentTemp.Name = "lblCurrentTemp";
            this.lblCurrentTemp.Size = new System.Drawing.Size(17, 12);
            this.lblCurrentTemp.TabIndex = 9;
            this.lblCurrentTemp.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "当前温度：";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(490, 55);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(17, 12);
            this.lblSerialNumber.TabIndex = 7;
            this.lblSerialNumber.Text = "--";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "序列号：";
            // 
            // lblBoardName
            // 
            this.lblBoardName.AutoSize = true;
            this.lblBoardName.Location = new System.Drawing.Point(100, 55);
            this.lblBoardName.Name = "lblBoardName";
            this.lblBoardName.Size = new System.Drawing.Size(17, 12);
            this.lblBoardName.TabIndex = 5;
            this.lblBoardName.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "板名称：";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(290, 25);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(17, 12);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "版本号：";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(100, 25);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(17, 12);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "设备地址：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewVoltage);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1200, 431);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "32路电压监测";
            // 
            // dataGridViewVoltage
            // 
            this.dataGridViewVoltage.AllowUserToAddRows = false;
            this.dataGridViewVoltage.AllowUserToDeleteRows = false;
            this.dataGridViewVoltage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoltage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChannelNumber,
            this.Voltage,
            this.IsDropped,
            this.RawValue});
            this.dataGridViewVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVoltage.Location = new System.Drawing.Point(3, 67);
            this.dataGridViewVoltage.Name = "dataGridViewVoltage";
            this.dataGridViewVoltage.ReadOnly = true;
            this.dataGridViewVoltage.RowHeadersWidth = 25;
            this.dataGridViewVoltage.RowTemplate.Height = 23;
            this.dataGridViewVoltage.Size = new System.Drawing.Size(1194, 361);
            this.dataGridViewVoltage.TabIndex = 1;
            // 
            // ChannelNumber
            // 
            this.ChannelNumber.DataPropertyName = "ChannelNumber";
            this.ChannelNumber.HeaderText = "通道号";
            this.ChannelNumber.Name = "ChannelNumber";
            this.ChannelNumber.ReadOnly = true;
            this.ChannelNumber.Width = 80;
            // 
            // Voltage
            // 
            this.Voltage.DataPropertyName = "Voltage";
            this.Voltage.HeaderText = "电压值 (V)";
            this.Voltage.Name = "Voltage";
            this.Voltage.ReadOnly = true;
            this.Voltage.Width = 120;
            // 
            // IsDropped
            // 
            this.IsDropped.DataPropertyName = "IsDropped";
            this.IsDropped.HeaderText = "跳落状态";
            this.IsDropped.Name = "IsDropped";
            this.IsDropped.ReadOnly = true;
            this.IsDropped.Width = 80;
            // 
            // RawValue
            // 
            this.RawValue.DataPropertyName = "RawValue";
            this.RawValue.HeaderText = "原始值";
            this.RawValue.Name = "RawValue";
            this.RawValue.ReadOnly = true;
            this.RawValue.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStopMonitor);
            this.panel1.Controls.Add(this.btnStartMonitor);
            this.panel1.Controls.Add(this.numMonitorInterval);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnReadOnce);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnStopMonitor
            // 
            this.btnStopMonitor.Enabled = false;
            this.btnStopMonitor.Location = new System.Drawing.Point(370, 12);
            this.btnStopMonitor.Name = "btnStopMonitor";
            this.btnStopMonitor.Size = new System.Drawing.Size(100, 25);
            this.btnStopMonitor.TabIndex = 4;
            this.btnStopMonitor.Text = "停止监测";
            this.btnStopMonitor.UseVisualStyleBackColor = true;
            this.btnStopMonitor.Click += new System.EventHandler(this.btnStopMonitor_Click);
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.Enabled = false;
            this.btnStartMonitor.Location = new System.Drawing.Point(250, 12);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(100, 25);
            this.btnStartMonitor.TabIndex = 3;
            this.btnStartMonitor.Text = "开始监测";
            this.btnStartMonitor.UseVisualStyleBackColor = true;
            this.btnStartMonitor.Click += new System.EventHandler(this.btnStartMonitor_Click);
            // 
            // numMonitorInterval
            // 
            this.numMonitorInterval.Location = new System.Drawing.Point(530, 14);
            this.numMonitorInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMonitorInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMonitorInterval.Name = "numMonitorInterval";
            this.numMonitorInterval.Size = new System.Drawing.Size(80, 21);
            this.numMonitorInterval.TabIndex = 2;
            this.numMonitorInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(490, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "采集间隔(毫秒)：";
            // 
            // btnReadOnce
            // 
            this.btnReadOnce.Enabled = false;
            this.btnReadOnce.Location = new System.Drawing.Point(20, 12);
            this.btnReadOnce.Name = "btnReadOnce";
            this.btnReadOnce.Size = new System.Drawing.Size(120, 25);
            this.btnReadOnce.TabIndex = 0;
            this.btnReadOnce.Text = "读取一次";
            this.btnReadOnce.UseVisualStyleBackColor = true;
            this.btnReadOnce.Click += new System.EventHandler(this.btnReadOnce_Click);
            // 
            // timerMonitor
            // 
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 678);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DC32通道电压检测板调试工具 v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceAddress)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoltage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonitorInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown numDeviceAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDroppedChannels;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAcOnSignal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFanCurrent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCurrentTemp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBoardName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewVoltage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopMonitor;
        private System.Windows.Forms.Button btnStartMonitor;
        private System.Windows.Forms.NumericUpDown numMonitorInterval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReadOnce;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDropped;
        private System.Windows.Forms.DataGridViewTextBoxColumn RawValue;
    }
}