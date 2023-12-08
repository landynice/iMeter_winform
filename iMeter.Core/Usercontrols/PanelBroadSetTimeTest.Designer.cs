namespace iMeter
{
    partial class PanelBroadSetTimeTest
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt1stJsr = new System.Windows.Forms.TextBox();
            this.checkBoxPCTime = new System.Windows.Forms.CheckBox();
            this.txtBroadcastSetTime1 = new System.Windows.Forms.TextBox();
            this.txt3rdJsr = new System.Windows.Forms.TextBox();
            this.txtMeterTime1 = new System.Windows.Forms.TextBox();
            this.txt2ndJsr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReadMeterTime = new System.Windows.Forms.Button();
            this.btnSet3rdJsr = new System.Windows.Forms.Button();
            this.btnSetMeterTime = new System.Windows.Forms.Button();
            this.btnSet2ndJsr = new System.Windows.Forms.Button();
            this.btnBroadcastSetTime = new System.Windows.Forms.Button();
            this.btnSet1stJsr = new System.Windows.Forms.Button();
            this.btnRead1stJsr = new System.Windows.Forms.Button();
            this.btnRead3rdJsr = new System.Windows.Forms.Button();
            this.btnRead2ndJsr = new System.Windows.Forms.Button();
            this.btnSuperBrd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAddrSch = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Location = new System.Drawing.Point(4, 336);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(690, 242);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "标准";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(4, 25);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(682, 213);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "1.广播校时每天只允许一次；\r\n\r\n2.电表可接受的广播校时范围不得大于5min；\r\n\r\n3.“每天只允许一次”中的“天”指电表内的日期，加密方式进行时钟设置前后" +
    "，如果电表日期发生变化，则允许再次广播校时；\r\n\r\n4.在结算数据转存操作前后5min内不能广播校时；\r\n\r\n5.在每日的午夜0时前后5min内不能广播校时。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAddrSch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSuperBrd);
            this.groupBox2.Controls.Add(this.txt1stJsr);
            this.groupBox2.Controls.Add(this.checkBoxPCTime);
            this.groupBox2.Controls.Add(this.txtBroadcastSetTime1);
            this.groupBox2.Controls.Add(this.txt3rdJsr);
            this.groupBox2.Controls.Add(this.txtMeterTime1);
            this.groupBox2.Controls.Add(this.txt2ndJsr);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnReadMeterTime);
            this.groupBox2.Controls.Add(this.btnSet3rdJsr);
            this.groupBox2.Controls.Add(this.btnSetMeterTime);
            this.groupBox2.Controls.Add(this.btnSet2ndJsr);
            this.groupBox2.Controls.Add(this.btnBroadcastSetTime);
            this.groupBox2.Controls.Add(this.btnSet1stJsr);
            this.groupBox2.Controls.Add(this.btnRead1stJsr);
            this.groupBox2.Controls.Add(this.btnRead3rdJsr);
            this.groupBox2.Controls.Add(this.btnRead2ndJsr);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1044, 322);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "广播校时";
            // 
            // txt1stJsr
            // 
            this.txt1stJsr.BackColor = System.Drawing.Color.White;
            this.txt1stJsr.Location = new System.Drawing.Point(284, 153);
            this.txt1stJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt1stJsr.MaxLength = 4;
            this.txt1stJsr.Name = "txt1stJsr";
            this.txt1stJsr.Size = new System.Drawing.Size(122, 28);
            this.txt1stJsr.TabIndex = 13;
            this.txt1stJsr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxPCTime
            // 
            this.checkBoxPCTime.AutoSize = true;
            this.checkBoxPCTime.Location = new System.Drawing.Point(156, 69);
            this.checkBoxPCTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxPCTime.Name = "checkBoxPCTime";
            this.checkBoxPCTime.Size = new System.Drawing.Size(106, 22);
            this.checkBoxPCTime.TabIndex = 0;
            this.checkBoxPCTime.Text = "电脑时间";
            this.checkBoxPCTime.UseVisualStyleBackColor = true;
            this.checkBoxPCTime.CheckedChanged += new System.EventHandler(this.checkBoxPCTime_CheckedChanged);
            // 
            // txtBroadcastSetTime1
            // 
            this.txtBroadcastSetTime1.BackColor = System.Drawing.Color.White;
            this.txtBroadcastSetTime1.Location = new System.Drawing.Point(284, 69);
            this.txtBroadcastSetTime1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBroadcastSetTime1.MaxLength = 6;
            this.txtBroadcastSetTime1.Name = "txtBroadcastSetTime1";
            this.txtBroadcastSetTime1.Size = new System.Drawing.Size(122, 28);
            this.txtBroadcastSetTime1.TabIndex = 1;
            this.txtBroadcastSetTime1.Text = "231201000000";
            // 
            // txt3rdJsr
            // 
            this.txt3rdJsr.BackColor = System.Drawing.Color.White;
            this.txt3rdJsr.Location = new System.Drawing.Point(284, 243);
            this.txt3rdJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt3rdJsr.MaxLength = 4;
            this.txt3rdJsr.Name = "txt3rdJsr";
            this.txt3rdJsr.Size = new System.Drawing.Size(122, 28);
            this.txt3rdJsr.TabIndex = 15;
            this.txt3rdJsr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMeterTime1
            // 
            this.txtMeterTime1.BackColor = System.Drawing.Color.White;
            this.txtMeterTime1.Location = new System.Drawing.Point(284, 110);
            this.txtMeterTime1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMeterTime1.MaxLength = 6;
            this.txtMeterTime1.Name = "txtMeterTime1";
            this.txtMeterTime1.Size = new System.Drawing.Size(122, 28);
            this.txtMeterTime1.TabIndex = 2;
            // 
            // txt2ndJsr
            // 
            this.txt2ndJsr.BackColor = System.Drawing.Color.White;
            this.txt2ndJsr.Location = new System.Drawing.Point(284, 200);
            this.txt2ndJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt2ndJsr.MaxLength = 4;
            this.txt2ndJsr.Name = "txt2ndJsr";
            this.txt2ndJsr.Size = new System.Drawing.Size(122, 28);
            this.txt2ndJsr.TabIndex = 14;
            this.txt2ndJsr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "YYMMDD hhmmss";
            // 
            // btnReadMeterTime
            // 
            this.btnReadMeterTime.Location = new System.Drawing.Point(417, 110);
            this.btnReadMeterTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReadMeterTime.Name = "btnReadMeterTime";
            this.btnReadMeterTime.Size = new System.Drawing.Size(123, 34);
            this.btnReadMeterTime.TabIndex = 4;
            this.btnReadMeterTime.Text = "读表时间";
            this.btnReadMeterTime.UseVisualStyleBackColor = true;
            this.btnReadMeterTime.Click += new System.EventHandler(this.btnReadMeterTime_Click);
            // 
            // btnSet3rdJsr
            // 
            this.btnSet3rdJsr.Location = new System.Drawing.Point(417, 240);
            this.btnSet3rdJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSet3rdJsr.Name = "btnSet3rdJsr";
            this.btnSet3rdJsr.Size = new System.Drawing.Size(123, 34);
            this.btnSet3rdJsr.TabIndex = 12;
            this.btnSet3rdJsr.Text = "设第3结算日";
            this.btnSet3rdJsr.UseVisualStyleBackColor = true;
            this.btnSet3rdJsr.Click += new System.EventHandler(this.btnSet3rdJsr_Click);
            // 
            // btnSetMeterTime
            // 
            this.btnSetMeterTime.Location = new System.Drawing.Point(152, 110);
            this.btnSetMeterTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetMeterTime.Name = "btnSetMeterTime";
            this.btnSetMeterTime.Size = new System.Drawing.Size(123, 34);
            this.btnSetMeterTime.TabIndex = 5;
            this.btnSetMeterTime.Text = "设表时间";
            this.btnSetMeterTime.UseVisualStyleBackColor = true;
            this.btnSetMeterTime.Click += new System.EventHandler(this.btnSetMeterTime_Click);
            // 
            // btnSet2ndJsr
            // 
            this.btnSet2ndJsr.Location = new System.Drawing.Point(417, 195);
            this.btnSet2ndJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSet2ndJsr.Name = "btnSet2ndJsr";
            this.btnSet2ndJsr.Size = new System.Drawing.Size(123, 34);
            this.btnSet2ndJsr.TabIndex = 11;
            this.btnSet2ndJsr.Text = "设第2结算日";
            this.btnSet2ndJsr.UseVisualStyleBackColor = true;
            this.btnSet2ndJsr.Click += new System.EventHandler(this.btnSet2ndJsr_Click);
            // 
            // btnBroadcastSetTime
            // 
            this.btnBroadcastSetTime.Location = new System.Drawing.Point(417, 66);
            this.btnBroadcastSetTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBroadcastSetTime.Name = "btnBroadcastSetTime";
            this.btnBroadcastSetTime.Size = new System.Drawing.Size(123, 34);
            this.btnBroadcastSetTime.TabIndex = 6;
            this.btnBroadcastSetTime.Text = "广播校时";
            this.btnBroadcastSetTime.UseVisualStyleBackColor = true;
            this.btnBroadcastSetTime.Click += new System.EventHandler(this.btnBroadcastSetTime_Click);
            // 
            // btnSet1stJsr
            // 
            this.btnSet1stJsr.Location = new System.Drawing.Point(417, 150);
            this.btnSet1stJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSet1stJsr.Name = "btnSet1stJsr";
            this.btnSet1stJsr.Size = new System.Drawing.Size(123, 34);
            this.btnSet1stJsr.TabIndex = 10;
            this.btnSet1stJsr.Text = "设第1结算日";
            this.btnSet1stJsr.UseVisualStyleBackColor = true;
            this.btnSet1stJsr.Click += new System.EventHandler(this.btnSet1stJsr_Click);
            // 
            // btnRead1stJsr
            // 
            this.btnRead1stJsr.Location = new System.Drawing.Point(152, 153);
            this.btnRead1stJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead1stJsr.Name = "btnRead1stJsr";
            this.btnRead1stJsr.Size = new System.Drawing.Size(123, 34);
            this.btnRead1stJsr.TabIndex = 7;
            this.btnRead1stJsr.Text = "读第1结算日";
            this.btnRead1stJsr.UseVisualStyleBackColor = true;
            this.btnRead1stJsr.Click += new System.EventHandler(this.btnRead1stJsr_Click);
            // 
            // btnRead3rdJsr
            // 
            this.btnRead3rdJsr.Location = new System.Drawing.Point(152, 240);
            this.btnRead3rdJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead3rdJsr.Name = "btnRead3rdJsr";
            this.btnRead3rdJsr.Size = new System.Drawing.Size(123, 34);
            this.btnRead3rdJsr.TabIndex = 9;
            this.btnRead3rdJsr.Text = "读第3结算日";
            this.btnRead3rdJsr.UseVisualStyleBackColor = true;
            this.btnRead3rdJsr.Click += new System.EventHandler(this.btnRead3rdJsr_Click);
            // 
            // btnRead2ndJsr
            // 
            this.btnRead2ndJsr.Location = new System.Drawing.Point(152, 196);
            this.btnRead2ndJsr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead2ndJsr.Name = "btnRead2ndJsr";
            this.btnRead2ndJsr.Size = new System.Drawing.Size(123, 34);
            this.btnRead2ndJsr.TabIndex = 8;
            this.btnRead2ndJsr.Text = "读第2结算日";
            this.btnRead2ndJsr.UseVisualStyleBackColor = true;
            this.btnRead2ndJsr.Click += new System.EventHandler(this.btnRead2ndJsr_Click);
            // 
            // btnSuperBrd
            // 
            this.btnSuperBrd.Location = new System.Drawing.Point(548, 66);
            this.btnSuperBrd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuperBrd.Name = "btnSuperBrd";
            this.btnSuperBrd.Size = new System.Drawing.Size(123, 34);
            this.btnSuperBrd.TabIndex = 18;
            this.btnSuperBrd.Text = "超播";
            this.btnSuperBrd.UseVisualStyleBackColor = true;
            this.btnSuperBrd.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(694, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "地址方案：";
            // 
            // cbAddrSch
            // 
            this.cbAddrSch.FormattingEnabled = true;
            this.cbAddrSch.Items.AddRange(new object[] {
            "999999999999",
            "电表地址"});
            this.cbAddrSch.Location = new System.Drawing.Point(782, 71);
            this.cbAddrSch.Name = "cbAddrSch";
            this.cbAddrSch.Size = new System.Drawing.Size(121, 26);
            this.cbAddrSch.TabIndex = 20;
            // 
            // PanelBroadSetTimeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PanelBroadSetTimeTest";
            this.Size = new System.Drawing.Size(1052, 584);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt1stJsr;
        private System.Windows.Forms.CheckBox checkBoxPCTime;
        private System.Windows.Forms.TextBox txtBroadcastSetTime1;
        private System.Windows.Forms.TextBox txt3rdJsr;
        private System.Windows.Forms.TextBox txtMeterTime1;
        private System.Windows.Forms.TextBox txt2ndJsr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReadMeterTime;
        private System.Windows.Forms.Button btnSet3rdJsr;
        private System.Windows.Forms.Button btnSetMeterTime;
        private System.Windows.Forms.Button btnSet2ndJsr;
        private System.Windows.Forms.Button btnBroadcastSetTime;
        private System.Windows.Forms.Button btnSet1stJsr;
        private System.Windows.Forms.Button btnRead1stJsr;
        private System.Windows.Forms.Button btnRead3rdJsr;
        private System.Windows.Forms.Button btnRead2ndJsr;
        private System.Windows.Forms.ComboBox cbAddrSch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuperBrd;
    }
}
