using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.AttendanceModule
{
    public partial class UpdateAttendanceForm : Form
    {
        #region global variables
        // temporarily store presents and absents
        private ArrayList presents = new ArrayList();
        private ArrayList absents = new ArrayList();

        // final variable to store presents and absents
        private ArrayList final_present = new ArrayList();
        private ArrayList final_absent = new ArrayList();

        // store all the last names from database
        private ArrayList last_names = new ArrayList();
        #endregion

        public UpdateAttendanceForm()
        {
            InitializeComponent();
        }

        // constructor for passing data
        public UpdateAttendanceForm(string college, string department, string semester, string school_year, string class_enrolled, string date)
        {
            InitializeComponent();

            cb_class.Text = class_enrolled;
            cb_college.Text = college;
            cb_department.Text = department;
            cb_semester.Text = semester;
            cb_school_year.Text = school_year;
            cb_date.Text = date;
        }

        #region Update attendance on the date given
        private void btn_update_Click(object sender, System.EventArgs e)
        {
            #region Old
            //SqlConnection connection = new SqlConnection(DBTools.get_connection_string());

            //DateTime currentDate = DateTime.Now;
            //string current_date = "attendance_" + currentDate.ToString("yyyy_MM_dd");

            //string table_name = "class_" + cb_class.Text; ;
            //string column_name = current_date;

            //// all students, initially has a present value
            //// creating_new_column();
            //validate_student(table_name, column_name);

            //#region Inserting )absents
            //List<string> myRecordIds_absent = new List<string>();
            //foreach (var items in final_absent)
            //{
            //    myRecordIds_absent.Add(items.ToString());
            //}

            //string myValue_absent = "Absent";

            //InsertSameValueInRecords(myRecordIds_absent, myValue_absent, table_name, column_name, "last_name");

            //#endregion

            //#region Update present and absents in database
            //AttendanceTools.update_present(table_name, column_name);
            //AttendanceTools.update_absent(table_name, column_name);
            //string class_code = cb_class.Text;
            //AttendanceTools.update_total_meet_count("classes_table", class_code);

            //btn_refresh_Click(sender, e);
            #endregion

            string table_name = "class_" + cb_class.Text;
            string column_name = "attendance_" + cb_date.Text;
            //table_name = "class_test123";
            //column_name = "attendance_2023_06_04";

            // update attendance algorithm:
            // 1. set all the initial values to 'present'
            // 2. set the absents to 'absents'
            // 3. edit the count of absents and present
            // 4. done

            validate_student(table_name, column_name);

            #region Subtracting 1 from absent and present whatever is the status
            subract_one_from_total_presents(table_name, column_name);
            subtract_one_from_total_absents(table_name, column_name);
            #endregion

            #region Inserting absents
            List<string> myRecordIds_absent = new List<string>();
            foreach (var items in final_absent)
            {
                myRecordIds_absent.Add(items.ToString());
            }
            // setting all the fields to present initially
            InsertSameValueInAllRecords("Present", table_name, column_name);

            // updating absent in the database
            string myValue_absent = "Absent";

            InsertSameValueInRecords(myRecordIds_absent, myValue_absent, table_name, column_name, "last_name");

            #endregion

        }
        #endregion

        private void validate_student(string table_name, string column_name)
        {
            final_absent.Clear();
            //get_all_absents_in_database(table_name, column_name);
            string myValue = "Present";

            InsertSameValueInAllRecords(myValue, table_name, column_name);

            foreach (var items in absents)
            {
                foreach (var items2 in last_names)
                {
                    if ((items.ToString() == items2.ToString()) && !(final_absent.Contains(items.ToString())))
                    {
                        final_absent.Add(items);
                        MessageBox.Show(items.ToString(), "Absent");
                    }
                }
            }

            foreach (var items in final_absent)
            {
                foreach (var items2 in inital_absents)
                {
                    if (!(final_absent.Contains(items2.ToString())))
                    {
                        final_absent.Add(items);
                        MessageBox.Show(items.ToString(), "Absent");
                    }
                }
            }


            absents.Clear();
        }


        #region Inserting the same value in all of the rows in a column
        private void InsertSameValueInAllRecords(string value, string table_name, string column_name)
        {
            SqlConnection connection = new SqlConnection(DBTools.get_connection_string());

            try
            {
                connection.Open();

                string query = "UPDATE " + table_name + " SET " + column_name + " = @value;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();

                MessageBox.Show("Value inserted in all records successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting value in records: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion


        #region insert the same values in different records using their ids
        private void InsertSameValueInRecords(List<string> recordIds, string value, string table_name, string column_name, string column_name_to_be_updated)
        {
            SqlConnection connection = new SqlConnection(DBTools.get_connection_string());

            try
            {
                connection.Open();

                string query = "UPDATE " + table_name + " SET " + column_name + " = @value WHERE " + column_name_to_be_updated + " = @id;";
                SqlCommand command = new SqlCommand(query, connection);

                foreach (var id in recordIds)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@id", id);
                    //DBTools.IncrementAndInsert(table_name, column_name, id);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Value inserted in records successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting value in records: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion


        #region Get all the initial absents
        private ArrayList inital_absents = new ArrayList();
        private void get_all_absents_in_database(string table_name, string column_name)
        {
            string date_of_attendance = column_name;
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());

            try
            {
                MessageBox.Show("Getting all absents in database");
                conn.Open();

                string query = "SELECT last_name FROM " + table_name.ToString() + " WHERE " + date_of_attendance + " like 'Absent';";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal("last_name");
                        while (reader.Read())
                        {
                            string column_value = reader.GetString(column_index);
                            inital_absents.Add(column_value);
                            absents.Add(column_value);
                            MessageBox.Show(column_value);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found!");
                    }
                }
                MessageBox.Show("Done");
            }
            catch
            {
                Console.WriteLine("Me when I'm falling...");
            }
        }
        #endregion


        #region Subtract 1 from total absents
        private void subtract_one_from_total_absents(string table_name, string column_name)
        {
            /// TODO: implement this!
            string date_of_attendance = column_name;
            try
            {
                string querry = "UPDATE " + table_name + " SET total_absents =  total_absents - 1 WHERE " + date_of_attendance + " like 'Absent'";

                SqlConnection connection = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(querry, connection);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Absent count Updated Successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Done");
            }
        }

        #endregion


        #region Subtract 1 from total presents
        private void subract_one_from_total_presents(string table_name, string column_name)
        {
            string date_of_attendance = column_name;
            /// TODO: implement this!
            try
            {
                string querry = "UPDATE " + table_name + " SET total_presents =  total_presents - 1 WHERE " + date_of_attendance + " like 'Present'";

                SqlConnection connection = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(querry, connection);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Present count Updated Successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Done");
            }

        }
        #endregion

        #region Get all last names in the class
        private void get_all_last_names_in_database(string table_name)
        {
            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());

            try
            {
                conn.Open();

                string query = "SELECT last_name FROM " + table_name.ToString();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal("last_name");
                        while (reader.Read())
                        {
                            string column_value = reader.GetString(column_index);
                            last_names.Add(column_value);
                            MessageBox.Show(column_value);
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
                Console.WriteLine("Me when I'm falling...");
            }
        }
        #endregion


        #region Generating buttons programatically
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            //string current_date = DBTools.get_current_date();
            //cb_date.Text = "attendance_" + current_date;
            string table_name = "class_" + cb_class.Text;
            string column_name = "attendance_" + cb_date.Text.Replace("-", "_");

            get_all_absents_in_database(table_name, column_name);
            #region Remove all of the items in the array-lists if there is any
            absents.Clear();
            presents.Clear();
            final_absent.Clear();
            #endregion

            flowLayoutPanel1.Controls.Clear();

            SqlConnection conn = new SqlConnection(DBTools.get_connection_string());
            // string table_name = "class_" + cb_class.Text;
            //table_name = "class_test123";
            try
            {
                conn.Open();

                string query = "SELECT last_name FROM " + table_name.ToString();
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int column_index = reader.GetOrdinal("last_name");
                        int i = 0;
                        while (reader.Read())
                        {
                            string column_value = reader.GetString(column_index);
                            last_names.Add(column_value);
                            MessageBox.Show(column_value);
                            Button btn = new Button();

                            btn.Name = last_names[i].ToString();
                            btn.Text = last_names[i].ToString();
                            btn.Size = new Size(145, 52);
                            btn.BackColor = Color.White;

                            foreach (var items in inital_absents)
                            {
                                if (btn.Name == items.ToString())
                                {
                                    btn.BackColor = Color.Red;
                                    absents.Add(btn.Name);
                                    break;
                                }
                            }


                            flowLayoutPanel1.Controls.Add(btn);

                            btn.Click += new EventHandler(this.on_btn_click);
                            i++;
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


        #region Initial validation if present or absent
        void on_btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Red)
            {
                btn.BackColor = Color.White;
                absents.Remove(btn.Text);
            }
            else
            {
                btn.BackColor = Color.Red;
                absents.Add(btn.Text);
            }

        }
        #endregion

        private void UpdateAttendanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AttendanceForm af = new AttendanceForm();

            af.Show();
            Hide();
        }

        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            btn_refresh_Click(sender, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateAttendanceForm_Load(object sender, EventArgs e)
        {
            btn_refresh_Click(sender, e);
        }
    }
}
