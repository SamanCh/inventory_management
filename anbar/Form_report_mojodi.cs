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
    public partial class Form_report_mojodi : Form
    {
        public Form_report_mojodi()
        {
            InitializeComponent();
        }

        private void Form_report_mojodi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select * from anbar");
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "name";
            DataTable dt2 = new DataTable();
            dt2 = db.MySelect("select * from kala where anbar='" + comboBoxEx1.Text + "' ");
            dataGridViewX1.DataSource = dt2;
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
            int sum = 0;
            for (int i = 0; i < dt2.Rows.Count; i++)
                sum += int.Parse(dataGridViewX1[5, i].Value.ToString());
            textBoxX1.Text = sum.ToString();

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX1);
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            DataBase db = new DataBase();
            dt2 = db.MySelect("select * from kala where anbar='" + comboBoxEx1.Text + "' ");
            dataGridViewX1.DataSource = dt2;
            int sum = 0;
            for (int i = 0; i < dt2.Rows.Count; i++)
                sum += int.Parse(dataGridViewX1[5, i].Value.ToString());
            textBoxX1.Text = sum.ToString();
        }
    }
}
