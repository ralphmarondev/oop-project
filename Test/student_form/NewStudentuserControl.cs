using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test.student_form
{
    public partial class NewStudentuserControl : UserControl
    {
        public NewStudentuserControl()
        {
            InitializeComponent();
        }


        #region Getter and Setter for labels
        private string student_id_number;
        private string student_name;
        private string student_total_present;
        private string student_total_absent;

        [Category("Custom Props")]
        public string StudentIDNumber
        {
            get { return student_id_number; }
            set { student_id_number = value; lbl_id_number.Text = value; }
        }

        [Category("Custom Props")]
        public string StudentName
        {
            get { return student_name; }
            set { student_name = value; lbl_name.Text = value; }
        }

        [Category("Custom Props")]
        public string StudentTotalPresent
        {
            get { return student_total_present; }
            set { student_total_present = value; lbl_total_present.Text = value; }
        }

        [Category("Custom Props")]
        public string StudentTotalAbsent
        {
            get { return student_total_absent; }
            set { student_total_absent = value; lbl_total_absents.Text = value; }
        }
        #endregion

        private void NewStudentuserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
