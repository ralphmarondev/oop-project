using StudentAttendanceManagementSystem.GuestUserModules.GuestClassModule;
using StudentAttendanceManagementSystem.GuestUserModules.GuestReportsModule;
using StudentAttendanceManagementSystem.GuestUserModules.GuestStudentModule;
using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.GuestUserModules.GuessUserDashBoard
{
    public partial class GuessDashBoardForm : Form
    {
        public GuessDashBoardForm()
        {
            InitializeComponent();
        }

        private void GuessDashBoardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main_form = new MainForm();

            main_form.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main_form = new MainForm();

            main_form.Show();
            Hide();
        }

        private void btn_student_form_Click(object sender, EventArgs e)
        {
            GuestStudentsForm guest_student_form = new GuestStudentsForm();

            guest_student_form.Show();
            Hide();
        }

        private void btn_class_form_Click(object sender, EventArgs e)
        {
            GuestClassForm guest_classs_form = new GuestClassForm();

            guest_classs_form.Show();
            Hide();
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            GuestReportsForm guest_reports_form = new GuestReportsForm();

            guest_reports_form.Show();
            Hide();
        }
    }
}
