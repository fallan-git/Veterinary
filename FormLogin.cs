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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            DBConnection.ConnectionDB();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Authorization.Authorizations(textBox1.Text, textBox2.Text);
                switch (Authorization.Role)
                {
                    case null:
                        {
                            MessageBox.Show("Такого аккаунта не существует или пароль введён неверно!", "Проверьте данные и начните снова!");
                            break;
                        }
                    case "Администратор":
                        {
                            Authorization.User = textBox1.Text;
                            MessageBox.Show(textBox1.Text + ", добро пожаловать в меню администратора!", "Успешный вход в панель администратора.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormAdm fA = new FormAdm();
                            fA.Show();
                            break;
                        }
                    case "Ветеринар":
                        {
                            Authorization.User = textBox1.Text;
                            MessageBox.Show(textBox1.Text + ", добро пожаловать в меню ветеринара!", "Успешный вход в панель ветеринара.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormVet fV = new FormVet();
                            fV.Show();
                            break;
                        }
                    case "Пользователь":
                        {
                            Authorization.User = textBox1.Text;
                            MessageBox.Show(textBox1.Text + ", добро пожаловать в меню пользователя!", "Успешный вход в меню.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormUser f4 = new FormUser();
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
            FormRegister f = new FormRegister();
            f.Show();
            this.Hide();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(sender, e);
            }
        }
    }
}