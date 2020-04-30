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
    public partial class First_window : Form
    {
        public First_window(Form f)
        {
            this.Location = f.Location;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registation reg = new Registation(this);
            this.Hide();
            reg.Show();
        }

        Point lastpoint, lastpoint2;

        private void First_window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void First_window_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint.X = e.X;
            lastpoint.Y = e.Y;
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Close_button_MouseEnter(object sender, EventArgs e)
        {
            this.Close_button.ForeColor = Color.Red;
        }

        private void Close_button_MouseLeave(object sender, EventArgs e)
        {
            this.Close_button.ForeColor = Color.White;
        } 

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint2.X;
                this.Top += e.Y - lastpoint2.Y;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Login_freelancer log = new Login_freelancer(this);
            this.Hide();
            log.Show();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint2.X = e.X;
            lastpoint2.Y = e.Y;
        }

    }
}
