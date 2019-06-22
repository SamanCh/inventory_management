using System;
using System.Data;
using System.Data.OleDb;

namespace anbar
{
    public class DataBase
    {
        private OleDbCommand cmd;
        private OleDbConnection con;
        private OleDbDataAdapter da;
        private DataTable dt; 

        //for sql
        /*
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataAdapter da;
        private DataTable dt;
        */

        public DataBase()
        {
        }

        public void DoCommand(string ole)
        {
            con = new OleDbConnection();
            //for sql
            //con=new SqlConnection();

            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb;Persist Security Info=True";
            //for sql
            //con.ConnectionString="server=(local);trusted_connection=yes;database=telephon;";

            cmd = new OleDbCommand();
            //for sql
            //cmd=new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = ole;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable MySelect(string sql)
        {
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb;Persist Security Info=True;";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            cmd.CommandText = sql;
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}