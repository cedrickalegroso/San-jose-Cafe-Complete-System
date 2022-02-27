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
    public partial class livequeue : Form
    {

        public String txtval { get; set; }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataReader sql_dbr;
        public static string authFirstName;
        public static string authLastName;
        public static int authGuard;
        public static int authID;


        public static int prevp1IDz;
        public static int p1IDz;
        public static string p1Namez;
        public static string p1Schedz;


        public livequeue()
        {
            InitializeComponent();
        }

        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }

        private void getAuthData()
        {
            string txtQuery = "SELECT * FROM Staff WHERE SJCS_ID = '" + 2 + "' ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

                authFirstName = sql_dbr.GetString(1);
                authLastName = sql_dbr.GetString(2);


                authGuard = sql_dbr.GetInt32(8);
                authID = sql_dbr.GetInt32(0);
                count = count + 1;

            }
            if (count == 1)

            {






            }

            else if (count > 1)

            {
                MessageBox.Show("There was an error fetching your account", "login page");
            }

            else

            {
                MessageBox.Show("There was an error fetching your account", "login page");
            }

            doc.Text = " Please proceed to Dr. " + authLastName +", " + authFirstName + " office. ";
            sql_con.Close();
        }

        public void update()
        { 
            // Deprecated
           //string txtQuery = "SELECT * FROM Appointments WHERE isActive = 1 AND  SJCA_Staff = '" + authID + "' AND  SJCA_Schedule = '" + DateTime.Now.ToShortDateString() + "' LIMIT 3 ";

           // setConnection();
           // sql_con.Open();
           // sql_cmd = sql_con.CreateCommand();
           // sql_cmd.CommandText = txtQuery;
           // sql_cmd.ExecuteNonQuery();
           // sql_dbr = sql_cmd.ExecuteReader();
           // int count = 0;
           // while (sql_dbr.Read())
           // {

                

           //     if (count == 0)
           //     {
           //         p1IDz = sql_dbr.GetInt32(2);
           //         p1Schedz = sql_dbr.GetString(3);
           //     }

           //     count = count + 1;


           // }
           // patient1Data(p1IDz);
      
           // sql_con.Close();
        }


        private void patient1Data(int i)
        {
          
            string txtQuery = "SELECT * FROM Patient WHERE SJCP_ID = '" + i + "' ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

                p1Namez = sql_dbr.GetString(2) + ", " + sql_dbr.GetString(1);
                count = count + 1;

            }

          
            textBox1.Text = p1Namez;


            prevp1IDz = i;
            sql_con.Close();
        }

        public void fetch()
        {
           
            getAuthData();
            update();
            button1.PerformClick();
        }

    
        public void livequeue_Load(object sender, EventArgs e)
        {
           
            fetch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
