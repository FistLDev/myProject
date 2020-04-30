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
    public partial class Login_customer : Form
    {
        Point lastpoint, lastpoint_logo;//переменные с координатами
        public Login_customer(Form f)
        {
            this.Location = f.Location;
            InitializeComponent();
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

        private void Login_customer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Login_customer_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint.X = e.X;
            lastpoint.Y = e.Y;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint_logo.X;
                this.Top += e.Y - lastpoint_logo.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBUtils.GetDBconnection())
            {
                string username = "";
                DataTable table2 = new DataTable();//создаем вторую таблицу
                SqlDataAdapter adapter2 = new SqlDataAdapter();//создаем второй адаптер
                DataTable table = new DataTable();//создаем таблицу
                SqlDataAdapter adapter = new SqlDataAdapter();//создаем адаптер
                conn.Open();
                string sqlExpression = "SELECT * FROM Customer WHERE Email = '" + textBox2.Text + "' AND Pass = '" + textBox3.Text + "' ";
                string sqlExpression2 = "SELECT Username FROM Customer WHERE Email = '" + textBox2.Text + "' AND Pass = '" + textBox3.Text + "' ";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                SqlCommand command2 = new SqlCommand(sqlExpression2, conn);
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter2.SelectCommand = command2;
                adapter.Fill(table);
                adapter2.Fill(table2);
                foreach (DataRow row in table2.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        username = cell.ToString();
                }

                if (table.Rows.Count > 0)//проверяем, есть ли в таблице данные
                {

                    Personal_acc_customer perAcc = new Personal_acc_customer(this, username);
                    perAcc.Show();
                    this.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid E-mail or Password");
                    conn.Close();
                }
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "E-mail") textBox2.Text = "";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Password") textBox3.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            lastpoint_logo.X = e.X;
            lastpoint_logo.Y = e.Y;
        }
    }
}
