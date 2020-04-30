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
    
    public partial class Very_first_window : Form
    {
        
        Point lastpoint, lastpoint_logo;//переменные с координатами
        
        public Very_first_window()
        {
            InitializeComponent();
        }

        private void Close_button_Click(object sender, EventArgs e)//кнопка закрытия программы
        {
            Application.Exit();
        }

        private void Close_button_MouseEnter(object sender, EventArgs e)//изменение цвета кнопки закрытия приложения
        {
            Close_button.ForeColor = Color.Red;
        }

        private void Close_button_MouseLeave(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.White;
        }

        
        private void Very_first_window_MouseMove(object sender, MouseEventArgs e)//функция преемещения окна
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint_logo.X;
                this.Top += e.Y - lastpoint_logo.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint_logo.X = e.X;
            lastpoint_logo.Y = e.Y;
        }

        private void Login_Click(object sender, EventArgs e)//открытие формы для фрилансера
        {
            First_window first_Window = new First_window(this);
            this.Hide();
            first_Window.Show();
        }

        private void button1_Click(object sender, EventArgs e)//открытие формы для заказчика
        {
            Sign_log_customer sign_Log_Customer = new Sign_log_customer(this);
            this.Hide();
            sign_Log_Customer.Show();
        }

        private void Very_first_window_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint.X = e.X;
            lastpoint.Y = e.Y;
        }
    }
}
