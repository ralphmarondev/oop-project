using StudentAttendanceManagementSystem.GuestUserModules.GuessUserDashBoard;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.GuestUserModules.GuestClassModule
{
    public partial class GuestClassForm : Form
    {
        public GuestClassForm()
        {
            InitializeComponent();
        }

        private void GuestClassForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuessDashBoardForm guest_dashboard_form = new GuessDashBoardForm();

            guest_dashboard_form.Show();
            Hide();
        }
    }
}
