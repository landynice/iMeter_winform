namespace iMeter
{
    partial class PanelInfinitTest
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRead = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtTimes = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lbltimes = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnOutData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(171, 23);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(65, 25);
            this.txtId.MaxLength = 8;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 1;
            this.txtId.Text = "04000102";
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTimes
            // 
            this.txtTimes.Location = new System.Drawing.Point(252, 25);
            this.txtTimes.Name = "txtTimes";
            this.txtTimes.Size = new System.Drawing.Size(100, 21);
            this.txtTimes.TabIndex = 2;
            this.txtTimes.Text = "10";
            this.txtTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(36, 30);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 12);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID:";
            // 
            // lbltimes
            // 
            this.lbltimes.AutoSize = true;
            this.lbltimes.Location = new System.Drawing.Point(358, 30);
            this.lbltimes.Name = "lbltimes";
            this.lbltimes.Size = new System.Drawing.Size(17, 12);
            this.lbltimes.TabIndex = 4;
            this.lbltimes.Text = "次";
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtContent.Location = new System.Drawing.Point(0, 66);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(718, 465);
            this.txtContent.TabIndex = 5;
            // 
            // btnOutData
            // 
            this.btnOutData.Location = new System.Drawing.Point(611, 25);
            this.btnOutData.Name = "btnOutData";
            this.btnOutData.Size = new System.Drawing.Size(75, 23);
            this.btnOutData.TabIndex = 6;
            this.btnOutData.Text = "导出数据";
            this.btnOutData.UseVisualStyleBackColor = true;
            this.btnOutData.Click += new System.EventHandler(this.btnOutData_Click);
            // 
            // PanelInfinitTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOutData);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lbltimes);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtTimes);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnRead);
            this.Name = "PanelInfinitTest";
            this.Size = new System.Drawing.Size(718, 531);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTimes;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lbltimes;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnOutData;
    }
}
