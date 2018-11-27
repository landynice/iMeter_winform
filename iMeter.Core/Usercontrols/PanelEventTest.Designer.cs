namespace iMeter
{
    partial class PanelEventTest
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
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.txtBoxTimeSetEvent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimeSetEventTest = new System.Windows.Forms.Button();
            this.btnDataSave = new System.Windows.Forms.Button();
            this.textBoxTestTimes = new System.Windows.Forms.TextBox();
            this.labelSetTimeEventTestResult = new System.Windows.Forms.Label();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.tBRecID = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.lbRecTestResult = new System.Windows.Forms.Label();
            this.btnR1_NRec2 = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.btnCmp2Rec = new System.Windows.Forms.Button();
            this.tBRecN = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tBTestRec2 = new System.Windows.Forms.TextBox();
            this.tBTestRec1 = new System.Windows.Forms.TextBox();
            this.btnR1_NRec1 = new System.Windows.Forms.Button();
            this.tabControl4.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage13);
            this.tabControl4.Controls.Add(this.tabPage14);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(917, 666);
            this.tabControl4.TabIndex = 7;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.txtBoxTimeSetEvent);
            this.tabPage13.Controls.Add(this.label2);
            this.tabPage13.Controls.Add(this.btnTimeSetEventTest);
            this.tabPage13.Controls.Add(this.btnDataSave);
            this.tabPage13.Controls.Add(this.textBoxTestTimes);
            this.tabPage13.Controls.Add(this.labelSetTimeEventTestResult);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(909, 640);
            this.tabPage13.TabIndex = 0;
            this.tabPage13.Text = "校时记录";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // txtBoxTimeSetEvent
            // 
            this.txtBoxTimeSetEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTimeSetEvent.BackColor = System.Drawing.Color.White;
            this.txtBoxTimeSetEvent.Location = new System.Drawing.Point(3, 36);
            this.txtBoxTimeSetEvent.Multiline = true;
            this.txtBoxTimeSetEvent.Name = "txtBoxTimeSetEvent";
            this.txtBoxTimeSetEvent.ReadOnly = true;
            this.txtBoxTimeSetEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxTimeSetEvent.Size = new System.Drawing.Size(903, 603);
            this.txtBoxTimeSetEvent.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "测试次数：";
            // 
            // btnTimeSetEventTest
            // 
            this.btnTimeSetEventTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimeSetEventTest.Location = new System.Drawing.Point(515, 5);
            this.btnTimeSetEventTest.Name = "btnTimeSetEventTest";
            this.btnTimeSetEventTest.Size = new System.Drawing.Size(75, 23);
            this.btnTimeSetEventTest.TabIndex = 0;
            this.btnTimeSetEventTest.Text = "开始测试";
            this.btnTimeSetEventTest.UseVisualStyleBackColor = true;
            this.btnTimeSetEventTest.Click += new System.EventHandler(this.btnTimeSetEventTest_Click);
            // 
            // btnDataSave
            // 
            this.btnDataSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataSave.Location = new System.Drawing.Point(653, 5);
            this.btnDataSave.Name = "btnDataSave";
            this.btnDataSave.Size = new System.Drawing.Size(75, 23);
            this.btnDataSave.TabIndex = 4;
            this.btnDataSave.Text = "导出数据";
            this.btnDataSave.UseVisualStyleBackColor = true;
            this.btnDataSave.Click += new System.EventHandler(this.btnDataSave_Click);
            // 
            // textBoxTestTimes
            // 
            this.textBoxTestTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxTestTimes.BackColor = System.Drawing.Color.White;
            this.textBoxTestTimes.Location = new System.Drawing.Point(393, 6);
            this.textBoxTestTimes.MaxLength = 5;
            this.textBoxTestTimes.Name = "textBoxTestTimes";
            this.textBoxTestTimes.Size = new System.Drawing.Size(100, 21);
            this.textBoxTestTimes.TabIndex = 1;
            this.textBoxTestTimes.Text = "1";
            this.textBoxTestTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelSetTimeEventTestResult
            // 
            this.labelSetTimeEventTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSetTimeEventTestResult.AutoSize = true;
            this.labelSetTimeEventTestResult.Location = new System.Drawing.Point(770, 10);
            this.labelSetTimeEventTestResult.Name = "labelSetTimeEventTestResult";
            this.labelSetTimeEventTestResult.Size = new System.Drawing.Size(65, 12);
            this.labelSetTimeEventTestResult.TabIndex = 3;
            this.labelSetTimeEventTestResult.Text = "测试结果：";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.tBRecID);
            this.tabPage14.Controls.Add(this.label57);
            this.tabPage14.Controls.Add(this.lbRecTestResult);
            this.tabPage14.Controls.Add(this.btnR1_NRec2);
            this.tabPage14.Controls.Add(this.label56);
            this.tabPage14.Controls.Add(this.btnCmp2Rec);
            this.tabPage14.Controls.Add(this.tBRecN);
            this.tabPage14.Controls.Add(this.label55);
            this.tabPage14.Controls.Add(this.tBTestRec2);
            this.tabPage14.Controls.Add(this.tBTestRec1);
            this.tabPage14.Controls.Add(this.btnR1_NRec1);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(909, 640);
            this.tabPage14.TabIndex = 1;
            this.tabPage14.Text = "事件抄读对比";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // tBRecID
            // 
            this.tBRecID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBRecID.Location = new System.Drawing.Point(641, 7);
            this.tBRecID.MaxLength = 6;
            this.tBRecID.Name = "tBRecID";
            this.tBRecID.Size = new System.Drawing.Size(103, 21);
            this.tBRecID.TabIndex = 13;
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(516, 10);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(119, 12);
            this.label57.TabIndex = 12;
            this.label57.Text = "事件ID前6位[D3D2D1]";
            // 
            // lbRecTestResult
            // 
            this.lbRecTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRecTestResult.AutoSize = true;
            this.lbRecTestResult.Location = new System.Drawing.Point(679, 100);
            this.lbRecTestResult.Name = "lbRecTestResult";
            this.lbRecTestResult.Size = new System.Drawing.Size(65, 12);
            this.lbRecTestResult.TabIndex = 11;
            this.lbRecTestResult.Text = "对比结果：";
            // 
            // btnR1_NRec2
            // 
            this.btnR1_NRec2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR1_NRec2.Location = new System.Drawing.Point(750, 31);
            this.btnR1_NRec2.Name = "btnR1_NRec2";
            this.btnR1_NRec2.Size = new System.Drawing.Size(153, 23);
            this.btnR1_NRec2.TabIndex = 10;
            this.btnR1_NRec2.Text = "测试后：读上1~N次记录";
            this.btnR1_NRec2.UseVisualStyleBackColor = true;
            this.btnR1_NRec2.Click += new System.EventHandler(this.btnR1_NRec2_Click);
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(439, 65);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(305, 12);
            this.label56.TabIndex = 9;
            this.label56.Text = "对比测试后上2~N次记录是否等于测试前上1~(N-1)次记录";
            // 
            // btnCmp2Rec
            // 
            this.btnCmp2Rec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCmp2Rec.Location = new System.Drawing.Point(750, 60);
            this.btnCmp2Rec.Name = "btnCmp2Rec";
            this.btnCmp2Rec.Size = new System.Drawing.Size(153, 23);
            this.btnCmp2Rec.TabIndex = 8;
            this.btnCmp2Rec.Text = "对比";
            this.btnCmp2Rec.UseVisualStyleBackColor = true;
            this.btnCmp2Rec.Click += new System.EventHandler(this.btnCmp2Rec_Click);
            // 
            // tBRecN
            // 
            this.tBRecN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBRecN.Location = new System.Drawing.Point(641, 33);
            this.tBRecN.MaxLength = 2;
            this.tBRecN.Name = "tBRecN";
            this.tBRecN.Size = new System.Drawing.Size(103, 21);
            this.tBRecN.TabIndex = 7;
            this.tBRecN.Text = "10";
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(558, 36);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(77, 12);
            this.label55.TabIndex = 6;
            this.label55.Text = "事件记录次数";
            // 
            // tBTestRec2
            // 
            this.tBTestRec2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBTestRec2.BackColor = System.Drawing.Color.White;
            this.tBTestRec2.Location = new System.Drawing.Point(508, 116);
            this.tBTestRec2.Multiline = true;
            this.tBTestRec2.Name = "tBTestRec2";
            this.tBTestRec2.ReadOnly = true;
            this.tBTestRec2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBTestRec2.Size = new System.Drawing.Size(395, 528);
            this.tBTestRec2.TabIndex = 4;
            // 
            // tBTestRec1
            // 
            this.tBTestRec1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tBTestRec1.BackColor = System.Drawing.Color.White;
            this.tBTestRec1.Location = new System.Drawing.Point(3, 116);
            this.tBTestRec1.Multiline = true;
            this.tBTestRec1.Name = "tBTestRec1";
            this.tBTestRec1.ReadOnly = true;
            this.tBTestRec1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBTestRec1.Size = new System.Drawing.Size(500, 528);
            this.tBTestRec1.TabIndex = 3;
            // 
            // btnR1_NRec1
            // 
            this.btnR1_NRec1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR1_NRec1.Location = new System.Drawing.Point(750, 5);
            this.btnR1_NRec1.Name = "btnR1_NRec1";
            this.btnR1_NRec1.Size = new System.Drawing.Size(153, 23);
            this.btnR1_NRec1.TabIndex = 0;
            this.btnR1_NRec1.Text = "测试前：读上1~N次记录";
            this.btnR1_NRec1.UseVisualStyleBackColor = true;
            this.btnR1_NRec1.Click += new System.EventHandler(this.btnR1_NRec1_Click);
            // 
            // PanelEventTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl4);
            this.Name = "PanelEventTest";
            this.Size = new System.Drawing.Size(917, 666);
            this.tabControl4.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage13;
        public System.Windows.Forms.TextBox txtBoxTimeSetEvent;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnTimeSetEventTest;
        public System.Windows.Forms.Button btnDataSave;
        public System.Windows.Forms.TextBox textBoxTestTimes;
        public System.Windows.Forms.Label labelSetTimeEventTestResult;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TextBox tBRecID;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label lbRecTestResult;
        private System.Windows.Forms.Button btnR1_NRec2;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button btnCmp2Rec;
        private System.Windows.Forms.TextBox tBRecN;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox tBTestRec2;
        private System.Windows.Forms.TextBox tBTestRec1;
        private System.Windows.Forms.Button btnR1_NRec1;
    }
}
