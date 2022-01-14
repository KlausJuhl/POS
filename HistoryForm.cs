using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_POSTransaction.DataSource = getPOSTransaction();
                dgv_POSTransaction.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv_POSTransaction.Columns[3].Width = 60;
                dgv_POSTransaction.Columns[4].DefaultCellStyle.Format = "0.00##";
                dgv_POSTransaction.Columns[5].DefaultCellStyle.Format = "0.00##";

            }
            catch 
            { 
            }

        }

        private DataTable getPOSTransaction()
        {
            DataTable dt = new DataTable();

            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SelfServicePOS"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    string SelectTxt = "SELECT TOP 100 POSTimestamp as DatoTid, CustomerNumber as Medlemsnummer, Product.ProductName, Quantity as Antal, cast(UnitNetPrice as money) as Pris, cast(Quantity* UnitNetPrice as money) as Total FROM POSTransaction INNER JOIN Product ON Product.ProductNumber = POSTransaction.ProductNumber";

                    if (txt_Customer.Text != "")
                        SelectTxt = SelectTxt + " WHERE CustomerNumber=" + txt_Customer.Text;
                    SelectTxt = SelectTxt + "  ORDER BY POSTransId Desc";

                    using (SqlCommand cmd = new SqlCommand(SelectTxt, con))
                    {
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Fejl -"+ex.Message);
            }
            return dt;

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_POSTransaction.DataSource = getPOSTransaction();
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

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgv_POSTransaction.DataSource = getPOSTransaction();

            }
        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Customer.Text = "";
            dgv_POSTransaction.DataSource = getPOSTransaction();
            txt_Customer.Focus();

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
