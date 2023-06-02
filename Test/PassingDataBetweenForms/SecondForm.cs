using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test.PassingDataBetweenForms
{
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        public SecondForm(string data)
        {
            InitializeComponent();

            tb_data.Text = data;


        }

        private void btn_send_Click(object sender, EventArgs e)
        {

        }
    }
}
