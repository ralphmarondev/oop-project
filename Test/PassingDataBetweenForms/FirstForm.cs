using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test.PassingDataBetweenForms
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SecondForm f2 = new SecondForm(tb_data.Text);

            f2.ShowDialog();
        }
    }
}
