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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin f = new FormLogin();
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
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fio = textBox5.Text + " " + textBox6.Text + " " + textBox7.Text;
            if (textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Вы не указали все данные.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox4.Text != textBox3.Text)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Encoding.UTF8.GetByteCount(textBox2.Text) != 11)
            {
                MessageBox.Show("Номер телефона введён не в верном формате.\n\nПример: 88005553535", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Registration.Registration1(textBox1.Text, textBox2.Text, textBox3.Text, fio);
                if (Registration.Resulting == "true")
                {
                    this.Hide();
                    FormLogin f1 = new FormLogin();
                    f1.Show();
                }
            }
        }
    }
}
