namespace StudentAttendanceManagementSystem.Debug.SettingRowAndColumnButton
{
    partial class ButtonRowAndColumn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_row = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_column = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.buttons_panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_column);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb_row);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 72);
            this.panel1.TabIndex = 1;
            // 
            // tb_row
            // 
            this.tb_row.Location = new System.Drawing.Point(577, 32);
            this.tb_row.Name = "tb_row";
            this.tb_row.Size = new System.Drawing.Size(100, 27);
            this.tb_row.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Row:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(690, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Col:";
            // 
            // tb_column
            // 
            this.tb_column.Location = new System.Drawing.Point(694, 32);
            this.tb_column.Name = "tb_column";
            this.tb_column.Size = new System.Drawing.Size(100, 27);
            this.tb_column.TabIndex = 2;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(845, 12);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(143, 47);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "REFRESH";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // buttons_panel
            // 
            this.buttons_panel.AutoScroll = true;
            this.buttons_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttons_panel.Location = new System.Drawing.Point(0, 72);
            this.buttons_panel.Name = "buttons_panel";
            this.buttons_panel.Size = new System.Drawing.Size(1000, 490);
            this.buttons_panel.TabIndex = 2;
            // 
            // ButtonRowAndColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.buttons_panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ButtonRowAndColumn";
            this.Text = "ButtonRowAndColumn";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_column;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_row;
        private System.Windows.Forms.Panel buttons_panel;
    }
}