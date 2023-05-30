using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Tools
{
    public class DBTools
    {
        // change this depending on the name of the server installed in your computer!!
        // TODO: later, save the connection string in a file then the program will just read it
        //  this will avoid the recompilation of the program in different computer for having different names.
        private static string connection_string = "Data Source=LAPTOP-T2HJFRJU\\SQLEXPRESS;Initial Catalog=StudentAttendanceManagementSystemDB;Integrated Security=True";
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
                    byte[] content = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
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
        public static void ReadFile(string filePath)
        {
            try
            {
                // Read all the text from the file
                string content = File.ReadAllText(filePath);

                Console.WriteLine("File content: " + content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
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

        private void generate_file()
        {
            // if file path is not specified, it will be saved in
            // bin/Debug folder :)
            string filePath = "db.txt";
            string content = "Hello, world!";

            DBTools.CreateFile(filePath);
            DBTools.ReadFile(filePath);
            DBTools.WriteToFile(filePath, content);
            //DBTools.ReadFile(filePath);
            //DBTools.DeleteFile(filePath);

        }
        #endregion

        #region TESTING PURPOSES
        public string table_name = "test123";
        #endregion

        #region OTHER TOOLS

        public static void IncrementAndInsertValue(string column_name, string table_name, string column_to_be_updated)
        {
            SqlConnection connection = new SqlConnection(get_connection_string());

            if (column_to_be_updated.ToLower().Equals("total_absents"))
            {
                MessageBox.Show("Updating total absents");
                try
                {
                    connection.Open();

                    // Retrieve the value from the database
                    string selectQuery = "SELECT " + column_to_be_updated + " FROM " + table_name + " WHERE " + column_name + " = 'Absent';";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    //string currentValue = selectCommand.ExecuteScalar().ToString();
                    int currentValue = int.Parse(selectCommand.ExecuteScalar().ToString());
                    // Increment the value
                    int incrementedValue = currentValue + 1;//int.Parse(currentValue) + 1;

                    // Convert the incremented value back to a string
                    // string newValue = incrementedValue.ToString();
                    //newValue = "2".ToString();

                    // Insert the updated value back into the database
                    string updateQuery = "UPDATE " + table_name + " SET " + column_to_be_updated + " = @newValue " + " WHERE " + column_name + " = 'Absent';";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@newValue", incrementedValue);
                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Absent count updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error incrementing and inserting value: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (column_to_be_updated == "total_presents")
            {
                MessageBox.Show("Updating total presents");
                try
                {
                    connection.Open();

                    // Retrieve the value from the database
                    string selectQuery = "SELECT " + column_to_be_updated + " FROM " + table_name + " WHERE " + column_name + " = 'Present';";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    //string currentValue = selectCommand.ExecuteScalar().ToString();
                    int currentValue = int.Parse(selectCommand.ExecuteScalar().ToString());
                    // Increment the value
                    int incrementedValue = currentValue + 1;//int.Parse(currentValue) + 1;

                    // Convert the incremented value back to a string
                    // string newValue = incrementedValue.ToString();
                    //newValue = "2".ToString();

                    // Insert the updated value back into the database
                    string updateQuery = "UPDATE " + table_name + " SET " + column_to_be_updated + " = @newValue " + " WHERE " + column_name + " = 'Present';";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@newValue", incrementedValue);
                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Present count updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error incrementing and inserting value: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        #endregion
    }
}
