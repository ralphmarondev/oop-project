using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
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
                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand("UPDATE classes_table SET class_name = @class_name, class_semester = @class_semester, class_school_year = @class_school_year, class_department = @class_department, class_college = @class_college WHERE class_code = @class_code", conn);

                cmd.Parameters.AddWithValue("@class_code", tb_subject_code.Text);
                cmd.Parameters.AddWithValue("@class_name", tb_subject_name.Text);
                cmd.Parameters.AddWithValue("@class_semester", cb_semester.Text);
                cmd.Parameters.AddWithValue("@class_school_year", tb_school_year.Text);
                cmd.Parameters.AddWithValue("@class_department", tb_department.Text);
                cmd.Parameters.AddWithValue("@class_college", tb_college.Text);

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

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                get_data_in_certain_column_from_database();
                tb_subject_name.Text = subject_name[0].ToString();
                tb_college.Text = subject_college[0].ToString();
                tb_department.Text = subject_college[0].ToString();
                cb_semester.Text = subject_semester[0].ToString();
                tb_school_year.Text = subject_school_year[0].ToString();

                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #region Get all data of a class for auto-fill
        /// <date-2023-06-10>
        /// 
        /// </date-2023-06-10>
        private ArrayList subject_name = new ArrayList();
        private ArrayList subject_semester = new ArrayList();
        private ArrayList subject_college = new ArrayList();
        private ArrayList subject_department = new ArrayList();
        private ArrayList subject_school_year = new ArrayList();

        private void get_data_in_certain_column_from_database()
        {
            string table_name = "classes_table";
            string subject_code = tb_subject_code.Text;

            get_data_in_certain_column_from_database_helper(table_name, "class_name", subject_code, 1);
            get_data_in_certain_column_from_database_helper(table_name, "class_semester", subject_code, 2);
            get_data_in_certain_column_from_database_helper(table_name, "class_college", subject_code, 3);
            get_data_in_certain_column_from_database_helper(table_name, "class_department", subject_code, 4);
            get_data_in_certain_column_from_database_helper(table_name, "class_school_year", subject_code, 5);


        }


        private void get_data_in_certain_column_from_database_helper(string table_name, string column_name, string subject_code, int flag)
        {
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());

            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name + " WHERE class_code = '" + subject_code + "';";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal(column_name);
                        while (reader.Read())
                        {
                            switch (flag)
                            {
                                case 1:
                                    string column_value1 = reader.GetString(column_index);
                                    subject_name.Add(column_value1);
                                    MessageBox.Show(column_value1);
                                    break;
                                case 2:
                                    string column_value2 = reader.GetString(column_index);
                                    subject_semester.Add(column_value2);
                                    MessageBox.Show(column_value2);
                                    break;
                                case 3:
                                    string column_value3 = reader.GetString(column_index);
                                    subject_college.Add(column_value3);
                                    MessageBox.Show(column_value3);
                                    break;
                                case 4:
                                    string column_value4 = reader.GetString(column_index);
                                    subject_department.Add(column_value4);
                                    MessageBox.Show(column_value4);
                                    break;
                                case 5:
                                    string column_value5 = reader.GetString(column_index);
                                    subject_school_year.Add(column_value5);
                                    MessageBox.Show(column_value5);
                                    break;
                            }

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
