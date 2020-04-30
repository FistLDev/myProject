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

    public partial class Personal_acc_freelancer : Form
    {
        Point lastpoint, lastpoint2, lastpoint3;//переменные с координатами
        public Personal_acc_freelancer(Form f, string username)
        {
            this.Location = f.Location;
            InitializeComponent();
            textBox1.Text = username;
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Close_button_MouseEnter(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.Red;
        }

        private void Close_button_MouseLeave(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.White;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            {
                lastpoint.X = e.X;
                lastpoint.Y = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint2.X;
                this.Top += e.Y - lastpoint2.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint2.X = e.X;
            lastpoint2.Y = e.Y;
        }

        private void Personal_acc_freelancer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint3.X;
                this.Top += e.Y - lastpoint3.Y;
            }
        }

        private void Personal_acc_freelancer_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint3.X = e.X;
            lastpoint3.Y = e.Y;
        }
    }
}
