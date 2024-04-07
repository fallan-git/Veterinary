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
    public partial class FormVetRecords : Form
    {
        public FormVetRecords()
        {
            InitializeComponent();
            Records.GetRecords();
            dataGridView2.DataSource = Records.DtbRecords;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormVet FV = new FormVet();
            FV.Show();
            Hide();
        }
    }
}
