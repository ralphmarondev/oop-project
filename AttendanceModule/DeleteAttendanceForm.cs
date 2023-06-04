using StudentAttendanceManagementSystem.Tools;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.AttendanceModule
{
    public partial class DeleteAttendanceForm : Form
    {
        public DeleteAttendanceForm()
        {
            InitializeComponent();
        }

        // for passing data from attendance form
        public DeleteAttendanceForm(string table_name, string column_name)
        {
            InitializeComponent();

            cb_class.Text = table_name;
            cb_date.Text = column_name;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string table_name = "class_" + cb_class.Text;
            string column_name = "attendance_" + cb_date.Text;
            // query to delete a column [i.e. attendance]
            string query = "alter table " + table_name + " drop column " + column_name;

            try
            {
                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Attendance '" + cb_date.Text + "' Deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void DeleteAttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
