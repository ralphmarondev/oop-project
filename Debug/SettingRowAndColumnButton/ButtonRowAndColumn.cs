using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentAttendanceManagementSystem.Debug.SettingRowAndColumnButton
{
    public partial class ButtonRowAndColumn : Form
    {
        public ButtonRowAndColumn()
        {
            InitializeComponent();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (var items in last_names)
            //{
            //    Button btn = new Button();

            //    btn.Name = last_names[i].ToString();
            //    btn.Text = last_names[i].ToString();
            //    btn.Size = new Size(145, 52);
            //    btn.BackColor = Color.White;

            //    flowLayoutPanel1.Controls.Add(btn);

            //    // adding click listener on buttons
            //    btn.Click += new EventHandler(this.on_btn_click);
            //    i++;
            //}

            int row = int.Parse(tb_row.Text);
            int col = int.Parse(tb_column.Text);
            //int col = 5, row = 3;

            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        cout << "* ";
            //    }
            //    cout << endl;
            //}
            // *****
            // *****
            // *****
            //int x = 145, y = 52;
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        Button btn = new Button();

            //        btn.Name = (i + j).ToString();
            //        btn.Text = (i + j).ToString();
            //        btn.Size = new Size(145, 52);
            //        btn.BackColor = Color.White;

            //        flowLayoutPanel1.Controls.Add(btn);

            //        //// adding click listener on buttons
            //        btn.Click += new EventHandler(this.on_btn_click);
            //        //i++;
            //    }
            //    Button b = new Button();
            //    b.Size = new Size(30000, 10);
            //    b.Visible = false;
            //}
            int buttonWidth = 145;// 80;
            int buttonHeight = 52; // 30;
            int spacing = 20; // 10;

            int startX = 30; // (ClientSize.Width - (col * buttonWidth + (col - 1) * spacing)) / 2;
            int startY = 30; // (ClientSize.Height - (row * buttonHeight + (row - 1) * spacing)) / 2;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(buttonWidth, buttonHeight);
                    button.Location = new Point(startX + j * (buttonWidth + spacing),
                                                startY + i * (buttonHeight + spacing));
                    button.Text = $"Button {i}-{j}";
                    button.Click += on_btn_click;

                    buttons_panel.Controls.Add(button);
                }
            }
        }

        private void on_btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            MessageBox.Show(btn.Text);

        }
    }
}
