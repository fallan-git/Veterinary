using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Veterinary
{
    public partial class FormUserCabinet : Form
    {
        public FormUserCabinet()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(Authorization.User);
            textBox2.Text = Convert.ToString(Authorization.Number);
            textBox3.Text = Convert.ToString(Authorization.FIO);
            textBox4.Text = Convert.ToString(Authorization.Password);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Вы указали не все данные.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UsersFunctions.UppdateProfile(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
                Authorization.Authorization1(textBox1.Text, textBox4.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUserMenu main = new FormUserMenu();
            main.Show();
            Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
