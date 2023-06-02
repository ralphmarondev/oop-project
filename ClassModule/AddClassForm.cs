using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.ClassModule
{
    public partial class AddClassForm : Form
    {
        public AddClassForm()
        {
            InitializeComponent();
        }

        private void btn_finish_add_Click(object sender, EventArgs e)
        {
            try
            {
                #region Inserting the data in class_table
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                //This is my insert query in which i am taking input from the user through windows forms
                string Query = "insert into classes_table(class_code, class_name, class_semester, class_school_year, class_department, class_college, total_meets) values" +
                    "('" + tb_subject_code_add.Text + "','" + tb_subject_name_add.Text + "','" + cb_semester_add.Text + "','" + tb_school_year_add.Text + "','" + tb_department.Text + "','" + tb_college.Text + "', 0);";
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
                #endregion


                #region Creating a new table using the name of the class created
                SqlConnection new_connection = new SqlConnection(MyConnection2);
                new_connection.Open();

                string table_name = "class_" + tb_subject_code_add.Text;//tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");
                // Execute your SQL query to create the table
                string query = "CREATE TABLE " + table_name + " (id_number VARCHAR(50), last_name VARCHAR(50), first_name VARCHAR(50), address VARCHAR(50), contact_number VARCHAR(50), name_of_guardian VARCHAR(50), college VARCHAR(50), department VARCHAR(50), semester VARCHAR(50), school_year VARCHAR(50), email VARCHAR(50), class_enrolled VARCHAR(50), total_presents INT, total_absents INT);";
                SqlCommand command = new SqlCommand(query, new_connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Table created successfully!");
                new_connection.Close();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Hide();
        }
    }
}
