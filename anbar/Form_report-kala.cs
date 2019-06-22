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
    public partial class Form_report_kala : Form
    {
        public Form_report_kala()
        {
            InitializeComponent();
        }

        private void Form_report_kala_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select * from kala");
            dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "نام ";
            dataGridViewX1.Columns[2].HeaderText = "توضیحات";
            dataGridViewX1.Columns[3].HeaderText = "کشور سازنده";
            dataGridViewX1.Columns[4].HeaderText = " نام انبار";
            dataGridViewX1.Columns[5].HeaderText = "تعداد";
            dataGridViewX1.Columns[6].HeaderText = "واحد";
            dataGridViewX1.Columns[7].HeaderText = "قیمت واحد";
            dataGridViewX1.Columns[8].HeaderText = "قیمت کل";
            dataGridViewX1.Columns[9].HeaderText = " تاریخ ثیت";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX1);
        }
    }
}
