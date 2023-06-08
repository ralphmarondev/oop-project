using StudentAttendanceManagementSystem.DashBoardModule;
using StudentAttendanceManagementSystem.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.UserModule
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DashBoardForm dbf = new DashBoardForm();

            dbf.Show();
            Hide();
        }

        private void btn_add_user_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#region Inserting the data in class_table
                ////This is my connection string i have assigned the database file address path
                //string MyConnection2 = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                ////This is my insert query in which i am taking input from the user through windows forms
                ////string Query = "insert into classes_table(class_code, class_name, class_semester, class_school_year) values" +
                ////  "('" + tb_subject_code_add.Text + "','" + tb_subject_name_add.Text + "','" + cb_semester_add.Text + "','" + tb_school_year_add.Text + "');";
                //string Query = "INSERT INTO Users (username, password) values ('" + tb_new_username.Text + "','" + tb_new_password.Text + "');";
                ////This is  MySqlConnection here i have created the object and pass my connection string.
                //SqlConnection MyConn2 = new SqlConnection(MyConnection2);
                ////This is command class which will handle the query and connection object.
                //SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                //SqlDataReader MyReader2;
                //MyConn2.Open();
                //MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                //MessageBox.Show("New user saved Successfully!");
                //MyConn2.Close();
                //#endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Hide();

            DashBoardForm dbf = new DashBoardForm();

            dbf.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_edit_user_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUserForm af = new AddNewUserForm();

            af.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditUserForm ef = new EditUserForm();

            ef.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUserForm df = new DeleteUserForm();

            df.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            DashBoardForm df = new DashBoardForm();

            df.Show();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            string table_name = "Users";
            try
            {
                //Display query
                string Query = "select * from " + table_name + ";";
                SqlConnection MyConn2 = new SqlConnection(DBTools.get_connection_string());
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                SqlDataAdapter MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.
                                                   // MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
