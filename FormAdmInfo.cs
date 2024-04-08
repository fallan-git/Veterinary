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
    public partial class FormAdmInfo : Form
    {
        static public string EditId, EditTitle, EditContent;
        public FormAdmInfo()
        {
            InitializeComponent();
            Information.GetInfo();
            dataGridView1.DataSource = Information.DtbInformation;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAdm FA = new FormAdm();
            FA.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                string Sql = @"SELECT `id_info` FROM `information` WHERE `title` = '" + textBox1.Text + "'";
                DBConnection.msCommand.CommandText = Sql;
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    MessageBox.Show("Информация с таким названием уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                }
                else
                {
                    if (Information.AddInfo(textBox1.Text, textBox3.Text))
                    {
                        MessageBox.Show("Информация успешно добавлена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Information.GetInfo();
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == EditTitle)
            {
                if (textBox2.Text != "" && textBox4.Text != "")
                {
                    if (Information.EditInfo(EditId, textBox2.Text, textBox4.Text))
                    {
                        MessageBox.Show("Услуга успешно изменена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Information.GetInfo();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string Sql = @"SELECT `id_info` FROM `information` WHERE `title` = '" + textBox2.Text + "'";
                DBConnection.msCommand.CommandText = Sql;
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    MessageBox.Show("Услуга с таким названием уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                }
                else
                {
                    if (textBox2.Text != "" && textBox4.Text != "")
                    {
                        if (Information.EditInfo(EditId, textBox2.Text, textBox4.Text))
                        {
                            MessageBox.Show("Услуга успешно изменена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Information.GetInfo();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Select = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult Del = MessageBox.Show("Вы уверенны что хотите удалить данную информацию?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Del == DialogResult.Yes)
            {
                Information.DeleteInfo(Select);
                Information.GetInfo();
                MessageBox.Show("Информация удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditTitle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            EditContent = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            textBox2.Text = EditTitle;
            textBox4.Text = EditContent;
        }
    }
}
