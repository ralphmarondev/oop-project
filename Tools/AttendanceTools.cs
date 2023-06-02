using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Tools
{
    public class AttendanceTools
    {
        #region old
        private static void UpdateAttendance(string column_name, string table_name)
        {
            SqlConnection connection = new SqlConnection(DBTools.get_connection_string());

            try
            {
                connection.Open();

                // Retrieve the records from the database
                string selectQuery = "SELECT id_number, total_absents, " + column_name + " FROM " + table_name + ";";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = selectCommand.ExecuteReader();

                // Iterate over the records
                while (reader.Read())
                {
                    //string id = reader.GetString("id_number");
                    //string attendance = reader.GetInt32("attendance");
                    //int absents = reader.GetInt32("absents");

                    //// Perform calculations and modifications
                    //int totalAbsents = attendance + absents;
                    //int updatedAbsents = totalAbsents + 1;

                    //// Update the database with the updated value
                    //string updateQuery = "UPDATE your_table_name SET absents = @updatedAbsents WHERE id = @id;";
                    //SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    //updateCommand.Parameters.AddWithValue("@updatedAbsents", updatedAbsents);
                    //updateCommand.Parameters.AddWithValue("@id", id);
                    //updateCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Attendance updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        public static void update_present(string table_name, string column_name)
        {
            try
            {
                string querry = "UPDATE " + table_name + " SET  total_presents =  total_presents + 1 WHERE " + column_name + " like 'Present'";

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

        public static void update_absent(string table_name, string column_name)
        {
            try
            {
                string querry = "UPDATE " + table_name + " SET  total_absents =  total_absents + 1 WHERE " + column_name + " like 'Absent'";

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

        public static void update_total_meet_count(string table_name, string class_code)
        {
            try
            {
                string querry = "UPDATE " + table_name + " SET  total_meets =  total_meets + 1 WHERE class_code like '" + class_code + "';";

                SqlConnection connection = new SqlConnection(DBTools.get_connection_string());
                SqlCommand cmd = new SqlCommand(querry, connection);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(class_code + " total meets count Updated Successfully!");

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

        public static bool is_eligible_for_drop_out()
        {
            return false;
        }

    }
}
