namespace StudentAttendanceManagementSystem.Test
{
    partial class IncrementingDBRecord
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
            this.btn_increment_absent = new System.Windows.Forms.Button();
            this.btn_increment_present = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_increment_absent
            // 
            this.btn_increment_absent.Location = new System.Drawing.Point(12, 77);
            this.btn_increment_absent.Name = "btn_increment_absent";
            this.btn_increment_absent.Size = new System.Drawing.Size(269, 45);
            this.btn_increment_absent.TabIndex = 0;
            this.btn_increment_absent.Text = "INCREMENT ABSENT";
            this.btn_increment_absent.UseVisualStyleBackColor = true;
            this.btn_increment_absent.Click += new System.EventHandler(this.btn_increment_absent_Click);
            // 
            // btn_increment_present
            // 
            this.btn_increment_present.Location = new System.Drawing.Point(306, 77);
            this.btn_increment_present.Name = "btn_increment_present";
            this.btn_increment_present.Size = new System.Drawing.Size(269, 45);
            this.btn_increment_present.TabIndex = 1;
            this.btn_increment_present.Text = "INCREMENT PRESENT";
            this.btn_increment_present.UseVisualStyleBackColor = true;
            // 
            // IncrementingDBRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 147);
            this.Controls.Add(this.btn_increment_present);
            this.Controls.Add(this.btn_increment_absent);
            this.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IncrementingDBRecord";
            this.Text = "IncrementingDBRecord";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_increment_absent;
        private System.Windows.Forms.Button btn_increment_present;
    }
}