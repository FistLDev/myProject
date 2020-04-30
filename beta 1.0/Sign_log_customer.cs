    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace beta_1._0
    {
        public partial class Sign_log_customer : Form
        {
            Point lastpoint, lastpoint2;
            public Sign_log_customer(Form f)
            {
                this.Location = f.Location;
                InitializeComponent();
            }

            private void Close_button_MouseEnter(object sender, EventArgs e)
            {
                Close_button.ForeColor = Color.Red;
            }

            private void Close_button_MouseLeave(object sender, EventArgs e)
            {
                Close_button.ForeColor = Color.White;
            }

            private void Close_button_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void Sign_log_customer_MouseDown(object sender, MouseEventArgs e)
            {
                lastpoint.X = e.X;
                lastpoint.Y = e.Y;
            }

            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - lastpoint2.X;
                    this.Top += e.Y - lastpoint2.Y;
                }
            }

            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                lastpoint2.X = e.X;
                lastpoint2.Y = e.Y;
            }

            private void Login_Click(object sender, EventArgs e)
            {
                Login_customer log = new Login_customer(this);
                this.Hide();
                log.Show();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                Signup_customer sign = new Signup_customer(this);
                this.Hide();
                sign.Show();
            }

            private void Sign_log_customer_MouseMove(object sender, MouseEventArgs e)
            {
                if(e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - lastpoint.X;
                    this.Top += e.Y - lastpoint.Y;
                }
            }


        }
    }
