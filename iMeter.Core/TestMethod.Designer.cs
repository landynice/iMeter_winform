namespace iMeter
{
    partial class TestMethod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxSetTime = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxZhengdian = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(504, 350);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxSetTime);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(496, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "校时事件测试";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxSetTime
            // 
            this.textBoxSetTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSetTime.Location = new System.Drawing.Point(3, 3);
            this.textBoxSetTime.Multiline = true;
            this.textBoxSetTime.Name = "textBoxSetTime";
            this.textBoxSetTime.ReadOnly = true;
            this.textBoxSetTime.Size = new System.Drawing.Size(490, 319);
            this.textBoxSetTime.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxZhengdian);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(496, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "整点冻结测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxZhengdian
            // 
            this.textBoxZhengdian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxZhengdian.Location = new System.Drawing.Point(3, 3);
            this.textBoxZhengdian.Multiline = true;
            this.textBoxZhengdian.Name = "textBoxZhengdian";
            this.textBoxZhengdian.ReadOnly = true;
            this.textBoxZhengdian.Size = new System.Drawing.Size(490, 319);
            this.textBoxZhengdian.TabIndex = 0;
            // 
            // TestMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 350);
            this.Controls.Add(this.tabControl1);
            this.Name = "TestMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestMethod";
            this.Load += new System.EventHandler(this.TestMethod_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxSetTime;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxZhengdian;
    }
}