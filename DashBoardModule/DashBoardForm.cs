using StudentAttendanceManagementSystem.ClassModule;
using StudentAttendanceManagementSystem.StudentModule;
using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.DashBoardModule
{
    public partial class DashBoardForm : Form
    {
        public DashBoardForm()
        {
            InitializeComponent();
        }

        private void btn_class_form_Click(object sender, EventArgs e)
        {
            ClassForm class_form = new ClassForm();

            class_form.Show();
            this.Hide();
        }

        private void btn_student_form_Click(object sender, EventArgs e)
        {
            StudentForm student_form = new StudentForm();

            student_form.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main_form = new MainForm();

            main_form.Show();
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_attendance_form_Click(object sender, EventArgs e)
        {
            AttendanceForm attendance_form = new AttendanceForm();

            attendance_form.Show();
            this.Hide();
        }

        private void gb_check_attendance_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_chck_attndce_Click(object sender, EventArgs e)
        {
            // go to attendance form
            MessageBox.Show("Shortcut to go to checking attendance.");
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            ReportsModule.ReportsForm rf = new ReportsModule.ReportsForm();

            rf.Show();
            Hide();
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            UserModule.UserForm uf = new UserModule.UserForm();

            uf.Show();
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shortcut to view students");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shortcut to generate reports");
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("Name of the current user will appear here!");
        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {
            //AttendanceTools.select_all_that_have_20_percent_absent_from_database("test123");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("selecting all that have 20 percent absent from database");
            AttendanceTools.select_all_that_have_20_percent_absent_from_database("test123");
        }

        // 2023-06-09
        #region Selecting top 3 classes, will be placed on dashboard form
        private ArrayList top_three_class_code = new ArrayList();
        // private ArrayList top_three_class_names = new ArrayList();

        private void select_top_three_classes_in_database_to_be_putted_on_dashboard_form(string column_name)
        {
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            string table_name = "classes_table"; //tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");

            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name.ToString();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal(column_name);
                        while (reader.Read())
                        {
                            string column_value = reader.GetString(column_index);
                            top_three_class_code.Add(column_value);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        #endregion


    }
}
