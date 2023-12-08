namespace iMeter
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeBps = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBps2400 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBps9600 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Err信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试方法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxCom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxBps = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxOprCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxPsw = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnWriteAddr = new System.Windows.Forms.ToolStripButton();
            this.toolStripTbAddr = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripBtnReadAddr = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPCTime = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSorF = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusReturn = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbComMemo = new System.Windows.Forms.TextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTBCA = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.menuItemChangeBps,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1456, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 32);
            this.toolStripMenuItem1.Text = "文件";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = global::iMeter.Properties.Resources.exit_quit_24px_16971_easyicon_net;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // menuItemChangeBps
            // 
            this.menuItemChangeBps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBps2400,
            this.menuItemBps9600});
            this.menuItemChangeBps.Name = "menuItemChangeBps";
            this.menuItemChangeBps.Size = new System.Drawing.Size(116, 32);
            this.menuItemChangeBps.Text = "更改波特率";
            // 
            // menuItemBps2400
            // 
            this.menuItemBps2400.Image = global::iMeter.Properties.Resources.cog;
            this.menuItemBps2400.Name = "menuItemBps2400";
            this.menuItemBps2400.Size = new System.Drawing.Size(154, 34);
            this.menuItemBps2400.Text = "2400";
            this.menuItemBps2400.Click += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // menuItemBps9600
            // 
            this.menuItemBps9600.Image = global::iMeter.Properties.Resources.cog;
            this.menuItemBps9600.Name = "menuItemBps9600";
            this.menuItemBps9600.Size = new System.Drawing.Size(154, 34);
            this.menuItemBps9600.Text = "9600";
            this.menuItemBps9600.Click += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Err信息ToolStripMenuItem,
            this.测试方法ToolStripMenuItem,
            this.检查更新ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(62, 32);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // Err信息ToolStripMenuItem
            // 
            this.Err信息ToolStripMenuItem.Image = global::iMeter.Properties.Resources.error_26px_1172434_easyicon_net;
            this.Err信息ToolStripMenuItem.Name = "Err信息ToolStripMenuItem";
            this.Err信息ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.Err信息ToolStripMenuItem.Text = "Err信息";
            this.Err信息ToolStripMenuItem.Click += new System.EventHandler(this.Err信息ToolStripMenuItem_Click);
            // 
            // 测试方法ToolStripMenuItem
            // 
            this.测试方法ToolStripMenuItem.Image = global::iMeter.Properties.Resources.M_31px_1120899_easyicon_net;
            this.测试方法ToolStripMenuItem.Name = "测试方法ToolStripMenuItem";
            this.测试方法ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.测试方法ToolStripMenuItem.Text = "测试方法";
            this.测试方法ToolStripMenuItem.Click += new System.EventHandler(this.测试方法ToolStripMenuItem_Click);
            // 
            // 检查更新ToolStripMenuItem
            // 
            this.检查更新ToolStripMenuItem.Image = global::iMeter.Properties.Resources.adept_refresh_reload_renew_update_32px_156_easyicon_net;
            this.检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem";
            this.检查更新ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.检查更新ToolStripMenuItem.Text = "检查更新";
            this.检查更新ToolStripMenuItem.Click += new System.EventHandler(this.检查更新ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Image = global::iMeter.Properties.Resources.about_26px_1172236_easyicon_net;
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxCom,
            this.toolStripLabel2,
            this.toolStripComboBoxBps,
            this.toolStripLabel3,
            this.toolStripTextBoxOprCode,
            this.toolStripLabel4,
            this.toolStripTextBoxPsw,
            this.toolStripLabel5,
            this.toolStripTBCA,
            this.toolStripSeparator1,
            this.toolStripBtnWriteAddr,
            this.toolStripTbAddr,
            this.toolStripBtnReadAddr});
            this.toolStrip1.Location = new System.Drawing.Point(0, 36);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1456, 38);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 33);
            this.toolStripLabel1.Text = "串口：";
            // 
            // toolStripComboBoxCom
            // 
            this.toolStripComboBoxCom.AutoSize = false;
            this.toolStripComboBoxCom.BackColor = System.Drawing.Color.White;
            this.toolStripComboBoxCom.Name = "toolStripComboBoxCom";
            this.toolStripComboBoxCom.Size = new System.Drawing.Size(88, 32);
            this.toolStripComboBoxCom.DropDown += new System.EventHandler(this.toolStripComboBoxCom_DropDown);
            this.toolStripComboBoxCom.SelectedIndexChanged += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(82, 33);
            this.toolStripLabel2.Text = "波特率：";
            // 
            // toolStripComboBoxBps
            // 
            this.toolStripComboBoxBps.AutoSize = false;
            this.toolStripComboBoxBps.BackColor = System.Drawing.Color.White;
            this.toolStripComboBoxBps.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600"});
            this.toolStripComboBoxBps.Name = "toolStripComboBoxBps";
            this.toolStripComboBoxBps.Size = new System.Drawing.Size(96, 32);
            this.toolStripComboBoxBps.SelectedIndexChanged += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(118, 33);
            this.toolStripLabel3.Text = "操作者代码：";
            // 
            // toolStripTextBoxOprCode
            // 
            this.toolStripTextBoxOprCode.AutoSize = false;
            this.toolStripTextBoxOprCode.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxOprCode.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBoxOprCode.MaxLength = 8;
            this.toolStripTextBoxOprCode.Name = "toolStripTextBoxOprCode";
            this.toolStripTextBoxOprCode.Size = new System.Drawing.Size(88, 30);
            this.toolStripTextBoxOprCode.Text = "00000001";
            this.toolStripTextBoxOprCode.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTextBoxOprCode.TextChanged += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(64, 33);
            this.toolStripLabel4.Text = "密码：";
            // 
            // toolStripTextBoxPsw
            // 
            this.toolStripTextBoxPsw.AutoSize = false;
            this.toolStripTextBoxPsw.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxPsw.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBoxPsw.MaxLength = 8;
            this.toolStripTextBoxPsw.Name = "toolStripTextBoxPsw";
            this.toolStripTextBoxPsw.Size = new System.Drawing.Size(96, 30);
            this.toolStripTextBoxPsw.Text = "00000002";
            this.toolStripTextBoxPsw.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTextBoxPsw.TextChanged += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripBtnWriteAddr
            // 
            this.toolStripBtnWriteAddr.Image = global::iMeter.Properties.Resources.gear_26px_1133400_easyicon_net;
            this.toolStripBtnWriteAddr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnWriteAddr.Margin = new System.Windows.Forms.Padding(30, 1, 0, 2);
            this.toolStripBtnWriteAddr.Name = "toolStripBtnWriteAddr";
            this.toolStripBtnWriteAddr.Size = new System.Drawing.Size(110, 35);
            this.toolStripBtnWriteAddr.Text = "写表地址";
            this.toolStripBtnWriteAddr.Click += new System.EventHandler(this.toolStripBtnWriteAddr_Click);
            // 
            // toolStripTbAddr
            // 
            this.toolStripTbAddr.AutoSize = false;
            this.toolStripTbAddr.BackColor = System.Drawing.Color.White;
            this.toolStripTbAddr.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.toolStripTbAddr.MaxLength = 12;
            this.toolStripTbAddr.Name = "toolStripTbAddr";
            this.toolStripTbAddr.Size = new System.Drawing.Size(178, 33);
            this.toolStripTbAddr.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTbAddr.TextChanged += new System.EventHandler(this.CommunicationPropertyChange);
            // 
            // toolStripBtnReadAddr
            // 
            this.toolStripBtnReadAddr.Image = global::iMeter.Properties.Resources.read_more_32px_1069689_easyicon_net;
            this.toolStripBtnReadAddr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnReadAddr.Name = "toolStripBtnReadAddr";
            this.toolStripBtnReadAddr.Size = new System.Drawing.Size(110, 33);
            this.toolStripBtnReadAddr.Text = "读表地址";
            this.toolStripBtnReadAddr.Click += new System.EventHandler(this.toolStripBtnReadAddr_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制toolStripMenuItem2,
            this.清空ToolStripMenuItem,
            this.全选ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 94);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 复制toolStripMenuItem2
            // 
            this.复制toolStripMenuItem2.Name = "复制toolStripMenuItem2";
            this.复制toolStripMenuItem2.Size = new System.Drawing.Size(116, 30);
            this.复制toolStripMenuItem2.Text = "复制";
            this.复制toolStripMenuItem2.Click += new System.EventHandler(this.复制toolStripMenuItem2_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(116, 30);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(116, 30);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // timerPCTime
            // 
            this.timerPCTime.Interval = 1000;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(199, 29);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // tsslSorF
            // 
            this.tsslSorF.AutoSize = false;
            this.tsslSorF.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslSorF.Name = "tsslSorF";
            this.tsslSorF.Size = new System.Drawing.Size(131, 29);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsslSorF,
            this.statusReturn,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1131);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1456, 36);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusReturn
            // 
            this.statusReturn.AutoSize = false;
            this.statusReturn.Name = "statusReturn";
            this.statusReturn.Size = new System.Drawing.Size(90, 29);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(750, 28);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 74);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tbComMemo);
            this.splitContainer3.Panel2MinSize = 0;
            this.splitContainer3.Size = new System.Drawing.Size(1456, 1057);
            this.splitContainer3.SplitterDistance = 915;
            this.splitContainer3.SplitterWidth = 2;
            this.splitContainer3.TabIndex = 215;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1456, 915);
            this.tabControl1.TabIndex = 0;
            // 
            // tbComMemo
            // 
            this.tbComMemo.BackColor = System.Drawing.Color.White;
            this.tbComMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbComMemo.ContextMenuStrip = this.contextMenuStrip1;
            this.tbComMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbComMemo.Location = new System.Drawing.Point(0, 0);
            this.tbComMemo.Margin = new System.Windows.Forms.Padding(4);
            this.tbComMemo.Multiline = true;
            this.tbComMemo.Name = "tbComMemo";
            this.tbComMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbComMemo.Size = new System.Drawing.Size(1456, 140);
            this.tbComMemo.TabIndex = 0;
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(39, 33);
            this.toolStripLabel5.Text = "CA:";
            // 
            // toolStripTBCA
            // 
            this.toolStripTBCA.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTBCA.Name = "toolStripTBCA";
            this.toolStripTBCA.Size = new System.Drawing.Size(100, 38);
            this.toolStripTBCA.Text = "A1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1456, 1167);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iMeter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Err信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCom;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxBps;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripMenuItem 测试方法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timerPCTime;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBoxOprCode;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBoxPsw;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSorF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.TextBox tbComMemo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制toolStripMenuItem2;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusReturn;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeBps;
        private System.Windows.Forms.ToolStripMenuItem menuItemBps2400;
        private System.Windows.Forms.ToolStripMenuItem menuItemBps9600;
        private System.Windows.Forms.ToolStripButton toolStripBtnWriteAddr;
        private System.Windows.Forms.ToolStripTextBox toolStripTbAddr;
        private System.Windows.Forms.ToolStripButton toolStripBtnReadAddr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox toolStripTBCA;
        //private _645_2007DataSet _645_2007DataSet;
    }
}

