using ConnectSQLserver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beta_1._0
{
    public partial class Signup_customer : Form
    {
        Point lastpoint, lastpoint_logo;//переменные с координатами
        public Signup_customer(Form f)
        {
            this.Location = f.Location;
            InitializeComponent();
        }

        private void Signup_customer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Signup_customer_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint.X = e.X;
            lastpoint.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint_logo.X;
                this.Top += e.Y - lastpoint_logo.Y;
            }
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

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Login") textBox1.Text = "";
        }
        private void textBox3_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Password") textBox3.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)//Меняет значение текстбокса при клике на пустое
        {
            if (textBox2.Text == "E-mail") textBox2.Text = "";
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint_logo.X = e.X;
            lastpoint_logo.Y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBUtils.GetDBconnection())//Вносим значения логина, пароля и имейла в БД
            {

                if (textBox1.Text == "")//проверка, чтобы поле не было пустым
                {
                    MessageBox.Show("Enter login");
                    return;
                }
                if (textBox2.Text == "")//проверка, чтобы поле не было пустым
                {
                    MessageBox.Show("Enter login");
                    return;
                }
                if (textBox3.Text == "")//проверка, чтобы поле не было пустым
                {
                    MessageBox.Show("Enter login");
                    return;
                }
                if (textBox3.Text.Length < 8)//проверка длины пароля
                {
                    MessageBox.Show("Password is too short (min - 8 signs)");
                    return;
                }
                if (CheckUserLogin()) return;
                if (CheckUserEmail()) return;
                int dogSignInt = 0;//количество знаков @ в имейле
                for (int i = 0; i < textBox2.Text.Length; i++)//цикл проверки наличия @ в поле для ввода почты
                {
                    if (textBox2.Text[i] == '@') dogSignInt++;

                }
                if (dogSignInt != 1) MessageBox.Show("Invalid E-mail");//если в посте нет @, то выводит, что почта невалидна
                connection.Open();
                string sqlExpression = "INSERT INTO Customer (Username,Email,Pass) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                Personal_acc_customer perAcc = new Personal_acc_customer(this, textBox1.Text);
                perAcc.Show();
                this.Hide();
                connection.Close();
            }
        }

        public Boolean CheckUserLogin()//функция проверки наличия пользователя с таким ником в базе данных
        {
            DataTable table = new DataTable();//создаем таблицу
            SqlDataAdapter adapter = new SqlDataAdapter();//создаем адаптер
            using (SqlConnection conn = DBUtils.GetDBconnection())
            {
                conn.Open();
                string sqlExpression = "SELECT * FROM Customer WHERE Username = '" + textBox1.Text + "' ";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)//проверяем, есть ли в таблице строка с таким же логином
                {
                    MessageBox.Show("A user with this username already exists ");
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }


            }
        }

        

        public Boolean CheckUserEmail()//функция проверки наличия такого же имейла в БД
        {
            DataTable table = new DataTable();//создаем таблицу
            SqlDataAdapter adapter = new SqlDataAdapter();//создаем адаптер
            using (SqlConnection conn = DBUtils.GetDBconnection())
            {
                conn.Open();
                string sqlExpression = "SELECT * FROM Customer WHERE Email = '" + textBox2.Text + "' ";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)//проверяем, есть ли в таблице строка с таким же имейлом
                {
                    MessageBox.Show("A user with this e-mail already exists ");
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
        }
    }
}
