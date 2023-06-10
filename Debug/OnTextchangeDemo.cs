using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Debug
{
    public partial class OnTextchangeDemo : Form
    {
        public OnTextchangeDemo()
        {
            InitializeComponent();
        }

        private void tb_text_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(tb_text.Text);
        }
    }
}
