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
    public partial class FormVet : Form
    {
        public FormVet()
        {
            InitializeComponent();
            LabelLogin.Text = Convert.ToString(Authorization.User);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin f1 = new FormLogin();
            f1.Show();
            Hide();
        }

        private void Form_Vet_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormVetInfo fVI = new FormVetInfo();
            fVI.Show();
            Hide();
        }
    }
}
