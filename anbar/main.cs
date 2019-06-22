using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace anbar
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void office2007StartButton1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (variable.i == 2)
            {
                labelX1.Text = "کاربر عادی";
                buttonItem14.Enabled = false;
                buttonItem15.Enabled = false;
                buttonItem16.Enabled = false;
                buttonItem20.Enabled = false;
                buttonItem22.Enabled = false;
                buttonItem23.Enabled = false;
            }
            else
                labelX1.Text = "مدیر";

            System.Globalization.PersianCalendar dtePersianCalendar = new System.Globalization.PersianCalendar();
            System.String Year, Month, Day, strResult;
            DateTime Date_Now = DateTime.Now;
            //-----------------------------------------------------------------------------
            Year = dtePersianCalendar.GetYear(Date_Now).ToString();
            Month = dtePersianCalendar.GetMonth(Date_Now).ToString();
            Day = dtePersianCalendar.GetDayOfMonth(Date_Now).ToString();
            strResult = Year + "/" + Month + "/" + Day;
            buttonX2.Text = strResult;
            DataTable dt = new DataTable();
            //'sakhte yek nemoone az class DataBase
            DataBase db = new DataBase();
            //'seda zadan function==>MySelect baraye jostejoo dar bank
            dt = db.MySelect("select top 6 * from foroshandeh");
            dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "نام";
            dataGridViewX1.Columns[2].HeaderText = "فامیلی";
            dataGridViewX1.Columns[3].HeaderText = "تلفن";
            dataGridViewX1.Columns[4].HeaderText = "ادرس";
            dt = db.MySelect("select top 6 * from tahvilgirandeh");
            dataGridViewX2.DataSource = dt;
            dataGridViewX2.Columns[0].HeaderText = "کد";
            dataGridViewX2.Columns[1].HeaderText = "نام";
            dataGridViewX2.Columns[2].HeaderText = "فامیلی";
            dataGridViewX2.Columns[3].HeaderText = "تلفن";
            dataGridViewX2.Columns[4].HeaderText = "ادرس";
            dt = db.MySelect("select top 6 * from kala");
            dataGridViewX3.DataSource = dt;
            dataGridViewX3.Columns[0].HeaderText = "کد";
            dataGridViewX3.Columns[1].HeaderText = "نام ";
            dataGridViewX3.Columns[2].HeaderText = "توضیحات";
            dataGridViewX3.Columns[3].HeaderText = "کشور سازنده";
            dataGridViewX3.Columns[4].HeaderText = " نام انبار";
            dataGridViewX3.Columns[5].HeaderText = "تعداد";
            dataGridViewX3.Columns[6].HeaderText = "واحد";
            dataGridViewX3.Columns[7].HeaderText = "قیمت واحد";
            dataGridViewX3.Columns[8].HeaderText = "قیمت کل";
            dataGridViewX3.Columns[9].HeaderText = " تاریخ ثیت";
            dt = db.MySelect("select top 6 * from anbar");
            dataGridViewX4.DataSource = dt;
            dataGridViewX4.Columns[0].HeaderText = "کد";
            dataGridViewX4.Columns[1].HeaderText = "نام ";
            dataGridViewX4.Columns[2].HeaderText = "نوع انبار";
            dataGridViewX4.Columns[3].HeaderText = "انباردار";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonX1.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            Form_foroshandeh x = new Form_foroshandeh();
            x.ShowDialog();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            Form_tahvilgirandeh x = new Form_tahvilgirandeh();
            x.ShowDialog();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            Form_anbar x = new Form_anbar();
            x.ShowDialog();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            Form_kala x = new Form_kala();
            x.ShowDialog();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            Form_country x = new Form_country();
            x.ShowDialog();
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            Form_unit x = new Form_unit();
            x.ShowDialog();
        }

        private void labelItem1_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
        }

        private void labelItem2_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver;
        }

        private void labelItem3_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
        }

        private void labelItem4_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
        }

        private void labelItem5_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
        }

        private void labelItem6_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
        }

        private void labelItem7_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
        }

        private void labelItem9_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX1);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX2);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX4);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX3);
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure to exit?", "alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
            else { }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            Form_report_kala x = new Form_report_kala();
            x.ShowDialog();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            Form_report_foroshandeh x = new Form_report_foroshandeh();
            x.ShowDialog();
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            Form_report_tahvilgirandeh x = new Form_report_tahvilgirandeh();
            x.ShowDialog();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            Form_report_mojodi x = new Form_report_mojodi();
            x.ShowDialog();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            Form_factor x = new Form_factor();
            x.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Form_foroshandeh x = new Form_foroshandeh();
            x.ShowDialog();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Form_tahvilgirandeh x = new Form_tahvilgirandeh();
            x.ShowDialog();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            Form_kala x = new Form_kala();
            x.ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Form_anbar x = new Form_anbar();
            x.ShowDialog();
        }

        private void buttonItem7_Click_1(object sender, EventArgs e)
        {
            Form_unit x = new Form_unit();
            x.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            Form_country x = new Form_country();
            x.ShowDialog();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            Form_factor x = new Form_factor();
            x.ShowDialog();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            Form_report_mojodi x = new Form_report_mojodi();
            x.ShowDialog();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            Form_report_kala x = new Form_report_kala();
            x.ShowDialog();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            Form_report_foroshandeh x = new Form_report_foroshandeh();
            x.ShowDialog();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            Form_user_settings x = new Form_user_settings();
            x.ShowDialog();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            Form_user_settings x = new Form_user_settings();
            x.ShowDialog();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            about x = new about();
            x.ShowDialog();
        }
    }
}
