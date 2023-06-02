using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Tools
{
    public class DBTools
    {
        private static string computer_name = ReadFile("my_server.txt");
        // change this depending on the name of the server installed in your computer!!
        // TODO: later, save the connection string in a file then the program will just read it
        //  this will avoid the recompilation of the program in different computer for having different names.
        private static string connection_string = "Data Source= " + computer_name + "\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";

        // default type for creating column in database
        private static string default_type = "NVARCHAR(50)";





        #region GETTERS
        /// <summary>
        /// this will return the connection string, defined on the top of this file
        /// </summary>
        public static string get_connection_string()
        {
            return connection_string;
        }

        /// <summary>
        /// this will return the default type 'nvarchar(50)'
        /// </summary>
        public static string get_default_type()
        {
            return default_type;
        }
        #endregion

        #region READ, WRITE, TO A FILE [experimental]
        // Create a new file
        public static void CreateFile(string filePath)
        {
            try
            {
                // Create a file at the specified path
                using (FileStream fs = File.Create(filePath))
                {
                    // Optionally, you can write content to the file immediately after creating it
                    byte[] content = System.Text.Encoding.UTF8.GetBytes("Hello there, Ralph Maron Eda is here!");
                    fs.Write(content, 0, content.Length);
                }

                Console.WriteLine("File created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating file: " + ex.Message);
            }
        }

        // Read the contents of a file
        public static string ReadFile(string filePath)
        {
            string content = "";
            try
            {
                // Read all the text from the file
                content = File.ReadAllText(filePath);

                Console.WriteLine("File content: " + content);
                MessageBox.Show("File content:\n" + content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                MessageBox.Show("Error reading file: " + ex.Message);
            }
            return content;
        }

        // Write content to a file
        public static void WriteToFile(string filePath, string content)
        {
            try
            {
                // Write the specified content to the file, overwriting any existing content
                File.WriteAllText(filePath, content);

                Console.WriteLine("Content written to file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }

        // Delete a file
        public static void DeleteFile(string filePath)
        {
            try
            {
                // Delete the file if it exists
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("File deleted successfully!");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting file: " + ex.Message);
            }
        }
        #endregion

        #region TESTING PURPOSES
        public string table_name = "test123";
        #endregion

        #region OTHER TOOLS

        /// <summary>
        /// for attendance form
        /// </summary>
        public static void IncrementAndInsertValue(string column_name, string table_name, string column_to_be_updated, List<string> recordIds_absent)
        {
            List<int> incremented_values_to_be_inserted = new List<int>();

            int incremented_value;
            SqlConnection connection = new SqlConnection(get_connection_string());

            if (column_to_be_updated.ToLower().Equals("total_absents"))
            {
                MessageBox.Show("Updating total absents");
                try
                {
                    connection.Open();

                    // Retrieve the value from the database
                    string selectQuery = "SELECT " + column_to_be_updated + " FROM " + table_name + " WHERE " + column_name + " = 'Absent' AND id_number = @id;";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                    MessageBox.Show("INserting the values [count of absents] in a list");
                    foreach (var id in recordIds_absent)
                    {
                        incremented_value = 0;
                        selectCommand.Parameters.Clear();
                        //string currentValue = selectCommand.ExecuteScalar().ToString();
                        int currentValue = int.Parse(selectCommand.ExecuteScalar().ToString());
                        // Increment the value
                        incremented_value = currentValue + 1;//int.Parse(currentValue) + 1;
                        incremented_values_to_be_inserted.Add(incremented_value);
                        currentValue = 0;
                        #region comment
                        // Convert the incremented value back to a string
                        // string newValue = incrementedValue.ToString();
                        //newValue = "2".ToString();
                        //MessageBox.Show("Updating.. after incrementing value");
                        //// Insert the updated value back into the database
                        //string updateQuery = "UPDATE " + table_name + " SET " + column_to_be_updated + " = @newValue " + " WHERE " + column_name + " = 'Absent' AND id_number = @id;";
                        //SqlCommand updateCommand = new SqlCommand(updateQuery, connection);


                        //updateCommand.Parameters.AddWithValue("@newValue", incremented_value);
                        //updateCommand.Parameters.AddWithValue("@id", id);
                        //updateCommand.ExecuteNonQuery();
                        //updateCommand.Parameters.Clear();
                        #endregion
                        MessageBox.Show(incremented_value.ToString());

                    }
                    MessageBox.Show("Done");
                    MessageBox.Show("Updating count of absents in db");

                    updating_absents_count_in_db(recordIds_absent, incremented_values_to_be_inserted, table_name, column_name, column_to_be_updated);

                    MessageBox.Show("Absent count updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error incrementing absents and inserting value: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            #region else if
            //else if (column_to_be_updated.ToLower().Equals("total_presents"))
            //{
            //    MessageBox.Show("Updating total presents");
            //    try
            //    {
            //        connection.Open();
            //        foreach (var id_present in recordIds_present)
            //        {
            //            incremented_value = 0;
            //            // Retrieve the value from the database
            //            string selectQuery = "SELECT " + column_to_be_updated + " FROM " + table_name + " WHERE " + column_name + " = 'Present'  AND id_number = @id;";
            //            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            //            //string currentValue = selectCommand.ExecuteScalar().ToString();

            //            selectCommand.Parameters.Clear();
            //            selectCommand.Parameters.AddWithValue("@id", id_present);

            //            int currentValue = int.Parse(selectCommand.ExecuteScalar().ToString());
            //            // Increment the value
            //            incremented_value = currentValue + 1;//int.Parse(currentValue) + 1;
            //            currentValue = 0;
            //            // Convert the incremented value back to a string
            //            // string newValue = incrementedValue.ToString();
            //            //newValue = "2".ToString();

            //            // Insert the updated value back into the database
            //            string updateQuery = "UPDATE " + table_name + " SET " + column_to_be_updated + " = @newValue " + " WHERE " + column_name + " = 'Present' AND id_number = @id;";
            //            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

            //            updateCommand.Parameters.AddWithValue("@newValue", incremented_value);
            //            updateCommand.Parameters.AddWithValue("@id", id_present);
            //            updateCommand.ExecuteNonQuery();
            //            updateCommand.Parameters.Clear();
            //        }

            //        MessageBox.Show("Present count updated successfully!");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error incrementing presents and inserting value: " + ex.Message);
            //    }
            //    finally
            //    {
            //        incremented_value = 0;
            //        connection.Close();
            //    }
            //}
            #endregion
        }

        private static void updating_absents_count_in_db(List<string> recordIds, List<int> values_to_be_inserted, string table_name, string column_name, string column_name_to_be_updated)
        {
            // string connectionString = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(get_connection_string());

            try
            {
                connection.Open();

                string query = "UPDATE " + table_name + " SET " + column_name + " = @value WHERE " + column_name_to_be_updated + " = @id;";
                SqlCommand command = new SqlCommand(query, connection);

                //for (int i = 0; i < recordIds.Count; i++)
                //{
                //    command.Parameters.Clear();
                //    command.Parameters.AddWithValue("@value", values_to_be_inserted.ElementAt(i));
                //    command.Parameters.AddWithValue("@id", recordIds.ElementAt(i));
                //    //DBTools.IncrementAndInsert(table_name, column_name, id);
                //    command.ExecuteNonQuery();
                //}

                int i = 0;
                foreach (var id in recordIds)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@value", values_to_be_inserted[i]);
                    command.Parameters.AddWithValue("@id", id);
                    i++;
                    //DBTools.IncrementAndInsert(table_name, column_name, id);
                    command.ExecuteNonQuery();
                }

                //foreach (var id in recordIds)
                //{
                //    command.Parameters.Clear();
                //    command.Parameters.AddWithValue("@value", value);
                //    command.Parameters.AddWithValue("@id", id);
                //    //DBTools.IncrementAndInsert(table_name, column_name, id);
                //    command.ExecuteNonQuery();
                //}

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




        /// <summary>
        /// this is used in attendance form
        /// </summary>
        public static void IncrementAndInsert(string table_name, string column_name, string id_number)
        {
            SqlConnection connection = new SqlConnection(get_connection_string());

            try
            {
                connection.Open();

                // Retrieve the value from the database
                string selectQuery = "SELECT " + column_name + " FROM " + table_name + " WHERE id_number = @id;";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@id", id_number);
                int currentValue = Convert.ToInt32(selectCommand.ExecuteScalar());

                // Increment the retrieved value by 1
                int incrementedValue = currentValue + 1;

                // Update the database with the incremented value
                string updateQuery = "UPDATE " + table_name + " SET " + column_name + " = @incrementedValue WHERE id_number = @id;";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@incrementedValue", incrementedValue);
                updateCommand.Parameters.AddWithValue("@id", id_number);
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


        #endregion

        #region backup
        //public static void IncrementAndInsertValue(string column_name, string table_name, string column_to_be_updated)
        //{
        //    List<string> recordIds_present = new List<string>();
        //    recordIds_present.Add("21-21800");

        //    int incremented_value = 0;
        //    SqlConnection connection = new SqlConnection(get_connection_string());

        //    if (column_to_be_updated.ToLower().Equals("total_absents"))
        //    {
        //        MessageBox.Show("Updating total absents");
        //        try
        //        {
        //            connection.Open();

        //            // Retrieve the value from the database
        //            string selectQuery = "SELECT " + column_to_be_updated + " FROM " + table_name + " WHERE " + column_name + " = 'Absent';";
        //            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
        //            //string currentValue = selectCommand.ExecuteScalar().ToString();
        //            int currentValue = int.Parse(selectCommand.ExecuteScalar().ToString());
        //            // Increment the value
        //            incremented_value = currentValue + 1;//int.Parse(currentValue) + 1;
        //            currentValue = 0;
        //            // Convert the incremented value back to a string
        //            // string newValue = incrementedValue.ToString();
        //            //newValue = "2".ToString();

        //            // Insert the updated value back into the database
        //            string updateQuery = "UPDATE " + table_name + " SET " + column_to_be_updated + " = @newValue " + " WHERE " + column_name + " = 'Absent' AND id_number = @id;";
        //            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

        //            foreach (var id in recordIds_present)
        //            {
        //                updateCommand.Parameters.AddWithValue("@newValue", incremented_value);
        //                updateCommand.Parameters.AddWithValue("@id", id);
        //                updateCommand.ExecuteNonQuery();
        //            }
        //            MessageBox.Show("Absent count updated successfully!");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error incrementing absents and inserting value: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    else if (column_to_be_updated.ToLower().Equals("total_presents"))
        //    {
        //        MessageBox.Show("Updating total presents");
        //        try
        //        {
        //            connection.Open();

        //            // Retrieve the value from the database
        //            string selectQuery = "SELECT " + column_to_be_updated + " FROM " + table_name + " WHERE " + column_name + " = 'Present'  AND id_number = @id;";
        //            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
        //            //string currentValue = selectCommand.ExecuteScalar().ToString();


        //            int currentValue = int.Parse(selectCommand.ExecuteScalar().ToString());
        //            // Increment the value
        //            incremented_value = currentValue + 1;//int.Parse(currentValue) + 1;
        //            currentValue = 0;
        //            // Convert the incremented value back to a string
        //            // string newValue = incrementedValue.ToString();
        //            //newValue = "2".ToString();

        //            // Insert the updated value back into the database
        //            string updateQuery = "UPDATE " + table_name + " SET " + column_to_be_updated + " = @newValue " + " WHERE " + column_name + " = 'Present' AND id_number = @id;";
        //            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

        //            foreach (var id_a in recordIds_present)
        //            {
        //                updateCommand.Parameters.AddWithValue("@newValue", incremented_value);
        //                updateCommand.Parameters.AddWithValue("@id", id_a);
        //                updateCommand.ExecuteNonQuery();
        //            }

        //            MessageBox.Show("Present count updated successfully!");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error incrementing presents and inserting value: " + ex.Message);
        //        }
        //        finally
        //        {
        //            incremented_value = 0;
        //            connection.Close();
        //        }
        //    }
        //}

        #endregion

        #region Student Form tools

        #endregion

        #region Attendance Form tools
        // selecting all students having 20% absents
        // select * from class_test123 where total_absents = (select total_meets from classes_table where class_code like 'test123') * (20 / 100)

        public static void select_all_student_with_20_percent_absents()
        {

        }

        #endregion
    }
}
