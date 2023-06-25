﻿using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections;
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

            string subject_code = tb_subject_code_add.Text;
            string subject_name = tb_subject_name_add.Text;
            string semester = cb_semester_add.Text;
            string school_year = tb_school_year_add.Text;
            string department = tb_department.Text;
            string college = tb_college.Text;

            ArrayList names = new ArrayList();
            names.Clear();
            string empty_fields = "Empty Fields:\n\n";

            if ((subject_code != "" && subject_name != "" && semester != "" &&
                school_year != "" && department != "" && college != ""))
            {
                if (!(is_class_exist_in_class_database()))
                {
                    add_class();
                    MessageBox.Show("Class saved successfully!");
                }
                else
                {
                    MessageBox.Show("Class already exists.", "Failed!");
                }
            }
            else
            {
                if (subject_code == "")
                {
                    names.Add("Subject Code");
                }
                if (subject_name == "")
                {
                    names.Add("Subject Name");
                }
                if (semester == "")
                {
                    names.Add("Semester");
                }
                if (school_year == "")
                {
                    names.Add("School Year");
                }
                if (department == "")
                {
                    names.Add("Department");
                }
                if (college == "")
                {
                    names.Add("College");
                }

                foreach (var items in names)
                {
                    empty_fields = empty_fields + items.ToString() + "\n";
                }

                MessageBox.Show(empty_fields, "Adding class failed!");
            }


            Hide();
        }


        private bool is_class_exist_in_class_database()
        {
            // Create the MySqlConnection object
            using (SqlConnection connection = new SqlConnection(DBTools.get_connection_string()))
            {
                try
                {
                    connection.Open();

                    // Prepare the SQL query
                    string query = "SELECT COUNT(*) FROM classes_table WHERE class_code = @value"; // Replace with your table and column names
                    SqlCommand command = new SqlCommand(query, connection);

                    // Set the parameter value
                    command.Parameters.AddWithValue("@value", tb_subject_code_add.Text); // Replace with the value you want to search

                    // Execute the query and get the result
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Check if the record exists
                    if (count > 0)
                    {
                        Console.WriteLine("The record already exists in the database.");
                        return true;
                    }
                    else
                    {
                        // Add the record to the database
                        // ...
                        Console.WriteLine("The record does not exist in the database and can be added.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                return false;
            }
        }


        private void add_class()
        {
            try
            {
                #region Inserting the data in class_table
                //This is my insert query in which i am taking input from the user through windows forms
                string Query = "insert into classes_table(class_code, class_name, class_semester, class_school_year, class_department, class_college, total_meets) values" +
                    "('" + tb_subject_code_add.Text + "','" + tb_subject_name_add.Text + "','" + cb_semester_add.Text + "','" + tb_school_year_add.Text + "','" + tb_department.Text + "','" + tb_college.Text + "', 0);";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                SqlConnection MyConn2 = new SqlConnection(DBTools.get_connection_string());
                //This is command class which will handle the query and connection object.
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                SqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                Console.WriteLine("Saved Successfully!");
                while (MyReader2.Read())
                {
                }

                MyConn2.Close();
                #endregion


                #region Creating a new table using the name of the class created
                SqlConnection new_connection = new SqlConnection(DBTools.get_connection_string());
                new_connection.Open();

                string table_name = "class_" + tb_subject_code_add.Text;//tb_subject_code_add.Text.Replace("-", "_") + "_" + tb_subject_name_add.Text + "_" + cb_semester_add.Text + "_" + tb_school_year_add.Text.Replace("-", "_");
                // Execute your SQL query to create the table
                string query = "CREATE TABLE " + table_name + " (id_number VARCHAR(50), last_name VARCHAR(50), first_name VARCHAR(50), address VARCHAR(50), contact_number VARCHAR(50), name_of_guardian VARCHAR(50), college VARCHAR(50), department VARCHAR(50), semester VARCHAR(50), school_year VARCHAR(50), email VARCHAR(50), class_enrolled VARCHAR(50), total_presents INT, total_absents INT, status VARCHAR(50));";
                SqlCommand command = new SqlCommand(query, new_connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Table created successfully!");
                new_connection.Close();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
