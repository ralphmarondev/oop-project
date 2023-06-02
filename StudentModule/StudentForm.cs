﻿using StudentAttendanceManagementSystem.DashBoardModule;
using StudentAttendanceManagementSystem.ReportsModule;
using StudentAttendanceManagementSystem.StudentModule.UserControls;
using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.StudentModule
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                string class_code = "class_" + cb_class.Text;
                // string MyConnection2 = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
                //Display query
                string Query = "select * from " + class_code + ";";
                SqlConnection MyConn2 = new SqlConnection(DBTools.get_connection_string());
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For off-line connection we will use  MySqlDataAdapter class.
                SqlDataAdapter MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dgv_classes_lists.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.
                                                       // MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_class_Click(object sender, EventArgs e)
        {
            // string college, string department, string semester, string school_year, string class_enrolled
            AddStudentForm add_student_form = new AddStudentForm(cb_college.Text, cb_department.Text, cb_semester.Text, cb_school_year.Text, cb_class.Text);

            add_student_form.Show();
        }

        private void btn_update_student_Click(object sender, EventArgs e)
        {
            UpdateStudentForm update_student_form = new UpdateStudentForm(cb_college.Text, cb_department.Text, cb_semester.Text, cb_school_year.Text, cb_class.Text);

            update_student_form.Show();
        }

        private void btn_delete_student_Click(object sender, EventArgs e)
        {
            DeleteStudentForm delete_student_form = new DeleteStudentForm();

            delete_student_form.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DashBoardForm dash_board_form = new DashBoardForm();

            dash_board_form.Show();
            this.Hide();
        }

        private void dgv_classes_lists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region search student from database
        private ArrayList searched_student_name_list = new ArrayList();
        private ArrayList searched_student_total_absents = new ArrayList();
        private ArrayList searched_student_total_presents = new ArrayList();
        private int search_size_list = 0;

        private void btn_search_student_Click(object sender, EventArgs e)
        {
            #region Display searched students in a data grid view
            //string class_code = "class_" + cb_class.Text;
            //SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            //SqlCommand cmd = new SqlCommand("Select * from " + class_code + " where id_number = @id_number", conn);
            //conn.Open();
            //cmd.Parameters.AddWithValue("id_number", tb_student_id_search.Text);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dgv_classes_lists.DataSource = dt;
            #endregion

            string table_name = "class_" + cb_class.Text;
            string id_number = tb_student_id_search.Text;

            generate_searched_student_dynamic_user_control(table_name, id_number);

        }

        private void get_searched_student_from_db(string table_name, string id_number)
        {
            // searched_student_id_list.Clear();
            searched_student_name_list.Clear();
            searched_student_total_presents.Clear();
            searched_student_total_absents.Clear(); //class_test123

            // get_searched_student_from_database(table_name, "id_number", 1);
            get_searched_student_from_database("last_name", table_name, id_number, 1);
            // get_data_from_database(table_name, "last_name", 2);
            //get_data_from_database(table_name, "total_presents", 3);
            //get_data_from_database(table_name, "total_absents", 4);
        }

        private void get_searched_student_from_database(string column_name, string table_name, string id_number, int flag)
        {
            // Get data from database 
            // string conn_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            // string table_name = "classes_table"; //tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");

            #region try one
            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name + " WHERE id_number like '" + id_number + "';";
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
                                //case 1:
                                //    string column_value1 = reader.GetString(column_index);
                                //    student_id_list.Add(column_value1);
                                //    // MessageBox.Show(column_value);
                                //    search_size_list++;
                                //    break;
                                case 1:
                                    string column_value2 = reader.GetString(column_index);
                                    searched_student_name_list.Add(column_value2);
                                    search_size_list++;
                                    //MessageBox.Show(column_value);
                                    break;
                                    //case 3:
                                    //    //object result = cmd.ExecuteScalar();
                                    //    ////student_total_presents.Add(Convert.ToString(column_value.ToString()));
                                    //    //student_total_presents.Add(result.ToString());
                                    //    // MessageBox.Show(column_value);
                                    //    int int_value = Convert.ToInt32(cmd.ExecuteScalar());
                                    //    string string_value1 = int_value.ToString();
                                    //    student_total_presents.Add(string_value1);
                                    //    break;
                                    //case 4:
                                    //    //student_total_absents.Add(Convert.ToString(column_value.ToString()));
                                    //    //object result2 = cmd.ExecuteScalar();
                                    //    //student_total_absents.Add(result2.ToString());
                                    //    //MessageBox.Show(column_value);
                                    //    int int_value2 = Convert.ToInt32(cmd.ExecuteScalar());
                                    //    string string_value2 = int_value2.ToString();
                                    //    student_total_absents.Add(string_value2);
                                    //    break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found!");
                    }
                }
            }
            catch
            {

            }
            #endregion

        }

        private void generate_searched_student_dynamic_user_control(string table_name, string id_number)
        {
            search_size_list = 0;
            get_searched_student_from_db(table_name, id_number);

            flp_students.Controls.Clear();

            StudentUserControl[] list_items = new StudentUserControl[search_size_list];

            try
            {
                for (int i = 0; i < list_items.Length; i++)
                {
                    // create and story every dynamic user control object to list item array
                    list_items[i] = new StudentUserControl();
                    list_items[i].StudentIDNumber = id_number;
                    list_items[i].StudentName = searched_student_name_list[i].ToString();
                    //list_items[i].StudentTotalPresent = student_total_presents[i].ToString();
                    //list_items[i].StudentTotalAbsent = student_total_absents[i].ToString();

                    // adding newly created dynamic user control to dynamic panel
                    flp_students.Controls.Add(list_items[i]);

                    list_items[i].Click += new System.EventHandler(this.UserControl_Click);

                }
            }
            catch
            {
                Console.WriteLine("Me when I'm falling");
            }
        }


        #endregion

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // btn_refresh_Click(sender, e);
            btn_better_view_Click(sender, e);
        }

        private void btn_better_view_Click(object sender, EventArgs e)
        {
            string table_name = "class_" + cb_class.Text.ToString();
            //generate_dynamic_user_control(table_name);
            generate_dynamic_user_control(table_name);
        }


        #region Function to generate dynamic user controls
        private ArrayList student_id_list = new ArrayList();
        private ArrayList student_name_list = new ArrayList();
        private ArrayList student_total_absents = new ArrayList();
        private ArrayList student_total_presents = new ArrayList();
        private int size_list = 0;
        private void generate_dynamic_user_control(string table_name)
        {
            //string table_name = "class_test123";
            //string table_name = "class_" + cb_class.Text.ToString();
            generated_from_database(table_name);

            flp_students.Controls.Clear();

            StudentUserControl[] list_items = new StudentUserControl[size_list];

            try
            {
                for (int i = 0; i < list_items.Length; i++)
                {
                    // create and story every dynamic user control object to list item array
                    list_items[i] = new StudentUserControl();
                    list_items[i].StudentIDNumber = student_id_list[i].ToString();
                    list_items[i].StudentName = student_name_list[i].ToString();
                    //list_items[i].StudentTotalPresent = student_total_presents[i].ToString();
                    //list_items[i].StudentTotalAbsent = student_total_absents[i].ToString();

                    // adding newly created dynamic user control to dynamic panel
                    flp_students.Controls.Add(list_items[i]);

                    list_items[i].Click += new System.EventHandler(this.UserControl_Click);

                }
            }
            catch
            {
                Console.WriteLine("Me when I'm falling");
            }
        }
        #endregion

        #region Click Listener on user controls
        private void UserControl_Click(object sender, EventArgs e)
        {
            #region comment
            // user control object to access controls used in it
            // like (title, and subtitle);
            //MyClassUserControl obj = (MyClassUserControl)sender;

            //MessageBox.Show(obj.ClassName);

            ////lbl_title.Text = obj.Title;
            ////lbl_sub.Text = obj.SubTitle;
            ////show_panel();
            #endregion

            StudentUserControl obj = (StudentUserControl)sender;

            MessageBox.Show(obj.StudentIDNumber);
        }
        #endregion

        #region Get data from database
        /// <summary>
        /// FIXME: get the name of class here, since each student
        /// is saved on a table named by the class name
        /// </summary>
        private void generated_from_database(string table_name)
        {
            student_id_list.Clear();
            student_name_list.Clear();
            student_total_presents.Clear();
            student_total_absents.Clear(); //class_test123

            get_data_from_database(table_name, "id_number", 1);
            get_data_from_database(table_name, "last_name", 2);
            get_data_from_database(table_name, "total_presents", 3);
            get_data_from_database(table_name, "total_absents", 4);
        }

        private void get_data_from_database(string table_name, string column_name, int flag)
        {
            // Get data from database 
            // string conn_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            // string table_name = "classes_table"; //tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");

            #region try one
            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name;
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
                                    student_id_list.Add(column_value1);
                                    // MessageBox.Show(column_value);
                                    size_list++;
                                    break;
                                case 2:
                                    string column_value2 = reader.GetString(column_index);
                                    student_name_list.Add(column_value2);
                                    //MessageBox.Show(column_value);
                                    break;
                                case 3:
                                    //object result = cmd.ExecuteScalar();
                                    ////student_total_presents.Add(Convert.ToString(column_value.ToString()));
                                    //student_total_presents.Add(result.ToString());
                                    // MessageBox.Show(column_value);
                                    int int_value = Convert.ToInt32(cmd.ExecuteScalar());
                                    string string_value1 = int_value.ToString();
                                    student_total_presents.Add(string_value1);
                                    break;
                                case 4:
                                    //student_total_absents.Add(Convert.ToString(column_value.ToString()));
                                    //object result2 = cmd.ExecuteScalar();
                                    //student_total_absents.Add(result2.ToString());
                                    //MessageBox.Show(column_value);
                                    int int_value2 = Convert.ToInt32(cmd.ExecuteScalar());
                                    string string_value2 = int_value2.ToString();
                                    student_total_absents.Add(string_value2);
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
            catch
            {

            }
            #endregion

        }

        #endregion

        private void btn_check_attendance_Click(object sender, EventArgs e)
        {
            AttendanceForm attendance_form = new AttendanceForm(cb_college.Text, cb_department.Text, cb_semester.Text, cb_school_year.Text, cb_class.Text);

            attendance_form.Show();
            Hide();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            ReportsForm rf = new ReportsForm();

            rf.Show();
            Hide();
        }
    }
}
