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
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
            Information.GetDopInfo();
            LabelLogin.Text = Convert.ToString(Authorization.User);
            label8.Text = Convert.ToString(Information.Adres);
            label7.Text = Convert.ToString(Information.Grafik);
            label3.Text = Convert.ToString(Information.Number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUserCabinet f3 = new FormUserCabinet();
            f3.Show();
            Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin f1 = new FormLogin();
            f1.Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormUserList UsrList = new FormUserList();
            UsrList.Show();
            Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormUserRecords fRec = new FormUserRecords();
            fRec.Show();
            Hide();
        }
    }
}
