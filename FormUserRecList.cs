﻿using System;
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
    public partial class FormUserRecList : Form
    {
        public FormUserRecList()
        {
            InitializeComponent();
            Records.GetRecordsFromUsersCab();
            dataGridView2.DataSource = Records.DtbRecordsFromUsersCab;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormUserCabinet Cabinet = new FormUserCabinet();
            Cabinet.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormUserRecords Records = new FormUserRecords();
            Records.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Select = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            DialogResult Del = MessageBox.Show("Вы уверенны что хотите удалить данную запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Del == DialogResult.Yes)
            {
                Records.DeleteRecord(Select);
                Records.GetRecordsFromUsersCab();
                MessageBox.Show("Запись удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
