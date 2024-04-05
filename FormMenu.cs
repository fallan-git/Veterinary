﻿using System;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            LabelLogin.Text = Convert.ToString(Authorization.User);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCabinet f3 = new FormCabinet();
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

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRecords fRec = new FormRecords();
            fRec.Show();
            Hide();
        }
    }
}