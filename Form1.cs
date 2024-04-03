using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    public partial class Form1 : Form
    {
        static public string loginActive;
        static public string whois;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Authorization.Authorization1(textBox1.Text, textBox2.Text);
                switch (Authorization.Role)
                {
                    case null:
                        {
                            MessageBox.Show("Такого аккаунта не существует или пароль введён неверно!", "Проверьте данные и начните снова!");
                            break;
                        }
                    case "Администратор":
                        {
                            loginActive = textBox1.Text;
                            whois = "Администратор";
                            Authorization.User = textBox1.Text;
                            MessageBox.Show(textBox1.Text + ", добро пожаловать в меню администратора!", "Успешный вход в панель администратора.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Form_Admin fA = new Form_Admin();
                            fA.Show();
                            break;
                        }
                    case "Ветеринар":
                        {
                            loginActive = textBox1.Text;
                            whois = "Ветеринар";
                            Authorization.User = textBox1.Text;
                            MessageBox.Show(textBox1.Text + ", добро пожаловать в меню ветеринара!", "Успешный вход в панель ветеринара.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Form_Vet fV = new Form_Vet();
                            fV.Show();
                            break;
                        }
                    case "Пользователь":
                        {
                            loginActive = textBox1.Text;
                            whois = "Пользователь";
                            Authorization.User = textBox1.Text;
                            MessageBox.Show(textBox1.Text + ", добро пожаловать в меню пользователя!", "Успешный вход в меню.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Form4 f4 = new Form4();
                            f4.Show();
                            break;
                        }
                }

            }
            else
            {
                MessageBox.Show("Заполните поля с даннными!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnection.ConnectionDB();
        }
    }
}
