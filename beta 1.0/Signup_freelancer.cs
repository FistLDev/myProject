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
    public partial class Registation : Form
    {
        public Registation(Form form)//конструктор вызова формы
        {
            this.Location = form.Location;
            InitializeComponent();
        }

        private void Close_button_Click(object sender, EventArgs e)//кнопка закрытия формы
        {
            Application.Exit();
        }

        private void Close_button_MouseEnter(object sender, EventArgs e)// изменение цвета знака закрытия
        {
            Close_button.ForeColor = Color.Red;
        }

        private void Close_button_MouseLeave(object sender, EventArgs e)// измение цвета знака закрытия обратно
        {
            Close_button.ForeColor = Color.White;
        }

        Point lastpoint, lastpoint2;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint2.X;
                this.Top += e.Y - lastpoint2.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint2 = new Point(e.X, e.Y);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//Когда текст меняется, символы становятся звездочками
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e) //Меняет значение текстбокса при клике на пустое
        {
            if(textBox3.Text == "Password") textBox3.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)//Меняет значение текстбокса при клике на пустое
        {
            if (textBox2.Text == "E-mail") textBox2.Text = "";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)//Меняет значение текстбокса при клике на пустое
        {
            if (textBox1.Text == "Login") textBox1.Text = "";
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
                for (int i = 0; i< textBox2.Text.Length; i++)//цикл проверки наличия @ в поле для ввода почты
                {
                    if (textBox2.Text[i] == '@') dogSignInt++;

                }
                if (dogSignInt != 1) MessageBox.Show("Invalid E-mail");//если в посте нет @, то выводит, что почта невалидна
                connection.Open();
                string sqlExpression = "INSERT INTO Freelancer (Username,Email,Pass) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                Verification verification = new Verification(this, textBox2.Text, textBox1.Text);
                verification.Show();
                this.Hide();
                connection.Close();
            }   
           
            
                      
        }
           
        public Boolean CheckUserLogin()//функция проверки наличия пользователя с таким ником в базе данных
        {
            DataTable table = new DataTable();//создаем таблицу
            SqlDataAdapter adapter = new SqlDataAdapter();//создаем адаптер
            using(SqlConnection conn = DBUtils.GetDBconnection())
            {
                conn.Open();
                string sqlExpression = "SELECT * FROM Freelancer WHERE Username = '" + textBox1.Text + "' ";
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
                string sqlExpression = "SELECT * FROM Freelancer WHERE Email = '" + textBox2.Text + "' ";
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
