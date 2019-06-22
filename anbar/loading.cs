using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace anbar
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarX1.PerformStep();
            if (progressBarX1.Value == progressBarX1.Maximum)
            {

                timer1.Enabled = false;
                this.Hide();
                login x = new login();
                x.ShowDialog();

            }
        }
    }
}
