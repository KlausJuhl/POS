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
                LogPOSTransactionToDB();

                // Show last order in label, in bottom of screen
                lbl_LastPurchase.Text = localDate.ToString()
                    + " " + txt_Name.Text
                    + " " + txt_Total.Text + " DKK";
                lbl_LastPurchase.ForeColor = Color.Black;

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

            connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SelfServicePOS"].ConnectionString;


            // Load logo
            pic_Logo.ImageLocation = LogoPath;

            // Place buttons relative to window size
            btn_Close.Left = pnl_Toppanel.Left + pnl_Toppanel.Width - btn_Close.Width - 10;
            btn_History.Left = pnl_Toppanel.Left + pnl_Toppanel.Width -btn_History.Width -20 - btn_Close.Width - 10;

            pnl_Customer.Dock = DockStyle.Fill;

            lbl_Header.Left = (pnl_Toppanel.Width-lbl_Header.Width)/2;

            // Load products
            pictureBox1.ImageLocation = ProductPath + "Sodavand.jpg";
            pictureBox2.ImageLocation = ProductPath + "Øl.jpg";
            pictureBox3.ImageLocation = ProductPath + "Is.jpg";


            lbl_LastPurchase.Text = "";
            
            txt_Customer.Focus();
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
                // look-up customer
                using (var session = new EconomicWebServiceSoapClient())
                {
                    // Set cursor as hourglass
                    Cursor.Current = Cursors.WaitCursor;

                    Connect(session);

                    // Find Debtor
                    var DebtorHandle = session.Debtor_FindByNumber(txt_Customer.Text);
                    var DebtorData = session.Debtor_GetData(DebtorHandle);

                    if (DebtorHandle is null || DebtorData is null)
                    {
                        lbl_LastPurchase.Text = "Medlemsnummer ikke fundet i Economic";
                        lbl_LastPurchase.ForeColor = Color.Red;

                        // Play Error sound
                        System.Media.SystemSounds.Hand.Play();

                        txt_Customer.Focus();
                    }
                    else
                    {
                        txt_Name.Text = DebtorData.Name;

                        lbl_LastPurchase.Text = "";
                        lbl_LastPurchase.ForeColor = Color.Black;
                    }
                    session.Disconnect();
                    // Set cursor as default arrow
                    Cursor.Current = Cursors.Default;
                }

                

                
            }
        }

       private void PurchaseItem(int productid, string product, int qty, float price)
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
            ListViewItem item1 = lsv_ShoppingCart.FindItemWithText(productid.ToString());

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
                item1.SubItems[4].Text = itemTotal.ToString();

            }

            else
            {
                // Not found -> Insert
                ListViewItem listItem = new ListViewItem(productid.ToString(), 0); // productid
                listItem.SubItems.Add(product); //product
                listItem.SubItems.Add(qty.ToString()); //Qty
                listItem.SubItems.Add(price.ToString()); //Pris
                listItem.SubItems.Add(price.ToString()); //Total
                lsv_ShoppingCart.Items.Add(listItem);

                lsv_ShoppingCart.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
            
            if (!float.TryParse(txt_Total.Text, out float Total))
            { 
                Total = 0;
            }
            Total += price;

            txt_Total.Text = Total.ToString();
        }

       

        private void btn_Close_Click(object sender, EventArgs e)
        {
            // Display the password form.
            /*
            PasswordForm frm = new PasswordForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {*/
                Application.Exit();
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Indsæt i listen
            if (sender == pictureBox1)
                PurchaseItem(1, "Sodavand", 1, 10);
            else if (sender == pictureBox2)
                PurchaseItem(2, "Øl", 1, 10);
            else if (sender == pictureBox3)
                PurchaseItem(3, "Is", 1, 10);
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
                        AddInvoiceLine(session, currentInvoiceHandle, ProductHandle[0], ProductPartnumber, Qty, Price, out ErrorTxt);
                    }
                }
                else
                {
                    // Invoice not found - adding invoice
                    var InvoiceHandle = session.CurrentInvoice_Create(DebtorHandle);

                    // Set OtherRef = "Kantine"
                    session.CurrentInvoice_SetOtherReference(InvoiceHandle, OtherRef);

                    // Adding lines
                    AddInvoiceLine(session, InvoiceHandle, ProductHandle[0], ProductPartnumber, Qty, Price, out ErrorTxt);
                }

                session.Disconnect();
            }
            return 0;
        }

        public static int AddInvoiceLine(EconomicWebServiceSoapClient session, CurrentInvoiceHandle InvoiceHandle, ProductHandle ProductHandle, string ProductPartnumber, int Qty, decimal Price, out string ErrorTxt)
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

        private int LogPOSTransactionToDB()
        {
            // Log to database SelfServicePOS
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();

            for (int i = 0; i < lsv_ShoppingCart.Items.Count; i++)
            {
                String sql = "INSERT INTO POSTransaction (POSTimestamp, CustomerNumber, ProductNumber, Quantity, UnitNetPrice) values(getdate(),"
                    + "'" + txt_Customer.Text + "'"
                    + ",'" + lsv_ShoppingCart.Items[i].SubItems[0].Text + "'"  //Productid
                    + "," + lsv_ShoppingCart.Items[i].SubItems[2].Text  //Quantity
                    + "," + lsv_ShoppingCart.Items[i].SubItems[3].Text  //Price
                    + ")";
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
            }

            cnn.Close();
            return 0;

        }



    }
}
