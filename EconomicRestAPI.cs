using EconomicDraftInvoices;
using EconomicDraftInvoice;
using RestSharp;
using System.Text.Json;
using System;
using Paymentterms = EconomicDraftInvoice.Paymentterms;
using Customer = EconomicDraftInvoice.Customer;
using Recipient = EconomicDraftInvoice.Recipient;
using References = EconomicDraftInvoice.References;
using EconomicCustomers;
using Layout = EconomicDraftInvoice.Layout;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;

namespace EconomicDraftInvoices
{

    public class DraftInvoices
    {
        public Collection[] collection { get; set; }
        public Pagination pagination { get; set; }
        public string self { get; set; }
    }

    public class Pagination
    {
        public int maxPageSizeAllowed { get; set; }
        public int skipPages { get; set; }
        public int pageSize { get; set; }
        public int results { get; set; }
        public int resultsWithoutFilter { get; set; }
        public string firstPage { get; set; }
        public string lastPage { get; set; }
    }

    public class Collection
    {
        public int draftInvoiceNumber { get; set; }
        public Soap soap { get; set; }
        public Templates templates { get; set; }
        public string date { get; set; }
        public string currency { get; set; }
        public float exchangeRate { get; set; }
        public float netAmount { get; set; }
        public float netAmountInBaseCurrency { get; set; }
        public float grossAmount { get; set; }
        public float grossAmountInBaseCurrency { get; set; }
        public float marginInBaseCurrency { get; set; }
        public float marginPercentage { get; set; }
        public float vatAmount { get; set; }
        public float roundingAmount { get; set; }
        public float costPriceInBaseCurrency { get; set; }
        public string dueDate { get; set; }
        public Paymentterms paymentTerms { get; set; }
        public Customer customer { get; set; }
        public Recipient recipient { get; set; }
        public References references { get; set; }
        public Layout layout { get; set; }
        public Pdf pdf { get; set; }
        public string self { get; set; }
    }

    public class Soap
    {
        public Currentinvoicehandle currentInvoiceHandle { get; set; }
    }

    public class Currentinvoicehandle
    {
        public int id { get; set; }
    }

    public class Templates
    {
        public string bookingInstructions { get; set; }
        public string self { get; set; }
    }

    public class Paymentterms
    {
        public int paymentTermsNumber { get; set; }
        public int daysOfCredit { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string paymentTermsType { get; set; }
        public string self { get; set; }
    }

    public class Customer
    {
        public int customerNumber { get; set; }
        public string self { get; set; }
    }

    public class Recipient
    {
        public string name { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public Vatzone vatZone { get; set; }
    }

    public class Vatzone
    {
        public string name { get; set; }
        public int vatZoneNumber { get; set; }
        public bool enabledForCustomer { get; set; }
        public bool enabledForSupplier { get; set; }
        public string self { get; set; }
    }

    public class References
    {
        public string other { get; set; }
    }

    public class Layout
    {
        public int layoutNumber { get; set; }
        public string self { get; set; }
    }

    public class Pdf
    {
        public string download { get; set; }
    }







}

namespace EconomicDraftInvoice
{


    public class DraftInvoice
    {
        public int draftInvoiceNumber { get; set; }
        public Soap soap { get; set; }
        public Templates templates { get; set; }
        public Line[] lines { get; set; }
        public string date { get; set; }
        public string currency { get; set; }
        public float exchangeRate { get; set; }
        public float netAmount { get; set; }
        public float netAmountInBaseCurrency { get; set; }
        public float grossAmount { get; set; }
        public float grossAmountInBaseCurrency { get; set; }
        public float marginInBaseCurrency { get; set; }
        public float marginPercentage { get; set; }
        public float vatAmount { get; set; }
        public float roundingAmount { get; set; }
        public float costPriceInBaseCurrency { get; set; }
        public string dueDate { get; set; }
        public Paymentterms paymentTerms { get; set; }
        public Customer customer { get; set; }
        public Recipient recipient { get; set; }
        public References references { get; set; }
        public Layout layout { get; set; }
        public Pdf pdf { get; set; }
        public string self { get; set; }
    }

    public class Soap
    {
        public Currentinvoicehandle currentInvoiceHandle { get; set; }
    }

    public class Currentinvoicehandle
    {
        public int id { get; set; }
    }

    public class Templates
    {
        public string bookingInstructions { get; set; }
        public string self { get; set; }
    }

    public class Paymentterms
    {
        public int paymentTermsNumber { get; set; }
        public int daysOfCredit { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string paymentTermsType { get; set; }
        public string self { get; set; }
    }

    public class Customer
    {
        public int customerNumber { get; set; }
        public string self { get; set; }
    }

    public class Recipient
    {
        public string name { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public Vatzone vatZone { get; set; }
    }

    public class Vatzone
    {
        public string name { get; set; }
        public int vatZoneNumber { get; set; }
        public bool enabledForCustomer { get; set; }
        public bool enabledForSupplier { get; set; }
        public string self { get; set; }
    }

    public class References
    {
        public string other { get; set; }
    }

    public class Layout
    {
        public int layoutNumber { get; set; }
        public string self { get; set; }
    }

    public class Pdf
    {
        public string download { get; set; }
    }

    public class Line
    {
        public int lineNumber { get; set; }
        public int sortKey { get; set; }
        public string description { get; set; }
        public Product product { get; set; }
        public float quantity { get; set; }
        public float unitNetPrice { get; set; }
        public float discountPercentage { get; set; }
        public float unitCostPrice { get; set; }
        public float totalNetAmount { get; set; }
        public float marginInBaseCurrency { get; set; }
        public float marginPercentage { get; set; }
    }

    public class Product
    {
        public string productNumber { get; set; }
        public string self { get; set; }
    }

}

namespace EconomicCustomers
{


    public class Customer
    {
        public int customerNumber { get; set; }
        public string currency { get; set; }
        public Paymentterms paymentTerms { get; set; }
        public Customergroup customerGroup { get; set; }
        public string address { get; set; }
        public float balance { get; set; }
        public float dueAmount { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string zip { get; set; }
        public string telephoneAndFaxNumber { get; set; }
        public Vatzone vatZone { get; set; }
        public DateTime lastUpdated { get; set; }
        public string contacts { get; set; }
        public Templates templates { get; set; }
        public Totals totals { get; set; }
        public string deliveryLocations { get; set; }
        public Invoices invoices { get; set; }
        public bool eInvoicingDisabledByDefault { get; set; }
        public Metadata metaData { get; set; }
        public string self { get; set; }

        public static int FindCustomer(string CustomerNumber, out string CustomerName)
        {
            int ErrorCode = 0;
            RestRequest request;
            EconomicCustomers.Customer Customer;

            CustomerName = "";

            string EconAgreementGrantToken = ConfigurationManager.AppSettings["EconAgreementGrantToken"];
            string EconAppSecretToken = ConfigurationManager.AppSettings["EconAppSecretToken"];

            var client = new RestClient("https://restapi.e-conomic.com")
            .AddDefaultHeader("X-AppSecretToken", EconAppSecretToken)
            .AddDefaultHeader("X-AgreementGrantToken", EconAgreementGrantToken)
            .AddDefaultHeader("Content-Type", "application/json");

            try
            {
                Console.WriteLine("Find Customer " + CustomerNumber);

                request = new RestRequest("customers/" + CustomerNumber, Method.Get);
                var r = client.Execute(request);


                if (r.IsSuccessful)
                {
                    Console.WriteLine("GET Customer success ");
                    Customer = JsonSerializer.Deserialize<EconomicCustomers.Customer>(r.Content);
                    CustomerName = Customer.name;
                }
                else
                {
                    Console.WriteLine("GET Customer failed: " + r.Content);
                    MessageBox.Show("GET Customer failed: " + r.Content);
                    ErrorCode = 91;
                }



                return ErrorCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine("customers/ failed, {0}", ex);
                MessageBox.Show("GET Customer failed: " + ex.Message);

                return 99;
            }
        }



    }

    public class Paymentterms
    {
        public int paymentTermsNumber { get; set; }
        public string self { get; set; }
    }

    public class Customergroup
    {
        public int customerGroupNumber { get; set; }
        public string self { get; set; }
    }

    public class Vatzone
    {
        public int vatZoneNumber { get; set; }
        public string self { get; set; }
    }

    public class Templates
    {
        public string invoice { get; set; }
        public string invoiceLine { get; set; }
        public string self { get; set; }
    }

    public class Totals
    {
        public string drafts { get; set; }
        public string booked { get; set; }
        public string self { get; set; }
    }

    public class Invoices
    {
        public string drafts { get; set; }
        public string booked { get; set; }
        public string self { get; set; }
    }

    public class Metadata
    {
        public Delete delete { get; set; }
        public Replace replace { get; set; }
    }

    public class Delete
    {
        public string description { get; set; }
        public string href { get; set; }
        public string httpMethod { get; set; }
    }

    public class Replace
    {
        public string description { get; set; }
        public string href { get; set; }
        public string httpMethod { get; set; }
    }

    



}


public class EconomicRESTAPIThread
{

    // Non-static method
    //public async void ecothread()
    public void ecothread()

    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SelfServicePOS"].ConnectionString;
        SqlConnection cnn;
        cnn = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        var EcoPOS = new DataTable();

        while (true)
        {
            // wait 
            Thread.Sleep(10000);


            try
            {
                cnn.Open();

                EcoPOS.Clear();

                adapter.SelectCommand = new SqlCommand("SELECT * FROM EcoPOS WHERE EcoBooked is NULL", cnn);
                adapter.Fill(EcoPOS);



                for (int i = 0; i < EcoPOS.Rows.Count; i++)
                {

                    if (!int.TryParse(EcoPOS.Rows[i]["CustomerNumber"].ToString(), out int CustomerNumber))
                        CustomerNumber = 0;

                    //if (!int.TryParse(EcoPOS.Rows[i]["ProductNumber"].ToString(), out int ProductNumber))
                    //    ProductNumber = 0;
                    String ProductNumber = EcoPOS.Rows[i]["ProductNumber"].ToString();

                    if (!int.TryParse(EcoPOS.Rows[i]["Quantity"].ToString(), out int Qty))
                        Qty = 0;

                    if (!float.TryParse(EcoPOS.Rows[i]["Total"].ToString(), out float Total))
                        Total = 0;

                    //int ErrorCode = await ProcessEconomicPOSTransactionRESTAPI(CustomerNumber, ProductNumber, Qty, Total);
                    int ErrorCode = ProcessEconomicPOSTransactionRESTAPI(CustomerNumber, ProductNumber, Qty, Total, out string ErrorText);


                    String sql = "UPDATE EcoPOS SET "
                    + " EcoBooked=getdate()"
                    + ", EcoErrorCode=" + ErrorCode.ToString()
                    + ", EcoErrorText='" + ErrorText.Replace("'", "\"") + "'"
                    + " WHERE EcoPosId=" + EcoPOS.Rows[i]["EcoPosId"];

                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();




                }

                cnn.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Fejl:, {0}", ex);

            }

        }

    }




    //private static async Task<int> ProcessEconomicPOSTransactionRESTAPI(int CustomerNumber, string ProductPartnumber, int Qty, float Price, out string ErrorText)
    public static int ProcessEconomicPOSTransactionRESTAPI(int CustomerNumber, string ProductPartnumber, int Qty, float Price, out string ErrorText)
    {
        int ErrorCode = 0;
        ErrorText = "";

        int invoiceNumber;
        int Linefound;
        RestRequest request;
        RestResponse response;
        DraftInvoice DraftInvoice;
        EconomicCustomers.Customer Customer;

        string OtherRef = "POS";  // Invoice otherref used by the POS aplication


        string EconAgreementGrantToken = ConfigurationManager.AppSettings["EconAgreementGrantToken"];
        string EconAppSecretToken = ConfigurationManager.AppSettings["EconAppSecretToken"];

        var client = new RestClient("https://restapi.e-conomic.com")
        .AddDefaultHeader("X-AppSecretToken", EconAppSecretToken)
        .AddDefaultHeader("X-AgreementGrantToken", EconAgreementGrantToken)
        .AddDefaultHeader("Content-Type", "application/json");

        try
        {
            // Liste over fakturaer
            // https://restapi.e-conomic.com/invoices/drafts?filter=customer.customerNumber$eq:[1459]$and:references.other$eq:[POS]
            Console.WriteLine("Find existing POS-Invoice for Customer " + CustomerNumber);
            request = new RestRequest("invoices/drafts?filter=customer.customerNumber$eq:" + CustomerNumber + "$and:references.other$eq:" + OtherRef);
            
            //response = await client.GetAsync(request);
            response = client.Execute(request);
            
            // Find faktura nummer i draftInvoiceNumber
            DraftInvoices DraftInvoices = JsonSerializer.Deserialize<DraftInvoices>(response.Content);

            if (DraftInvoices.collection.Length > 0)
            {
                invoiceNumber = DraftInvoices.collection[0].draftInvoiceNumber;
                Console.WriteLine("Faktura fundet " + invoiceNumber);
            }
            else
                invoiceNumber = 0;

            Console.WriteLine(response.StatusCode.ToString() + " " + response.StatusDescription);

            if (invoiceNumber != 0)
            {
                // Hent faktura, inkl. linjer
                // https://restapi.e-conomic.com/invoices/drafts/[InvoiceNumber]
                Console.WriteLine("Get invoice " + invoiceNumber);
                request = new RestRequest("invoices/drafts/" + invoiceNumber);
                //response = await client.GetAsync(request);
                response = client.Execute(request);

                DraftInvoice = JsonSerializer.Deserialize<DraftInvoice>(response.Content);

                Console.WriteLine(response.StatusCode.ToString() + " " + response.StatusDescription);
                Console.WriteLine("Faktura hentet");



                // Find linje med korrekt varenummer 
                Linefound = -1;
                int length = 0;
                if (null != DraftInvoice.lines)
                {
                    for (int i = 0; i < DraftInvoice.lines.Length; i++)
                    {
                        if (DraftInvoice.lines[i].product.productNumber == ProductPartnumber)
                        {
                            Linefound = i;
                            break;
                        }
                    }
                    length = DraftInvoice.lines.Length;
                }

                // Hvis linje findes - opdater beløb på linje lokalt i C#
                if (Linefound != -1)
                {
                    Console.WriteLine("Ordreline/Product found - Price updated from {0} to {1}", DraftInvoice.lines[Linefound].unitNetPrice, DraftInvoice.lines[Linefound].unitNetPrice + Price);

                    DraftInvoice.lines[Linefound].unitNetPrice = DraftInvoice.lines[Linefound].unitNetPrice + Price;
                }
                else
                // Hvis linje ikke findes - Opret fakturalinje lokalt i C#
                {
                    Console.WriteLine("Ordreline/Product not found on draft invoice ");

                    Linefound = length;

                    var obj = DraftInvoice.lines;
                    Array.Resize(ref obj, length + 1);
                    DraftInvoice.lines = obj;

                    DraftInvoice.lines[Linefound] = new Line();
                    DraftInvoice.lines[Linefound].lineNumber = Linefound + 1;
                    DraftInvoice.lines[Linefound].sortKey = Linefound + 1;
                    DraftInvoice.lines[Linefound].description = "Kantine";
                    DraftInvoice.lines[Linefound].product = new Product();
                    DraftInvoice.lines[Linefound].product.productNumber = ProductPartnumber;
                    DraftInvoice.lines[Linefound].product.self = "https://restapi.e-conomic.com/products/" + ProductPartnumber;
                    DraftInvoice.lines[Linefound].quantity = 1;
                    DraftInvoice.lines[Linefound].unitNetPrice = Price;
                    DraftInvoice.lines[Linefound].totalNetAmount = Price;
                    DraftInvoice.lines[Linefound].marginInBaseCurrency = Price;

                }


                // Når faktura er korrekt i C# opdateres den i Economics
                // PUT /invoices/drafts/[draftInvoiceNumber]
                request = new RestRequest("/invoices/drafts/" + invoiceNumber, Method.Put)
                .AddJsonBody(DraftInvoice);
                var r = client.Execute(request);

                if (r.IsSuccessful)
                {
                    Console.WriteLine("PUT DraftInvoice success ");
                }
                else
                {
                    Console.WriteLine("PUT DraftInvoice failed: " + r.Content);
                    ErrorText = "PUT DraftInvoice failed: " + r.Content;
                    ErrorCode = 97;
                }



            }


            else
            {
                // Hvis faktura ikke findes, opret en ny af type POS

                // Find Customer
                request = new RestRequest("customers/" + CustomerNumber);
                //response = await client.GetAsync(request);
                response = client.Execute(request);

                Customer = JsonSerializer.Deserialize<EconomicCustomers.Customer>(response.Content);


                // POST /invoices/drafts
                // Required properties: currency, customer, date, layout, paymentTerms, recipient, recipient.name, recipient.vatZone
                Linefound = 0;
                DraftInvoice = new DraftInvoice();

                DraftInvoice.date = DateTime.Now.ToString("yyyy-MM-dd");
                DraftInvoice.currency = "DKK";
                DraftInvoice.exchangeRate = (float)100.0;
                //DraftInvoice.netAmount = 0;
                //netAmountInBaseCurrency 
                //grossAmount
                //grossAmountInBaseCurrency
                //marginInBaseCurrency
                //marginPercentage
                //vatAmount
                //roundingAmount
                //costPriceInBaseCurrency
                DraftInvoice.dueDate = DateTime.Now.ToString("yyyy-MM-dd");


                DraftInvoice.paymentTerms = new Paymentterms();
                DraftInvoice.paymentTerms.paymentTermsNumber = 1;
                //"daysOfCredit": 8,
                //"description": "Opkræves via BS",
                //"name": "BS",
                DraftInvoice.paymentTerms.paymentTermsType = "net";
                DraftInvoice.paymentTerms.self = "https://restapi.e-conomic.com/payment-terms/1";

                DraftInvoice.customer = new Customer();
                DraftInvoice.customer.customerNumber = CustomerNumber;
                DraftInvoice.customer.self = Customer.self;

                DraftInvoice.recipient = new Recipient();
                DraftInvoice.recipient.name = Customer.name;
                DraftInvoice.recipient.address = Customer.address;
                DraftInvoice.recipient.zip = Customer.zip;
                DraftInvoice.recipient.city = Customer.city;

                DraftInvoice.recipient.vatZone = new EconomicDraftInvoice.Vatzone();
                DraftInvoice.recipient.vatZone.name = "Domestic";
                DraftInvoice.recipient.vatZone.vatZoneNumber = 1;
                DraftInvoice.recipient.vatZone.enabledForCustomer = true;
                DraftInvoice.recipient.vatZone.enabledForSupplier = true;
                DraftInvoice.recipient.vatZone.self = "https://restapi.e-conomic.com/vat-zones/1";

                DraftInvoice.references = new References();
                DraftInvoice.references.other = OtherRef;

                Line[] obj = new Line[1];
                DraftInvoice.lines = obj;

                DraftInvoice.lines[Linefound] = new Line();
                DraftInvoice.lines[Linefound].lineNumber = Linefound + 1;
                DraftInvoice.lines[Linefound].sortKey = Linefound + 1;
                DraftInvoice.lines[Linefound].description = "Kantine";
                DraftInvoice.lines[Linefound].product = new Product();
                DraftInvoice.lines[Linefound].product.productNumber = ProductPartnumber;
                DraftInvoice.lines[Linefound].product.self = "https://restapi.e-conomic.com/products/" + ProductPartnumber;
                DraftInvoice.lines[Linefound].quantity = 1;
                DraftInvoice.lines[Linefound].unitNetPrice = Price;
                DraftInvoice.lines[Linefound].totalNetAmount = Price;
                DraftInvoice.lines[Linefound].marginInBaseCurrency = Price;

                DraftInvoice.layout = new Layout();
                DraftInvoice.layout.layoutNumber = 14;
                DraftInvoice.layout.self = "https://restapi.e-conomic.com/layouts/14";

                DraftInvoice.pdf = new EconomicDraftInvoice.Pdf();
                DraftInvoice.pdf.download = "https://restapi.e-conomic.com/invoices/drafts/27694/pdf";


                // Når faktura er korrekt i C# indsættes den i Economics
                // POST /invoices/drafts/[draftInvoiceNumber]
                request = new RestRequest("/invoices/drafts", Method.Post)
                .AddJsonBody(DraftInvoice);
                var r = client.Execute(request);

                if (r.IsSuccessful)
                {
                    Console.WriteLine("POST DraftInvoice success ");
                }
                else
                {
                    Console.WriteLine("POST DraftInvoice failed: " + r.Content);
                    ErrorText = "POST DraftInvoice failed: " + r.Content;
                    ErrorCode = 98;
                }



            }





            return ErrorCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine("invoices/drafts failed, {0}", ex);
            ErrorText=ex.Message;
            return 99;
        }

    }
    



}
