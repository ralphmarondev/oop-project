using StudentAttendanceManagementSystem.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.ReportsModule
{
    public partial class ViewAttendanceForm : Form
    {
        private string table_name;
        public ViewAttendanceForm()
        {
            InitializeComponent();
        }

        public ViewAttendanceForm(string table_name)
        {
            InitializeComponent();
            this.table_name = table_name;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            string date_of_attendance = "attendance_" + cb_date.Text;
            try
            {
                string conn = DBTools.get_connection_string();

                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string query = "select id_number, last_name, first_name, " + date_of_attendance + " from " + table_name;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_presents_Click(object sender, EventArgs e)
        {
            string date_of_attendance = "attendance_" + cb_date.Text;
            try
            {
                string conn = DBTools.get_connection_string();

                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string query = "select id_number, last_name, first_name, " + date_of_attendance + " from " + table_name + " where " + date_of_attendance + " = 'Present'";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_absents_Click(object sender, EventArgs e)
        {
            string date_of_attendance = "attendance_" + cb_date.Text;
            try
            {
                string conn = DBTools.get_connection_string();

                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string query = "select id_number, last_name, first_name, " + date_of_attendance + " from " + table_name + " where " + date_of_attendance + " = 'Absent'";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    string connectionString = "server=your_server_name;user=your_username;database=your_database_name;password=your_password;";

        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        string query = "SELECT LastName, IDNumber, Age FROM YourTableName";
        //        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
        //        {
        //            DataTable dataTable = new DataTable();
        //            adapter.Fill(dataTable);
        //            dataGridView1.DataSource = dataTable;
        //        }
        //    }
        //}

    }
}
