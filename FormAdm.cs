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
    public partial class FormAdm : Form
    {
        public FormAdm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin f1 = new FormLogin();
            f1.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdmList fLA = new FormAdmList();
            fLA.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form_Admin_Load(object sender, EventArgs e)
        {
            LabelLogin.Text = Convert.ToString(Authorization.User);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
