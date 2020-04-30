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
    public partial class New_order_form : Form
    {
        Point lastpoint, lastpoint2, lastpoint3, lastpoint4, lastpoint5, lastpoint6, lastpoint7, lastpoint8, lastpoint9;//переменные с координатами
        public New_order_form(Form f)
        {
            this.Location = f.Location;
            InitializeComponent();
        }

        private void New_order_form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void New_order_form_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint.X = e.X;
            lastpoint.Y = e.Y;
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

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint3.X;
                this.Top += e.Y - lastpoint3.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
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

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint8.X;
                this.Top += e.Y - lastpoint8.Y;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint8.X = e.X;
            lastpoint8.Y = e.Y;
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

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint9.X;
                this.Top += e.Y - lastpoint9.Y;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint9.X = e.X;
            lastpoint9.Y = e.Y;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint5.X;
                this.Top += e.Y - lastpoint5.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint5.X = e.X;
            lastpoint5.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint6.X;
                this.Top += e.Y - lastpoint6.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint6.X = e.X;
            lastpoint6.Y = e.Y;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint7.X;
                this.Top += e.Y - lastpoint7.Y;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint7.X = e.X;
            lastpoint7.Y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object id = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table2 = new DataTable();
            if (textBox1 != null && textBox2 != null && textBox3.Text != "Price" && textBox4.Text != "Tag")
            {
                using (SqlConnection connection = DBUtils.GetDBconnection())
                {
                    connection.Open();
                    string sqlExpression = "INSERT INTO Ordertable (Name, Description, Price, Tag) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                    string sqlExpression2 = "SELECT MAX(Id) FROM Freelancer";
                    SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    id = table2.Rows[0];
                }
            }

            Random rnd = new Random();
            var id2 = (int)id;
            int value = rnd.Next(1, id2);
            selectFreelancer(value);

        }

        public int selectFreelancer(int id)
        {
            int rate;
            string username;
            using (SqlConnection connection = DBUtils.GetDBconnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                connection.Open();
                string sqlExpression = $"SELECT Username, Rate FROM Freelancer WHERE Id = {id}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                username = Convert.ToString(table.Rows[0]);
                rate = Convert.ToInt32(table.Rows[1]);
                MessageBox.Show($"{username}, {rate}");
                return 0;
            }

        }
    }
}
