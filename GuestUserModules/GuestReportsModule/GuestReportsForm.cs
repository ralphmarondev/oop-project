using StudentAttendanceManagementSystem.GuestUserModules.GuessUserDashBoard;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.GuestUserModules.GuestReportsModule
{
    public partial class GuestReportsForm : Form
    {
        public GuestReportsForm()
        {
            InitializeComponent();
        }

        private void GuestReportsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuessDashBoardForm guest_dashboard_form = new GuessDashBoardForm();

            guest_dashboard_form.Show();
            Hide();
        }
    }
}
