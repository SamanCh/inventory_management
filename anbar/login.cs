using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace anbar
{
    public partial class login : Form
    {
        static OleDbConnection con = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=database.mdb;jet oledb:Database Password=☺☻♥♦♣♠");
        OleDbDataAdapter da = new OleDbDataAdapter("", con);
        DataSet ds = new DataSet();

        public login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonX2.Text = DateTime.Now.ToLongTimeString();
        }

        private void login_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar dtePersianCalendar = new System.Globalization.PersianCalendar();
            System.String Year, Month, Day, strResult;
            DateTime Date_Now = DateTime.Now;
            //-----------------------------------------------------------------------------
            Year = dtePersianCalendar.GetYear(Date_Now).ToString();
            Month = dtePersianCalendar.GetMonth(Date_Now).ToString();
            Day = dtePersianCalendar.GetDayOfMonth(Date_Now).ToString();
            strResult = Year + "/" + Month + "/" + Day;
            buttonX1.Text = strResult;
            comboBoxEx1.SelectedIndex = 0;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            string type;
            if (comboBoxEx1.SelectedIndex == 0) type = "admin";
            else type = "user";
            string s = "select id from login where type='" + type + "'and users='" + textBoxX1.Text + "' and id='" + textBoxX2.Text + "' ";
            OleDbDataAdapter da = new OleDbDataAdapter(s, con);
            da.Fill(ds, "t1");
            if (ds.Tables["t1"].Rows.Count > 0)
            {
                if (comboBoxEx1.SelectedIndex == 0)
                    variable.i = 1;
                else
                    variable.i = 2;
                    
                this.Hide();
                main fm = new main();
                fm.ShowDialog();

            }
            else
            {
                MessageBox.Show("رمز عبور یا نام کاربری اشتباه می باشد", "اخطار");
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                buttonX3_Click(sender,e);
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonX3_Click(sender, e);
        }
    }
}
