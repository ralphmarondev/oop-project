namespace StudentAttendanceManagementSystem.Debug
{
    partial class AddingItemsInComboBox
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_add_item = new System.Windows.Forms.Button();
            this.tb_item_to_add = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 142);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(251, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // btn_add_item
            // 
            this.btn_add_item.Location = new System.Drawing.Point(16, 78);
            this.btn_add_item.Name = "btn_add_item";
            this.btn_add_item.Size = new System.Drawing.Size(251, 38);
            this.btn_add_item.TabIndex = 1;
            this.btn_add_item.Text = "Add Item";
            this.btn_add_item.UseVisualStyleBackColor = true;
            this.btn_add_item.Click += new System.EventHandler(this.btn_add_item_Click);
            // 
            // tb_item_to_add
            // 
            this.tb_item_to_add.Location = new System.Drawing.Point(16, 32);
            this.tb_item_to_add.Name = "tb_item_to_add";
            this.tb_item_to_add.Size = new System.Drawing.Size(251, 27);
            this.tb_item_to_add.TabIndex = 2;
            // 
            // AddingItemsInComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 214);
            this.Controls.Add(this.tb_item_to_add);
            this.Controls.Add(this.btn_add_item);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddingItemsInComboBox";
            this.Text = "AddingItemsInComboBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_add_item;
        private System.Windows.Forms.TextBox tb_item_to_add;
    }
}