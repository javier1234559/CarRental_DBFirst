﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Renting.UserControls
{
    public partial class BillsScreen : UserControl
    {
        public BillsScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRating_Click(object sender, EventArgs e)
        {
            fRating f = new fRating();
            f.ShowDialog();
        }
    }
}
