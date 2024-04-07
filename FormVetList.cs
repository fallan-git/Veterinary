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
    public partial class FormVetList : Form
    {
        public FormVetList()
        {
            InitializeComponent();
            List.GetList();
            dataGridView1.DataSource = List.DtbList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormVet FV = new FormVet();
            FV.Show();
            Hide();
        }
    }
}
