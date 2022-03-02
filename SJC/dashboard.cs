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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataReader sql_dbr;
        public static string authFirstName;
        public static string authLastName;
        public static int authGuard;
        public static int authID;

        private static bool isCardOn = false;

        private static string emptyThis = "No Data";




        private SQLiteDataAdapter sql_adptr;


        // A
        private DataSet DSA = new DataSet();
        private DataTable DTA = new DataTable();

        public static int prevp1ID;
        public static int p1ID;
        public static string p1Name;
        public static string p1Sched;

        public static int prevp2ID;
        public static int p2ID;
        public static string p2Name;
        public static string p2Sched;

        public static int prevp3ID;
        public static int p3ID;
        public static string p3Name;
        public static string p3Sched;

        // Patient Card
        public static int patientCardIDVal;
        public static string patientCardNameVal;
        public static int patientCardStaffPatientVal;
        public static string patientCardAddVal;
        public static string patientCardBdayVal;

        // Patient Card Daignosis
        public static int diag1IDVal;
        public static string diag1NameVal;
        public static string diag1SchedVal;
        public static string diag1desVal;

        public static int diag2IDVal;
        public static string diag2NameVal;
        public static string diag2SchedVal;
        public static string diag2desVal;

        public static int diag3IDVal;
        public static string diag3NameVal;
        public static string diag3SchedVal;
        public static string diag3desVal;

        public static int diag4IDVal;
        public static string diag4NameVal;
        public static string diag4SchedVal;
        public static string diag4desVal;

        public static int diag5IDVal;
        public static string diag5NameVal;
        public static string diag5SchedVal;
        public static string diag5desVal;

        // Patient Card Prescriptions
        public static string selectedPresID;

        public static string pres1Val;
        public static int pres1CountVal;
        public static string pres1SchedVal;

        public static string pres2Val;
        public static int pres2CountVal;
        public static string pres2SchedVal;

        public static string pres3Val;
        public static int pres3CountVal;
        public static string pres3SchedVal;

        public static string pres4Val;
        public static int pres4CountVal;
        public static string pres4SchedVal;

        public static string pres5Val;
        public static int pres5CountVal;
        public static string pres5SchedVal;


        //sessions
        public static string GeneratedSessionID;
        public static string GeneratedSessionMedID;
        public static string GeneratedItemMedID;


        // Diagnoseses
        public static int patientDiagnoseID;
        private DataSet DSDIAG = new DataSet();
        private DataTable DTDIAG = new DataTable();

        // ViewPatientDashboard
        private static string patientSelectedID;
        private DataSet DSPATIENT = new DataSet();
        private DataTable DTPATIENT = new DataTable();

        // CreatePatient
        public static int newlyCreatedID;

        // EditPatient
        public static int editPatientIDVal;
        public static string editPatientFNVal;
        public static string editPatientLNVal;
        public static string editPatientAddVal;
        public static string editPatientBdayVal;
        public static string editPatientGenderVal;
        public static string editPatientDataVal;
        public static int editPatientisArchiveVal;


        // History Patient
        public static string historySelectedPatientID;
        public static int historyPatientIDVal;
        public static string historyPatientFNVal;
        public static string historyPatientLNVal;
        public static string historyPatientAddVal;
        public static string historyPatientBdayVal;
        public static string historyPatientGenderVal;
        public static string historyPatientDataVal;
        public static int historyPatientisArchiveVal;
        public static int historyPatientStaffPatient;

        // History Patient Diagnoseses
        private DataSet DSHISD = new DataSet();
        private DataTable DTHISD = new DataTable();


        // History Patient Diagnoseses
        private DataSet DSHISP = new DataSet();
        private DataTable DTHISP = new DataTable();

        // Meds
        public static string selectedMedID;
        private DataSet DSMeds = new DataSet();
        private DataTable DTMEds = new DataTable();

        // Meds
        public static string selectedMedOVRID;
        private DataSet DSOVRMeds = new DataSet();
        private DataTable DTOVRMEds = new DataTable();


        // Add New Session Meds
        // public static string selectedMedID;
        private DataSet DSAddMeds = new DataSet();
        private DataTable DTAddMEds = new DataTable();


        // View Session Meds
        // public static string selectedMedID;
        private DataSet DSViewMeds = new DataSet();
        private DataTable DTViewMeds = new DataTable();



        // ViewMeds
        public static int viewMedIDVal;
        public static string viewMedNameVal;
        public static string viewMedBrandVal;
        public static int viewMedStockVal;
        public static string viewMedDescVal;
        public static int viewMedisArchiveVal;

        // ViewDiagnoseses
        private DataSet DSVIEWPRES = new DataSet();
        private DataTable DTVIEWPRES = new DataTable();
        public static string viewDiagSessionVal;
        public static int viewDiagpatientVal;
        public static int viewDiagIDVal;
        public static string viewDiagNameVal;
        public static string viewDiagAddVal;
        public static string viewDiagSchedVal;
        public static string viewDiagTitleVal;
        public static string viewDiagDescVal;

        public static string shorteneddes1;
        public static string shorteneddes2;
        public static string shorteneddes3;
        public static string shorteneddes4;
        public static string shorteneddes5;



        public static string SelectedPatientStaffPatient;


        public static int appointMent1ID;
        public static int appointMent1IDVal;
        public static int appointMent2ID;
        public static int appointMent2IDVal;
        public static int appointMent3ID;
        public static int appointMent3IDVal;


        public static string historySelectedID;

        private static string SelectedAddnewMedID;
        private static string SelectedVewMedID;


        private static int addedMedInASessionCount;
        private static int addedViewMedInASessionCount;

        private static string edFNVAL;
        private static string edLNVAL;
        private static string edGenVAL;
        private static string edAddVAL;
        private static string edBdayVAL;

        private static string authUserPass;
        private static string authUserVal;
        

        private void button25_Click(object sender, EventArgs e)
        {
            string txtQuery = "update Staff set SJCS_FirstName = '" + edFN.Text + "',  SJCS_LastName = '" + edLN.Text + "',  SJCS_BirthDay = '" + edBday.Value.ToShortDateString() + "',  SJCS_Address = '" + edAdd.Text + "',  SJCS_Gender = '" + edGen.Text + "' WHERE SJCS_ID = '" + authID + "' ";
            executeQuery(txtQuery);
            getDataandInfo();
            dashboardTab.SelectedIndex = 11;
            MessageBox.Show("Information updated", "Successfull");
          
        }


        private void button24_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 12;
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

        private void button26_Click(object sender, EventArgs e)
        {


       

            if (authPas.Text == authPasVer.Text )
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
                        dashboardTab.SelectedIndex = 11;
                        MessageBox.Show("Auth Credential updated", "Successfull");
                    }



                } else
                {
                    MessageBox.Show("Wrong Current Password", "Error");
                }

            

            }
            else
            {
                MessageBox.Show("Password Mismatch", "Error");
            }


           
        }

        private void button23_Click(object sender, EventArgs e)
        {

            getDataandInfo();


            dashboardTab.SelectedIndex = 11;
        }


        private void button17_Click(object sender, EventArgs e)
        {
            string txtQuery = "update Medication_Inventory set SJCMI_Session = '" + SelectedVewMedID + "',  SJCMI_Date = '" + DateTime.Now.ToShortDateString() + "',  SJCMI_Count = '" + addedViewMedInASessionCount + "' WHERE SJCMI_Session = '" + SelectedVewMedID + "' AND SJCMI_isArchive = 0 ";
            executeQuery(txtQuery);
            loadMedsOverall();
            loadMeds();
            dashboardTab.SelectedIndex = 7;
            MessageBox.Show("New Inventory added", "Successfull");
            addedViewMedInASessionCount = 0;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (SelectedVewMedID != null)
            {

                addedViewMedInASessionCount = addedViewMedInASessionCount - int.Parse(viewMedStock.Text);


                string txtQuery = "update Medication set SJCM_isArchive = 1 WHERE SJCM_ItemID = '" + SelectedVewMedID + "' AND SJCM_isArchive = 0 ";
                executeQuery(txtQuery);
                loadAddMedSession();
                GenerateItemMedID();
                resetViewnewMedTexts();



            }
            else
            {
                MessageBox.Show("Please select and item to archive first");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {

            addedViewMedInASessionCount = addedViewMedInASessionCount + int.Parse(viewMedStock.Text);

            string txtQuery = "update Medication set SCJM_Name = '" + viewMedName.Text + "', SCJM_Brand = '" + viewMedBrand.Text + "', SCJM_Description = '" + viewMedDesc.Text + "', SJCM_Stock = '" + viewMedStock.Text + "', SJCM_DateExp = '" + viewMedEXPDATE.Value.ToShortDateString() + "'  WHERE SJCM_ItemID = '" + SelectedVewMedID + "' AND SJCM_isArchive = 0 ";

            executeQuery(txtQuery);
            loadAddMedSession();
            GenerateItemMedID();
            resetAddnewMedTexts();

            MessageBox.Show("Medication Updated Successfully", "Successfull");
        }


        private void viewMedSessionDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            SelectedVewMedID = viewMedSessionDGV.SelectedRows[0].Cells[6].Value.ToString();

            viewMedName.Text = viewMedSessionDGV.SelectedRows[0].Cells[0].Value.ToString();
            viewMedBrand.Text = viewMedSessionDGV.SelectedRows[0].Cells[1].Value.ToString();
            viewMedStock.Text = viewMedSessionDGV.SelectedRows[0].Cells[2].Value.ToString();
            viewMedDesc.Text = viewMedSessionDGV.SelectedRows[0].Cells[3].Value.ToString();
            viewMedEXPDATE.Text = viewMedSessionDGV.SelectedRows[0].Cells[4].Value.ToString();
        }


        private void addMedicationToInventory()
        {
            string txtQuery = "INSERT into Medication_Inventory (SJCMI_Session, SJCMI_Date, SJCMI_Count) values ('" + GeneratedSessionMedID + "', '" + DateTime.Now.ToShortDateString() + "', '" + addedMedInASessionCount + "')";

            executeQuery(txtQuery);
            loadMeds();
            dashboardTab.SelectedIndex = 7;
            addedMedInASessionCount = 0;
            MessageBox.Show("New Inventory added", "Successfull");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            addMedicationToInventory();
            loadMedsOverall();
        }


        private void button19_Click(object sender, EventArgs e)
        {
            //string txtQuery = "INSERT into Medication (SCJM_Name, SCJM_Brand, SCJM_Description, SJCM_Stock, SJCM_DateExp) values ('" + addNewMedName.Text + "', '" + addNewMedBrand.Text + "', '" + addNewMedDesc.Text + "', '" + addNewMedStock.Text + "', '" + addNewMedEXP.Value.ToShortDateString() + "' )";

            addedMedInASessionCount = addedMedInASessionCount + int.Parse(addNewMedStock.Text);

            string txtQuery = "update Medication set SCJM_Name = '" + addNewMedName.Text + "', SCJM_Brand = '" + addNewMedBrand.Text + "', SCJM_Description = '" + addNewMedDesc.Text + "', SJCM_Stock = '" + addNewMedStock.Text + "', SJCM_DateExp = '" + addNewMedEXP.Value.ToShortDateString() + "'  WHERE SJCM_ItemID = '" + SelectedAddnewMedID + "' AND SJCM_isArchive = 0 ";

            executeQuery(txtQuery);
            loadCurrentMedSession();
            GenerateItemMedID();
            resetAddnewMedTexts();

         
        }


        private void archiveMedItem_Click(object sender, EventArgs e)
        {
            if (SelectedAddnewMedID != null )
            {

                addedMedInASessionCount = addedMedInASessionCount - int.Parse(addNewMedStock.Text);


                string txtQuery = "update Medication set SJCM_isArchive = 1 WHERE SJCM_ItemID = '" + SelectedAddnewMedID + "' AND SJCM_isArchive = 0 ";
                executeQuery(txtQuery);
                loadCurrentMedSession();
                GenerateItemMedID();
                resetAddnewMedTexts();

                

            }  else
            {
                MessageBox.Show("Please select and item to archive first");
            }
          
        }

     
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SelectedAddnewMedID = addNewMedDGV.SelectedRows[0].Cells[6].Value.ToString();
            //MessageBox.Show(SelectedAddnewMedID.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Medication (SCJM_Name, SCJM_Brand, SCJM_Description, SCJM_DateAdded, SJCM_Stock, SJCM_DateExp, SJCM_ItemID, SJCM_SessionID, SJCM_isArchive) values ('" + addNewMedName.Text + "', '" + addNewMedBrand.Text + "', '" + addNewMedDesc.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + addNewMedStock.Text + "', '" + addNewMedEXP.Value.ToShortDateString() + "', '" + GeneratedItemMedID + "', '" + GeneratedSessionMedID + "', '" + 0 + "')";
            addedMedInASessionCount = addedMedInASessionCount + int.Parse(addNewMedStock.Text);
            executeQuery(txtQuery);
            loadCurrentMedSession();
            GenerateItemMedID();
            resetAddnewMedTexts();
        }


        private void GenerateSessionMedID(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            GeneratedSessionMedID = "Session-" + randomString;

        }

        private void GenerateItemMedID(int length = 7)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            GeneratedItemMedID = "Item-" + randomString;

        }

        private void loadCurrentMedSession()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SCJM_Name AS NAME, SCJM_Brand AS BRAND, SJCM_Stock AS STOCK,  SCJM_Description AS DESCRIPTION,  SJCM_DateExp AS DATEEXPIRE, SCJM_DateAdded DATEADDED, SJCM_ItemID AS ITEM, SJCM_SessionID AS SESSION  FROM Medication WHERE SJCM_SessionID = '" + GeneratedSessionMedID + "' AND  SJCM_isArchive = 0 ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSAddMeds.Reset();
            sql_adptr.Fill(DSAddMeds);
            DTAddMEds = DSAddMeds.Tables[0];
            addNewMedDGV.DataSource = DTAddMEds;

            sql_con.Close();
        }

        private void addNewMedDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedAddnewMedID = addNewMedDGV.SelectedRows[0].Cells[6].Value.ToString();

            addNewMedName.Text = addNewMedDGV.SelectedRows[0].Cells[0].Value.ToString();
            addNewMedBrand.Text = addNewMedDGV.SelectedRows[0].Cells[1].Value.ToString();
            addNewMedStock.Text = addNewMedDGV.SelectedRows[0].Cells[2].Value.ToString();
            addNewMedDesc.Text = addNewMedDGV.SelectedRows[0].Cells[3].Value.ToString();
            addNewMedEXP.Text = addNewMedDGV.SelectedRows[0].Cells[4].Value.ToString();

            addedMedInASessionCount = addedMedInASessionCount - int.Parse(addNewMedStock.Text);

        }
        private void button13_Click(object sender, EventArgs e)
        {
           
            dashboardTab.SelectedIndex = 8;
            GenerateSessionMedID();
            GenerateItemMedID();
            loadCurrentMedSession();
            SessionAddMed.Text = GeneratedSessionMedID;

        }


        private void prevdiagwitharchive(int i)
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCD_ID AS ID, SJCD_Diagnosis AS DIAGNOSIS, SJCD_Description AS DESCRIPTION, SJCD_Date AS DATE   FROM Diagnosis WHERE SJCD_StaffPatientID = '" + i + "' ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSHISD.Reset();
            sql_adptr.Fill(DSHISD);
            DTHISD = DSHISD.Tables[0];
            historyPatientPrevDiagnosis.DataSource = DTHISD;

            sql_con.Close();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            prevdiagwitharchive(historyPatientStaffPatient); 
        }


        private void historyPatientPrevDiagnosis_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            historySelectedPatientID = historyPatientPrevDiagnosis.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void archivePres(string s)
        {
            string txtQuery = "update Prescriptions set SJCPS_isArchived = 1 WHERE SJCPS_ID = '" + s + "' AND SJCPS_isArchived = 0 ";
            executeQuery(txtQuery);

            LoadCurrentDiagnoseSession();
            resetPrescriptionTexts();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (selectedPresID != null )
            {
                archivePres(selectedPresID);
            } else
            {
                MessageBox.Show("Select a Prescription First!");
            }
        }

        private void prescriptiondgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPresID = prescriptiondgv.SelectedRows[0].Cells[0].Value.ToString();

            LoadCurrentDiagnoseSession();
           
        }


        private void loadSpecifcMed(string s)
        {
            string txtQuery = "SELECT * FROM Medication WHERE SCJM_ID =  '" + s + "'   ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {



                viewMedIDVal = sql_dbr.GetInt32(0);
                viewMedNameVal = sql_dbr.GetString(1);
                viewMedBrandVal = sql_dbr.GetString(2);
                viewMedStockVal = sql_dbr.GetInt32(6);
                viewMedDescVal = sql_dbr.GetString(3);
                viewMedisArchiveVal = sql_dbr.GetInt32(5);
        

                count = count + 1;


            }

            //viewMedBrand.Text = viewMedBrandVal;
            //viewMedDesc.Text = viewMedDescVal;
            //viewMedStock.Text = viewMedStockVal.ToString();
            //viewMedName.Text = viewMedNameVal;
            

            sql_con.Close();
        }


        private void loadAddMedSession()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

          
            string CommandText = "SELECT SCJM_Name AS NAME, SCJM_Brand AS BRAND, SJCM_Stock AS STOCK,  SCJM_Description AS DESCRIPTION,  SJCM_DateExp AS DATEEXPIRE, SCJM_DateAdded DATEADDED, SJCM_ItemID AS ITEM, SJCM_SessionID AS SESSION  FROM Medication WHERE SJCM_SessionID = '" + selectedMedID + "' AND  SJCM_isArchive = 0 ";

            //string CommandText = "SELECT * FROM Medication WHERE SJCM_SessionID = '" + selectedMedID  + "' AND SJCM_isArchive = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSViewMeds.Reset();
            sql_adptr.Fill(DSViewMeds);
            DTViewMeds = DSViewMeds.Tables[0];
            viewMedSessionDGV.DataSource = DTViewMeds;

            sql_con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
          

            if (selectedMedID != null)
            {
                label24.Text = selectedMedID;
                dashboardTab.SelectedIndex = 9;
                loadAddMedSession();
            }
            else
            {
                MessageBox.Show("Select a Medication first", "Error");
            }
        }


        private void medsInventoryDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedMedID = medsInventoryDgv.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void loadMeds()
        {
          

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT * FROM Medication_Inventory";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSMeds.Reset();
            sql_adptr.Fill(DSMeds);
            DTMEds = DSMeds.Tables[0];
            medsInventoryDgv.DataSource = DTMEds;

            sql_con.Close();
        }

     


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            dashboardTab.SelectedIndex = 7;
            loadMeds();
            loadMedsOverall();
        }

        private void loadMedsOverall()
        {

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SCJM_Name, SCJM_Brand , SCJM_Description, SUM(SJCM_Stock) FROM Medication GROUP BY SCJM_Name; ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSOVRMeds.Reset();
            sql_adptr.Fill(DSOVRMeds);
            DTOVRMEds = DSOVRMeds.Tables[0];
            MedsInv.DataSource = DTOVRMEds;

            sql_con.Close();
        }




        private void button9_Click(object sender, EventArgs e)
        {
            if (historySelectedPatientID != null )
            {
                dashboardTab.SelectedIndex = 2;
                getDagnosisData(int.Parse(historySelectedPatientID));
            } else
            {
                MessageBox.Show("Select a diagnosis first", "Error");
            }
           
        }

        private void historyPatientPrevDiagnosis_CellClick(object sender, DataGridViewCellEventArgs e)
        {

                 historySelectedPatientID = historyPatientPrevDiagnosis.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void getdiagnosisforHistry(int i)
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCD_ID AS ID, SJCD_Diagnosis AS DIAGNOSIS, SJCD_Description AS DESCRIPTION, SJCD_Date AS DATE   FROM Diagnosis WHERE SJCD_StaffPatientID = '" + i + "' AND SJCD_isArchive = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSHISD.Reset();
            sql_adptr.Fill(DSHISD);
            DTHISD = DSHISD.Tables[0];
            historyPatientPrevDiagnosis.DataSource = DTHISD;

            sql_con.Close();

        }

        private void getprescriptionsforHistry(int i)
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCPS_Prescriptions AS PRESCRIPTION, SJCPS_Count AS QUANTITY, SJCPS_Unit AS UNIT   FROM Prescriptions WHERE SJCPS_StaffPatientID = '" + i + "'";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSHISP.Reset();
            sql_adptr.Fill(DSHISP);
            DTHISP = DSHISP.Tables[0];
            historyPatientPrevPrescrip.DataSource = DTHISP;

            sql_con.Close();

        }


        private void button12_Click(object sender, EventArgs e)
        {
           

            if (patientSelectedID != null)
            {
                dashboardTab.SelectedIndex = 6;
                string txtQuery = "Select p.SJCP_ID, p.SJCP_LastName, p.SJCP_FirstName, p.SJCP_Address, p.SJCP_Gender,  p.SJCP_Birthday, p.SJCP_isArchive, sp.SJCSPR_ID from Patient AS p INNER JOIN Staff_Patient AS sp ON p.SJCP_ID = sp.SJCSPR_Patient AND sp.SJCSPR_Staff = '" + authID + "' AND p.SJCP_ID = '" + patientSelectedID + "'";

                setConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_dbr = sql_cmd.ExecuteReader();
                int count = 0;
                while (sql_dbr.Read())
                {



                    historyPatientIDVal = sql_dbr.GetInt32(0);
                    historyPatientFNVal = sql_dbr.GetString(2);
                    historyPatientLNVal = sql_dbr.GetString(1);
                    historyPatientAddVal = sql_dbr.GetString(3);
                    historyPatientGenderVal = sql_dbr.GetString(4);
                    historyPatientBdayVal = sql_dbr.GetString(5);
                    historyPatientisArchiveVal = sql_dbr.GetInt32(6);
                    historyPatientStaffPatient = sql_dbr.GetInt32(7);

                    count = count + 1;


                }

                historyPatientName.Text = historyPatientLNVal + ", " + historyPatientFNVal;
                historyPatientAdd.Text = historyPatientAddVal;
                historyPatientBday.Text = historyPatientBdayVal;
                historyPatientGender.Text = historyPatientGenderVal;
                historyPatientIsArchive.Text = "Archive Status : " + historyPatientisArchiveVal;


                getdiagnosisforHistry(historyPatientStaffPatient);
                getprescriptionsforHistry(historyPatientStaffPatient);

                sql_con.Close();
            }
            else
            {
                MessageBox.Show("Select a patient first", "Error");
            }



        }


        private void button7_Click(object sender, EventArgs e)
        {

            string txtQuery = "update Patient set SJCP_FirstName = '" + editPatientFN.Text + "', SJCP_LastName = '" + editPatientLN.Text + "', SJCP_Birthday = '" + editPatientBday.Value.ToShortDateString() + "', SJCP_Address = '" + editPatientAdd.Text + "', SJCP_Gender = '" + editPatientGender.Text + "', SJCP_PatientData = '" + editPatientData.Text + "' WHERE SJCP_ID = '" + patientSelectedID + "' ";
            
            executeQuery(txtQuery);
            loadPatientsTab();
            dashboardTab.SelectedIndex = 3;
           
            MessageBox.Show("Patient Data Edit Successfully");
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (patientsIsArchived.Checked)
            {
                loadPatientsTab2();
             
            }
            else
            {
                loadPatientsTab();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string txtQuery = "update Patient set SJCP_isArchive = 1 WHERE SJCP_ID = '" + patientSelectedID + "' ";
            patientsIsArchived.Checked = false;
            dashboardTab.SelectedIndex = 3;
            executeQuery(txtQuery);
            MessageBox.Show("Patient Archived Successfully");
            loadPatientsTab();
        }



        private void button10_Click(object sender, EventArgs e)
        {
            string txtQuery = "update Patient set SJCP_isArchive = 0 WHERE SJCP_ID = '" + patientSelectedID + "' ";
            patientsIsArchived.Checked = false;
            dashboardTab.SelectedIndex = 3;
            executeQuery(txtQuery);
            MessageBox.Show("Patient unArchived Successfully");
            loadPatientsTab();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (patientSelectedID != null)
            {
                dashboardTab.SelectedIndex = 5;
                string txtQuery = "SELECT * FROM Patient WHERE SJCP_ID =  '" + patientSelectedID + "'  ORDER BY SJCP_ID DESC LIMIT 1 ";

                setConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_dbr = sql_cmd.ExecuteReader();
                int count = 0;
                while (sql_dbr.Read())
                {



                    editPatientIDVal = sql_dbr.GetInt32(0);
                    editPatientFNVal = sql_dbr.GetString(1);
                    editPatientLNVal = sql_dbr.GetString(2);
                    editPatientAddVal = sql_dbr.GetString(4);
                    editPatientGenderVal = sql_dbr.GetString(5);
                    editPatientDataVal = sql_dbr.GetString(6);
                    editPatientBdayVal = sql_dbr.GetString(3);
                    editPatientisArchiveVal = sql_dbr.GetInt32(8);

                    count = count + 1;


                }


                if (editPatientisArchiveVal == 1)
                {
                    button10.Visible = true;
                    button11.Visible = false;
                }
                else
                {
                    button10.Visible = false;
                    button11.Visible = true;
                }



                editPatientFN.Text = editPatientFNVal;
                editPatientLN.Text = editPatientLNVal;
                editPatientAdd.Text = editPatientAddVal;
                editPatientGender.Text = editPatientGenderVal;
                editPatientData.Text = editPatientDataVal;
                editPatientBday.Text = editPatientBdayVal;

                sql_con.Close();
            } else
            {
                MessageBox.Show("Select a patient first", "Error");
            }
             
        
        }


        private void registerPatientToStaff(int i)
        {
            string txtQuery = "INSERT into Staff_Patient (SJCSPR_Staff, SJCSPR_Patient) values ('" + authID + "', '" + i + "')";

            executeQuery(txtQuery);
            loadPatientsTab();
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


        private void button6_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 4;
        }

        private void addNewPatientSubmit_Click(object sender, EventArgs e)
        {
            string txtQuery = "INSERT into Patient (SJCP_FirstName, SJCP_LastName, SJCP_Birthday, SJCP_Address, SJCP_Gender, SJCP_PatientData, SJCP_DateRegistered, SJCP_isArchive) values ('" + addNewPatientFN.Text + "', '" + addNewPatientLN.Text + "', '" + addNewPatientDT.Value.ToShortDateString() + "', '" + addNewPatientADD.Text + "', '" + addNewPatientGEN.Text + "', '" + addNewPatientDATA.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + 0 + "')";

            executeQuery(txtQuery);

          
            dashboardTab.SelectedIndex = 3;
         
            getLatestID();
        }

        private void patientsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientSelectedID = patientsDGV.SelectedRows[0].Cells[0].Value.ToString();
            SelectedPatientStaffPatient = patientsDGV.SelectedRows[0].Cells[5].Value.ToString();

            patientCardReset();
            isCardOn = true;


          

            getPatientData(int.Parse(patientSelectedID));
            patientCardOnOff();
        }

        private void patientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(patientsDGV.CurrentCell.Value.ToString());
        }


        private void loadPatientsTab()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

     
            string CommandText = "Select p.SJCP_ID AS ID, p.SJCP_LastName AS LastName, p.SJCP_FirstName AS FirstName, p.SJCP_Address AS Address,  p.SJCP_Birthday AS Birthday, sp.SJCSPR_ID AS StaffPatientID from Patient AS p INNER JOIN Staff_Patient AS sp ON p.SJCP_ID = sp.SJCSPR_Patient AND sp.SJCSPR_Staff = '" + authID + "' AND p.SJCP_isArchive = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSPATIENT.Reset();
            sql_adptr.Fill(DSPATIENT);
            DTPATIENT = DSPATIENT.Tables[0];
            patientsDGV.DataSource = DTPATIENT;

            sql_con.Close();
        }

        private void loadPatientsTab2()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select p.SJCP_ID AS ID, p.SJCP_LastName AS LastName, p.SJCP_FirstName AS FirstName, p.SJCP_Address AS Address,  p.SJCP_Birthday AS Birthday, sp.SJCSPR_ID AS StaffPatientID from Patient AS p INNER JOIN Staff_Patient AS sp ON p.SJCP_ID = sp.SJCSPR_Patient AND sp.SJCSPR_Staff = '" + authID + "'";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSPATIENT.Reset();
            sql_adptr.Fill(DSPATIENT);
            DTPATIENT = DSPATIENT.Tables[0];
            patientsDGV.DataSource = DTPATIENT;

            sql_con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            dashboardTab.SelectedIndex = 3;
            patientsIsArchived.Checked = false;



            loadPatientsTab();


        }


        private void viewDiagDelete_Click(object sender, EventArgs e)
        {
            string txtQuery = "update Diagnosis set SJCD_isArchive = 1 WHERE SJCD_ID = '" + viewDiagIDVal + "' ";
            executeQuery(txtQuery);
            dashboardTab.SelectedIndex = 0;
            isCardOn = false;
            patientCardOnOff();
        }

        private void viewDiagUpdate_Click(object sender, EventArgs e)
        {
          
            string txtQuery = "update Diagnosis set SJCD_Description = '" + viewDiagDesc.Text + "' WHERE SJCD_ID = '" + viewDiagIDVal + "' ";
            executeQuery(txtQuery);
            Cursor.Current = Cursors.Arrow;

        }


        private void applyToUi()
        {
            viewDiagAdd.Text = viewDiagAddVal;
            viewDiagDesc.Text = viewDiagDescVal;
            viewDiagName.Text = viewDiagNameVal;
            viewDiagTitle.Text = viewDiagTitleVal;
            viewDiagSched.Text = viewDiagSchedVal;
        }

        private void getPresciptions(string s)
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select SJCPS_Prescriptions, SJCPS_Count, SJCPS_Unit  from Prescriptions WHERE SJCPS_SessionID = '" + s + "' AND SJCPS_isArchived = 0 ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSVIEWPRES.Reset();
            sql_adptr.Fill(DSVIEWPRES);
            DTVIEWPRES = DSVIEWPRES.Tables[0];
            viewPresdgv.DataSource = DTVIEWPRES;

            sql_con.Close();
        }

        private void getPatientDataforDiag(int i)
        {
            string txtQuery = "SELECT * FROM Patient WHERE  SJCP_ID = '" + i + "'  ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

                // p1ID = sql_dbr.GetInt32(2);
                // p1Sched = sql_dbr.GetString(3);

                viewDiagNameVal = sql_dbr.GetString(2) + ", " + sql_dbr.GetString(1);
                viewDiagAddVal = sql_dbr.GetString(4);

                count = count + 1;


            }

         

            applyToUi();
            sql_con.Close();
        }

        private void getDagnosisData(int i)
        {
            string txtQuery = "Select d.SJCD_ID, d.SJCD_Diagnosis, d.SJCD_Description, d.SJCD_Date, d.SJCD_PrescriptionSessionID, d.SJCD_StaffPatientID, sp.SJCSPR_Patient from Diagnosis AS d INNER JOIN Staff_Patient AS sp ON d.SJCD_StaffPatientID = sp.SJCSPR_ID AND d.SJCD_ID = '" + i + "' AND sp.SJCSPR_Staff = '" + authID + "' AND d.SJCD_isArchive = '" + 0 + "';";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

                // p1ID = sql_dbr.GetInt32(2);
                // p1Sched = sql_dbr.GetString(3);

                viewDiagIDVal = sql_dbr.GetInt32(0);
                viewDiagSessionVal = sql_dbr.GetString(4);
                viewDiagpatientVal = sql_dbr.GetInt32(6);
                viewDiagSchedVal = sql_dbr.GetString(3);
                viewDiagTitleVal = sql_dbr.GetString(1);
                viewDiagDescVal = sql_dbr.GetString(2);

                count = count + 1;


            }

            getPresciptions(viewDiagSessionVal);
            getPatientDataforDiag(viewDiagpatientVal);
            sql_con.Close();
        }

        private void diag5name_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 2;
            getDagnosisData(diag5IDVal);
        }

        private void diag4name_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 2;
            getDagnosisData(diag4IDVal);
        }


        private void diag3name_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 2;
            getDagnosisData(diag3IDVal);
        }


        private void diag2name_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 2;
            getDagnosisData(diag2IDVal);
        }


        private void diag1name_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 2;
            getDagnosisData(diag1IDVal);
        }

        private void resetDiagnosisText()
        {
            newDiagnosis.Text = "Diagnosis";
            newDiagnosisDesc.Text = "Diagnosis Description";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            patientCardReset();

            string txtQuery = "INSERT into Diagnosis (SJCD_StaffPatientID, SJCD_Diagnosis, SJCD_Description, SJCD_Date, SJCD_PrescriptionSessionID, SJCD_isArchive ) values ('" + SelectedPatientStaffPatient + "', '" + newDiagnosis.Text + "', '" + newDiagnosisDesc.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + GeneratedSessionID + "', '" + 0 + "')";

            executeQuery(txtQuery);

            MessageBox.Show("Diagnosis Submitted!", "Great!");


            resetAddPatientTexts();
            resetDiagnosisText();
            GenerateSessionID();

           
            getPatientData(patientDiagnoseID);
          
        }

        private void newDiagnosis_Enter(object sender, EventArgs e)
        {
            if (newDiagnosis.Text == "Diagnosis")
            {
                newDiagnosis.Text = "";
            }
        }

        private void newDiagnosis_Leave(object sender, EventArgs e)
        {
            if (newDiagnosis.Text == "")
            {
                newDiagnosis.Text = "Diagnosis";
            }
        }

        private void newDiagnosisDesc_Enter(object sender, EventArgs e)
        {
            if (newDiagnosisDesc.Text == "Diagnosis Description")
            {
                newDiagnosisDesc.Text = "";
            }
        }

        private void newDiagnosisDesc_Leave(object sender, EventArgs e)
        {
            if (newDiagnosisDesc.Text == "")
            {
                newDiagnosisDesc.Text = "Diagnosis Description";
            }
        }


        private void prescriptionCount_Enter(object sender, EventArgs e)
        {
            if (prescriptionCount.Text == "Prescriptions Quantity")
            {
                prescriptionCount.Text = "";
            }
        }

        private void prescriptionCount_Leave(object sender, EventArgs e)
        {
            if (prescriptionCount.Text == "")
            {
                prescriptionCount.Text = "Prescriptions Quantity";
            }
        }


        private void prescription_Enter(object sender, EventArgs e)
        {
            if (prescription.Text == "Prescriptions")
            {
                prescription.Text = "";
            }
        }

        private void prescription_Leave(object sender, EventArgs e)
        {
            if (prescription.Text == "")
            {
                prescription.Text = "Prescriptions";
            }
        }

        private void resetPrescriptionTexts()
        {
            prescription.Text = "Prescriptions";
            prescriptionCount.Text = "Prescriptions Quantity";
            prescriptionUnit.Text = "Prescriptions Unit";
            //newDiagnosisDesc.Text = "Diagnosis Description";
            //newDiagnosis.Text = "Diagnosis";
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            string txtQuery = "INSERT into Prescriptions (SJCPS_StaffPatientID, SJCPS_Prescriptions, SJCPS_Count, SJCPS_Sched, SJCPS_SessionID, SJCPS_Unit, SJCPS_isArchived) values ('" + patientCardStaffPatientVal + "', '" + prescription.Text + "', '" + prescriptionCount.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + GeneratedSessionID + "', '" + prescriptionUnit.Text + "', '" + 0 + "')";

            executeQuery(txtQuery);

            LoadCurrentDiagnoseSession();
            resetPrescriptionTexts();
        }

        private void LoadCurrentDiagnoseSession()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select SJCPS_ID AS ID, SJCPS_Prescriptions AS Name, SJCPS_Count AS Count, SJCPS_Unit AS Unit  from Prescriptions WHERE SJCPS_SessionID = '" + genSesID.Text + "' AND SJCPS_isArchived = 0 ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSDIAG.Reset();
            sql_adptr.Fill(DSDIAG);
            DTDIAG = DSDIAG.Tables[0];
            prescriptiondgv.DataSource = DTDIAG;

            sql_con.Close();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 1;


            genSesID.Text = GeneratedSessionID;
            patientDiagnoseID = patientCardIDVal;
            NewDiagnosisTitle.Text = "New Diagnosis for " + patientCardNameVal;
            LoadCurrentDiagnoseSession();
        }


        private void GenerateSessionID(int length = 4)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            GeneratedSessionID = "Session-" + randomString;

        }

   

        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }

        private void getAppointmentList()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "Select a.SJCA_ID, a.SJCA_StaffPatientID, a.SJCA_Schedule,  sp.SJCSPR_Staff from Appointments AS a INNER JOIN Staff_Patient AS sp ON sp.SJCSPR_Staff = '" + authID + "' AND a.SJCA_StaffPatientID = sp.SJCSPR_ID LIMIT 3 ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSA.Reset();
            sql_adptr.Fill(DSA);
            DTA = DSA.Tables[0];
           // adgv.DataSource = DTA;

           

         

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


        private void initGetPatient()
        {
            string txtQuery = "Select a.SJCA_ID, a.SJCA_StaffPatientID, a.SJCA_Schedule, a.isActive,  sp.SJCSPR_Staff, sp.SJCSPR_Patient from Appointments AS a INNER JOIN Staff_Patient AS sp ON sp.SJCSPR_Staff = '" + authID +"' AND a.SJCA_StaffPatientID = sp.SJCSPR_ID AND a.isActive = '" + 1 + "' LIMIT 3;";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

               
                if (count == 0)
                {
                    appointMent1IDVal = sql_dbr.GetInt32(0);
                    p1ID = sql_dbr.GetInt32(5);
                    p1Sched = sql_dbr.GetString(2);
                } if (count == 1)
                {
                    appointMent2IDVal = sql_dbr.GetInt32(0);
                    p2ID = sql_dbr.GetInt32(5);
                    p2Sched = sql_dbr.GetString(2);
                } if (count == 2)
                {
                    appointMent3IDVal = sql_dbr.GetInt32(0);
                    p3ID = sql_dbr.GetInt32(5);
                    p3Sched = sql_dbr.GetString(2);
                }
               

                count = count + 1;


            }



            //if (prevp1ID == p1ID)
            //{
            //    MessageBox.Show("Same patient id maybe below was done first?");

            //    p1DashSched.Text = " ";
            //    p1DashName.Visible = false;
            //    viewCard1.Visible = false;
            //    donePatient1.Visible = false;
            //    patient1Data(p1ID);
            //}
            //else
            //{
            //    p1DashName.Visible = true;
            //    p1DashSched.Text = p1Sched;
            //    appointMent1ID = appointMent1IDVal;
            //    patient1Data(p1ID);
            //}


            if (prevp1ID == p1ID)
            {
                p1DashSched.Text = " ";
                p1DashName.Visible = false;
                viewCard1.Visible = false;
                donePatient1.Visible = false;
                patient1Data(p1ID);
            }
            else
            {
                p1DashName.Visible = true;
                p1DashSched.Text = p1Sched;
                appointMent1ID = appointMent1IDVal;
                patient1Data(p1ID);
            }




            if (prevp2ID == p2ID)
            {
             
                p2DashSched.Text = " ";
                p2DashName.Visible = false;
                viewCard2.Visible = false;
                donePatient2.Visible = false;
                patient1Data(p2ID);
            }
            else
            {
                donePatient2.Visible = false;
                p2DashName.Visible = true;
                p2DashSched.Text = p2Sched;
                appointMent2ID = appointMent2IDVal;
                patient2Data(p2ID);
            }


            if (prevp3ID == p3ID)
            {
           
                p3DashSched.Text = " ";
                p3DashName.Visible = false;
                viewCard3.Visible = false;
                donePatient3.Visible = false;
                patient3Data(p3ID);
            }
            else
            {
                donePatient3.Visible = false;
                p3DashName.Visible = true;
                p3DashSched.Text = p3Sched;
                appointMent3ID = appointMent3IDVal;
                patient3Data(p3ID);
            }



            

            sql_con.Close();
        }

        private void getPatientData(int i)
        {

          

            string txtQuery = "Select p.SJCP_ID, p.SJCP_LastName, p.SJCP_FirstName, p.SJCP_Address,  p.SJCP_Birthday, sp.SJCSPR_ID from Patient AS p INNER JOIN Staff_Patient AS sp ON p.SJCP_ID = sp.SJCSPR_Patient AND p.SJCP_ID = '" + i + "' AND sp.SJCSPR_Staff = 2 ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {

                patientCardNameVal = sql_dbr.GetString(2) + ", " + sql_dbr.GetString(1);
                patientCardAddVal  = sql_dbr.GetString(3);
                patientCardBdayVal = sql_dbr.GetString(4);
                patientCardIDVal = sql_dbr.GetInt32(0);
                patientCardStaffPatientVal = sql_dbr.GetInt32(5);

            
                count = count + 1;


            }

            SelectedPatientStaffPatient = patientCardStaffPatientVal.ToString();

            patientCardName.Text = patientCardNameVal;
            patientCardAddress.Text = patientCardAddVal;
            patientCardBday.Text = patientCardBdayVal;

            getPatientDiagnosis(patientCardStaffPatientVal);

            
            getPatientPrescriptions(patientCardStaffPatientVal);

            sql_con.Close();
        }

        private void getPatientPrescriptions(int i)
        {
            string txtQuery = "SELECT * FROM Prescriptions WHERE SJCPS_StaffPatientID = '" + i + "'  ORDER BY `SJCPS_ID` DESC LIMIT 5 ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {



                if (count == 0)
                {
                    pres1Val = sql_dbr.GetString(2);
                    pres1CountVal = sql_dbr.GetInt32(3);
                    pres1SchedVal = sql_dbr.GetString(4);
                }
                if (count == 1)
                {
                    pres2Val = sql_dbr.GetString(2);
                    pres2CountVal = sql_dbr.GetInt32(3);
                    pres2SchedVal = sql_dbr.GetString(4);
                }
                if (count == 2)
                {
                    pres3Val = sql_dbr.GetString(2);
                    pres3CountVal = sql_dbr.GetInt32(3);
                    pres3SchedVal = sql_dbr.GetString(4);
                }
                if (count == 3)
                {
                    pres4Val = sql_dbr.GetString(2);
                    pres4CountVal = sql_dbr.GetInt32(3);
                    pres4SchedVal = sql_dbr.GetString(4);
                }
                if (count == 4)
                {
                    pres5Val = sql_dbr.GetString(2);
                    pres5CountVal = sql_dbr.GetInt32(3);
                    pres5SchedVal = sql_dbr.GetString(4);
                }


                count = count + 1;


            }

            if (count == 0)
            {
                pres1.Text = "";
                pres1sched.Text = "";

                pres2.Text = "";
                pres2sched.Text = "";

                pres3.Text = "";
                pres3sched.Text = "";

                pres4.Text = "";
                pres4sched.Text = "";

                pres5.Text = "";
                pres5sched.Text = "";
            }

            if (count == 1)
            {
                if (pres1CountVal > 0)
                {
                    pres1.Text = pres1CountVal.ToString() + " " + pres1Val;
                    pres1sched.Text = pres1SchedVal;
                }

                pres2.Text = "";
                pres2sched.Text = "";

                pres3.Text = "";
                pres3sched.Text = "";

                pres4.Text = "";
                pres4sched.Text = "";

                pres5.Text = "";
                pres5sched.Text = "";
            }

            if (count == 2 )
            {
                if (pres1CountVal > 0)
                {
                    pres1.Text = pres1CountVal.ToString() + " " + pres1Val;
                    pres1sched.Text = pres1SchedVal;
                }

                if (pres2CountVal > 0)
                {
                    pres2.Text = pres2CountVal.ToString() + " " + pres2Val;
                    pres2sched.Text = pres2SchedVal;
                }
                pres3.Text = "";
                pres3sched.Text = "";

                pres4.Text = "";
                pres4sched.Text = "";

                pres5.Text = "";
                pres5sched.Text = "";
            }

            if (count == 3)
            {
                if (pres1CountVal > 0)
                {
                    pres1.Text = pres1CountVal.ToString() + " " + pres1Val;
                    pres1sched.Text = pres1SchedVal;
                }

                if (pres2CountVal > 0)
                {
                    pres2.Text = pres2CountVal.ToString() + " " + pres2Val;
                    pres2sched.Text = pres2SchedVal;
                }

                if (pres3CountVal > 0)
                {
                    pres3.Text = pres3CountVal.ToString() + " " + pres3Val;
                    pres3sched.Text = pres3SchedVal;
                }

                pres4.Text = "";
                pres4sched.Text = "";

                pres5.Text = "";
                pres5sched.Text = "";
            }

            if (count == 4)
            {
                if (pres1CountVal > 0)
                {
                    pres1.Text = pres1CountVal.ToString() + " " + pres1Val;
                    pres1sched.Text = pres1SchedVal;
                }

                if (pres2CountVal > 0)
                {
                    pres2.Text = pres2CountVal.ToString() + " " + pres2Val;
                    pres2sched.Text = pres2SchedVal;
                }

                if (pres3CountVal > 0)
                {
                    pres3.Text = pres3CountVal.ToString() + " " + pres3Val;
                    pres3sched.Text = pres3SchedVal;
                }

                if (pres4CountVal > 0)
                {
                    pres4.Text = pres4CountVal.ToString() + " " + pres4Val;
                    pres4sched.Text = pres4SchedVal;
                }

                pres5.Text = "";
                pres5sched.Text = "";
            }


            if (count == 5)
            {
                if (pres1CountVal > 0)
                {
                    pres1.Text = pres1CountVal.ToString() + " " + pres1Val;
                    pres1sched.Text = pres1SchedVal;
                }

                if (pres2CountVal > 0)
                {
                    pres2.Text = pres2CountVal.ToString() + " " + pres2Val;
                    pres2sched.Text = pres2SchedVal;
                }

                if (pres3CountVal > 0)
                {
                    pres3.Text = pres3CountVal.ToString() + " " + pres3Val;
                    pres3sched.Text = pres3SchedVal;
                }

                if (pres4CountVal > 0)
                {
                    pres4.Text = pres4CountVal.ToString() + " " + pres4Val;
                    pres4sched.Text = pres4SchedVal;
                }

                if (pres5CountVal > 0)
                {
                    pres5.Text = pres4CountVal.ToString() + " " + pres5Val;
                    pres5sched.Text = pres4SchedVal;
                }

            }




            sql_con.Close();
        }


        private string shortener(string word)
        {
            diag1des.Text = "";
            shorteneddes1 = "";
            if (word.Length > 29)

            {

                for (int i = 0; i < 30; i++)
                {

                    if (i < 29)
                    {
                        shorteneddes1 += word[i].ToString();
                    }
                    else
                    {
                        shorteneddes1 += "...";
                    }

                }

              
            } else
            {
                shorteneddes1 = word;
            }
           

            return shorteneddes1;
        }

        private string shortener1(string word)
        {
            diag2des.Text = "";
            shorteneddes2 = "";
            if (word.Length > 29)

            {

                for (int i = 0; i < 30; i++)
                {

                    if (i < 29)
                    {
                        shorteneddes2 += word[i].ToString();
                    }
                    else
                    {
                        shorteneddes2 += "...";
                    }

                }

               
            }
            else
            {
                shorteneddes2 = word;
            }

           

            return shorteneddes2;
        }

        private string shortener2(string word)
        {
            diag3des.Text = "";
            shorteneddes3 = "";
            if (word.Length > 29)

            {

                for (int i = 0; i < 30; i++)
                {

                    if (i < 29)
                    {
                        shorteneddes3 += word[i].ToString();
                    }
                    else
                    {
                        shorteneddes3 += "...";
                    }

                }


            }
            else
            {
                shorteneddes3 = word;
            }



            return shorteneddes3;
        }


        private string shortener3(string word)
        {
            diag4des.Text = "";
            shorteneddes4 = "";
            if (word.Length > 29)

            {

                for (int i = 0; i < 30; i++)
                {

                    if (i < 29)
                    {
                        shorteneddes4 += word[i].ToString();
                    }
                    else
                    {
                        shorteneddes4 += "...";
                    }

                }


            }
            else
            {
                shorteneddes4 = word;
            }



            return shorteneddes4;
        }

        private string shortener4(string word)
        {
            diag5des.Text = "";
            shorteneddes5 = "";
            if (word.Length > 29)

            {

                for (int i = 0; i < 30; i++)
                {

                    if (i < 29)
                    {
                        shorteneddes5 += word[i].ToString();
                    }
                    else
                    {
                        shorteneddes5 += "...";
                    }

                }


            }
            else
            {
                shorteneddes5 = word;
            }



            return shorteneddes4;
        }

        private void getPatientDiagnosis(int i)
        {

        

            string txtQuery = "SELECT * FROM Diagnosis WHERE SJCD_isArchive = 0 AND  SJCD_StaffPatientID = '" + i + "' ORDER BY `SJCD_ID` DESC LIMIT 5  ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {



                if (count == 0)
                {
                    diag1IDVal = sql_dbr.GetInt32(0);
                    diag1NameVal = sql_dbr.GetString(2);
                    diag1SchedVal = sql_dbr.GetString(4);
                    diag1desVal = sql_dbr.GetString(3);
                }
                if (count == 1)
                {
                    diag2IDVal = sql_dbr.GetInt32(0);
                    diag2NameVal = sql_dbr.GetString(2);
                    diag2SchedVal = sql_dbr.GetString(4);
                    diag2desVal = sql_dbr.GetString(3);
                }
                if (count == 2)
                {
                    diag3IDVal = sql_dbr.GetInt32(0);
                    diag3NameVal = sql_dbr.GetString(2);
                    diag3SchedVal = sql_dbr.GetString(4);
                    diag3desVal = sql_dbr.GetString(3);
                }
                if (count == 3)
                {
                    diag4IDVal = sql_dbr.GetInt32(0);
                    diag4NameVal = sql_dbr.GetString(2);
                    diag4SchedVal = sql_dbr.GetString(4);
                    diag4desVal = sql_dbr.GetString(3);
                }
                if (count == 4)
                {
                    diag5IDVal = sql_dbr.GetInt32(0);
                    diag5NameVal = sql_dbr.GetString(2);
                    diag5SchedVal = sql_dbr.GetString(4);
                    diag5desVal = sql_dbr.GetString(3);
                }


                count = count + 1;


            }
           



            if (count == 0 )
            {
            
                diag1des.Text = " ";
                diag1name.Text = " ";
                diag1sched.Text = " ";

                diag2des.Text = " ";
                diag2name.Text = " ";
                diag2sched.Text = " ";

                diag3des.Text = " ";
                diag3name.Text = " ";
                diag3sched.Text = " ";

                diag4des.Text = " ";
                diag4name.Text = " ";
                diag4sched.Text = " ";

                diag5des.Text = " ";
                diag5name.Text = " ";
                diag5sched.Text = " ";

            }

            if (count == 1)
            {


                diag1des.Text = shortener(diag1desVal);
                diag1name.Text = diag1NameVal;
                diag1sched.Text = diag1SchedVal;

                diag2des.Text = "";
                diag2name.Text = "";
                diag2sched.Text = "";

                diag3des.Text = "";
                diag3name.Text = "";
                diag3sched.Text = "";

                diag4des.Text = "";
                diag4name.Text = "";
                diag4sched.Text = "";

                diag5des.Text = "";
                diag5name.Text = "";
                diag5sched.Text = "";
            }

            if (count == 2)
            {

                diag1des.Text = shortener(diag1desVal);
                diag1name.Text = diag1NameVal;
                diag1sched.Text = diag1SchedVal;

                diag2des.Text = shortener1(diag2desVal);
                diag2name.Text = diag2NameVal;
                diag2sched.Text = diag2SchedVal;

                diag3des.Text = "";
                diag3name.Text = "";
                diag3sched.Text = "";

                diag4des.Text = "";
                diag4name.Text = "";
                diag4sched.Text = "";

                diag5des.Text = "";
                diag5name.Text = "";
                diag5sched.Text = "";
            }


            if (count == 3)
            {


                diag1des.Text = shortener(diag1desVal);
                diag1name.Text = diag1NameVal;
                diag1sched.Text = diag1SchedVal;

                diag2des.Text = shortener1(diag2desVal);
                diag2name.Text = diag2NameVal;
                diag2sched.Text = diag2SchedVal;




                diag3des.Text = shortener2(diag3desVal);
                diag3name.Text = diag3NameVal;
                diag3sched.Text = diag3SchedVal;


                diag4des.Text = "";
                diag4name.Text = "";
                diag4sched.Text = "";

                diag5des.Text = "";
                diag5name.Text = "";
                diag5sched.Text = "";
            }


            if (count == 4)
            {
                diag1des.Text = shortener(diag1desVal);
                diag1name.Text = diag1NameVal;
                diag1sched.Text = diag1SchedVal;

                diag2des.Text = shortener1(diag2desVal);
                diag2name.Text = diag2NameVal;
                diag2sched.Text = diag2SchedVal;

                diag3des.Text = shortener2(diag3desVal);
                diag3name.Text = diag3NameVal;
                diag3sched.Text = diag3SchedVal;

                diag4des.Text = shortener3(diag4desVal);
                diag4name.Text = diag4NameVal;
                diag4sched.Text = diag4SchedVal;

                diag5des.Text = "";
                diag5name.Text = "";
                diag5sched.Text = "";
            }


            if (count == 5)
            {
                diag1des.Text = shortener(diag1desVal);
                diag1name.Text = diag1NameVal;
                diag1sched.Text = diag1SchedVal;

                diag2des.Text = shortener1(diag2desVal);
                diag2name.Text = diag2NameVal;
                diag2sched.Text = diag2SchedVal;

                diag3des.Text = shortener2(diag3desVal);
                diag3name.Text = diag3NameVal;
                diag3sched.Text = diag3SchedVal;

                diag4des.Text = shortener3(diag4desVal);
                diag4name.Text = diag4NameVal;
                diag4sched.Text = diag4SchedVal;

                diag5des.Text = shortener4(diag5desVal);
                diag5name.Text = diag5NameVal;
                diag5sched.Text = diag5SchedVal;
            }

              



    


            sql_con.Close();
        }

        private void viewCard3_Click(object sender, EventArgs e)
        {
            patientCardReset();
            isCardOn = true;
            getPatientData(p3ID);
            patientCardOnOff();
        }

        private void viewCard2_Click(object sender, EventArgs e)
        {
            patientCardReset();
            isCardOn = true;
            getPatientData(p2ID);
            patientCardOnOff();
        }

        private void viewCard1_Click(object sender, EventArgs e)
        {
            patientCardReset();
            isCardOn = true;
         
            

            getPatientData(p1ID);
            patientCardOnOff();
        }

        private void donePatient1_Click(object sender, EventArgs e)
        {
           
            string txtQuery = "update Appointments set isActive = 0 WHERE SJCA_ID = '" + appointMent1ID + "' AND isActive = 1 ";
            executeQuery(txtQuery);
            initGetPatient();
            getpatientsCount();
            getPatientOverall();
            getAppointmentsCount();
            getAppointmentsDoneCount();
            //updateLiveQueue();
        }


        private void donePatient2_Click_1(object sender, EventArgs e)
        {
            string txtQuery = "update Appointments set isActive = 0 WHERE SJCA_ID = '" + appointMent2ID + "' AND isActive = 1 ";
            executeQuery(txtQuery);
            initGetPatient();
            getpatientsCount();
            getPatientOverall();
            getAppointmentsCount();
            getAppointmentsDoneCount();
            //updateLiveQueue();
        }


        private void donePatient3_Click(object sender, EventArgs e)
        {


            string txtQuery = "update Appointments set isActive = 0 WHERE SJCA_ID = '" + appointMent3ID + "' AND isActive = 1 ";
            executeQuery(txtQuery);
            initGetPatient();
            getpatientsCount();
            getPatientOverall();
            getAppointmentsCount();
            getAppointmentsDoneCount();
            //updateLiveQueue();
        }


        private void patientCardReset()
        {
            diag1des.Text = "";
            diag1name.Text = "";
            diag1sched.Text = "";

            diag2des.Text = "";
            diag2name.Text = "";
            diag2sched.Text = "";

            diag3des.Text = "";
            diag3name.Text = "";
            diag3sched.Text = "";

            diag4des.Text = "";
            diag4name.Text = "";
            diag4sched.Text = "";

            diag5des.Text = "";
            diag5name.Text = "";
            diag5sched.Text = "";


            pres1.Text = "";
            pres1sched.Text = "";

            pres2.Text = "";
            pres2sched.Text = "";

            pres3.Text = "";
            pres3sched.Text = "";

            pres4.Text = "";
            pres4sched.Text = "";

            pres4.Text = "";
            pres4sched.Text = "";


            diag1desVal = "";
            diag2desVal = "";
            diag3desVal = "";
            diag4desVal = "";
            diag5desVal = "";
        }

        private void patientCardOnOff()
        {
            if (isCardOn)
            {
                patientCardOff.Visible = false;

                patientCardName.Visible = true;
                patientCardAddress.Visible = true;
                patientCardBday.Visible = true;
                prevDiaTitle.Visible = true;
                prevPresTitle.Visible = true;
                panel4.Visible = true;
                patientCardCloseBtn.Visible = true;

                pres1.Visible = true;
                pres1sched.Visible = true;

                pres2.Visible = true;
                pres2sched.Visible = true;

                pres3.Visible = true;
                pres3sched.Visible = true;

                pres4.Visible = true;
                pres4sched.Visible = true;

                pres5.Visible = true;
                pres5sched.Visible = true;


                diag1des.Visible = true;
                diag1name.Visible = true;
                diag1sched.Visible = true;

                diag2des.Visible = true;
                diag2name.Visible = true;
                diag2sched.Visible = true;

                diag3des.Visible = true;
                diag3name.Visible = true;
                diag3sched.Visible = true;

                diag4des.Visible = true;
                diag4name.Visible = true;
                diag4sched.Visible = true;

                diag5des.Visible = true;
                diag5name.Visible = true;
                diag5sched.Visible = true;
                diagnoseBtn.Visible = true;

            } else
            {

                patientCardOff.Visible = true;

                diagnoseBtn.Visible = false;
                patientCardName.Visible = false;
                patientCardAddress.Visible = false;
                patientCardBday.Visible = false;
                prevDiaTitle.Visible = false;
                prevPresTitle.Visible = false;
                panel4.Visible = false;
                patientCardCloseBtn.Visible = false;

                pres1.Visible = false;
                pres1sched.Visible = false;

                pres2.Visible = false;
                pres2sched.Visible = false;

                pres3.Visible = false;
                pres3sched.Visible = false;

                pres4.Visible = false;
                pres4sched.Visible = false;

                pres5.Visible = false;
                pres5sched.Visible = false;


                diag1des.Visible = false;
                diag1name.Visible = false;
                diag1sched.Visible = false;

                diag2des.Visible = false;
                diag2name.Visible = false;
                diag2sched.Visible = false;

                diag3des.Visible = false;
                diag3name.Visible = false;
                diag3sched.Visible = false;

                diag4des.Visible = false;
                diag4name.Visible = false;
                diag4sched.Visible = false;

                diag5des.Visible = false;
                diag5name.Visible = false;
                diag5sched.Visible = false;

            }
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

                p1Name = sql_dbr.GetString(2) + ", " + sql_dbr.GetString(1);
                count = count + 1;

            }

          
            p1DashName.Text = p1Name;

        

            prevp1ID = i;
            sql_con.Close();
        }




        private void patient2Data(int i)
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

                p2Name = sql_dbr.GetString(2) + ", " + sql_dbr.GetString(1);
                count = count + 1;

            }

            p2DashName.Text = p2Name;

            prevp2ID = i;
            sql_con.Close();
        }

        private void patient3Data(int i)
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

                p3Name = sql_dbr.GetString(2) + ", " + sql_dbr.GetString(1);
                count = count + 1;

            }

           

            p3DashName.Text = p3Name;


            prevp3ID = i;
            sql_con.Close();
        }


        private void getAuthData()
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

        private void setDashNames()
        {

            if ( DateTime.Now.ToString("tt") == "pm")
            {
                dashboardGreetingName.Text = "Good Morning Dr. " + authLastName;
            } else
            {
                dashboardGreetingName.Text = "Good Morning Dr. " + authLastName;
            }
            
            dashbboardTopName.Text = authLastName + ", " + authFirstName;
        }

        private void updateLiveQueue()
        {
           
            
            livequeue queue = new livequeue();
            queue.fetch();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            dashboardTab.SelectedIndex = 0;
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 3;
        }

     

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dashboardTab.SelectedIndex = 10;
        }

      

        private void dashboard_Load(object sender, EventArgs e)
        {
            getAuthData();
            setDashNames();
            getpatientsCount();
            getPatientOverall();
            getAppointmentsCount();
            getAppointmentList();
            initGetPatient();
            getAppointmentsDoneCount();
            patientCardOnOff();
            GenerateSessionID();

          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            isCardOn = false;
            patientCardOnOff();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FeatureMaster dev = new FeatureMaster();
            this.Hide();
            dev.ShowDialog();
            this.Close();
        }


        private void getPatientOverall()
        {

            string txtQuery = "SELECT * FROM Staff_Patient WHERE   SJCSPR_Staff = '" + authID + "' ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {
                count = count + 1;

            }



            patientOverall.Text = count.ToString();


            sql_con.Close();

            
        }

        private void getpatientsCount()
        {
            string txtQuery = "SELECT * FROM Staff_Patient WHERE isActive = 1 AND SJCSPR_Staff = '" + authID + "' ";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {
                count = count + 1;

            }

           

            patientCount.Text = count.ToString();


            sql_con.Close();
        }

        private void getAppointmentsCount()
        {
            // string txtQuery = "SELECT * FROM Appointments WHERE isActive = 1 AND  SJCA_Staff = '" + authID + "' AND  SJCA_Schedule = '" + DateTime.Now.ToShortDateString() + "' ";

            string txtQuery = "Select a.SJCA_ID, a.SJCA_StaffPatientID, a.SJCA_Schedule,  sp.SJCSPR_Staff from Appointments AS a INNER JOIN Staff_Patient AS sp ON sp.SJCSPR_Staff = '" + authID + "' AND a.SJCA_StaffPatientID = sp.SJCSPR_ID AND a.SJCA_Schedule = '" + DateTime.Now.ToShortDateString() + "';";

            


            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {
                count = count + 1;

            }


  

            dateNow.Text = DateTime.Now.ToLongDateString();
            AppointmentCount.Text = count.ToString();


            sql_con.Close();
        }

        private void getAppointmentsDoneCount()
        {
            string txtQuery = "Select a.SJCA_ID, a.SJCA_StaffPatientID, a.SJCA_Schedule,  sp.SJCSPR_Staff from Appointments AS a INNER JOIN Staff_Patient AS sp ON sp.SJCSPR_Staff = '" + authID + "' AND a.isActive = 0 AND a.SJCA_StaffPatientID = sp.SJCSPR_ID AND a.SJCA_Schedule = '" + DateTime.Now.ToShortDateString() + "'";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {
                count = count + 1;

            }





            appointmenstDone.Text = count.ToString();


            sql_con.Close();
        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SJCAUTH auth = new SJCAUTH();
            this.Hide();
            auth.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            livequeue queue = new livequeue();
            queue.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

        private void prescriptionUnit_Enter(object sender, EventArgs e)
        {
            if (prescriptionUnit.Text == "Prescriptions Unit")
            {
                prescriptionUnit.Text = "";
            }
        }

        private void prescriptionUnit_Leave(object sender, EventArgs e)
        {
            if (prescriptionUnit.Text == "")
            {
                prescriptionUnit.Text = "Prescriptions Unit";
            }
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

    

        private void addNewMedName_Enter(object sender, EventArgs e)
        {
            if (addNewMedName.Text == "Med Name")
            {
                addNewMedName.Text = "";
            }
        }

        private void addNewMedName_Leave(object sender, EventArgs e)
        {
            if (addNewMedName.Text == "")
            {
                addNewMedName.Text = "Med Name";
            }
        }

        private void addNewMedBrand_Enter(object sender, EventArgs e)
        {
            if (addNewMedBrand.Text == "Med Brand")
            {
                addNewMedBrand.Text = "";
            }
        }

        private void addNewMedBrand_Leave(object sender, EventArgs e)
        {
            if (addNewMedBrand.Text == "")
            {
                addNewMedBrand.Text = "Med Brand";
            }
        }

        private void addNewMedStock_Enter(object sender, EventArgs e)
        {
            if (addNewMedStock.Text == "Stock")
            {
                addNewMedStock.Text = "";
            }
        }

        private void addNewMedStock_Leave(object sender, EventArgs e)
        {
            if (addNewMedStock.Text == "")
            {
                addNewMedStock.Text = "Stock";
            }
        }

        private void addNewMedDesc_Enter(object sender, EventArgs e)
        {
            if (addNewMedDesc.Text == "Med Descriptions")
            {
                addNewMedDesc.Text = "";
            }
        }

        private void addNewMedDesc_Leave(object sender, EventArgs e)
        {
            if (addNewMedDesc.Text == "")
            {
                addNewMedDesc.Text = "Med Descriptions";
            }
        }

        private void resetAddnewMedTexts()
        {
            addNewMedName.Text = "Med Name";
            addNewMedBrand.Text = "Med Brand";
            addNewMedStock.Text = "Stock";
            addNewMedDesc.Text = "Med Descriptions";
        }

        private void resetViewnewMedTexts()
        {
            viewMedName.Text = "Med Name";
            viewMedBrand.Text = "Med Brand";
            viewMedStock.Text = "Stock";
            viewMedDesc.Text = "Med Descriptions";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            resetAddnewMedTexts();
        }

        private void viewMedName_Enter(object sender, EventArgs e)
        {
            if (viewMedName.Text == "Med Name")
            {
                viewMedName.Text = "";
            }
        }

        private void viewMedName_Leave(object sender, EventArgs e)
        {
            if (viewMedName.Text == "")
            {
                viewMedName.Text = "Med Name";
            }
        }

        private void viewMedBrand_Enter(object sender, EventArgs e)
        {
            if (viewMedBrand.Text == "Med Brand")
            {
                viewMedBrand.Text = "";
            }
        }

        private void viewMedBrand_Leave(object sender, EventArgs e)
        {
            if (viewMedBrand.Text == "")
            {
                viewMedBrand.Text = "Med Brand";
            }
        }

        private void viewMedStock_Enter(object sender, EventArgs e)
        {
            if (viewMedStock.Text == "Stock")
            {
                viewMedStock.Text = "";
            }
        }

        private void viewMedStock_Leave(object sender, EventArgs e)
        {
            if (viewMedStock.Text == "")
            {
                viewMedStock.Text = "Stock";
            }
        }

        private void viewMedDesc_Enter(object sender, EventArgs e)
        {
            if (viewMedDesc.Text == "Med Descriptions")
            {
                viewMedDesc.Text = "";
            }
        }

        private void viewMedDesc_Leave(object sender, EventArgs e)
        {
            if (viewMedDesc.Text == "")
            {
                viewMedDesc.Text = "Med Descriptions";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            resetViewnewMedTexts();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

     
    }
}
