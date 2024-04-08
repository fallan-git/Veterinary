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
    public partial class FormAdmVet : Form
    {
        public FormAdmVet()
        {
            InitializeComponent();
            DateTime DateNow = DateTime.Now;
            dateTimePicker1.MaxDate = DateNow;
            dateTimePicker2.MaxDate = DateNow;
            Pets.GetPets();
            dataGridView1.DataSource = Pets.DtbPets;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAdm FA = new FormAdm();
            FA.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Text;
            if (textBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "")
            {
                if (Pets.AddPet(textBox1.Text, dateTimePicker1.Text, textBox3.Text, textBox5.Text))
                {
                    MessageBox.Show("Питоиец успешно добавлен!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pets.GetPets();
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
