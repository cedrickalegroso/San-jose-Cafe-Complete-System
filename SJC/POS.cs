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
    public partial class POS : Form
    {
        public POS()
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


        // Meds
        public static string selectedMedID;
        private DataSet DSMeds = new DataSet();
        private DataTable DTMEds = new DataTable();

        private static string SelectedVewMedID;
        private static string SelectedVewMedSessionID;
        


        // Meds
        public static string selectedMedOVRID;
        private DataSet DSOVRMeds = new DataSet();
        private DataTable DTOVRMEds = new DataTable();


        // View Session Meds
        // public static string selectedMedID;
        private DataSet DSViewMeds = new DataSet();
        private DataTable DTViewMeds = new DataTable();


        private DataSet DSOrders = new DataSet();
        private DataTable DTOrders = new DataTable();

        private DataSet DSMOrders = new DataSet();
        private DataTable DTMOrders = new DataTable();

        private DataSet DSVMOrders = new DataSet();
        private DataTable DTVMOrders = new DataTable();



        // Add New Session Meds
        // public static string selectedMedID;
        private DataSet DSAddMeds = new DataSet();
        private DataTable DTAddMEds = new DataTable();


        private static string edFNVAL;
        private static string edLNVAL;
        private static string edGenVAL;
        private static string edAddVAL;
        private static string edBdayVAL;

        private static string authUserPass;
        private static string authUserVal;


        //sessions
        public static string GeneratedSessionPOSID;
        public static string GeneratedItemPOSID;


        //sessions
        public static string GeneratedSessionID;
        public static string GeneratedSessionMedID;
        public static string GeneratedItemMedID;

        private static string SelectedAddnewMedID;

        private static int addedMedInASessionCount;
        private static int addedViewMedInASessionCount;




        private static int CurrentSessionTotal = 0;

        private static string prdName;
        private static string prdPrice;


        public static int OrderTotal;
        public static string OrderNumber;

        private static string SelectedORDERM;

        public static List<KeyValuePair<string, int>> ShoppingCart = new List<KeyValuePair<string, int>>();

        private void medsInventoryDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedMedID = medsInventoryDgv.SelectedRows[0].Cells[0].Value.ToString();

          
        }

        private void GenerateSessionID(int length = 4)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            GeneratedSessionPOSID = "Session-" + randomString;

        }

        private void GenerateItemID(int length = 4)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            GeneratedItemPOSID = "Item_Order-" + randomString;

        }

        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }

        private void POS_Load(object sender, EventArgs e)
        {
            loadCurrentSessiionOrderPOS();
            getData();
            GenerateSessionID();
            GenerateItemID();
            setDashNames();

            SessionIDDash.Text = GeneratedSessionPOSID;
            itemSessiondash.Text = GeneratedItemPOSID;
            totalPOS.Text =  "Total : " + CurrentSessionTotal.ToString();
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


        private void setDashNames()
        {
            dashbboardTopName.Text = authLastName + ", " + authFirstName;
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            tabControl1.SelectedIndex = 4;
            loadMeds();
            loadMedsOverall();
        }


        private void loadMeds()
        {

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCMI_Session AS SESSION, SJCMI_Date AS DATE  FROM Medication_Inventory";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSMeds.Reset();
            sql_adptr.Fill(DSMeds);
            DTMEds = DSMeds.Tables[0];
            medsInventoryDgv.DataSource = DTMEds;

            sql_con.Close();
        }


        private void loadMedsOverall()
        {


            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SCJM_Name, SCJM_Brand , SCJM_Description, SUM(SJCM_Stock) FROM Medication WHERE SJCM_isArchive = 0 GROUP BY SCJM_Name; ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSOVRMeds.Reset();
            sql_adptr.Fill(DSOVRMeds);
            DTOVRMEds = DSOVRMeds.Tables[0];
            MedsInv.DataSource = DTOVRMEds;

            sql_con.Close();
        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            getDataandInfo();

            tabControl1.SelectedIndex = 2;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
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
            GeneratedItemMedID =  randomString;

        }


        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;

            GenerateSessionMedID();
            GenerateItemMedID();
            loadCurrentMedSession();
            SessionAddMed.Text = GeneratedSessionMedID;
        }

        private void loadCurrentMedSession()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SCJM_Name AS NAME, SCJM_Brand AS BRAND, SJCM_Stock AS STOCK, SCJM_Price AS Price,  SCJM_Description AS DESCRIPTION,  SJCM_DateExp AS DATEEXPIRE, SCJM_DateAdded DATEADDED, SJCM_ItemID AS ITEM, SJCM_SessionID AS SESSION  FROM Medication WHERE SJCM_SessionID = '" + GeneratedSessionMedID + "'  ";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSAddMeds.Reset();
            sql_adptr.Fill(DSAddMeds);
            DTAddMEds = DSAddMeds.Tables[0];
            addNewMedDGV.DataSource = DTAddMEds;

            sql_con.Close();
        }

        private void loadAddMedSession()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();


            string CommandText = "SELECT SCJM_Name AS NAME, SCJM_Brand AS BRAND, SJCM_Stock AS STOCK, SCJM_Price AS PRICE,  SCJM_Description AS DESCRIPTION,  SJCM_DateExp AS DATEEXPIRE, SCJM_DateAdded DATEADDED, SJCM_ItemID AS ITEM, SJCM_SessionID AS SESSION  FROM Medication WHERE SJCM_SessionID = '" + selectedMedID + "' AND  SJCM_isArchive = 0 ";

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

        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedVewMedID = viewMedSessionDGV.SelectedRows[0].Cells[6].Value.ToString();

            SelectedVewMedSessionID = viewMedSessionDGV.SelectedRows[0].Cells[7].Value.ToString();

            //viewMedName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //viewMedBrand1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //viewMedStock1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //viewMedPrice1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //viewMedDesc1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //viewMedEXPDATE1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
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

        private void resetAddnewMedTexts()
        {
            addNewMedName.Text = "Med Name";
            addNewMedBrand.Text = "Med Brand";
            addNewMedStock.Text = "Stock";
            addNewMedDesc.Text = "Med Descriptions";
            addNewMedPrice.Text = "Price";
        }

        private void resetViewnewMedTexts()
        {
            viewMedName.Text = "Med Name";
            viewMedBrand.Text = "Med Brand";
            viewMedStock.Text = "Stock";
            viewMedDesc.Text = "Med Descriptions";
            viewMedPrice.Text = "Price";
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

        private void button16_Click(object sender, EventArgs e)
        {
            resetViewnewMedTexts();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (selectedMedID != null)
            {
                label24.Text = selectedMedID;
                tabControl1.SelectedIndex = 8;
                loadAddMedSession();
            }
            else
            {
                MessageBox.Show("Select a Medication first", "Error");
            }

        }

  

        private void viewMedSessionDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedVewMedID = viewMedSessionDGV.SelectedRows[0].Cells[7].Value.ToString();
            SelectedVewMedSessionID = viewMedSessionDGV.SelectedRows[0].Cells[8].Value.ToString();


            viewMedName.Text = viewMedSessionDGV.SelectedRows[0].Cells[0].Value.ToString();
            viewMedBrand.Text = viewMedSessionDGV.SelectedRows[0].Cells[1].Value.ToString();
            viewMedStock.Text = viewMedSessionDGV.SelectedRows[0].Cells[2].Value.ToString();
            viewMedPrice.Text = viewMedSessionDGV.SelectedRows[0].Cells[3].Value.ToString();
            viewMedDesc.Text = viewMedSessionDGV.SelectedRows[0].Cells[4].Value.ToString();
            viewMedEXPDATE.Text = viewMedSessionDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void medsInventoryDgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectedMedID = medsInventoryDgv.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {

          //  MessageBox.Show(SelectedVewMedID);

            addedViewMedInASessionCount = addedViewMedInASessionCount + int.Parse(viewMedStock.Text);

            string txtQuery = "update Medication set SCJM_Name = '" + viewMedName.Text + "', SCJM_Brand = '" + viewMedBrand.Text + "', SCJM_Description = '" + viewMedDesc.Text + "', SJCM_Stock = '" + viewMedStock.Text + "', SJCM_DateExp = '" + viewMedEXPDATE.Value.ToShortDateString() + "'  WHERE SJCM_ItemID = '" + SelectedVewMedID + "' AND SJCM_isArchive = 0 ";

            executeQuery(txtQuery);
            loadAddMedSession();
            GenerateItemMedID();
            resetAddnewMedTexts();

            MessageBox.Show("Medication Updated Successfully", "Successfull");
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            resetViewnewMedTexts();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            if (SelectedVewMedID != null)
            {

                addedViewMedInASessionCount = addedViewMedInASessionCount - int.Parse(viewMedStock.Text);


                string txtQuery = "update Medication set SJCM_isArchive = 3 WHERE SJCM_ItemID = '" + SelectedVewMedID + "' AND SJCM_isArchive = 0 ";
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

        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show(int.Parse(viewMedStock.Text).ToString());

            MessageBox.Show(SelectedVewMedSessionID.ToString());
            

            addedViewMedInASessionCount = int.Parse(viewMedStock.Text);


            string txtQuery = "update Medication_Inventory set SJCMI_Session = '" + SelectedVewMedSessionID + "',  SJCMI_Date = '" + DateTime.Now.ToShortDateString() + "',  SJCMI_Count = '" + addedViewMedInASessionCount + "' WHERE SJCMI_Session = '" + SelectedVewMedSessionID + "' AND SJCMI_isArchive = 0 ";
            executeQuery(txtQuery);
            loadMedsOverall();
            loadMeds();
          
            MessageBox.Show(" Inventory Updated", "Successfull");
            addedViewMedInASessionCount = 0;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;

            GenerateSessionMedID();
            GenerateItemMedID();
            loadCurrentMedSession();
            SessionAddMed.Text = GeneratedSessionMedID;
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

        private void addNewMedPrice_Leave(object sender, EventArgs e)
        {
            if (addNewMedPrice.Text == "")
            {
                addNewMedPrice.Text = "Price";
            }
        }

        private void addNewMedPrice_Enter(object sender, EventArgs e)
        {
            if (addNewMedPrice.Text == "Price")
            {
                addNewMedPrice.Text = "";
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            //addNewMedPrice
            string txtQuery = "INSERT into Medication (SCJM_Name, SCJM_Brand, SCJM_Description, SCJM_DateAdded, SJCM_Stock, SJCM_DateExp, SJCM_ItemID, SJCM_SessionID, SJCM_isArchive, SCJM_Price) values ('" + addNewMedName.Text + "', '" + addNewMedBrand.Text + "', '" + addNewMedDesc.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + addNewMedStock.Text + "', '" + addNewMedEXP.Value.ToShortDateString() + "', '" + GeneratedItemMedID + "', '" + GeneratedSessionMedID + "', '" + 1 + "', '" + addNewMedPrice.Text + "')";
            addedMedInASessionCount = addedMedInASessionCount + int.Parse(addNewMedStock.Text);
            executeQuery(txtQuery);
            loadCurrentMedSession();
            GenerateItemMedID();
            resetAddnewMedTexts();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            addedMedInASessionCount = addedMedInASessionCount + int.Parse(addNewMedStock.Text);

            string txtQuery = "update Medication set SCJM_Name = '" + addNewMedName.Text + "', SCJM_Brand = '" + addNewMedBrand.Text + "', SCJM_Description = '" + addNewMedDesc.Text + "', SJCM_Stock = '" + addNewMedStock.Text + "', SJCM_DateExp = '" + addNewMedEXP.Value.ToShortDateString() + "'  WHERE SJCM_ItemID = '" + SelectedAddnewMedID + "' AND SJCM_isArchive = 0 ";

            executeQuery(txtQuery);
            loadCurrentMedSession();
            GenerateItemMedID();
            resetAddnewMedTexts();
        }

        private void archiveMedItem_Click(object sender, EventArgs e)
        {
            if (SelectedAddnewMedID != null)
            {

                addedMedInASessionCount = addedMedInASessionCount - int.Parse(addNewMedStock.Text);


                string txtQuery = "update Medication set SJCM_isArchive = 1 WHERE SJCM_ItemID = '" + SelectedAddnewMedID + "' AND SJCM_isArchive = 3 ";
                executeQuery(txtQuery);
                loadCurrentMedSession();
                GenerateItemMedID();
                resetAddnewMedTexts();



            }
            else
            {
                MessageBox.Show("Please select and item to archive first");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            resetAddnewMedTexts();
        }

        private void addMedicationToInventory()
        {
            string txtQuery = "INSERT into Medication_Inventory (SJCMI_Session, SJCMI_Date, SJCMI_Count, SJCMI_isArchive) values ('" + GeneratedSessionMedID + "', '" + DateTime.Now.ToShortDateString() + "', '" + addedMedInASessionCount + "', '" + 0 + "')";

            executeQuery(txtQuery);
            loadMeds();
            tabControl1.SelectedIndex = 4;
            addedMedInASessionCount = 0;
            MessageBox.Show("New Inventory added", "Successfull");
            unarchiveMedsAdded(GeneratedSessionMedID);
        }



        private void unarchiveMedsAdded(string s)
        {
            string txtQuery = "update Medication set SJCM_isArchive = '" + 0 + "' WHERE SJCM_SessionID = '" + s + "'";

            executeQuery(txtQuery);

        }

        private void button20_Click(object sender, EventArgs e)
        {

            addMedicationToInventory();
            loadMedsOverall();
        }

        private void addNewMedDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedAddnewMedID = addNewMedDGV.SelectedRows[0].Cells[6].Value.ToString();

            addNewMedName.Text = addNewMedDGV.SelectedRows[0].Cells[0].Value.ToString();
            addNewMedBrand.Text = addNewMedDGV.SelectedRows[0].Cells[1].Value.ToString();
            addNewMedStock.Text = addNewMedDGV.SelectedRows[0].Cells[2].Value.ToString();
            addNewMedPrice.Text = addNewMedDGV.SelectedRows[0].Cells[3].Value.ToString();
            addNewMedDesc.Text = addNewMedDGV.SelectedRows[0].Cells[4].Value.ToString();
            addNewMedEXP.Text = addNewMedDGV.SelectedRows[0].Cells[5].Value.ToString();

            addedMedInASessionCount = addedMedInASessionCount - int.Parse(addNewMedStock.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {

            addToSession();


        }


        private void addToSession()
        {

           


            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "Select * FROM Medication WHERE SJCM_ItemID = '" + prdCode.Text + "'";
            sql_cmd.ExecuteNonQuery();
            sql_dbr = sql_cmd.ExecuteReader();
            int count = 0;
            while (sql_dbr.Read())
            {


            
                prdName = sql_dbr.GetString(1);
                prdPrice = sql_dbr.GetString(6);
                count = count + 1;

            }

            if (count == 1)
            {
                addToCurrentSessionPOS(prdName, int.Parse(prdPrice));

                

                ShoppingCart.Add(new KeyValuePair<string, int>(prdCode.Text, int.Parse(prdQuan.Text)));

            } else
            {
                MessageBox.Show("Item Does not exist");
            }

          

         

            sql_con.Close();
        }

        private void addToCurrentSessionPOS(string name, int price)
        {

            CurrentSessionTotal = CurrentSessionTotal + (int.Parse(prdPrice) * int.Parse(prdQuan.Text));

            OrderTotal = CurrentSessionTotal;

            totalPOS.Text = "Total : " + CurrentSessionTotal.ToString();

            string txtQuery = "INSERT into Orders (SJCO_SessionID, SJCO_ProductName, SJCO_Price, SJCO_Quantity, SJCO_Date ,SJCO_isArchived, SJCO_OverAll) values ('" + GeneratedSessionPOSID + "', '" + name + "', '" + prdPrice + "', '" + prdQuan.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + 0 + "', '" + int.Parse(prdPrice) * int.Parse(prdQuan.Text) + "')";

            prdName = "";
            prdPrice = "";
            GenerateItemMedID();
            SessionIDDash.Text = GeneratedSessionPOSID;
            itemSessiondash.Text = GeneratedItemPOSID;

            executeQuery(txtQuery);
            loadCurrentSessiionOrderPOS();
        }


        private void loadCurrentSessiionOrderPOS()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCO_ProductName AS MEDICATION, SJCO_Price AS PRICE, SJCO_Quantity AS QUANTITY, SJCO_OverAll AS OVERALL  FROM Orders WHERE SJCO_SessionID = '" + GeneratedSessionPOSID + "' AND SJCO_isArchived = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSOrders.Reset();
            sql_adptr.Fill(DSOrders);
            DTOrders = DSOrders.Tables[0];
            OrderDGV.DataSource = DTOrders;

            sql_con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            OrderNumber = GeneratedSessionPOSID;


            OrderMaster ord = new OrderMaster();
            ord.ShowDialog();

       //     string txtQuery = "INSERT into Orders_Master (SJCOM_Session, SJCOM_Date, SJCOM_isArchive) values ('" + GeneratedSessionPOSID + "', '" + DateTime.Now.ToShortDateString() + "', '" + 0 + "')";

            prdName = "";
            prdPrice = "";
            GenerateItemMedID();
            GenerateSessionID();
            CurrentSessionTotal = 0;
            totalPOS.Text = "Total";
            SessionIDDash.Text = GeneratedSessionPOSID;
            itemSessiondash.Text = GeneratedItemPOSID;

         //   executeQuery(txtQuery);
            loadCurrentSessiionOrderPOS();


            prdCode.Text = "Product Code";
            prdQuan.Text = "Quantity";

           // getItemData();
        }


        public void getItemData()
        {

            

            int stockNow = 0;

            foreach (var val in ShoppingCart)
            {
                setConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "Select * FROM Medication WHERE SJCM_ItemID = '" + val.Key + "'";
                sql_cmd.ExecuteNonQuery();
                sql_dbr = sql_cmd.ExecuteReader();
                int count = 0;
                while (sql_dbr.Read())
                {



                    stockNow = sql_dbr.GetInt32(5);
                  
                    count = count + 1;

                }


                stockNow = stockNow - val.Value;

                minusToStocks(val.Key, stockNow);

                sql_con.Close();


            }

            ShoppingCart.Clear();
        }

        private void minusToStocks(string id, int stockMinused)
        {
         
                string txtQuery = "update Medication set SJCM_Stock = '" + stockMinused + "' WHERE SJCM_ItemID = '" + id + "' ";

                executeQuery(txtQuery);

         
        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;

            loadOrders();
        }

        private void loadOrders()
        {
            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCOM_Session AS SESSION, SJCOM_Date AS DATE, SJCOM_Cash AS CASH, SJCOM_MOD AS MOD, SJCOM_Change AS CHANGE , SJCOM_isDiscounted AS DISCOUNTED  FROM Orders_Master WHERE  SJCOM_isArchive = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSMOrders.Reset();
            sql_adptr.Fill(DSMOrders);
            DTMOrders = DSMOrders.Tables[0];
            dataGridView2.DataSource = DTMOrders;

            sql_con.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedORDERM = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (SelectedORDERM == null )
            {
                MessageBox.Show("Please select a session first");
            } else
            {
                tabControl1.SelectedIndex = 7;
                loadOrderSessionItems();
            }
        }


        private void loadOrderSessionItems()
        {
            sessioNView.Text = SelectedORDERM;


            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCO_ProductName AS NAME, SJCO_Quantity AS QUANTITY, SJCO_Price AS PRICE, SJCO_OverAll AS OVERALL  FROM Orders WHERE  SJCO_SessionID = '"+ SelectedORDERM  + "' AND SJCO_isArchived = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSVMOrders.Reset();
            sql_adptr.Fill(DSVMOrders);
            DTVMOrders = DSVMOrders.Tables[0];
            dataGridView3.DataSource = DTVMOrders;

            sql_con.Close();

            
        }
    }
}
