﻿using StudentAttendanceManagementSystem.DashBoardModule;
using StudentAttendanceManagementSystem.StudentModule;
using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.ClassModule
{
    public partial class ClassForm : Form
    {
        #region variables
        ArrayList class_code_list = new ArrayList();
        ArrayList class_name_list = new ArrayList();
        ArrayList class_semester_list = new ArrayList();
        ArrayList class_school_year_list = new ArrayList();
        private int size_list = 0;
        #endregion

        public ClassForm()
        {
            InitializeComponent();
        }

        private void btn_add_class_Click(object sender, EventArgs e)
        {
            AddClassForm add_class_form = new AddClassForm();

            add_class_form.Show();
        }

        private void btn_update_class_Click(object sender, EventArgs e)
        {
            UpdateClassForm update_class_form = new UpdateClassForm();

            update_class_form.Show();
        }

        private void btn_delete_class_Click(object sender, EventArgs e)
        {
            DeleteClassForm delete_class_form = new DeleteClassForm();

            delete_class_form.Show();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //Display query
            //    string Query = "select * from classes_table;";
            //    SqlConnection MyConn2 = new SqlConnection(DBTools.get_connection_string());
            //    SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
            //    //  MyConn2.Open();
            //    //For offline connection we weill use  MySqlDataAdapter class.
            //    SqlDataAdapter MyAdapter = new SqlDataAdapter();
            //    MyAdapter.SelectCommand = MyCommand2;
            //    DataTable dTable = new DataTable();
            //    MyAdapter.Fill(dTable);
            //    dgv_classes_lists.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.
            //                                           // MyConn2.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DashBoardForm dash_board_form = new DashBoardForm();

            dash_board_form.Show();
            this.Hide();
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            // btn_refresh_Click(sender, e);
            generate_dynamic_user_control();
        }

        #region search functionality
        // ArrayList searched_class_code_list = new ArrayList();
        ArrayList searched_class_name_list = new ArrayList();
        ArrayList searched_class_semester_list = new ArrayList();
        ArrayList searched_class_school_year_list = new ArrayList();
        private int size_searched_list = 0;

        private void btn_search_class_Click(object sender, EventArgs e)
        {
            #region Search and store in data grid view
            //SqlConnection conn = new SqlConnection("Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("Select * from classes_table where class_code = @class_code", conn);
            //conn.Open();
            //cmd.Parameters.AddWithValue("class_code", tb_class_code_search.Text);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dgv_classes_lists.DataSource = dt;
            #endregion

            string class_code = tb_class_code_search.Text;
            generate_searched_class_user_control(class_code);
            class_code = "";
        }

        private void get_data_from_database(string class_code)
        {
            searched_class_name_list.Clear();
            searched_class_semester_list.Clear();
            searched_class_school_year_list.Clear();

            get_searched_data_from_database("class_name", class_code, 1);
            get_searched_data_from_database("class_semester", class_code, 2);
            get_searched_data_from_database("class_school_year", class_code, 3);
        }

        private void get_searched_data_from_database(string column_name, string class_code, int flag)
        {
            size_searched_list = 0;
            // Get data from database 
            // string conn_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            string table_name = "classes_table"; //tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");

            #region try one
            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name.ToString() + " WHERE class_code like '" + class_code + "';";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal(column_name);
                        while (reader.Read())
                        {
                            string column_value = reader.GetString(column_index);
                            switch (flag)
                            {
                                case 1:
                                    searched_class_name_list.Add(column_value);
                                    // MessageBox.Show(column_value);
                                    size_searched_list++;
                                    break;
                                case 2:
                                    searched_class_semester_list.Add(column_value);
                                    //MessageBox.Show(column_value);
                                    break;
                                case 3:
                                    searched_class_school_year_list.Add(column_value);
                                    // MessageBox.Show(column_value);
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

        private void generate_searched_class_user_control(string class_code)
        {
            get_data_from_database(class_code);
            #region try one
            //generate_searched_from_db();

            //flowLayoutPanel1.Controls.Clear();

            //MyClassUserControl[] list_items = new MyClassUserControl[size_list];

            //try
            //{
            //    for (int i = 0; i < list_items.Length; i++)
            //    {
            //        // create and story every dynamic user control object to list item array
            //        list_items[i] = new MyClassUserControl();
            //        list_items[i].ClassCode = class_code_list[i].ToString();
            //        list_items[i].ClassName = class_name_list[i].ToString();
            //        list_items[i].ClassSemester = class_semester_list[i].ToString();
            //        list_items[i].ClassSchoolYear = class_school_year_list[i].ToString();

            //        // adding newly created dynamic user control to dynamic panel
            //        flowLayoutPanel1.Controls.Add(list_items[i]);

            //        list_items[i].Click += new System.EventHandler(this.UserControl_Click);
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("When I'm falling");
            //}
            #endregion

            flowLayoutPanel1.Controls.Clear();

            MyClassUserControl[] list_items = new MyClassUserControl[size_searched_list];

            try
            {
                for (int i = 0; i < list_items.Length; i++)
                {
                    // create and story every dynamic user control object to list item array
                    list_items[i] = new MyClassUserControl();
                    list_items[i].ClassCode = class_code;
                    list_items[i].ClassName = searched_class_name_list[i].ToString();
                    list_items[i].ClassSemester = searched_class_semester_list[i].ToString();
                    list_items[i].ClassSchoolYear = searched_class_school_year_list[i].ToString();

                    // adding newly created dynamic user control to dynamic panel
                    flowLayoutPanel1.Controls.Add(list_items[i]);

                    list_items[i].Click += new System.EventHandler(this.UserControl_Click);
                }
            }
            catch
            {
                Console.WriteLine("Me when I'm falling...");
            }

        }
        #endregion

        #region Function to generate dynamic user controls
        public void generate_dynamic_user_control()
        {

            generated_from_database();

            flowLayoutPanel1.Controls.Clear();

            MyClassUserControl[] list_items = new MyClassUserControl[size_list];

            #region static list
            // sample titles
            string[] class_code = { "Title 1", "Title 2", "Title 3", "Title 4", "Title 5" };
            // sample sub titles
            string[] class_name = { "Sub title 1", "Sub title 2", "Sub title 3", "Sub title 4", "Sub title 5" };
            // sample titles
            string[] class_semester = { "Class Semester 1", "Class Semester 2", "Class Semester 3", "Class Semester 4", "Class Semester 5" };
            // sample sub titles
            string[] class_school_year = { "School Year 1", "School Year 2", "School Year 3", "School Year 4", "School Year 5" };
            #endregion

            try
            {
                for (int i = 0; i < list_items.Length; i++)
                {
                    // create and story every dynamic user control object to list item array
                    list_items[i] = new MyClassUserControl();
                    list_items[i].ClassCode = class_code_list[i].ToString();
                    list_items[i].ClassName = class_name_list[i].ToString();
                    list_items[i].ClassSemester = class_semester_list[i].ToString();
                    list_items[i].ClassSchoolYear = class_school_year_list[i].ToString();

                    // adding newly created dynamic user control to dynamic panel
                    flowLayoutPanel1.Controls.Add(list_items[i]);

                    list_items[i].Click += new System.EventHandler(this.UserControl_Click);
                }
            }
            catch
            {
                // me when i'm falling lol :)
            }
        }

        #endregion


        #region User control click event
        private void UserControl_Click(object sender, EventArgs e)
        {
            MyClassUserControl obj = (MyClassUserControl)sender;

            MessageBox.Show(obj.ClassName);
            // go to students form
            StudentForm student_form = new StudentForm();

            student_form.Show();
            Hide();
        }
        #endregion

        private void btn_show_classes_Click(object sender, EventArgs e)
        {
            generate_dynamic_user_control();
        }

        #region Get data from database
        private void generated_from_database()
        {
            class_code_list.Clear();
            class_name_list.Clear();
            class_semester_list.Clear();
            class_school_year_list.Clear();

            get_data_from_database("class_code", 1);
            get_data_from_database("class_name", 2);
            get_data_from_database("class_semester", 3);
            get_data_from_database("class_school_year", 4);
        }

        private void get_data_from_database(string column_name, int flag)
        {
            // Get data from database 
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            string table_name = "classes_table"; //tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");

            #region try on
            try
            {
                conn.Open();

                string query = "SELECT " + column_name + " FROM " + table_name.ToString();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal(column_name);
                        while (reader.Read())
                        {
                            string column_value = reader.GetString(column_index);
                            switch (flag)
                            {
                                case 1:
                                    class_code_list.Add(column_value);
                                    // MessageBox.Show(column_value);
                                    size_list++;
                                    break;
                                case 2:
                                    class_name_list.Add(column_value);
                                    //MessageBox.Show(column_value);
                                    break;
                                case 3:
                                    class_semester_list.Add(column_value);
                                    // MessageBox.Show(column_value);
                                    break;
                                case 4:
                                    class_school_year_list.Add(column_value);
                                    //MessageBox.Show(column_value);
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

    }
}
