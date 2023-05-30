using StudentAttendanceManagementSystem.Tools;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.StudentModule
{
    public partial class UpdateStudentForm : Form
    {
        public UpdateStudentForm()
        {
            InitializeComponent();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                //string connection_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());

                #region basis from my other form
                //SqlCommand cmd = new SqlCommand("UPDATE classes_table SET class_name = @class_name, class_semester = @class_semester, class_school_year = @class_school_year WHERE class_code = @class_code", conn);

                //cmd.Parameters.AddWithValue("@class_code", tb_subject_code_add.Text);
                //cmd.Parameters.AddWithValue("@class_name", tb_subject_name_add.Text);
                //cmd.Parameters.AddWithValue("@class_semester", cb_semester_add.Text);
                //cmd.Parameters.AddWithValue("@class_school_year", tb_school_year_add.Text);

                //conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //MessageBox.Show("Updated Successfully!");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {

        }
    }
}
