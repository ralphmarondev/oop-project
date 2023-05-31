using StudentAttendanceManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test
{
    public class IncrementingDBRecordHelper
    {

        public static void IncrementAndInsert(string id)
        {
            SqlConnection connection = new SqlConnection(DBTools.get_connection_string());

            try
            {
                connection.Open();

                // Retrieve the current value from the database using the provided ID
                string selectQuery = "SELECT total_absents FROM test_incrementing_data_table WHERE id = @id;";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@id", id);
                int currentValue = Convert.ToInt32(selectCommand.ExecuteScalar());

                // Increment the retrieved value by one
                int incrementedValue = currentValue + 1;

                // Update the database with the incremented value
                string updateQuery = "UPDATE test_incrementing_data_table SET total_absents = @incrementedValue WHERE id = @id;";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@incrementedValue", incrementedValue);
                updateCommand.Parameters.AddWithValue("@id", id);
                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Value incremented and updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error incrementing value: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private List<string> GetColumnValues(string columnName, string filterColumnName, string filterValue)
        {
            List<string> columnValues = new List<string>();

            SqlConnection connection = new SqlConnection(DBTools.get_connection_string());

            try
            {
                connection.Open();

                // Retrieve the values of the specified column based on the filter value
                string selectQuery = "SELECT " + columnName + " FROM your_table_name WHERE " + filterColumnName + " = @filterValue;";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@filterValue", filterValue);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //string value = reader.GetString(columnName); // I can't do it anymore 
                        //columnValues.Add(value);
                    }
                }

                MessageBox.Show("Column values retrieved successfully!");

                MessageBox.Show("Column values retrieved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving column values: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return columnValues;
        }


    }
}
