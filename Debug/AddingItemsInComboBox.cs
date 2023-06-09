using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Debug
{
    public partial class AddingItemsInComboBox : Form
    {
        public AddingItemsInComboBox()
        {
            InitializeComponent();
        }

        private void btn_add_item_Click(object sender, EventArgs e)
        {
            // Assuming you have a ComboBox control named comboBox1

            // Method 1: Adding items individually
            //comboBox1.Items.Add("Item 1");
            //comboBox1.Items.Add("Item 2");
            //comboBox1.Items.Add("Item 3");

            //// Method 2: Adding items using an array
            //string[] items = { "Item A", "Item B", "Item C" };
            //comboBox1.Items.AddRange(items);

            //// Method 3: Adding items using a List
            //List<string> itemList = new List<string> { "Item X", "Item Y", "Item Z" };
            //comboBox1.Items.AddRange(itemList.ToArray());
            comboBox1.Items.Add(tb_item_to_add.Text);
            tb_item_to_add.Clear();
        }
    }
}
