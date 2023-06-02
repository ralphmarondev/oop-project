using StudentAttendanceManagementSystem.Tools;
using System;
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

        }
    }
}
