using StudentAttendanceManagementSystem.DashBoardModule;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.UserModule
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DashBoardForm dbf = new DashBoardForm();

            dbf.Show();
            Hide();
        }
    }
}
