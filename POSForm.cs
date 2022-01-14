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
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.econSoap;

namespace POS
{
    

    public partial class POSForm : Form
    {
        public string LogoPath { get; private set; }
        public string CashRegSoundPath { get; private set; }
        public string ProductPath { get; private set; }
        public string connetionString { get; private set; }
        public static string EconAgreementGrantToken { get; private set; }
        public static string EconAppSecretToken { get; private set; }
        public string Exitcode { get; private set; }
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
            if (POSTransaction(txt_Customer.Text, "Kantine", 1, Total, out txt) != 0)
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

            connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SelfServicePOS"].ConnectionString;


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
            
            this.ActiveControl = txt_Customer;
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
                        Application.Exit();
                    }
                    txt_Customer.Text = "";
                    txt_Customer.Focus();
                    return;

                }
                // look-up customer
                using (var session = new EconomicWebServiceSoapClient())
                {
                    // Set cursor as hourglass
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        Connect(session);

                        // Find Debtor
                        DebtorHandle DebtorHandle = session.Debtor_FindByNumber(txt_Customer.Text);
                        DebtorData DebtorData = session.Debtor_GetData(DebtorHandle);

                        if (DebtorHandle is null || DebtorData is null)
                        {
                            lbl_LastPurchase.Text = "Medlemsnummer " + txt_Customer.Text + " ikke fundet i Economic";
                            lbl_LastPurchase.ForeColor = Color.Red;
                            System.Media.SystemSounds.Hand.Play();
                            txt_Customer.Text = "";
                            txt_Customer.Focus();
                        }
                        else
                        {
                            txt_Name.Text = DebtorData.Name;

                            lbl_LastPurchase.Text = "";
                            lbl_LastPurchase.ForeColor = Color.Black;
                        }
                        session.Disconnect();
                        
                    }
                    catch (Exception ex)
                    {
                        lbl_LastPurchase.Text = "Economic Fejl - " + ex.Message;
                        lbl_LastPurchase.ForeColor = Color.Red;
                        System.Media.SystemSounds.Hand.Play();
                        txt_Customer.Text = "";
                        txt_Customer.Focus();

                    }
                    // Set cursor as default arrow
                    Cursor.Current = Cursors.Default;
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

            if (item1 != null)
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

        private static void Connect(EconomicWebServiceSoapClient session)
        {
            // A necessary setting as the session is put in a cookie
            ((BasicHttpBinding)session.Endpoint.Binding).AllowCookies = true;

            using (new OperationContextScope(session.InnerChannel))
            {
                session.ConnectWithToken(EconAgreementGrantToken, EconAppSecretToken);
                
            }
        }

        public static int POSTransaction(string Customer, String ProductPartnumber, int Qty, decimal Price, out string ErrorTxt)
        {
            string OtherRef = "POS";  // Invoice otherref used by the POS aplication
            ErrorTxt = "";
            int ErrorCode = 0;
            
            try
            {

                using (var session = new EconomicWebServiceSoapClient())
                {
                    Connect(session);

                    // Find Debtor
                    var DebtorHandle = session.Debtor_FindByNumber(Customer);

                    if (DebtorHandle is null)
                    {
                        ErrorTxt = "Debtor not found, Number: " + Customer;
                        session.Disconnect();
                        return 1;
                    }

                    var ProductHandle = session.Product_FindByName(ProductPartnumber);
                    if (ProductHandle is null)
                    {
                        ErrorTxt = "Product not found, PartNumber: " + ProductPartnumber;
                        session.Disconnect();
                        return 2;
                    }

                    // Search existing invoice for customer of OtherRef 
                    var currentInvoiceHandles = session.CurrentInvoice_FindByOtherReference(OtherRef);

                    DebtorData InvoiceDebtorData;
                    Boolean InvoiceFound = false;
                    Boolean InvoiceLineFound = false;
                    DebtorHandle InvoiceDebtorHandle;
                    CurrentInvoiceHandle currentInvoiceHandle = default;
                    CurrentInvoiceData currentInvoiceData;
                    CurrentInvoiceLineData currentInvoiceLineData = default;

                    if (currentInvoiceHandles.Length > 0)
                    {
                        // Find Invoice for actual customer
                        for (int i = 0; i < currentInvoiceHandles.Length; i++)
                        {
                            // next invoice
                            currentInvoiceHandle = currentInvoiceHandles[i];
                            currentInvoiceData = session.CurrentInvoice_GetData(currentInvoiceHandle);

                            // Debtor
                            InvoiceDebtorHandle = currentInvoiceData.DebtorHandle;
                            InvoiceDebtorData = session.Debtor_GetData(InvoiceDebtorHandle);

                            if (InvoiceDebtorData.Number == Customer)
                            {
                                InvoiceFound = true;
                                break;
                            }
                        }
                    }

                    if (InvoiceFound)
                    {
                        //CurrentInvoiceLine_FindByCurrentInvoiceList
                        CurrentInvoiceHandle[] CurrentInvoiceHandleArray = new CurrentInvoiceHandle[1];
                        CurrentInvoiceHandleArray[0] = currentInvoiceHandle;
                        var CurrentInvoiceLineHandles = session.CurrentInvoiceLine_FindByCurrentInvoiceList(CurrentInvoiceHandleArray);

                        // Find invoice line
                        for (int line = 0; line < CurrentInvoiceLineHandles.Length; line++)
                        {
                            // next line
                            var currentInvoiceLineHandle = CurrentInvoiceLineHandles[line];
                            currentInvoiceLineData = session.CurrentInvoiceLine_GetData(currentInvoiceLineHandle);
                            var InvoiceLineProductHandle = currentInvoiceLineData.ProductHandle;
                            var ProductData = session.Product_GetData(InvoiceLineProductHandle);

                            if (ProductData.Name == ProductPartnumber)
                            {
                                InvoiceLineFound = true;
                                break;
                            }
                        }

                        if (InvoiceLineFound)
                        {
                            //InvoiceLine found - update Price
                            //Qty unchanged, allways = 1
                            currentInvoiceLineData.UnitNetPrice = currentInvoiceLineData.UnitNetPrice + Price;
                            session.CurrentInvoiceLine_UpdateFromData(currentInvoiceLineData);
                        }
                        else
                        {
                            // Add invoice line
                            ErrorCode=AddInvoiceLine(session, currentInvoiceHandle, ProductHandle[0], ProductPartnumber, Qty, Price, out ErrorTxt);
                        }
                    }
                    else
                    {
                        // Invoice not found - adding invoice
                        var InvoiceHandle = session.CurrentInvoice_Create(DebtorHandle);

                        // Set OtherRef = "Kantine"
                        session.CurrentInvoice_SetOtherReference(InvoiceHandle, OtherRef);

                        // Adding lines
                        ErrorCode=AddInvoiceLine(session, InvoiceHandle, ProductHandle[0], ProductPartnumber, Qty, Price, out ErrorTxt);
                    }

                    session.Disconnect();
                }
                return ErrorCode;
            }
            catch (Exception ex)
            {
                ErrorTxt = "Economic Fejl - " + ex.Message;
                return 99;
            }

        }

        public static int AddInvoiceLine(EconomicWebServiceSoapClient session, CurrentInvoiceHandle InvoiceHandle, ProductHandle ProductHandle, string ProductPartnumber, int Qty, decimal Price, out string ErrorTxt)
        {
            try
            {
                CurrentInvoiceLineData Invoiceline = new CurrentInvoiceLineData();
                Invoiceline.InvoiceHandle = InvoiceHandle;
                Invoiceline.ProductHandle = ProductHandle;
                Invoiceline.Description = ProductPartnumber;
                Invoiceline.Quantity = Qty;
                Invoiceline.UnitNetPrice = Price;

                session.CurrentInvoiceLine_CreateFromData(Invoiceline);
                ErrorTxt = "";
                return 0;
            }
            catch(Exception ex)
            {
                ErrorTxt = "Economic Fejl - " + ex.Message;
                return 99;
            }
        }

        private int LogPOSTransactionToDB(out string ErrorTxt)
        {
            try
            {
                // Log to database SelfServicePOS
                SqlConnection cnn;
                cnn = new SqlConnection(connetionString);
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
                using (var da = new SqlDataAdapter("SELECT * FROM Product", connetionString))
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
    }
}
