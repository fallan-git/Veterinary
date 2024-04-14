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
    public partial class FormAdmUsers : Form
    {
        static public string EditID, EditLogin, EditPassword, EditFIO, EditNumberPhone, EditRoleID;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == EditLogin)
            {
                if (textBox2.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox8.Text != "" && textBox10.Text != "")
                {
                    if (Users.EditUser(EditID, textBox2.Text, textBox4.Text, textBox6.Text, textBox8.Text, textBox10.Text))
                    {
                        MessageBox.Show("Пользователь успешно изменён!", "Изменение.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Users.GetUsers();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string Sql = @"SELECT `id_account` FROM `users` WHERE `login` = '" + textBox2.Text + "'";
                DBConnection.msCommand.CommandText = Sql;
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                }
                else
                {
                    if (textBox2.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox8.Text != "" && textBox10.Text != "")
                    {
                        if (Users.EditUser(EditID, textBox2.Text, textBox4.Text, textBox6.Text, textBox8.Text, textBox10.Text))
                        {
                            MessageBox.Show("Пользователь успешно изменён!", "Изменение.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Users.GetUsers();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox9.Text != "")
            {
                string Sql = @"SELECT `id_account` FROM `users` WHERE `login` = '" + textBox1.Text + "'";
                DBConnection.msCommand.CommandText = Sql;
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                }
                else
                {
                    if (Users.AddUser(textBox1.Text, textBox3.Text, textBox5.Text, textBox7.Text, textBox9.Text))
                    {
                        MessageBox.Show("Пользователь успешно добавлен!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Users.GetUsers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }

        public FormAdmUsers()
        {
            InitializeComponent();
            Users.GetUsers();
            dataGridView1.DataSource = Users.DtbUsers;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAdm FA = new FormAdm();
            FA.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Select = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult Del = MessageBox.Show("Вы уверенны что хотите удалить данного пользователя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Del == DialogResult.Yes)
            {
                Users.DeleteUser(Select);
                Users.GetUsers();
                MessageBox.Show("Пользователь удалён", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditLogin = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            EditPassword = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            EditFIO = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            EditNumberPhone = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            EditRoleID = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox2.Text = EditLogin;
            textBox4.Text = EditPassword;
            textBox6.Text = EditFIO;
            textBox8.Text = EditNumberPhone;
            textBox10.Text = EditRoleID;
        }
    }
}
