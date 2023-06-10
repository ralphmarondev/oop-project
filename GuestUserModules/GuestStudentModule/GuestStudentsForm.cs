using StudentAttendanceManagementSystem.GuestUserModules.GuessUserDashBoard;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.GuestUserModules.GuestStudentModule
{
    public partial class GuestStudentsForm : Form
    {
        public GuestStudentsForm()
        {
            InitializeComponent();
        }

        private void GuestStudentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuessDashBoardForm guest_dashboard_form = new GuessDashBoardForm();

            guest_dashboard_form.Show();
            Hide();
        }
    }
}
