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
    public partial class FormListAdm : Form
    {
        static public string EditNum, EditName, EditPrice, EditDesc;
        public FormListAdm()
        {
            InitializeComponent();
            ListUpdate.GetList();
            dataGridView1.DataSource = ListUpdate.DtbList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdm fA = new FormAdm();
            fA.Show();
            Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormListAdm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string Sql = @"SELECT `id_service` FROM `list` WHERE `name` = '" + textBox1.Text + "'";
                DBConnection.msCommand.CommandText = Sql;
                object Result = DBConnection.msCommand.ExecuteScalar();
                if(Result != null)
                {
                    MessageBox.Show("Услуга с таким названием уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                }
                else
                {
                    if(ListUpdate.AddList(textBox1.Text, textBox3.Text, textBox4.Text))
                    {
                        MessageBox.Show("Услуга успешно добавлена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListUpdate.GetList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == EditName)
            {
                if (textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    ListUpdate.EditList(EditNum, textBox2.Text, textBox5.Text, textBox6.Text);
                    MessageBox.Show("Услуга успешно изменена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListUpdate.GetList();
                }
                else
                {
                    MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string Sql = @"SELECT `id_service` FROM `list` WHERE `name` = '" + textBox2.Text + "'";
                DBConnection.msCommand.CommandText = Sql;
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    MessageBox.Show("Услуга с таким названием уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                }
                else
                {
                    if (textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                    {
                        ListUpdate.EditList(EditNum, textBox2.Text, textBox5.Text, textBox6.Text);
                        MessageBox.Show("Услуга успешно изменена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListUpdate.GetList();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditNum = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            EditPrice = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            EditDesc = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            textBox2.Text = EditName;
            textBox5.Text = EditPrice;
            textBox6.Text = EditDesc;
        }
    }
}
