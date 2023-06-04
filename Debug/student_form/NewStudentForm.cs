using StudentAttendanceManagementSystem.Test.student_form;
using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test
{
    public partial class NewStudentForm : Form
    {
        #region variables
        private ArrayList student_id_list = new ArrayList();
        private ArrayList student_name_list = new ArrayList();
        private ArrayList student_total_present_list = new ArrayList();
        private ArrayList student_total_absent_list = new ArrayList();
        private int size_list = 0;
        #endregion

        public NewStudentForm()
        {
            InitializeComponent();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            generate_dynamic_user_control();
            //try_one();
        }

        #region practice generating dynamic user controls
        private void try_one()
        {
            //ArrayList id_nums = new ArrayList();
            //id_nums.Add("ID 1");
            string[] st_id = { "Id 1", "ID 2", "ID 3" };
            string[] st_name = { "Name 1", "Name 2", "Name 3" };
            string[] st_tp = { "0", "0", "0" };
            string[] st_ta = { "1", "0", "1" };
            my_flowLayoutPanel1.Controls.Clear();

            NewStudentuserControl[] list_items = new NewStudentuserControl[3];

            try
            {
                for (int i = 0; i < list_items.Length; i++)
                {
                    // create and story every dynamic user control object to list item array
                    list_items[i] = new NewStudentuserControl();
                    list_items[i].StudentIDNumber = st_id[i];
                    list_items[i].StudentName = st_name[i];
                    list_items[i].StudentTotalPresent = st_tp[i];
                    list_items[i].StudentTotalAbsent = st_ta[i];

                    // adding newly created dynamic user control to dynamic panel
                    my_flowLayoutPanel1.Controls.Add(list_items[i]);

                    list_items[i].Click += new System.EventHandler(this.UserControl_Click);
                }
            }
            catch
            {
                generate_dynamic_user_control();
                Console.WriteLine("Me when I'm falling.");
            }
        }
        #endregion


        #region Function to generate dynamic user controls
        private void generate_dynamic_user_control()
        {

            generated_from_database();

            my_flowLayoutPanel1.Controls.Clear();

            NewStudentuserControl[] list_items = new NewStudentuserControl[size_list];

            try
            {
                for (int i = 0; i < list_items.Length; i++)
                {
                    // create and story every dynamic user control object to list item array
                    list_items[i] = new NewStudentuserControl();
                    list_items[i].StudentIDNumber = student_id_list[i].ToString();
                    list_items[i].StudentName = student_name_list[i].ToString();
                    //list_items[i].StudentTotalPresent = student_total_present_list[i].ToString();
                    //list_items[i].StudentTotalAbsent = student_total_absent_list[i].ToString();

                    // adding newly created dynamic user control to dynamic panel
                    my_flowLayoutPanel1.Controls.Add(list_items[i]);

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
            NewStudentuserControl obj = (NewStudentuserControl)sender;

            MessageBox.Show(obj.StudentIDNumber);
        }
        #endregion

        #region Get data from database
        private void generated_from_database()
        {
            student_id_list.Clear();
            student_name_list.Clear();
            student_total_present_list.Clear();
            student_total_absent_list.Clear();

            get_data_from_database("id_number", 1);
            get_data_from_database("last_name", 2);
            get_data_from_database("total_presents", 3);
            get_data_from_database("total_absents", 4);
        }

        private void get_data_from_database(string column_name, int flag)
        {
            // Get data from database 
            // string conn_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            string table_name = "class_test123"; //tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");


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
                                    student_id_list.Add(column_value);
                                    // MessageBox.Show(column_value);
                                    size_list++;
                                    break;
                                case 2:
                                    student_name_list.Add(column_value);
                                    //MessageBox.Show(column_value);
                                    break;
                                case 3:
                                    student_total_present_list.Add(column_value);
                                    // MessageBox.Show(column_value);
                                    break;
                                case 4:
                                    student_total_absent_list.Add(column_value);
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


        }

        #endregion

    }
}
