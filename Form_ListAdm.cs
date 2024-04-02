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
    public partial class Form_ListAdm : Form
    {
        public Form_ListAdm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Admin FormAdmin = new Form_Admin();
            FormAdmin.Show();
            Hide();
        }
    }
}
