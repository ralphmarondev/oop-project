using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
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

        // constructor for passing data
        public UpdateStudentForm(string college, string department, string semester, string school_year, string class_enrolled)
        {
            InitializeComponent();

            cb_class.Text = class_enrolled;
            cb_college.Text = college;
            cb_department.Text = department;
            cb_semester.Text = semester;
            cb_school_year.Text = school_year;
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
            try
            {
                //string connection_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
                // id_number, last_name, first_name, address, contact_number, email, name_of_guardian,
                // college, department, semester, school_year, class_enrolled, total_presents, total_absents
                SqlCommand cmd = new SqlCommand("UPDATE " + cb_class.Text + " SET " +
                    "last_name = @last_name, " +
                    "first_name = @first_name, " +
                    "address = @address, " +
                    "contact_number = @contact_number, " +
                    "email = @email, " +
                    "name_of_guardian, " +
                    "college = @college, " +
                    "department = @department, " +
                    "semester = @semester, " +
                    "class_enrolled = @class_enrolled " +
                    "WHERE  id_number = @id_number", conn);

                cmd.Parameters.AddWithValue("@id_number", tb_id_number);
                cmd.Parameters.AddWithValue("@last_name", tb_last_name);
                cmd.Parameters.AddWithValue("@first_name", tb_name);
                cmd.Parameters.AddWithValue("@address", tb_address);
                cmd.Parameters.AddWithValue("@contact_number", tb_contact_number);
                cmd.Parameters.AddWithValue("@email", tb_email);
                cmd.Parameters.AddWithValue("@name_of_guardian", tb_name_of_guardian);
                cmd.Parameters.AddWithValue("@college", cb_college);
                cmd.Parameters.AddWithValue("@department", cb_department);
                cmd.Parameters.AddWithValue("@semester", cb_semester);
                cmd.Parameters.AddWithValue("@class_enrolled", cb_class);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(tb_id_number.Text + " information Updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
        }

        private void UpdateStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // autofill all of the fields
            //string table_name = "class_" + cb_class.Text;
            //string column_name = "first_name";
            //string id_number = tb_id_number.Text;
            //table_name = "class_test123";
            //column_name = "first_name";
            //tb_name.Text = DBTools.get_data_from_database(table_name, column_name, id_number);

            get_data_in_certain_column_from_database();

            tb_name.Text = first_name[0].ToString();
            tb_last_name.Text = last_name[0].ToString();
            tb_address.Text = address[0].ToString();
            tb_email.Text = email[0].ToString();
            tb_contact_number.Text = contact_number[0].ToString();
            tb_name_of_guardian.Text = name_of_guardian[0].ToString();

        }


        #region Get all data of a class for auto-fill
        /// <date-2023-06-10>
        /// 
        /// </date-2023-06-10>
        private ArrayList first_name = new ArrayList();
        private ArrayList last_name = new ArrayList();
        private ArrayList address = new ArrayList();
        private ArrayList email = new ArrayList();
        private ArrayList contact_number = new ArrayList();
        private ArrayList name_of_guardian = new ArrayList();

        private void get_data_in_certain_column_from_database()
        {
            string table_name = "class_" + cb_class.Text;
            string student_id = tb_id_number.Text;

            get_data_in_certain_column_from_database_helper(table_name, "first_name", student_id, 1);
            get_data_in_certain_column_from_database_helper(table_name, "last_name", student_id, 2);
            get_data_in_certain_column_from_database_helper(table_name, "address", student_id, 3);
            get_data_in_certain_column_from_database_helper(table_name, "email", student_id, 4);
            get_data_in_certain_column_from_database_helper(table_name, "contact_number", student_id, 5);
            get_data_in_certain_column_from_database_helper(table_name, "name_of_guardian", student_id, 6);

        }


        private void get_data_in_certain_column_from_database_helper(string table_name, string column_name, string id_number, int flag)
        {
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());

            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name + " WHERE id_number = '" + id_number + "';";
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
                                    first_name.Add(column_value1);
                                    MessageBox.Show(column_value1);
                                    break;
                                case 2:
                                    string column_value2 = reader.GetString(column_index);
                                    last_name.Add(column_value2);
                                    MessageBox.Show(column_value2);
                                    break;
                                case 3:
                                    string column_value3 = reader.GetString(column_index);
                                    address.Add(column_value3);
                                    MessageBox.Show(column_value3);
                                    break;
                                case 4:
                                    string column_value4 = reader.GetString(column_index);
                                    email.Add(column_value4);
                                    MessageBox.Show(column_value4);
                                    break;
                                case 5:
                                    string column_value5 = reader.GetString(column_index);
                                    contact_number.Add(column_value5);
                                    MessageBox.Show(column_value5);
                                    break;
                                case 6:
                                    string column_value6 = reader.GetString(column_index);
                                    name_of_guardian.Add(column_value6);
                                    MessageBox.Show(column_value6);
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
