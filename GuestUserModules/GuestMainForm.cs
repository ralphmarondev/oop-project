using StudentAttendanceManagementSystem.GuestUserModules.GuessUserDashBoard;
using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.GuestUserModules
{
    public partial class GuestMainForm : Form
    {
        public GuestMainForm()
        {
            InitializeComponent();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            GuessDashBoardForm guess_dash_board = new GuessDashBoardForm();

            guess_dash_board.Show();
            Hide();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
