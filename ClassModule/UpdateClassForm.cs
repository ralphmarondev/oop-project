using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.ClassModule
{
    public partial class UpdateClassForm : Form
    {
        public UpdateClassForm()
        {
            InitializeComponent();
        }

        private void btn_finish_add_Click(object sender, EventArgs e)
        {
            try
            {
                string connection_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection_string);
                SqlCommand cmd = new SqlCommand("UPDATE classes_table SET class_name = @class_name, class_semester = @class_semester, class_school_year = @class_school_year WHERE class_code = @class_code", conn);

                cmd.Parameters.AddWithValue("@class_code", tb_subject_code_add.Text);
                cmd.Parameters.AddWithValue("@class_name", tb_subject_name_add.Text);
                cmd.Parameters.AddWithValue("@class_semester", cb_semester_add.Text);
                cmd.Parameters.AddWithValue("@class_school_year", tb_school_year_add.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
        }

        private void UpdateClassForm_Load(object sender, EventArgs e)
        {
            #region 
            // coming soon...
            #endregion
            //try //(class_code, class_name, class_semester, class_school_year
            //{
            //    //This is my connection string i have assigned the database file address path
            //    string MyConnection2 = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
            //    //This is my update query in which i am taking input from the user through windows forms and update the record.
            //    string Query = "update classes_table set class_code='" + this.tb_subject_code_add.Text + "',class_name='" + this.tb_subject_name_add.Text +
            //        "', class_semester = '" + this.cb_semester_add.Text + "', class_school_year = '" + tb_school_year_add.Text + "'; ";
            //    //This is  MySqlConnection here i have created the object and pass my connection string.
            //    SqlConnection MyConn2 = new SqlConnection(MyConnection2);
            //    SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
            //    SqlDataReader MyReader2;
            //    MyConn2.Open();
            //    MyReader2 = MyCommand2.ExecuteReader();
            //    MessageBox.Show("Data Updated");
            //    while (MyReader2.Read())
            //    {
            //    }
            //    MyConn2.Close();//Connection closed here
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
