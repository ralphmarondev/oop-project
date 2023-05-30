using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Test
{
    public partial class TestForm : Form
    {
        ArrayList list_of_absent = new ArrayList();

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            ArrayList last_names = new ArrayList();
            last_names.Add("Maron 1");
            last_names.Add("Maron 2");
            last_names.Add("Maron 3");
            last_names.Add("Maron 4");
            last_names.Add("Maron 5");
            last_names.Add("Maron 6");
            last_names.Add("Maron 7");
            last_names.Add("Maron 8");
            last_names.Add("Maron 9");
            last_names.Add("Maron 10");

            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();

                btn.Name = last_names[i].ToString();
                btn.Text = last_names[i].ToString();
                btn.Size = new Size(145, 52);

                flowLayoutPanel1.Controls.Add(btn);

                // adding click listener on buttons
                btn.Click += new EventHandler(this.on_btn_click);
            }
            Console.Write(list_of_absent);
        }

        private void on_btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Red;
            //            MessageBox.Show(btn.Name);
            list_of_absent.Add(btn.Name);

        }
    }
}
