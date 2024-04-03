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
    public partial class Form_Vet : Form
    {
        public Form_Vet()
        {
            InitializeComponent();
            LabelLogin.Text = Convert.ToString(Authorization.User);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Hide();
        }

        private void Form_Vet_Load(object sender, EventArgs e)
        {

        }
    }
}
