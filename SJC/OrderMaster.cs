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
    public partial class OrderMaster : Form
    {

        private SQLiteDataAdapter sql_adptr;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataReader sql_dbr;

        private DataSet DSOrders = new DataSet();
        private DataTable DTOrders = new DataTable();


        private static int isDiscounted = 0;
        private static double change1;
        private static double vater;

        private static double discount;




        public OrderMaster()
        {
            InitializeComponent();
        }

        private void setConnection()
        {
            sql_con = new SQLiteConnection("Data Source = SJCDB.db; Version = 3; New = False; Compress = True;");
        }



        private void OrderMaster_Load(object sender, EventArgs e)
        {


            vater = Convert.ToDouble(POS.OrderTotal) * Convert.ToDouble("0.12");
            vater = vater + POS.OrderTotal;
            txtTotal.Text = "Total : " +  vater;
            orderDetails.Text = "+12% VAT";

            setConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            // Employee
            string CommandText = "SELECT SJCO_ProductName AS MEDICATION, SJCO_Price AS PRICE, SJCO_Quantity AS QUANTITY, SJCO_OverAll AS OVERALL  FROM Orders WHERE SJCO_SessionID = '" + POS.OrderNumber + "' AND SJCO_isArchived = 0";
            sql_adptr = new SQLiteDataAdapter(CommandText, sql_con);
            DSOrders.Reset();
            sql_adptr.Fill(DSOrders);
            DTOrders = DSOrders.Tables[0];
            dataGridView1.DataSource = DTOrders;

            sql_con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            if (OrderCash.Text == string.Empty || OrderCash.Text == "Cash" || orderMod.Text == string.Empty || orderMod.Text == string.Empty)
            {

                MessageBox.Show("Please input all the required data.");

            } else
            {
               

                if (OrderPatient.Text == string.Empty || OrderPatient.Text == "Customer ID")
                {
              


                    change1 = int.Parse(OrderCash.Text) - vater;


                    changeText.Text = "Change: " + change1;


                    sql_con.Close();


                } else
                {

              

                    setConnection();
                    sql_con.Open();
                    sql_cmd = sql_con.CreateCommand();
                    sql_cmd.CommandText = "SELECT * FROM Patient WHERE SJCP_ID = '" + OrderPatient.Text + "'";
                    sql_cmd.ExecuteNonQuery();
                    sql_dbr = sql_cmd.ExecuteReader();
                    int count = 0;
                    while (sql_dbr.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        isDiscounted = 1;

                        discount = vater * Convert.ToDouble("0.10");
                        discount = Convert.ToDouble(POS.OrderTotal) - discount;
                        txtTotal.Text = "Total: " + discount;
                        orderDetails.Text = "+12% VAT - 10% Discount";

                        change1 = int.Parse(OrderCash.Text) - discount;


                        changeText.Text = "Change: " + change1;

                    }
                    else
                    {
                        MessageBox.Show("Customer ID not found");
                    }


                    sql_con.Close();


                }
            }

         


          

            submitToDB(); 
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

        private void submitToDB()
        {
            string txtQuery = "INSERT into Orders_Master (SJCOM_Session, SJCOM_Date, SJCOM_Cash, SJCOM_MOD,  SJCOM_Change,  SJCOM_isArchive, SJCOM_isDiscounted) values ('" + POS.OrderNumber + "', '" + DateTime.Now.ToShortDateString() + "', '" + OrderCash.Text + "', '" + orderMod.Text + "', '" + change1 + "', '" + 0 + "' , '" + isDiscounted + "')";
            executeQuery(txtQuery);

            getItemData();
        }


        public void getItemData()
        {

         

            int stockNow = 0;

            foreach (var val in POS.ShoppingCart)
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

            POS.ShoppingCart.Clear();
        }

        private void minusToStocks(string id, int stockMinused)
        {

            string txtQuery = "update Medication set SJCM_Stock = '" + stockMinused + "' WHERE SJCM_ItemID = '" + id + "' ";

            executeQuery(txtQuery);


        }




    }
}
