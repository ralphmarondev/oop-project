using System;
using System.Collections;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Debug.MessageBoxes
{
    public partial class MessageBoxDemo : Form
    {
        public MessageBoxDemo()
        {
            InitializeComponent();
        }

        private void MessageBoxDemo_Load(object sender, EventArgs e)
        {
            ArrayList names = new ArrayList();

            names.Add("Maron");
            names.Add("Cazmir");

            string empty_fields = "Empty Fields:\n\n";

            foreach (var items in names)
            {
                empty_fields = empty_fields + items.ToString() + "\n";
            }

            MessageBox.Show(empty_fields, "Fields cannot be empty!");
        }
    }
}
