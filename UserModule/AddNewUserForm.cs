using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.UserModule
{
    public partial class AddNewUserForm : Form
    {
        public AddNewUserForm()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                //This is my insert query in which i am taking input from the user through windows forms
                //string Query = "insert into classes_table(class_code, class_name, class_semester, class_school_year) values" +
                //    "('" + tb_subject_code_add.Text + "','" + tb_subject_name_add.Text + "','" + cb_semester_add.Text + "','" + tb_school_year_add.Text + "');";
                string Query = "insert into Users (username, password) values ('" + tb_username.Text + "','" + tb_password.Text + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                SqlConnection MyConn2 = new SqlConnection(MyConnection2);
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
                MessageBox.Show("Error in saving new user: " + ex.Message);
                Console.WriteLine("ME WHEN I'M FALLING...");
            }
        }
    }
}
