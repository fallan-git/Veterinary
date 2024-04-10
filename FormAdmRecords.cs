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
    public partial class FormAdmRecords : Form
    {
        static public string EditId, EditIdUser, EditIdPet, EditIdService, EditVeterinarian;
        public FormAdmRecords()
        {
            InitializeComponent();
            DateTime DateNow = DateTime.Now;
            DateTime NextDate = DateNow.AddMonths(1);
            dateTimePicker1.MinDate = DateNow;
            dateTimePicker1.MaxDate = NextDate;
            dateTimePicker2.MinDate = DateNow;
            dateTimePicker2.MaxDate = NextDate;
            Records.GetRecords();
            dataGridView2.DataSource = Records.DtbRecords;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAdm FA = new FormAdm();
            FA.Show();
            Hide();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Select = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            DialogResult Del = MessageBox.Show("Вы уверенны что хотите удалить данную запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Del == DialogResult.Yes)
            {
                Records.DeleteRecord(Select);
                Records.GetRecords();
                MessageBox.Show("Запись удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox7.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "")
            {
                if (Records.AddRecord(textBox1.Text, textBox3.Text, textBox5.Text, dateTimePicker1.Text, comboBox1.Text, textBox7.Text))
                {
                    MessageBox.Show("Запись успешно добавлена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Records.GetRecords();
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox8.Text != "" && dateTimePicker2.Text != "" && comboBox2.Text != "")
            {
                if (Records.EditRecord(EditId, textBox2.Text, textBox4.Text, textBox6.Text, dateTimePicker2.Text, comboBox2.Text, textBox8.Text))
                {
                    MessageBox.Show("Запись успешно изменена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Records.GetRecords();
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditId = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            EditIdUser = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            EditIdPet = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            EditIdService = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            EditVeterinarian = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            textBox2.Text = EditIdUser;
            textBox4.Text = EditIdPet;
            textBox6.Text = EditIdService;
            textBox8.Text = EditVeterinarian;
        }
    }
}
