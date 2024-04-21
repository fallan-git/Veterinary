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
            LabelLogin.Text = Convert.ToString(Authorization.User);
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
        private void button5_Click(object sender, EventArgs e)
        {
            FormAdmUsers FAU = new FormAdmUsers();
            FAU.Show();
            Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormAdmVet FAV = new FormAdmVet();
            FAV.Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormAdmRecords FAR = new FormAdmRecords();
            FAR.Show();
            Hide();
        }
    }
}
