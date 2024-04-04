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
    public partial class FormRecords : Form
    {
        public FormRecords()
        {
            InitializeComponent();
            DateTime DateNow = DateTime.Now;
            DateTime NextDate = DateNow.AddMonths(1);
            dateTimePicker1.MinDate = DateNow;
            dateTimePicker1.MaxDate = NextDate;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 main = new Form4();
            main.Show();
            Hide();
        }

        private void FormRecords_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection.msCommand.CommandText = @"SELECT name FROM list;";
            object Result = DBConnection.msCommand.ExecuteScalar();

            textBox1.Text = Convert.ToString(Result);
        }
    }
}
