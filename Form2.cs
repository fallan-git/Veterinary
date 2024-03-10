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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = "Введите логин";
            textBox2.Text = "Номер телефона";
            textBox3.Text = "Введите пароль";
            textBox4.Text = "Повторите пароль";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")
                textBox1.Text = "";
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Номер телефона")
                textBox2.Text = "";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Введите пароль")
                textBox3.Text = "";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Повторите пароль")
                textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val;
            if (textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Вы не указали все данные.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text != textBox3.Text)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(textBox2.Text, out val))
            {
                MessageBox.Show("Номер телефона указан не правильно. Пример как его надо указать: 88005553535", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Registration.Registration1(textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show(textBox1.Text + ", вы были успешно зарегестрированны! Зайдите в свой аккаунт.", "Успешная регистрация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();


            }
        }
    }
}
