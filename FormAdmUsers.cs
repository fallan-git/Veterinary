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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
