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
    public partial class Form_newfactor : Form
    {
        string shfact;
        string a;
        int index;
        public Form_newfactor()
        {
            InitializeComponent();
        }
        private void Form_newfactor_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select name from foroshandeh");
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "name";
            dt = db.MySelect("select name from tahvilgirandeh");
            comboBoxEx2.DataSource = dt;
            comboBoxEx2.DisplayMember = "name";
            dt = db.MySelect("select name from anbar");
            comboBoxEx3.DataSource = dt;
            comboBoxEx3.DisplayMember = "name";
            dt = db.MySelect("select name from kala where anbar='"+comboBoxEx3.Text+"'");
            comboBoxEx4.DataSource = dt;
            comboBoxEx4.DisplayMember = "name";
            dt = db.MySelect("select unitprice from kala where name='"+comboBoxEx4.Text+"'");
            comboBoxEx5.DataSource = dt;
            comboBoxEx5.DisplayMember = "unitprice";

            System.Globalization.PersianCalendar dtePersianCalendar = new System.Globalization.PersianCalendar();
            System.String Year, Month, Day, strResult;
            DateTime Date_Now = DateTime.Now;
            //-----------------------------------------------------------------------------
            Year = dtePersianCalendar.GetYear(Date_Now).ToString();
            Month = dtePersianCalendar.GetMonth(Date_Now).ToString();
            Day = dtePersianCalendar.GetDayOfMonth(Date_Now).ToString();
            strResult = Year + "/" + Month + "/" + Day;
            textBoxX2.Text = strResult;
        }

        void show()
        {
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select *from aghlam  where shfact='" + textBoxX1.Text + "'");
            dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "کد فاکتور";
            dataGridViewX1.Columns[2].HeaderText = "نام ";
            dataGridViewX1.Columns[3].HeaderText = "توضیحات";
            dataGridViewX1.Columns[4].HeaderText = "کشور سازنده";
            dataGridViewX1.Columns[5].HeaderText = " نام انبار";
            dataGridViewX1.Columns[6].HeaderText = "تعداد";
            dataGridViewX1.Columns[7].HeaderText = "واحد";
            dataGridViewX1.Columns[8].HeaderText = "قیمت واحد";
            dataGridViewX1.Columns[9].HeaderText = "قیمت کل";
            dataGridViewX1.Columns[10].HeaderText = " تاریخ ثیت";

            dt = db.MySelect("select cter from kala where name='" + comboBoxEx4.Text + "'");
            //    dataGridViewX2.Visible = false;
            dataGridViewX2.DataSource = dt;
            textBoxX5.Text = dataGridViewX2[0, 0].Value.ToString();
        }
        private void comboBoxEx4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt5 = new DataTable();
            DataBase db = new DataBase();
            dt5 = db.MySelect("select cter from kala where name='" + comboBoxEx4.Text + "'");
            dataGridViewX2.DataSource = dt5;
            textBoxX5.Text = dataGridViewX2[0, 0].Value.ToString();

            DataTable dt6 = new DataTable();
            dt6 = db.MySelect("select unitprice from kala where name='" + comboBoxEx4.Text + "'");
            comboBoxEx5.DataSource = dt6;
            comboBoxEx5.DisplayMember = "unitprice";


            DataTable dt7 = new DataTable();
            dt7 = db.MySelect("select id from kala where name='" + comboBoxEx4.Text + "'");
            dataGridViewX3.DataSource = dt7;
            textBoxX3.Text = dataGridViewX3[0, 0].Value.ToString();
            
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt4 = new DataTable();
            DataBase db = new DataBase();
            dt4 = db.MySelect("select name from kala where anbar='" + comboBoxEx3.Text + "'");
            comboBoxEx4.DataSource = dt4;
            comboBoxEx4.DisplayMember = "name";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
                DataBase db = new DataBase();
                dt = db.MySelect("select shfact from aghlam where shfact='" + textBoxX1.Text + "' and name='" + comboBoxEx4.Text + "' ");
                if (dt.Rows.Count > 0)
                    MessageBox.Show("این کالا قبلا وارد شده است");
                else{
                dt = db.MySelect("select id from kala where name='"+comboBoxEx4.Text+"'");
            dataGridViewX3.DataSource=dt;
            textBoxX3.Text = dataGridViewX3[0, 0].Value.ToString();
                int t = 0;
                t = int.Parse(comboBoxEx5.Text) * int.Parse(textBoxX4.Text);
                db.DoCommand("insert into aghlam(name,des,country,anbar,unit,unitprice,tarikh,cter,totalprice,shfact,id) select name,des,country,anbar,unit,unitprice,tarikh, '" + textBoxX4.Text + "' as cter,  '" + t.ToString() + "' as totalprice,  '" + textBoxX1.Text + "' as shfact,  '" + textBoxX3.Text + "' as id from kala where name='" + comboBoxEx4.Text + "'");
                DataTable dt5 = new DataTable();
                DataBase db2 = new DataBase();
                dt5 = db2.MySelect("select *from aghlam  where shfact='"+textBoxX1.Text+"'");
                dataGridViewX1.DataSource = dt5;
                dataGridViewX1.Columns[0].HeaderText = "کد";
                dataGridViewX1.Columns[1].HeaderText = "کد فاکتور";
                dataGridViewX1.Columns[2].HeaderText = "نام ";
                dataGridViewX1.Columns[3].HeaderText = "توضیحات";
                dataGridViewX1.Columns[4].HeaderText = "کشور سازنده";
                dataGridViewX1.Columns[5].HeaderText = " نام انبار";
                dataGridViewX1.Columns[6].HeaderText = "تعداد";
                dataGridViewX1.Columns[7].HeaderText = "واحد";
                dataGridViewX1.Columns[8].HeaderText = "قیمت واحد";
                dataGridViewX1.Columns[9].HeaderText = "قیمت کل";
                dataGridViewX1.Columns[10].HeaderText = " تاریخ ثیت";
                    show();
                    }
            }

        private void dataGridViewX1_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxX4.Text=dataGridViewX1[6,dataGridViewX1.CurrentRow.Index].Value.ToString();
            comboBoxEx3.Text = dataGridViewX1[5, dataGridViewX1.CurrentRow.Index].Value.ToString();
            shfact = dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value.ToString();
            comboBoxEx4.Text = dataGridViewX1[2, dataGridViewX1.CurrentRow.Index].Value.ToString();
            index = dataGridViewX1.CurrentRow.Index;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataBase db = new DataBase();
                a = dataGridViewX1[2, index].Value.ToString();
                int b = 0;
                b = int.Parse(dataGridViewX1[6, index].Value.ToString());
                string fi;
                fi = dataGridViewX1[8, index].Value.ToString();
                db.DoCommand("delete from aghlam where name='" + a +"'and shfact='" + textBoxX1.Text + "'");
                show();
                string t;
                t = (dataGridViewX1.RowCount - 1).ToString();
                db.DoCommand("update factor set t_kala='"+t+"' where id='"+textBoxX1.Text+"'");
                DataTable dt = new DataTable();
                dt = db.MySelect("select id from factor where id='"+textBoxX1.Text+"'");
                if (dt.Rows.Count <= 0) { }
                else
                {
                    int totall = 0;
                    dt = db.MySelect("select cter from kala where name='" + a + "'");
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "cter";
                    int count;
                    int c;
                    c = int.Parse(comboBox1.Text);
                    count = c + b;//cter final
                    totall = count * int.Parse(fi);//totall price
                    db.DoCommand("update kala set cter='" + count.ToString() + "',totalprice='" + totall.ToString() + "' where name='" + a + "'");
                    show();
                }
            }
            else { }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || textBoxX2.Text == "" || textBoxX4.Text == "")
            {
                MessageBox.Show("پرشون کن");
            }
            else
            {
                buttonX1.Enabled = false;
                DataBase db = new DataBase();
                DataTable dt = new DataTable();
                dt = db.MySelect("select *from factor where id='" + textBoxX1.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("این فاکتور قبلا ثبت شده است");
                }
                else
                {
                    string t;
                    t = (dataGridViewX1.RowCount - 1).ToString();
                    db.DoCommand("insert into factor(id,seller,custumer,dt,num_res_anbar,t_kala) values('" + textBoxX1.Text + "','" + comboBoxEx1.Text + "','" + comboBoxEx2.Text + "','" + textBoxX2.Text + "','" + textBoxX6.Text + "','" + t + "')");
                    MessageBox.Show("ثبت شد", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < dataGridViewX1.RowCount - 1; i++)
                    {
                        a = dataGridViewX1[2, i].Value.ToString();
                        int b = 0;
                        b = int.Parse(dataGridViewX1[6, i].Value.ToString());
                        int totall = 0;
                        dt = db.MySelect("select cter from kala where name='" + a + "'");
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "cter";
                        int count;
                        int c;
                        c = int.Parse(comboBox1.Text);
                        count = c - b;//cter final
                        totall = count * int.Parse(dataGridViewX1[8, i].Value.ToString());//totall price
                        db.DoCommand("update kala set cter='" + count.ToString() + "',totalprice='" + totall.ToString() + "' where name='" + a + "'");

                    }
                }
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select id from factor where id='" + textBoxX1.Text + "'");
            if (dt.Rows.Count > 0){
                buttonX3.Enabled = false;
                buttonX1.Enabled = false;
                dt=db.MySelect("select num_res_anbar from factor where id='"+textBoxX1.Text+"'");
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "num_res_anbar";
                textBoxX6.Text = comboBox1.Text;
            }
            else{
                buttonX1.Enabled = true;
                buttonX3.Enabled = true;
            }
            dt = db.MySelect("select *from aghlam where shfact='" + textBoxX1.Text + "'");
            dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "کد فاکتور";
            dataGridViewX1.Columns[2].HeaderText = "نام ";
            dataGridViewX1.Columns[3].HeaderText = "توضیحات";
            dataGridViewX1.Columns[4].HeaderText = "کشور سازنده";
            dataGridViewX1.Columns[5].HeaderText = " نام انبار";
            dataGridViewX1.Columns[6].HeaderText = "تعداد";
            dataGridViewX1.Columns[7].HeaderText = "واحد";
            dataGridViewX1.Columns[8].HeaderText = "قیمت واحد";
            dataGridViewX1.Columns[9].HeaderText = "قیمت کل";
            dataGridViewX1.Columns[10].HeaderText = " تاریخ ثیت";
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ribbonClientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || textBoxX6.Text == "")
            {
                MessageBox.Show("پرشون کن");
            }
            else
            {

                DataBase db = new DataBase();
                db.DoCommand("update factor set id='" + textBoxX1.Text + "',seller='" + comboBoxEx1.Text + "',custumer='" + comboBoxEx2.Text + "',num_res_anbar='" + textBoxX6.Text + "' where id='" + textBoxX1.Text + "'");

                MessageBox.Show("ویرایش شد");
            }
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
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
