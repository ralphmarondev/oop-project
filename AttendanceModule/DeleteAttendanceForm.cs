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
                // added 2023-06-05 -> 8:23pm
                delete_one_from_presents(table_name, column_name);
                delete_one_from_absents(table_name, column_name);

                AttendanceTools.delete_one_from_total_meet_count("classes_table", table_name);
                MessageBox.Show("Delete one meet count from: '" + table_name + "'");

                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //// added 2023-06-05 -> 8:23pm
                //delete_one_from_presents(table_name, column_name);
                //delete_one_from_absents(table_name, column_name);

                //AttendanceTools.delete_one_from_total_meet_count("classes_table", table_name);

                MessageBox.Show("Attendance '" + cb_date.Text + "' Deleted successfully!");
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        #region Process in deleting a column [i.e. attendance]
        private void delete_one_from_presents(string table_name, string column_name)
        {
            string query = "update " + table_name + " set total_presents = total_presents - 1 where " + column_name + " = 'Present';";

            try
            {
                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Present count of class: '" + table_name + "' updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void delete_one_from_absents(string table_name, string column_name)
        {
            string query = "update " + table_name + " set total_absents = total_absents - 1 where " + column_name + " = 'Absent';";

            try
            {
                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Absents count of class: '" + table_name + "' updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion

        private void DeleteAttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
