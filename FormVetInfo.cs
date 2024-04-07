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
    public partial class FormVetInfo : Form
    {
        public FormVetInfo()
        {
            InitializeComponent();
            Pets.GetPets();
            dataGridView1.DataSource = Pets.DtbPets;
            Users.GetUsersForVet();
            dataGridView2.DataSource = Users.DtbUsersForVet;
            Users.GetUsersForVet2();
            dataGridView3.DataSource = Users.DtbUsersForVet2;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void Form_VetInfo_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormVet FV = new FormVet();
            FV.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;

        }
    }
}
