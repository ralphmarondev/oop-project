﻿namespace StudentAttendanceManagementSystem.StudentModule
{
    partial class StudentForm
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
            this.btn_search_student = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_school_year = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_semester = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_department = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_college = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_class = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_student_id_search = new System.Windows.Forms.Label();
            this.tb_student_id_search = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_delete_student = new System.Windows.Forms.Button();
            this.btn_add_student = new System.Windows.Forms.Button();
            this.btn_update_student = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_better_view = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_check_attendance = new System.Windows.Forms.Button();
            this.dgv_classes_lists = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flp_students = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_classes_lists)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search_student
            // 
            this.btn_search_student.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_student.Location = new System.Drawing.Point(670, 77);
            this.btn_search_student.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search_student.Name = "btn_search_student";
            this.btn_search_student.Size = new System.Drawing.Size(173, 45);
            this.btn_search_student.TabIndex = 9;
            this.btn_search_student.Text = "Search";
            this.btn_search_student.UseVisualStyleBackColor = true;
            this.btn_search_student.Click += new System.EventHandler(this.btn_search_student_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.Controls.Add(this.cb_school_year);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cb_semester);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cb_department);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cb_college);
            this.panel1.Controls.Add(this.btn_search_student);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_class);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_student_id_search);
            this.panel1.Controls.Add(this.tb_student_id_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(265, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 135);
            this.panel1.TabIndex = 25;
            // 
            // cb_school_year
            // 
            this.cb_school_year.FormattingEnabled = true;
            this.cb_school_year.Items.AddRange(new object[] {
            "2022-2023",
            "2023-2024",
            "2024-2025",
            "2025-2026",
            "2026-2027",
            "2027-2028",
            "2028-2029"});
            this.cb_school_year.Location = new System.Drawing.Point(234, 91);
            this.cb_school_year.Margin = new System.Windows.Forms.Padding(4);
            this.cb_school_year.Name = "cb_school_year";
            this.cb_school_year.Size = new System.Drawing.Size(196, 28);
            this.cb_school_year.TabIndex = 27;
            this.cb_school_year.Text = "2022-2023";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(231, 66);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "School Year:";
            // 
            // cb_semester
            // 
            this.cb_semester.FormattingEnabled = true;
            this.cb_semester.Items.AddRange(new object[] {
            "FIRST SEMESTER",
            "SECOND SEMESTER"});
            this.cb_semester.Location = new System.Drawing.Point(13, 91);
            this.cb_semester.Margin = new System.Windows.Forms.Padding(4);
            this.cb_semester.Name = "cb_semester";
            this.cb_semester.Size = new System.Drawing.Size(196, 28);
            this.cb_semester.TabIndex = 25;
            this.cb_semester.Text = "FIRST SEMESTER";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 66);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "Semester:";
            // 
            // cb_department
            // 
            this.cb_department.FormattingEnabled = true;
            this.cb_department.Items.AddRange(new object[] {
            "BSCPE",
            "BSCE",
            "BSEE",
            "BSCHEM"});
            this.cb_department.Location = new System.Drawing.Point(234, 31);
            this.cb_department.Margin = new System.Windows.Forms.Padding(4);
            this.cb_department.Name = "cb_department";
            this.cb_department.Size = new System.Drawing.Size(196, 28);
            this.cb_department.TabIndex = 23;
            this.cb_department.Text = "BSCPE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(231, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Department:";
            // 
            // cb_college
            // 
            this.cb_college.FormattingEnabled = true;
            this.cb_college.Items.AddRange(new object[] {
            "COEA",
            "CPAD",
            "CAS",
            "CHK"});
            this.cb_college.Location = new System.Drawing.Point(13, 30);
            this.cb_college.Margin = new System.Windows.Forms.Padding(4);
            this.cb_college.Name = "cb_college";
            this.cb_college.Size = new System.Drawing.Size(196, 28);
            this.cb_college.TabIndex = 21;
            this.cb_college.Text = "COEA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "College:";
            // 
            // cb_class
            // 
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(459, 32);
            this.cb_class.Margin = new System.Windows.Forms.Padding(4);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(196, 28);
            this.cb_class.TabIndex = 20;
            this.cb_class.Text = "test123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(456, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Class Code:";
            // 
            // lbl_student_id_search
            // 
            this.lbl_student_id_search.AutoSize = true;
            this.lbl_student_id_search.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_student_id_search.Location = new System.Drawing.Point(456, 66);
            this.lbl_student_id_search.Name = "lbl_student_id_search";
            this.lbl_student_id_search.Size = new System.Drawing.Size(107, 17);
            this.lbl_student_id_search.TabIndex = 11;
            this.lbl_student_id_search.Text = "Student ID:";
            // 
            // tb_student_id_search
            // 
            this.tb_student_id_search.Location = new System.Drawing.Point(459, 92);
            this.tb_student_id_search.Name = "tb_student_id_search";
            this.tb_student_id_search.Size = new System.Drawing.Size(196, 27);
            this.tb_student_id_search.TabIndex = 10;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_back.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(22, 569);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(226, 45);
            this.btn_back.TabIndex = 9;
            this.btn_back.Text = "BACK";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.Aquamarine;
            this.btn_refresh.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(22, 129);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(226, 45);
            this.btn_refresh.TabIndex = 6;
            this.btn_refresh.Text = "REFRESH";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_delete_student
            // 
            this.btn_delete_student.BackColor = System.Drawing.Color.DeepPink;
            this.btn_delete_student.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_student.Location = new System.Drawing.Point(22, 181);
            this.btn_delete_student.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete_student.Name = "btn_delete_student";
            this.btn_delete_student.Size = new System.Drawing.Size(226, 45);
            this.btn_delete_student.TabIndex = 8;
            this.btn_delete_student.Text = "DELETE STUDENTS";
            this.btn_delete_student.UseVisualStyleBackColor = false;
            this.btn_delete_student.Click += new System.EventHandler(this.btn_delete_student_Click);
            // 
            // btn_add_student
            // 
            this.btn_add_student.BackColor = System.Drawing.Color.Lime;
            this.btn_add_student.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_student.Location = new System.Drawing.Point(22, 22);
            this.btn_add_student.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add_student.Name = "btn_add_student";
            this.btn_add_student.Size = new System.Drawing.Size(226, 45);
            this.btn_add_student.TabIndex = 0;
            this.btn_add_student.Text = "ADD STUDENT";
            this.btn_add_student.UseVisualStyleBackColor = false;
            this.btn_add_student.Click += new System.EventHandler(this.btn_add_class_Click);
            // 
            // btn_update_student
            // 
            this.btn_update_student.BackColor = System.Drawing.Color.HotPink;
            this.btn_update_student.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_student.Location = new System.Drawing.Point(22, 77);
            this.btn_update_student.Margin = new System.Windows.Forms.Padding(4);
            this.btn_update_student.Name = "btn_update_student";
            this.btn_update_student.Size = new System.Drawing.Size(226, 45);
            this.btn_update_student.TabIndex = 7;
            this.btn_update_student.Text = "UPDATE STUDENT";
            this.btn_update_student.UseVisualStyleBackColor = false;
            this.btn_update_student.Click += new System.EventHandler(this.btn_update_student_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_better_view);
            this.panel3.Controls.Add(this.btn_back);
            this.panel3.Controls.Add(this.btn_refresh);
            this.panel3.Controls.Add(this.btn_delete_student);
            this.panel3.Controls.Add(this.btn_add_student);
            this.panel3.Controls.Add(this.btn_update_student);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 626);
            this.panel3.TabIndex = 24;
            // 
            // btn_better_view
            // 
            this.btn_better_view.BackColor = System.Drawing.Color.Aquamarine;
            this.btn_better_view.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_better_view.Location = new System.Drawing.Point(22, 233);
            this.btn_better_view.Name = "btn_better_view";
            this.btn_better_view.Size = new System.Drawing.Size(226, 45);
            this.btn_better_view.TabIndex = 11;
            this.btn_better_view.Text = "BETTER";
            this.btn_better_view.UseVisualStyleBackColor = false;
            this.btn_better_view.Click += new System.EventHandler(this.btn_better_view_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_check_attendance);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(265, 556);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 70);
            this.panel4.TabIndex = 2;
            // 
            // btn_check_attendance
            // 
            this.btn_check_attendance.BackColor = System.Drawing.Color.Lime;
            this.btn_check_attendance.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check_attendance.Location = new System.Drawing.Point(617, 12);
            this.btn_check_attendance.Margin = new System.Windows.Forms.Padding(4);
            this.btn_check_attendance.Name = "btn_check_attendance";
            this.btn_check_attendance.Size = new System.Drawing.Size(226, 45);
            this.btn_check_attendance.TabIndex = 10;
            this.btn_check_attendance.Text = "CHECK ATTENDANCE";
            this.btn_check_attendance.UseVisualStyleBackColor = false;
            this.btn_check_attendance.Click += new System.EventHandler(this.btn_check_attendance_Click);
            // 
            // dgv_classes_lists
            // 
            this.dgv_classes_lists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_classes_lists.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_classes_lists.Location = new System.Drawing.Point(0, 0);
            this.dgv_classes_lists.Name = "dgv_classes_lists";
            this.dgv_classes_lists.RowHeadersWidth = 51;
            this.dgv_classes_lists.RowTemplate.Height = 24;
            this.dgv_classes_lists.Size = new System.Drawing.Size(856, 460);
            this.dgv_classes_lists.TabIndex = 0;
            this.dgv_classes_lists.Visible = false;
            this.dgv_classes_lists.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_classes_lists_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_classes_lists);
            this.panel2.Location = new System.Drawing.Point(265, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 27);
            this.panel2.TabIndex = 26;
            this.panel2.Visible = false;
            // 
            // flp_students
            // 
            this.flp_students.BackColor = System.Drawing.Color.White;
            this.flp_students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_students.Location = new System.Drawing.Point(265, 135);
            this.flp_students.Name = "flp_students";
            this.flp_students.Size = new System.Drawing.Size(856, 491);
            this.flp_students.TabIndex = 11;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 626);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.flp_students);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_classes_lists)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_search_student;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_student_id_search;
        private System.Windows.Forms.TextBox tb_student_id_search;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_delete_student;
        private System.Windows.Forms.Button btn_add_student;
        private System.Windows.Forms.Button btn_update_student;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_class;
        private System.Windows.Forms.Button btn_better_view;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_check_attendance;
        private System.Windows.Forms.DataGridView dgv_classes_lists;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flp_students;
        private System.Windows.Forms.ComboBox cb_school_year;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_semester;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_department;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_college;
        private System.Windows.Forms.Label label5;
    }
}