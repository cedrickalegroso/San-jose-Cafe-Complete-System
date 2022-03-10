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
    public partial class Assistant : Form
    {

        public Assistant()
        {
            InitializeComponent();
        }

        private SQLiteDataAdapter sql_adptr;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataReader sql_dbr;
        public static string authFirstName;
        public static string authLastName;
        public static int authGuard;
        public static int authID;

        // CreatePatient
        public static int newlyCreatedID;


        private static string edFNVAL;
        private static string edLNVAL;
        private static string edGenVAL;
        private static string edAddVAL;
        private static string edBdayVAL;

        private static string authUserPass;
        private static string authUserVal;


        // Add New Session Meds
        // public static string selectedMedID;
        private DataSet DSPATIENT = new DataSet();
        private DataTable DTPATIENT = new DataTable();


        // View Session Meds
        // public static string selectedMedID;
        private DataSet DSSTAFF = new DataSet();
        private DataTable DTSTAFF = new DataTable();



        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }


        private void getData()
        {
            // MessageBox.Show(SJCAUTH.hostID.ToString(), "getAuthData");

            string txtQuery = "SELECT * FROM Staff WHERE SJCS_ID = '" + SJCAUTH.hostID + "' ";

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


            sql_con.Close();
        }

        private void LoadComboBox()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Patient
            string CommandText = "SELECT SJCP_ID, SJCP_LastName || ', ' || SJCP_FirstName || ' AND ' ||  SJCS_LastName || ', ' || SJCS_FirstName AS NameStaff,  SJCS_ID, SJCSPR_ID FROM PATIENT  INNER JOIN Staff  INNER JOIN Staff_Patient  WHERE SJCSPR_Patient = SJCP_ID  AND SJCSPR_Staff = SJCS_ID";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSPATIENT.Reset();
            sql_adptr.Fill(DSPATIENT);
            DTPATIENT = DSPATIENT.Tables[0];
            // pddgv.DataSource = DTPATIENT;




            patientcbx.DataSource = DTPATIENT;
            patientcbx.DisplayMember = "NameStaff";
            patientcbx.ValueMember = "SJCSPR_ID";




            sql_con.Close();
        }



        private void setDashNames()
        {
            dashbboardTopName.Text = authLastName + ", " + authFirstName;
        }


        private void Assistant_Load(object sender, EventArgs e)
        {
            getData();
            setDashNames();
            LoadComboBox();
            adt2.Format = DateTimePickerFormat.Time;
            adt2.ShowUpDown = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoadComboBox();
            tabControl1.SelectedIndex = 0;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            getDataandInfo();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }


        private void getDataandInfo()
        {
            string txtQuery = "SELECT * FROM Staff WHERE SJCS_ID = '" + SJCAUTH.hostID + "' ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

                edFNVAL = sql_dbr.GetString(1);
                edLNVAL = sql_dbr.GetString(2);
                edBdayVAL = sql_dbr.GetString(3);
                edAddVAL = sql_dbr.GetString(4);
                edGenVAL = sql_dbr.GetString(5);


                authUserPass = sql_dbr.GetString(6);

                authUserVal = sql_dbr.GetString(7);

                count = count + 1;

            }


            edFN.Text = edFNVAL;
            edLN.Text = edLNVAL;
            edBday.Text = edBdayVAL;
            edAdd.Text = edAddVAL;
            edGen.Text = edGenVAL;

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

        private void button25_Click(object sender, EventArgs e)
        {
            string txtQuery = "update Staff set SJCS_FirstName = '" + edFN.Text + "',  SJCS_LastName = '" + edLN.Text + "',  SJCS_BirthDay = '" + edBday.Value.ToShortDateString() + "',  SJCS_Address = '" + edAdd.Text + "',  SJCS_Gender = '" + edGen.Text + "' WHERE SJCS_ID = '" + authID + "' ";
            executeQuery(txtQuery);
            getDataandInfo();
         
            MessageBox.Show("Information updated", "Successfull");
        }

        private void button26_Click(object sender, EventArgs e)
        {

            if (authPas.Text == authPasVer.Text)
            {

                if (authPasCur.Text == authUserVal)
                {


                    if (authUsern.Text == "Username")
                    {
                        string txtQuery = "update Staff set SJCS_AuthPass = '" + authPas.Text + "'  WHERE SJCS_ID = '" + authID + "' ";
                        executeQuery(txtQuery);
                        getDataandInfo();
                        MessageBox.Show("Auth Credential updated", "Successfull");
                    }
                    else
                    {
                        string txtQuery = "update Staff set SJCS_AuthUser = '" + authUsern.Text + "', SJCS_AuthPass = '" + authPas.Text + "'  WHERE SJCS_ID = '" + authID + "' ";
                        executeQuery(txtQuery);
                        getDataandInfo();
                     
                        MessageBox.Show("Auth Credential updated", "Successfull");
                    }



                }
                else
                {
                    MessageBox.Show("Wrong Current Password", "Error");
                }



            }
            else
            {
                MessageBox.Show("Password Mismatch", "Error");
            }


        }

        private void button17_Click(object sender, EventArgs e)
        {
          // MessageBox.Show(patientcbx.SelectedValue.ToString());


            string txtQuery = "INSERT into Appointments (SJCA_StaffPatientID, SJCA_Schedule, SJCA_Time, isActive) values ('" + patientcbx.SelectedValue + "',  '" + adt.Value.ToShortDateString() + "', '" + adt2.Value.ToShortTimeString() + "', '" + 1 + "')";

            executeQuery(txtQuery);


            MessageBox.Show("New Appointment Added", "Success!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void addNewPatientSubmit_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Patient (SJCP_FirstName, SJCP_LastName, SJCP_Birthday, SJCP_Address, SJCP_Gender, SJCP_PatientData, SJCP_DateRegistered, SJCP_isArchive) values ('" + addNewPatientFN.Text + "', '" + addNewPatientLN.Text + "', '" + addNewPatientDT.Value.ToShortDateString() + "', '" + addNewPatientADD.Text + "', '" + addNewPatientGEN.Text + "', '" + addNewPatientDATA.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + 0 + "')";

            executeQuery(txtQuery);
            getLatestID();


        }


        private void registerPatientToStaff(int i)
        {
            string txtQuery = "INSERT into Staff_Patient (SJCSPR_Staff, SJCSPR_Patient, isActive) values ('" + authID + "', '" + i + "', 1)";

            executeQuery(txtQuery);
            MessageBox.Show("New Patient Added", "Success!");
        }



        private void addNewPatientFN_Enter(object sender, EventArgs e)
        {
            if (addNewPatientFN.Text == "First Name")
            {
                addNewPatientFN.Text = "";
            }
        }

        private void addNewPatientFN_Leave(object sender, EventArgs e)
        {
            if (addNewPatientFN.Text == "")
            {
                addNewPatientFN.Text = "First Name";
            }
        }

        private void addNewPatientLN_Enter(object sender, EventArgs e)
        {
            if (addNewPatientLN.Text == "Last Name")
            {
                addNewPatientLN.Text = "";
            }
        }

        private void addNewPatientLN_Leave(object sender, EventArgs e)
        {
            if (addNewPatientLN.Text == "")
            {
                addNewPatientLN.Text = "Last Name";
            }
        }

        private void addNewPatientADD_Enter(object sender, EventArgs e)
        {
            if (addNewPatientADD.Text == "Address")
            {
                addNewPatientADD.Text = "";
            }
        }

        private void addNewPatientADD_Leave(object sender, EventArgs e)
        {
            if (addNewPatientADD.Text == "")
            {
                addNewPatientADD.Text = "Address";
            }
        }

        private void addNewPatientGEN_Enter(object sender, EventArgs e)
        {
            if (addNewPatientGEN.Text == "Gender")
            {
                addNewPatientGEN.Text = "";
            }
        }

        private void addNewPatientGEN_Leave(object sender, EventArgs e)
        {
            if (addNewPatientGEN.Text == "")
            {
                addNewPatientGEN.Text = "Gender";
            }
        }

        private void addNewPatientDATA_Enter(object sender, EventArgs e)
        {
            if (addNewPatientDATA.Text == "Patient Data")
            {
                addNewPatientDATA.Text = "";
            }
        }

        private void addNewPatientDATA_Leave(object sender, EventArgs e)
        {
            if (addNewPatientDATA.Text == "")
            {
                addNewPatientDATA.Text = "Patient Data";
            }
        }

        private void resetAddPatientTexts()
        {
            addNewPatientFN.Text = "First Name";
            addNewPatientLN.Text = "Last Name";
            addNewPatientADD.Text = "Address";
            addNewPatientGEN.Text = "Gender";
            addNewPatientDATA.Text = "Patient Data";
        }




        private void getLatestID()
        {
            string txtQuery = "SELECT * FROM Patient ORDER BY SJCP_ID DESC LIMIT 1 ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {



                newlyCreatedID = sql_dbr.GetInt32(0);


                count = count + 1;


            }

            registerPatientToStaff(newlyCreatedID);
            sql_con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
