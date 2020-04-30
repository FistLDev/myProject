using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beta_1._0
{
    public partial class Verification : Form
    {
        Point lastpoint, lastpoint_logo;
        public string code;
        public string username;
        public Verification(Form f, string email, string username)
        {
            this.username = username;
            this.Location = f.Location;
            InitializeComponent();
            Random rnd = new Random();
            int value = rnd.Next(1001, 9999);
            code = value.ToString();
            MailAddress from = new MailAddress("codesender2020@gmail.com", "Tom");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Verification";
            m.Body = $"<h2>Your code is: {code}</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("codesender2020@gmail.com", "qwerty2020");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        private void Verification_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Verification_MouseDown(object sender, MouseEventArgs e)
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint_logo.X = e.X;
            lastpoint_logo.Y = e.Y;
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Close_button_MouseEnter(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == code)
            {
                Personal_acc_freelancer acc = new Personal_acc_freelancer(this,username);
                acc.Show();
                this.Close();
            }
            else MessageBox.Show("Wrong code!");
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Code") textBox3.Text = "";
        }

        private void Close_button_MouseLeave(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.White;
        }
    }
}
