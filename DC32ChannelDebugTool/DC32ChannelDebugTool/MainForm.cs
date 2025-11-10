using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using DC32ChannelDebugTool.Core.Models;
using DC32ChannelDebugTool.Core.Services;

namespace DC32ChannelDebugTool
{
    public partial class MainForm : Form
    {
        private DeviceService _deviceService;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 初始化设备服务
                _deviceService = new DeviceService();

                // 加载串口列表
                LoadComPorts();

                // 设置波特率默认值
                cmbBaudRate.SelectedIndex = 3; // 默认57600

                // 初始化Timer
                timerMonitor.Interval = (int)numMonitorInterval.Value;

                // 更新状态
                UpdateStatus("未连接");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 加载可用的串口列表
        /// </summary>
        private void LoadComPorts()
        {
            cmbComPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length > 0)
            {
                cmbComPort.Items.AddRange(ports);
                cmbComPort.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("未检测到可用的串口！", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 连接按钮点击事件
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbComPort.SelectedItem == null)
                {
                    MessageBox.Show("请选择串口！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cmbBaudRate.SelectedItem == null)
                {
                    MessageBox.Show("请选择波特率！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string portName = cmbComPort.SelectedItem.ToString();
                int baudRate = int.Parse(cmbBaudRate.SelectedItem.ToString());
                byte deviceAddress = (byte)numDeviceAddress.Value;

                // 连接设备
                if (_deviceService.Connect(portName, baudRate))
                {
                    _deviceService.SetDeviceAddress(deviceAddress);

                    // 更新UI状态
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    cmbComPort.Enabled = false;
                    cmbBaudRate.Enabled = false;
                    numDeviceAddress.Enabled = false;

                    btnReadOnce.Enabled = true;
                    btnStartMonitor.Enabled = true;

                    UpdateStatus($"已连接 - {portName} @ {baudRate}bps");

                    // 读取设备信息
                    ReadDeviceInfo();

                    MessageBox.Show("连接成功！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("连接失败！", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 断开按钮点击事件
        /// </summary>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                // 先停止监测
                if (timerMonitor.Enabled)
                {
                    timerMonitor.Stop();
                    btnStartMonitor.Enabled = true;
                    btnStopMonitor.Enabled = false;
                }

                // 断开连接
                _deviceService.Disconnect();

                // 更新UI状态
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                cmbComPort.Enabled = true;
                cmbBaudRate.Enabled = true;
                numDeviceAddress.Enabled = true;

                btnReadOnce.Enabled = false;
                btnStartMonitor.Enabled = false;
                btnStopMonitor.Enabled = false;

                UpdateStatus("未连接");
                ClearDeviceInfo();

                MessageBox.Show("已断开连接", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"断开连接失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 读取一次按钮点击事件
        /// </summary>
        private void btnReadOnce_Click(object sender, EventArgs e)
        {
            try
            {
                ReadVoltageData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 开始监测按钮点击事件
        /// </summary>
        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                timerMonitor.Interval = (int)numMonitorInterval.Value;
                timerMonitor.Start();

                btnStartMonitor.Enabled = false;
                btnStopMonitor.Enabled = true;
                numMonitorInterval.Enabled = false;

                UpdateStatus($"监测中 - 间隔 {numMonitorInterval.Value}ms");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动监测失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止监测按钮点击事件
        /// </summary>
        private void btnStopMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                timerMonitor.Stop();

                btnStartMonitor.Enabled = true;
                btnStopMonitor.Enabled = false;
                numMonitorInterval.Enabled = true;

                UpdateStatus($"已连接 - {_deviceService.PortName} @ {_deviceService.BaudRate}bps");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"停止监测失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 定时器Tick事件 - 自动读取电压
        /// </summary>
        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            try
            {
                ReadVoltageData();
            }
            catch (Exception ex)
            {
                timerMonitor.Stop();
                btnStartMonitor.Enabled = true;
                btnStopMonitor.Enabled = false;

                MessageBox.Show($"监测过程中发生错误: {ex.Message}\n\n已停止监测。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 读取电压数据
        /// </summary>
        private void ReadVoltageData()
        {
            var voltages = _deviceService.ReadAllVoltages();

            // 更新DataGridView
            dataGridViewVoltage.DataSource = null;
            dataGridViewVoltage.DataSource = voltages;

            // 设置跳落状态的单元格颜色
            foreach (DataGridViewRow row in dataGridViewVoltage.Rows)
            {
                var voltageData = row.DataBoundItem as VoltageData;
                if (voltageData != null && voltageData.IsDropped)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // 更新最后更新时间
            lblLastUpdate.Text = $"最后更新: {DateTime.Now:HH:mm:ss}";
        }

        /// <summary>
        /// 读取设备信息
        /// </summary>
        private void ReadDeviceInfo()
        {
            try
            {
                var deviceInfo = _deviceService.ReadDeviceInfo();

                lblAddress.Text = deviceInfo.Address.ToString();
                lblVersion.Text = deviceInfo.Version;
                lblBoardName.Text = string.IsNullOrEmpty(deviceInfo.BoardName) ? "--" : deviceInfo.BoardName;
                lblSerialNumber.Text = string.IsNullOrEmpty(deviceInfo.SerialNumber) ? "--" : deviceInfo.SerialNumber;
                lblCurrentTemp.Text = $"{deviceInfo.CurrentTemperature}℃";
                lblFanCurrent.Text = $"{deviceInfo.FanCurrentInAmps:F3}A";
                lblAcOnSignal.Text = deviceInfo.AcOnSignal ? "到位" : "未到位";
                lblDroppedChannels.Text = deviceInfo.DroppedChannelCount > 0
                    ? $"{deviceInfo.DroppedChannelCount} 个通道 ({string.Join(",", deviceInfo.GetDroppedChannels())})"
                    : "无";

                // 如果有跳落通道，用红色显示
                if (deviceInfo.DroppedChannelCount > 0)
                {
                    lblDroppedChannels.ForeColor = Color.Red;
                }
                else
                {
                    lblDroppedChannels.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取设备信息失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 清空设备信息显示
        /// </summary>
        private void ClearDeviceInfo()
        {
            lblAddress.Text = "--";
            lblVersion.Text = "--";
            lblBoardName.Text = "--";
            lblSerialNumber.Text = "--";
            lblCurrentTemp.Text = "--";
            lblFanCurrent.Text = "--";
            lblAcOnSignal.Text = "--";
            lblDroppedChannels.Text = "--";
            lblDroppedChannels.ForeColor = Color.Black;

            dataGridViewVoltage.DataSource = null;
            lblLastUpdate.Text = "最后更新: 从未更新";
        }

        /// <summary>
        /// 更新状态栏
        /// </summary>
        private void UpdateStatus(string status)
        {
            lblStatus.Text = status;
        }

        /// <summary>
        /// 退出菜单点击事件
        /// </summary>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 关于菜单点击事件
        /// </summary>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "DC32通道电压检测板调试工具 v1.0\n\n" +
                "用于32通道直流电压检测板的参数配置、电压监测和数据记录。\n\n" +
                "协议版本: GJVdc-32 (2022-02-26)\n" +
                "开发者: iguobo\n" +
                "框架: .NET Framework 4.8",
                "关于",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // 停止监测
                if (timerMonitor.Enabled)
                {
                    timerMonitor.Stop();
                }

                // 断开连接
                if (_deviceService != null && _deviceService.IsConnected)
                {
                    _deviceService.Disconnect();
                }

                // 释放资源
                _deviceService?.Dispose();
            }
            catch
            {
                // 忽略关闭时的异常
            }
        }
    }
}