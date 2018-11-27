namespace iMeter
{
    partial class PanelEnergyTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTestEnergy = new System.Windows.Forms.DataGridView();
            this.sumOfEnergy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feilv1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feilv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feilv3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feilv4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wucha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOfReadMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnergyTestStop = new System.Windows.Forms.Button();
            this.btnEnergyTestStart = new System.Windows.Forms.Button();
            this.checkBoxZuhe = new System.Windows.Forms.CheckBox();
            this.radioButtonF = new System.Windows.Forms.RadioButton();
            this.checkBoxZhengxiang = new System.Windows.Forms.CheckBox();
            this.radioButtonZ = new System.Windows.Forms.RadioButton();
            this.checkBoxFanxiang = new System.Windows.Forms.CheckBox();
            this.radioButtonZ_F = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestEnergy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTestEnergy
            // 
            this.dataGridViewTestEnergy.AllowUserToAddRows = false;
            this.dataGridViewTestEnergy.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTestEnergy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTestEnergy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTestEnergy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestEnergy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sumOfEnergy,
            this.feilv1,
            this.feilv2,
            this.feilv3,
            this.feilv4,
            this.wucha1,
            this.timeOfReadMeter});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTestEnergy.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTestEnergy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTestEnergy.Location = new System.Drawing.Point(0, 79);
            this.dataGridViewTestEnergy.Name = "dataGridViewTestEnergy";
            this.dataGridViewTestEnergy.ReadOnly = true;
            this.dataGridViewTestEnergy.RowHeadersWidth = 180;
            this.dataGridViewTestEnergy.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTestEnergy.RowTemplate.Height = 23;
            this.dataGridViewTestEnergy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTestEnergy.Size = new System.Drawing.Size(915, 380);
            this.dataGridViewTestEnergy.TabIndex = 10;
            // 
            // sumOfEnergy
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sumOfEnergy.DefaultCellStyle = dataGridViewCellStyle8;
            this.sumOfEnergy.HeaderText = "总电量/kWh";
            this.sumOfEnergy.Name = "sumOfEnergy";
            this.sumOfEnergy.ReadOnly = true;
            this.sumOfEnergy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feilv1
            // 
            this.feilv1.HeaderText = "费率1/kWh";
            this.feilv1.Name = "feilv1";
            this.feilv1.ReadOnly = true;
            this.feilv1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feilv2
            // 
            this.feilv2.HeaderText = "费率2/kWh";
            this.feilv2.Name = "feilv2";
            this.feilv2.ReadOnly = true;
            this.feilv2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feilv3
            // 
            this.feilv3.HeaderText = "费率3/kWh";
            this.feilv3.Name = "feilv3";
            this.feilv3.ReadOnly = true;
            this.feilv3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feilv4
            // 
            this.feilv4.HeaderText = "费率4/kWh";
            this.feilv4.Name = "feilv4";
            this.feilv4.ReadOnly = true;
            this.feilv4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // wucha1
            // 
            this.wucha1.HeaderText = "误差(总-(1+2+3+4)/kWh";
            this.wucha1.Name = "wucha1";
            this.wucha1.ReadOnly = true;
            this.wucha1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // timeOfReadMeter
            // 
            this.timeOfReadMeter.HeaderText = "抄表时间";
            this.timeOfReadMeter.Name = "timeOfReadMeter";
            this.timeOfReadMeter.ReadOnly = true;
            this.timeOfReadMeter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnergyTestStop);
            this.groupBox1.Controls.Add(this.btnEnergyTestStart);
            this.groupBox1.Controls.Add(this.checkBoxZuhe);
            this.groupBox1.Controls.Add(this.radioButtonF);
            this.groupBox1.Controls.Add(this.checkBoxZhengxiang);
            this.groupBox1.Controls.Add(this.radioButtonZ);
            this.groupBox1.Controls.Add(this.checkBoxFanxiang);
            this.groupBox1.Controls.Add(this.radioButtonZ_F);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 79);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // btnEnergyTestStop
            // 
            this.btnEnergyTestStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnergyTestStop.Location = new System.Drawing.Point(719, 28);
            this.btnEnergyTestStop.Name = "btnEnergyTestStop";
            this.btnEnergyTestStop.Size = new System.Drawing.Size(75, 23);
            this.btnEnergyTestStop.TabIndex = 8;
            this.btnEnergyTestStop.Text = "结束";
            this.btnEnergyTestStop.UseVisualStyleBackColor = true;
            this.btnEnergyTestStop.Click += new System.EventHandler(this.btnEnergyTestStop_Click);
            // 
            // btnEnergyTestStart
            // 
            this.btnEnergyTestStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnergyTestStart.Location = new System.Drawing.Point(590, 28);
            this.btnEnergyTestStart.Name = "btnEnergyTestStart";
            this.btnEnergyTestStart.Size = new System.Drawing.Size(75, 23);
            this.btnEnergyTestStart.TabIndex = 7;
            this.btnEnergyTestStart.Text = "开始";
            this.btnEnergyTestStart.UseVisualStyleBackColor = true;
            this.btnEnergyTestStart.Click += new System.EventHandler(this.btnEnergyTestStart_Click);
            // 
            // checkBoxZuhe
            // 
            this.checkBoxZuhe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBoxZuhe.AutoSize = true;
            this.checkBoxZuhe.Checked = true;
            this.checkBoxZuhe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZuhe.Location = new System.Drawing.Point(121, 19);
            this.checkBoxZuhe.Name = "checkBoxZuhe";
            this.checkBoxZuhe.Size = new System.Drawing.Size(96, 16);
            this.checkBoxZuhe.TabIndex = 1;
            this.checkBoxZuhe.Text = "组合有功电量";
            this.checkBoxZuhe.UseVisualStyleBackColor = true;
            // 
            // radioButtonF
            // 
            this.radioButtonF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.radioButtonF.AutoSize = true;
            this.radioButtonF.Location = new System.Drawing.Point(417, 43);
            this.radioButtonF.Name = "radioButtonF";
            this.radioButtonF.Size = new System.Drawing.Size(101, 16);
            this.radioButtonF.TabIndex = 6;
            this.radioButtonF.Text = "组合=反向有功";
            this.radioButtonF.UseVisualStyleBackColor = true;
            // 
            // checkBoxZhengxiang
            // 
            this.checkBoxZhengxiang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBoxZhengxiang.AutoSize = true;
            this.checkBoxZhengxiang.Checked = true;
            this.checkBoxZhengxiang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZhengxiang.Location = new System.Drawing.Point(269, 19);
            this.checkBoxZhengxiang.Name = "checkBoxZhengxiang";
            this.checkBoxZhengxiang.Size = new System.Drawing.Size(96, 16);
            this.checkBoxZhengxiang.TabIndex = 2;
            this.checkBoxZhengxiang.Text = "正向有功电量";
            this.checkBoxZhengxiang.UseVisualStyleBackColor = true;
            // 
            // radioButtonZ
            // 
            this.radioButtonZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.radioButtonZ.AutoSize = true;
            this.radioButtonZ.Location = new System.Drawing.Point(296, 43);
            this.radioButtonZ.Name = "radioButtonZ";
            this.radioButtonZ.Size = new System.Drawing.Size(101, 16);
            this.radioButtonZ.TabIndex = 5;
            this.radioButtonZ.Text = "组合=正向有功";
            this.radioButtonZ.UseVisualStyleBackColor = true;
            // 
            // checkBoxFanxiang
            // 
            this.checkBoxFanxiang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBoxFanxiang.AutoSize = true;
            this.checkBoxFanxiang.Checked = true;
            this.checkBoxFanxiang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFanxiang.Location = new System.Drawing.Point(417, 19);
            this.checkBoxFanxiang.Name = "checkBoxFanxiang";
            this.checkBoxFanxiang.Size = new System.Drawing.Size(96, 16);
            this.checkBoxFanxiang.TabIndex = 3;
            this.checkBoxFanxiang.Text = "反向有功电量";
            this.checkBoxFanxiang.UseVisualStyleBackColor = true;
            // 
            // radioButtonZ_F
            // 
            this.radioButtonZ_F.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.radioButtonZ_F.AutoSize = true;
            this.radioButtonZ_F.Checked = true;
            this.radioButtonZ_F.Location = new System.Drawing.Point(121, 43);
            this.radioButtonZ_F.Name = "radioButtonZ_F";
            this.radioButtonZ_F.Size = new System.Drawing.Size(155, 16);
            this.radioButtonZ_F.TabIndex = 4;
            this.radioButtonZ_F.TabStop = true;
            this.radioButtonZ_F.Text = "组合=正向有功+反向有功";
            this.radioButtonZ_F.UseVisualStyleBackColor = true;
            // 
            // PanelEnergyTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewTestEnergy);
            this.Controls.Add(this.groupBox1);
            this.Name = "PanelEnergyTest";
            this.Size = new System.Drawing.Size(915, 459);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestEnergy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTestEnergy;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumOfEnergy;
        private System.Windows.Forms.DataGridViewTextBoxColumn feilv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn feilv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn feilv3;
        private System.Windows.Forms.DataGridViewTextBoxColumn feilv4;
        private System.Windows.Forms.DataGridViewTextBoxColumn wucha1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOfReadMeter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnergyTestStop;
        private System.Windows.Forms.Button btnEnergyTestStart;
        private System.Windows.Forms.CheckBox checkBoxZuhe;
        private System.Windows.Forms.RadioButton radioButtonF;
        private System.Windows.Forms.CheckBox checkBoxZhengxiang;
        private System.Windows.Forms.RadioButton radioButtonZ;
        private System.Windows.Forms.CheckBox checkBoxFanxiang;
        private System.Windows.Forms.RadioButton radioButtonZ_F;
    }
}
