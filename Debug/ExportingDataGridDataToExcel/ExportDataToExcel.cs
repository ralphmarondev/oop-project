using StudentAttendanceManagementSystem.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Debug.ExportingDataGridDataToExcel
{
    public partial class ExportDataToExcel : Form
    {
        public ExportDataToExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string table_name = "class_test123";
            try
            {
                //Display query
                string Query = "select * from " + table_name + ";";
                SqlConnection MyConn2 = new SqlConnection(DBTools.get_connection_string());
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                SqlDataAdapter MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.
                                                   // MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            // solution explorer -> reference -> add reference -> microsoft excel ...
            DataObject copy_data = dataGridView1.GetClipboardContent();

            if (copy_data != null)
            {
                Clipboard.SetDataObject(copy_data);
            }
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();

            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlwbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;

            object miseddata = System.Reflection.Missing.Value;

            xlwbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)
                xlwbook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 0];

            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        }
    }
}
