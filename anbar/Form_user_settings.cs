using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace anbar
{
    public partial class Form_user_settings : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb;Persist Security Info=True");
        OleDbDataAdapter da = new OleDbDataAdapter("", con);
        DataSet ds = new DataSet();

        public Form_user_settings()
        {
            InitializeComponent();
        }
        string nam;

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || textBoxX2.Text == "")
            {
                MessageBox.Show("پرشون کن");
            }
            else
            {
                string s;
                if (comboBoxEx1.SelectedIndex == 0)
                    s = "admin";
                else
                    s = "user";

                ds.Clear();
                da.SelectCommand.CommandText = "select id from login where id='" + textBoxX2.Text + "'";
                da.Fill(ds, "d1");
                if (ds.Tables["d1"].Rows.Count > 0)
                {
                    DialogResult d = MessageBox.Show("این رکورد قبلا ثبت شده است ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxX1.Clear();
                    textBoxX2.Clear();

                }
                else
                {
                    DataBase db = new DataBase();
                    db.DoCommand("insert into login(type,users,id) values('" + s + "','" + textBoxX1.Text + "','" + textBoxX2.Text + "')");
                    Form_user_settings_Load(sender, e);
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[dataGridViewX1.RowCount - 2].Cells[0];
                    MessageBox.Show("Inserted");
                }
            }
        }

        private void Form_user_settings_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            if (variable.i == 2)
            {
                buttonX1.Enabled = false;
                buttonX2.Enabled = false;
                buttonX3.Enabled = false;
                buttonX4.Enabled = false;
                dt = db.MySelect("select type,users from login");
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns[0].HeaderText = "دسترسی";
                dataGridViewX1.Columns[1].HeaderText = "نام کاربری";
            }
            else
            {

                dt = db.MySelect("select *from login");
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns[0].HeaderText = "دسترسی";
                dataGridViewX1.Columns[1].HeaderText = "نام کاربری";
                dataGridViewX1.Columns[2].HeaderText = "رمز عبور";
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string s;
            if (comboBoxEx1.SelectedIndex==0)
                s = "admin";
            else
                s = "user";
            DataBase db = new DataBase();
            db.DoCommand("update login set users='" + textBoxX1.Text + "',id='" + textBoxX2.Text + "',type='" + s + "' where users='" + nam + "'");
            Form_user_settings_Load(sender,e);
            MessageBox.Show("Updated"); 
        }

        private void dataGridViewX1_MouseUp(object sender, MouseEventArgs e)
        {
            if (variable.i == 2)
            {
                textBoxX1.Text = dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value.ToString();
                comboBoxEx1.Text = dataGridViewX1[0, dataGridViewX1.CurrentRow.Index].Value.ToString();
                if (comboBoxEx1.Text == "admin")
                    comboBoxEx1.Text = "مدیر";
                else
                    comboBoxEx1.Text = "کاربر";
                nam = textBoxX1.Text;
            }
            else
            {

                textBoxX1.Text = dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value.ToString();
                textBoxX2.Text = dataGridViewX1[2, dataGridViewX1.CurrentRow.Index].Value.ToString();
                comboBoxEx1.Text = dataGridViewX1[0, dataGridViewX1.CurrentRow.Index].Value.ToString();
                if (comboBoxEx1.Text == "admin")
                    comboBoxEx1.Text = "مدیر";
                else
                    comboBoxEx1.Text = "کاربر";
                nam = textBoxX1.Text;
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("are you sure to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataBase db = new DataBase();
                db.DoCommand("delete from login where id='" + textBoxX2.Text + "' and users='" + textBoxX1.Text + "'");
                Form_user_settings_Load(sender, e);
                MessageBox.Show("Deleted");
            }
            else { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string s;
            if (comboBoxEx1.SelectedIndex==0)
                s = "admin";
            else
                s = "user";

            string str = "select * from login where ";

            //'inja deghat konid ke mitavan faghat ghesmati az name ra nevesht va jostejoo kard 
            if (textBoxX1.Text != "") str += "users like '%" + textBoxX1.Text + "' and ";

            if (comboBoxEx1.Text != "") str += "type='" + s + "' and ";
            if (textBoxX2.Text != "") str += "users='" + textBoxX2.Text + "' and ";
            //'inja str control mishavad va , and akhari bardashte mishavad
            if (str == "select * from login where ")
                str = "select * from login";
            else
                str = str.Remove(str.Length - 4, 4);
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect(str);
            MessageBox.Show(dt.Rows.Count.ToString() + " Rows founded.");
            dataGridViewX1.DataSource = dt;
        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonX5_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridViewX1);
        }
    }
}
