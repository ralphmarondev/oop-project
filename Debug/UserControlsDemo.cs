using System;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test
{
    public partial class UserControlsDemo : Form
    {
        public UserControlsDemo()
        {
            InitializeComponent();
        }

        #region Function to generate dynamic user controls
        public void generate_dynamic_user_control()
        {
            flowLayoutPanel1.Controls.Clear();

            MyUserControl[] list_items = new MyUserControl[5];

            // sample titles
            string[] title = { "Title 1", "Title 2", "Title 3", "Title 4", "Title 5" };
            // sample sub titles
            string[] sub_title = { "Sub title 1", "Sub title 2", "Sub title 3", "Sub title 4", "Sub title 5" };

            for (int i = 0; i < list_items.Length; i++)
            {
                // create and story every dynamic user control object to listitem array
                list_items[i] = new MyUserControl();
                list_items[i].Title = title[i];
                list_items[i].SubTitle = sub_title[i];

                // adding newly created dynamic user control to dynamic panel
                flowLayoutPanel1.Controls.Add(list_items[i]);

                list_items[i].Click += new System.EventHandler(this.UserControl_Click);
            }
        }

        #endregion


        #region User control click event
        private void UserControl_Click(object sender, EventArgs e)
        {
            // user control object to access controls used in it
            // like (title, and subtitle);
            MyUserControl obj = (MyUserControl)sender;

            lbl_title.Text = obj.Title;
            lbl_sub.Text = obj.SubTitle;
            show_panel();
        }

        #endregion


        #region Hide and show panel
        private void hide_panel()
        {
            panel1.Visible = false;
        }

        private void show_panel()
        {
            panel1.Visible = true;
        }

        #endregion

        private void UserControlsDemo_Load(object sender, EventArgs e)
        {
            generate_dynamic_user_control();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            hide_panel();
        }
    }
}
