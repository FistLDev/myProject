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
    public partial class Order_information : Form
    {
        Point lastpoint, lastpoint2, lastpoint3, lastpoint4, lastpoint5, lastpoint6, lastpoint7, lastpoint8, lastpoint9;//переменные с координатами
        public Order_information(Form f)
        {
            this.Location = f.Location;
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint.X = e.X;
            lastpoint.Y = e.Y;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint2.X;
                this.Top += e.Y - lastpoint2.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint2.X = e.X;
            lastpoint2.Y = e.Y;
        }

        private void Order_information_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint3.X;
                this.Top += e.Y - lastpoint3.Y;
            }
        }

        private void Order_information_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint3.X = e.X;
            lastpoint3.Y = e.Y;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint4.X;
                this.Top += e.Y - lastpoint4.Y;
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint4.X = e.X;
            lastpoint4.Y = e.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint5.X;
                this.Top += e.Y - lastpoint5.Y;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint5.X = e.X;
            lastpoint5.Y = e.Y;
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

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint6.X;
                this.Top += e.Y - lastpoint6.Y;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint6.X = e.X;
            lastpoint6.Y = e.Y;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint7.X;
                this.Top += e.Y - lastpoint7.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint7.X = e.X;
            lastpoint7.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint8.X;
                this.Top += e.Y - lastpoint8.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint8.X = e.X;
            lastpoint8.Y = e.Y;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint9.X;
                this.Top += e.Y - lastpoint9.Y;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint9.X = e.X;
            lastpoint9.Y = e.Y;
        }
    }
}
