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
            FormLogin FL = new FormLogin();
            FL.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdmList FAL = new FormAdmList();
            FAL.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdmInfo FAI = new FormAdmInfo();
            FAI.Show();
            Hide();
        }

        private void Form_Admin_Load(object sender, EventArgs e)
        {
            LabelLogin.Text = Convert.ToString(Authorization.User);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAdmUsers FAU = new FormAdmUsers();
            FAU.Show();
            Hide();
        }
    }
}
