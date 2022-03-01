using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SJC
{
    public partial class SJCAUTH : Form
    {
        public SJCAUTH()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataReader sql_dbr;
        public static string setdashname;
        public static int authaccess;
        public static int hostID;

        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }

        private void Authenticate(string txtQuery)
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {
                authaccess = sql_dbr.GetInt32(8);
                hostID = sql_dbr.GetInt32(0);
                count = count + 1;

            }
            if (count == 1)

            {

                setdashname = SJCAUTHTXTUSER.Text; // Name


                //MessageBox.Show("GOODS LODS", "login page");


                dashboard dash = new dashboard();
                this.Hide();
                dash.ShowDialog();
                this.Close();

            }

            else if (count > 1)

            {
                MessageBox.Show("Duplicate username and password", "login page");
            }

            else

            {
                MessageBox.Show(" username and password incorrect", "login page");
            }
            sql_con.Close();
        }



        private void BTNAUTHLOGIN_Click(object sender, EventArgs e)
        {
            string txtQuery = "SELECT * FROM Staff WHERE SJCS_AuthUser = '" + SJCAUTHTXTUSER.Text + "' AND SJCS_AuthPass = '" + SJCAUTHTXTPASS.Text + "' ";
            Authenticate(txtQuery);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FeatureMaster dev = new FeatureMaster();
            this.Hide();
            dev.ShowDialog();
            this.Close();
        }
    }
}
