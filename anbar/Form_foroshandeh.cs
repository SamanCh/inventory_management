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
    public partial class Form_foroshandeh : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb;Persist Security Info=True");
        OleDbDataAdapter da = new OleDbDataAdapter("", con);
        DataSet ds = new DataSet();

        public Form_foroshandeh()
        {
            InitializeComponent();
        }
        string nam, famil;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text == "" || textBoxX3.Text == "" || textBoxX4.Text == "" || textBoxX5.Text == "")
            {
                MessageBox.Show("پرشون کن");
            }
            else
            {
                ds.Clear();
                da.SelectCommand.CommandText = "select name,family from foroshandeh where name='" + textBoxX2.Text + "'and family='" + textBoxX3.Text + "'";
                da.Fill(ds, "d1");
                if (ds.Tables["d1"].Rows.Count > 0)
                {
                    DialogResult d = MessageBox.Show("این رکورد قبلا ثبت شده است ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxX2.Clear();
                    textBoxX3.Clear();
                    textBoxX4.Clear();
                    textBoxX5.Clear();

                }
                else
                {
                    DataBase db = new DataBase();
                    db.DoCommand("insert into foroshandeh(name,family,tel,address) values('" + textBoxX2.Text + "','" + textBoxX3.Text + "','" + textBoxX4.Text + "','" + textBoxX5.Text + "')");
                    Form_foroshandeh_Load(sender, e);
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[dataGridViewX1.RowCount - 2].Cells[0];
                    MessageBox.Show("Inserted");
                }
            }
        }

        private void Form_foroshandeh_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //'sakhte yek nemoone az class DataBase
            DataBase db = new DataBase();
            //'seda zadan function==>MySelect baraye jostejoo dar bank
            dt = db.MySelect("select * from foroshandeh");
            dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "نام ";
            dataGridViewX1.Columns[2].HeaderText = "نام خانوادگی";
            dataGridViewX1.Columns[3].HeaderText = "تلفن";
            dataGridViewX1.Columns[4].HeaderText = "آدرس";
        }

        private void dataGridViewX1_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxX2.Text = dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX3.Text = dataGridViewX1[2, dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX4.Text = dataGridViewX1[3, dataGridViewX1.CurrentRow.Index].Value.ToString();
            textBoxX5.Text = dataGridViewX1[4, dataGridViewX1.CurrentRow.Index].Value.ToString();
            nam = textBoxX2.Text;
            famil = textBoxX3.Text;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            db.DoCommand("update foroshandeh set name='" + textBoxX2.Text + "',family='" + textBoxX3.Text + "',tel='" + textBoxX4.Text + "',address='" + textBoxX5.Text + "' where name='" + nam + "' and family='" + famil + "'");
            //'UPDATE DATAGRID
            Form_foroshandeh_Load(sender, e);
            MessageBox.Show("Updated"); 
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataBase db = new DataBase();
                db.DoCommand("delete from foroshandeh where name='" + textBoxX2.Text + "' and family='" + textBoxX3.Text + "'");
                //'update datagrid
                Form_foroshandeh_Load(sender, e);
                MessageBox.Show("Deleted");
            }
            else { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string str = "select * from foroshandeh where ";

            //'inja deghat konid ke mitavan faghat ghesmati az name ra nevesht va jostejoo kard 
            if (textBoxX2.Text != "") str += "name like '%" + textBoxX2.Text + "' and ";

            if (textBoxX3.Text != "") str += "family='" + textBoxX3.Text + "' and ";
            if (textBoxX4.Text != "") str += "tel='" + textBoxX4.Text + "' and ";
            //'inja str control mishavad va , and akhari bardashte mishavad
            if (str == "select * from foroshandeh where ")
                str = "select * from foroshandeh";
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
