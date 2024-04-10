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
    public partial class FormUsersPets : Form
    {
        static public string EditId, EditIdOwner, EditName, EditDate, EditDiseases;
        public FormUsersPets()
        {
            InitializeComponent();
            DateTime DateNow = DateTime.Now;
            dateTimePicker1.MaxDate = DateNow;
            dateTimePicker2.MaxDate = DateNow;
            Pets.GetPetsForUser();
            dataGridView1.DataSource = Pets.DtbPetsForUser;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox6.Text != "" && dateTimePicker2.Text != "")
            {
                if (Pets.EditPet(EditId, Authorization.ID, dateTimePicker2.Text, textBox4.Text, textBox6.Text))
                {
                    MessageBox.Show("Питомец успешно изменён!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pets.GetPetsForUser();
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Select = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult Del = MessageBox.Show("Вы уверенны что хотите удалить данного питомца?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Del == DialogResult.Yes)
            {
                Pets.DeletePet(Select);
                Pets.GetPetsForUser();
                MessageBox.Show("Питоиец удалён", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "")
            {
                if (Pets.AddPet(Authorization.ID, dateTimePicker1.Text, textBox3.Text, textBox5.Text))
                {
                    MessageBox.Show("Питомец успешно добавлен!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pets.GetPetsForUser();
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormUserCabinet Cabinet = new FormUserCabinet();
            Cabinet.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditIdOwner = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            EditDate = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            EditName = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            EditDiseases = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            textBox4.Text = EditName;
            textBox6.Text = EditDiseases;
            dateTimePicker2.Text = EditDate;
        }
    }
}
