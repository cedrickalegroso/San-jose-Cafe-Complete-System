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
    public partial class FeatureMaster : Form
    {
        public FeatureMaster()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataReader sql_dbr;

        private SQLiteDataAdapter sql_adptr;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        // Patient
        private DataSet DSP = new DataSet();
        private DataTable DTP = new DataTable();

        // SPR
        private DataSet DSSPR = new DataSet();
        private DataTable DTSPR = new DataTable();

        // A
        private DataSet DSA = new DataSet();
        private DataTable DTA = new DataTable();

        // D
        private DataSet DSD = new DataSet();
        private DataTable DTD = new DataTable();


        // pr
        private DataSet DSPR = new DataSet();
        private DataTable DTPR = new DataTable();

        // Patient CARD


        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }


        private void LoadStudents()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select * from Staff";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            sql_adptr.Fill(DS);
            DT = DS.Tables[0];
            devdvg1.DataSource = DT;

            cbs.DataSource = DT;
            cbs.DisplayMember = "Staff";
            cbs.ValueMember = "SJCS_ID";

            pst.DataSource = DT;
            pst.DisplayMember = "Staff";
            pst.ValueMember = "SJCS_ID";

      

            sql_con.Close();
        }


        private void LoadPatients()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select * from Patient";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSP.Reset();
            sql_adptr.Fill(DSP);
            DTP = DSP.Tables[0];
            pdgv.DataSource = DTP;


            cbp.DataSource = DTP;
            cbp.DisplayMember = "Patient";
            cbp.ValueMember = "SJCP_ID";


            ppa.DataSource = DTP;
            ppa.DisplayMember = "Patient";
            ppa.ValueMember = "SJCP_ID";


            sql_con.Close();
        }

        private void LoadSPR()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select * from Staff_Patient";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSSPR.Reset();
            sql_adptr.Fill(DSSPR);
            DTSPR = DSSPR.Tables[0];
            sprgdv.DataSource = DTSPR;

            acb.DataSource = DTSPR;
            acb.DisplayMember = "Staff";
            acb.ValueMember = "SJCSPR_ID";

            sql_con.Close();
        }

        private void LoadA()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select * from Appointments";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSA.Reset();
            sql_adptr.Fill(DSA);
            DTA = DSA.Tables[0];
            advg.DataSource = DTA;


            dpa.DataSource = DTP;
            dpa.DisplayMember = "Patient";
            dpa.ValueMember = "SJCP_ID";

            dst.DataSource = DT;
            dst.DisplayMember = "Staff";
            dst.ValueMember = "SJCS_ID";

            sql_con.Close();
        }


        private void LoadD()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select * from Diagnosis";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSD.Reset();
            sql_adptr.Fill(DSD);
            DTD = DSD.Tables[0];
            ddgv.DataSource = DTD;

            sql_con.Close();
        }

        private void LoadPR()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select * from Prescriptions";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSPR.Reset();
            sql_adptr.Fill(DSPR);
            DTPR = DSPR.Tables[0];
            pddgv.DataSource = DTPR;

            sql_con.Close();
        }

        private void executeQuery(string txtQuery)
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void FeatureMaster_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadPatients();
            LoadSPR();
            LoadA();
            LoadD();
            LoadPR();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Staff (SJCS_Firstname, SJCS_Lastname, SJCS_Birthday, SJCS_Address, SJCS_Gender, SJCS_AuthUser, SJCS_AuthPass, SJCS_AuthGuard ) values ('" + fn.Text + "', '" + ln.Text + "', '" + bd.Text + "', '" + ad.Text + "', '" + ge.Text + "', '" + us.Text + "',  '" + pa.Text + "',  '" + au.Text + "')";
           
            executeQuery(txtQuery);
   
            LoadStudents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SJCAUTH form = new SJCAUTH();

            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Patient (SJCP_Firstname, SJCP_Lastname, SJCP_Birthday, SJCP_Address, SJCP_Gender ) values ('" + pfn.Text + "', '" + pln.Text + "', '" + pbd.Text + "', '" + pad.Text + "', '" + pge.Text + "')";

            executeQuery(txtQuery);

            LoadPatients();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Staff_Patient (SJCSPR_Staff, SJCSPR_Patient) values ('" + cbs.Text + "', '" + cbp.Text + "')";

            executeQuery(txtQuery);

            LoadSPR();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Appointments (SJCA_StaffPatientID, SJCA_Schedule, isActive) values ('" + acb.Text + "',  '" + adt.Value.ToShortDateString() + "', '" + 1 + "')";

            executeQuery(txtQuery);

            LoadA();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Diagnosis (SJCD_Staff, SJCD_Patient, SJCD_Diagnosis, SJCD_Description, SJCD_Date) values ('" + dst.Text + "', '" + dpa.Text + "', '" + ddi.Text + "', '" + dde.Text + "', '" + ddt.Value.ToShortDateString() + "')";

            executeQuery(txtQuery);

            LoadD();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Prescriptions (SJCPS_From, SJCPS_To, SJCPS_Prescriptions, SJCPS_Count, SJCPS_Sched) values ('" + pst.Text + "', '" + ppa.Text + "', '" + ppr.Text + "', '" + pco.Text + "', '" + pdt.Value.ToShortDateString() + "')";

            executeQuery(txtQuery);

            LoadPR();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(adt.Value.ToString());
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

      
    }
}
