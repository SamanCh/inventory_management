using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace anbar
{
    public partial class Form_kala : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb;Persist Security Info=True");
        OleDbDataAdapter da = new OleDbDataAdapter("", con);
        DataSet ds = new DataSet();
        public Form_kala()
        {
            InitializeComponent();
        }
        string nam;

        private void Form_kala_Load(object sender, EventArgs e)
        {

            System.Globalization.PersianCalendar dtePersianCalendar = new System.Globalization.PersianCalendar();
            System.String Year, Month, Day, strResult;
            DateTime Date_Now = DateTime.Now;
            //-----------------------------------------------------------------------------
            Year = dtePersianCalendar.GetYear(Date_Now).ToString();
            Month = dtePersianCalendar.GetMonth(Date_Now).ToString();
            Day = dtePersianCalendar.GetDayOfMonth(Date_Now).ToString();
            strResult = Year + "/" + Month + "/" + Day;
            textBoxX3.Text = strResult;

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
            dataGridViewX1.Columns[9].HeaderText = " شماره رسید";

            DataTable dt2 = new DataTable();
            DataBase db2 = new DataBase();

            dt2=db2.MySelect("select * from country");
            comboBoxEx1.DataSource = dt2;
            comboBoxEx1.DisplayMember = "name";

            dt2 = db2.MySelect("select * from unit");
            comboBoxEx2.DataSource = dt2;
            comboBoxEx2.DisplayMember = "name";

            dt2 = db2.MySelect("select name from anbar");
            comboBoxEx3.DataSource = dt2;
            comboBoxEx3.DisplayMember = "name";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || textBoxX4.Text == "" || textBoxX6.Text == "")
            {
                MessageBox.Show("پرشون کن");
            }
            else
            {
                int sum = int.Parse(textBoxX4.Text) * int.Parse(textBoxX6.Text);
                string s = sum.ToString();
                DataBase db3 = new DataBase();
                db3.DoCommand("insert into kala(name,des,country,anbar,cter,unit,unitprice,totalprice,tarikh) values('" + textBoxX1.Text + "','" + textBoxX2.Text + "','" + comboBoxEx1.Text + "','" + comboBoxEx3.Text + "','" + textBoxX4.Text + "','" + comboBoxEx2.Text + "','" + textBoxX6.Text + "','" + s + "','" + textBoxX3.Text + "')");
                Form_kala_Load(sender, e);
                dataGridViewX1.CurrentCell = dataGridViewX1.Rows[dataGridViewX1.RowCount - 2].Cells[0];
                MessageBox.Show("Inserted");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            int sum = int.Parse(textBoxX4.Text) * int.Parse(textBoxX6.Text);
            string s = sum.ToString();
            db.DoCommand("update kala set name='" + textBoxX1.Text + "',des='" + textBoxX2.Text + "',country='" + comboBoxEx1.Text +"',anbar='" + comboBoxEx3.Text + "',cter='" + textBoxX4.Text + "',unit='" + comboBoxEx2.Text+"',unitprice='"+textBoxX6.Text+"',totalprice='"+s+"',tarikh='"+textBoxX3.Text+ "' where name='" + nam + "'");
            Form_kala_Load(sender, e);
            MessageBox.Show("Updated"); 
        }

        private void dataGridViewX1_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxX1.Text = dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX2.Text = dataGridViewX1[2, dataGridViewX1.CurrentRow.Index].Value.ToString();
            comboBoxEx1.Text = dataGridViewX1[3, dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX4.Text = dataGridViewX1[5, dataGridViewX1.CurrentRow.Index].Value.ToString();
            comboBoxEx2.Text = dataGridViewX1[6, dataGridViewX1.CurrentRow.Index].Value.ToString();
            comboBoxEx3.Text=dataGridViewX1[4,dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX6.Text = dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX3.Text = dataGridViewX1[9, dataGridViewX1.CurrentRow.Index].Value.ToString();
            nam = textBoxX1.Text;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataBase db = new DataBase();
                db.DoCommand("delete from kala where name='" + textBoxX1.Text + "'");
                Form_kala_Load(sender, e);
                MessageBox.Show("Deleted");
            }
            else { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string str = "select * from kala where ";
            if (textBoxX1.Text != "") str += "name like '%" + textBoxX1.Text + "' and ";

            if (textBoxX2.Text != "") str += "des='" + textBoxX2.Text + "' and ";
            if (comboBoxEx1.Text != "") str += "country='" + comboBoxEx1.Text + "' and ";
            if (str == "select * from kala where ")
                str = "select * from kala";
            else
                str = str.Remove(str.Length - 4, 4);
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect(str);
            MessageBox.Show(dt.Rows.Count.ToString() + " Rows founded.");
            dataGridViewX1.DataSource = dt;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX1);
        }

        private void textBoxX6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            if (!System.Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("لطفا عدد وارد کنید", "هشدار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void textBoxX4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            if (!System.Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("لطفا عدد وارد کنید", "هشدار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
