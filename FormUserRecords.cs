using MySqlX.XDevAPI.Common;
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
    public partial class FormUserRecords : Form
    {
        string SelectPets;
        public FormUserRecords()
        {
            InitializeComponent();
            DateTime DateNow = DateTime.Now;
            DateTime NextDate = DateNow.AddMonths(1);
            dateTimePicker1.MinDate = DateNow;
            dateTimePicker1.MaxDate = NextDate;

            Users.GetUsersForRec();
            dataGridView1.DataSource = Users.DtbUsersForRec;
            List.GetListForRec();
            dataGridView2.DataSource = List.DtbListForRec;
            Pets.GetPetsForRec();
            dataGridView3.DataSource = Pets.DtbPetsForRec;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUser main = new FormUser();
            main.Show();
            Hide();
        }

        private void FormRecords_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SelectService = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string SelectVeterinar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DBConnection.msCommand.CommandText = @"SELECT `name` FROM pets WHERE `id_user` = '" + Authorization.ID + "';";
            object Result = DBConnection.msCommand.ExecuteScalar();
            if (Result != null)
            {
                SelectPets = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                SelectPets = "null";
            }
            if (dateTimePicker1.Text != "" && comboBox2.Text != "")
            {
                if (Records.AddRecordForUser(dateTimePicker1.Text, comboBox2.Text, SelectService, SelectVeterinar, SelectPets))
                {
                    MessageBox.Show("Запись успешно добавлена!", "Добавление.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Если у вас не доступен выбор то проигнорируйте этот пункт.\n\nДобавить питомца можно в личном кабинете.", "Выбор питомца..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
