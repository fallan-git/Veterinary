﻿using System;
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
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
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
            else if (Encoding.UTF8.GetByteCount(textBox2.Text) != 11)
            {
                MessageBox.Show("Номер телефона введён не в верном формате.\n\nПример: 88005553535", "Ошибка.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Users.UppdateProfile(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUser Main = new FormUser();
            Main.Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormUsersPets Pets = new FormUsersPets();
            Pets.Show();
            Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormUserRecList RecList = new FormUserRecList();
            RecList.Show();
            Hide();
        }
    }
}
