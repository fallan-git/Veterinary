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
    public partial class FormUserList : Form
    {
        public FormUserList()
        {
            InitializeComponent();
            List.GetList();
            dataGridView1.DataSource = List.DtbList;
        }

        private void FormUserList_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUser Main = new FormUser();
            Main.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUserRecords Records = new FormUserRecords();
            Records.Show();
            Hide();
        }
    }
}
