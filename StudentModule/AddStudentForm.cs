using StudentAttendanceManagementSystem.Tools;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.DashBoardModule
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            try
            {
                string table_name = "class_" + cb_class.Text;//tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");

                //This is my connection string i have assigned the database file address path
                // string MyConnection2 = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                //This is my insert query in which i am taking input from the user through windows forms
                string Query = "insert into " + table_name + " (id_number, last_name, first_name, address, contact_number, email, name_of_guardian, college, department, semester, school_year, class_enrolled, total_presents, total_absents) values" + "('" +
                    tb_id_number.Text + "','" +
                    tb_last_name.Text + "','" +
                    tb_first_name.Text + "','" +
                    tb_address.Text + "','" +
                    tb_contact_number.Text + "','" +
                    tb_email.Text + "','" +
                    tb_name_of_guardian.Text + "','" +
                    cb_college.Text + "','" +
                    cb_department.Text + "','" +
                    cb_semester.Text + "','" +
                    cb_school_year.Text + "','" +
                    cb_class.Text + "', '0', '0');";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                SqlConnection MyConn2 = new SqlConnection(DBTools.get_connection_string());
                //This is command class which will handle the query and connection object.
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                SqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                MessageBox.Show("Saved Successfully!");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
