using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test
{
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

        #region Getter and Setter for labels
        private string title;
        private string sub_title;

        [Category("Custom Props")]
        public string Title
        {
            get { return title; }
            set { title = value; lbl_title.Text = value; }
        }

        [Category("Custom Props")]
        public string SubTitle
        {
            get { return sub_title; }
            set { sub_title = value; lbl_sub.Text = value; }
        }

        #endregion


        #region Hover effect
        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(128, 255, 128); // change user control back color when mouse enter
        }

        private void MyUserControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(192, 255, 192); // reset user control back color when mouse leaves
        }
        #endregion
    }
}
