using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace POS
{

    public partial class POSForm : Form
    {
        public string LogoPath { get; private set; }
        public string CashRegSoundPath { get; private set; }
        public string ProductPath { get; private set; }
        public string connectionString { get; private set; }
        public static string EconAgreementGrantToken { get; private set; }
        public static string EconAppSecretToken { get; private set; }
        public string Exitcode { get; private set; }
        public Thread thr { get; private set; }

        struct product
        {
            public string ProductNumber;
            public string ProductName;
            public float Price;
            public string ImageFileName;
        }
        product[] ProductArr = new product[4];

        public POSForm()
        {
            InitializeComponent();
        }

 

        private void label2_Click(object sender, EventArgs e)
        {

        }

              

        private void btn_Purchase_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "")  // No customer selected
            {
                // Error message
                lbl_LastPurchase.Text = "Ingen kunde valgt";
                lbl_LastPurchase.ForeColor = Color.Red;

                // Play Error sound
                System.Media.SystemSounds.Hand.Play();

                txt_Customer.Focus();
                return;
            }

           if (lsv_ShoppingCart.Items.Count == 0)
            {
                // Error message
                lbl_LastPurchase.Text = "Ingen varer i listen";
                lbl_LastPurchase.ForeColor = Color.Red;

                // Play Error sound
                System.Media.SystemSounds.Hand.Play();

                txt_Customer.Focus();
                return;
            }

            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;


            // Find transaction data
            DateTime localDate = DateTime.Now;

            if (!decimal.TryParse(txt_Total.Text, out decimal Total))
            {
                Total = 0;
            }

            // Insert/Update Invoice in Economic
            string txt;
            if (POSTransaction(txt_Customer.Text, "8000", 1, Total, out txt) != 0)
            {
                lbl_LastPurchase.Text = "Error in POS trans: " + txt;
                lbl_LastPurchase.ForeColor = Color.Red;
            }
            else
            {
                //Play ka-ching sound (CashRegSoundPath)
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(CashRegSoundPath);
                player.Play();

                // Log POS transaction to DB
                if (LogPOSTransactionToDB(out txt) != 0)
                {
                    lbl_LastPurchase.Text = "Error in POS trans: " + txt;
                    lbl_LastPurchase.ForeColor = Color.Red;
                }
                else
                {
                    // Show last order in label, in bottom of screen
                    lbl_LastPurchase.Text = localDate.ToString()
                        + " " + txt_Name.Text
                        + " " + txt_Total.Text + " DKK";
                    lbl_LastPurchase.ForeColor = Color.Black;
                }

                // Reset purchase data
                lsv_ShoppingCart.Items.Clear();

                txt_Customer.Clear();
                txt_Name.Clear();
                txt_Total.Clear();

                pnl_Products.Visible = false;
                pnl_Keyboard.Visible = true;

                txt_Customer.Focus();
                
            }
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Read App.config file
            LogoPath = ConfigurationManager.AppSettings["LogoPath"];
            CashRegSoundPath = ConfigurationManager.AppSettings["CashRegSoundPath"];
            ProductPath = ConfigurationManager.AppSettings["ProductPath"];
            EconAgreementGrantToken = ConfigurationManager.AppSettings["EconAgreementGrantToken"];
            EconAppSecretToken = ConfigurationManager.AppSettings["EconAppSecretToken"];
            Exitcode = ConfigurationManager.AppSettings["Exitcode"];

            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SelfServicePOS"].ConnectionString;
            
            // Load logo
            pic_Logo.ImageLocation = LogoPath;
            

            // Place buttons relative to window size
            btn_Close.Left = pnl_Toppanel.Left + pnl_Toppanel.Width - btn_Close.Width - 10;
            btn_History.Left = pnl_Toppanel.Left + pnl_Toppanel.Width -btn_History.Width -20 - btn_Close.Width - 10;

            pnl_Customer.Dock = DockStyle.Fill;

            lbl_Header.Left = (pnl_Toppanel.Width-lbl_Header.Width)/2;

            // Load products
            LoadProducts();

            lsv_ShoppingCart.Columns[0].Width = 0;
            lsv_ShoppingCart.Columns[1].Width = 120;


            lbl_LastPurchase.Text = "";

            pnl_Products.Visible = false;

            this.ActiveControl = txt_Customer;

            // Creating object of ExThread class
            EconomicRESTAPIThread obj = new EconomicRESTAPIThread();
            //EconomicThread obj = new EconomicThread();
            

            // Creating thread
            // Using thread class
            //Thread
            thr = new Thread(new ThreadStart(obj.ecothread));
            thr.Start();


        }
        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Check not empty field
                if (txt_Customer.Text == "")
                {
                    lbl_LastPurchase.Text = "Medlemsnummer skal indtastes";
                    lbl_LastPurchase.ForeColor = Color.Red;

                    // Play Error sound
                    System.Media.SystemSounds.Hand.Play();

                    txt_Customer.Focus();
                    return;
                }
                // Check not Exitcode
                if (txt_Customer.Text == Exitcode)
                {
                    DialogResult dialogResult = MessageBox.Show("Vil du afslutte programmet?", "Afslut", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (thr.IsAlive)
                        {
                            thr.Abort();
                            // Waiting for thread to terminate.
                            thr.Join();
                        }
                        Application.Exit();
                    }
                    txt_Customer.Text = "";
                    txt_Customer.Focus();
                    return;

                }

                
                if (validateCustomer(txt_Customer.Text, out string Name, out string txt) !=0)
                {
                    lbl_LastPurchase.Text = txt;
                    lbl_LastPurchase.ForeColor = Color.Red;
                    System.Media.SystemSounds.Hand.Play();
                    txt_Customer.Text = "";
                    txt_Customer.Focus();
                    return;
                }
                else
                {
                    txt_Name.Text = Name;

                    lbl_LastPurchase.Text = "";
                    lbl_LastPurchase.ForeColor = Color.Black;

                    pnl_Products.Visible = true;
                    pnl_Keyboard.Visible = false;
                }
               
                

                
            }
        }

       private void PurchaseItem(string productid, string product, int qty, float price)
        {
            if (txt_Name.Text == "")  // No customer selected
            {
                // Error message
                lbl_LastPurchase.Text = "Ingen kunde valgt";
                lbl_LastPurchase.ForeColor = Color.Red;

                // Play Error sound
                System.Media.SystemSounds.Hand.Play();

                txt_Customer.Focus();
                return;
            }

            //int itemQty;
            ListViewItem item1 = lsv_ShoppingCart.FindItemWithText(productid);

            Boolean SomethingFound = false;
            Boolean Found = false;
            string ProductFound = "";
            if (item1 != null)
                SomethingFound = true;

            if (SomethingFound)
            {
                ProductFound = item1.SubItems[0].Text;
                if (ProductFound == productid)
                    Found = true;

            }

            if (Found)
            {

                // Found -> Update
                // Qty
                if (!int.TryParse(item1.SubItems[2].Text, out int itemQty))
                    itemQty = 0;
                itemQty += qty;
                item1.SubItems[2].Text = itemQty.ToString();
                // Total
                if (!float.TryParse(item1.SubItems[4].Text, out float itemTotal))
                    itemTotal = 0;
                itemTotal += price;
                item1.SubItems[4].Text = itemTotal.ToString("F");
            }
            else
            {
                // Not found -> Insert
                ListViewItem listItem = new ListViewItem(productid, 0); // productid
                listItem.SubItems.Add(product); //product
                listItem.SubItems.Add(qty.ToString()); //Qty
                listItem.SubItems.Add(price.ToString("F")); //Pris
                listItem.SubItems.Add(price.ToString("F")); //Total
                lsv_ShoppingCart.Items.Add(listItem);

            }
            //lsv_ShoppingCart.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsv_ShoppingCart.Columns[0].Width = 0;
            lsv_ShoppingCart.Columns[1].Width = 120;

            if (!float.TryParse(txt_Total.Text, out float Total))
            { 
                Total = 0;
            }
            Total += price;

            txt_Total.Text = Total.ToString("F");
        }

       

        private void btn_Close_Click(object sender, EventArgs e)
        {
            // Display the password form.
            
            PasswordForm frm = new PasswordForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (thr.IsAlive)
                {
                    thr.Abort();
                    // Waiting for thread to terminate.
                    thr.Join();
                }
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Indsæt i listen
            int i = 0;

            if (sender == pictureBox1)
                i = 0;
            else if (sender == pictureBox2)
                i = 1;
            else if (sender == pictureBox3)
                i = 2;
            else if (sender == pictureBox4)
                i = 3;


            PurchaseItem(ProductArr[i].ProductNumber, ProductArr[i].ProductName, 1, ProductArr[i].Price);

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_Toppanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lsv_ShoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Reset purchase data
            lsv_ShoppingCart.Items.Clear();

            txt_Customer.Clear();
            txt_Name.Clear();
            txt_Total.Clear();

            pnl_Products.Visible = false;
            pnl_Keyboard.Visible = true;

            txt_Customer.Focus();
        }

        private void pnl_Product_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            HistoryForm frm = new HistoryForm();
            frm.ShowDialog(this);

        }

        private void btn_Key1_Click(object sender, EventArgs e)
        {
            if (lsv_ShoppingCart.Items.Count != 0 || txt_Name.Text !="")
                return;

            if (sender == btn_Key1)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("1");
            }
            else if (sender == btn_Key2)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("2");
            }
            else if (sender == btn_Key3)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("3");
            }
            else if (sender == btn_Key4)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("4");
            }
            else if (sender == btn_Key5)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("5");
            }
            else if (sender == btn_Key6)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("6");
            }
            else if (sender == btn_Key7)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("7");
            }
            else if (sender == btn_Key8)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("8");
            }
            else if (sender == btn_Key9)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("9");
            }
            else if (sender == btn_Key0)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("0");
            }
            else if (sender == btn_Enter)
            {
                txt_Customer.Focus();
                System.Windows.Forms.SendKeys.Send("{ENTER}");
            }
        }

        private void txt_Customer_Enter(object sender, EventArgs e)
        {
            //pnl_Keyboard.Visible = true;
        }

        private void txt_Customer_Leave(object sender, EventArgs e)
        {
            //pnl_Keyboard.Visible = false;
        }

        
        private int LogPOSTransactionToDB(out string ErrorTxt)
        {
            try
            {
                // Log to database SelfServicePOS
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                for (int i = 0; i < lsv_ShoppingCart.Items.Count; i++)
                {
                    if (!float.TryParse(lsv_ShoppingCart.Items[i].SubItems[3].Text, out float Price))
                        Price = 0;

                    String sql = "INSERT INTO POSTransaction (POSTimestamp, CustomerNumber, ProductNumber, Quantity, UnitNetPrice) values("
                        +"getdate(),"
                        + "'" + txt_Customer.Text + "'"
                        + ",'" + lsv_ShoppingCart.Items[i].SubItems[0].Text + "'"  //Productid
                        + "," + lsv_ShoppingCart.Items[i].SubItems[2].Text  //Quantity
                        + "," + Price.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)  //Price
                        + ")";
                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();
                }

                cnn.Close();
                ErrorTxt = "";
                return 0;
            }
            catch (Exception ex)
            {
                ErrorTxt = "SQL Fejl - " + ex.Message;
                return 99;
            }

        }

        private int POSTransaction(string Customer, String ProductPartnumber, int Qty, decimal Price, out string ErrorTxt)
        {
            ErrorTxt = "";
            int ErrorCode = 0;

            try
            {
                // Save Transaction in SQL database for later processing
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();


                String sql = "INSERT INTO EcoPOS (EcoPOSTimestamp, CustomerNumber, ProductNumber, Quantity, Total) values("
                        + "getdate(),"
                        + "'" + Customer + "'"
                        + ",'" + ProductPartnumber + "'"
                        + "," + Qty.ToString()  //Quantity
                        + "," + Price.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)
                        + ")";
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();


                cnn.Close();
                ErrorTxt = "";

                return ErrorCode;
            }
            catch (Exception ex)
            {
                ErrorTxt = "POSTransaction Fejl - " + ex.Message;
                return 99;
            }

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
        private void LoadProducts()
        {
            try
            {
                var Products = new DataTable();
                using (var da = new SqlDataAdapter("SELECT * FROM Product", connectionString))
                {
                    da.Fill(Products);
                }

                pictureBox1.ImageLocation = "";
                pictureBox2.ImageLocation = "";
                pictureBox3.ImageLocation = "";
                pictureBox4.ImageLocation = "";

                lbl_Price1.Text = "";
                lbl_Price2.Text = "";
                lbl_Price3.Text = "";
                lbl_Price4.Text = "";


                for (int i = 0; i < Products.Rows.Count; i++)
                {

                    if (!float.TryParse(Products.Rows[i]["Price"].ToString(), out float Price))
                        Price = 0;

                    ProductArr[i].ProductNumber = Products.Rows[i]["ProductNumber"].ToString();
                    ProductArr[i].ProductName = Products.Rows[i]["ProductName"].ToString();
                    ProductArr[i].Price = Price;
                    ProductArr[i].ImageFileName = Products.Rows[i]["ImageFileName"].ToString();

                    switch (i)
                    {
                        case 0:
                            lbl_Price1.Text = Price.ToString("F") + " DKK"; ;
                            pictureBox1.ImageLocation = ProductPath + ProductArr[i].ImageFileName;

                            break;
                        case 1:
                            lbl_Price2.Text = Price.ToString("F") + " DKK"; ;
                            pictureBox2.ImageLocation = ProductPath + ProductArr[i].ImageFileName;
                            break;
                        case 2:
                            lbl_Price3.Text = Price.ToString("F") + " DKK"; ;
                            pictureBox3.ImageLocation = ProductPath + ProductArr[i].ImageFileName;
                            break;
                        case 3:
                            lbl_Price4.Text = Price.ToString("F") + " DKK"; ;
                            pictureBox4.ImageLocation = ProductPath + ProductArr[i].ImageFileName;
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Fejl: " + ex.Message);

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private int validateCustomer(string CustomerNumber, out string Name, out string ErrorTxt)
        {

            Name = "";

            // Validate Customer agaist database
            int Err = ValidateCustomerDB(CustomerNumber, out Name, out ErrorTxt);

            if (Err>0) //Database fejl
            {
                return Err;
            }

            if (Err < 0) //Customer not found
            {
                int r = EconomicCustomers.Customer.FindCustomer(CustomerNumber, out Name);
                if (r == 0)
                {
                    // Insert i SQL
                    if (SaveCustomerToDB(CustomerNumber, Name, out ErrorTxt) != 0)
                    {
                        return 99;
                    }
                }
                
            }
            ErrorTxt = "";
            return 0;
        }

        private int SaveCustomerToDB(string CustomerNumber, string CustomerName, out string ErrorTxt)
        {
            try
            {
                // Log to database SelfServicePOS
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                String sql = "INSERT INTO Customer (CustomerNumber, CustomerName) values("
                    + "'" + CustomerNumber + "'"
                    + ",'" + CustomerName + "'"
                    + ")";
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                cnn.Close();
                ErrorTxt = "";
                return 0;
            }
            catch (Exception ex)
            {
                ErrorTxt = "SQL Fejl - " + ex.Message;
                return 99;
            }

        }
        private int ValidateCustomerDB(string CustomerNumber, out string CustomerName, out string Errortxt)
        {
            CustomerName = "";
            try
            {
                var Customer = new DataTable();
                string sql = "SELECT * FROM Customer WHERE CustomerNumber=" + CustomerNumber;
                using (var da = new SqlDataAdapter(sql, connectionString))
                {
                    da.Fill(Customer);
                }

                if (Customer.Rows.Count==0)
                {
                    Errortxt = "Medlemsnummer ikke fundet i databasen";
                    return -1; 
                }
                CustomerName = Customer.Rows[0]["CustomerName"].ToString();
            }
            catch (Exception ex)
            {
                Errortxt="SQL Fejl: " + ex.Message;
                return 99;
            }

            Errortxt = "";
            return 0;

        }

        private void pnl_Products_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_Logo_Click(object sender, EventArgs e)
        {

        }
    }


    



}
